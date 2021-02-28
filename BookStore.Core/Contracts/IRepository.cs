using BookStore.Core.Models;
using System.Linq;

namespace BookStore.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Delete(string ID);
        T Find(string ID);
        void Insert(T t);
        void Save();
        void Update(T t);
    }
}