using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using Microsoft.EntityFrameworkCore;
using ShoppingList.ViewModel;

namespace ShoppingList.Controllers
{
    public class AdminController : Controller
    {
        //[Authorize]
        MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Panel()
        {
            return View();
        }
        public IActionResult Product()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLoginViewModel adminLoginViewModel)
        {
            if (adminLoginViewModel.adminemail == "admin@gmail.com" && adminLoginViewModel.adminpassword == "admin123")
            {
                return RedirectToAction("Panel", "Admin");
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
            var kategori = _context.Categories.ToList();
            return View(kategori);
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
