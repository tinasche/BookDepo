using System.Collections.Generic;
using AutoMapper;
using BookDepo.Data;
using BookDepo.Dtos;
using BookDepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookDepo.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorRepo;
        private readonly IMapper _mapper; // instance of our dependency injection DTO mapper

        public AuthorsController(IAuthorService authorRepo, IMapper mapper)
        {
            _authorRepo = authorRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method to fetch all Authors from the resource.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<AuthorReadDto>> GetAllAuthors()
        {
            var allAuthors = _authorRepo.GetAllAuthors();
            if (allAuthors != null)
            {
                var authorDTOs = _mapper.Map<IEnumerable<AuthorReadDto>>(allAuthors);
                return Ok(authorDTOs);
            }
            return NoContent();

        }

        /// <summary>
        /// GET a single author by their Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAuthorById")]
        public ActionResult<AuthorReadDto> GetAuthorById(int id)
        {
            var theAuthor = _authorRepo.GetAuthorById(id);
            if (theAuthor != null)
            {
                var authorDTO = _mapper.Map<AuthorReadDto>(theAuthor);
                return Ok(authorDTO);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AuthorReadDto> AddAuthor(AuthorAddDto theAuthor)
        {
            var authorContent = _mapper.Map<Author>(theAuthor);
            _authorRepo.AddAuthor(authorContent);

            var authorOutDto = _mapper.Map<AuthorReadDto>(authorContent);

            return CreatedAtRoute(nameof(GetAuthorById), new { Id = authorOutDto.Id }, authorOutDto);
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var theAuthor = _authorRepo.GetAuthorById(id);
            if (theAuthor == null)
            {
                return NotFound(nameof(theAuthor));
            }
            _authorRepo.DeleteAuthor(theAuthor);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuthon(int id, AuthorAddDto authorAddDto)
        {
            var theAuthor = _authorRepo.GetAuthorById(id);
            if (theAuthor == null)
            {
                return NotFound();
            }
            _mapper.Map(authorAddDto, theAuthor); // this syntax allows to update like(source, target)
            _authorRepo.SaveChanges();

            return NoContent();
        }

        //TODO: Get the Patch Request for authors working.
    }
}