using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.Business.Abstract
{
    public interface ISizeService
    {
        Size GetById(int id);
        List<Size> GetAll();

        void Create(Size entity);
        void Update(Size entity);
        void Delete(Size entity);

        Size GetByIdWithSize(int id);
        void DeleteFromSize(int sizeId, int productId);
    }
}
