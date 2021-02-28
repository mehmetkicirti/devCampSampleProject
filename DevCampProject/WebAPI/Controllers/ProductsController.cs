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
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            // Swagger => ile dökümantasyon hazırlanır
            var result =  _iProductService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _iProductService.Add(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _iProductService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
