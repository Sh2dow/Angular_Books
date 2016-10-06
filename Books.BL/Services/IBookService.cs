using Books.Models;
using System.Collections.Generic;

namespace Books
{
    internal interface IBookService
    {
        void AddBook(Book book);
        //void UpdateBook(Book book);
        void RemoveBook(Book book);
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
    }
}