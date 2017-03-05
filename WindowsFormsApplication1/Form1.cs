using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Python.Runtime;


namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            //  PythonEngine.Initialize();
            //  IntPtr pythonLock = PythonEngine.AcquireLock();
            //  PythonEngine.RunSimpleString("import sys\n");
            //  PythonEngine.RunSimpleString("sys.path.append('D:\\project_home_path')\n");
            //  PyObject pModule = PythonEngine.ImportModule("MODULE");
            // PyObject a = PythonEngine.ImportModule("clr");
            try
            {
                //    PyString model_path = new PyString("hello");
                ////   var ret = pModule.InvokeMethod("METHOD", model_path);
                //    Console.WriteLine(ret);
                //   PythonEngine.ReleaseLock(pythonLock);
                //   PythonEngine.Shutdown();
                // py.ExecuteFile("newpython.py");


                /*System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "Python.exe";
                startInfo.Arguments = "exp.py";
                process.StartInfo = startInfo;
                process.Start();

                */

                using (Py.GIL())
                {
                    dynamic sys = Py.Import("sys");
                    dynamic requests = Py.Import("requests");
                    dynamic re = Py.Import("re");
                    dynamic io = Py.Import("io");
                    dynamic BeautifulSoup = Py.Import("bs4");
                    dynamic math = Py.Import("math");
                    Console.WriteLine(5);
                    dynamic r = requests.get("https://www.facebook.com/ScienceAlert/");
                    dynamic data = r.text;
                    dynamic soup = BeautifulSoup.BeautifulSoup(data, "html.parser");

                    // dynamic tag = soup.select("a[href^='https://l.facebook.com/']");
                    // dynamic result = [];

                    dynamic tag = soup.select("a[href^='https://l.facebook.com/']");
                    for (var i = 1; i < 10; i++)
                    {
                      
                        
                        dynamic dict = new[] {"class":"lfloat"};
                        dynamic item = soup.find_all("attrs", dict);
                        //String k = tag;
                        // dynamic m1 = tag(i)["href"].replace("https://l.facebook.com/l.php?u=", "", 1);
                        // Console.WriteLine(item(1));
                       // Console.WriteLine(item);
                    }

                    String exp = Convert.ToString(tag[1]);
                    Console.WriteLine(exp);

                    //  PythonEngine.ImportModule("ex1p.py");
                    Console.WriteLine(
                       "ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                   "Oops! We couldn't execute the script because of an exception: " + ex.Message);
            }
        }
    }
}
