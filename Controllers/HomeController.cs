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
        public IActionResult List(string p, string categoryFilter)
        {

            string username = User.Identity.Name;

            var user = _context.Users
                .Include(u => u.ProductDetails)
                .FirstOrDefault(u => u.UserEmail == username);

            var products = _context.ProductDetails
                .Include(p => p.User)
                .Include(l => l.Product)
                .Where(l => l.User.UserEmail == username)
                .Select(l => new UserProductViewModel
                {
                    ProductName = l.Product.ProductName,
                    ProductImage = l.Product.ProductImage,
                    CategoryName = l.Product.Category.CategoryName,
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
        public IActionResult ProductSelectToAdd(string searchTerm, string categoryFilter)
        {
            var product = _context.Products
                .Select(p => new Product()
                {
                    ProductName = p.ProductName,
                    ProductImage = p.ProductImage,
                    CategoryId = p.CategoryId,
                    ProductId = p.ProductId
                })
                .ToList();
            //arama
            if (!string.IsNullOrEmpty(searchTerm))
            {
                product = product.Where(x => x.ProductName.ToLower().Contains(searchTerm.ToLower())).ToList();
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
                //if (categoryFilter != "all")
                //{
                //    product = product.Where(y => y.CategoryName == categoryFilter).ToList();
                //}
            }
            return View(product.ToList());
        }

        public IActionResult Product()
        {
            return View();
        }
        public IActionResult AddProduct(int id) 
        {
            var product = _context.Products
            .Where(p => p.ProductId == id)
            .SingleOrDefault();
            return View(product);
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