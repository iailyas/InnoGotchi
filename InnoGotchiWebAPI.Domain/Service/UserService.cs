using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class UserService : IUserService
    {
        private IUserRepository repository;


        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddCollaborationToUser(int id, AddCollaborationToUserDTO collaborationDTO)
        {
            await repository.AddCollaborationToUser(id,collaborationDTO);
        }

        public async Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO)
        {
            await repository.AddFarmToUser(id,addFarmToUserDTO);
        }

        public async Task<string> Create(UserDTO entity, IWebHostEnvironment webHostEnvironment)
        {
            return await repository.Create(entity,webHostEnvironment);
        }

        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }

        public async  Task DeleteByName(string userName)
        {
            await repository.DeleteByName(userName);
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            return await repository.FindAll();
        }

        public async Task<User> FindById(int id)
        {
            return await repository.FindById(id);
        }

        public async Task<User> FindByName(string lastName)
        {
            return await repository.FindByName(lastName);
        }

        public async Task Update(User user)
        {
            await repository.Update(user);
        }
    }
}
