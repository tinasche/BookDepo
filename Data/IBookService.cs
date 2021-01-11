using System.Collections.Generic;
using BookDepo.Models;

namespace BookDepo.Data
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void UpdateBook(int id);
        void DeleteBook(int id);
    }
}