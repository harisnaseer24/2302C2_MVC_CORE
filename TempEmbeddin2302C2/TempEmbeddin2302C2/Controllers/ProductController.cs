using Microsoft.AspNetCore.Mvc;

using TempEmbeddin2302C2.Models;

namespace TempEmbeddin2302C2.Controllers
{
    public class ProductController : Controller
    {
        _2302c2ecommerceContext db= new _2302c2ecommerceContext();
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
