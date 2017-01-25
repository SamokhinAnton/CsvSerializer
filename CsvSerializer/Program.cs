using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book
            {
                Author = "Robert Anthony Salvatore",
                Created = DateTime.Now,
                Price = 15.5m,
                Title = "Homeland",
                Year = 1990
            };
            var book2 = new Book
            {
                Author = "Robert Anthony Salvatore",
                Created = DateTime.Now.AddDays(-10),
                Price = 17.5m,
                Title = "Sojourn",
                Year = 1991
            };
            var list = new List<Book>();
            list.Add(book);
            list.Add(book2);

            var str = CsvSerializer.Serialize(book);
            var obj = CsvSerializer.Deserialize<Book>(str);

            var str2 = CsvSerializer.SerializeEnum(list);
            Console.WriteLine(str2);
            var obj2 = CsvSerializer.DeserializeIEnum<Book>(str2);
        }
    }
}
