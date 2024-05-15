using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canaderra",
                "Hong kong",
            };
            
            var query  = names.Where(s => s.Length <= 5);
            foreach (var item in query) {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------");
            names[0] = "Osaka";
            foreach (var item in query) {
                Console.WriteLine(item);
            }
        
        }









            //int count = numbers.Count(n => n%2 == 0);

            /*double num = numbers.Where(n => n > 5).Average();
            int total = numbers.Where(n => n > 5).Sum();
            Console.WriteLine(num);
            Console.WriteLine(total);
            */


        


    }
}
