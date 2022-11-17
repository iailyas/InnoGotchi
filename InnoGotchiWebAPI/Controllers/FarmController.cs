using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        IFarmService farmService;
        public FarmController(IFarmService farmService)
        {
            this.farmService = farmService;
        }
        [HttpGet]
        public async Task<IEnumerable<Farm>> Get()
        {
            return await farmService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<Farm> GetById(int id)
        {
            return await farmService.FindById(id);
        }
        //[HttpGet("{name}")]
        //public async Task<Farm> GetByName(string name)
        //{
        //    return await farmService.FindByName(name);
        //}
        [HttpPost("/AddPetToFarm")]
        public async Task AddPetToFarm(int id, AddPetToFarmDTO addPetToFarmDTO)
        {
            await farmService.AddPetToFarm(id, addPetToFarmDTO);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await farmService.Delete(id);
        }
        //[HttpDelete("{name}")]
        //public async Task Delete(string name)
        //{
        //    await farmService.DeleteByName(name);
        //}
        [HttpPatch("{id}")]
        public async Task Patch(Farm farm)
        {
            await farmService.Update(farm);
        }
        [HttpPut]
        public async Task<Farm> Update(int id,Farm farm)
        {
            return await farmService.UpdateFarmProp(id,farm);
        }
    }
}
