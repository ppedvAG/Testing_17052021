using System.Collections.Generic;

namespace ppedv.TestingBooks.Model
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    }
}
