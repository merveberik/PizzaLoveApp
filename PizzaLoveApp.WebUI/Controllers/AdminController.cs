using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.Entities;
using PizzaLoveApp.WebUI.Models;

namespace PizzaLoveApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel product)
        {
            var entity = new Product()
            {
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description,
                Size = product.Size
            };

            _productService.Create(entity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Size = entity.Size
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel product)
        {
            var entity = _productService.GetById(product.Id);
            if(entity == null)
            {
                return NotFound();
            }
            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.ImageUrl = product.ImageUrl;
            entity.Size = product.Size;

            _productService.Update(entity);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("Index");
        }
    }
}
