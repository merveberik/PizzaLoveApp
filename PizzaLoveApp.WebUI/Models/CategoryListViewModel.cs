using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCateogry { get; set; }
        public List<Category> Categories { get; set; }
    }
}
