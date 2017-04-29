
using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Threading;

namespace WindowsFormsApplication1
{
    public class Splash
    {
        private static volatile bool _shouldStop;
        static MetroFramework.Forms.MetroForm promptRemove;
        public static string ShowDialog()
        {
            _shouldStop = false;
            return "";
        }
        
      
        public static void closeForm()
        {
            promptRemove.Close();
            _shouldStop = true;
       //     random_form(2);
        }

        public static string random_form(int flag)
        {
            if (flag == 1)
            {
                promptRemove = new MetroFramework.Forms.MetroForm()
                {
                    Width = 700,
                    Height = 100,
                    FormBorderStyle = FormBorderStyle.None,
                    Text = "Loading The Links",
                    StartPosition = FormStartPosition.CenterScreen
                };
                
                promptRemove.TopMost = true;
                promptRemove.Visible = true;
                return "";
            }
            else
            {
                promptRemove.Close();
                return "";
            }

        }

    }
}