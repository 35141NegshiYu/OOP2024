using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor currentColor = new MyColor();   //現在設定してる色情報
        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor = new MyColor {

                Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value),
                Name = ""
            };
        
            colorArea.Background = new SolidColorBrush(currentColor.Color);

            int rvalue = (int)rSlider.Value;
            int gvalue = (int)gSlider.Value;
            int bvalue = (int)bSlider.Value;

            rValue.Text = rvalue.ToString();
            gValue.Text = gvalue.ToString();
            bValue.Text = bvalue.ToString();

           
        
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            stockList.Items.Insert(0, currentColor);
        }
    

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                // 選択されたMyColorから色を取得
                colorArea.Background = new SolidColorBrush(selectedColor.Color);

                //スライダーの更新
                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;

                //テキストボックスの値も更新
                rValue.Text = selectedColor.Color.R.ToString();
                gValue.Text = selectedColor.Color.G.ToString();
                bValue.Text = selectedColor.Color.B.ToString();
            }
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
