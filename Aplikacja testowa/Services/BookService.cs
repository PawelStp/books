using Aplikacja_testowa.Abstracts;
using Aplikacja_testowa.DTOs;
using System.Collections.Generic;

namespace Aplikacja_testowa.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public int Create(BookDTO newBook)
        {
            if(newBook.Title == string.Empty)
            {
                return -1;
            }

            return bookRepository.Create(newBook.Title);
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }
    }
}