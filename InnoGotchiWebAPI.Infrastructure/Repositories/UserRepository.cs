using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Interfaces.Repositories;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {

        }

        public void Create(UserDTO entity)
        {
           mainDbContext.Add(entity);
        }
    }
}
