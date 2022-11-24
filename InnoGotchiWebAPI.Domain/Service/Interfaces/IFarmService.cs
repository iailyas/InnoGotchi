using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface IFarmService 
    {
        Task<IEnumerable<FarmCommand>> FindAll();
        Task<FarmCommand> FindById(int id);
        Task<FarmCommand> FindByName(string lastName);
        Task AddPetToFarm(int id, AddPetToFarmDTO addPetToFarmDTO);
        Task Update(FarmCommand farm);
        Task Delete(int id);
        Task DeleteByName(string farmName);
        Task<FarmCommand> UpdateFarmProp(int id, FarmCommand updatedFarm);
    }
}
