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
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult ProductList()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.Categories = _categoryService.GetAll();
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
            };

            _productService.Create(entity);

            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int)id);

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
                SelectedCategories = entity.ProductCategories.Select(i =>i.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductModel product)
        {
            var entity = _productService.GetById(product.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.ImageUrl = product.ImageUrl;

            _productService.Update(entity);

            return RedirectToAction("ProductList");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    Name = model.Name
                };

                _categoryService.Create(entity);

                return RedirectToAction("CategoryList");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditCategory(int categoryId)
        {
            var entity = _categoryService.GetByIdWithProducts(categoryId);

            if (entity != null)
            {
                return View(new CategoryModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Products = entity.ProductCategories.Select(p => p.Product).ToList()
                });
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);

            if (entity == null)
                return NotFound();

            entity.Name = model.Name;
            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteFromCategory(int categoryId, int productId)
        {
            _categoryService.DeleteFromCategory(categoryId, productId);
            return RedirectToAction("CategoryList");
        }
    }
}
