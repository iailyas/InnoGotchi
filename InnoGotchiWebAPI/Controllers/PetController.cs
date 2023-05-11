using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("[controller]")/*,Authorize*/]
    [ApiController]
    //[Authorize]
    public class PetController : ControllerBase
    {
        private IPetService petService;
        IWebHostEnvironment env;

        public PetController(IPetService petService, IWebHostEnvironment env)
        {
            this.petService = petService;
            this.env = env;
        }

        [HttpGet]
        public async Task<IEnumerable<Pet>> Get()
        {
            return await petService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<Pet> GetById(int id)
        {
            return await petService.FindById(id);
        }
        [HttpPatch("/FarmStatsUpdate")]
        public async Task Patch(int  farmID)
        {
            await petService.UpdateFarmStats(farmID);
        }
        [HttpGet("/PetByFarmId")]
        public async Task<IEnumerable<Pet>> GetPetsByFarm(int FarmId)
        {
            return await petService.CurrentFarmPets(FarmId);
        }
        //[HttpGet("{name}")]
        //public async Task<Pet> GetByName(string name)
        //{
        //    return await petService.FindByName(name);
        //}
        [HttpPost("/AddLookToPet")]
        public async Task AddLookToPet(int id,[FromForm]AddLookToPetDTO look)
        {
            await petService.AddLookToPet(id,look,env);
        }
        [HttpPost("/AddCharacteristicToPet")]
        public async Task AddCharacteristicToPet(int id, AddCharacteristicToPetDTO addCharacteristicToPetDTO)
        {
            await petService.AddCharacteristicToPet(id, addCharacteristicToPetDTO);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await petService.Delete(id);
        }
        //[HttpDelete("{name}")]
        //public async Task Delete(string name)
        //{
        //    await petService.DeleteByName(name);
        //}
        [HttpPatch("{id}")]
        public async Task  Patch(Pet pet)
        {
            await petService.Update(pet);
        }
        [HttpGet("Tamagochi/{id}")]
        public async Task<Tamagochi> GetTamagochiById(int id)
        {
           return await petService.GetTamagochiById(id);
        }
        [HttpGet("GetPetScore/{id}")]
        public int GetScoreByPetId(int id)
        {
            return petService.GetScore(id);
        }
        [HttpPatch("SetPetScore/{id}")]
        public async Task SetScoreByPetId(int id,int score)
        {
            await petService.SetScore(id,score);
        }
        [HttpPatch("Tamagochi/{id}")]
        public async Task PatchTamagochi(Tamagochi tamagochi)
        {
            await petService.UpdateTamagochi(tamagochi);
        }
    }
}
