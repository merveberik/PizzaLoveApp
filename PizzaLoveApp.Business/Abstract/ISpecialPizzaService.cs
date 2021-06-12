using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Business.Abstract
{
    public interface ISpecialPizzaService
    {
        List<SpecialPizza> GetAll();
        void Create(SpecialPizza entity);
        void Update(SpecialPizza entity);
        void Delete(SpecialPizza entity);
    }
}
