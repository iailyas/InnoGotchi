using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces
{
    public interface IUserRepository 
    {
        Task<IEnumerable<User>> FindAll();
        Task<User> FindById(int id);
        Task<User> FindByName(string lastName);
        Task<String> Create(UserDTO entity, IWebHostEnvironment webHostEnvironment);
        Task AddCollaborationToUser(int id,AddCollaborationToUserDTO collaborationDTO);
        Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO);
        Task Update(User user);
        Task Delete(int id);
        Task DeleteByName(string userName);
    }
}
