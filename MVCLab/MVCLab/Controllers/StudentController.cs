using Microsoft.AspNetCore.Mvc;
using MVCLab.Models;

namespace MVCLab.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult CheckStudentExist(string StudentId)
        {
            var students = new List<string>() { "47.01.104.004", "47.01.104.104", "47.01.104.404" };
            if (students.Contains(StudentId))
            {
                return Json(false);
            }
            return Json(true);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student sinhVien)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Còn lỗi server");
            }
            return View();
        }
    }
}
