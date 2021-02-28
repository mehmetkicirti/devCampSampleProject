using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager: IProductService
    {
        private readonly IProductDal _iProductDal;
        public ProductManager(IProductDal productDal)
        {
            _iProductDal = productDal;
        }

        public void Add(Product product)
        {
            _iProductDal.Add(product);
        }

        public void Delete(Product product)
        {
            _iProductDal.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _iProductDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _iProductDal.GetAll(p => p.ProductID == id).ToList();
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _iProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
        }

        public Product GetById(int productId)
        {
            return _iProductDal.Get(p => p.ProductID == productId);
        }

        public void Update(Product product)
        {
            _iProductDal.Update(product);
        }
    }
}
