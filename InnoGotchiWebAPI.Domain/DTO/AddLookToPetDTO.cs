using Microsoft.AspNetCore.Http;

namespace InnoGotchiWebAPI.Domain.DTO
{
    public class AddLookToPetDTO
    {
        public IFormFile? Body { get; set; }
        public IFormFile? Eye { get; set; }
        public IFormFile? Nose { get; set; }
        public IFormFile? Mouth { get; set; }
    }
}
