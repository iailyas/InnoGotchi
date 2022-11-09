using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class LookService : ILookService
    {
        IRepositoryWrapper repositoryWrapper;

        public LookService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public void Create(Look entity)
        {
            repositoryWrapper.LookRepository.Create(entity);
        }

        public void Delete(int id)
        {
            Look look = (Look)repositoryWrapper.LookRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.LookRepository.Delete(look);
        }

        public IQueryable<Look> FindAll()
        {
            return repositoryWrapper.LookRepository.FindAll();
        }

        public IQueryable<Look> FindByCondition(int id)
        {
            return repositoryWrapper.LookRepository.FindByCondition(x => x.Id.Equals(id));
        }

        public void Update(int id)
        {
            Look look = (Look)repositoryWrapper.LookRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.LookRepository.Update(look);
        }
    }
}
