using CustomerApp.Objects;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CustomerApp {
    public partial class MainWindow : Window {
        List<Customer> _customers;
        string _lastSearchText = ""; // 検索ボックスの内容を保持するための変数

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }

        // Saveボタンをクリックしたとき
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            // 名前が未入力の場合は登録できないようにする
            if (string.IsNullOrEmpty(NameTextBox.Text)) {
                MessageBox.Show("名前は必須です。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // 他のフィールドが未入力の場合でも、未登録と表示する
            string name = string.IsNullOrEmpty(NameTextBox.Text) ? "未登録" : NameTextBox.Text;
            string phone = string.IsNullOrEmpty(PhoneTextBox.Text) ? "未登録" : PhoneTextBox.Text;
            string address = string.IsNullOrEmpty(AddressTextBox.Text) ? "未登録" : AddressTextBox.Text;

            byte[] imageData = null;
            if (CustomerImage.Source != null) {
                BitmapImage bitmapImage = CustomerImage.Source as BitmapImage;
                if (bitmapImage != null) {
                    imageData = ConvertImageToBytes(bitmapImage); // 画像をバイト配列に変換
                }
            }

            var customer = new Customer() {
                Name = name,
                Phone = phone,
                Address = address,
                ImageData = imageData
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }

            CustomerImage.Source = null;
            ReadDatabase();  // 新しい顧客を追加した後、リストを更新
            ApplySearch();  // 検索を再適用
        }

        // 画像選択ボタンをクリックしたとき
        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "画像ファイル (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true) {
                string filePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(filePath));

                // 画像をUIに表示
                CustomerImage.Source = bitmap;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);
                ReadDatabase();  // リストを更新    
            }
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            CustomerImage.Source = null;
            ApplySearch();  // 検索を再適用
        }

        // Updateボタンをクリックしたとき
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください");
                return;
            }

            // 各フィールドが空であれば「未登録」と設定
            selectedCustomer.Name = string.IsNullOrEmpty(NameTextBox.Text) ? "未登録" : NameTextBox.Text;
            selectedCustomer.Phone = string.IsNullOrEmpty(PhoneTextBox.Text) ? "未登録" : PhoneTextBox.Text;
            selectedCustomer.Address = string.IsNullOrEmpty(AddressTextBox.Text) ? "未登録" : AddressTextBox.Text;

            // 画像がUIで変更されている場合、画像データも更新
            if (CustomerImage.Source == null) {
                selectedCustomer.ImageData = null; // 画像が削除された場合
            } else {
                selectedCustomer.ImageData = ConvertImageToBytes(CustomerImage.Source as BitmapImage);
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);
            }

            ReadDatabase();  // 更新後にリストを再表示
            ApplySearch();  // 検索を再適用
        }

        // 顧客リストをデータベースから読み込む
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();
                CustomerListView.ItemsSource = _customers;
            }
        }

        // 検索ボックスに入力があった場合、顧客リストをフィルタリング
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            _lastSearchText = SearchTextBox.Text.ToLower();  // 検索テキストを保持
            ApplySearch();
        }

        // 顧客リストの選択が変更されたとき
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;


                if (selectedCustomer.ImageData != null) {
                    using (var stream = new System.IO.MemoryStream(selectedCustomer.ImageData)) {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        CustomerImage.Source = bitmap;
                    }
                } else {
                    CustomerImage.Source = null;
                }
            }
        }

        // 画像削除ボタンをクリックしたとき
        private void DeleteImageButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer == null) {
                MessageBox.Show("削除する顧客を選択してください");
                return;
            }

            // 顧客の画像をUIから削除
            CustomerImage.Source = null;

            // 画像データをデータベースから削除
            if (selectedCustomer.ImageData != null) {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    selectedCustomer.ImageData = null;  // 画像データをnullに設定
                    connection.Update(selectedCustomer);
                }
            }
        }

        // 検索条件を適用
        private void ApplySearch() {
            if (string.IsNullOrEmpty(_lastSearchText)) {
                CustomerListView.ItemsSource = _customers;
            } else {
                var filterList = _customers.Where(x =>
                    x.Name.ToLower().Contains(_lastSearchText) ||
                    x.Phone.ToLower().Contains(_lastSearchText) ||
                    x.Address.ToLower().Contains(_lastSearchText)
                ).ToList();
                CustomerListView.ItemsSource = filterList;
            }
        }

        // 画像をバイト配列に変換するメソッド
        private byte[] ConvertImageToBytes(BitmapImage bitmapImage) {
            using (MemoryStream ms = new MemoryStream()) {
                // JpegBitmapEncoderを使用して画像をメモリストリームに保存
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(ms); // 画像をバイト配列に変換
                return ms.ToArray(); // バイト配列として返す
            }
        }

        // バイト配列を画像に変換するメソッド
        private BitmapImage ConvertBytesToImage(byte[] byteArray) {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(byteArray)) {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;  // メモリストリームから画像を読み込む
                bitmapImage.EndInit();
                return bitmapImage; // 変換したBitmapImageを返す
            }
        }
    }
}
