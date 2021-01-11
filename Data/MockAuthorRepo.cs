using System.Collections.Generic;
using BookDepo.Models;

namespace BookDepo.Data
{
    public class MockAuthorRepo : IAuthorService
    {
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
            var allAuthors = new List<Author>
            {
                new Author
                {
                    Id = 5,
                    FirstName = "Toren",
                    LastName = "Serpentus",
                    BooksPublished = 7
                },
                new Author
                {
                    Id = 1,
                    FirstName = "Thesaurus",
                    LastName = "Von Demiem",
                    BooksPublished = 3
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Chris",
                    LastName = "Pine",
                    BooksPublished = 5
                }
            };

            return allAuthors;
        }

        public Author GetAuthorById(int id)
        {
            return new Author
            {
                Id = 5,
                FirstName = "Toren",
                LastName = "Serpentus",
                BooksPublished = 7
            };
        }

        public void UpdateAuthor(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}