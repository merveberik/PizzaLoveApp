using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PizzaLoveApp.WebUI.Models;

namespace PizzaLoveApp.WebUI.Controllers
{
    /*
     * TODO API'ye login işlemleri eklenecek
     */
    [Route("api/[controller]")]
    [ApiController]

    public class IonicController : ControllerBase
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public IonicController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("productlist")]
        public List<Product> ProductList()
        {
            return _productService.GetAll();

        }

        [HttpGet("categorylist")]
        public List<Category> CategoryList()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("products/{category?}")]
        public List<Product> ProductListWithCategory(string category)
        {
            return _productService.GetProductsByCategories(category);
        }

        [HttpGet("details/{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails((int)id);

            if (product == null)
            {
                return NotFound();
            }

            return new ObjectResult(product);
        }



    }


}
