﻿using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product entitiy)
        {
            _productDal.Create(entitiy);
        }

        public void Delete(Product entitiy)
        {
            _productDal.Delete(entitiy);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategories(string category)
        {
            return _productDal.GetProductsByCategories(category);
        }

        public void Update(Product entitiy)
        {
            _productDal.Update(entitiy);
        }
    }
}