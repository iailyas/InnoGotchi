using InnoGotchiWebAPI.Domain.Interfaces.Repositories;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class LookRepository : RepositoryBase<Look>, ILookRepository
    {
        public LookRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }
    }
}
