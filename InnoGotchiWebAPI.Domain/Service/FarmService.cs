
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class FarmService : IFarmService
    {
        private IFarmRepository farmRepository;

        public FarmService(IFarmRepository farmRepository)
        {
            this.farmRepository = farmRepository;
        }

        public async Task AddPetToFarm(int id, AddPetToFarmDTO addPetToFarmDTO)
        {
            await farmRepository.AddPetToFarm(id, addPetToFarmDTO);
        }

        public async Task Delete(int id)
        {
            await farmRepository.Delete(id);
        }

        public async Task DeleteByName(string farmName)
        {
            await farmRepository.DeleteByName(farmName);
        }

        public async Task<IEnumerable<Farm>> FindAll()
        {
            return await farmRepository.FindAll();
        }

        public async Task<Farm> FindById(int id)
        {
            return await farmRepository.FindById(id);
        }

        public async Task<Farm> FindByName(string lastName)
        {
            return await farmRepository.FindByName(lastName);
        }

        public async Task Update(Farm farm)
        {
            await farmRepository.Update(farm);
        }

        public async Task<Farm> UpdateFarmProp(int id, Farm updatedFarm)
        {
            return await farmRepository.UpdateFarmProp(id, updatedFarm);
            
        }
    }
}
