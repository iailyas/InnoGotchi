using InnoGotchiWebAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InnoGotchiWebAPI.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected MainDbContext mainDbContext;

        public RepositoryBase(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public void Create(T entity) => mainDbContext.Set<T>().Add(entity);

        public void Delete(T entity) => mainDbContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() => mainDbContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> exception) => mainDbContext.Set<T>().Where(exception).AsNoTracking();

        public void Update(T entity) => mainDbContext.Set<T>().Update(entity);
    }
}
