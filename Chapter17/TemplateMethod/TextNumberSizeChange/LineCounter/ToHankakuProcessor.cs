using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using TextNumberSizeChange.Framework;

namespace TextNumberSizeChange {
    class ToHankakuProcessor : ITextFileService {
        private int _count;
        string _text = "";

        public void Execute(string line) {
            _count = 0;
        }

        public void Initialize(string fname) {
            _count++;
        }

        public void Terminate() {
            Console.WriteLine("{0} 行", _count);
        }


        /*protected override void Initialize(string fname) {
            _count = 0;
        }

        protected override void Execute(string line) {
            var output = new string(line.Select(c => (c >= '０') && (c <= '９') ? (char)(c - '０' + '0') : c).ToArray());
            Console.WriteLine(output);
        }

        protected override void Terminate() {
            Console.WriteLine("{0}行", _count);
            Console.WriteLine(_text);
        }*/

    }
}