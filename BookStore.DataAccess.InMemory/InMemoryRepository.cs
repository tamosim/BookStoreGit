using BookStore.Core.Contracts;
using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        String ClassName;

        public InMemoryRepository()
        {
            ClassName = typeof(T).Name; //reflection
            items = cache[ClassName] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }
        public void Save()
        {
            cache[ClassName] = items;
        }
        public void Insert(T t)
        {
            items.Add(t);
        }
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.ID == t.ID);
            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(ClassName + "Not Found!");
            }
        }
        public T Find(String ID)
        {
            T t = items.Find(i => i.ID == ID);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(ClassName + "Not Found!");
            }
        }
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }
        public void Delete(String ID)
        {
            T tToDelete = items.Find(i => i.ID == ID);
            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(ClassName + "Not Found!");
            }
        }
    }
}
