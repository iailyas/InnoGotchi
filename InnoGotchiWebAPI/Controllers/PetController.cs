using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Mapper.Commands;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<PetCommand>> Get()
        {
            return await petService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<PetCommand> GetById(int id)
        {
            return await petService.FindById(id);
        }
        //[HttpGet("{name}")]
        //public async Task<Pet> GetByName(string name)
        //{
        //    return await petService.FindByName(name);
        //}
        [HttpPost("/AddLookToPet")]
        public async Task AddLookToPet(int id, [FromForm] AddLookToPetDTO look)
        {
            await petService.AddLookToPet(id, look, env);
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
        public async Task Patch(PetCommand pet)
        {
            await petService.Update(pet);
        }
    }
}
