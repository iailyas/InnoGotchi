
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class CharacteristicService : ICharacteristicService
    {
        private ICharacteristicRepository characteristicRepository;

        public CharacteristicService(ICharacteristicRepository characteristicRepository)
        {
            this.characteristicRepository = characteristicRepository;
        }

        public async Task Delete(int id)
        {
            await characteristicRepository.Delete(id);
        }
        public async Task<IEnumerable<Characteristic>> FindAll()
        {
           return await characteristicRepository.FindAll();
        }

        public async Task<Characteristic> FindById(int id)
        {
            return await characteristicRepository.FindById(id);
        }       

        public async Task Update(Characteristic characteristic)
        {
            await characteristicRepository.Update(characteristic);
        }
    }
}
