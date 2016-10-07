using Books.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Books.DL
{
    public class BooksRepository : IDisposable
    {
        private BooksContext _bookContext;

        public BooksRepository()
        {
            _bookContext = new BooksContext();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookContext.Books.AsEnumerable();
        }

        public Book GetBook(int id)
        {
            return _bookContext.Books.FirstOrDefault(book => book.Id == id);
        }

        public Book AddBook(Book book)
        {
            if (book != null)
            {
                return _bookContext.Books.Add(book);
            }
            else
                return null;
        }

        public void UpdateBook(Book book)
        {
            _bookContext.Books.Attach(book);
            _bookContext.Entry(book).State = EntityState.Modified;
        }

        public void RemoveBook(Book book)
        {
            if (book != null)
            {
                _bookContext.Books.Remove(book);
            }
        }
        
        public void Save()
        {
            _bookContext.SaveChanges();
        }

        public void Dispose()
        {
            _bookContext.Dispose();
        }
    }
}
