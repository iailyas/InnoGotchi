
using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper.Commands;
using Microsoft.AspNetCore.Hosting;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class PetService : IPetService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IPetRepository petRepository;
        private IMapper mapper;

        public PetService(IWebHostEnvironment webHostEnvironment, IPetRepository petRepository, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            this.petRepository = petRepository;
            this.mapper = mapper;
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

        public async Task<IEnumerable<PetCommand>> FindAll()
        {
            var pets = await petRepository.FindAll();
            mapper.Map<IEnumerable<Pet>>(pets);
            return mapper.Map<IEnumerable<PetCommand>>(pets);
        }

        public async Task<PetCommand> FindById(int id)
        {
            var pet = await petRepository.FindById(id);
            return mapper.Map<PetCommand>(pet);
        }

        public async Task<PetCommand> FindByName(string petName)
        {
            var pet = await petRepository.FindByName(petName);

            return mapper.Map<PetCommand>(pet);
        }

        public async Task Update(PetCommand pet)
        {
            await petRepository.Update(mapper.Map<Pet>(pet));
        }
    }
}
