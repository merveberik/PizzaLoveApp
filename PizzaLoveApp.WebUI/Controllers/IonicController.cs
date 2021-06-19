using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class IonicController : ControllerBase
    {
        IProductService _productService;

        public IonicController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "merhaba";
        //}

        [HttpGet("getall")]
        public List<Product> GetAll()
        {

            return _productService.GetAll();

        }
    }


}
