using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Mapper.Commands;
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
        public async Task<IEnumerable<CollaborationCommand>> Get()
        {
            return await collaborationService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<CollaborationCommand> GetById(int id)
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
        public async Task Patch(CollaborationCommand collaboration)
        {
            await collaborationService.Update(collaboration);
        }
    }
}
