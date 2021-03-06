using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl_solution.Database
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Published { get; set; }

        public string Genre { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
