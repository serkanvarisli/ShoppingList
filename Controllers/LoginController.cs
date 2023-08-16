using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
	}
}
