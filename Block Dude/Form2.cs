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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void nudDimChanged(object sender, EventArgs e)
        {
            speelVeld1.Dimensie = new Point((int)nudBreedte.Value, (int)nudHoogte.Value);
        }
    }
}
