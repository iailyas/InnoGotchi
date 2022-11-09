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
        public IQueryable<Look> Get()
        {
            return lookService.FindAll();
        }
        [HttpGet("{id}")]
        public IQueryable<Look> GetById(int id)
        {
            return lookService.FindByCondition(id);
        }
        [HttpPost]
        public void Post(Look look)
        {
            lookService.Create(look);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            lookService.Delete(id);
        }
        [HttpPatch("{id}")]
        public void Patch(int id)
        {

            lookService.Update(id);
        }
    }
}
