using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class User
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
