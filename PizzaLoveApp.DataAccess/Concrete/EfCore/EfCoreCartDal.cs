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
    class EfCoreCartDal : EfCoreGenericRepository<Cart, PizzaLoveAppContext>, ICartDal
    {
        public Cart GetByUserId(string userId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                return context
                    .Carts
                    .Include(i => i.CartItems)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault(i => i.UserId == userId);
            }
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0 and ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public void ClearCart(string cartId)
        {
            using (var context = new PizzaLoveAppContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0";
                context.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }

        public override void Update(Cart entity)
        {
            using (var context = new PizzaLoveAppContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }

    }
}
