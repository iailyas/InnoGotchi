
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class CollaborationService : ICollaborationService
    {
        private ICollaborationRepository collaborationRepository;

        public CollaborationService(ICollaborationRepository collaborationRepository)
        {
            this.collaborationRepository = collaborationRepository;
        }

        public async Task Delete(int id)
        {
            await collaborationRepository.Delete(id);
        }

        public async Task DeleteByName(string collaborationName)
        {
            await collaborationRepository.DeleteByName(collaborationName);
        }

        public async Task<IEnumerable<Collaboration>> FindAll()
        {
            return await collaborationRepository.FindAll();
        }

        public async Task<Collaboration> FindById(int id)
        {
            return await collaborationRepository.FindById(id);
        }

        public async Task<Collaboration> FindByName(string collaborationName)
        {
            return await collaborationRepository.FindByName(collaborationName);
        }

        public async Task Update(Collaboration collaboration)
        {
            await collaborationRepository.Update(collaboration);
        }
    }
}
