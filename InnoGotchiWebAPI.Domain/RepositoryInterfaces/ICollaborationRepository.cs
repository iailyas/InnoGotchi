using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;


namespace InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces
{
    public interface ICollaborationRepository
    {
        Task<IEnumerable<Collaboration>> FindAll();
        Task<Collaboration> FindById(int id);
        Task<Collaboration> FindByName(string collaborationName);
        Task Update(Collaboration collaboration);
        Task Delete(int id);
        Task DeleteByName(string collaborationName);
    }
}
