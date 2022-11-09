using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchiWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet(Name = "Get")]
        public IQueryable<User> Get()
        {
            return userService.FindAll();
        }
        [HttpGet("{id}")]
        public IQueryable<User> GetById(int id)
        {
            return userService.FindByCondition(id);
        }
        [HttpPost(Name = "Post")]
        public void Post(User user)
        {
            userService.Create(user);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userService.Delete(id);
        }
        [HttpPatch("{id}")]
        public void Patch(int id)
        {

            userService.Update(id);
        }
    }
}