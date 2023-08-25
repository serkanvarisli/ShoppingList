using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.ViewModel;

namespace ShoppingList.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin"); 
            }
            return View();
		}
		public IActionResult Register()
		{
			return View();
		}
        public IActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Admin(AdminLoginViewModel model)
        {
            if (model.adminemail == "admin@gmail.com" && model.adminpassword == "123")
            {
                await HttpContext.SignOutAsync("AdminAuthentication");

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, model.adminemail));


                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("AdminAuthentication",principal, new AuthenticationProperties() { IsPersistent = false });

                return RedirectToAction("Index", "Admin");
            }
            else {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı";

            }
            return View(model);
        }
        public IActionResult AdminLogout()
        {
            // Oturumu sonlandırma işlemleri
            HttpContext.SignOutAsync("AdminAuthentication"); // Oturumu sonlandır
            return RedirectToAction("Index", "Admin"); // Anasayfaya yönlendir
        }
    }
}
