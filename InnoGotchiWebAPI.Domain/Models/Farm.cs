using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class Farm
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int Dead_pets_count { get; set; }
        public int Alive_pets_count { get; set; }
        public float Average_feeding_period { get; set; }
        public float Average_thirst_quenching { get; set; }
        public float Average_pet_happiness { get; set; }
        public float Average_pets_age { get; set; }
        public List<Pet> Pets { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
