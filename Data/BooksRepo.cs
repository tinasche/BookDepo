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
            throw new System.NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bpContext.Books.ToList();     
        }

        public Book GetBookById(int id)
        {
            return _bpContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateBook(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}