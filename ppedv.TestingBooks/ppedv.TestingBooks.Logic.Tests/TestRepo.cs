using ppedv.TestingBooks.Model;
using ppedv.TestingBooks.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.TestingBooks.Logic.Tests
{
    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Author))
            {
                var a1 = new Author() { Name = "A1" };
                var a2 = new Author() { Name = "A2" };
                a1.Books.Add(new Book());
                a1.Books.Add(new Book());

                a2.Books.Add(new Book());
                a2.Books.Add(new Book());
                a2.Books.Add(new Book());

                return new[] { a1, a2 }.Cast<T>();
            }

            throw new System.NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }

        public int SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new System.NotImplementedException();
        }
    }
}
