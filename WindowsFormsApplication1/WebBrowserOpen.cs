using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal class WebBrowserOpen
    {
        public static string ShowDialog(string url)
        {

            MetroFramework.Forms.MetroForm promptWeb = new MetroFramework.Forms.MetroForm()
            {
                Width = 470,
                Height = 475,
                FormBorderStyle = FormBorderStyle.None,
                Text = "Help",
                StartPosition = FormStartPosition.CenterScreen
            };
            promptWeb.WindowState =FormWindowState.Maximized;
            Form myForm = new Form();
            Screen myScreen = Screen.FromControl(myForm);
            Rectangle area = myScreen.WorkingArea;
            WebBrowser newWeb = new WebBrowser();
            newWeb.Navigate(url);
            newWeb.Size = new Size(area.Width, area.Height);
            newWeb.ScriptErrorsSuppressed = true;
            promptWeb.Controls.Add(newWeb);
            return promptWeb.ShowDialog() == DialogResult.OK ? " " : " ";
        }
    }
}