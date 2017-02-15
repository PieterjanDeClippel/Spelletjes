namespace Rush_Hour
{
	partial class Spelen
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
			this.btnDelen = new System.Windows.Forms.Button();
			this.btnDownload = new System.Windows.Forms.Button();
			this.btnOpslaan = new System.Windows.Forms.Button();
			this.btnOpenen = new System.Windows.Forms.Button();
			this.btnVorige = new System.Windows.Forms.Button();
			this.btnVolgende = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.speelVeld1 = new Rush_Hour.SpeelVeld();
			this.SuspendLayout();
			// 
			// btnDelen
			// 
			this.btnDelen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelen.Location = new System.Drawing.Point(213, 275);
			this.btnDelen.Name = "btnDelen";
			this.btnDelen.Size = new System.Drawing.Size(75, 23);
			this.btnDelen.TabIndex = 1;
			this.btnDelen.Text = "Delen";
			this.btnDelen.UseVisualStyleBackColor = true;
			this.btnDelen.Click += new System.EventHandler(this.btnDelen_Click);
			// 
			// btnDownload
			// 
			this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDownload.Location = new System.Drawing.Point(132, 275);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(75, 23);
			this.btnDownload.TabIndex = 2;
			this.btnDownload.Text = "Download";
			this.btnDownload.UseVisualStyleBackColor = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// btnOpslaan
			// 
			this.btnOpslaan.Location = new System.Drawing.Point(213, 246);
			this.btnOpslaan.Name = "btnOpslaan";
			this.btnOpslaan.Size = new System.Drawing.Size(75, 23);
			this.btnOpslaan.TabIndex = 4;
			this.btnOpslaan.Text = "Opslaan";
			this.btnOpslaan.UseVisualStyleBackColor = true;
			this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
			// 
			// btnOpenen
			// 
			this.btnOpenen.Location = new System.Drawing.Point(132, 246);
			this.btnOpenen.Name = "btnOpenen";
			this.btnOpenen.Size = new System.Drawing.Size(75, 23);
			this.btnOpenen.TabIndex = 5;
			this.btnOpenen.Text = "Openen";
			this.btnOpenen.UseVisualStyleBackColor = true;
			this.btnOpenen.Click += new System.EventHandler(this.btnOpenen_Click);
			// 
			// btnVorige
			// 
			this.btnVorige.Location = new System.Drawing.Point(36, 246);
			this.btnVorige.Name = "btnVorige";
			this.btnVorige.Size = new System.Drawing.Size(42, 23);
			this.btnVorige.TabIndex = 7;
			this.btnVorige.Text = "<";
			this.btnVorige.UseVisualStyleBackColor = true;
			this.btnVorige.Click += new System.EventHandler(this.btnVorige_Click);
			// 
			// btnVolgende
			// 
			this.btnVolgende.Location = new System.Drawing.Point(84, 246);
			this.btnVolgende.Name = "btnVolgende";
			this.btnVolgende.Size = new System.Drawing.Size(42, 23);
			this.btnVolgende.TabIndex = 6;
			this.btnVolgende.Text = ">";
			this.btnVolgende.UseVisualStyleBackColor = true;
			this.btnVolgende.Click += new System.EventHandler(this.btnVolgende_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(51, 275);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Ontwerpen";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// speelVeld1
			// 
			this.speelVeld1.Afm = 50;
			this.speelVeld1.AutoAfm = true;
			this.speelVeld1.Dimensie = new System.Drawing.Size(5, 4);
			this.speelVeld1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.speelVeld1.DoelAuto = null;
			this.speelVeld1.Level = 1;
			this.speelVeld1.Location = new System.Drawing.Point(0, 0);
			this.speelVeld1.Name = "speelVeld1";
			this.speelVeld1.Ontwerpen = false;
			this.speelVeld1.OpeningBreedte = 2;
			this.speelVeld1.OpeningPlaats = Rush_Hour.SpeelVeld.Plaats_opening.Rechts;
			this.speelVeld1.OpeningPositie = 2;
			this.speelVeld1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 80);
			this.speelVeld1.RandDikte = 5;
			this.speelVeld1.RandKleur = System.Drawing.Color.Gray;
			this.speelVeld1.Size = new System.Drawing.Size(300, 310);
			this.speelVeld1.TabIndex = 0;
			this.speelVeld1.Text = "speelVeld1";
			this.speelVeld1.ToonRaster = false;
			// 
			// Spelen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 310);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnVorige);
			this.Controls.Add(this.btnVolgende);
			this.Controls.Add(this.btnOpenen);
			this.Controls.Add(this.btnOpslaan);
			this.Controls.Add(this.btnDownload);
			this.Controls.Add(this.btnDelen);
			this.Controls.Add(this.speelVeld1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Spelen";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private SpeelVeld speelVeld1;
        private System.Windows.Forms.Button btnDelen;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.Button btnOpenen;
        private System.Windows.Forms.Button btnVorige;
        private System.Windows.Forms.Button btnVolgende;
		private System.Windows.Forms.Button button1;
	}
}

