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
                    context.AddRange(ProductCategory);
                }
                context.SaveChanges();
            }
        }
        
        private static Category[] Categories =
        {
            new Category(){ Name="En Çok Tercih Edilenler"},
            new Category(){ Name="Pizza Menüler"},
            new Category(){ Name="Tekli Pizzalar ve Çeşitleri"},
            new Category(){ Name="Patso Menüler"},
            new Category(){ Name="Burger Menüler"},
            new Category(){ Name="Pilav Menüleri"},
            new Category(){ Name="Çıtır Menüler"},
            new Category(){ Name="Çorbalar"},
            new Category(){ Name="Salatalar"},
            new Category(){ Name="Yan Ürünler"},
            new Category(){ Name="Tatlılar"},
            new Category(){ Name="İçecekler"},
        };

        private static Product[] Products = {
            new Product(){ Name="Çıtır Tavuk Döner Menü",Price=35,ImageUrl="1.jpg",Description="Dana etli pizza"},
            new Product(){ Name="Tavuklu Nohutlu Pilav Menü",Price=35,ImageUrl="1.jpg",Description="Dana etli pizza"},
            new Product(){ Name="Sporcu Fit Menü",Price=35,ImageUrl="1.jpg",Description="Dana etli pizza"},
            new Product(){ Name="Ye-Doy Menü",Price=35,ImageUrl="1.jpg",Description="Dana etli pizza"},
            new Product(){ Name="3'lü Fırsat Menü",Price=40,ImageUrl="2.jpg",Description="Etsiz pizza"},
            new Product(){ Name="Ye-Doy Plus Menü",Price=25,ImageUrl="3.jpg",Description="zeytinli peynirli pizza"},
            new Product(){ Name="Vegan Pizza",Price=40,ImageUrl="2.jpg",Description="Etsiz pizza"},
            new Product(){ Name="Akdenizli Pizza",Price=25,ImageUrl="3.jpg",Description="zeytinli peynirli pizza"},
            new Product(){ Name="Mix Pizza",Price=25,ImageUrl="3.jpg",Description="zeytinli peynirli pizza"},
            new Product(){ Name="Ekmek Arası Sosisli Patso Sandviç Menü",Price=70,ImageUrl="7.jpg",Description="Zeytin, Peynir, Tereyağı, Bal, Kaymak, Pekmezli Tahin, çay, yumurta, keçi sütü, Kızrtma "},
            new Product(){ Name="Ekmek Arası Patso Menü",Price=60,ImageUrl="8.jpg",Description="Tepside gelen 2 kişilik serpme kahvaltı"},
            new Product(){ Name="Kankim Menü",Price=120,ImageUrl="9.jpg",Description="A101 ve Bimden alınan malzemeler ile köy kahvaltısı ile satılan kahvaltı"},
            new Product(){ Name="Chicken Menü",Price=7,ImageUrl="10.jpg",Description="Ev yapımı ama burada yapılan limonata"},
            new Product(){ Name="Kavurmalı Nohutlu Pilav",Price=3,ImageUrl="11.jpg",Description="Rize tomurcuk çayı"},
            new Product(){ Name="Nohutlu pilav Menü",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="4'lü Çıtır Partisi Menü",Price=35,ImageUrl="1.jpg",Description="Dana etli pizza"},
            new Product(){ Name="Sporcu Fit Menü",Price=35,ImageUrl="1.jpg",Description="Dana etli pizza"},
            new Product(){ Name="Mercimek Çorbası",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="Mevsim Salata",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="Çıtır Tavuklu Salata",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="Patates Kızartması",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="Çıtır Tavuk Crispy",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="Fırın Sütlaç",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="Pepsi",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
            new Product(){ Name="Tropicana",Price=8,ImageUrl="12.jpg",Description="sade türk kahvesi"},
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
            new ProductCategory(){Product=Products[11],Category=Categories[4]},
            new ProductCategory(){Product=Products[12],Category=Categories[4]},
            new ProductCategory(){Product=Products[13],Category=Categories[5]},
            new ProductCategory(){Product=Products[14],Category=Categories[5]},
            new ProductCategory(){Product=Products[15],Category=Categories[6]},
            new ProductCategory(){Product=Products[16],Category=Categories[6]},
            new ProductCategory(){Product=Products[17],Category=Categories[7]},
            new ProductCategory(){Product=Products[18],Category=Categories[8]},
            new ProductCategory(){Product=Products[19],Category=Categories[8]},
            new ProductCategory(){Product=Products[20],Category=Categories[9]},
            new ProductCategory(){Product=Products[21],Category=Categories[9]},
            new ProductCategory(){Product=Products[22],Category=Categories[10]},
            new ProductCategory(){Product=Products[23],Category=Categories[11]},
            new ProductCategory(){Product=Products[24],Category=Categories[11]},
        };

        //private static SpecialPizza[] SpecialPizzas =
        //{
        //    new SpecialPizza(){Name="Tonbalıklı pizza",Price=30,ImageUrl="13.jpg",Description="Akdenizden çıkartılan özenle hazırlanmış tonbalıkları ile süslenmiş pizza"},
        //    new SpecialPizza(){Name="Kapya biberli pizza",Price=22,ImageUrl="14.jpg",Description="Mevsime özel kırmızı ve yeşil kapya biberli pizza"}
        //};
    }
}
