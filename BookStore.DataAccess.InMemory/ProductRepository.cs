using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using BookStore.Core;
using BookStore.Core.Models;

namespace BookStore.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }
        public void Save()
        {
            cache["products"] = products;
        }
        public void Insert(Product prod)
        {
            products.Add(prod);
        }

        public void Update(Product prod)
        {
            Product ProductToUpdate = products.Find(p => p.ID == prod.ID);
            if (ProductToUpdate != null)
            {
                ProductToUpdate = prod;
            }
            else
            {
                throw new Exception("Product Not Found!");
            }

        }
        public Product Find(String ID)
        {
            Product product = products.Find(p => p.ID == ID);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Not Found!");
            }
        }
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string ID)
        {

            Product productToBeDeleted = products.Find(p => p.ID == ID);
            if (productToBeDeleted != null)
            {
                products.Remove(productToBeDeleted);
            }
            else
            {
                throw new Exception("Product Not Found!");
            }
        }
    }
}
