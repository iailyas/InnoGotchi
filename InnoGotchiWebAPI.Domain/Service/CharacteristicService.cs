using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class CharacteristicService : ICharacteristicService
    {
        IRepositoryWrapper repositoryWrapper;

        public CharacteristicService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public void Create(Characteristic entity)
        {
            repositoryWrapper.CharacteristicRepository.Create(entity);
        }

        public void Delete(int id)
        {
            Characteristic characteristic = (Characteristic)repositoryWrapper.CharacteristicRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.CharacteristicRepository.Delete(characteristic);
        }

        public IQueryable<Characteristic> FindAll()
        {
            return repositoryWrapper.CharacteristicRepository.FindAll();
        }

        public IQueryable<Characteristic> FindByCondition(int id)
        {
            return repositoryWrapper.CharacteristicRepository.FindByCondition(x => x.Id.Equals(id));
        }

        public void Update(int id)
        {
            Characteristic characteristic = (Characteristic)repositoryWrapper.CharacteristicRepository.FindByCondition(x => x.Id.Equals(id));
            repositoryWrapper.CharacteristicRepository.Update(characteristic);
        }
    }
}
