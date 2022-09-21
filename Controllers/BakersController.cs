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
        public BakersController(ApplicationContext context) {
            _context = context;
        }
        //REST API
        [HttpGet]
        // router.get()
        // access return-type name(parameters)
        public IEnumerable<Baker> GetAll() {
            Console.WriteLine("get all bakers");

            return _context.Bakers;

        }

        [HttpPost]
        public IActionResult Post(Baker baker) {
            Console.WriteLine("in post baker");

            // SQL transactions
            _context.Add(baker);
            _context.SaveChanges();

            // 201 Create
            return CreatedAtAction(nameof(Post), new {id = baker.id}, baker);

        }
    }
}
