using System.ComponentModel;

namespace CarReportSystem {
    public partial class Form1 : Form {
        
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }


        private void label2_Click(object sender, EventArgs e) {

        }

        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,

            };
            listCarReports.Add(carReport);

        }
    }
}
