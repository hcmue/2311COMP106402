using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEStoreProject.Data;
using MyEStoreProject.Models;

namespace MyEStoreProject.Controllers
{
	public class HangHoaController : Controller
	{
		private readonly MyeStoreContext _ctx;

		public HangHoaController(MyeStoreContext ctx)
		{
			_ctx = ctx;
		}

		[Authorize]
		public IActionResult Search()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Search(string? keyword, double? priceFrom, double? priceTo)
		{
			var data = _ctx.HangHoas.AsQueryable();
			if (keyword != null)
			{
				data = data.Where(hh => hh.TenHh.Contains(keyword));
			}
			if (priceFrom != null)
			{
				data = data.Where(hh => hh.DonGia >= priceFrom);
			}
			if (priceTo != null)
			{
				data = data.Where(hh => hh.DonGia <= priceTo);
			}

			var result = data.Select(hh => new HangHoaVM
			{
				MaHh = hh.MaHh,
				TenHh = hh.TenHh,
				DonGia = hh.DonGia ?? 0,
				Hinh = hh.Hinh,
				Loai = hh.MaLoaiNavigation.TenLoai
			}).ToList();

			return View(result);
		}

		[Authorize(Roles ="Admin")]
		public IActionResult TimKiem()
		{
			return View();
		}

		public IActionResult XuLyTimKiem(string keyword)
		{
			var data = _ctx.HangHoas.Where(hh => hh.TenHh.Contains(keyword)).Select(hh => new HangHoaVM
			{
				MaHh = hh.MaHh,
				TenHh = hh.TenHh,
				DonGia = hh.DonGia ?? 0,
				Hinh = hh.Hinh,
				Loai = hh.MaLoaiNavigation.TenLoai
			}).ToList();
			return PartialView(data);
		}
	}
}
