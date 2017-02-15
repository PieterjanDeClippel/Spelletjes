using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lunar_Lockout
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(0, 0, 50, 50));
			g.DrawEllipse(new Pen(Color.Black,3), new Rectangle(0, 0, 50, 50));
		}

		Bitmap bmp = new Bitmap(50, 50);
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			//e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
			//e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			ColorMap[] map = new ColorMap[3];
			map[0] = new ColorMap() { OldColor = Color.Yellow, NewColor = Color.Green };
			map[1] = new ColorMap() { OldColor = Color.Blue, NewColor = Color.Orange };
			map[2] = new ColorMap() { OldColor = Color.Red, NewColor = Color.Purple };

			ImageAttributes attr = new ImageAttributes();
			attr.SetRemapTable(map);
			e.Graphics.DrawImage(Properties.Resources.rocketklein, new Rectangle(0, 0, 60, 60), 0, 0, 120, 120, GraphicsUnit.Pixel, attr);

			Bitmap bmp2 = Properties.Resources.rocketklein;
			MessageBox.Show(bmp2.GetPixel(60, 60).ToString());

			//// Create a color map.
			//ColorMap[] myColorMap = new ColorMap[2];
			//myColorMap[0] = new ColorMap();
			//myColorMap[0].OldColor = Color.Red;
			//myColorMap[0].NewColor = Color.Green;
			//myColorMap[1] = new ColorMap();
			//myColorMap[1].OldColor = Color.Black;
			//myColorMap[1].NewColor = Color.Orange;

			//// Create an ImageAttributes object, and then pass the
			//// myColorMap object to the SetRemapTable method.
			//ImageAttributes imageAttr = new ImageAttributes();
			//imageAttr.SetRemapTable(myColorMap);

			//// Draw the image with the remap table set.
			//Rectangle rect = new Rectangle(150, 20, 50, 50);
			//e.Graphics.DrawImage(bmp, rect, 0, 0, 50, 50,
			//	GraphicsUnit.Pixel, imageAttr);

		}
	}
}
