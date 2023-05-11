using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

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
            var tamagochi = new Tamagochi
            {
                Hunger = 100,
                Play = 100,
                Score = 0,
                Sleep = 100,
                Look = "\"♡＼(❤˘⌣˘❤)／♡\"",
                PetId = 0
            };

            await context.Pet.AddAsync(pet);
            await context.SaveChangesAsync();
            var currentPet = await context.Pet.AsNoTracking().SingleAsync(b => b.Name == pet.Name); ;
            tamagochi.PetId = currentPet.Id;
            await context.Tamagochis.AddAsync(tamagochi);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Pet>> CurrentFarmPets(int farmId)
        {
            return await context.Pet.AsNoTracking().Where(c => c.FarmId == farmId).ToListAsync();
        }
        public async Task<IEnumerable<Tamagochi>> CurrentPetTamagochi(int petId)
        {
            return await context.Tamagochis.AsNoTracking().Where(c => c.PetId == petId).ToListAsync();
        }

        public async Task Delete(int id)
        {
            var farm = await FindById(id);
            var pets = await CurrentFarmPets(id);
            foreach (var pet in pets)
            {
              context.RemoveRange(await CurrentPetTamagochi(pet.Id));
              context.Remove(pet); 
            }

           
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
            return await context.Farm.SingleAsync(b => b.Id == id);
        }

        public async Task<Farm> FindByName(string name)
        {
            return await context.Farm.AsNoTracking().SingleAsync(a => a.Name == name);
        }
        public async Task<Farm> UpdateFarmProp(int id, Farm updatedFarm)
        {
            var curentFarm = await FindById(id);
            curentFarm.Name = updatedFarm.Name;
            await context.SaveChangesAsync();
            return curentFarm;
        }
        public async Task Update(Farm farm)
        {
            context.Update(farm);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Farm> CurrentUserFarms(string currentUserName)
        {


            var user = context.Registration.AsNoTracking().Single(a => a.UserName == currentUserName);
            var id = user.Id;
            return context.Farm.AsNoTracking().Where(c => c.UserId == id).OrderBy(a => a.Alive_pets_count).ToList();
            //return farms;
        }




    }
}
