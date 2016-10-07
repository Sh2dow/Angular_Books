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
using System.Linq;

namespace Books.UnitTests
{
    [TestClass]
    public class TestBooksController
    {
        [TestInitialize]
        public void TestInitialize()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "../../../../Books.Web/App_Data"));
        }

        [TestMethod]
        public void GetShouldReturnAllBooks()
        {
             // Arrange
            var controller = new BooksController();
            // Act
            var actionResult = controller.Get();
            // Assert
            var response = actionResult as OkNegotiatedContentResult<IEnumerable<Book>>;
            Assert.IsNotNull(response);
            var books = response.Content;
            Assert.AreEqual(4, books.Count());
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
        public void PostShouldAddBook()
        {
            var controller = new BooksController();
            var actionResult = controller.Post(new Book
            {
                Title = "C# 5.0 in a Nutshell",
                Author = "Joseph Albahari"
            });
            var response = actionResult as CreatedAtRouteNegotiatedContentResult<Book>;
            Assert.IsNotNull(response);
            Assert.AreEqual("DefaultApi", response.RouteName);
            Assert.AreEqual(response.Content.Id, response.RouteValues["Id"]);
        }

        [TestMethod]
        public void PutShouldUpdateBook()
        {
            var controller = new BooksController();
            var book = new Book { Id = 5, Title = "CLR via C#", Author = "Jeffrey Richter" };
            var actionResult = controller.Put(book.Id, book);
            var response = actionResult as OkNegotiatedContentResult<Book>;
            Assert.IsNotNull(response);
            var newBook = response.Content;
            Assert.AreEqual(5, newBook.Id);
            Assert.AreEqual("CLR via C#", newBook.Title);
            Assert.AreEqual("Jeffrey Richter", newBook.Author);
        }
    }
}