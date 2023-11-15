using Microsoft.AspNetCore.Mvc;
using MyEStoreProject.Data;
using MyEStoreProject.Models;

namespace MyEStoreProject.Controllers
{
	public class CartController : Controller
	{
		private readonly MyeStoreContext _ctx;

		public CartController(MyeStoreContext ctx)
		{
			_ctx = ctx;
		}

		public List<CartItem> Carts
		{
			get
			{
				var data = HttpContext.Session.Get<List<CartItem>>("GioHang") ?? new List<CartItem>();
				return data;
			}
		}
		public IActionResult Index()
		{
			return View(Carts);
		}

		public IActionResult AddToCart(int id, int qty = 1)
		{
			var gioHang = Carts;

			var item = gioHang.SingleOrDefault(p => p.ProductId == id);
			if (item != null)
			{
				item.Quantity += qty;
			}
			else
			{
				var hangHoa = _ctx.HangHoas.SingleOrDefault(p => p.MaHh == id);
				if (hangHoa != null)
				{
					item = new CartItem
					{
						ProductId = id,
						Quantity = qty,
						Price = hangHoa.DonGia ?? 0,
						ImageUrl = hangHoa.Hinh,
						ProductName = hangHoa.TenHh
					};
					gioHang.Add(item);
				}
			}
			HttpContext.Session.Set("GioHang", gioHang);
			return RedirectToAction("Index");
		}
	}
}
