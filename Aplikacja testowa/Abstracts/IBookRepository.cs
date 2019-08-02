using Aplikacja_testowa.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace Aplikacja_testowa.Abstracts
{
    public interface IBookRepository
    {
        IEnumerable<BookDTO> GetAllBooks();

        int Create(string title);
    }
}