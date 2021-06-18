using ppedv.TestingBooks.Logic;
using ppedv.TestingBooks.Model;
using System;
using System.Linq;

namespace ppedv.TestingBooks.UI.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // ? => €

            Console.WriteLine("*** Testing Books v0.1 ***");

            Core core = new Core(new Data.EFCore.EfRepository());

            foreach (var b in core.Repository.GetAll<Book>())
            {
                Console.WriteLine($"{b.Title} {b.Price:c}");
                Console.WriteLine($"\t{string.Join(", ", b.Authors.Select(x => x.Name))}");
            }

            Console.WriteLine("Fleißigster Autor: " + core.GetAuthorWithTheMostBooks().Name);

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
