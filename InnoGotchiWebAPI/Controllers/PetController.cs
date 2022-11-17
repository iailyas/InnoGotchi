using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
    }
}
