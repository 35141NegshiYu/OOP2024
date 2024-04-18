using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class FeetConverter {
        //private const double retio = 0.3048;//定数
        public static readonly double retio = 0.3048;  //定数（外部にも公開する場合）

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / retio;
        }
        //フィートからメートルを求める
        public static double ToMeter(double feet) {
            return feet * retio;
        }
    }
}
