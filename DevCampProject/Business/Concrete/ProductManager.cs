using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Aspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Business;
namespace Business.Concrete
{
    public class ProductManager: IProductService
    {
        private readonly IProductDal _iProductDal;
        private readonly ICategoryService _iCategoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _iProductDal = productDal;
            _iCategoryService = categoryService;
        }
        // ikisi farklıdır
        // business code => bizim iş ihtiyaçlarımıza uygunluk ör=> bir kişiye ehliyet vericez veya kredi vericez bunlara uygun olup olmadığına bakmak ilkyardımdan 70 üzeri almışmı veya finansal kredisi yeterli mi
        // validation => nesnenin yapısal olarak doğru olup olmadığını kontrolüdür. Şifre şuna uymalı, min bu karakter olmalı gibi
        //if (product.UnitPrice <= 0)
        //{
        //    return new ErrorResult(Messages.UnitPriceInvalid)
        //}
        //if (product.ProductName.Length < 2)
        //{
        //    return new ErrorResult(Messages.ProductNameInvalid);
        //}
        //ValidationTool.Validate(new ProductValidator(), product);
        //Loglama
        //cacheRemove
        //Performance
        // Transaction
        // Authorization
        // böyle yaparsak çorba olucak bu yüzden AOP tekniği ile Attiribute ile ekleyerek ilgili validator'u veya işlemleri bulucak ve metodun başında sonunda veya hata anında bu işlemleri yapacak.
        //[Transaction]
        //[Performance]
        //[LogAspect] => AOP ile sağlayacağımız yapı
        [ValidationAspect(typeof(ProductValidator))] // bu işlem bu metodu doğrula girmeden gönderdiğim validate sınıfı ile
        public IResult Add(Product product)
        {
            //business code => Yönetim tarafından ortaya koyulan kurallar yer olur
            //Work 1 => bir kategoride en fazla 10 ürün olabilir eklenmek istenen üründe
            //Work 2 => aynı isimde ürün eklenemez
            //Work 3 => Eğer mevcut category sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryID),
                CheckProductNameAlreadyDefined(product.ProductName), CountOfCategoryBoundaryPassed());
            if (result != null)
            {
                return result;
            };
            _iProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        //İş sürecleri bir çok noktada kullanıcaksa DRY Prensibi ve Solid Prensibine uygun bir şekilde metod haline dönüştürülmeli
        private IResult CheckProductNameAlreadyDefined(string productName)
        {
            if(_iProductDal.GetAll(p=>p.ProductName == productName).Any())
            {
                return new ErrorResult(Messages.ProductNameAlreadyDefined);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            // Select count(*) from Products as p where p.CategoryID = categoryId
            if (_iProductDal.GetAll(p => p.CategoryID == categoryId).Count < 10)
            {
                return new ErrorResult(Messages.AddedProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        public IResult Delete(Product product)
        {
            _iProductDal.Remove(product);
            return new SuccessResult(Messages.ProductRemoved);

        }
        private IResult CountOfCategoryBoundaryPassed()
        {
            if (_iCategoryService.GetAll().Data.Count > 15) {
                return new ErrorResult(Messages.CountOfCategoryBoundaryPassed);
            };
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(),Messages.ProductsListed);
        }
        
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(p => p.ProductID == id), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList(),Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_iProductDal.Get(p => p.ProductID == productId),Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_iProductDal.GetProductDetails(), Messages.ProductsListed);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _iProductDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
