using Aplikacja_testowa.DTOs;
using System.Collections.Generic;

namespace Aplikacja_testowa.Abstracts
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks();
        int Create(BookDTO newBook);
    }
}