using System.ComponentModel.DataAnnotations;

namespace InnoGotchiWebAPI.Domain.DTO
{
    public class AddCharacteristicToPetDTO
    {
        public int Age { get; set; }
        [StringLength(255)]
        public string Hunger_level { get; set; }
        [StringLength(255)]
        public string Thisty_level { get; set; }
        public int PetId { get; set; }
    }
}
