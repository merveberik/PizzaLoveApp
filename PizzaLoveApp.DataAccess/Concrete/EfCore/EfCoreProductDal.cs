using Microsoft.EntityFrameworkCore;
using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, PizzaLoveAppContext>, IProductDal
    {
        public Product GetProductDetails(int id)
        {
            using (var context = new PizzaLoveAppContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategories(string category)
        {
            using (var context = new PizzaLoveAppContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.ToList();
            }
        }

        public Product GetByIdWithCategories(int id)
        {
            using (var context = new PizzaLoveAppContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new PizzaLoveAppContext())
            {
                var product = context.Products
                    .Include(i => i.ProductCategories)
                    .FirstOrDefault(i => i.Id == entity.Id);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.ImageUrl = entity.ImageUrl;
                    product.Description = entity.Description;
                    product.PointPrize = entity.PointPrize;
                    product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                    {
                        CategoryId = catId,
                        ProductId = product.Id
                    }).ToList();

                    context.SaveChanges();
                }

            }
        }

        public void Create(Product entity, int[] categoryIds)
        {
            using (var context = new PizzaLoveAppContext())
            {
                if (entity != null)
                {
                    Product product = new Product();
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.ImageUrl = entity.ImageUrl;
                    product.Description = entity.Description;
                    product.PointPrize = entity.PointPrize;
                    product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                    {
                        CategoryId = catId,
                        ProductId = product.Id
                    }).ToList();

                    context.Products.Add(product);
                    context.SaveChanges();
                }

            }
        }
    }
}
