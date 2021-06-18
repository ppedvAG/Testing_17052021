using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.TestingBooks.Model;
using ppedv.TestingBooks.Model.Contracts;
using System;
using System.Collections.Generic;

namespace ppedv.TestingBooks.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void GetAuthorWithTheMostBooks_no_book_and_no_authors_result_null()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Author>()).Returns(() => new List<Author>());

            var core = new Core(mock.Object);

            var result = core.GetAuthorWithTheMostBooks();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAuthorWithTheMostBooks_all_authors_with_no_books_result_null()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Author>())
                .Returns(() =>
                {
                    var a1 = new Author() { Name = "A1" };
                    var a2 = new Author() { Name = "A2" };

                    return new[] { a1, a2 };
                });

            var core = new Core(mock.Object);

            var result = core.GetAuthorWithTheMostBooks();

            Assert.IsNull(result);

        }

        [TestMethod]
        public void GetAuthorWithTheMostBooks_2_authors_second_one_has_more_book__eigenes_TestRepo()
        {
            var core = new Core(new TestRepo());

            var result = core.GetAuthorWithTheMostBooks();

            Assert.AreEqual("A2", result.Name);
        }

        [TestMethod]
        public void GetAuthorWithTheMostBooks_2_authors_second_one_has_more_book__moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Author>())
                .Returns(() =>
                {
                    var a1 = new Author() { Name = "A1" };
                    var a2 = new Author() { Name = "A2" };
                    a1.Books.Add(new Book());
                    a1.Books.Add(new Book());

                    a2.Books.Add(new Book());
                    a2.Books.Add(new Book());
                    a2.Books.Add(new Book());

                    return new[] { a1, a2 };
                });

            var core = new Core(mock.Object);

            var result = core.GetAuthorWithTheMostBooks();

            Assert.AreEqual("A2", result.Name);
        }

        [TestMethod]
        public void GetAuthorWithTheMostBooks_2_authors_same_book_count_then_take_the_author_that_was_created_first()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Author>())
                .Returns(() =>
                {
                    var a1 = new Author() { Name = "A1", Created = DateTime.Now };
                    var a2 = new Author() { Name = "A2", Created = DateTime.Now.AddMinutes(-1) };
                    a1.Books.Add(new Book());
                    a1.Books.Add(new Book());

                    a2.Books.Add(new Book());
                    a2.Books.Add(new Book());

                    return new[] { a1, a2 };
                });

            //mock.Setup(x => x.GetAll<Author>()).Throws(new InvalidOperationException());

            var core = new Core(mock.Object);

            var result = core.GetAuthorWithTheMostBooks();

            Assert.AreEqual("A2", result.Name);

            mock.Verify(x => x.GetAll<Author>(),Times.Once);

        }
    }
}
