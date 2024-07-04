using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using TempEmbeddin2302C2.Models;

namespace TempEmbeddin2302C2.Controllers
{
    public class HomeController : Controller
    {
  
        public IActionResult Index()
        {
            //data can be accessed on same view
            ViewBag.name = "Haris Naseer";
            ViewData["email"] = "haris@gmail.com";


            //data can be accessed on other view as well as other controllers
            TempData["phone"] = "03241257793";

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


    }
}