using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Block_Dude
{
	public class SpeelVeld : Control
	{
		#region Constructor
		public SpeelVeld()
		{
			elementen = new Collectie<Element>();
			elementen.Changed += elementen_Changed;
            this.KeyDown += SpeelVeld_KeyDown;
            this.Click += SpeelVeld_Click;
            this.Resize += SpeelVeld_Resize;
            this.DoubleBuffered = true;

            tmiPlaats.Text = "Plaats";
            tmiPlaats.DropDownItems.AddRange(new ToolStripItem[] { tmiPlaatsSteen, tmiPlaatsPetie, tmiPlaatsDeur, tmiPlaatsBlok });
            tmiPlaatsSteen.Text = "Steen";
            tmiPlaatsPetie.Text = "Petie";
            tmiPlaatsDeur.Text = "Deur";
            tmiPlaatsBlok.Text = "Blok";
            tmiWis.Text = "Wissen";
            tmiOpslaan.Text = "Opslaan";
            cmsOntwerpen.Items.AddRange(new ToolStripItem[] { tmiPlaats, tmiWis, tmiOpslaan });
            this.MouseClick += SpeelVeld_MouseClick;
            tmiPlaatsBlok.Click += tmiPlaatsBlok_Click;
            tmiPlaatsDeur.Click += tmiPlaatsDeur_Click;
            tmiPlaatsPetie.Click += tmiPlaatsPetie_Click;
            tmiPlaatsSteen.Click += tmiPlaatsSteen_Click;
            tmiWis.Click += tmiWis_Click;
            tmiOpslaan.Click += tmiOpslaan_Click;
            
        }




        void tmiWis_Click(object sender, EventArgs e)
        {
            Element el = GetElementVanPositie(pt_co(this.PointToClient(mousedownpt)));
            if(el != null)
            {
                elementen.Remove(el);
                this.Invalidate();
            }

        }

        void tmiOpslaan_Click(object sender, EventArgs e)
        {
            this.Opslaan();
        }



        Point mousedownpt;
        Element objectToPlace = null;
        void tmiPlaatsBlok_Click(object sender, EventArgs e)
        {
            objectToPlace = new Element();
            objectToPlace.Soort = Element.enSoort.Blok;
            objectToPlace.Locatie = pt_co(this.PointToClient(mousedownpt));
            elementen.Add(objectToPlace);
            this.Invalidate();
        }
        void tmiPlaatsDeur_Click(object sender, EventArgs e)
        {
            objectToPlace = new Element();
            objectToPlace.Soort = Element.enSoort.Deur;
            objectToPlace.Locatie = pt_co(this.PointToClient(mousedownpt));
            elementen.Add(objectToPlace);
            this.Invalidate();
        }
        void tmiPlaatsPetie_Click(object sender, EventArgs e)
        {
            objectToPlace = new Element();
            objectToPlace.Soort = Element.enSoort.Petie;
            objectToPlace.Locatie = pt_co(this.PointToClient(mousedownpt));
            elementen.Add(objectToPlace);
            this.Invalidate();
        }
        void tmiPlaatsSteen_Click(object sender, EventArgs e)
        {
            objectToPlace = new Element();
            objectToPlace.Soort = Element.enSoort.Steen;
            objectToPlace.Locatie = pt_co(this.PointToClient(mousedownpt));
            elementen.Add(objectToPlace);
            this.Invalidate();
        }

        Point pt_co(Point pt)
        {
            Point p = new Point(
                (pt.X - pt.X % afm) / afm + 1,
                ((Height - pt.Y) - (Height - pt.Y) % afm) / afm + 1);
            return p;
        }

        void SpeelVeld_MouseClick(object sender, MouseEventArgs e)
        {
            if((e.Button == System.Windows.Forms.MouseButtons.Right) & ontwerpen)
            {
                mousedownpt = Control.MousePosition;
                cmsOntwerpen.Show(this.PointToScreen(e.Location));
            }
        }

        void SpeelVeld_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        void SpeelVeld_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private Element DraagBlok;
        void SpeelVeld_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Control) == Keys.Control)
            {
                if (ontwerpen)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.B:
                            objectToPlace = new Element();
                            objectToPlace.Soort = Element.enSoort.Blok;
                            objectToPlace.Locatie = pt_co(this.PointToClient(Control.MousePosition));
                            elementen.Add(objectToPlace);
                            this.Invalidate();
                            break;
                        case Keys.P:
                            objectToPlace = new Element();
                            objectToPlace.Soort = Element.enSoort.Petie;
                            objectToPlace.Locatie = pt_co(this.PointToClient(Control.MousePosition));
                            elementen.Add(objectToPlace);
                            this.Invalidate();
                            break;
                        case Keys.S:
                            objectToPlace = new Element();
                            objectToPlace.Soort = Element.enSoort.Steen;
                            objectToPlace.Locatie = pt_co(this.PointToClient(Control.MousePosition));
                            elementen.Add(objectToPlace);
                            this.Invalidate();
                            break;
                        case Keys.D:
                            objectToPlace = new Element();
                            objectToPlace.Soort = Element.enSoort.Deur;
                            objectToPlace.Locatie = pt_co(this.PointToClient(Control.MousePosition));
                            elementen.Add(objectToPlace);
                            this.Invalidate();
                            break;
                    }
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        foreach (Element el in elementen)
                        {
                            if (el.Soort == Element.enSoort.Petie)
                            {
                                el.KijkRichting = Element.enKijkRichting.Links;
                                if (el.Locatie.X == 1) continue;
                                Point vorig = el.Locatie;
                                if (GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y) == null)
                                {
                                    el.Locatie = new Point(el.Locatie.X - 1, el.Locatie.Y);
                                    el.Val(this);
                                }
                                else if (elementen.Where(T => (T.Locatie.X == el.Locatie.X - 1) & (T.Locatie.Y == el.Locatie.Y) & (T.Soort == Element.enSoort.Deur)).Count() != 0)
                                {
                                    el.Locatie = new Point(el.Locatie.X - 1, el.Locatie.Y);
                                    el.Val(this);
                                    if (LevelUitgespeeld != null) LevelUitgespeeld(this, EventArgs.Empty);
                                }
                                if (DraagBlok != null)
                                {
                                    if (GetElementVanPositie(vorig.X - 1, vorig.Y + 1) != null)
                                    {
                                        DraagBlok.Val(this);
                                        DraagBlok = null;
                                    }
                                    else
                                        DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                }
                            }
                        }
                        break;
                    case Keys.Right:
                        foreach (Element el in elementen)
                        {
                            if (el.Soort == Element.enSoort.Petie)
                            {
                                el.KijkRichting = Element.enKijkRichting.Rechts;
                                if (el.Locatie.X + 1 >= dimensie.X) continue;
                                Point vorig = el.Locatie;
                                if (GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y) == null)
                                {
                                    el.Locatie = new Point(el.Locatie.X + 1, el.Locatie.Y);
                                    el.Val(this);
                                }
                                else if (GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y).Soort == Element.enSoort.Deur)
                                {
                                    el.Locatie = new Point(el.Locatie.X + 1, el.Locatie.Y);
                                    el.Val(this);
                                    if (LevelUitgespeeld != null) LevelUitgespeeld(this, EventArgs.Empty);
                                }
                                if (DraagBlok != null)
                                {
                                    if (GetElementVanPositie(vorig.X + 1, vorig.Y + 1) != null)
                                    {
                                        DraagBlok.Val(this);
                                        DraagBlok = null;
                                    }
                                    else
                                        DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                }
                            }
                        }
                        break;
                    case Keys.Up:
                        foreach (Element el in elementen)
                        {
                            if (el.Soort == Element.enSoort.Petie)
                            {
                                Point loc = el.Locatie;
                                if (el.KijkRichting == Element.enKijkRichting.Links)
                                {
                                    Element elLinks = GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y);
                                    Element elLinksBoven = GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y + 1);
                                    Element elLinks2Boven = GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y + 2);
                                    if (elLinks == null) continue;
                                    if ((GetElementVanPositie(el.Locatie.X, el.Locatie.Y + 1) != null) & !ReferenceEquals(GetElementVanPositie(el.Locatie.X, el.Locatie.Y + 1), DraagBlok)) continue;
                                    if ((elLinks.Soort == Element.enSoort.Blok) | (elLinks.Soort == Element.enSoort.Steen))
                                    {
                                        if (DraagBlok == null)
                                        {
                                            if (elLinksBoven == null)
                                                el.Locatie = new Point(el.Locatie.X - 1, el.Locatie.Y + 1);
                                            else if ((elLinksBoven.Soort != Element.enSoort.Blok) & (elLinksBoven.Soort != Element.enSoort.Steen))
                                                el.Locatie = new Point(el.Locatie.X - 1, el.Locatie.Y + 1);
                                        }
                                        else if (elLinks2Boven == null)
                                        {
                                            if (elLinksBoven == null)
                                            {
                                                el.Locatie = new Point(el.Locatie.X - 1, el.Locatie.Y + 1);
                                                DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                            }
                                            else if ((elLinksBoven.Soort != Element.enSoort.Blok) & (elLinksBoven.Soort != Element.enSoort.Steen))
                                            {
                                                el.Locatie = new Point(el.Locatie.X - 1, el.Locatie.Y + 1);
                                                DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Element elRechts = GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y);
                                    Element elRechtsBoven = GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y + 1);
                                    Element elRechts2Boven = GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y + 2);
                                    if (elRechts == null) return;
                                    if ((GetElementVanPositie(el.Locatie.X, el.Locatie.Y + 1) != null) & !ReferenceEquals(GetElementVanPositie(el.Locatie.X, el.Locatie.Y + 1), DraagBlok)) continue;
                                    if ((elRechts.Soort == Element.enSoort.Blok) | (elRechts.Soort == Element.enSoort.Steen))
                                    {
                                        if (DraagBlok == null)
                                        {
                                            if (elRechtsBoven == null)
                                                el.Locatie = new Point(el.Locatie.X + 1, el.Locatie.Y + 1);
                                            else if ((elRechtsBoven.Soort != Element.enSoort.Blok) & (elRechtsBoven.Soort != Element.enSoort.Steen))
                                                el.Locatie = new Point(el.Locatie.X + 1, el.Locatie.Y + 1);
                                        }
                                        else if (elRechts2Boven == null)
                                        {
                                            if (elRechtsBoven == null)
                                            {
                                                el.Locatie = new Point(el.Locatie.X + 1, el.Locatie.Y + 1);
                                                DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                            }
                                            else if ((elRechtsBoven.Soort != Element.enSoort.Blok) & (elRechtsBoven.Soort != Element.enSoort.Steen))
                                            {
                                                el.Locatie = new Point(el.Locatie.X + 1, el.Locatie.Y + 1);
                                                DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                            }
                                        }
                                    }
                                }
                                if (loc != el.Locatie)
                                {
                                    Element[] t = elementen.Where(T => (T.Locatie.X == el.Locatie.X) & (T.Locatie.Y == el.Locatie.Y) & (T.Soort == Element.enSoort.Deur)).ToArray();
                                    if (t.Length != 0)
                                        if (LevelUitgespeeld != null) LevelUitgespeeld(this, EventArgs.Empty);
                                }
                            }
                        }
                        break;
                    case Keys.Down:
                        if (DraagBlok == null)
                        {
                            foreach (Element el in elementen)
                            {
                                if (el.Soort == Element.enSoort.Petie)
                                {
                                    if (GetElementVanPositie(el.Locatie.X, el.Locatie.Y + 1) != null) continue;
                                    if (el.KijkRichting == Element.enKijkRichting.Links)
                                    {
                                        if (this.GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y) == null) continue;
                                        if (this.GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y).Soort != Element.enSoort.Blok) continue;

                                        if (this.GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y + 1) == null)
                                        {
                                            DraagBlok = this.GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y);
                                            DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                        }
                                        else if (this.GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y + 1).Soort == Element.enSoort.Deur)
                                        {
                                            DraagBlok = this.GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y);
                                            DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                        }
                                    }
                                    else
                                    {
                                        if (this.GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y) == null) continue;
                                        if (this.GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y).Soort != Element.enSoort.Blok) continue;

                                        if (this.GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y + 1) == null)
                                        {
                                            DraagBlok = this.GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y);
                                            DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                        }
                                        else if (this.GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y + 1).Soort == Element.enSoort.Deur)
                                        {
                                            DraagBlok = this.GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y);
                                            DraagBlok.Locatie = new Point(el.Locatie.X, el.Locatie.Y + 1);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Element el in elementen)
                            {
                                if (el.Soort == Element.enSoort.Petie)
                                {
                                    if (el.KijkRichting == Element.enKijkRichting.Links)
                                    {
                                        if (GetElementVanPositie(el.Locatie.X - 1, el.Locatie.Y + 1) == null)
                                        {
                                            DraagBlok.Locatie = new Point(el.Locatie.X - 1, el.Locatie.Y + 1);
                                            DraagBlok.Val(this);
                                            DraagBlok = null;
                                        }
                                    }
                                    else
                                    {
                                        if (GetElementVanPositie(el.Locatie.X + 1, el.Locatie.Y + 1) == null)
                                        {
                                            DraagBlok.Locatie = new Point(el.Locatie.X + 1, el.Locatie.Y + 1);
                                            DraagBlok.Val(this);
                                            DraagBlok = null;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

		void elementen_Changed(object sender, Collectie<Element>.CollectieChangedEventArgs e)
		{
			foreach (Element el in e.ItemsVerwijderd)
				el.ElementVeranderd -= el_ElementVeranderd;

			foreach (Element el in e.ItemsToegevoegd)
				el.ElementVeranderd += el_ElementVeranderd;
		}
        void el_ElementVeranderd(object sender, Element.ElementVeranderdEventArgs e)
        {
            if (e.Property == "Locatie")
            {
                this.Invalidate(new Rectangle(((Point)e.OldValue).X * afm-afm, this.Height - ((Point)e.OldValue).Y * afm-1, afm + 1, afm + 1));
                this.Invalidate(new Rectangle(((Point)e.NewValue).X * afm-afm, this.Height - ((Point)e.NewValue).Y * afm-1, afm + 1, afm + 1));
            }
            if (e.Property == "KijkRichting")
            {
                this.Invalidate(new Rectangle(((Element)sender).Locatie.X * afm-afm, this.Height - ((Element)sender).Locatie.Y * afm-1, afm + 1, afm + 1));
            }
        }

		#endregion
		#region Elementen
		private Collectie<Element> elementen = null;
			public Collectie<Element> Elementen
			{
				get { return elementen; }
			}
            public Element GetElementVanPositie(int x,int y)
            {
                foreach(Element el in elementen)
                    if ((el.Locatie.X == x) & (el.Locatie.Y == y))
                        return el;
                return null;
            }
            public Element GetElementVanPositie(Point pt)
            {
                return GetElementVanPositie(pt.X, pt.Y);
            }
		#endregion
		#region afm
			private int afm = 50;
			public int Afm
			{
				get { return afm; }
                set { afm = value; RecalcParent(); this.Invalidate(); }
			}
		#endregion
		#region Tekenen
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Graphics gr = e.Graphics;
                gr.Clear(Color.White);
                foreach (Element el in elementen)
                {
                    switch (el.Soort)
                    {
                        case Element.enSoort.Blok:
                            gr.DrawRectangle(Pens.Black, el.Locatie.X * afm - afm, this.Height - (el.Locatie.Y * afm) - 1, afm, afm);
                            break;
                        case Element.enSoort.Deur:
                            gr.DrawRectangle(Pens.Black, el.Locatie.X * afm - 3 * afm / 4, this.Height - (el.Locatie.Y * afm - afm / 4 + 1), afm / 2, 3 * afm / 4);
                            gr.FillEllipse(Brushes.Black, el.Locatie.X * afm - afm * 5 / 8, this.Height - (el.Locatie.Y * afm - afm * 3 / 8 + 1), afm / 4, afm / 4);
                            break;
                        case Element.enSoort.Petie:
                            gr.DrawEllipse(Pens.Black, el.Locatie.X * afm - afm * 5 / 8, this.Height - (el.Locatie.Y * afm - afm / 8 + 1), afm / 4, afm / 4);
                            gr.DrawLine(Pens.Black, el.Locatie.X * afm - afm / 2, this.Height - (el.Locatie.Y * afm - afm * 6 / 8 + 1), el.Locatie.X * afm - afm * 1 / 2, this.Height - (el.Locatie.Y * afm - afm * 3 / 8 + 1)); //buik
                            gr.DrawLine(Pens.Black, el.Locatie.X * afm - afm / 2, this.Height - (el.Locatie.Y * afm - afm * 3 / 4 + 1), el.Locatie.X * afm - afm * 3 / 4, this.Height - (el.Locatie.Y * afm - afm + 1)); //linkerbeen
                            gr.DrawLine(Pens.Black, el.Locatie.X * afm - afm / 2, this.Height - (el.Locatie.Y * afm - afm * 3 / 4 + 1), el.Locatie.X * afm - afm * 1 / 4, this.Height - (el.Locatie.Y * afm - afm + 1)); //rechterbeen
                            gr.DrawLine(Pens.Black, el.Locatie.X * afm - afm * 3 / 4, this.Height - (el.Locatie.Y * afm - afm * 1 / 2 + 1), el.Locatie.X * afm - afm * 2 / 8, this.Height - (el.Locatie.Y * afm - afm * 1 / 2 + 1)); //armen

                            if (el.KijkRichting == Element.enKijkRichting.Links)
                            {
                                gr.DrawLine(
                                    Pens.Black,
                                    el.Locatie.X * afm - afm * 3 / 4,
                                    this.Height - (el.Locatie.Y * afm - afm * 3 / 16 + 1),
                                    el.Locatie.X * afm - afm * 6 / 16,
                                    this.Height - (el.Locatie.Y * afm - afm * 3 / 16 + 1));
                            }
                            else
                            {
                                gr.DrawLine(
                                    Pens.Black,
                                    el.Locatie.X * afm - afm * 5 / 8,
                                    this.Height - (el.Locatie.Y * afm - afm * 3 / 16 + 1),
                                    el.Locatie.X * afm - afm * 1 / 4,
                                    this.Height - (el.Locatie.Y * afm - afm * 3 / 16 + 1));
                            }
                            break;
                        case Element.enSoort.Steen:
                            gr.DrawImage(Block_Dude.Properties.Resources.Steen, new Rectangle(el.Locatie.X * afm - afm, this.Height - el.Locatie.Y * afm - 1, afm, afm));

                            break;
                    }
                }
            }
		#endregion
        #region Knoppen
            protected override bool IsInputKey(Keys keyData)
            {
                switch(keyData)
                {
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Left:
                    case Keys.Right:
                        return true;
                    default:
                        return base.IsInputKey(keyData);
                }
            }
        #endregion
        #region Dimensie
            private Point dimensie;
            public Point Dimensie
            {
                get { return dimensie; }
                set
                {
                    dimensie = value;
                    RecalcParent();
                    this.Invalidate();
                }
            }

            private void RecalcParent()
            {
                if (Parent != null)
                {
                    if ((this.Dock == DockStyle.Top) | (this.Dock == DockStyle.Bottom) | (this.Dock == DockStyle.Fill))
                        Parent.ClientSize = new Size(afm * dimensie.X, Parent.ClientSize.Height);
                    else if (((this.Anchor & AnchorStyles.Left) == AnchorStyles.Left) & ((this.Anchor & AnchorStyles.Right) == AnchorStyles.Right))
                        Parent.ClientSize = new Size(Parent.ClientSize.Width - this.Width + afm * dimensie.X + 1, Parent.ClientSize.Height + 1);


                    if ((this.Dock == DockStyle.Left) | (this.Dock == DockStyle.Right) | (this.Dock == DockStyle.Fill))
                        Parent.ClientSize = new Size(Parent.ClientSize.Width, afm * dimensie.Y);
                    else if (((this.Anchor & AnchorStyles.Top) == AnchorStyles.Top) & ((this.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom))
                        Parent.ClientSize = new Size(Parent.ClientSize.Width + 1, Parent.ClientSize.Height - this.Height + afm * dimensie.Y + 1);

                    if ((this.Dock == DockStyle.None) & (this.Anchor == AnchorStyles.None))
                        this.ClientSize = new Size(afm * dimensie.X + 1, afm * dimensie.Y + 1);
                }
            }
        
        #endregion
        #region Levels
            private int huidiglevel;
            public int Level
            {
                get { return huidiglevel; }
            }
            
            
            public void LaadLevel(string bestand, int level)
            {
                FileStream fs = new FileStream(bestand, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string tekst = reader.ReadToEnd();
                string[] regels = tekst.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                if (regels.Count() > level) return;
                string leveltekst = regels[level - 1];

                string[] items = leveltekst.Split(';');
                string[] dim = items[0].Split(',');
                this.Dimensie = new Point(Convert.ToInt16(dim[0]), Convert.ToInt16(dim[1]));
                elementen.Clear();
                for (int i = 1; i < items.Count(); i++)
                {
                    Element nieuw = new Element();
                    nieuw.FromString(items[i]);
                    elementen.Add(nieuw);
                }
                huidiglevel = level;
                this.Focus();
            }
            
            
            
            public void Opslaan(/*int level*/)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "bestand|*.bd";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(dimensie.X);
                    builder.Append(',');
                    builder.Append(dimensie.Y);

                    foreach(Element element in elementen)
                    {
                        builder.Append(';');
                        builder.Append(element.Locatie.X);
                        builder.Append(',');
                        builder.Append(element.Locatie.Y);
                        builder.Append(',');
                        builder.Append((int)element.Soort);
                    }
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write(builder.ToString());
                    writer.Close();
                    writer = null;
                }
            }

        public event EventHandler LevelUitgespeeld;
        #endregion
        #region Modus
            private bool ontwerpen = false;
            public bool Ontwerpen
            {
                get { return ontwerpen; }
                set
                {
                    ontwerpen = value;
                }
            }
            ContextMenuStrip cmsOntwerpen = new ContextMenuStrip();
            ToolStripMenuItem tmiPlaats = new ToolStripMenuItem();
            ToolStripMenuItem tmiPlaatsPetie = new ToolStripMenuItem();
            ToolStripMenuItem tmiPlaatsDeur = new ToolStripMenuItem();
            ToolStripMenuItem tmiPlaatsBlok = new ToolStripMenuItem();
            ToolStripMenuItem tmiPlaatsSteen = new ToolStripMenuItem();
            ToolStripMenuItem tmiWis = new ToolStripMenuItem();
            ToolStripMenuItem tmiOpslaan = new ToolStripMenuItem();
        #endregion
    }


}
