using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Authorize]

    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IWebHostEnvironment webHostEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            this.userService = userService;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Authorize]
        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<User>> Get()
        {
            return await userService.FindAll();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<User> GetById(int id)
        {
            return await userService.FindById(id);
        }
        [HttpGet("/current/{name}")]
        [Authorize]
        public async Task<User> GetByName(string name)
        {
            return await userService.FindByName(name);
        }

        [HttpPost(Name = "Post")]
        public async Task Post([FromForm] UserDTO user)
        {
            await userService.Create(user, webHostEnvironment);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await userService.Delete(id);
        }
        //[HttpDelete("{name}")]
        //public async Task Delete(string name)
        //{
        //    await userService.DeleteByName(name);
        //}
        [Authorize]
        [HttpPatch("{id}")]
        public async Task Patch(User user)
        {

            await userService.Update(user);
        }

        [Authorize]
        [HttpPost("/AddCollaborationToUser")]
        public async Task AddCollabprationToUser(int id, AddCollaborationToUserDTO collaborationDTO)
        {
            await userService.AddCollaborationToUser(id, collaborationDTO);
        }
        [Authorize]
        [HttpPost("/AddFarmToUser")]
        public async Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO)
        {
            await userService.AddFarmToUser(id, addFarmToUserDTO);
        }
       
       
    }
}