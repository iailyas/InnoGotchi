using Microsoft.AspNetCore.Http;

namespace InnoGotchiWebAPI.Domain.DTO
{
    public class UserDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Role { get; set; } = "User";
        public string Email { get; set; }
        public string UserName { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
