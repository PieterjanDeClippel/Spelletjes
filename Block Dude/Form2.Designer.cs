namespace Block_Dude
{
    partial class Form2
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
            this.speelVeld1 = new Block_Dude.SpeelVeld();
            this.nudBreedte = new System.Windows.Forms.NumericUpDown();
            this.nudHoogte = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreedte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoogte)).BeginInit();
            this.SuspendLayout();
            // 
            // speelVeld1
            // 
            this.speelVeld1.Afm = 50;
            this.speelVeld1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speelVeld1.Dimensie = new System.Drawing.Point(0, 0);
            this.speelVeld1.Location = new System.Drawing.Point(12, 12);
            this.speelVeld1.Name = "speelVeld1";
            this.speelVeld1.Ontwerpen = true;
            this.speelVeld1.Size = new System.Drawing.Size(329, 256);
            this.speelVeld1.TabIndex = 0;
            this.speelVeld1.Text = "speelVeld1";
            // 
            // nudBreedte
            // 
            this.nudBreedte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudBreedte.Location = new System.Drawing.Point(62, 274);
            this.nudBreedte.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudBreedte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBreedte.Name = "nudBreedte";
            this.nudBreedte.Size = new System.Drawing.Size(50, 20);
            this.nudBreedte.TabIndex = 1;
            this.nudBreedte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBreedte.ValueChanged += new System.EventHandler(this.nudDimChanged);
            // 
            // nudHoogte
            // 
            this.nudHoogte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudHoogte.Location = new System.Drawing.Point(169, 274);
            this.nudHoogte.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudHoogte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHoogte.Name = "nudHoogte";
            this.nudHoogte.Size = new System.Drawing.Size(50, 20);
            this.nudHoogte.TabIndex = 2;
            this.nudHoogte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHoogte.ValueChanged += new System.EventHandler(this.nudDimChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Breedte:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hoogte:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudHoogte);
            this.Controls.Add(this.nudBreedte);
            this.Controls.Add(this.speelVeld1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.nudBreedte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoogte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SpeelVeld speelVeld1;
        private System.Windows.Forms.NumericUpDown nudBreedte;
        private System.Windows.Forms.NumericUpDown nudHoogte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}