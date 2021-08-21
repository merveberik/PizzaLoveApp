using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.Business.Concrete
{
    public class SizeManager : ISizeService
    {
        private ISizeDal _sizeDal;

        public SizeManager(ISizeDal sizeDal)
        {
            _sizeDal = sizeDal;
        }

        public Size GetById(int id)
        {
            return _sizeDal.GetById(id);
        }

        public List<Size> GetAll()
        {
            return _sizeDal.GetAll();
        }

        public void Create(Size entity)
        {
            _sizeDal.Create(entity);
        }

        public void Update(Size entity)
        {
            _sizeDal.Update(entity);
        }

        public void Delete(Size entity)
        {
            _sizeDal.Delete(entity);
        }

        public Size GetByIdWithSize(int sizeId)
        {
            return _sizeDal.GetByIdWithSize(sizeId);
        }

        public void DeleteFromSize(int sizeId, int productId)
        {
            _sizeDal.DeleteFromSize(sizeId,productId);
        }
    }
}
