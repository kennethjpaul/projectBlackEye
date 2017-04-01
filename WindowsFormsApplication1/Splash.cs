
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
        public static void ShowDialog()
        {
            _shouldStop = false;
          
              while (!_shouldStop)
               {
                
               }
        }
        
      
        public static void closeForm()
        {
            _shouldStop = true;
       //     random_form(2);
        }

        public static void random_form(int flag)
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
            }
            else
            {
                promptRemove.Close();
            }

        }

    }
}