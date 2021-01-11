using System.Collections.Generic;
using BookDepo.Data;
using BookDepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookDepo.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookRepo;

        public BooksController(IBookService bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var bookItems = _bookRepo.GetAllBooks();
            return Ok(bookItems);
        }

        [HttpGet("{id}")]
        public ActionResult <Book> GetBookById(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        
    }
}