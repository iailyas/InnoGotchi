
using AutoMapper;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class CollaborationService : ICollaborationService
    {
        private ICollaborationRepository collaborationRepository;
        private IMapper mapper;

        public CollaborationService(ICollaborationRepository collaborationRepository, IMapper mapper)
        {
            this.collaborationRepository = collaborationRepository;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await collaborationRepository.Delete(id);
        }

        public async Task DeleteByName(string collaborationName)
        {
            await collaborationRepository.DeleteByName(collaborationName);
        }

        public async Task<IEnumerable<CollaborationCommand>> FindAll()
        {
            var Collaborations = await collaborationRepository.FindAll();

            return mapper.Map<IEnumerable<CollaborationCommand>>(Collaborations);
        }

        public async Task<CollaborationCommand> FindById(int id)
        {
            var collaboration = await collaborationRepository.FindById(id);

            return mapper.Map<CollaborationCommand>(collaboration);
        }

        public async Task<CollaborationCommand> FindByName(string collaborationName)
        {
            var collaboration = await collaborationRepository.FindByName(collaborationName);

            return mapper.Map<CollaborationCommand>(collaboration);

        }

        public async Task Update(CollaborationCommand collaboration)
        {
            await collaborationRepository.Update(mapper.Map<Collaboration>(collaboration));
        }
    }
}
