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
        Task Delete(int id);
        Task DeleteByName(string userName);
    }
}
