using Books.Models;
using Books.DL;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;

namespace Books.BL
{
    public class BooksService : IBooksService
    {
        private BooksRepository _booksRepository;

        public BooksService()
        {
            _booksRepository = new BooksRepository();
        }

        public Book AddBook(Book book)
        {
            _booksRepository.AddBook(book);
            _booksRepository.Save();
            return book;
        }

        public Book UpdateBook(Book book)
        {
            _booksRepository.UpdateBook(book);
            _booksRepository.Save();
            return book;
        }

        public void RemoveBook(Book book)
        {
            _booksRepository.RemoveBook(book);
            _booksRepository.Save();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _booksRepository.GetBooks().AsEnumerable();
        }

        public Book GetBook(int id)
        {
            return _booksRepository.GetBook(id);
        }

        public void Dispose()
        {
            _booksRepository.Dispose();
        }
    }
}
