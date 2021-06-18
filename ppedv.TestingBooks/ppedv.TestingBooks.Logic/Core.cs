using ppedv.TestingBooks.Model;
using ppedv.TestingBooks.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.TestingBooks.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public Author GetAuthorWithTheMostBooks()
        {
            return Repository.GetAll<Author>().OrderBy(x => x.Books.Count()).FirstOrDefault();
        }
    }
}
