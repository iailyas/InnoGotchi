using InnoGotchiWebAPI.Domain.Interfaces.Repositories;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class CharacteristicRepository : RepositoryBase<Characteristic>, ICharacteristicRepository
    {
        public CharacteristicRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }
    }
}
