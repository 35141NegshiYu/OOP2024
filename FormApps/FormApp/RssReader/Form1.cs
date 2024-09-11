using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;

namespace RssReader {
    
    public partial class Form1 : Form {
        IEnumerable<ItemData> items;
        Dictionary<string, string> urlMapping = new Dictionary<string, string> {
               { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
               {"国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml"},
               {"国際", "https://news.yahoo.co.jp/rss/topics/world.xml"},
               { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml"},
               {"エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
               {"スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"},
               { "IT","https://news.yahoo.co.jp/rss/topics/it.xml"},
               {"科学", "https://news.yahoo.co.jp/rss/topics/science.xml"},
               {"地域", "https://news.yahoo.co.jp/rss/topics/local.xml"} };

        public Form1() {
            InitializeComponent();
            InitializeWebView2();
            /*cbRssUrl.DataSource = new BindingSource(urlMapping, null);
            cbRssUrl.DisplayMember = "Key";
            cbRssUrl.ValueMember = "Value";*/


        }
        private async void InitializeWebView2() {
            await webView21.EnsureCoreWebView2Async();
            webView21.Source = new Uri("about:blank"); // 初期状態の設定
        }

        private void btGet_Click(string url) {
            using (var wc = new WebClient()) {
                try {
                    var rssFeedStream = wc.OpenRead(url);
                    var xdoc = XDocument.Load(rssFeedStream);
                    items = xdoc.Root.Descendants("item")
                                      .Select(item => new ItemData {
                                          Title = (string)item.Element("title"),
                                          Link = (string)item.Element("link")
                                      }).ToList();

                    lbRssTitle.Items.Clear();
                    foreach (var item in items) {
                        lbRssTitle.Items.Add(item.Title);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"RSS フィードの読み込み中にエラーが発生しました: {ex.Message}");
                }
            }
        }



        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            // WebBrowserに表示
            if (lbRssTitle.SelectedItem != null) {
                var selectedTitle = lbRssTitle.SelectedItem.ToString();
                var selectedItem = items?.FirstOrDefault(i => i.Title == selectedTitle);
                if (selectedItem != null) {
                    // WebView2 にリンクを表示
                    webView21.CoreWebView2.Navigate(selectedItem.Link);
                }
            }
        }

        private void webView21_Click(object sender, EventArgs e) {

        }

       
        private void AddRssUrl(string displayName, string url) {
            
            cbRssUrl.Items.Add(displayName);
            urlMapping[displayName] = url;
        }
        private void Form1_Load(object sender, EventArgs e) {
            
        }


        private void cbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbRssUrl.SelectedItem != null) {
                var selectedDisplayName = cbRssUrl.SelectedItem.ToString();
                if (urlMapping.TryGetValue(selectedDisplayName, out var url)) {
                    MessageBox.Show($"選択されたURL: {url}"); // 確認用メッセージ
                    btGet_Click(url);
                } else {
                    MessageBox.Show($"URLが見つかりません: {selectedDisplayName}");
                }
            }
        }

        private void trButton_Click(object sender, EventArgs e) {
            var displayName = tbRssUrl.Text.Trim();
            var currentUrl = webView21.Source?.ToString(); // 現在表示されている URL を取得

            if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(currentUrl) || currentUrl == "about:blank") {
                MessageBox.Show("表示名を入力してください。現在表示されているページの URL が取得できません。");
                return;
            }

            if (urlMapping.ContainsKey(displayName)) {
                MessageBox.Show("この表示名はすでに登録されています。");
                return;
            }

            // 登録処理
            urlMapping.Add(displayName, currentUrl);

            // コンボボックスに表示名を追加
            cbRssUrl.Items.Add(displayName);

            MessageBox.Show($"登録されたURL: {currentUrl}");
            // テキストボックスをクリア
            tbRssUrl.Clear();
        }
    }
    
    //データ格納用のクラス
    public partial class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
