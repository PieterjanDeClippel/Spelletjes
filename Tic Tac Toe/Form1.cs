using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void veld1_SpelerGewonnen(object sender, Veld.SpelerGewonnenEventArgs e)
		{
			MessageBox.Show("Speler " + e.Speler + " heeft gewonnen");
		}

        private void btnNieuwSpel_Click(object sender, EventArgs e)
        {
            veld1.Reset();
        }
	}
}
