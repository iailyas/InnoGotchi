using System.Text.Json.Serialization;

namespace InnoGotchiWebAPI.Domain.Models
{
    public class Look
    {
        public int Id { get; set; }
        public byte[]? Body { get; set; }
        public byte[]? Eye { get; set; }
        public byte[]? Nose { get; set; }
        public byte[]? Mouth { get; set; }
        [JsonIgnore]
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
