using Books.Models;
using Books.DL;
using System.Collections.Generic;
using System;

namespace Books.BL
{
    public class BookService : IBookService
    {
        private BooksRepository repo;

        public BookService()
        {
            repo = new BooksRepository();
        }

        public void AddBook(Book book)
        {
            repo.AddBook(book);
            repo.Save();
        }

        public void UpdateBook(Book book)
        {
            repo.UpdateBook(book);
            repo.Save();
        }

        public void RemoveBook(Book book)
        {
            repo.RemoveBook(book);
            repo.Save();
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = repo.GetBooks();
            return books;
        }

        public Book GetBook(int id)
        {
            return repo.GetBook(id);
        }

        public void Dispose()
        {
            repo.Dispose();
        }
    }
}
