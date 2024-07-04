using Microsoft.AspNetCore.Mvc;

namespace TempEmbeddin2302C2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()                                                              
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string pass)
        {
            if(email=="admin@gmail.com" && pass== "123")
            {
                return RedirectToAction("Index");
            }else if (email == "user@gmail.com" && pass == "123")
            {
                return RedirectToAction("Index","Home");
            }
            else
            {

            return View();
            }
        }


    }
}
