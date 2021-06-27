using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }

        public List<Category> SelectedCategories = new List<Category>();
    }
}
