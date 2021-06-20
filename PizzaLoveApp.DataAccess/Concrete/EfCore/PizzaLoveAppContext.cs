using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaLoveApp.Entities;

namespace PizzaLoveApp.DataAccess.Concrete.EfCore
{
    public class PizzaLoveAppContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PizzaLoveApp;Trusted_Connection=true;");
            // Create local DB
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=PizzaLoveApp;integrated security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ProductCategory>()
                .HasKey(c => new { c.CategoryId, c.ProductId , c.PizzaSizeId});
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<SpecialPizza> SpecialPizzas { get; set; }
    }
}
