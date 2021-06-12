using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Business.Concrete
{
    public class SpecialPizzaManager : ISpecialPizzaService
    {
        private ISpecialPizzaDal _specialPizzaDal;

        public SpecialPizzaManager(ISpecialPizzaDal specialPizzaDal)
        {
            _specialPizzaDal = specialPizzaDal;
        }

        public void Create(SpecialPizza entity)
        {
            _specialPizzaDal.Create(entity);
        }

        public void Delete(SpecialPizza entity)
        {
            _specialPizzaDal.Delete(entity);
        }

        public List<SpecialPizza> GetAll()
        {
            return _specialPizzaDal.GetAll();
        }

        public void Update(SpecialPizza entity)
        {
            _specialPizzaDal.Delete(entity);
        }
    }
}
