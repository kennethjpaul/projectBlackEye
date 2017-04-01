
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    internal class PromptRemove
    {
        public static string ShowDialog()
        {
            MetroFramework.Forms.MetroForm promptRemove = new MetroFramework.Forms.MetroForm()
            {
                Width = 470,
                Height = 175,
                FormBorderStyle = FormBorderStyle.None,
                Text = "Enter the Title of the Link you want to remove",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textTitle = new Label() { Text = "Title" };
            textTitle.Location = new Point(20, 70);
            //, FontStyle.Bold
            textTitle.Font = new Font(textTitle.Font.Name, 12);
            TextBox titleBox = new TextBox() { Left = 40, Top = 100, Width = 400 };

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 140, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { promptRemove.Close(); };
            promptRemove.Controls.Add(titleBox);
            promptRemove.Controls.Add(confirmation);
            promptRemove.Controls.Add(textTitle);
            promptRemove.AcceptButton = confirmation;
            return promptRemove.ShowDialog() == DialogResult.OK ? titleBox.Text : " ";
        }
    }
}