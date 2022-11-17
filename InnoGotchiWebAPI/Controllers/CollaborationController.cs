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
    public class CollaborationController : ControllerBase
    {
        ICollaborationService collaborationService;

        public CollaborationController(ICollaborationService collaborationService)
        {
            this.collaborationService = collaborationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Collaboration>> Get()
        {
            return await collaborationService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<Collaboration> GetById(int id)
        {
            return await collaborationService.FindById(id);
        }
        //[HttpGet("{name}")]
        //public async Task<Collaboration> GetByName(string name)
        //{
        //    return await collaborationService.FindByName(name);
        //}
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await collaborationService.Delete(id);
        }
        //[HttpDelete("{name}")]
        //public async Task Delete(string name)
        //{
        //    await collaborationService.DeleteByName(name);
        //}
        [HttpPatch("{id}")]
        public async Task Patch(Collaboration collaboration)
        {
            await collaborationService.Update(collaboration);
        }
    }
}
