using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Controllers
{
	public class HomeController : Controller
	{
        //[Authorize]
		public IActionResult Index()
		{
			return View();
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

    }
}