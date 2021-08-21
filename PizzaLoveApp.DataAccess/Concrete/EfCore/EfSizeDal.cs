using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.DataAccess.Concrete.EfCore
{
    public class EfSizeDal : EfCoreGenericRepository<Size, PizzaLoveAppContext>, ISizeDal
    {
        public Size GetByIdWithSize(int sizeId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                return context.Sizes
                    .Where(i => i.Id == sizeId)
                    .Include(i => i.ProductSizes)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }

        public void DeleteFromSize(int sizeId, int productId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                var cmd = @"delete from ProductSize where ProductId=@p0 and SizeId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, sizeId);
            }
        }
    }
}
