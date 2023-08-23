using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
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
            var lists = _context.Lists.ToList();

            return View(lists);
		}

        public IActionResult List()
        {
            return View();
        }
        public IActionResult AddList()
        {
            return View();
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