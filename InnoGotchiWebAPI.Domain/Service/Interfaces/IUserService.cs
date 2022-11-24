using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;
using Microsoft.AspNetCore.Hosting;


namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserCommand>> FindAll();
        Task<UserCommand> FindById(int id);
        Task<UserCommand> FindByName(string lastName);
        Task<String> Create(UserDTO entity, IWebHostEnvironment webHostEnvironment);
        Task AddCollaborationToUser(int id, AddCollaborationToUserDTO collaborationDTO);
        Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO);
        public IEnumerable<CollaborationCommand> GetCollaboration(int userId);
        Task Update(UserCommand user);
        Task Delete(int id);
        Task DeleteByName(string userName);
    }
}
