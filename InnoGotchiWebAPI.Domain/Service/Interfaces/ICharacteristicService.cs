using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface ICharacteristicService
    {
        Task<IEnumerable<CharacteristicCommand>> FindAll();
        Task<CharacteristicCommand> FindById(int id);
        Task Update(CharacteristicCommand characteristic);
        Task Delete(int id);
    }
}
