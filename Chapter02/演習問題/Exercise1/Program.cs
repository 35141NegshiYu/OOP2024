using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {
            var songs = new Song[] {
                new Song("Soranji", "Mrs", 50),
                new Song("ナハトムジーク", "GREEN", 100),
                new Song("ライラック", "APPLE", 150),
            };
            PrintSongs(songs);
        }


        private static void PrintSongs(Song[] songs) {

            foreach (var song in songs) {

                Console.WriteLine(@"{0}, {1} {2:mm\:ss}", song.title, song.ArtistName, TimeSpan.FromSeconds(song.Length));

            }


        }


    }
}
