using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PizzaLoveApp.DataAccess.Concrete.EfCore
{
    public class EfCoreOrderDal : EfCoreGenericRepository<Order, PizzaLoveAppContext>, IOrderDal
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                var orders = context.Orders
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Product)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserId == userId);
                }


                return orders.ToList();
            }
        }

        public List<Order> GetOrders()
        {
            using (var context = new PizzaLoveAppContext())
            {
                var orders = context.Orders
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Product).ToList();

                return orders;
            }
        }
    }
}
