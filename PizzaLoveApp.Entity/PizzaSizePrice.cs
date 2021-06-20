using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Entities
{
    public class PizzaSizePrice
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
    }
}
