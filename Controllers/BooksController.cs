using System.Collections.Generic;
using AutoMapper;
using BookDepo.Data;
using BookDepo.Dtos;
using BookDepo.Models;
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
        [HttpGet("{id}", Name="GetBookById")]
        public ActionResult <BookReadDto> GetBookById(int id)
        {
            var book = _bookRepo.GetBookById(id);
            if (book != null)
            {
                var bookDTO = _mapper.Map<BookReadDto>(book);
                return Ok(bookDTO);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <BookReadDto> AddBook(BookAddDto bookAddDto)
        {
            var bookItem = _mapper.Map<Book>(bookAddDto);
            _bookRepo.CreateBook(bookItem);
            var bookDTO = _mapper.Map<BookReadDto>(bookItem);
            
            return CreatedAtRoute(nameof(GetBookById), new { Id = bookDTO.Id }, bookDTO);
        }
    }
}