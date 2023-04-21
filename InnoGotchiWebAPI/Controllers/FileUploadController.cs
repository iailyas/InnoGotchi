
using InnoGotchiWebAPI.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Drawing;
using System.IO;

namespace InnoGotchiWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
  
    public class FileUploadController:ControllerBase
    {
        private IWebHostEnvironment webHostEnvironment;

        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<string> Post([FromForm]UserDTO user)
        {
            try
            {

                string path = "F:\\prog\\myrepository\\Angular\\AngularApp\\src\\assets\\images\\";
                using (FileStream fs = System.IO.File.Create(path + user.Avatar.FileName))
                {
                    await user.Avatar.CopyToAsync(fs);
                    fs.Flush();
                    return "done";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpPost("/default")]
        public async Task<string> Post(IFormFile file)
        {
            try
            {
                string path = "F:\\prog\\myrepository\\Angular\\AngularApp\\src\\assets\\images\\";
                using (FileStream fs = System.IO.File.Create(path + file.FileName))
                {
                    await file.CopyToAsync(fs);
                    fs.Flush();
                    return "done";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get(string filename) 
        {

            string path = "F:\\prog\\myrepository\\Angular\\AngularApp\\src\\assets\\images\\";
            var filePath = Path.Combine(path, filename)+".jpg";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "jpg");
            }
            return null;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            byte[] b=null;
            string[] allfiles = Directory.GetFiles("F:\\prog\\myrepository\\Angular\\AngularApp\\src\\assets\\images\\");
            foreach (string file in allfiles)
            {
                var filePath = Path.Combine("F:\\prog\\myrepository\\Angular\\AngularApp\\src\\assets\\images\\", file) + ".jpg";
                if (System.IO.File.Exists(filePath))
                {
                    b = System.IO.File.ReadAllBytes(filePath);
                    
                }
                return File(b, "jpg");
            }
            
          return null;
           
           
        }
    }
}
