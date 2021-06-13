using Microsoft.EntityFrameworkCore;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new PizzaLoveAppContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                }
                context.SaveChanges();
            }
        }
        
        private static Category[] Categories =
        {
            new Category(){ Name="Pizza"},
            new Category(){ Name="Hambuger"},
            new Category(){ Name="Kahvaltı"},
            new Category(){ Name="İçecekler"},
        };

        private static Product[] Products = { 
            new Product(){ Name="Kavurmalı Pizza",Price=35,ImageUrl="1.jpg",Description="Dana etli pizza"},
            new Product(){ Name="Vegan Pizza",Price=40,ImageUrl="2.jpg",Description="Etsiz pizza"},
            new Product(){ Name="Akdenizli Pizza",Price=25,ImageUrl="3.jpg",Description="zeytinli peynirli pizza"},
            new Product(){ Name="Tavuk Burger",Price=20,ImageUrl="4.jpg",Description="Tavuklu Burger"},
            new Product(){ Name="Kadri Burger",Price=25,ImageUrl="5.jpg",Description="Yerli Burger"},
            new Product(){ Name="Kavurmalı Burger",Price=30,ImageUrl="6.jpg",Description="Kavurmalı yerli Burger"},
            new Product(){ Name="Serpme Kahvaltı",Price=70,ImageUrl="7.jpg",Description="Zeytin, Peynir, Tereyağı, Bal, Kaymak, Pekmezli Tahin, çay, yumurta, keçi sütü, Kızrtma "},
            new Product(){ Name="Tepsi Kahvaltı",Price=60,ImageUrl="8.jpg",Description="Tepside gelen 2 kişilik serpme kahvaltı"},
            new Product(){ Name="Köy Kahvaltısı",Price=120,ImageUrl="9.jpg",Description="A101 ve Bimden alınan malzemeler ile köy kahvaltısı ile satılan kahvaltı"},
            new Product(){ Name="Limonata",Price=7,ImageUrl="10.jpg",Description="Ev yapımı ama burada yapılan limonata"},
            new Product(){ Name="Çay",Price=3,ImageUrl="11.jpg",Description="Rize tomurcuk çayı"},
            new Product(){ Name="Kahve",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
        };

        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[3],Category=Categories[1]},
            new ProductCategory(){Product=Products[4],Category=Categories[1]},
            new ProductCategory(){Product=Products[5],Category=Categories[1]},
            new ProductCategory(){Product=Products[6],Category=Categories[2]},
            new ProductCategory(){Product=Products[7],Category=Categories[2]},
            new ProductCategory(){Product=Products[8],Category=Categories[2]},
            new ProductCategory(){Product=Products[9],Category=Categories[3]},
            new ProductCategory(){Product=Products[10],Category=Categories[3]},
            new ProductCategory(){Product=Products[11],Category=Categories[3]},
        };
    }
}
