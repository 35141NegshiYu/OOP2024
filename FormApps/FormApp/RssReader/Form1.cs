using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        IEnumerable<ItemData> items;
        Dictionary<string, string> urlMapping = new Dictionary<string, string>
        {
            { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            { "国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "国際", "https://news.yahoo.co.jp/rss/topics/world.xml" },
            { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml" },
            { "エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
            { "スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "科学", "https://news.yahoo.co.jp/rss/topics/science.xml" },
            { "地域", "https://news.yahoo.co.jp/rss/topics/local.xml" }
        };

        public Form1() {
            InitializeComponent();
            InitializeWebView2();
        }

        private async void InitializeWebView2() {
            await webView21.EnsureCoreWebView2Async();
            webView21.Source = new Uri("about:blank");
        }

        private async void btGet_Click(object sender, EventArgs e) {
            string url = cbRssUrl.Text.Trim(); // ComboBoxからURLを取得
            if (string.IsNullOrEmpty(url) || !Uri.IsWellFormedUriString(url, UriKind.Absolute)) {
                MessageBox.Show("有効なURLを入力してください。");
                return;
            }

            try {
                using (var wc = new WebClient()) {
                    var rssFeedStream = await wc.OpenReadTaskAsync(url); // URLからRSSフィードを取得
                    var xdoc = XDocument.Load(rssFeedStream); // XMLドキュメントとして読み込む
                    items = xdoc.Root.Descendants("item")
                                      .Select(item => new ItemData {
                                          Title = (string)item.Element("title"),
                                          Link = (string)item.Element("link")
                                      }).ToList();

                    lbRssTitle.Items.Clear(); // リストボックスをクリア
                    foreach (var item in items) {
                        lbRssTitle.Items.Add(item.Title); // アイテムのタイトルをリストボックスに追加
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }


        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem != null) {
                var selectedTitle = lbRssTitle.SelectedItem.ToString();
                var selectedItem = items?.FirstOrDefault(i => i.Title == selectedTitle);
                if (selectedItem != null) {
                    webView21.CoreWebView2.Navigate(selectedItem.Link);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            cbRssUrl.DropDownStyle = ComboBoxStyle.DropDown; // URLの入力を許可
            LoadFavorites();
        }

        private void LoadFavorites() {
            cbRssUrl.Items.Clear();
            foreach (var entry in urlMapping) {
                cbRssUrl.Items.Add(entry.Key);
            }
        }

        private void cbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedItem = cbRssUrl.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedItem)) {
                if (urlMapping.ContainsKey(selectedItem)) {
                    var url = urlMapping[selectedItem];
                    btGet_Click(url);
                } else if (Uri.IsWellFormedUriString(selectedItem, UriKind.Absolute)) {
                    btGet_Click(selectedItem);
                } else {
                    MessageBox.Show($"URLが無効です: {selectedItem}");
                }
            }
        }

        private void btGet_Click(string url) {
        }

        private void trButton_Click(object sender, EventArgs e) {
            var displayName = tbRssUrl.Text.Trim();
            var currentUrl = webView21.Source?.ToString();

            if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(currentUrl) || currentUrl == "about:blank") {
                MessageBox.Show("表示名を入力してください。");
                return;
            }

            if (urlMapping.ContainsKey(displayName)) {
                MessageBox.Show("この表示名はすでに登録されています。");
                return;
            }

            urlMapping[displayName] = currentUrl;
            LoadFavorites(); // お気に入りを再読み込み

            MessageBox.Show($"登録されたURL: {currentUrl}");
            tbRssUrl.Clear();
        }
    }

    public class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
