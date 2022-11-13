using InnoGotchiWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchiWebAPI.Domain.DTO
{
    public class AddCollaborationToUserDTO
    {
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Keyword { get; set; }
        [StringLength(255)]
        public string Route { get; set; }
    }
}
