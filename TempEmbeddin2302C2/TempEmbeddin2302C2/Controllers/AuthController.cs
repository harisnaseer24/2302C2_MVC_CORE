using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using TempEmbeddin2302C2.Models;

namespace TempEmbeddin2302C2.Controllers
{
    public class AuthController : Controller
    {
        private readonly _2302c2ecommerceContext db;
        public AuthController(_2302c2ecommerceContext _db)
        {
            db = _db;
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(User user)
        {
            var checkUser = db.Users.FirstOrDefault(a => a.Email == user.Email);
            if (checkUser == null)
            {
                var hasher = new PasswordHasher<string>();
                string hashPassword = hasher.HashPassword(user.Email, user.Password);

                user.Password = hashPassword;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");

            }
            else
            {
             ViewBag.msg = "User Already registered. Please Login.";
            return View();
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            bool isAuthenticated = false;
            bool isAdmin = false;
            ClaimsIdentity identity = null;

            if (email == "admin@gmail.com" && pass == "123")
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,"Haris" ),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAdmin = true;
                isAuthenticated = true;


            }
            else if (email == "user@gmail.com" && pass == "123")
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,"user1" ),
                    new Claim(ClaimTypes.Role, "User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAdmin = false;
                isAuthenticated = true;

                //return RedirectToAction("Index", "Home");
            }
            if(isAuthenticated && isAdmin)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Admin");

            }
            else if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Auth");
        }
    }
}
