using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaborationController : ControllerBase
    {
        ICollaborationService collaborationService;

        public CollaborationController(ICollaborationService collaborationService)
        {
            this.collaborationService = collaborationService;
        }
        [HttpGet]
        public IQueryable<Collaboration> Get()
        {
            return collaborationService.FindAll();
        }
        [HttpGet("{id}")]
        public IQueryable<Collaboration> GetById(int id)
        {
            return collaborationService.FindByCondition(id);
        }
        [HttpPost]
        public void Post(Collaboration collaboration)
        {
            collaborationService.Create(collaboration);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            collaborationService.Delete(id);
        }
        [HttpPatch("{id}")]
        public void Patch(int id)
        {

            collaborationService.Update(id);
        }
    }
}
