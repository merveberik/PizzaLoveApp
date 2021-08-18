using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
