using System;
using System.Collections.Generic;
using DataLayer;
using System.Linq;

namespace Services
{
    public class ProductService
    {

            readonly Repository<Product, Product, Product> _Repository;

            static ProductService instance;
            ProductService(String path)
            {
                _Repository = new Repository<Product, Product, Product>(path);
            }
            public static ProductService GetInstance(String path)
            {
                if (instance is null)
                {
                    instance = new ProductService(path);
                }
                return instance;
            }
            public List<Product> GetAll()
            {

                return _Repository.GetAll().ToList();

            }
            public Product Get(int Id)
            {
                List<Product> items = GetAll();
                return items.FirstOrDefault(s => s.Id == Id);
            }
            public Product Update() { return null; }
            public Product Delete(int Id) { return null; }
    }
}
