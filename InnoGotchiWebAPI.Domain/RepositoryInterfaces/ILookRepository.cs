using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;


namespace InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces
{
    public interface ILookRepository 
    {
        Task<IEnumerable<Look>> FindAll();
        Task<Look> FindById(int id);
        //Task<Look> FindByName(string lookName);
        Task Update(Look look);
        Task Delete(int id);
        //Task DeleteByName(string lookName);
    }
}
