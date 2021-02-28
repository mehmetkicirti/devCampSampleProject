using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager: IProductService
    {
        private readonly IProductDal _iProductDal;
        public ProductManager(IProductDal productDal)
        {
            _iProductDal = productDal;
        }

        //[Validate]
        //[Transaction]
        //[Performance]
        //[LogAspect] => AOP ile sağlayacağımız yapı
        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _iProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _iProductDal.Remove(product);
            return new SuccessResult(Messages.ProductRemoved);

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

        public IResult Update(Product product)
        {
            _iProductDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
