using CustomerApp.Objects;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CustomerApp {
    public partial class MainWindow : Window {
        List<Customer> _customers;

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();  // データベースを読み込む
        }

        // Saveボタンをクリックしたとき
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);  // 顧客データを挿入
            }
            ReadDatabase();  // 更新後にデータを再読み込み
        }

        // ListViewの選択された顧客情報をテキストボックスに表示
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;
            }
        }

        // 顧客情報の更新
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください");
                return;
            }

            bool isUpdated = false;

            // 名前が変更された場合
            if (selectedCustomer.Name != NameTextBox.Text) {
                selectedCustomer.Name = NameTextBox.Text;
                isUpdated = true;
            }

            // 電話番号が変更された場合
            if (selectedCustomer.Phone != PhoneTextBox.Text) {
                selectedCustomer.Phone = PhoneTextBox.Text;
                isUpdated = true;
            }

            // 住所が変更された場合
            if (selectedCustomer.Address != AddressTextBox.Text) {
                selectedCustomer.Address = AddressTextBox.Text;
                isUpdated = true;
            }

            if (isUpdated) {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Update(selectedCustomer);  // 顧客情報をデータベースで更新
                }

                // 更新後、ListViewを再度読み込み
                ReadDatabase();
                MessageBox.Show("顧客情報が更新されました。");
            } else {
                MessageBox.Show("変更がありません。");
            }
        }

        // 顧客データを読み込んでListViewに表示
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();
                CustomerListView.ItemsSource = _customers;  // ListViewを更新
            }
        }

        // 顧客を削除する
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);  // 顧客データを削除
                ReadDatabase();  // 更新後にデータを再読み込み
            }
        }

        // 検索ボックスが変更されたとき
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;  // 検索に応じたフィルタリング
        }
    }
}
