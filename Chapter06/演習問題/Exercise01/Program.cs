using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            var num = numbers.Max();
            Console.WriteLine(num);
        }

        private static void Exercise1_2(int[] numbers) {
            /*var lastTwoElements = numbers.Skip(Math.Max(0, numbers.Count() - 2));
            // 結果を出力
            foreach (var number in lastTwoElements) {
                Console.WriteLine("最後から二つの要素: " + number);
            }*/
            var skip = numbers.Length - 2;

            foreach (var number in numbers.Skip(skip)) {
                Console.WriteLine(number);
            }
        }

        private static void Exercise1_3(int[] numbers) {
            var strings = numbers.Select(n => n.ToString());
            foreach(var numString in strings) {
                Console.WriteLine(numString);
            }
            
        }

        private static void Exercise1_4(int[] numbers) {
            foreach(var number in numbers.OrderBy(n => n).Take(3)) {
                Console.WriteLine(number);
            }
        
        }

        private static void Exercise1_5(int[] numbers) {
            var count = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine(count);
        
        }
    }
}
