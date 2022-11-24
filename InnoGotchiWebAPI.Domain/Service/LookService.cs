
using AutoMapper;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Domain.Service
{
    public class LookService : ILookService
    {
        private ILookRepository lookRepository;
        private IMapper mapper;

        public LookService(ILookRepository lookRepository, IMapper mapper)
        {
            this.lookRepository = lookRepository;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await lookRepository.Delete(id);
        }

        //public async Task DeleteByName(string lookName)
        //{
        //    await lookRepository.DeleteByName(lookName);
        //}

        public async Task<IEnumerable<LookCommand>> FindAll()
        {
            var users = await lookRepository.FindAll();
            return mapper.Map<IEnumerable<LookCommand>>(users);
        }

        public async Task<LookCommand> FindById(int id)
        {
            var look = await lookRepository.FindById(id);
            return mapper.Map<LookCommand>(look);
        }

        //public async Task<Look> FindByName(string lookName)
        //{
        //   return await lookRepository.FindByName(lookName);
        //}

        public async Task Update(LookCommand look)
        {

            await lookRepository.Update(mapper.Map<Look>(look));
        }
    }
}
