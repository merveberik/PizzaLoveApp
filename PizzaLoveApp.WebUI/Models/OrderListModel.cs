﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.WebUI.Models
{
    public class OrderListModel
    {

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public EnumOrderState OrderState { get; set; }
        public EnumPaymentTypes PaymentTypes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }

        /*
         * liste tutacağız
         */

        public List<OrderItemModel> OrderItems { get; set; }

        public decimal TotalPrice()
        {
            return OrderItems.Sum(i => i.Price * i.Quantity);
        }

        public decimal TotalPrizePoint()
        {
            return OrderItems.Sum(i => i.PointPrize * i.Quantity);
        }
    }

    public class OrderItemModel
    {
        public int OrderItemId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal PointPrize { get; set; }
    }

}
