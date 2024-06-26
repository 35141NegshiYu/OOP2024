using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System;

namespace Excercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void btEx8_1_Click(object sender, EventArgs e) {
            var now = DateTime.Now;
            tbDisp.Text = now.ToString("yyyy/MM//dd hh:mm" + "\r\n");
            tbDisp.Text += now.ToString("yyyy�NMM��dd�� hh��mm��ss�b" + "\r\n");
            tbDisp.Text += now.ToString("ggyy�N M��d���idddd�j");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Thread.Sleep(1000);
            sw.Stop();

            TimeSpan elapsed = sw.Elapsed;
            Console.WriteLine("��������:{0}", elapsed);




        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            DateTime nextWeek = NextDay(today, DayOfWeek.Tuesday);
            tbDisp.Text = nextWeek.ToString("dddd");

        }

        private static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }

        private void tbDisp_TextChanged(object sender, EventArgs e) {

        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = String.Format("�������Ԃ�{0}�~���b�ł���",duration.TotalMilliseconds);
            tbDisp.Text = str;
        }
    }
    class TimeWatch {
        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _time;
        }
    }

}
