using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using ShoppingList.ViewModel;

namespace ShoppingList.Controllers
{
    [Authorize(AuthenticationSchemes = "UserAuthentication")]
	public class HomeController : Controller
	{
        //[Authorize]
        MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
            string username = User.Identity.Name;

            // Kullanıcı adına ait veriyi veritabanından çekme
            var kullaniciListe = _context.Lists
                .Include(l => l.User)
                .Where(l => l.User.UserEmail == username)
                .Select(l => new UserListsViewModel
                {
                    ListName=l.ListName,
                })
                .ToList();

            return View(kullaniciListe);
		}

        public IActionResult List()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddList()
        {
            string username = User.Identity.Name;

            // Kullanıcının UserId'sini veritabanından çekme
            var userId = _context.Users
                .Where(u => u.UserEmail == username)
                .Select(u => u.UserId)
                .FirstOrDefault(); // Tek bir değer alıyoruz

            var model = new UserListsViewModel
            {
                UserId = userId,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddList(List list)
        {
            _context.Lists.Add(list);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteList()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
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
        public IActionResult ProductReadOnly()
        {
            return View();
        }

    }
}