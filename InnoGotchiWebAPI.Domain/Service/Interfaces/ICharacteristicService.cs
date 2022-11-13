using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface ICharacteristicService
    {
        Task<IEnumerable<Characteristic>> FindAll();
        Task<Characteristic> FindById(int id);
        Task Update(Characteristic characteristic);
        Task Delete(int id);
    }
}
