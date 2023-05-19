

using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private MainDbContext context;


        public PetRepository(MainDbContext context)
        {
            this.context = context;
        }

        public async Task AddCharacteristicToPet(int id, AddCharacteristicToPetDTO addCharacteristicToPetDTO)
        {
            var pet = await FindById(id);
            if (pet == null)
            {
                throw new Exception("Incorrect Pet");
            }
            var characteristic = new Characteristic
            {
                Age = addCharacteristicToPetDTO.Age,
                Hunger_level = addCharacteristicToPetDTO.Hunger_level,
                Thisty_level = addCharacteristicToPetDTO.Thisty_level,
                PetId = id
            };
            await context.Characteristic.AddAsync(characteristic);
            await context.SaveChangesAsync();
        }

        public async Task AddLookToPet(int id, AddLookToPetDTO lookToPetDTO, IWebHostEnvironment webHostEnvironment)
        {
            var pet = await FindById(id);
            if (pet == null)
            {
                throw new Exception("Incorrect Pet");
            }
            var look = new Look
            {
                Body = lookToPetDTO.Body.FileName,
                Eye = lookToPetDTO.Eye.FileName,
                Nose = lookToPetDTO.Nose.FileName,
                Mouth = lookToPetDTO.Mouth.FileName,
                PetId = id
            };
            try
            {
                string path = webHostEnvironment.ContentRootPath + "\\Uploads\\";

                using (FileStream fs = System.IO.File.Create(path + lookToPetDTO.Body.FileName))
                {
                    await lookToPetDTO.Body.CopyToAsync(fs);
                    fs.Flush();
                }
                using (FileStream fs = System.IO.File.Create(path + lookToPetDTO.Eye.FileName))
                {
                    await lookToPetDTO.Eye.CopyToAsync(fs);
                    fs.Flush();
                }
                using (FileStream fs = System.IO.File.Create(path + lookToPetDTO.Nose.FileName))
                {
                    await lookToPetDTO.Nose.CopyToAsync(fs);
                    fs.Flush();
                }
                using (FileStream fs = System.IO.File.Create(path + lookToPetDTO.Mouth.FileName))
                {
                    await lookToPetDTO.Mouth.CopyToAsync(fs);
                    fs.Flush();
                }
                await context.AddAsync(look);
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }



        public async Task Delete(int id)
        {
            var pet = await FindById(id);
            var tamagochis = await context.Tamagochis.AsNoTracking().Where(c => c.PetId == id).ToListAsync();
            context.RemoveRange(tamagochis);
            //foreach (var tamagoch in tamagochis)
            //{
            //    context.Remove(tamagoch);
            //}
            context.Remove(pet);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByName(string petName)
        {
            var pet = FindByName(petName);
            context.Remove(pet);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> FindAll()
        {
            return await context.Pet.AsNoTracking().ToListAsync();
        }

        public async Task<Pet> FindById(int id)
        {
            return await context.Pet.AsNoTracking().SingleAsync(b => b.Id == id);
        }

        public async Task<Pet> FindByName(string petName)
        {
            return await context.Pet.AsNoTracking().SingleAsync(b => b.Name == petName);
        }

        public async Task UpdateTamagochi(Tamagochi tamagochi)
        {
            context.Update(tamagochi);
            await context.SaveChangesAsync();
        }
        public async Task Update(Pet pet)
        {
            context.Update(pet);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Pet>> CurrentFarmPets(int farmId)
        {
            return await context.Pet.AsNoTracking().Where(c => c.FarmId == farmId).ToListAsync();
        }
        public async Task UpdateFarmStats(int farmId)
        {
            var pets = await context.Pet.AsNoTracking().Where(c => c.FarmId == farmId).ToListAsync();
            var alive = 0;
            var dead = 0;
            var counter = 0;
            foreach (var pet in pets)
            {
                if (pet.Happiness_days_count != 0)
                    dead += 1;
                else
                    alive += 1;
                counter += pet.Happiness_days_count;
            }
            var farm = await context.Farm.AsNoTracking().SingleAsync(c => c.Id == farmId);
            farm.Alive_pets_count = alive;
            farm.Dead_pets_count = dead;
            if (dead != 0)
                farm.Average_pets_age = counter / dead;
            context.Farm.Update(farm);
            await context.SaveChangesAsync();

        }

        public async Task<Tamagochi> GetTamagochiById(int id)
        {
            return await context.Tamagochis.AsNoTracking().SingleAsync(b => b.PetId == id);
        }

        public int GetScore(int id)
        {
            return FindById(id).Result.Happiness_days_count;
        }

        public async Task SetScore(int id, int score)
        {
            var currentPet = await FindById(id);
            currentPet.Happiness_days_count = score;
            context.Pet.Update(currentPet);
            await context.SaveChangesAsync();
        }
    }
}
