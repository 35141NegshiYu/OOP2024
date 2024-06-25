namespace Excercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void btEx8_1_Click(object sender, EventArgs e) {
            var now = DateTime.Now;
            tbDisp.Text = now.ToString("yyyy/MM//dd hh:mm" + "\r\n");
            tbDisp.Text += now.ToString("yyyy年MM月dd日 hh時mm分ss秒" + "\r\n");
            tbDisp.Text += now.ToString("ggyy年 M月d日（dddd）");
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            DateTime nextWeek = NextDay(today, DayOfWeek.Tuesday);
            tbDisp.Text = nextWeek.ToString("dddd");

        }

        private static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }

        private void tbDisp_TextChanged(object sender, EventArgs e) {

        }
    }

}
