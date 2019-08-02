using Aplikacja_testowa.Abstracts;
using Aplikacja_testowa.DTOs;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Aplikacja_testowa.API
{
    public class BookController : ApiController
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(bookService.GetAllBooks());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] BookDTO newBook)
        {
            var id = bookService.Create(newBook);
            if (id > 0)
                return Created(new Uri(Request.RequestUri.AbsoluteUri), id);
            else
                return BadRequest();
        }
    }
}
