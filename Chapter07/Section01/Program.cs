using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
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
            var kentyo = new Dictionary<string, string>();
            //入力処理
            Console.WriteLine("県庁所在地の登録");
            for (int i = 0; i < 5; i++) {
                Console.Write("都道府県:");
                string Key = Console.ReadLine();
                Console.Write("県庁所在地:");
                string Value = Console.ReadLine();

                kentyo[Key] = Value;
            }
            foreach (var ken in kentyo) {
                Console.WriteLine($"{ken.Key}の県庁所在地は{ken.Value}です。");
            }


        }
    }
}
