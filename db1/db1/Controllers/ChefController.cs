using db1.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult product()
        {
            var mydbContext = db.Products.Include(p => p.Cat);
            return View(mydbContext.ToList());
        }

        [HttpGet]
        public IActionResult addpro()
        {
            ViewData["Catid"] = new SelectList(db.Menus, "Id", "Namee");

            return View();
        }
        [HttpPost]
        public IActionResult addpro(Product pr, IFormFile file)
        {
            var imageName = Path.GetFileName(file.FileName);
            string imagePath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Image/");
            string imagevalue = Path.Combine(imagePath, imageName);
            using (var stream = new FileStream(imagevalue, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var dbimage = Path.Combine("/Image/", imageName);
            pr.Imagepath = dbimage;
            db.Products.Add(pr);
            db.SaveChanges();

            ViewData["Catid"] = new SelectList(db.Menus, "Id", "Namee");
            return RedirectToAction("product");
        }

        [HttpGet]
        public IActionResult proDelete(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult proDelete(int id, Product vs)
        {
            if (ModelState.IsValid)
            {
                db.Remove(vs);
                db.SaveChanges();
            }

            return RedirectToAction("product");
        }




        [HttpGet]
        public IActionResult proUpdate(int id)
        {


            ViewData["CatId"] = new SelectList(db.Menus, "Id", "Namee");
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult proUpdate(int id, Product vs, IFormFile file, string hid)
        {
            if (ModelState.IsValid)
            {
                var dbimage = "";
                if (file != null && file.Length > 0)
                {
                    var imageName = Path.GetFileName(file.FileName);
                    string imagePath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Image/");
                    string imagevalue = Path.Combine(imagePath, imageName);
                    using (var stream = new FileStream(imagevalue, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    dbimage = Path.Combine("/Image/", imageName);
                    vs.Imagepath = dbimage;
                    db.Update(vs);
                    db.SaveChanges();

                }
                else
                {
                    vs.Imagepath = hid;
                    db.Update(vs);
                    db.SaveChanges();

                }

            }
            ViewData["CatId"] = new SelectList(db.Menus, "Id", "Namee");
            return RedirectToAction("product");
        }



    }
}
