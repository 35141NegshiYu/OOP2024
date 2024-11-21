using System.Windows.Controls;
using Microsoft.Win32;
using SQLite;
using CustomerApp.Objects;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows;
using System;
using System.Linq;

namespace CustomerApp {
    public partial class MainWindow : Window {
        List<Customer> _customers;

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }

        // Saveボタンをクリックしたとき
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(NameTextBox.Text) &&
                string.IsNullOrEmpty(PhoneTextBox.Text) &&
                string.IsNullOrEmpty(AddressTextBox.Text)) {

                MessageBox.Show("名前、電話番号、住所のいずれかが必須です。少なくとも1つの項目に入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;  
            }

            var customer = new Customer() {
                Name = string.IsNullOrEmpty(NameTextBox.Text) ? "未登録" : NameTextBox.Text,
                Phone = string.IsNullOrEmpty(PhoneTextBox.Text) ? "未登録" : PhoneTextBox.Text,
                Address = string.IsNullOrEmpty(AddressTextBox.Text) ? "未登録" : AddressTextBox.Text,
                ImagePath = CustomerImage.Source != null ? (CustomerImage.Source as BitmapImage)?.UriSource.AbsolutePath : null  // 画像のパスを保存
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            CustomerImage.Source = null;
            ReadDatabase();  // 新しい顧客を追加した後、リストを更新
        }

        // 画像選択ボタンをクリックしたとき
        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "画像ファイル (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true) {
                string filePath = openFileDialog.FileName;
                CustomerImage.Source = new BitmapImage(new Uri(filePath));  // 画像を表示
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
        }

        // Updateボタンをクリックしたとき
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください");
                return;
            }

            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            // 画像がUIで変更されている場合、画像パスも更新
            if (CustomerImage.Source == null) {
                selectedCustomer.ImagePath = null; // 画像が削除された場合
            } else {
                selectedCustomer.ImagePath = (CustomerImage.Source as BitmapImage)?.UriSource.AbsolutePath;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);
            }

            ReadDatabase();  // 更新後にリストを再表示
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
            string searchText = SearchTextBox.Text.ToLower();  // 小文字に変換して、大小文字を区別しない

            var filterList = _customers.Where(x =>
                x.Name.ToLower().Contains(searchText) ||   
                x.Phone.ToLower().Contains(searchText) ||  
                x.Address.ToLower().Contains(searchText)   
            ).ToList();

            CustomerListView.ItemsSource = filterList;
        }

        // 顧客リストの選択が変更されたとき
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;

                // 画像表示
                if (!string.IsNullOrEmpty(selectedCustomer.ImagePath)) {
                    CustomerImage.Source = new BitmapImage(new Uri(selectedCustomer.ImagePath));
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
        }
    }
}
