
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class LookService : ILookService
    {
        ILookRepository lookRepository;

        public LookService(ILookRepository lookRepository)
        {
            this.lookRepository = lookRepository;
        }

        public async Task Delete(int id)
        {
            await lookRepository.Delete(id);
        }

        //public async Task DeleteByName(string lookName)
        //{
        //    await lookRepository.DeleteByName(lookName);
        //}

        public async Task<IEnumerable<Look>> FindAll()
        {
            return await lookRepository.FindAll();
        }

        public async Task<Look> FindById(int id)
        {
            return await lookRepository.FindById(id);
        }

        public async Task<IEnumerable<Look>> GetLook(int lookId)
        {
            return await lookRepository.GetLook(lookId);
        }

        //public async Task<Look> FindByName(string lookName)
        //{
        //   return await lookRepository.FindByName(lookName);
        //}

        public async Task Update(Look look)
        {
            await lookRepository.Update(look);
        }
    }
}
