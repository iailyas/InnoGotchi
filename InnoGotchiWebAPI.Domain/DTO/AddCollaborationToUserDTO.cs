using System.ComponentModel.DataAnnotations;

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
