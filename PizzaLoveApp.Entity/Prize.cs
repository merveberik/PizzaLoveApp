using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Entities
{
    public class Prize
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public decimal CartPoint { get; set; }

    }
}
