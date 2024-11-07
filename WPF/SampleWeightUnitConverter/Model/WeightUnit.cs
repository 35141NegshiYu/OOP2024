using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SampleWeightUnitConverter {
    public class WeightUnit {
        public string Name { get; set; }
        public int Coefficient { get; set; }
        public override string ToString() {
            return this.Name;
        }

    }
}
