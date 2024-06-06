using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Book {
        public string Title { get; private set; }
        public int Price { get; private set; }
        public int Pages { get; private set; }

        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);
        }

        private static void Exercise2_1(List<Book> books) {
            var result = books.Where(n => n.Title == "ワンダフル・C#ライフ");
            foreach (var book in result)
                Console.WriteLine("{0}:{1}円{2}ページ ", book.Title, book.Price, book.Pages);

        }

        private static void Exercise2_2(List<Book> books) {
            int count = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<Book> books) {
            var average = books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages);
            Console.WriteLine(average);
        }

        private static void Exercise2_4(List<Book> books) {
            var book = books.FirstOrDefault(b => b.Price >= 4000);
            if (book != null)
                Console.WriteLine(book.Title);
        }

        private static void Exercise2_5(List<Book> books) {
            var pages = books.Where(b => b.Price < 4000).Max(b => b.Pages);
            Console.WriteLine(pages);
        }

        private static void Exercise2_6(List<Book> books) {
            var pages = books.Where(p => p.Pages > 400).OrderByDescending(b => b.Price);
            foreach (var book in pages) {
                Console.WriteLine("{0}:{1}円", book.Title, book.Price);
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var selected = books.Where(b => b.Title.Contains("C#") && b.Pages <= 500);
            foreach (var book in selected) {
                Console.WriteLine(book.Title);
                
            }
        }
    }
}
