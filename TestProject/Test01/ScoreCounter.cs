using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要：　生徒の点数を読み込み、Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            List<Student> list = new List<Student>();
            string[] strings = File.ReadAllLines(filePath);
            foreach (var s in strings){
                string[] items = s.Split(',');
                Student student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2]),
                };
                list.Add(student);
            }
            return list;
        }

        //メソッドの概要：教科別の点数の合計を求める 
        public IDictionary<string, int> GetPerStudentScore() {
            var score = new Dictionary<string, int>();
            foreach (var student in _score) {
                if (score.ContainsKey(student.Subject)) {
                    score[student.Subject] += student.Score;
                } else {
                    score[student.Subject] = student.Score;
                }
            }
            return score;




        }
    }
}
