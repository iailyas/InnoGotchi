using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface ILookService 
    {
        Task<IEnumerable<LookCommand>> FindAll();
        Task<LookCommand> FindById(int id);
        //Task<Look> FindByName(string lookName);
        Task Update(LookCommand look);
        Task Delete(int id);
        //Task DeleteByName(string lookName);
    }
}
