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
        public IQueryable<Characteristic> Get()
        {
            return characteristicService.FindAll();
        }
        [HttpGet("{id}")]
        public IQueryable<Characteristic> GetById(int id)
        {
            return characteristicService.FindByCondition(id);
        }
        [HttpPost]
        public void Post(Characteristic characteristic)
        {
            characteristicService.Create(characteristic);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            characteristicService.Delete(id);
        }
        [HttpPatch("{id}")]
        public void Patch(int id)
        {

            characteristicService.Update(id);
        }
    }
}
