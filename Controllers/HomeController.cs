using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Index(string p)
		{
            string username = User.Identity.Name;
            TempData["username"] = username;
            var kullaniciListe = _context.Lists
                .Include(l => l.User)
                .Where(l => l.User.UserEmail == username)
                .Select(l => new UserListsViewModel
                {
                    ListName = l.ListName,
                    ListId = l.ListId,
                })
                .ToList();

            return View(kullaniciListe);
		}

        [HttpGet]
        public IActionResult AddList()
        {
            string username = User.Identity.Name;
            TempData["username"] = username;

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
        [AllowAnonymous]
        public IActionResult DeleteList(UserListsViewModel user)
        {
            var ListToDelete = _context.Lists
                //.Include(l => l.ProductDetails)
                .Where(p => p.ListId == user.ListId).SingleOrDefault();

            if (ListToDelete == null)
            {
                return NotFound();
            }
            else
            {
                //// Önce productDetail tablosundaki ilişkili kayıtları silin
                //_context.ProductDetails.RemoveRange(ListToDelete.ProductDetails);

                // Ardından ana listenin kaydını silin
                _context.Lists.Remove(ListToDelete);

                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult List(string p, string categoryFilter,int listId)
        {

            string username = User.Identity.Name;
            TempData["username"] = username;

            ViewBag.ListId = listId;

            var products = _context.ProductDetails
                .Include(p => p.List)
                .Include(p => p.Product)
                .Where(l => l.ListId == listId)
                .Select(l => new UserProductViewModel
                {
                    ProductName = l.Product.ProductName,
                    ProductImage = l.Product.ProductImage,
                    CategoryName = l.Product.Category.CategoryName,
                    ListId = listId,
                    ProductId=l.ProductId,
                    ProductDetailId = l.ProductDetailId
				});
            //arama
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(x => x.ProductName.Contains(p));
            }
            //filtreleme
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryName.ToString(),
                Text = c.CategoryName
            }).ToList();
            ViewBag.Categories = categories;
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                if (categoryFilter != "all")
                {
                    products = products.Where(x => x.CategoryName == categoryFilter);
                }
            }

            return View(products.ToList());
        }
        public IActionResult ProductSelectToAdd(string searchTerm, string categoryFilter,int listId)
        {
            string username = User.Identity.Name;
            TempData["username"] = username;

            // Kullanıcının UserId'sini veritabanından çekme
            var userId = _context.Users
                .Where(u => u.UserEmail == username)
                .Include(u => u.Lists)
                .Select(u => u.UserId)
                .FirstOrDefault(); // Tek bir değer alıyoruz


            var product = _context.ProductDetails
                .Include(p => p.Product)
                .ThenInclude(p=>p.Category)
                .Select(p => new ProductDetail
                {
                    ProductId= p.ProductId,
                    ListId = listId,
                    UserId = userId,
                    ProductBrand = p.ProductBrand,
                    ProductQuantity = p.ProductQuantity,
                    ProductDetail1 = p.ProductDetail1
                })
                .ToList();
            var products = _context.Products
                .Include(p => p.ProductDetails)
                .Include(p => p.Category)
                .ToList();
            ViewBag.Products = products;
            //arama
            if (!string.IsNullOrEmpty(searchTerm))
            {
				ViewBag.Products = products.Where(x => x.ProductName.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            //filtreleme
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryName.ToString(),
                Text = c.CategoryName
            }).ToList();
            ViewBag.Categories = categories;
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                if (categoryFilter != "all")
                {
					ViewBag.Products = products.Where(y => y.Category.CategoryName == categoryFilter).ToList();
                }
            }
            return View(product.ToList());
        }
        [HttpPost]
        public IActionResult ProductSelectToAdd(ProductDetail model)
        {
            _context.ProductDetails.Add(model);
            _context.SaveChanges();
            return RedirectToAction("List", "Home", new {listId=model.ListId});
        }
        [HttpGet]
        public IActionResult ProductDetail(int productDetailId)
        {
            var product= _context.ProductDetails
                .Include(p => p.Product)
				.Where(p => p.ProductDetailId == productDetailId)
                .SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProductDetail(ProductDetail model)
        {
			var product = _context.ProductDetails.FirstOrDefault(p => p.ProductDetailId == model.ProductDetailId);
			if (product == null)
			{
				return NotFound();
			}
			product.ProductBrand = model.ProductBrand;
			product.ProductQuantity = model.ProductQuantity;
			product.ProductDetail1 = model.ProductDetail1;
			_context.SaveChanges();
			return RedirectToAction("Product", "Home", new { productDetailId = model.ProductDetailId });
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