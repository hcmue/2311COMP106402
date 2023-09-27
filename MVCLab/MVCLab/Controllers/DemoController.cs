using Microsoft.AspNetCore.Mvc;
using MVCLab.Models;
using System.Diagnostics;

namespace MVCLab.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult SyncDemo()
        {
            var sw = new Stopwatch();
            sw.Start();
            Demo.A();
            Demo.B();
            Demo.C();
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }

        public async Task<IActionResult> AsyncDemo()
        {
            var sw = new Stopwatch();
            sw.Start();
            var a = Demo.AA();
            var b = Demo.BB();
            var c = Demo.CC();
            await a;
            await b;
            await c;
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }
    }
}
