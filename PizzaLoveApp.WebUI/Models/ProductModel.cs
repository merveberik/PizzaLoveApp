using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resim Ekleyiniz.")]
        [DisplayName("Resim Ekle")]
        public string ImageUrl { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat Belirtiniz.")]
        [DisplayName("Fiyat")]
        public decimal? Price { get; set; }
        [DisplayName("Boyutu")]
        public int Size { get; set; }
        [DisplayName("Ürün Puanı")]
        public decimal PointPrize { get; set; }

        public List<Category> SelectedCategories = new List<Category>();
    }
}
