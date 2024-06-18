using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    internal class InchConverter {
        public static readonly double ratio = 0.0254;    //定数(外部にも公開する場合)

        //メートルからインチを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }
        //インチからメートルを求める
        public static double ToMeter(double inch) {
            return inch * ratio;
        }
    }
}
