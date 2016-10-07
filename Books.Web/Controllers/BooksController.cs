using System.Web.Http;
using Books.BL;
using Books.DL;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Books.Models;
using System.Collections.Generic;

namespace Books.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/Books

        private BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await Task.FromResult(_bookService.GetBooks()));
        }

        public async Task<IHttpActionResult> GetBook(int id)
        {
            return Ok(await Task.FromResult(_bookService.GetBook(id)));
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookService.AddBook(book);
            return Ok(book);
        }
    }
}