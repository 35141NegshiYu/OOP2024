using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static private Dictionary<string,string> kentyo = new Dictionary<string, string>();
        static void Main(string[] args) {
            string Key, Value;
            /*var employeeDict = new Dictionary<int, Employee> {
               { 100, new Employee(100, "清水遼久") },
               { 112, new Employee(112, "芹沢洋和") },
               { 125, new Employee(125, "岩瀬奈央子") },
            };

            employeeDict.Add(126, new Employee(126, "床野遥香"));

            var name = employeeDict.Where(e => e.Value.Name.Contains("和"));

            foreach(var item in employeeDict.Values) {
                Console.WriteLine($"{item.Id} {item.Name}");
            }*/

            //入力処理
            Console.WriteLine("県庁所在地の登録");
            for (int i = 0; i < 5; i++) {
                //都道府県の入力
                Console.Write("都道府県:");
                Key = Console.ReadLine();

                if(Key ==null) {
                    break;
                }

                //県庁所在地の入力
                Console.Write("県庁所在地:");
                Value = Console.ReadLine();

                //既に登録されているか
                if (kentyo.ContainsKey(Key)) {
                    //登録済み
                    Console.WriteLine("上書きしますか(Yes/No)");
                    if (Console.ReadLine() == "No") {
                        continue;
                    }
                }
                //未登録
                kentyo[Key] = Value;
            }
            foreach (var ken in kentyo) {
                Console.WriteLine($"{ken.Key}の県庁所在地は{ken.Value}です。");
            }

            Boolean endFlag = false;

            while (!endFlag) {
                switch (menuDisp()) {
                    case "1":
                        AllDisp();
                        break;

                    case "2":
                        Search();
                        break;


                    case "9":
                        Console.WriteLine("終了");
                        endFlag = true;
                        break;
                }
            }
        }

        private static void Search() {
            Console.WriteLine("検索");
            Console.Write("都道府県:");
            String searchPref = Console.ReadLine();
            Console.WriteLine($"{searchPref}の県庁所在地は{kentyo[searchPref]}です。");
        }

        private static void AllDisp() {
            Console.WriteLine("一覧表示");
            foreach (var ken in kentyo) {
                Console.WriteLine($"{ken.Key}の県庁所在地は{ken.Value}です。");
            }
        }

        //メニュー表示
        private static string menuDisp() {
            Console.WriteLine("＊メニュー＊");
            Console.WriteLine("1:一覧表示");
            Console.WriteLine("2:検索");
            Console.WriteLine("9:終了");
            Console.Write(">");

            String menuSelect = Console.ReadLine();
            return menuSelect;
        }
    }

}