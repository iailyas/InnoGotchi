using System.Linq.Expressions;

namespace InnoGotchiWebAPI.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> exception,
            bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);



    }
}
