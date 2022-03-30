//IActionResults are normally going to be status, and they're a generic template
// If it is IActionResult you need to define NotFounds and BadRequests
//ActionResult would be returning something like <Baker> a model, so it doesn't need to be generic/customized. The code knows what to expect.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        // routes to database
        public BakersController(ApplicationContext context) {
            _context = context; // pool
        }

        // OUR API
        // Get all bakers
        [HttpGet]
        public IEnumerable<Baker> GetAll() //GetAll is taco
        {
            Console.WriteLine("get all bakers");
            // no SQL
            return _context.Bakers;
        }

        // Get 1 baker by id
        // GET /api/bakers/:id
        [HttpGet("{id}")] //HttpGet is a function 
        public ActionResult<Baker> GetById(int id) 
        {
            Console.WriteLine("get one baker");
            Baker baker = _context.Bakers
                .SingleOrDefault(baker => baker.id == id); 
            // Bakers model has a method SingleOrDefault

            if(baker is null) {
                return NotFound(); // res.sendStatus(404)
            }

            return baker;
        }
        // Post - add a new baker
        [HttpPost]
        public IActionResult Post(Baker baker)
        {
            // uses a transactions
            _context.Add(baker); // insert, not committed
            _context.SaveChanges(); // 

            // return baker; // would be missing id

            // returns the url to /api/Bakers?id=<new-id-number>
            return CreatedAtAction(nameof(Post),
                                   new { id = baker.id }, baker);
        }
        // Delete a baker by id
        // Put - change a baker's name by id
        // stretch: Patch a baker by id (like a put)

    }
}
