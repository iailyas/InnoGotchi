using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchiWebAPI.Domain.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public byte[]? Avatar { get; set; }
    }
}
