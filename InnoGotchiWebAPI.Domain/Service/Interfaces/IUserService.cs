using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Interfaces.Repositories;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface IUserService : IMainService<User>
    {
        public void Create(UserDTO entity);
    }
}
