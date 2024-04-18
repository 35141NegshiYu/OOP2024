
using SampleApp;
using System;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(223, "大福", 250);
            Product dorayaki = new Product(98, "どら焼き", 210);

            int price = karinto.Price;
            int taxIncluded = karinto.GetPriceIncludingTax();

            int daifukuPrice = daifuku.Price;
            int daifukuTaxIncluded = daifuku.GetPriceIncludingTax();

            int dorayakiTax = dorayaki.GetTax();

            Console.WriteLine(karinto.Name + "の税込金額" + taxIncluded + "円【税抜き" + price + "円】");

            Console.WriteLine($"{dorayakiTax}円");

            //ブロック選択: alt + sift
            //コピペ履歴：ctrl + sift + v
        }

    }
}
