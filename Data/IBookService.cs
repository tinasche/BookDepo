using System.Collections.Generic;
using BookDepo.Models;

namespace BookDepo.Data
{
    //TODO: Work on DbContext for this implementation
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void UpdateBook(int id);
        void DeleteBook(int id);
    }
}