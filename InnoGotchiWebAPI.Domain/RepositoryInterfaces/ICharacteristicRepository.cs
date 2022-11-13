using InnoGotchiWebAPI.Domain.Models;


namespace InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces
{
    public interface ICharacteristicRepository 
    {
        Task<IEnumerable<Characteristic>> FindAll();
        Task<Characteristic> FindById(int id);
        Task Update(Characteristic characteristic);
        Task Delete(int id);
    }
}
