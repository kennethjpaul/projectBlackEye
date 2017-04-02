

using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public static class Prompt
    {
        public static string[] ShowDialog(string text,string link, string caption)
        {
            string[] details = new string[2];
            string[] null_string = new string[2];
            MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm() 
            {
                Width = 470,
                Height = 250,
                FormBorderStyle = FormBorderStyle.None,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textTitle = new Label() { Text = text };
            textTitle.Location = new Point(20, 70);
            //, FontStyle.Bold
            textTitle.Font = new Font(textTitle.Font.Name, 12);
            TextBox titleBox = new TextBox() { Left = 40, Top = 100, Width = 400 };

            Label textLink = new Label() { Text = link };
            textLink.Location = new Point(20, 130);
            textLink.Font = new Font(textTitle.Font.Name, 12);
            TextBox linkBox = new TextBox() { Left = 40, Top = 160, Width = 400 };

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 200, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(titleBox);
            prompt.Controls.Add(linkBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textTitle);
            prompt.Controls.Add(textLink);
            prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? new string[] { titleBox.Text, linkBox.Text } : new string[] { " ", " "};
        }
    }
}