using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Mapper.Commands;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LookController : ControllerBase
    {
        ILookService lookService;
        public LookController(ILookService lookService)
        {
            this.lookService = lookService;
        }
        [HttpGet]
        public async Task<IEnumerable<LookCommand>> Get()
        {
            return await lookService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<LookCommand> GetById(int id)
        {
            return await lookService.FindById(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await lookService.Delete(id);
        }
        [HttpPatch("{id}")]
        public async Task Patch([FromForm] LookCommand look)
        {
            await lookService.Update(look);
        }
    }
}
