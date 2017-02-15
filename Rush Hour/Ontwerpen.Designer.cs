namespace Rush_Hour
{
    partial class Ontwerpen
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
			this.speelVeld1 = new Rush_Hour.SpeelVeld();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.optiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wijzigAfmetingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// speelVeld1
			// 
			this.speelVeld1.Afm = 30;
			this.speelVeld1.AutoAfm = true;
			this.speelVeld1.Dimensie = new System.Drawing.Size(6, 6);
			this.speelVeld1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.speelVeld1.DoelAuto = null;
			this.speelVeld1.Level = 1;
			this.speelVeld1.Location = new System.Drawing.Point(0, 24);
			this.speelVeld1.Name = "speelVeld1";
			this.speelVeld1.Ontwerpen = true;
			this.speelVeld1.OpeningBreedte = 1;
			this.speelVeld1.OpeningPlaats = Rush_Hour.SpeelVeld.Plaats_opening.Rechts;
			this.speelVeld1.OpeningPositie = 3;
			this.speelVeld1.Padding = new System.Windows.Forms.Padding(30, 30, 30, 54);
			this.speelVeld1.RandDikte = 6;
			this.speelVeld1.RandKleur = System.Drawing.Color.Gray;
			this.speelVeld1.Size = new System.Drawing.Size(252, 252);
			this.speelVeld1.TabIndex = 0;
			this.speelVeld1.Text = "speelVeld1";
			this.speelVeld1.ToonRaster = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optiesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(252, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// optiesToolStripMenuItem
			// 
			this.optiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wijzigAfmetingenToolStripMenuItem});
			this.optiesToolStripMenuItem.Name = "optiesToolStripMenuItem";
			this.optiesToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.optiesToolStripMenuItem.Text = "Opties";
			// 
			// wijzigAfmetingenToolStripMenuItem
			// 
			this.wijzigAfmetingenToolStripMenuItem.Name = "wijzigAfmetingenToolStripMenuItem";
			this.wijzigAfmetingenToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.wijzigAfmetingenToolStripMenuItem.Text = "Wijzig afmetingen";
			this.wijzigAfmetingenToolStripMenuItem.Click += new System.EventHandler(this.wijzigAfmetingenToolStripMenuItem_Click);
			// 
			// Ontwerpen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(252, 276);
			this.Controls.Add(this.speelVeld1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Ontwerpen";
			this.Text = "Ontwerpen";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private SpeelVeld speelVeld1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem optiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wijzigAfmetingenToolStripMenuItem;
	}
}