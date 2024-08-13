using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TempEmbeddin2302C2.Models;

namespace TempEmbeddin2302C2.Controllers
{
    public class HomeController : Controller
    {
        private readonly _2302c2ecommerceContext db;

        public HomeController(_2302c2ecommerceContext _db)
        {
            db = _db;
        }

     
        [Authorize]
        public IActionResult Index()
        {
            return View();
         
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            TempData.Keep("phone");
            return View();
        }

        public IActionResult Products()
        {
            var data = db.Items.Include(item => item.Cat);
            return View(data.ToList());
        }

        [Authorize (Roles ="User")]
        public IActionResult Details(int id)
        {
            var data = db.Items.Include(item => item.Cat);
            var item = data.FirstOrDefault(prd =>prd.Id == id );

           if(item != null)
            {
                Cart cart = new Cart();
                ViewBag.Cart = cart;

            return View(item);
            }
            else
            {
            return RedirectToAction("Products");
            }
            
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(Cart cart)
        {
            cart.Total = cart.Price * cart.Qty;
            db.Carts.Add(cart); 
            db.SaveChanges();
            return RedirectToAction("Products");
        }

    }
}