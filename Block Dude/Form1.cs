using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Block_Dude
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			(new Form2()).Show();
		}
		Element petie;
        string bestand = "";
		private void button2_Click(object sender, EventArgs e)
		{
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bestand = ofd.FileName;
                speelVeld2.LaadLevel(bestand, 1);
                speelVeld2.Ontwerpen = false;
            }
		}

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                speelVeld2.LaadLevel(bestand, 1);
            }
            catch (Exception)
            {
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            speelVeld2.Afm = (int)numericUpDown1.Value;
        }

        private void speelVeld2_LevelUitgespeeld(object sender, EventArgs e)
        {
            MessageBox.Show("Level uitgespeeld");
        }
    }
}
