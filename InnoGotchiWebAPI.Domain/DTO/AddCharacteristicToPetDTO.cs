using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
