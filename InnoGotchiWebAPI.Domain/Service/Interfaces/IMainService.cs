using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Linq.Expressions;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface IMainService<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(int id);
        void Create(T entity);
        void Update(int id);
        void Delete(int id);
    }
}
