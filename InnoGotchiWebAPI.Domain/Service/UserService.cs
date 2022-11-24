using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper.Commands;
using Microsoft.AspNetCore.Hosting;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class UserService : IUserService
    {
        private IUserRepository repository;
        private IMapper mapper;


        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddCollaborationToUser(int id, AddCollaborationToUserDTO collaborationDTO)
        {
            await repository.AddCollaborationToUser(id, collaborationDTO);
        }

        public async Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO)
        {
            await repository.AddFarmToUser(id, addFarmToUserDTO);
        }

        public IEnumerable<CollaborationCommand> GetCollaboration(int userId)
        {
            var collaborations = repository.GetCollaboration(userId);
            return mapper.Map<IEnumerable<CollaborationCommand>>(collaborations);
        }

        public async Task<string> Create(UserDTO entity, IWebHostEnvironment webHostEnvironment)
        {
            return await repository.Create(entity, webHostEnvironment);
        }

        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }

        public async Task DeleteByName(string userName)
        {
            await repository.DeleteByName(userName);
        }

        public async Task<IEnumerable<UserCommand>> FindAll()
        {
            var users = await repository.FindAll();
            return mapper.Map<IEnumerable<UserCommand>>(users);
        }

        public async Task<UserCommand> FindById(int id)
        {
            var user = await repository.FindById(id);
            return mapper.Map<UserCommand>(user);
        }

        public async Task<UserCommand> FindByName(string lastName)
        {
            var user = await repository.FindByName(lastName);
            return mapper.Map<UserCommand>(user);
        }

        public async Task Update(UserCommand user)
        {
            await repository.Update(mapper.Map<User>(user));
        }
    }
}
