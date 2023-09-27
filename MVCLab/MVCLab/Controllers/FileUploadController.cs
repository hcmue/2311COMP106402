using Microsoft.AspNetCore.Mvc;

namespace MVCLab.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
