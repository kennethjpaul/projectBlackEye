namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.Location = new System.Drawing.Point(23, 100);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(396, 121);
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "metroTile1";
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.Location = new System.Drawing.Point(23, 261);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(396, 121);
            this.metroTile2.TabIndex = 1;
            this.metroTile2.Text = "metroTile2";
            // 
            // metroTile3
            // 
            this.metroTile3.Location = new System.Drawing.Point(23, 409);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(396, 121);
            this.metroTile3.TabIndex = 2;
            this.metroTile3.Text = "metroTile3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 569);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.Name = "Form1";
            this.Text = "Experiment";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
    }
}

