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
        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Ürün ismi minimum 5 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Ürün açıklaması minimum 10 karakter olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Fiyat Belirtiniz.")]
        [Range(1, 1000)]
        public decimal? Price { get; set; }
        public int Size { get; set; }

        public List<Category> SelectedCategories = new List<Category>();
    }
}
