using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
    }
}
