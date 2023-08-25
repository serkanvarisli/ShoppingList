using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using Microsoft.EntityFrameworkCore;
using ShoppingList.ViewModel;

namespace ShoppingList.Controllers
{
    [Authorize(AuthenticationSchemes="AdminAuthentication")]
    public class AdminController : Controller
    {
        //[Authorize]
        MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {

            return View();
        }
        [HttpGet]
        
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
        

    }
}
