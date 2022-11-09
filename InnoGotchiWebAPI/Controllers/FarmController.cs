using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        IFarmService farmService;

        public FarmController(IFarmService farmService)
        {
            this.farmService = farmService;
        }
        [HttpGet]
        public IQueryable<Farm> Get()
        {
            return farmService.FindAll();
        }
        [HttpGet("{id}")]
        public IQueryable<Farm> GetById(int id)
        {
            return farmService.FindByCondition(id);
        }
        [HttpPost]
        public void Post(Farm farm)
        {
            farmService.Create(farm);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            farmService.Delete(id);
        }
        [HttpPatch("{id}")]
        public void Patch(int id)
        {

            farmService.Update(id);
        }
    }
}
