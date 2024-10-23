using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace TextNumberSizeChange {
    internal class Program {
        static void Main(string[] args) {
            //TextProcessor.Run<ToHankakuProcessor>(args[0]);
            var processor = new Framework.TextFileProcessor(new ToHankakuProcessor());
            processor.Run(args[0]);

        }
    }
}
