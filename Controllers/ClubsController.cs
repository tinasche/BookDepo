using System;
using System.Collections.Generic;
using System.Linq;
using BookDepo.Data;
using BookDepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookDepo.Controllers
{
    [ApiController]
    [Route("api/clubs")]
    public class ClubsController : ControllerBase
    {
        private readonly BooksDepoContext _context;

        public ClubsController(BooksDepoContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Club>> GetAllClubs()
        {
            var patronList = _context.Clubs.ToList();
            if (patronList == null)
            {
                return NotFound();
            }
            return Ok(patronList);
        }

        [HttpGet("{id}", Name="GetClubById")]
        public ActionResult<Club> GetClubById(int id)
        {
            var club = _context.Clubs.FirstOrDefault(x => x.Id == id);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPost]
        public ActionResult<Club> CreateClub([FromBody] Club aClub)
        {
            if (aClub == null)
            {
                throw new ArgumentNullException(nameof(aClub));
            }

            _context.Clubs.Add(aClub);
            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetClubById), new { Id = aClub.Id }, aClub);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClub([FromRoute] int id)
        {
            var aClub = _context.Clubs.FirstOrDefault(x => x.Id == id);
            if (aClub == null)
            {
                return NotFound();
            }
            _context.Clubs.Remove(aClub);
            _context.SaveChanges();

            return Ok();
        }
        
        //TODO: Complete the Update method
    }
}