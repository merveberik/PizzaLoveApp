using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.DataAccess.Abstract
{
    public interface IProductDal:IRepository<Product>
    {
        Product GetProductDetails(int id);
        List<Product> GetProductsByCategories(string category);
        Product GetByIdWithCategories(int id);
        Product GetByIdWithSize(int id);
        void Update(Product entity, int[] categoryIds);
        void Create(Product entity, int[] categoryIds);
        void Create(Product entity, int[] categoryIds, int[] sizeIds);
        void Update(Product entity, int[] categoryIds, int[] sizeIds);
    }
}
