using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetProductsByCategories(string category);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
        void Create(Product entity, int[] categoryIds);
    }
}
