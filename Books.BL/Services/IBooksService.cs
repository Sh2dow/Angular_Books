using Books.Models;
using System;
using System.Collections.Generic;

namespace Books
{
    public interface IBooksService : IDisposable
    {
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        //void UpdateBook(Book book);
        void RemoveBook(Book book);
        IEnumerable<Book> GetBooks();
    }
}