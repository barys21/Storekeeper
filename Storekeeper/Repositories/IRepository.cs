using System;
using System.Linq;
using System.Linq.Expressions;

namespace Storekeeper.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
