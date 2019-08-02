using System;
using System.Collections.Generic;
using System.Linq;
using Aplikacja_testowa.Abstracts;
using Aplikacja_testowa.DAL;
using Aplikacja_testowa.DTOs;

namespace Aplikacja_testowa.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext dbContext;

        public BookRepository(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Create(string title)
        {
            var newBooke = new Book
            {
                AuthorId = 1,
                Title = title,
                Created = DateTime.UtcNow
            };

            dbContext.Books.Add(newBooke);

            dbContext.SaveChanges();

            return newBooke.Id;

        }

        public IEnumerable<BookDTO> GetAllBooks()
            => dbContext.Books.Select(b => new BookDTO
            {
                Id = b.Id,
                Created = b.Created,
                Title = b.Title
            }).ToList();
    }
}