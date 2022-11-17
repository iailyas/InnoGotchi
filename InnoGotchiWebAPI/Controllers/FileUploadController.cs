
using InnoGotchiWebAPI.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

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
                string path = webHostEnvironment.ContentRootPath + "\\Uploads\\";
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
        [HttpGet]
        public async Task<IActionResult> Get(string filename) 
        {
            string path = webHostEnvironment.ContentRootPath+"\\Uploads\\";
            var filePath = Path.Combine(path, filename)+".jpg";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/jpg");
            }
            return null;
        }
    }
}
