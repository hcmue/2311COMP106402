using Microsoft.AspNetCore.Mvc;

namespace MVCLab.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile myfile, string description)
        {
            try
            {
                var myPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MyFiles");
                if (!Directory.Exists(myPath))
                {
                    Directory.CreateDirectory(myPath);
                }
                var fullPath = Path.Combine(myPath, myfile.FileName);
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    myfile.CopyTo(file);
                }
                TempData["Message"] = $"Upload thành công {description}";
            }
            catch {
                TempData["Message"] = $"Upload không thành công {description}";
            }

            return Redirect("Index");
        }
    }
}
