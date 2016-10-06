using Books.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Books.DL
{
    public class BooksRepository
    {
        private BookContext ctx;

        public BooksRepository()
        {
            ctx = new BookContext();
        }

        public void AddBook(Book book)
        {
            if (book != null)
            {
                ctx.Books.Add(book);
            }
        }

        public void UpdateBook(Book book)
        {
            ctx.Books.Attach(book);
            ctx.Entry(book).State = EntityState.Modified;
        }

        public void RemoveBook(Book book)
        {
            if (book != null)
            {
                ctx.Books.Remove(book);
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            return ctx.Books;
        }

        public Book GetBook(int id)
        {
            return ctx.Books.FirstOrDefault(book => book.Id == id);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }
    }
}
