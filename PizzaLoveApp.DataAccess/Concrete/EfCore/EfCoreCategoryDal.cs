using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PizzaLoveApp.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, PizzaLoveAppContext>, ICategoryDal
    {
        public Category GetByIdWithProducts(int categoryId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                return context.Categories
                    .Where(i => i.Id == categoryId)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }

        public void DeleteFromCategory(int categoryId, int productId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }
    }
}
