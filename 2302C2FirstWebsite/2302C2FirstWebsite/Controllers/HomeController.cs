using _2302C2FirstWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2302C2FirstWebsite.Controllers
{
	public class HomeController : Controller
	{
		

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		

		
	}
}