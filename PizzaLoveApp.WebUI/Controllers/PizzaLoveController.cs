using Microsoft.AspNetCore.Mvc;
using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.Entities;
using PizzaLoveApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.Controllers
{
    public class PizzaLoveController : Controller
    {

        private IProductService _productService;

        public PizzaLoveController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("products/{category?}")]
        public IActionResult List(string category)
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetProductsByCategories(category)
            });
        }

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
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
            
        }
    }
}
