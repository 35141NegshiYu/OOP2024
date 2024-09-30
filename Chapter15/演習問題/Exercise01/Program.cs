
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var maxPrice = Library.Books.Max(b => b.Price);
            Console.WriteLine(maxPrice);
        }

        private static void Exercise1_3() {
            var counts = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(g => new {
                    year = g.Key,
                    count = g.Count()})
                .OrderBy(g => g.year);

            Console.WriteLine("書籍のカウント (発行年ごと):");
            foreach (var count in counts) {
                Console.WriteLine($"{count.year}年: {count.count} 冊");
            }
        }

        private static void Exercise1_4() {
            var sortedBooks = Library.Books
            .OrderByDescending(b => b.PublishedYear)  // 発行年で降順にソート
            .ThenByDescending(b => b.Price)              // 価格で降順にソート
            .ToList();

            Console.WriteLine("書籍のリスト (発行年、価格の順):");
            foreach (var book in sortedBooks) {
                Console.WriteLine($"Title: {book.Title},Price: {book.Price:C}, Year: {book.PublishedYear}");
            }
        }

        private static void Exercise1_5() {
        }

        private static void Exercise1_6() {
        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}
