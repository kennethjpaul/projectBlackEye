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
            this.metroPanelLinks = new MetroFramework.Controls.MetroPanel();
            this.metroPanelmainTile = new MetroFramework.Controls.MetroPanel();
            this.addButton = new MetroFramework.Controls.MetroTile();
            this.removeButton = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroPanelLinks
            // 
            this.metroPanelLinks.AutoScroll = true;
            this.metroPanelLinks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metroPanelLinks.HorizontalScrollbar = true;
            this.metroPanelLinks.HorizontalScrollbarBarColor = true;
            this.metroPanelLinks.HorizontalScrollbarHighlightOnWheel = true;
            this.metroPanelLinks.HorizontalScrollbarSize = 10;
            this.metroPanelLinks.Location = new System.Drawing.Point(23, 186);
            this.metroPanelLinks.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.metroPanelLinks.Name = "metroPanelLinks";
            this.metroPanelLinks.Size = new System.Drawing.Size(1850, 850);
            this.metroPanelLinks.TabIndex = 3;
            this.metroPanelLinks.VerticalScrollbar = true;
            this.metroPanelLinks.VerticalScrollbarBarColor = true;
            this.metroPanelLinks.VerticalScrollbarHighlightOnWheel = true;
            this.metroPanelLinks.VerticalScrollbarSize = 10;
            // 
            // metroPanelmainTile
            // 
            this.metroPanelmainTile.AutoScroll = true;
            this.metroPanelmainTile.HorizontalScrollbar = true;
            this.metroPanelmainTile.HorizontalScrollbarBarColor = true;
            this.metroPanelmainTile.HorizontalScrollbarHighlightOnWheel = true;
            this.metroPanelmainTile.HorizontalScrollbarSize = 10;
            this.metroPanelmainTile.Location = new System.Drawing.Point(23, 17);
            this.metroPanelmainTile.Name = "metroPanelmainTile";
            this.metroPanelmainTile.Size = new System.Drawing.Size(836, 150);
            this.metroPanelmainTile.TabIndex = 5;
            this.metroPanelmainTile.VerticalScrollbar = true;
            this.metroPanelmainTile.VerticalScrollbarBarColor = true;
            this.metroPanelmainTile.VerticalScrollbarHighlightOnWheel = true;
            this.metroPanelmainTile.VerticalScrollbarSize = 10;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1711, 92);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 75);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(1798, 92);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 75);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.metroPanelmainTile);
            this.Controls.Add(this.metroPanelLinks);
            this.Name = "Form1";
            this.Text = "Experiment";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanelLinks;
        private MetroFramework.Controls.MetroPanel metroPanelmainTile;
        private MetroFramework.Controls.MetroTile addButton;
        private MetroFramework.Controls.MetroTile removeButton;
    }
}

