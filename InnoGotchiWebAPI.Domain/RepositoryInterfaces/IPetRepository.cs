using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using Microsoft.AspNetCore.Hosting;

namespace InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces
{
    public interface IPetRepository 
    {
        Task<IEnumerable<Pet>> FindAll();
        Task<Pet> FindById(int id);
        Task<Pet> FindByName(string petName);
        Task AddLookToPet(int id, AddLookToPetDTO lookToPetDTO, IWebHostEnvironment webHostEnvironment);
        Task AddCharacteristicToPet(int id, AddCharacteristicToPetDTO addCharacteristicToPetDTO);
        Task Update(Pet pet);
        Task UpdateTamagochi(Tamagochi tamagochi);
        Task<Tamagochi> GetTamagochiById(int id);
        Task Delete(int id);
        Task DeleteByName(string userName);
        Task<IEnumerable<Pet>> CurrentFarmPets(int farmId);
        public int GetScore(int id);
        public Task UpdateFarmStats(int farmId);
        public Task SetScore(int id, int score);
    }
}
