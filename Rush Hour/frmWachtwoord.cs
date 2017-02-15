using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rush_Hour
{
    public partial class frmWachtwoord : Form
    {
        public frmWachtwoord()
        {
            InitializeComponent();
        }

        private void chkWachtwoord_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = chkWachtwoord.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkWachtwoord.Checked)
            {
                if (txtWachtwoord1.Text == txtWachtwoord2.Text)
                {
                    if (txtWachtwoord1.Text == "")
                    {
                        MessageBox.Show("Geef een wachtwoord op", "Wachtwoord", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("De opgegeven wachtwoorden zijn verschillend", "Wachtwoord", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        public string Wachtwoord
        {
            get { return txtWachtwoord1.Text; }
        }
        

        private void frmWachtwoord_Load(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
    }
}
