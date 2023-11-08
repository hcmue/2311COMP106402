using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyEStoreProject.Data;
using MyEStoreProject.Models;
using System.Security.Claims;

namespace MyEStoreProject.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly MyeStoreContext _ctx;

        public KhachHangController(MyeStoreContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult DangNhap(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            var kh = _ctx.KhachHangs.SingleOrDefault(kh => kh.MaKh == model.UserName && kh.MatKhau == model.Password);
            if (kh != null)
            {
                //set claim
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Email, kh.Email),
                    new Claim("FullName", kh.HoTen),

                    // động???
                    new Claim(ClaimTypes.Role, "KhachHang"),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                return Redirect("/");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
