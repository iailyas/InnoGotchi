using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface ICollaborationService 
    {
        Task<IEnumerable<CollaborationCommand>> FindAll();
        Task<CollaborationCommand> FindById(int id);
        Task<CollaborationCommand> FindByName(string collaborationName);
        Task Update(CollaborationCommand collaboration);
        Task Delete(int id);
        Task DeleteByName(string collaborationName);
    }
}
