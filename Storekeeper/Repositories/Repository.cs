using Microsoft.EntityFrameworkCore;
using Storekeeper.Data;
using System.Linq;

namespace Storekeeper.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected StorekeeperDbContext _storekeeperDbContext { get; set; }

        public Repository(StorekeeperDbContext storekeeperDbContext)
        {
            _storekeeperDbContext = storekeeperDbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _storekeeperDbContext.Set<T>().AsNoTracking();
        }

        public T GetById(int id)
        {
            return _storekeeperDbContext.Set<T>().Find(id);
        } 

        public void Create(T entity)
        {
            _storekeeperDbContext.Set<T>().Add(entity);
            _storekeeperDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _storekeeperDbContext.Set<T>().Update(entity);
            _storekeeperDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _storekeeperDbContext.Set<T>().Find(id);
            _storekeeperDbContext.Set<T>().Remove(entity);
            _storekeeperDbContext.SaveChanges();
        }
    }
}
