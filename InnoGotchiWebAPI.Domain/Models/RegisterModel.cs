using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

    }
}
