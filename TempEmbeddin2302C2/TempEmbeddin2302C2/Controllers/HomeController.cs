using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TempEmbeddin2302C2.Models;

namespace TempEmbeddin2302C2.Controllers
{
    public class HomeController : Controller
    {
        private readonly _2302c2EcommerceContext db;

        public HomeController(_2302c2EcommerceContext _db)
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
        public IActionResult Details(int id)
        {
            var data = db.Items.Include(item => item.Cat);
            var item = data.FirstOrDefault(prd =>prd.Id == id );

            return View(item);
        }

    }
}