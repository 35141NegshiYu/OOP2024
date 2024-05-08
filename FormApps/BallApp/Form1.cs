namespace BallApp {
    public partial class Form1 : Form {
        Obj Obj;
        PictureBox pb;

        //コンストラクタ
        public Form1() {
            InitializeComponent();

        }

        //フォームが最初にロードされるとき一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {
            Obj.Move();

            pb.Location = new Point((int)Obj.PosX, (int)Obj.PosY);


        }
       

        private void Form1_MouseClick(object sender, MouseEventArgs e) {

            pb = new PictureBox();   //画像を表示するコントロール
           

            if (e.Button == MouseButtons.Left) {

                Obj = new SoccerBall(e.X - 25, e.Y - 25);
                     pb.Size = new Size(50, 50);
                pb.Image = Obj.Image;
                pb.Location = new Point((int)Obj.PosX, (int)Obj.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;



            } else if (e.Button == MouseButtons.Right) {

                Obj = new TennisBall(e.X -12, e.Y -12);
                pb.Size = new Size(25, 25);
            }
                pb.Image = Obj.Image;
                pb.Location = new Point((int)Obj.PosX, (int)Obj.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;
                timer1.Start();

            




        }
    }
}
