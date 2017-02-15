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
    public partial class Ontwerpen : Form
    {
        public Ontwerpen()
        {
            InitializeComponent();
        }

		private void wijzigAfmetingenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Size newsize;
			DialogResult dr = SizeInput.ShowDialog(speelVeld1.Dimensie, this, out newsize);
			speelVeld1.Dimensie = newsize;
		}
	}
}
