using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {

            DateTime currentDate = DateTime.Today;
            TimeSpan diff = currentDate - dtpDate.Value;


            tdDisp.Text = (diff.Days + 1) + "日目";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        

        private void btDayBefore_Click(object sender, EventArgs e) {
            var past = dtpDate.Value.AddDays(-(double)nudDay.Value);
            tdDisp.Text = past.ToString("D");
        }

        private void btDayAfter_Click(object sender, EventArgs e) {
            var past = dtpDate.Value.AddDays((double)nudDay.Value);
            tdDisp.Text = past.ToString("D");
        }

        private void btAge_Click(object sender, EventArgs e) {
            var birthday = dtpDate.Value;
            var today = DateTime.Today;
            int age = GetAge(birthday,today);
            tdDisp.Text = age.ToString("D");
        }

        private int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if(targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        
    }
}
