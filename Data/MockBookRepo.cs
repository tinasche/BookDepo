using System;
using System.Collections.Generic;
using BookDepo.Models;

namespace BookDepo.Data
{
    public class MockBookRepo : IBookService
    {
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
            var sampleBooks = new List<Book>
            {
                new Book {
                    Id = 5,
                    Genre = "Drama",
                    Title = "The Book of Eli",
                    PublishedYear = 2005,
                    Publisher = "Necrome Publishing House",
                    Author = new Author
                    {
                        Id = 2,
                        FirstName = "Tinashe",
                        LastName = "Chitakunye",
                        BooksPublished = 2
                    },
                    CreatedOn = DateTime.UtcNow
                },
                new Book {
                    Id = 1,
                    Genre = "Romance",
                    Title = "Till Death Do Us Part...",
                    PublishedYear = 2014,
                    Publisher = "Necrome Publishing House",
                    Author = new Author
                    {
                        Id = 1,
                        FirstName = "Anesu",
                        LastName = "Chitakunye",
                        BooksPublished = 4
                    },
                    CreatedOn = DateTime.UtcNow
                },
                new Book {
                    Id = 2,
                    Genre = "Sci-Fi",
                    Title = "Star Wars: Revenge of the Sith",
                    PublishedYear = 2005,
                    Publisher = "LightBurn Pubs",
                    Author = new Author
                    {
                        Id = 5,
                        FirstName = "Rodrigue",
                        LastName = "Montana",
                        BooksPublished = 3
                    },
                    CreatedOn = DateTime.UtcNow
                }
        };

            return sampleBooks;
        }

        public Book GetBookById(int id)
        {
            return new Book
            {
                Id = 5,
                Genre = "Drama",
                Title = "The Book of Eli",
                PublishedYear = 2005,
                Publisher = "Necrome Publishing House",
                Author = new Author
                {
                    Id = 2,
                    FirstName = "Tinashe",
                    LastName = "Chitakunye",
                    BooksPublished = 2
                },
                CreatedOn = DateTime.UtcNow
            };
        }

        public void UpdateBook(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}