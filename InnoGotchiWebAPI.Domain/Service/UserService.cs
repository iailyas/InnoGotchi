using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public void Create(UserDTO user)
        {
            repositoryWrapper.UserRepository.Create(user);
        }

        public void Create(User entity)
        {
            repositoryWrapper.UserRepository.Create(entity);
        }

        public void Delete(int id)
        {
            User user = (User)repositoryWrapper.UserRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.UserRepository.Delete(user);
        }

        public IQueryable<User> FindAll()
        {
            return repositoryWrapper.UserRepository.FindAll();
        }

        public IQueryable<User> FindByCondition(int id)
        {
            return repositoryWrapper.UserRepository.FindByCondition(x => x.Id.Equals(id));
        }

        public void Update(int id)
        {
            User user = (User)repositoryWrapper.UserRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.UserRepository.Update(user);
        }
    }
}
