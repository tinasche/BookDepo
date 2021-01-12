using System.Collections.Generic;
using BookDepo.Models;

namespace BookDepo.Data
{
    //TODO: Work on DbContext for this implementation
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(int id);
        void DeleteAuthor(int id);
    }
}