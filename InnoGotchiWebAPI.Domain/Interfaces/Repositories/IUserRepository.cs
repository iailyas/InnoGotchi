using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        void Create(UserDTO entity);
    }
}
