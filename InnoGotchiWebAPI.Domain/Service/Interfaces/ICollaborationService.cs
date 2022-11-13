using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface ICollaborationService 
    {
        Task<IEnumerable<Collaboration>> FindAll();
        Task<Collaboration> FindById(int id);
        Task<Collaboration> FindByName(string collaborationName);
        Task Update(Collaboration collaboration);
        Task Delete(int id);
        Task DeleteByName(string collaborationName);
    }
}
