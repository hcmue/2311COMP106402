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
            catch
            {
                TempData["Message"] = $"Upload không thành công {description}";
            }

            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult UploadFiles(List<IFormFile> myfiles)
        {
            try
            {
                foreach (var myfile in myfiles)
                {
                    var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MyFiles", myfile.FileName);
                    using (var file = new FileStream(fullPath, FileMode.Create))
                    {
                        myfile.CopyTo(file);
                    }
                }
                TempData["Message"] = $"Upload thành công";
            }
            catch
            {
                TempData["Message"] = $"Upload không thành công ";
            }

            return Redirect("Index");
        }
    }
}
