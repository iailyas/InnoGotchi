using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;


namespace InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces
{
    public interface IFarmRepository 
    {
        Task<IEnumerable<Farm>> FindAll();
        Task<Farm> FindById(int id);
        Task<Farm> FindByName(string lastName);
        Task AddPetToFarm(int id, AddPetToFarmDTO addPetToFarmDTO);
        Task Update(Farm farm);
        Task Delete(int id);
        Task DeleteByName(string farmName);
        Task<Farm> UpdateFarmProp(int id, Farm updatedFarm);
    }
}
