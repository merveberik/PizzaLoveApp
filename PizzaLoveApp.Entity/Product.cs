using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(60)]

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
