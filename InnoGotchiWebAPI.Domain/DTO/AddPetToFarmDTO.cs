using InnoGotchiWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchiWebAPI.Domain.DTO
{
    public class AddPetToFarmDTO
    {
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Type { get; set; }
        public int Happiness_days_count { get; set; }
        public int Feeding_period { get; set; }
        public int Thist_quenching { get; set; }
        public int FarmId { get; set; }
    }
}
