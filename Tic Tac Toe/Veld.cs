using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
	public class Veld : Control
	{
		public Veld()
		{
			this.MouseMove += Veld_MouseMove;
			this.MouseClick += Veld_MouseClick;
			this.MouseLeave += Veld_MouseLeave;
			this.DoubleBuffered = true;
		}

		void Veld_MouseLeave(object sender, EventArgs e)
		{

			//this.Invalidate(new Rectangle(vorigeco.X * 100, vorigeco.Y * 100, 100, 100));
		}

		void Veld_MouseClick(object sender, MouseEventArgs e)
		{
            if (gewonnen) return;
			Point pt = getMouseCoordinate();
			if(waarden[pt.X,pt.Y].EndsWith("'"))
			{
				if (beurt)	waarden[pt.X, pt.Y] = "X";
				else		waarden[pt.X, pt.Y] = "O";
				this.Invalidate();
				if (CheckWinner(beurt ? "X" : "O"))
				{
					SpelerGewonnenEventArgs ee = new SpelerGewonnenEventArgs(beurt ? "X" : "O");
                    gewonnen = true;
					this.SpelerGewonnen(this, ee);
				}
				beurt = !beurt;
			}
		}
		public void Reset()
		{
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					waarden[i, j] = "";
            gewonnen = false;
			this.Invalidate();
		}

        private bool gewonnen = false;
		//private bool isbusy = false;
		void Veld_MouseMove(object sender, MouseEventArgs e)
		{
			//if (isbusy) return;
			//isbusy = true;
			 
			Point nieuweco = getMouseCoordinate();
			if (nieuweco.X < 0 || nieuweco.X > 2 || nieuweco.Y < 0 || nieuweco.Y > 2) return;
			if (nieuweco != vorigeco)
			{
				if (vorigeco.X != -1 && vorigeco.Y != -1)
					if (waarden[vorigeco.X, vorigeco.Y].EndsWith("'")) waarden[vorigeco.X, vorigeco.Y] = "";

				if (waarden[nieuweco.X, nieuweco.Y] == "")
				{
					if (beurt)
						waarden[nieuweco.X, nieuweco.Y] = "X'";
					else
						waarden[nieuweco.X, nieuweco.Y] = "O'";
				}
				this.Invalidate(new Rectangle(vorigeco.X * 100, vorigeco.Y * 100, 100, 100));
				this.Invalidate(new Rectangle(nieuweco.X * 100, nieuweco.Y * 100, 100, 100));
				vorigeco = nieuweco;
			}
			//isbusy = false;
		}

		private Point vorigeco = new Point(-1, -1);
		public Point getMouseCoordinate()
		{
			Point pt = this.PointToClient(Control.MousePosition);
			return new Point((pt.X - (pt.X % 100)) / 100, (pt.Y - (pt.Y % 100)) / 100);
		}

		#region SpelerGewonnen
		public delegate void SpelerGewonnenEventhandler(object sender, SpelerGewonnenEventArgs e);
		public event SpelerGewonnenEventhandler SpelerGewonnen;
		#endregion
		#region Waarden
		private string[,] waarden = new string[3, 3] {	{"", "", ""},
														{"", "", ""},
														{"", "", ""}};
		public string[,] Waarden
		{
			get { return waarden; }
		}
		#endregion
		public bool beurt = true;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics gr = e.Graphics;
			Pen pen = new Pen(Color.Gray, 10);
			for (int i = 1; i < 3; i++)
				gr.DrawLine(pen, 0, i * 100, 300, i * 100);
			for (int i = 1; i < 3; i++)
				gr.DrawLine(pen, i * 100, 0, i * 100, 300);

			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					switch (waarden[i, j])
					{
						case "X":
							gr.DrawLine(new Pen(Color.Red, 10), i * 100 + 20, j * 100 + 20, i * 100 + 80, j * 100 + 80);
							gr.DrawLine(new Pen(Color.Red, 10), i * 100 + 20, j * 100 + 80, i * 100 + 80, j * 100 + 20);
							break;
						case "O":
							gr.DrawEllipse(new Pen(Color.Green, 10), i * 100 + 20, j * 100 + 20, 60, 60);
							break;
						case "X'":
                            if (gewonnen) break;
							gr.DrawLine(new Pen(Color.DeepPink, 10), i * 100 + 20, j * 100 + 20, i * 100 + 80, j * 100 + 80);
							gr.DrawLine(new Pen(Color.DeepPink, 10), i * 100 + 20, j * 100 + 80, i * 100 + 80, j * 100 + 20);
							break;
						case "O'":
                            if (gewonnen) break;
							gr.DrawEllipse(new Pen(Color.LightGreen, 10), i * 100 + 20, j * 100 + 20, 60, 60);
							break;
					}
		}

		public bool CheckWinner(string speler)
		{
			//horizontaal
			for (int j = 0; j < 3; j++)
			{
				int i = 0;
				while (waarden[i, j] == speler)
					if (++i == 3) return true;
			}

			//verticaal
			for (int i = 0; i < 3; i++)
			{
				int j = 0;
				while (waarden[i, j] == speler)
					if (++j == 3) return true;
			}

			//diagonaal 1
			int k = 0;
			while (waarden[k, k] == speler)
				if (++k == 3) return true;

			//diagonaal 2
			k = 0;
			while (waarden[k, 2 - k] == speler)
				if (++k == 3) return true;
			return false;
		}

		public class SpelerGewonnenEventArgs : EventArgs
		{
			private string speler;
			public string Speler
			{
				get { return speler; }
				set { speler = value; }
			}
			public SpelerGewonnenEventArgs(string Speler)
			{
				speler = Speler;
			}
		}
	}
}
