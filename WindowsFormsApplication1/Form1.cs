using System;
using System.Collections.Generic;
using System.Drawing;
using Python.Runtime;
using System.Text.RegularExpressions;
using MetroFramework.Controls;
using System.Net;
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

        

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Yeah Called");
            MakeMainTiles();
           
        }
       
        private void MakeMainTiles()
        {
            
            List<mainTile> mainTile_list = new List<mainTile>();
            metroPanelmainTile.Controls.Clear();
            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlackEye");

            if (!Directory.Exists(specificFolder))
                Directory.CreateDirectory(specificFolder);

            string fileName = Path.Combine(specificFolder, "data_file.txt");

            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }

            using (StreamReader file = File.OpenText(fileName))
                {
                
                List<mainTile> mainTile_list_tmp = new List<mainTile>();
                JsonSerializer serializer_read = new JsonSerializer();
                mainTile_list_tmp = (List<mainTile>)serializer_read.Deserialize(file, typeof(List<mainTile>));
                if(mainTile_list_tmp!=null)
                {
                    mainTile_list = mainTile_list_tmp;
                }      
            }

            // TODO: StreamReaderJSON and put the code in loop
           // mainTile m = new mainTile("New York Times", "https://www.facebook.com/nytimes/");
           // mainTile_list.Add(m);
            //mainTile m1 = new mainTile("Science Alert", "https://www.facebook.com/ScienceAlert/");
            //mainTile_list.Add(m1);

            if(mainTile_list != null)
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
            Thread t = new Thread(new ThreadStart(Splash));
            t.Start();
            string url = Convert.ToString((sender as MetroTile).Tag);
            metroPanelLinks.Controls.Clear();
            List<String> list = new List<String>();
            list = getTheLinks(url);
            Console.WriteLine(list.Count);
            displayTiles(list);
            t.Abort();
        }

        private void Splash()
        {
            SplashScreen.SplashForm frm = new SplashScreen.SplashForm();
            frm.AppName = "Loading";
            //   frm.Size = new Size(700,350);
            frm.Text = "Getting the Links";
            Application.Run(frm);
           
        }

   
        private void displayTiles(List<string> list)
        {
            int flag = 0;
            for (int i = 1; i <= list.Count / 3; i++)
            {
                MetroFramework.Controls.MetroTile _tile = new MetroTile();
                Label namelabel = new Label();
                namelabel.AutoSize = true;
                namelabel.MaximumSize = new System.Drawing.Size(400, 60); ;
                namelabel.Text = list[(i - 1) * 3];
                namelabel.Font = new Font(namelabel.Font.Name, 12, FontStyle.Bold);
                _tile.Size = new Size(400, 200);
                _tile.Tag = list[(i - 1) * 3 + 1];
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(list[(i - 1) * 3 + 2]);
                request.Method = "GET";
                request.Accept = "text/html";
                request.UserAgent = "Fooo";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                {

                    _tile.TileImage = Image.FromStream(stream);

                }
                //_tile.ImageAlign
                _tile.TextAlign = ContentAlignment.TopLeft;
                //_tile.TextImageRelation
                _tile.UseTileImage = true;
                //   _tile.TileTextFontWeight = MetroTileTextWeight.Bold;
                metroPanelLinks.Controls.Add(_tile);
                metroPanelLinks.Controls.Add(namelabel);
                //   metroPanelLinks.HorizontalScrollbarBarColor = true;
                //   metroPanelLinks.HorizontalScrollbarHighlightOnWheel = false;
                //  metroPanelLinks.HorizontalScrollbarSize = 10;
                //Console.WriteLine(_tile.Tag);
            }
        }

        private List<string> getTheLinks(string url)
        {
            List<String> list = new List<String>();
            try
            {
                using (Py.GIL())
                {
                    dynamic sys = Py.Import("sys");
                    dynamic requests = Py.Import("requests");
                    dynamic re = Py.Import("re");
                    dynamic io = Py.Import("io");
                    dynamic BeautifulSoup = Py.Import("bs4");
                    dynamic math = Py.Import("math");
                    Console.WriteLine(5);
                    dynamic r = requests.get(url);
                    dynamic data = r.text;
                    dynamic soup = BeautifulSoup.BeautifulSoup(data, "html.parser");

                    var divExp = new { _class = "lfloat" };
                    var item = soup.find_all(Py.kw("class", divExp._class));
                    dynamic tag = soup.select("a[href^='https://l.facebook.com/']");
                    for (var i = 1; i < item.Length(); i++)
                    {
                        String input = Convert.ToString(item[i]);
                        string pattern_link = "(.*href=\"https:[\\/][\\/]l.facebook.com[\\/]l.php\\?u=)|(&.*)";
                        string replacement_link = " ";
                        Regex rgx_link = new Regex(pattern_link);
                        string result_link = rgx_link.Replace(input, replacement_link);
                        string pattern_link_1 = "(http|https)%.*";
                        Regex rgx_link_1 = new Regex(pattern_link_1);
                        Match result_link_1 = rgx_link_1.Match(result_link);
                        String input_1_1 = Convert.ToString(result_link_1.Value);
                        string pattern_link_2 = "%3F.*";
                        Regex rgx_link_2 = new Regex(pattern_link_2);
                        string result_link_2 = rgx_link_2.Replace(input_1_1, replacement_link);


                        result_link_2 = result_link_2.Replace("%2F", "/").Replace("%3A", ":");

                        string pattern_img = "(.*url=)";
                        string replacement_img = " ";
                        Regex rgx_img = new Regex(pattern_img);
                        string result_img = rgx_img.Replace(input, replacement_img);
                        Match result_img_1 = rgx_link_1.Match(result_img);
                        String result_img_1_1 = Convert.ToString(result_img_1.Value);

                        string pattern_img_2 = "(&amp.*)";
                        string replacement_img_2 = " ";
                        Regex rgx_img_2 = new Regex(pattern_img_2);
                        string result_img_2 = rgx_img_2.Replace(result_img_1_1, replacement_img_2);
                        result_img_2 = result_img_2.Replace("%2F", "/").Replace("%3A", ":");

                        string pattern_img_3 = "(%3F.*)";
                        Regex rgx_img_3 = new Regex(pattern_img_3);
                        string result_img_3 = rgx_img_3.Replace(result_img_2, replacement_img_2);

                        string pattern_img_4 = "(.jpg)|(.png)";
                        Regex rgx_img_4 = new Regex(pattern_img_4);
                        Match result_img_4 = rgx_img_4.Match(result_img_3);

                        if(result_img_4.Success)
                        {
                            
                        }
                        else
                        {
                            result_img_3 = "";
                        }

                        string pattern_title = "(rel=\"nofollow\" target=\"_blank\">.+?<)";
                        Regex rgx_title = new Regex(pattern_title);
                        Match result_title = rgx_title.Match(input);
                        String result_title_1 = Convert.ToString(result_title.Value);
                        string pattern_title_2 = "(.*>)|(<.*)";
                        string replacement_title_2 = " ";
                        Regex rgx_title_2 = new Regex(pattern_title_2);
                        string rgx_title_2_1 = rgx_title_2.Replace(result_title_1, replacement_title_2);

                        if (String.IsNullOrEmpty(rgx_title_2_1) || String.IsNullOrEmpty(result_link_2) || String.IsNullOrEmpty(result_img_3))
                        {
                            //   Console.WriteLine(" ");
                        }
                        else
                        {
                            list.Add(rgx_title_2_1);
                            list.Add(result_link_2);
                            list.Add(result_img_3);
                            //  Console.WriteLine(rgx_title_2_1);
                            //  Console.WriteLine(result_link_2);
                            //  Console.WriteLine(result_img_2);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                   "Oops! We couldn't execute the script because of an exception: " + ex.Message);
            }
            return list;
        }

        private void _tile_Click(object sender, EventArgs e)
        {
           // Console.WriteLine((sender as MetroTile).Tag);
            string link = Convert.ToString((sender as MetroTile).Tag);
            System.Diagnostics.Process.Start(link);
            //throw new NotImplementedException();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlackEye");
            string fileName = Path.Combine(specificFolder, "data_file.txt");


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<mainTile> mainTile_list = new List<mainTile>();
            string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlackEye");

            if (!Directory.Exists(specificFolder))
                Directory.CreateDirectory(specificFolder);

            string fileName = Path.Combine(specificFolder, "data_file.txt");

            using (StreamReader file = File.OpenText(fileName))
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                List<mainTile> mainTile_list_tmp = new List<mainTile>();
                JsonSerializer serializer_read = new JsonSerializer();
                mainTile_list_tmp = (List<mainTile>)serializer_read.Deserialize(file, typeof(List<mainTile>));
                if (mainTile_list_tmp != null)
                {
                    mainTile_list = mainTile_list_tmp;
                }
            }
            // TODO: Get link from input
            mainTile m1 = new mainTile("Science Alert", "https://www.facebook.com/ScienceAlert/");
            mainTile_list.Add(m1);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            // string filename = Properties.Resources.json;

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                if (!File.Exists(fileName))
                    File.Create(fileName);

                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, mainTile_list);
                    // {"ExpiryDate":new Date(1230375600000),"Price":0}
                }
            }
            MakeMainTiles();
        }
    }

   
}
