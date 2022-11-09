using InnoGotchiWebAPI.Domain.Interfaces.Repositories;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }
    }
}
