using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context) {
            _context = context;
        }

    [HttpGet] // /api/breads
    public IEnumerable<Bread> GetAll() {
        //include the joint Baker for each bread
        return _context.Breads.Include(Baker => Baker.bakedBy);
    }

    //get one bread by id
    // /api/breads/4
    [HttpGet("{id}")]
    public ActionResult<Bread> GetById(int id) {
            Bread bread = _context.Breads
                .Include(Baker => Baker.bakedBy)
                .SingleOrDefault(bread => bread.id == id);
            

            if(bread is null) {
                // can't find it
                return NotFound(); // status 404
            }

            return bread;
        }

    [HttpPost]
    public IActionResult Create(Bread bread) {
        _context.Add(bread);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Create), new {id = bread.id}, bread);
    }

    [HttpPut("{id}")] // req.params.id
    public IActionResult Put(int id, Bread bread) {
        Console.WriteLine("updating bread");

        if (id != bread.id) {
            // does not match the given bread id
            return BadRequest();
        }

        // update the DB
        _context.Update(bread);
        _context.SaveChanges();

        return NoContent(); // 204
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        // select the bread from Db
        Bread bread = _context.Breads.SingleOrDefault( b => b.id == id);

        if(bread is null) {
            // not bread with this id
            return NotFound();
        }    

        _context.Breads.Remove(bread);
        _context.SaveChanges();

        return NoContent(); //204
        
        }
}
}
