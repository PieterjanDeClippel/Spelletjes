namespace Rush_Hour
{
    partial class frmWachtwoord
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkWachtwoord = new System.Windows.Forms.CheckBox();
            this.txtWachtwoord1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWachtwoord2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(271, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(165, 93);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkWachtwoord
            // 
            this.chkWachtwoord.AutoSize = true;
            this.chkWachtwoord.Location = new System.Drawing.Point(12, 12);
            this.chkWachtwoord.Name = "chkWachtwoord";
            this.chkWachtwoord.Size = new System.Drawing.Size(145, 17);
            this.chkWachtwoord.TabIndex = 2;
            this.chkWachtwoord.Text = "Gebruik een wachtwoord";
            this.chkWachtwoord.UseVisualStyleBackColor = true;
            this.chkWachtwoord.CheckedChanged += new System.EventHandler(this.chkWachtwoord_CheckedChanged);
            // 
            // txtWachtwoord1
            // 
            this.txtWachtwoord1.Location = new System.Drawing.Point(142, 3);
            this.txtWachtwoord1.Name = "txtWachtwoord1";
            this.txtWachtwoord1.Size = new System.Drawing.Size(214, 20);
            this.txtWachtwoord1.TabIndex = 3;
            this.txtWachtwoord1.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Geef een wachtwoord op: ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtWachtwoord2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtWachtwoord1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 52);
            this.panel1.TabIndex = 5;
            // 
            // txtWachtwoord2
            // 
            this.txtWachtwoord2.Location = new System.Drawing.Point(142, 29);
            this.txtWachtwoord2.Name = "txtWachtwoord2";
            this.txtWachtwoord2.Size = new System.Drawing.Size(214, 20);
            this.txtWachtwoord2.TabIndex = 5;
            this.txtWachtwoord2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Herhaal het wachtwoord: ";
            // 
            // frmWachtwoord
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(383, 130);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkWachtwoord);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWachtwoord";
            this.Text = "Wachtwoord instellen";
            this.Load += new System.EventHandler(this.frmWachtwoord_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkWachtwoord;
        private System.Windows.Forms.TextBox txtWachtwoord1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtWachtwoord2;
        private System.Windows.Forms.Label label2;
    }
}