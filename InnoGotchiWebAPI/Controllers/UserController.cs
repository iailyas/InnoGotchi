using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Mapper.Commands;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IWebHostEnvironment webHostEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            this.userService = userService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<UserCommand>> Get()
        {
            return await userService.FindAll();
        }
        [HttpGet("{id}")]
        public async Task<UserCommand> GetById(int id)
        {
            return await userService.FindById(id);
        }
        //[HttpGet("{name}")]
        //public async Task<User> GetByName(string name)
        //{
        //    return await userService.FindByName(name);
        //}
        [HttpPost(Name = "Post")]
        public async Task Post([FromForm] UserDTO user)
        {
            await userService.Create(user, webHostEnvironment);
        }
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
        [HttpPatch("{id}")]
        public async Task Patch(UserCommand user)
        {

            await userService.Update(user);
        }


        [HttpPost("/AddCollaborationToUser")]
        public async Task AddCollabprationToUser(int id, AddCollaborationToUserDTO collaborationDTO)
        {
            await userService.AddCollaborationToUser(id, collaborationDTO);
        }
        [HttpPost("/AddFarmToUser")]
        public async Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO)
        {
            await userService.AddFarmToUser(id, addFarmToUserDTO);
        }


    }
}