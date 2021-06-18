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
            return Repository.GetAll<Author>()
                             .Where(x => x.Books.Count() > 0)
                             .OrderByDescending(x => x.Books.Count())
                             .ThenBy(x => x.Created)
                             .FirstOrDefault();
        }
    }
}
