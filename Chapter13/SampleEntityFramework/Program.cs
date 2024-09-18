using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    internal class Program {
        static void Main(string[] args) {
            //AddAuthors();
            //AddBooks();
            //InsertBooks();
            //DisplayAllBooks2();
            //UpdateBook(new DateTime(1899, 8, 27));
            DisplayAllBooks3();
            /*foreach (var book in GetBooks()) {
                Console.WriteLine(book.Title);
            }*/

            Console.WriteLine();
            Console.WriteLine("#1.4");
            Exercise1_4();


            Console.WriteLine();
            Console.WriteLine("#1.5");
            Exercise1_5();

            Console.ReadLine(); //コンソールアプリだがF5でデバッグ実行したいために記述
        }

       

        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);

                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                
                db.SaveChanges();   //データベースを更新
            }
        }

        //データの変更
        private static void UpdateBook(DateTime newBirthday) {
            using (var db = new BooksDbContext()) {
                var author = db.Authors.SingleOrDefault(a => a.Name == "宮沢賢治");
                if (author != null) {
                    author.Birthday = newBirthday; // 新しい誕生日を設定
                    db.SaveChanges(); // 変更をデータベースに保存
                    Console.WriteLine($"宮沢賢治の誕生日を {newBirthday:yyyy/MM/dd} に変更しました。");
                } else {
                    Console.WriteLine("宮沢賢治が見つかりませんでした。");
                }
            }
        }
        //データの削除
        private static void DeleteBook() {
            using(var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if(book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }
        /*private static void DeleteAuthor() {
            using (var db = new BooksDbContext()) {
                var author = db.Books.Remove(x => );
                if (author != null) {
                    db.Books.Remove(author);
                    db.SaveChanges();
                }
            }
        }*/

        //著者の追加
        private static void AddAuthors() { 
            using(var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛",
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成"
                };
                db.Authors.Add(author2);
                var author3 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "宮沢賢治"
                };
                db.Authors.Add(author3);
                var author4 = new Author {
                    Birthday = new DateTime(1896, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子"
                };
                db.Authors.Add(author4);

                db.SaveChanges();
            }
        }
        private static void AddBooks() {
            using(var db = new BooksDbContext()) {
                //Authorから該当するデータを取得する
                /*var author1 = db.Authors.Single(a => a.Name == "夏目漱石");
                var book1 = new Book {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = author1,
                };
                db.Books.Add(book1);
                //Authorから該当するデータを取得する
                var author2 = db.Authors.Single(a => a.Name == "川端康成");
                var book2 = new Book {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author2,
                };
                db.Books.Add(book2);

                var author3 = db.Authors.Single(a => a.Name == "菊池寛");
                var book3 = new Book {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = author3,
                };
                db.Books.Add(book3);

                var author4 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book4 = new Book {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = author4,
                };
                db.Books.Add(book4);*/
                var author5 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book5 = new Book {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author5,
                };
                db.Books.Add(book5);
                var author6 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book6 = new Book {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1989,
                    Author = author6,
                };
                db.Books.Add(book6);

                db.SaveChanges();
            }
        }
        //テーブルの全表示
        /*static void DisplayAllBooks() {
            var books = GetBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title} {book.PublishedYear}");
            }
            Console.WriteLine();
        }*/
        //13.1.2
        static void DisplayAllBooks2() { 
            using(var db = new BooksDbContext()) {
                foreach(var book in db.Books.ToList()) {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                        book.Title,book.PublishedYear,
                        book.Author.Name,book.Author.Birthday
                        );
                }
            }
        }
        //13.1.3
        static void DisplayAllBooks3() {
            using (var db = new BooksDbContext()) {
                var maxLength = db.Books.Max(book => book.Title.Length); // 最長の長さを取得

                var longestBooks = db.Books.Where(book => book.Title.Length == maxLength).ToList();// 最長のタイトルの書籍を取得

                if (longestBooks.Any()) {
                    Console.WriteLine("最も長い書籍:");
                    foreach (var book in longestBooks) {
                        Console.WriteLine($"タイトル: {book.Title},出版年: {book.PublishedYear}, 著者: {book.Author.Name}");
                    }
                }
            }
        }
        //13.1.4
        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var oldestBooks = db.Books.OrderBy(book => book.PublishedYear) // 発行年で昇順に並べ替え
                    .Take(3) // 最初の3冊を取得
                    .ToList();

                if (oldestBooks.Any()) {
                    Console.WriteLine("発行年の古い順に3冊の書籍:");
                    foreach (var book in oldestBooks) {
                        Console.WriteLine($"タイトル: {book.Title}, 著者: {book.Author.Name}");
                    }
                } else {
                    Console.WriteLine("書籍が見つかりませんでした。");
                }
            }
        }

        //13.1.5
        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authorsWithBooks = db.Authors.OrderByDescending(author => author.Birthday).Select(author => new {   // 誕生日の遅い順に並べる
                    AuthorName = author.Name,
                        Books = author.Books.Select(book => new {
                            book.Title,
                            book.PublishedYear
                        }).ToList()
                    }).ToList();

                if (authorsWithBooks.Any()) {
                    foreach (var author in authorsWithBooks) {
                        Console.WriteLine($"著者: {author.AuthorName}");
                        foreach (var book in author.Books) {
                            Console.WriteLine($"  タイトル: {book.Title}, 発行年: {book.PublishedYear}");
                        }
                        Console.WriteLine(); // 各著者の後に空行を追加
                    }
                } else {
                    Console.WriteLine("著者または書籍が見つかりませんでした。");
                }
            }
        }

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                    //.Where(book => book.Author.Name.StartsWith("夏目"))
                    .ToList();
            }
        }
    }

}
