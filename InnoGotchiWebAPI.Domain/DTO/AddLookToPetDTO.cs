using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
