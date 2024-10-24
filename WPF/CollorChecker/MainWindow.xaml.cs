using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            //αチャンネルの初期値を設定(起動時すぐにストックボタンが押された場合の対応)
            currentColor.Color = Color.FromArgb(255, 0, 0, 0);

            DataContext = GetColorList();
        }
        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
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
            //色の重複防止
            if (stockList.Items.OfType<MyColor>().Any(c => c.Color == currentColor.Color)) {
                return;
            }

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
            if (colorSelectComboBox.SelectedItem is MyColor selectedColor) {
                //選択された色を設定
                colorArea.Background = new SolidColorBrush(selectedColor.Color);

                //スライダーの更新
                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;

                //テキストボックスの値も更新
                rValue.Text = selectedColor.Color.R.ToString();
                gValue.Text = selectedColor.Color.G.ToString();
                bValue.Text = selectedColor.Color.B.ToString();

                var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
                var color = mycolor.Color;
                var name = mycolor.Name;

            }
        }
        /// <summary>
        /// 色と色名を保持するクラス
        /// </summary>
        public class MyColor {
            public Color Color { get; set; }
            public string Name { get; set; }
            
        }
    }
}
