using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.DataAccess.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        List<Order> GetOrders(string userId);
        List<Order> GetOrders();
    }
}
