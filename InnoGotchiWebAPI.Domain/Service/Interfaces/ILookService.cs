using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface ILookService 
    {
        Task<IEnumerable<Look>> FindAll();
        Task<Look> FindById(int id);
        //Task<Look> FindByName(string lookName);
        Task Update(Look look);
        Task Delete(int id);
        Task<IEnumerable<Look>> GetLook(int lookId);
        //Task DeleteByName(string lookName);
    }
}
