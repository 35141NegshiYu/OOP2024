using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Song {
        //歌のタイトル
        public String title {  get; set; }
        //アーティスト名
        public String ArtistName { get; set; }
        //演奏時間、単位は秒
        public int Length { get; set; }

        //コンストラクタ
        public Song(String title, String ArtistName, int Length) {
            this.title = title;
            this.ArtistName = ArtistName;
            this.Length = Length;
        }

    }
}
