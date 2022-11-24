using InnoGotchiWebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace InnoGotchiWebAPI.Mapper.Commands
{
    public class UserCommand
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string First_Name { get; set; }
        [StringLength(255)]
        public string Last_Name { get; set; }
        [StringLength(255)]
        public string Role { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public string? Avatar { get; set; }
        //public int? CollaborationId { get; set; }
        public List<Collaboration>? Collaborations { get; set; }
        public List<Farm>? Farms { get; set; }
    }
}
