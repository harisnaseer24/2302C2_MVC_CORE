using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodiContext _db;
        public FoodController(FoodiContext db) {
            _db = db;
        }




        [HttpGet]
        public IActionResult GetChef()
        {
            return Ok(_db.Chefs.ToList());

        }

        [HttpPost]
        public IActionResult AddChef(Chef chef)
        {
            _db.Chefs.Add(chef);
            _db.SaveChanges();


            return StatusCode(201);

        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var chef = _db.Chefs.Find(id);
            _db.Chefs.Remove(chef);
            _db.SaveChanges();
            return Ok();

        }
    }
}
