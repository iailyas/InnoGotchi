﻿using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Mapper.Commands;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacteristicController : ControllerBase
    {
        ICharacteristicService characteristicService;
        public CharacteristicController(ICharacteristicService characteristicService)
        {
            this.characteristicService = characteristicService;
        }
        [HttpGet]
        public async Task<IEnumerable<CharacteristicCommand>> Get()
        {
            return await characteristicService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<CharacteristicCommand> GetById(int id)
        {
            return await characteristicService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await characteristicService.Delete(id);
        }
        [HttpPatch("{id}")]
        public async Task Patch(CharacteristicCommand characteristic)
        {
            await characteristicService.Update(characteristic);
        }
    }
}
