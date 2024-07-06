using db1.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace db1.Controllers
{
    public class RecipesController : Controller
    {
        FoodiContext db = new FoodiContext();
        public IActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu m)
        {
            if(ModelState.IsValid)
            {
                db.Menus.Add(m);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Menus.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(int id,Menu vs)
        {
            if (ModelState.IsValid)
            {
                db.Update(vs);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int idval, Menu vs)
        {
            var data = db.Menus.Find(idval);
            if (data != null)
            {
                db.Menus.Remove(data);
                db.SaveChanges();
            }

          return RedirectToAction("Index");
        }

    }
}
