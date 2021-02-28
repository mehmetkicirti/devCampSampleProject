using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    // Attribute => Class ile ilgili bilgi almamızı kendini ona göre yapılandırmak için 
    [ApiController] // C# => Attribute Java => Annotation
    public class ProductsController : ControllerBase
    {   
        // Bir katman başka bir katmana asla soyut olarak bağlı olmamalı
        // Managerlar çoğul hale gelebilir isteklere göre 
        // Loosely Coupled => Gevşek soyuta bağladık manager'a göre değişecek
        // Javascript de ver interface'i kullan fakat C# ve Javada IOC container ile DI yöntemi ile somutunu vermemiz gerekiyor 
        private readonly IProductService _iProductService;
        public ProductsController(IProductService productService)
        {
            _iProductService = productService;
        }
        [HttpGet]
        public IDataResult<List<Product>> Get()
        {
            return _iProductService.GetAll();
        }
    }
}
