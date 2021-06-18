using Microsoft.EntityFrameworkCore;
using ppedv.TestingBooks.Model;
using System;

namespace ppedv.TestingBooks.Data.EFCore
{
    public class EfContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestingBooks;Trusted_Connection=true;")
                .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
