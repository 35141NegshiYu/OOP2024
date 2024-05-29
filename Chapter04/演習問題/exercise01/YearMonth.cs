using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise01 {
    public class YearMonth {
        //4.1.1
        public int Year{get; private set;}
        public int Month { get; private set;}

        //コンストラクタ
        public YearMonth(int Year, int Month) {
            Year = Year;
            Month = Month;
        }


        //4.1.2
        public bool Is21Century {
            get {
                return 2001 <= Year && Year <= 2100;
            }
        }
        //4.1.3
        public YearMonth AddOneMonth() {
            if (Month > 12) {
                return new YearMonth(Year + 1, 1);
            }
            else
            {
                return new YearMonth(Year, Month + 1);
                
            }

        }

        public override string ToString() {
            return $"{Year}年{Month}月";
        }
    }
}
