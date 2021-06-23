using Microsoft.AspNetCore.Mvc;
using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                //SelectedCateogry = RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll()
            });
        }
    }
}
