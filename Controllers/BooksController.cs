using System.Collections.Generic;
using AutoMapper;
using BookDepo.Data;
using BookDepo.Dtos;
using BookDepo.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookDepo.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookRepo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Setup for instantiating a BooksController object with incorporation
        /// of an implementation of our repository.
        /// </summary>
        /// <param name="bookRepo"></param>
        public BooksController(IBookService bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method to fetch the entire resource content of books.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetAllBooks()
        {
            var bookItems = _bookRepo.GetAllBooks();
            if (bookItems != null)
            {
                var bookDTOs = _mapper.Map<IEnumerable<BookReadDto>>(bookItems);
                return Ok(bookDTOs);
            }
            return NoContent();
        }
        

        /// <summary>
        /// GET method to fetch a book based on its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book != null)
            {
                return Ok(_mapper.Map<BookReadDto>(book));
            }
            return NotFound();
        }

        /// <summary>
        /// Create a new book resource.
        /// </summary>
        /// <param name="bookAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BookReadDto> AddBook(BookAddDto bookAddDto)
        {
            var bookItem = _mapper.Map<Book>(bookAddDto);
            _bookRepo.CreateBook(bookItem);
            var bookDTO = _mapper.Map<BookReadDto>(bookItem);

            return CreatedAtRoute(nameof(GetBookById), new { Id = bookDTO.Id }, bookDTO);
        }

        /// <summary>
        /// DELETE a book by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var theBook = _bookRepo.GetBookById(id);
            if (theBook == null)
            {
                return NotFound("Book Not Available as a Resource.");
            }
            _bookRepo.DeleteBook(theBook);

            return Ok();
        }

        /// <summary>
        /// Update a book resource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, BookAddDto bookDto)
        {
            var theBook = _bookRepo.GetBookById(id);
            if (theBook == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, theBook);

            _bookRepo.UpdateBook(theBook);
            _bookRepo.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialBookUpdate(int id, JsonPatchDocument<BookAddDto> patchDoc)
        {
            var theBook = _bookRepo.GetBookById(id);
            if (theBook == null)
            {
                return NotFound();
            }

            var bookToPatch = _mapper.Map<BookAddDto>(theBook);
            patchDoc.ApplyTo(bookToPatch, ModelState);

            if (!TryValidateModel(bookToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(bookToPatch, theBook);
            _bookRepo.UpdateBook(theBook);
            _bookRepo.SaveChanges();

            return NoContent();
        }

    }
}