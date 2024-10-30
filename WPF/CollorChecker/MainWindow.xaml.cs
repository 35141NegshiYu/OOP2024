using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

            //ほかの初期化処理
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
            /*Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value),
            Name = ""*/

            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(currentColor.Color);

        }
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            currentColor.Name = GetColorList().Where(c => c.Color==currentColor.Color).Select(c => c.Name).FirstOrDefault();
            //色の重複防止
            if (!stockList.Items.Contains((MyColor)currentColor)) {
                stockList.Items.Insert(0, currentColor);
                

            } else {
                MessageBox.Show("既に登録済みです！");
            }
            colorSelectComboBox.SelectedIndex = -1;
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedIndex != -1) {
                colorArea.Background = new SolidColorBrush(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
            //各スライダーの値を設定する    
            setSliderValue(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorSelectComboBox.SelectedIndex != -1) {
                var tempCurrentColor = currentColor = (MyColor)((ComboBox)sender).SelectedItem;
                setSliderValue(currentColor.Color);

                currentColor.Name = tempCurrentColor.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var selectedItem = stockList.SelectedItem;

            if (selectedItem != null) {
                var result = MessageBox.Show("選択した色を削除しますか？", "確認", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) {
                    stockList.Items.Remove(selectedItem);

                    //バックグラウンドの色を黒に戻す
                    colorArea.Background = new SolidColorBrush(Colors.Black);

                    // スライダーの値も初期化する場合はここに追加
                    setSliderValue(Color.FromArgb(255, 0, 0, 0));
                }
            }else {
                MessageBox.Show("削除する項目を選択してください。");
            }
        }
    }
        /// <summary>
        /// 色と色名を保持するクラス
        /// </summary>
        /*public class MyColor {
            public Color Color { get; set; }
            public string Name { get; set; }
            
        }*/
    
}
