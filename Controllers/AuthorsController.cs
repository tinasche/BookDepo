using System.Collections.Generic;
using BookDepo.Data;
using BookDepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookDepo.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorRepo;

        public AuthorsController(IAuthorService authorRepo)
        {
            _authorRepo = authorRepo;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            var allAuthors = _authorRepo.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthorById(int id)
        {
            var theAuthor = _authorRepo.GetAuthorById(id);
            return Ok(theAuthor);
        }
        
    }
}