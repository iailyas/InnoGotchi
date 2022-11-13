using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicController : ControllerBase
    {
        ICharacteristicService characteristicService;
        public CharacteristicController(ICharacteristicService characteristicService)
        {
            this.characteristicService = characteristicService;
        }
        [HttpGet]
        public async Task<IEnumerable<Characteristic>> Get()
        {
            return await characteristicService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<Characteristic> GetById(int id)
        {
            return await characteristicService.FindById(id);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await characteristicService.Delete(id);
        }
        [HttpPatch("{id}")]
        public async Task Patch(Characteristic characteristic)
        {
            await characteristicService.Update(characteristic);
        }
    }
}
