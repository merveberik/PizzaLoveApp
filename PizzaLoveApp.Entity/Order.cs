using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
