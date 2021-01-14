using AutoMapper;
using BookDepo.Dtos;
using BookDepo.Models;

namespace BookDepo.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            // source -> target
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorAddDto, Author>(); // use with updates as well.
            CreateMap<Author, AuthorAddDto>();
        }
    }
}