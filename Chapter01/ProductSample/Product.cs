using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp{
    //商品コード
    public class Product {
        //商品コード
        public int code { get; set; }
        //商品名
        public String Name { get; set; }
        //商品化価格（税抜き）
        public int Price { get; set; }

        

        //コンストラクタ
        public Product(int code, string name, int price) {
            this.code = code;
            this.Name = name;
            this.Price = price;

        }


        //消費税額を求める（消費税率は10％）
        public int GetTax() {
            return (int)(Price * 0.1);


            
        }
        //税込み価格を求める
        public int GetPriceIncludingTax() {
            return Price + GetTax();


           
        }
    }
}
