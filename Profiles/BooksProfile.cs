using AutoMapper;
using BookDepo.Dtos;
using BookDepo.Models;

namespace BookDepo.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            // source -> target
            CreateMap<Book, BookReadDto>();
            CreateMap<BookAddDto, Book>(); // used with updates as well

        }
        
    }
}