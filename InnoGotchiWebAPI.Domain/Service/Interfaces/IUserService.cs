using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using Microsoft.AspNetCore.Hosting;


namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> FindAll();
        Task<User> FindById(int id);
        Task<User> FindByName(string lastName);
        Task<String> Create(UserDTO entity, IWebHostEnvironment webHostEnvironment);
        Task AddCollaborationToUser(int id, AddCollaborationToUserDTO collaborationDTO);
        Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO);
        Task Update(User user);
        Task Delete(int id);
        Task DeleteByName(string userName);
    }
}
