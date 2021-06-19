using Microsoft.AspNetCore.Mvc;
using PizzaLoveApp.Business.Abstract;
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

        public IActionResult List()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}
