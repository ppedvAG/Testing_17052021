using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.TestingBooks.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void GetAuthorWithTheMostBooks_no_book_and_no_authors_result_null()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetAuthorWithTheMostBooks_no_authors_result_null()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetAuthorWithTheMostBooks_all_authors_with_no_books_result_null()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetAuthorWithTheMostBooks_2_authors_second_one_has_more_book__eigenes_TestRepo()
        {
            var core = new Core(new TestRepo());

            var result = core.GetAuthorWithTheMostBooks();

            Assert.AreEqual("A2", result.Name);
        }
    }
}
