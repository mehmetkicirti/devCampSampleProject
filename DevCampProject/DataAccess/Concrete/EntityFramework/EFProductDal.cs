using Core.DataAccess.EF;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFRepositoryBase<Product, NortwindContext>, IProductDal
    {

        public List<ProductDetailDto> GetProductDetails()
        {
            using (var context = new NortwindContext())
            {
                var productDetails = from p in context.Products
                                                        join c in context.Categories on p.ProductID equals c.CategoryID
                                                        select new ProductDetailDto
                                                        {
                                                            CategoryName = c.CategoryName,
                                                            ProductId = p.ProductID,
                                                            ProductName = p.ProductName,
                                                            UnitPrice = p.UnitPrice
                                                        };
                return productDetails.ToList();
            }
        }
    }
}
