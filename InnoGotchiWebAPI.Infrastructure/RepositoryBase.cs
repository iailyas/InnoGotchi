using InnoGotchiWebAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InnoGotchiWebAPI.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected MainDbContext mainDbContext;

        public RepositoryBase(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public void Create(T entity) => mainDbContext.Set<T>().Add(entity);

        public void Delete(T entity) => mainDbContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            mainDbContext.Set<T>()
            .AsNoTracking() :
            mainDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            mainDbContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            mainDbContext.Set<T>()
            .Where(expression);


        public void Update(T entity) => mainDbContext.Set<T>().Update(entity);
    }
}
