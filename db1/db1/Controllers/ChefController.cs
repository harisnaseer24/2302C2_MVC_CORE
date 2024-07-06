using db1.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace db1.Controllers
{
    public class ChefController : Controller
    {
        FoodiContext db = new FoodiContext();
        public IActionResult Index()
        {
           
            return View(db.Chefs.ToList());
        } 
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Chef c)
        {
            if (ModelState.IsValid)
            {
                db.Chefs.Add(c);
                db.SaveChanges();
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = db.Chefs.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Chef c)
        {
            if (ModelState.IsValid)
            {
                db.Update(c);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = db.Chefs.Find(id);
            return View(data);
        }

        [HttpPost]

        [HttpPost]
        public IActionResult Delete(int id, Chef vs)
        {
            
                db.Remove(vs);
                db.SaveChanges();
            

            return RedirectToAction("Index");
        }

        public  IActionResult Details (int? id)
        {
            if (id == null || db.Menus == null)
            {
                return NotFound();
            }

            var chef =  db.Chefs
                .FirstOrDefault(m => m.Id == id);
            if (chef == null)
            {
                return NotFound();
            }

            return View(chef);
        }
    }
}
