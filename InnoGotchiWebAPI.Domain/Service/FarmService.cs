using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class FarmService : IFarmService
    {
        IRepositoryWrapper repositoryWrapper;

        public FarmService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public void Create(Farm farm)
        {
           repositoryWrapper.FarmRepository.Create(farm);
        }

        public void Delete(int id)
        {
            Farm farm = (Farm)repositoryWrapper.FarmRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.FarmRepository.Delete(farm);
        }

        public IQueryable<Farm> FindAll()
        {
            return repositoryWrapper.FarmRepository.FindAll();
        }

        public IQueryable<Farm> FindByCondition(int id)
        {
            return repositoryWrapper.FarmRepository.FindByCondition(x => x.Id.Equals(id));
        }

        public void Update(int id)
        {
            Farm farm = (Farm)repositoryWrapper.FarmRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.FarmRepository.Update(farm);
        }
    }
}
