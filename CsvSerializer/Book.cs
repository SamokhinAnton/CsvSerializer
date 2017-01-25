using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvSerializer
{
    class Book
    {
        [CsvOrder(2)]
        public string Author { get; set; }
        [NoCsv]
        public int Year { get; set; }

        public DateTime Created { get; set; }
        [CsvOrder(1)]
        public string Title { get; set; }
        [CsvOrder(3)]
        public decimal Price { get; set; }
    }
}
