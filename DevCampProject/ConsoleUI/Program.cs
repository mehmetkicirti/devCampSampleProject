using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
        }
        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            var result = productManager.GetProductDetails();
            if (result.IsSuccess)
            {
                foreach (var item in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine($"{item.ProductName} / {item.CategoryName}");
                }
            }
            else Console.WriteLine(result.IsSuccess);
        }
    }
}
