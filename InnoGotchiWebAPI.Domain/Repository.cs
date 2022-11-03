using InnoGotchiWebAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchiWebAPI.Domain
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> Entities => throw new NotImplementedException();

        public DbContext dbContext => throw new NotImplementedException();

        public Task DeleteAsync(int id, bool savechanges = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity, bool savechanges = true)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable objects, bool savechanges = true)
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<IList> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task InsertRangeAsync(IEnumerable objects, bool savechanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
