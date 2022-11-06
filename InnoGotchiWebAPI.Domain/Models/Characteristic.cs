using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class Characteristic
    {
        public int Id { get; set; }
        public int Age { get; set; }
        [StringLength(255)]
        public string Hunger_level { get; set; }
        [StringLength(255)]
        public string Thisty_level { get; set; }
        [JsonIgnore]
        public int PetId { get; set; }
        public Pet Pet { get; set; }

    }
}
