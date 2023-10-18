using Microsoft.AspNetCore.Mvc;

namespace LayoutDemo.Areas.admin.Controllers
{
    [Area("Admin")]
    public class HangHoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
