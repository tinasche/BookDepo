using System.Collections.Generic;
using System.Linq;
using BookDepo.Models;

namespace BookDepo.Data
{
    public class AuthorsRepo : IAuthorService
    {
        private readonly BooksDepoContext _bpContext;

        public AuthorsRepo(BooksDepoContext bpContext)
        {
            _bpContext = bpContext;
        }
        public void AddAuthor(Author author)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAuthor(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _bpContext.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _bpContext.Authors.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateAuthor(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}