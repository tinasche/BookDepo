using Microsoft.AspNetCore.Mvc;
using BookDepo.Data;
using BookDepo.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BookDepo.Controllers
{
    [ApiController]
    [Route("api/patrons")]
    public class PatronsController : ControllerBase
    {
        private readonly BooksDepoContext _context;

        public PatronsController(BooksDepoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patron>> GetAllPatrons()
        {
            var patronList = _context.Patrons.ToList();
            if (patronList == null)
            {
                return NotFound();
            }
            return Ok(patronList);
        }

        [HttpGet("{id}", Name="GetPatronById")]
        public ActionResult<Patron> GetPatronById(int id)
        {
            var patron = _context.Patrons.FirstOrDefault(x => x.Id == id);
            if (patron == null)
            {
                return NotFound();
            }
            return Ok(patron);
        }

        [HttpPost]
        public ActionResult<Patron> CreatePatron([FromBody] Patron aPatron)
        {
            if (aPatron == null)
            {
                throw new ArgumentNullException(nameof(aPatron));
            }

            _context.Patrons.Add(aPatron);
            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetPatronById), new { Id = aPatron.Id }, aPatron);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePatron([FromRoute] int id)
        {
            var aPatron = _context.Patrons.FirstOrDefault(x => x.Id == id);
            if (aPatron == null)
            {
                return NotFound();
            }
            _context.Patrons.Remove(aPatron);
            _context.SaveChanges();

            return Ok();
        }
        
        //TODO: Complete the Update method
    }
}