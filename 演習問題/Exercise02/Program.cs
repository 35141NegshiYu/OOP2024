﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(names);
            Console.WriteLine();
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            do {
                //入力処理
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    Console.WriteLine(-1);
                    break;//空行だったら抜ける
                } else {
                    var index = names.FindIndex(x => x == line);
                    Console.WriteLine(index);
                }
              
           　}while(true);
        }

        private static void Exercise2_2(List<string> names) {
            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<string> names) {
            var array = names.Where(s => s.Contains("o")).ToArray();
            foreach(var item in array) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var selected = names.Where(s => s.StartsWith("B")).Select(s => new { s.Length,s });
            foreach(var obj in selected) {
                Console.WriteLine(obj.s + "," + obj.Length);
            }
        }
    }
}
