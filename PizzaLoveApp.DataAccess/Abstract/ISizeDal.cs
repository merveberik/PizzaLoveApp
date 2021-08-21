using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.DataAccess.Abstract
{
    public interface ISizeDal : IRepository<Size>
    {
        Size GetByIdWithSize(int id);
        void DeleteFromSize(int sizeId, int productId);
    }
}
