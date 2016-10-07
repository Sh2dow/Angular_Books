using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Books.Controllers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Data.Entity;
using Books;
using Books.Models;
using Books.DL;
using Books.BL;
using Books.Web;
using System.Diagnostics;

namespace Books.UnitTests
{
    [TestClass]
    public class TestBooksController
    {
        [TestInitialize]
        public void TestInitialize()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Books.Web\App_Data"));
            var p = AppDomain.CurrentDomain.GetData("DataDirectory");
            Debug.WriteLine(p);
            // rest of initialize implementation ...
        }

        [TestMethod]
        public void GetShouldReturnAllBooks()
        {
            var controller = new BooksController();
            var actionResult = controller.Get();
            var response = actionResult as OkNegotiatedContentResult<IEnumerable<Book>>;
            Assert.IsNotNull(response);
            var books = response.Content;
            Assert.AreEqual(1, books);
        }

        [TestMethod]
        public void GetWithIdItShouldReturnThatBook()
        {
            var controller = new BooksController();
            var actionResult = controller.Get(1);
            var response = actionResult as OkNegotiatedContentResult<Book>;
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Content.Id);
        }

        [TestMethod]
        public void PutShouldUpdateBook()
        {
            var controller = new BooksController();
            var book = new Book { Id = 1, Title = "asp.net webapi2", Author = "Jane Austen" };
            var actionResult = controller.Put(book.Id, book);
            var response = actionResult as OkNegotiatedContentResult<Book>;
            Assert.IsNotNull(response);
            var newBook = response.Content;
            Assert.AreEqual(1, newBook.Id);
            Assert.AreEqual("asp.net webapi2", newBook.Title);
            Assert.AreEqual("Jane Austen", newBook.Author);
        }

        [TestMethod]
        public void PostShouldAddBook()
        {
            var controller = new BooksController();
            var actionResult = controller.Post(new Book
            {
                Title = "asp.net webapi2",
                Author = "Jane Austen"
            });
            var response = actionResult as CreatedAtRouteNegotiatedContentResult<Book>;
            Assert.IsNotNull(response);
            Assert.AreEqual("DefaultApi", response.RouteName);
            Assert.AreEqual(response.Content.Id, response.RouteValues["Id"]);
        }

        public List<Book> GetTestBooks()
        {
            var testBooks = new List<Book>();
            testBooks.Add(new Book
            {
                Id = 1,
                Title = "Pride and Prejudice",
                Year = 1813,
                Author = "Jane Austen",
                Price = 9.99M,
                Genre = "Commedy of manners"
            });
            testBooks.Add(new Book
            {
                Id = 2,
                Title = "Northanger Abbey",
                Year = 1817,
                Author = "Jane Austen",
                Price = 12.95M,
                Genre = "Gothic parody"
            });
            testBooks.Add(new Book
            {
                Id = 3,
                Title = "David Copperfield",
                Year = 1850,
                Author = "Charles Dickens",
                Price = 15,
            });
            testBooks.Add(new Book
            {
                Id = 4,
                Title = "Don Quixote",
                Year = 1617,
                Author = "Miguel de Cervantes",
                Price = 8.95M,
                Genre = "Picaresque"
            });
            return testBooks;
        }

    }
}