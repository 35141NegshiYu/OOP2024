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
                connection.Insert(customer);
            }
            ReadDatabase();  // 新しい顧客を追加した後、リストを更新
        }

        // Deleteボタンをクリックしたとき
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);  // 顧客を削除
                ReadDatabase();  // リストを更新
            }
        }

        // Updateボタンをクリックしたとき
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください");
                return;
            }

            // テキストボックスに入力された内容で顧客情報を更新
            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);  // 顧客情報をデータベースで更新
            }

            ReadDatabase();  // 更新後にリストを再表示
        }

        // 顧客リストをデータベースから読み込む
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();
                CustomerListView.ItemsSource = _customers;  // ListViewにデータを表示
            }
        }

        // 検索ボックスに入力があった場合、顧客リストをフィルタリング
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        // 顧客リストの選択が変更されたとき
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                // 選択された顧客の情報をテキストボックスに表示
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;
            }
        }
    }
}
