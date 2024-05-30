using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        private static void Exercise3_1(string text) {
        int count = 0;
            foreach(char c in text) {
                if(c == ' ') {
                    count++;
                }
            }
            Console.WriteLine("空白数:"+count);
        }

        private static void Exercise3_2(string text) {
            text = text.Replace("big" ,"small");
            Console.WriteLine("置き換え後の文字列:" + text);
        }

        private static void Exercise3_3(string text) {
            var s = text.Split().Length;
            
            Console.WriteLine("単語数:" + s);
        }
    

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(s=>s.Length > 4);
            foreach(var word in words) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string word in words) {
                stringBuilder.Append(word);
                stringBuilder.Append(" "); // 単語の後に空白を追加
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
