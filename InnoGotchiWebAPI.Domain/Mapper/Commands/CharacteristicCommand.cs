using InnoGotchiWebAPI.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Mapper.Commands
{
    public class CharacteristicCommand
    {
        public int Id { get; set; }
        public int Age { get; set; }
        [StringLength(255)]
        public string Hunger_level { get; set; }
        [StringLength(255)]
        public string Thisty_level { get; set; }
        [JsonIgnore]
        public Pet? Pet { get; set; }
        public int? PetId { get; set; }
    }
}
