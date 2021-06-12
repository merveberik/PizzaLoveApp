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
        List<Pizza> Getall();
        Pizza GetById(int id);
        void Create(Pizza entitiy);
        void Update(Pizza entitiy);
        void Delete(Pizza entitiy);
    }
}
