using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetService petService;

        public PetController(IPetService petService)
        {
            this.petService = petService;
        }

        [HttpGet]
        public IQueryable<Pet> Get()
        {
            return petService.FindAll();
        }
        [HttpGet("{id}")]
        public IQueryable<Pet> GetById(int id)
        {
            return petService.FindByCondition(id);
        }
        [HttpPost]
        public void Post(Pet pet)
        {
            petService.Create(pet);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            petService.Delete(id);
        }
        [HttpPatch("{id}")]
        public void Patch(int id)
        {

            petService.Update(id);
        }
    }
}
