
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class CollaborationRepository : ICollaborationRepository
    {
        private MainDbContext context;

        public CollaborationRepository(MainDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            var collaboration = FindById(id);
            context.Remove(collaboration);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByName(string collaborationName)
        {
            var collaboration = FindByName(collaborationName);
            context.Remove(collaboration);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Collaboration>> FindAll()
        {
            return await context.Collaboration.AsNoTracking().ToListAsync();
        }

        public async Task<Collaboration> FindById(int id)
        {
            return await context.Collaboration.AsNoTracking().SingleAsync(b => b.Id == id);
        }

        public async Task<Collaboration> FindByName(string collaborationName)
        {
            return await context.Collaboration.AsNoTracking().SingleAsync(a => a.Name == collaborationName);
        }

        public async Task Update(Collaboration collaboration)
        {
            context.Update(collaboration);
            await context.SaveChangesAsync();
        }
    }
}
