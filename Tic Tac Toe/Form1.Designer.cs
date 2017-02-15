namespace Tic_Tac_Toe
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
            this.veld1 = new Tic_Tac_Toe.Veld();
            this.btnNieuwSpel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // veld1
            // 
            this.veld1.Location = new System.Drawing.Point(12, 12);
            this.veld1.Name = "veld1";
            this.veld1.Size = new System.Drawing.Size(300, 300);
            this.veld1.TabIndex = 0;
            this.veld1.Text = "veld1";
            this.veld1.SpelerGewonnen += new Tic_Tac_Toe.Veld.SpelerGewonnenEventhandler(this.veld1_SpelerGewonnen);
            // 
            // btnNieuwSpel
            // 
            this.btnNieuwSpel.Location = new System.Drawing.Point(13, 319);
            this.btnNieuwSpel.Name = "btnNieuwSpel";
            this.btnNieuwSpel.Size = new System.Drawing.Size(75, 23);
            this.btnNieuwSpel.TabIndex = 1;
            this.btnNieuwSpel.Text = "Nieuw spel";
            this.btnNieuwSpel.UseVisualStyleBackColor = true;
            this.btnNieuwSpel.Click += new System.EventHandler(this.btnNieuwSpel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 350);
            this.Controls.Add(this.btnNieuwSpel);
            this.Controls.Add(this.veld1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

		}

		#endregion

		private Veld veld1;
        private System.Windows.Forms.Button btnNieuwSpel;
	}
}

