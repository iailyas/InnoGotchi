
using AutoMapper;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class CharacteristicService : ICharacteristicService
    {
        private ICharacteristicRepository characteristicRepository;
        private IMapper mapper;

        public CharacteristicService(ICharacteristicRepository characteristicRepository, IMapper mapper)
        {
            this.characteristicRepository = characteristicRepository;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await characteristicRepository.Delete(id);
        }
        public async Task<IEnumerable<CharacteristicCommand>> FindAll()
        {
            var characteristics = await characteristicRepository.FindAll();

            return mapper.Map<IEnumerable<CharacteristicCommand>>(characteristics);
        }

        public async Task<CharacteristicCommand> FindById(int id)
        {
            var characteristic = await characteristicRepository.FindById(id);
            return mapper.Map<CharacteristicCommand>(characteristic);
        }

        public async Task Update(CharacteristicCommand characteristic)
        {
            await characteristicRepository.Update(mapper.Map<Characteristic>(characteristic));
        }
    }
}
