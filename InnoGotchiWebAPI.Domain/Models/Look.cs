using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class Look
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public string? Eye { get; set; }
        public string? Nose { get; set; }
        public string? Mouth { get; set; }
        [JsonIgnore]
        public Pet? Pet { get; set; }
        public int? PetId { get; set; }
        
    }
}
