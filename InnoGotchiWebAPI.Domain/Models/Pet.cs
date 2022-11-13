using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Type { get; set; }
        public int Happiness_days_count { get; set; }
        public int Feeding_period { get; set; }
        public int Thist_quenching { get; set; }
        public List<Characteristic>? Characteristics { get; set; }
        public List<Look>? Looks { get; set; }
        [JsonIgnore]
        public Farm? Farm { get; set; }
        public int? FarmId { get; set; }
        



    }
}
