using System.Web.Http;
using Books.BL;
using Books.DL;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Books.Models;

namespace Books.Controllers
{
    public class BooksController : ApiController
    {
        private BookContext db = new BookContext();

        // GET: api/Books

        private BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        public IHttpActionResult Get()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
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