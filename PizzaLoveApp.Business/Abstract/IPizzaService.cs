using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Business.Abstract
{
    public interface IPizzaService
    {
        List<Pizza> GetAll();
        Pizza GetById(int id);
        void Create(Pizza entity);
        void Update(Pizza entity);
        void Delete(Pizza entity);
    }
}
