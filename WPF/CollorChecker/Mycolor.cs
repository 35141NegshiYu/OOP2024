using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace CollorChecker {
    public struct MyColor {
        public string colorName;

        public Color Color { get; set; }
        public string Name { get; set; }

        public override string ToString() {
             return Name ?? string.Format("R:{0,3} G:{1,3} B:{2,3}", Color.R, Color.G, Color.B);
        }
        public override bool Equals(object obj) {
            return obj is MyColor other && Color.Equals(other.Color);
        }

        public override int GetHashCode() {
            return Color.GetHashCode();
        }
    }
}
