﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Entities
{
    public class PizzaSize
    {
        public int PizzaSizeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product{ get; set; }

    }
}
