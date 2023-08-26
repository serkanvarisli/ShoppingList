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

		public object PageUtility { get; private set; }

		public AdminController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product(int categoryid)
        {
            var product = _context.Products
                .Select(p => new AdminProductViewModel()
                {
                    ProductName = p.ProductName,
                    ProductImage = p.ProductImage,
                    CategoryName = p.Category.CategoryName
                })
                .ToList();

            return View(product);
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
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if(_context.Categories.Any(c => c.CategoryName == category.CategoryName))
            {
				TempData["ErrorMessage"] = "Kategori zaten var";
				return RedirectToAction("AddCategory", "Admin");
			}
			_context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Category","Admin");
               
        }
        [HttpGet]
        public IActionResult UpdateCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
			return View(category);
        }
        [HttpPost]
		public IActionResult UpdateCategory(Category category)
		{
			if (_context.Categories.Any(c => c.CategoryName == category.CategoryName))
			{
				TempData["ErrorMessage"] = "Kategori zaten var";
				return RedirectToAction("Category", "Admin");
			}
			_context.Categories.Update(category);
			_context.SaveChanges();
            TempData["SuccessMessage"] = "Kategori güncellendi";
			return RedirectToAction("Category", "Admin");
		}

        public IActionResult DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId); ;
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Category", "Admin");
        }
        

    }
}
