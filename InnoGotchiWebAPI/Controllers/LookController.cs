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
    public class LookController : ControllerBase
    {
        ILookService lookService;
        public LookController(ILookService lookService)
        {
            this.lookService = lookService;
        }
        [HttpGet]
        public async Task<IEnumerable<Look>> Get()
        {
            return await lookService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<Look> GetById(int id)
        {
            return await lookService.FindById(id);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await lookService.Delete(id);
        }
        [HttpPatch("{id}")]
        public async Task Patch([FromForm] Look look)
        {
            await lookService.Update(look);
        }
    }
}
