/*using System;
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

        List<string> favorites = new List<string>();

        public Form1() {
            InitializeComponent();
            InitializeWebView2();
        }

        private async void InitializeWebView2() {
            await webView21.EnsureCoreWebView2Async();
            webView21.Source = new Uri("about:blank"); // 初期状態の設定
        }

        private void btGet_Click(object sender, EventArgs e) {
            var selectedItem = cbRssUrl.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedItem)) {
                string url;

                // URLが選択されている場合
                if (urlMapping.TryGetValue(selectedItem,out url)) {
                    // URLを取得
                    GetRssFeed(url);
                } else if (Uri.IsWellFormedUriString(selectedItem, UriKind.Absolute)) {
                    // 入力されたURLが有効な場合
                    GetRssFeed(selectedItem);
                } else {
                    MessageBox.Show($"URLが無効です: {selectedItem}");
                }
            }
        }

        private void GetRssFeed(string url) {
            using (var wc = new WebClient()) {
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

        private void AddRssUrl(string displayName, string url) {
            cbRssUrl.Items.Add(displayName);
            urlMapping[displayName] = url;
        }

        private void Form1_Load(object sender, EventArgs e) {
            cbRssUrl.DropDownStyle = ComboBoxStyle.DropDown; // URLの入力を許可
        }

        private void cbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedItem = cbRssUrl.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedItem)) {
                string url;

                if (urlMapping.TryGetValue(selectedItem, out url)) {
                    GetRssFeed(url); // マッピングされたURLを取得
                } else if (Uri.IsWellFormedUriString(selectedItem, UriKind.Absolute)) {
                    GetRssFeed(selectedItem); // 入力されたURLを取得
                } else {
                    MessageBox.Show($"URLが無効です: {selectedItem}");
                }
            }
        }

        private void trButton_Click(object sender, EventArgs e) {
            var displayName = tbRssUrl.Text.Trim();
            var currentUrl = webView21.Source?.ToString();

            if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(currentUrl) || currentUrl == "about:blank") {
                MessageBox.Show("表示名を入力してください。現在表示されているページの URL が取得できません。");
                return;
            }

            if (urlMapping.ContainsKey(displayName)) {
                MessageBox.Show("この表示名はすでに登録されています。");
                return;
            }
            if (lbRssTitle.SelectedItem != null) {
                var selectedTitle = lbRssTitle.SelectedItem.ToString();
                var selectedItem = items?.FirstOrDefault(i => i.Title == selectedTitle);
                if (selectedItem != null) {
                    favorites.Add(selectedItem.Link);
                    MessageBox.Show($"{selectedItem.Title} をお気に入りに追加しました。");
                }
            }

            AddRssUrl(displayName, currentUrl);
            MessageBox.Show($"登録されたURL: {currentUrl}");
            tbRssUrl.Clear();
        }

        

        private void tbRssUrl_TextChanged(object sender, EventArgs e) {
            // ここに必要な処理を追加することができます。
        }
    }

    // データ格納用のクラス
    public partial class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}*/

using System;
using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls.Primitives;
using System.Security.Cryptography;
using Microsoft.Web.WebView2.WinForms;

namespace RssReader {

    public partial class form1 : Form {

        Dictionary<string, string> dataSource = new Dictionary<string, string> {
                       { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
                       {"国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml"},
                       {"国際", "https://news.yahoo.co.jp/rss/topics/world.xml"},
                       { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml"},
                       {"エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
                       {"スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"},
                       { "IT","https://news.yahoo.co.jp/rss/topics/it.xml"},
                       {"科学", "https://news.yahoo.co.jp/rss/topics/science.xml"},
                       {"地域", "https://news.yahoo.co.jp/rss/topics/local.xml"} };


        List<ItemData> items;
        private EventHandler<CoreWebView2InitializationCompletedEventArgs> webView2_CoreWebView2InitializationCompleted;

        public form1() {
            InitializeComponent();
            //初期化完了時のイベント
            webView21.CoreWebView2InitializationCompleted += webView2_CoreWebView2InitializationCompleted;

            webView21.EnsureCoreWebView2Async(null);

            //cbRssName.DataSource = dataSource;
            cbRssUrl.DataSource = new BindingSource(dataSource, null);
            cbRssUrl.DisplayMember = "Key";
            cbRssUrl.ValueMember = "Value";
            this.Resize += new System.EventHandler(this.Form_Resize);

            cbRssUrl.SelectedIndex = -1;

        }


        private void Form_Resize(object sender, EventArgs e) {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
        }


        //取得ボタン
        private void btGet_Click(object sender, EventArgs e) {
            lbRssTitle.Items.Clear();
            var cbBoxinput = cbRssUrl.Text;

            if (cbRssUrl.Text.Contains("news.yahoo.co.jp/rss/")) {
                using (var wc = new WebClient()) {
                    var rssurl = wc.OpenRead(cbRssUrl.Text);
                    var xdoc = XDocument.Load(rssurl);

                    items = xdoc.Root.Descendants("item")
                                          .Select(item => new ItemData {
                                              Title = item.Element("title").Value,
                                              Link = item.Element("link").Value
                                          }).ToList();

                    foreach (var item in items) {

                        lbRssTitle.Items.Add(item.Title);
                    }
                }
            } else if (dataSource.ContainsKey(cbBoxinput)) {
                var selectedCategory = (KeyValuePair<string, string>)cbRssUrl.SelectedItem;
                var url = selectedCategory.Value;

                using (var wc = new WebClient()) {
                    var rssurl = wc.OpenRead(url);
                    var xdoc = XDocument.Load(rssurl);

                    items = xdoc.Root.Descendants("item")
                                          .Select(item => new ItemData {
                                              Title = item.Element("title").Value,
                                              Link = item.Element("link").Value
                                          }).ToList();

                    foreach (var item in items) {

                        lbRssTitle.Items.Add(item.Title);
                    }
                }
            } else {
                MessageBox.Show("正しいＵＲＬを入力してください。", "エラー",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //WebView2にWebページを投影
        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (webView21 != null && webView21.CoreWebView2 != null) {
                webView21.CoreWebView2.Navigate(items[lbRssTitle.SelectedIndex].Link);
            }

        }
        //登録ボタン
        private void bt_Favorite_Click(object sender, EventArgs e) {
            if (tbRssUrl.Text != null && cbRssUrl.Text.Contains("news.yahoo.co.jp/rss/")) {
                dataSource.Add(tbRssUrl.Text, cbRssUrl.Text);
                cbRssUrl.DataSource = new BindingSource(dataSource, null);
                cbRssUrl.DisplayMember = "Key";
                cbRssUrl.ValueMember = "Value";
            } else {
                MessageBox.Show("ＵＲＬとお気に入り名称を入力してください。", "エラー",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tbRssUrl.Clear();
            cbRssUrl.SelectedIndex = -1;
        }
    }

    //データ格納用クラス
    public class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }

}