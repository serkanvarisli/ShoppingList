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
                .Select(p => new AdminAddFileViewModel()
                {
                    ProductName = p.ProductName,
                    ProductImage = p.ProductImage,
                    CategoryName = p.Category.CategoryName,
                    ProductId = p.ProductId
                })
                .ToList();

            return View(product);
        }
        [HttpGet]
        
        public IActionResult AddProduct()
		{
			return View();
		}
        [HttpPost]
        public IActionResult AddProduct(AdminAddFileViewModel adminAddFileViewModel)
        {
            if (_context.Products.Any(c => c.ProductName == adminAddFileViewModel.ProductName))
            {
                TempData["ErrorMessage"] = "Ürün zaten var";
                return RedirectToAction("AddProduct", "Admin");
            }
            var product = new Product
            {
                ProductName = adminAddFileViewModel.ProductName,
                ProductImage = adminAddFileViewModel.ProductImage,
                CategoryId = adminAddFileViewModel.CategoryId
            };

            // Ürünü veritabanına kaydetme
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Product", "Admin");

        }
        [HttpGet]
        public IActionResult UpdateProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return NotFound(); // Ürün bulunamazsa
            }

            var productUpdateViewModel = new AdminAddFileViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                ProductImage = product.ProductImage
                // Diğer özellikleri de ViewModel'e aktarabilirsiniz
            };

            return View(productUpdateViewModel);
        }

        [HttpPost]
        public IActionResult UpdateProduct(AdminAddFileViewModel viewModel)
        {
                        
            var product = _context.Products.FirstOrDefault(p => p.ProductId == viewModel.ProductId);

            if (product == null)
            {
                return NotFound(); // Ürün bulunamazsa
            }

            // ViewModel'den alınan verilerle ürünü güncelle
            product.ProductName = viewModel.ProductName;
            product.CategoryId = viewModel.CategoryId;
            product.ProductImage = viewModel.ProductImage;
            // Diğer özellikleri güncelleyebilirsiniz

            _context.SaveChanges(); // Veritabanını güncelle
                
            return RedirectToAction("Product","Admin"); // Güncelleme tamamlandığında bir başka sayfaya yönlendir
        }

        public IActionResult DeleteProduct(AdminAddFileViewModel adminEditFileViewModel)
        {
            var productsToDelete = _context.Products.Where(p => p.ProductId == adminEditFileViewModel.ProductId).SingleOrDefault();

            if (productsToDelete==null)
            {
                return NotFound();
                // Handle the case where no products with the given CategoryId exist
            }
            else
            {
                _context.Products.Remove(productsToDelete);
                _context.SaveChanges();
                return RedirectToAction("Product", "Admin");
            }
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
