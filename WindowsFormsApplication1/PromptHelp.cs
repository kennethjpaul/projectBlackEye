using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal class PromptHelp
    {
        public static string ShowDialog()
        {

            MetroFramework.Forms.MetroForm promtHelp = new MetroFramework.Forms.MetroForm()
            {
                Width = 470,
                Height = 475,
                FormBorderStyle = FormBorderStyle.None,
                Text = "Help",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label helpLabel = new Label();
            helpLabel.Text = @"Use the add button to add the Facebook Links, it should be of the following format, 'https://www.facebook.com/[your page]'";
            helpLabel.Location = new Point(50,100);
            helpLabel.Font = new Font(helpLabel.Font.Name, 12);
            helpLabel.MaximumSize = new Size(370, 200);
            helpLabel.AutoSize = true;

            Label helpLabel1 = new Label();
            helpLabel1.Text = @"Use the Remove Button to remove the Title you want";
            helpLabel1.Location = new Point(50, 300);
            helpLabel1.Font = new Font(helpLabel.Font.Name, 12);
            helpLabel1.MaximumSize = new Size(370, 200);
            helpLabel1.AutoSize = true;

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 450, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { promtHelp.Close(); };
            promtHelp.Controls.Add(confirmation);
            promtHelp.Controls.Add(helpLabel);
            promtHelp.Controls.Add(helpLabel1);
            return promtHelp.ShowDialog() == DialogResult.OK ? " " : " ";
        }

    }
}