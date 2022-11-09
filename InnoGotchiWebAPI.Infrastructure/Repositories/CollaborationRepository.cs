using InnoGotchiWebAPI.Domain.Interfaces.Repositories;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class CollaborationRepository : RepositoryBase<Collaboration>, ICollaborationRepository
    {
        public CollaborationRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }
    }
}
