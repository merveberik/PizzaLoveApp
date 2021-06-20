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
    public class PizzaManager : IPizzaService
    {
        private IPizzaDal _pizzaDal;

        public PizzaManager(IPizzaDal pizzaDal)
        {
            _pizzaDal = pizzaDal;
        }

        public void Create(Pizza entity)
        {
            _pizzaDal.Create(entity);
        }

        public void Delete(Pizza entity)
        {
            _pizzaDal.Delete(entity);
        }

        public List<Pizza> GetAll()
        {
            return _pizzaDal.GetAll();
        }

        public Pizza GetById(int id)
        {
            return _pizzaDal.GetById(id);
        }

        public void Update(Pizza entity)
        {
            _pizzaDal.Update(entity);
        }
    }
}
