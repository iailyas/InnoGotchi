using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class PetService : IPetService
    {
        private IRepositoryWrapper repositoryWrapper;

        public PetService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public void Create(Pet entity)
        {
            repositoryWrapper.PetRepository.Create(entity);
        }

        public void Delete(int id)
        {
            Pet pet = (Pet)repositoryWrapper.PetRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.PetRepository.Delete(pet);
        }

        public IQueryable<Pet> FindAll()
        {
            return repositoryWrapper.PetRepository.FindAll();
        }

        public IQueryable<Pet> FindByCondition(int id)
        {
            return repositoryWrapper.PetRepository.FindByCondition(x => x.Id.Equals(id));
        }

        public void Update(int id)
        {
            Pet pet = (Pet)repositoryWrapper.PetRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.PetRepository.Update(pet);
        }
    }
}
