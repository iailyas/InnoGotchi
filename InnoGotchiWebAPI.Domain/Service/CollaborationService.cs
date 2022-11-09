using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class CollaborationService : ICollaborationService
    {
        IRepositoryWrapper repositoryWrapper;

        public CollaborationService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Collaboration> FindAll()
        {
            return repositoryWrapper.CollaborationRepository.FindAll();
        }

        public IQueryable<Collaboration> FindByCondition(int id)
        {
            return repositoryWrapper.CollaborationRepository.FindByCondition(x => x.Id.Equals(id));
        }

        public void Create(Collaboration entity)
        {
            repositoryWrapper.CollaborationRepository.Create(entity);
        }

        public void Update(int id)
        {
            Collaboration collaboration = (Collaboration)repositoryWrapper.CollaborationRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.CollaborationRepository.Update(collaboration);
        }

        public void Delete(int id)
        {
            Collaboration collaboration = (Collaboration)repositoryWrapper.CollaborationRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.CollaborationRepository.Delete(collaboration);
        }


    }
}
