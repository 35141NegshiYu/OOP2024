using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            /*var pages = Books.GetBooks().Max(x => x.Pages);
            var bookTitle = Books.GetBooks().FirstOrDefault(b => b.Pages == pages);

            Console.WriteLine(bookTitle.Title);

            var title = Books.GetBooks().Max(x=>x.Title);
            Console.WriteLine(title);
            */

            var books = Books.GetBooks().OrderByDescending(x => x.Price).ToList();

            //books.ForEach(b=>Console.WriteLine(b.Title + ":" + b.Price));

            foreach (var book in books) {
                Console.WriteLine(book.Title + ":" + book.Price);
            }
            

        }
    }
}
