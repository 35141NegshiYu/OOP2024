namespace BallApp {
    public partial class Form1 : Form {
        //コンストラクタ
        public Form1() {
            InitializeComponent();
        }
        //フォームが最初にロードされるとき一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {
            this.BackColor = Color.Blue;
        }
    }
}
