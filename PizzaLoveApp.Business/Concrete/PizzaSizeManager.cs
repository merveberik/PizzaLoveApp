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
    public class PizzaSizeManager : IPizzaSizeService
    {
        private IPizzaSizeDal _pizzaSizeDal;

        public PizzaSizeManager(IPizzaSizeDal pizzaSizeDal)
        {
            _pizzaSizeDal = pizzaSizeDal;
        }

        public void Create(PizzaSize entity)
        {
            _pizzaSizeDal.Create(entity);
        }

        public void Delete(PizzaSize entity)
        {
            _pizzaSizeDal.Delete(entity);
        }

        public List<PizzaSize> GetAll()
        {
            return _pizzaSizeDal.GetAll();
        }

        public PizzaSize GetById(int id)
        {
            return _pizzaSizeDal.GetById(id);
        }

        public void Update(PizzaSize entity)
        {
            _pizzaSizeDal.Update(entity);
        }
    }
}
