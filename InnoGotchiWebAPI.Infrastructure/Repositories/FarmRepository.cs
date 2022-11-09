using InnoGotchiWebAPI.Domain.Interfaces.Repositories;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class FarmRepository : RepositoryBase<Farm>, IFarmRepository
    {
        public FarmRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }
    }
}
