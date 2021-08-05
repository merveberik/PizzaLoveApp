using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün Adı Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resim Ekleyiniz.")]
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat Belirtiniz.")]
        public decimal? Price { get; set; }
        public int Size { get; set; }

        public List<Category> SelectedCategories = new List<Category>();
    }
}
