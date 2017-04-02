using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using MetroFramework.Controls;
using System.Net;
using System.Web;
using System.Linq;
using System.Net.Http;
using MetroFramework;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private static Splash Splash = null;
        public static void CloseSplash()
        {
            if (Splash != null)
            {
               // Splash.CloseSplash();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Yeah Called");
            MakeMainTiles();
            MakeAddorRemove();
        }

        private void MakeAddorRemove()
        {
            MetroTile _addtile = new MetroTile();//
            _addtile.Location = new Point(0, 0);
            _addtile.Size = new Size(48, 48);
            _addtile.Click += addButtonClick;
            _addtile.TileImage = Properties.Resources.add;
            _addtile.UseTileImage = true;
            _addtile.BackColor = Color.White;
            _addtile.CustomBackground = true;



            MetroTile _removetile = new MetroTile();//
            _removetile.Location = new Point(50, 0);
            _removetile.Size = new Size(48, 48);
            _removetile.Click += removeButtonClick;
            _removetile.TileImage = Properties.Resources.remove;
            _removetile.UseTileImage = true;
            _removetile.BackColor = Color.White;
            _removetile.CustomBackground = true;

            MetroTile _helptile = new MetroTile();//
            _helptile.Location = new Point(100, 0);
            _helptile.Size = new Size(48, 48);
            _helptile.Click += helpButtonClick;
            _helptile.TileImage = Properties.Resources.help;
            _helptile.UseTileImage = true;
            _helptile.BackColor = Color.White;
            _helptile.CustomBackground = true;


            addRemovePanel.Controls.Add(_addtile);
            addRemovePanel.Controls.Add(_removetile);
            addRemovePanel.Controls.Add(_helptile);

        }

        private void helpButtonClick(object sender, EventArgs e)
        {
            string promptValue = PromptHelp.ShowDialog();
        }

        private void removeButtonClick(object sender, EventArgs e)
        {
            List<mainTile> mainTile_list = new List<mainTile>();

            mainTile_list = loadLinkFromFile();
            string promptValue = PromptRemove.ShowDialog();
            Regex trimmer = new Regex(@"\s\s+");

            promptValue = trimmer.Replace(promptValue, " ");
            if (promptValue != " " && promptValue != "")
            {
                 if(mainTile_list.Find(x => x.Title.Contains(promptValue)) != null)
                  {
                    string _str = mainTile_list.Find(x => x.Title.Contains(promptValue)).Title;
                    if (promptValue.Equals(_str, StringComparison.Ordinal))
                    {
                        int _index = mainTile_list.FindIndex(x => x.Title.Contains(promptValue));
                        if (_index >= 0)
                        {
                            mainTile_list.RemoveAt(_index);
                        }
                    }
                }
                

            }

            writeLinktoFile(mainTile_list);
            MakeMainTiles();
        }

        private void addButtonClick(object sender, EventArgs e)
        {
            List<mainTile> mainTile_list = new List<mainTile>();

            mainTile_list = loadLinkFromFile();
            string[] promptValue = Prompt.ShowDialog("Title", "Link", "Enter Facebook Link");
            Regex trimmer = new Regex(@"\s\s+");
            Regex link_chk = new Regex("https:[\\/][\\/]www.facebook.com[\\/]");
            Match link_match = link_chk.Match(promptValue[1]);
            if (!link_match.Success)
            {
                promptValue[1] = "";

            }
            promptValue[0] = trimmer.Replace(promptValue[0], " ");
            promptValue[1] = trimmer.Replace(promptValue[1], " ");
            // TODO: check for link format
            if (promptValue[0] != " " && promptValue[0] != "" && promptValue[1] != " " && promptValue[1] != "")
            {
                mainTile m1 = new mainTile();
                m1.add_mainTile(promptValue[0], promptValue[1]);
                mainTile_list.Add(m1);
            }

            writeLinktoFile(mainTile_list);


            MakeMainTiles();
        }

        private void MakeMainTiles()
        {
            
            List<mainTile> mainTile_list = new List<mainTile>();
            metroPanelmainTile.Controls.Clear();
            mainTile_list = loadLinkFromFile();
            // TODO: StreamReaderJSON and put the code in loop
            // mainTile m = new mainTile("New York Times", "https://www.facebook.com/nytimes/");
            // mainTile_list.Add(m);
            if (mainTile_list != null)
            {
                for (int i = 0; i < mainTile_list.Count; i++)
                {
                    MetroFramework.Controls.MetroTile _tile = new MetroTile();
                    _tile.Size = new Size(150, 50);
                    _tile.Tag = mainTile_list[i].Link;
                    _tile.Text = mainTile_list[i].Title;
                    _tile.Cursor = Cursors.Hand;
                    _tile.Location = new Point(i * 160, 0);
                    _tile.TextAlign = ContentAlignment.TopLeft;
                    _tile.TileTextFontWeight = MetroTileTextWeight.Bold;
                    _tile.Click += _tile_MainTile_Click;
                    
                    metroPanelmainTile.Controls.Add(_tile);
                }
            }            
        }
      

        private void _tile_MainTile_Click(object sender, EventArgs e)
        {
            //   Thread t = new Thread(new ThreadStart(Splash));
            //  t.Start();
            Splash workerObject = new Splash();
            Splash.random_form(1);
            Thread workerThread = new Thread(Splash.ShowDialog);

            workerThread.Start();
            string url = Convert.ToString((sender as MetroTile).Tag);
            metroPanelLinks.Controls.Clear();
            List<mainTile> list = new List<mainTile>();
            list = getTheLinks(url);
            Console.WriteLine(list.Count);
            displayTiles(list);
            Splash.closeForm();
            workerThread.Join();
            Splash.random_form(2);
            // Form1.CloseSplash();
            //  t.Abort();
        }

        private void Splash1()
        {
            SplashScreen.SplashForm frm = new SplashScreen.SplashForm();
            frm.AppName = "Loading";
            //   frm.Size = new Size(700,350);
            frm.Text = "Getting the Links";
            Application.Run(frm);
           
        }

   
        private void displayTiles(List<mainTile> list)
        {
            int flag = 0;
            for (int i = 1; i <= list.Count; i++)
            {
                MetroFramework.Controls.MetroTile _tile = new MetroTile();
                Label namelabel = new Label();
                namelabel.AutoSize = true;
                namelabel.MaximumSize = new System.Drawing.Size(400, 60); ;
                namelabel.Text = list[(i - 1)].Title;
                namelabel.Font = new Font(namelabel.Font.Name, 12, FontStyle.Bold);
                _tile.Size = new Size(400, 200);
                _tile.Tag = list[(i - 1)].Link;
                _tile.Cursor = Cursors.Hand;
                if (flag == 0)
                {
                    int k = (i - 1) / 2;
                    _tile.Location = new Point(k * 410, 50);
                    namelabel.Location = new Point(k * 410, 260);
                    flag = 1;
                }
                else
                {
                    int k = (i - 1) / 2;
                    _tile.Location = new Point(k * 410, 350);
                    namelabel.Location = new Point(k * 410, 560);
                    flag = 0;

                }

                //_tile.Style = (MetroFramework.MetroColorStyle)i;
                _tile.Click += _tile_Click;
                //  _tile.Text = list[(i-1)*3];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(list[(i - 1)].Img);
                request.Method = "GET";
                request.Accept = "text/html";
                request.UserAgent = "Fooo";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                   Image image = Image.FromStream(stream);
                    var image_16 = new System.Drawing.Bitmap(image, new Size(400, 200));
                    _tile.TileImage = image_16;
                    _tile.TileImageAlign = ContentAlignment.MiddleCenter;

                }
                _tile.TextAlign = ContentAlignment.TopLeft;
                _tile.UseTileImage = true;
                //   _tile.TileTextFontWeight = MetroTileTextWeight.Bold;
                metroPanelLinks.Controls.Add(_tile);
                metroPanelLinks.Controls.Add(namelabel);
            }
        }

        private List<mainTile> getTheLinks(string url)
        {
            List<mainTile> list = new List<mainTile>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:48.0) Gecko/20100101 Firefox/48.0.1 Waterfox/48.0.1");
            string html = client.GetStringAsync(url).Result;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            var anchors = document.DocumentNode.SelectNodes("//div[@class='lfloat _ohe']/span[@class='_3m6-']/div[@class='_6ks']/a");
            //TODO: Debug the Null values, find out what is happening
            if(anchors!=null)
            {
                foreach (var a in anchors)
                {
                    if (a.Attributes.AttributesWithName("onmouseover").First().Value != null && a.FirstChild.FirstChild.FirstChild.Attributes.AttributesWithName("src").First().Value != null && a.ParentNode.NextSibling != null)
                    {
                        string onmouseover = HttpUtility.HtmlDecode(a.Attributes.AttributesWithName("onmouseover").First().Value);
                        string image = HttpUtility.HtmlDecode(a.FirstChild.FirstChild.FirstChild.Attributes.AttributesWithName("src").First().Value);
                        string title = a.ParentNode.NextSibling.FirstChild.FirstChild.InnerText;
                        var pattern = new Regex(@"LinkshimAsyncLink.swap\(this, ""([^""]+)""\);");
                        var pattern_image = new Regex(@"&url=([^&]+)");
                        var link = pattern.Match(onmouseover).Groups[1].Value.Replace("\\", "");
                        var link_chk = new Regex(@"(\?).*");
                        link = link_chk.Replace(link, "");
                        //TODO: Do it a better way
                        title = title.Replace("&#039;", "\'");
                        var img_check = new Regex(@"(fbstaging:)");
                        var img = HttpUtility.UrlDecode(pattern_image.Match(image).Groups[1].Value);
                        Match _match = img_check.Match(img);
                        if (_match.Success)
                        {
                            // img = "https://d31v04zdn5vmni.cloudfront.net/blog/wp-content/uploads/2014/05/images-not-displayed-690x362.png";
                            img = "http://1.bp.blogspot.com/-Zr0pmj1bLnM/Uhh7kROhGYI/AAAAAAAAGkE/W51xFS75-Ec/s1600/no-thumbnail.png";
                        }
                        mainTile newsTile = new mainTile();
                        newsTile.add_newsTile(title, link, img);
                        list.Add(newsTile);
                    }

                }

            }
            

            return list;
        }

        private void _tile_Click(object sender, EventArgs e)
        {
            string link = Convert.ToString((sender as MetroTile).Tag);
            System.Diagnostics.Process.Start(link);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlackEye");
            string fileName = Path.Combine(specificFolder, "data_file.txt");


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
        }

        private void writeLinktoFile(List<mainTile> mainTile_list)
        {
            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlackEye");

            if (!Directory.Exists(specificFolder))
                Directory.CreateDirectory(specificFolder);

            string fileName = Path.Combine(specificFolder, "data_file.txt");

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            if (!File.Exists(fileName))
            {
                var k = File.Create(fileName);
                k.Close();
            }
                

            using (StreamWriter sw = new StreamWriter(fileName))
            {


                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, mainTile_list);
                }
            }
        }

        private List<mainTile> loadLinkFromFile()
        {
            List<mainTile> mainTile_list = new List<mainTile>();

            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlackEye");

            if (!Directory.Exists(specificFolder))
                Directory.CreateDirectory(specificFolder);

            string fileName = Path.Combine(specificFolder, "data_file.txt");
            if (!File.Exists(fileName))
            {
             var k =   File.Create(fileName);
                k.Close();

            }
            using (StreamReader file = File.OpenText(fileName))
            {
               
                List<mainTile> mainTile_list_tmp = new List<mainTile>();
                JsonSerializer serializer_read = new JsonSerializer();
                mainTile_list_tmp = (List<mainTile>)serializer_read.Deserialize(file, typeof(List<mainTile>));
                if (mainTile_list_tmp != null)
                {
                    mainTile_list = mainTile_list_tmp;
                }
            }
            return mainTile_list;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            
        }

    }

   
}
