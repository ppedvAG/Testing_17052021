using ppedv.TestingBooks.Model;
using ppedv.TestingBooks.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TestingBooks.Data.EFCore
{
    public class EfRepository : IRepository
    {
        EfContext con = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T) == typeof(Book))
            //    con.Books.Add(entity as Book);
            //...

            con.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            con.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return con.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return con.Set<T>().Find(id);
        }

        public int SaveAll()
        {
            return con.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            con.Set<T>().Update(entity);
        }
    }
}
