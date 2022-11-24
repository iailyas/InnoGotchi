
using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class FarmService : IFarmService
    {
        private IFarmRepository farmRepository;
        private IMapper mapper;

        public FarmService(IFarmRepository farmRepository, IMapper mapper)
        {
            this.farmRepository = farmRepository;
            this.mapper = mapper;
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

        public async Task<IEnumerable<FarmCommand>> FindAll()
        {
            var Farms = await farmRepository.FindAll();

            return mapper.Map<IEnumerable<FarmCommand>>(Farms);
        }

        public async Task<FarmCommand> FindById(int id)
        {
            var farm = await farmRepository.FindById(id);

            return mapper.Map<FarmCommand>(farm);
        }

        public async Task<FarmCommand> FindByName(string lastName)
        {
            var farm = await farmRepository.FindByName(lastName);
            return mapper.Map<FarmCommand>(lastName);
        }

        public async Task Update(FarmCommand farm)
        {
            await farmRepository.Update(mapper.Map<Farm>(farm));
        }

        public async Task<FarmCommand> UpdateFarmProp(int id, FarmCommand updatedFarm)
        {
            var farm = mapper.Map<Farm>(updatedFarm);


            return mapper.Map<FarmCommand>(await farmRepository.UpdateFarmProp(id, farm));

        }
    }
}
