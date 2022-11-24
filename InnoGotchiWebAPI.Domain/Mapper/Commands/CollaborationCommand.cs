using InnoGotchiWebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Mapper.Commands
{
    public class CollaborationCommand
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Keyword { get; set; }
        [StringLength(255)]
        public string Route { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
