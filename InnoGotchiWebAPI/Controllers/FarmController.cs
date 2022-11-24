using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Mapper.Commands;
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
        public async Task<IEnumerable<FarmCommand>> Get()
        {
            return await farmService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<FarmCommand> GetById(int id)
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
        public async Task Patch(FarmCommand farm)
        {
            await farmService.Update(farm);
        }
        [HttpPut]
        public async Task<FarmCommand> Update(int id, FarmCommand farm)
        {
            return await farmService.UpdateFarmProp(id, farm);
        }
    }
}
