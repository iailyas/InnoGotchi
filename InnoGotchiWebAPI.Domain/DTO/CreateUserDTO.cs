using InnoGotchiWebAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchiWebAPI.Domain.DTO
{
    public class UserDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
