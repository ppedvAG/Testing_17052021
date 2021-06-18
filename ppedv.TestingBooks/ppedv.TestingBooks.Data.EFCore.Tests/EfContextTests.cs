using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.TestingBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        [TestMethod]
        public void Can_CRUD_book_FluentAssertions()
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
                loaded.Should().NotBeNull();
                loaded.Title.Should().Be(b.Title);
                loaded.Price.Should().Be(b.Price);

                //UPDATE
                loaded.Title = newTitle;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check UPDATE
                var loaded = con.Books.Find(b.Id);
                loaded.Title.Should().Be(newTitle);

                //DELETE
                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check DELETE
                var loaded = con.Books.Find(b.Id);
                loaded.Should().BeNull();
            }
        }


        [TestMethod]
        public void Can_create_and_read_book_created_by_AutoFixture_and_tested_with_FluentAssertions()
        {
            var fix = new Fixture();

            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));

            var b = fix.Create<Book>();

            using (var con = new EfContext())
            {
                con.Books.Add(b);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Books.Find(b.Id);

                loaded.Should().BeEquivalentTo(b, c => c.IgnoringCyclicReferences());
            }

        }

        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }
    }
}
