
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class PetService : IPetService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IPetRepository petRepository;

        public PetService(IWebHostEnvironment webHostEnvironment, IPetRepository petRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            this.petRepository = petRepository;
        }

        public async Task AddCharacteristicToPet(int id, AddCharacteristicToPetDTO addCharacteristicToPetDTO)
        {
           await petRepository.AddCharacteristicToPet(id, addCharacteristicToPetDTO);
        }

        public async Task AddLookToPet(int id, AddLookToPetDTO lookToPetDTO, IWebHostEnvironment webHostEnvironment)
        {
            await petRepository.AddLookToPet(id, lookToPetDTO, webHostEnvironment);
        }

        public async Task Delete(int id)
        {
            await petRepository.Delete(id);
        }

        public async Task DeleteByName(string userName)
        {
            await petRepository.DeleteByName(userName);
        }

        public async Task<IEnumerable<Pet>> FindAll()
        {
            return await petRepository.FindAll();
        }

        public async Task<Pet> FindById(int id)
        {
            return await petRepository.FindById(id);
        }

        public async Task<Pet> FindByName(string petName)
        {
            return await petRepository.FindByName(petName);
        }

        public async Task Update(Pet pet)
        {
            await petRepository.Update(pet);
        }
    }
}
