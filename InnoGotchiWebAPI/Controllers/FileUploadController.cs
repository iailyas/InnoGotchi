
using InnoGotchiWebAPI.Domain.DTO;
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
        [HttpPost("/default")]
        public async Task<string> Post(IFormFile file)
        {
            try
            {
                string path = webHostEnvironment.ContentRootPath + "\\Uploads\\";
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
            string path = webHostEnvironment.ContentRootPath+"\\Uploads\\";
            var filePath = Path.Combine(path, filename)+".jpg";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/jpg");
            }
            return null;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            byte[] b=null;
            string[] allfiles = Directory.GetFiles(webHostEnvironment.ContentRootPath + "\\Uploads\\");
            foreach (string file in allfiles)
            {
                var filePath = Path.Combine(webHostEnvironment.ContentRootPath + "\\Uploads\\", file) + ".jpg";
                if (System.IO.File.Exists(filePath))
                {
                    b = System.IO.File.ReadAllBytes(filePath);
                    
                }
            }
            return File(b, "image/jpg");
            return null;
           
           
        }
    }
}
