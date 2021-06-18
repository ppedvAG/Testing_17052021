using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.TestingBooks.Model;
using System;

namespace ppedv.TestingBooks.Data.EFCore.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void Can_create_DB()
        {
            using (var con = new EfContext())
            {
                con.Database.EnsureDeleted();

                Assert.IsTrue(con.Database.EnsureCreated());
            }
        }

        [TestMethod]
        public void Can_CRUD_book()
        {
            var b = new Book
            {
                Title = $"Book_{Guid.NewGuid()}",
                Price = 5.55m
            };
            var newTitle = $"NewTitle_{Guid.NewGuid()}";

            //CREATE
            using (var con = new EfContext())
            {
                con.Books.Add(b);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check CREATE
                var loaded = con.Books.Find(b.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(b.Title, loaded.Title);
                Assert.AreEqual(b.Price, loaded.Price);

                //UPDATE
                loaded.Title = newTitle;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check UPDATE
                var loaded = con.Books.Find(b.Id);
                Assert.AreEqual(newTitle, loaded.Title);

                //DELETE
                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check DELETE
                var loaded = con.Books.Find(b.Id);
                Assert.IsNull(loaded);
            }
        }
    }
}
