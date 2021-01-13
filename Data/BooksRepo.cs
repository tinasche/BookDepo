using System;
using System.Collections.Generic;
using System.Linq;
using BookDepo.Models;

namespace BookDepo.Data
{
    public class BooksRepo : IBookService
    {
        private readonly BooksDepoContext _bpContext;

        public BooksRepo(BooksDepoContext bpContext)
        {
            _bpContext = bpContext;
        }
        public void CreateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _bpContext.Books.Add(book);
            _bpContext.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            if (book != null)
            {
                _bpContext.Books.Remove(book);
                _bpContext.SaveChanges();
            }            
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bpContext.Books.ToList();     
        }

        public Book GetBookById(int id)
        {
            return _bpContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateBook(Book book)
        {
            // Nothing
        }

        public void SaveChanges()
        {
            _bpContext.SaveChanges();
        }
    }
}