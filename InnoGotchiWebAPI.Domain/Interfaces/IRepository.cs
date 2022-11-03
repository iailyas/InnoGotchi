using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace InnoGotchiWebAPI.Domain.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        DbSet<T> Entities { get; }
        DbContext dbContext { get; }

        Task<IList> GetAllAsync();
        T Find(params object[] keyValues);
        Task<T> FindAsync(params object[] keyValues);
        Task InsertAsync(params object[] keyValues);
        Task InsertRangeAsync(IEnumerable objects, bool savechanges = true);
        Task DeleteAsync(int id, bool savechanges = true);
        Task DeleteAsync(T entity, bool savechanges = true);
        Task DeleteRangeAsync(IEnumerable objects, bool savechanges = true);


    }
}
