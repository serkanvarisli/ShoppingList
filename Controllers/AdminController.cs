using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Controllers
{
    public class AdminController : Controller
    {
        //[Authorize]

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string adminemail, string adminpassword)
        {
            if (adminemail == "admin@gmail.com" && adminpassword == "admin123")
            {
                return RedirectToAction("Index","Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
        }
        public IActionResult AddProduct()
		{
			return View();
		}
		public IActionResult UpdateProduct()
        {
            return View();
        }
		public IActionResult DeleteProduct()
		{
			return View();
		}
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult AddCategory()
        {
            return View();
        }    
        public IActionResult UpdateCategory()
        {
            return View();
        }
        public IActionResult DeleteCategory()
        {
            return View();
        }
        public IActionResult Logout()
        {
            // Oturumu sonlandırma işlemleri
            HttpContext.SignOutAsync(); // Oturumu sonlandır
            return RedirectToAction("Login", "Admin"); // Anasayfaya yönlendir
        }

    }
}
