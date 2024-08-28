using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
                

            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }


        private static void Exercise1_1(string outfile) {
            var employee = new Employee{
                    Id = 22194,
                    Name = "ノーマン",
                    HireDate = new DateTime(2034, 3, 21)
            };
            var settings = new XmlWriterSettings {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };
            //シリアル化
            using (var writer = XmlWriter.Create(outfile, settings)) {
                var serializer = new XmlSerializer(typeof(Employee));
                serializer.Serialize(writer, employee);
            }

            //逆シリアル化
            using (var reader = XmlReader.Create("Employee.xml")) {
                var serializer = new XmlSerializer(typeof(Employee));
                employee = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(employee);

            }
        }

        private static void Exercise1_2(string outfile) {
            var emps = new Employee[] {
                new Employee {
                    Id = 22194,
                    Name = "ノーマン",
                    HireDate = new DateTime(2034, 3, 21)
                },
                new Employee {
                    Id = 49137,
                    Name = "エマ",
                    HireDate = new DateTime(2034, 8, 22)
                },
                new Employee {
                    Id = 81194,
                    Name = "レイ",
                    HireDate = new DateTime(2034, 1, 15)
                },
            };
            var settings = new XmlWriterSettings {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };
            //シリアル化
            using (var writer = XmlWriter.Create(outfile, settings)) {
                var serializer = new DataContractSerializer(emps.GetType());
                serializer.WriteObject(writer, emps);
            }

        }

        private static void Exercise1_3(string file) {
            //逆シリアル化
            using(XmlReader reader = XmlReader.Create(file)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var emps = serializer.ReadObject(reader)as Employee[];
                foreach(var emp in emps) {
                    Console.WriteLine("[Id = {0}, Name = {1}, HireData = {2}]",
                        emp.Id,emp.Name,emp.HireDate);
                }
            }
        }

        private static void Exercise1_4(string file) {
            
        }
    }
}
