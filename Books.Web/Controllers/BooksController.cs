using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Books.BL;
using Books.DL;
using Books.Models;
using System.Collections.Generic;
using System.Linq;

namespace Books.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/Books

        private BooksService _bookService;

        public BooksController()
        {
            _bookService = new BooksService();
        }

        // GET api/books
        public IHttpActionResult Get()
        {
            return  Ok(_bookService.GetBooks().AsEnumerable());
        }

        // GET api/books/1
        public IHttpActionResult Get(int id)
        {
            var book = _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT api/books/1
        public IHttpActionResult Put(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_bookService.UpdateBook(book));
        }

        // POST api/books
        public IHttpActionResult Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book newBook = _bookService.AddBook(book);
            return CreatedAtRoute("DefaultApi", new { newBook.Id }, newBook);
        }

    }
}