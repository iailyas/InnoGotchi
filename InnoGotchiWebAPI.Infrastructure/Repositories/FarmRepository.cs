using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class FarmRepository : IFarmRepository
    {
        private MainDbContext context;

        public FarmRepository(MainDbContext context)
        {
            this.context = context;
        }

        public async Task AddPetToFarm(int id, AddPetToFarmDTO addPetToFarmDTO)
        {
            var farm = await FindById(id);
            if (farm == null)
            {
                throw new Exception("Incorrect Pet");
            }
            var pet = new Pet
            {
                Name = addPetToFarmDTO.Name,
                Type = addPetToFarmDTO.Type,
                Happiness_days_count = addPetToFarmDTO.Happiness_days_count,
                Feeding_period = addPetToFarmDTO.Feeding_period,
                Thist_quenching = addPetToFarmDTO.Thist_quenching,
                FarmId = id
            };
            await context.Pet.AddAsync(pet);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var farm = FindById(id);
            context.Remove(farm);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByName(string farmName)
        {
            var farm = FindByName(farmName);
            context.Remove(farm);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Farm>> FindAll()
        {
            return await context.Farm.AsNoTracking().ToListAsync();
        }

        public async Task<Farm> FindById(int id)
        {
            return await context.Farm.AsNoTracking().SingleAsync(b => b.Id == id);
        }

        public async Task<Farm> FindByName(string name)
        {
            return await context.Farm.AsNoTracking().SingleAsync(a => a.Name == name);
        }

        public async Task Update(Farm farm)
        {
            context.Update(farm);
            await context.SaveChangesAsync();
        }
    }
}
