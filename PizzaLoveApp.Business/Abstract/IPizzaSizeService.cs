using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Business.Abstract
{
    public interface IPizzaSizeService
    {
        List<PizzaSize> GetAll();
        PizzaSize GetById(int id);
        void Create(PizzaSize entity);
        void Update(PizzaSize entity);
        void Delete(PizzaSize entity);
    }
}
