using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Save()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(ProductCategory cat)
        {
            productCategories.Add(cat);
        }

        public void Update(ProductCategory cat)
        {
            ProductCategory ProductCategorytToUpdate = productCategories.Find(c => c.ID == cat.ID);
            if (ProductCategorytToUpdate != null)
            {
                ProductCategorytToUpdate = cat;
            }
            else
            {
                throw new Exception("Product Category Not Found!");
            }

        }
        public ProductCategory Find(String ID)
        {
            ProductCategory productCategory = productCategories.Find(c => c.ID == ID);
            if (productCategories != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found!");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string ID)
        {

            ProductCategory productCategoryToBeDeleted = productCategories.Find(c => c.ID == ID);
            if (productCategoryToBeDeleted != null)
            {
                productCategories.Remove(productCategoryToBeDeleted);
            }
            else
            {
                throw new Exception("Product Category Not Found!");
            }
        }
    }
}
