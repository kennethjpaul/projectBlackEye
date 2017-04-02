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
            this.components = new System.ComponentModel.Container();
            this.metroPanelLinks = new MetroFramework.Controls.MetroPanel();
            this.metroPanelmainTile = new MetroFramework.Controls.MetroPanel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.addRemovePanel = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.metroPanelmainTile.Location = new System.Drawing.Point(211, 17);
            this.metroPanelmainTile.Name = "metroPanelmainTile";
            this.metroPanelmainTile.Size = new System.Drawing.Size(1472, 91);
            this.metroPanelmainTile.TabIndex = 5;
            this.metroPanelmainTile.VerticalScrollbar = true;
            this.metroPanelmainTile.VerticalScrollbarBarColor = true;
            this.metroPanelmainTile.VerticalScrollbarHighlightOnWheel = true;
            this.metroPanelmainTile.VerticalScrollbarSize = 10;
            // 
            // addRemovePanel
            // 
            this.addRemovePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addRemovePanel.HorizontalScrollbarBarColor = true;
            this.addRemovePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.addRemovePanel.HorizontalScrollbarSize = 10;
            this.addRemovePanel.Location = new System.Drawing.Point(1689, 74);
            this.addRemovePanel.Name = "addRemovePanel";
            this.addRemovePanel.Size = new System.Drawing.Size(216, 106);
            this.addRemovePanel.TabIndex = 6;
            this.addRemovePanel.VerticalScrollbarBarColor = true;
            this.addRemovePanel.VerticalScrollbarHighlightOnWheel = false;
            this.addRemovePanel.VerticalScrollbarSize = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.addRemovePanel);
            this.Controls.Add(this.metroPanelmainTile);
            this.Controls.Add(this.metroPanelLinks);
            this.Name = "Form1";
            this.Text = "Black Eye";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanelLinks;
        private MetroFramework.Controls.MetroPanel metroPanelmainTile;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MetroFramework.Controls.MetroPanel addRemovePanel;
    }
}

