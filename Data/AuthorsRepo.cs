using System;
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
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            _bpContext.Authors.Add(author);
            _bpContext.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            
            _bpContext.SaveChanges();
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
            
            _bpContext.SaveChanges();
        }
    }
}