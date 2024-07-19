using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                             .Select(x => new {
                                 Name = x.Element("name").Value,
                                 Teammembers = x.Element("teammembers").Value
                             });
            foreach (var sport in sports) {
                Console.WriteLine("{0} {1}", sport.Name, sport.Teammembers);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                            .Select(x => new {
                                Name = x.Element("name").Attribute("kanji").Value,
                                Firstplayed = x.Element("firstplayed").Value,
                            }).OrderBy(x=>x.Firstplayed);

            foreach (var sport in sports) {
                Console.WriteLine("{0}({1})", sport.Name, sport.Firstplayed);
            }

        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load("sample.xml");
            var sports = xdoc.Root.Elements().OrderByDescending(x => x.Element("teammembers").Value).First();

            Console.WriteLine($"{sports.Element("name").Value}");
        }

        private static void Exercise1_4(string file, string newfile) {
            var element = new XElement("ballsport",
                new XElement("name", "サッカー", new XAttribute("kanji","蹴球")),
                new XElement("teammembers", "11"),
                new XElement("firstplayed","1863")
              );
            var xdoc = XDocument.Load(file);
            xdoc.Root.Add(element);


            
            //保存
            xdoc.Save(newfile);

        }
    }
}
