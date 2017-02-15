using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Rush_Hour
{
    [Designer(typeof(SpeelVeldDesigner))]
    public class SpeelVeld : Control
    {
		public SpeelVeld()
		{
			this.MouseMove += new MouseEventHandler(SpeelVeld_MouseMove);
			this.MouseDown += SpeelVeld_MouseDown;
			this.MouseUp += SpeelVeld_MouseUp;
			this.LevelUitgespeeld += SpeelVeld_LevelUitgespeeld;
			this.LostFocus += SpeelVeld_LostFocus;
			this.DoubleBuffered = true;

			cmsAuto.Items.AddRange(new ToolStripMenuItem[] { tmiKleur, tmiVrijheden, tmiWissen });
			tmiVrijheden.DropDownItems.AddRange(new ToolStripMenuItem[] { tmiHorizontaal, tmiVerticaal });
			tmiHorizontaal.CheckOnClick = true;
			tmiVerticaal.CheckOnClick = true;
        }
		
		void SpeelVeld_LostFocus(object sender, EventArgs e)
        {
            //MouseDownAuto = null;
            isMouseDown = false;

        }
        ~SpeelVeld()
        {

        }

        private Auto doelAuto = null;
        private Auto MouseDownAuto = null;
        public bool INIT = false;
        private bool autoAfm = false;
        private bool isMouseDown = false;
        private bool ontwerpen = false;
        private bool toonRaster = true;
        private Color randKleur = Color.Gray;
        private int afm = 30;
        private int openingBreedte = 1;
        private int openingPositie = 1;
        private int randDikte = 6;
        private Plaats_opening openingPlaats = Plaats_opening.Rechts;
        private Size dimensie = new Size(6, 6);
        private Point pt_mousedown;

        public delegate void LevelUitgespeeldEventHandler(object sender, LevelUitgespeeldEventArgs e);
        public void OnLevelUitgespeeld(LevelUitgespeeldEventArgs e)
        {
            if (this.LevelUitgespeeld != null)
                this.LevelUitgespeeld(this, e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (INIT == true) return;
            if (this.autoAfm)
            {
                if (this.Dock == DockStyle.Fill)
                    Parent.ClientSize = new Size(Padding.Left + afm * dimensie.Width + 2 * randDikte + Padding.Right, Padding.Top + afm * dimensie.Height + 2 * randDikte + Padding.Bottom);
                else
                    this.ClientSize = new Size(Padding.Left + afm * dimensie.Width + 2 * randDikte + Padding.Right, Padding.Top + afm * dimensie.Height + 2 * randDikte + Padding.Bottom);
            }
            Graphics gr = e.Graphics;

            if (BackColor == Color.Transparent) gr.Clear(Parent.BackColor);
            else gr.Clear(BackColor);

            /*boven */
            gr.FillRectangle(new SolidBrush(randKleur), Padding.Left, Padding.Top, afm * dimensie.Width + 2 * randDikte, randDikte);
            /*links */
            gr.FillRectangle(new SolidBrush(randKleur), Padding.Left, Padding.Top, randDikte, afm * dimensie.Height + 2 * randDikte);
            /*rechts*/
            gr.FillRectangle(new SolidBrush(randKleur), Padding.Left + afm * dimensie.Width + randDikte, Padding.Top, randDikte, afm * dimensie.Height + 2 * randDikte);
            /*onder */
            gr.FillRectangle(new SolidBrush(randKleur), Padding.Left, Padding.Top + afm * dimensie.Height + randDikte, afm * dimensie.Width + 2 * randDikte, randDikte);

            switch (openingPlaats)
            {
                case Plaats_opening.Bovenaan:
                    gr.FillRectangle(new SolidBrush(BackColor), Padding.Left + randDikte + (openingPositie - 1) * afm + 1, Padding.Top, openingBreedte * afm - 1, randDikte);
                    break;
                case Plaats_opening.Onderaan:
                    gr.FillRectangle(new SolidBrush(BackColor), Padding.Left + randDikte + (openingPositie - 1) * afm + 1, Padding.Top + afm * dimensie.Height + randDikte, openingBreedte * afm - 1, randDikte);
                    break;
                case Plaats_opening.Links:
                    gr.FillRectangle(new SolidBrush(BackColor), Padding.Left, Padding.Top + randDikte + (openingPositie - 1) * afm + 1, randDikte, openingBreedte * afm - 1);
                    break;
                case Plaats_opening.Rechts:
                    gr.FillRectangle(new SolidBrush(BackColor), Padding.Left + afm * dimensie.Width + randDikte, Padding.Top + randDikte + (openingPositie - 1) * afm + 1, randDikte, openingBreedte * afm - 1);
                    break;
            }

            if (toonRaster)
            {
                for (int i = 1; i < dimensie.Width; i++)
                    gr.DrawLine(new Pen(randKleur), Padding.Left + randDikte + afm * i, Padding.Top + randDikte, Padding.Left + randDikte + afm * i, Padding.Top + randDikte + dimensie.Height * afm);

                for (int j = 1; j < dimensie.Height; j++)
                    gr.DrawLine(new Pen(randKleur), Padding.Left + randDikte, Padding.Top + randDikte + afm * j, Padding.Left + randDikte + dimensie.Width * afm, Padding.Top + randDikte + afm * j);
            }

            foreach (Auto item in this.Autos)
            {
                Rectangle rct = item.rct(this);
                e.Graphics.FillRectangle(new SolidBrush(item.Kleur), rct);
                e.Graphics.DrawRectangle(Pens.Black, rct);

                if (this.ontwerpen)
                {
                    if ((item.Bewegingen & Auto.vrijheden.Horizontaal) == Auto.vrijheden.Horizontaal)
                    {
                        e.Graphics.FillPolygon(Brushes.Black, new Point[] {
							new Point(rct.Left, rct.Top + rct.Height / 2),
							new Point(rct.Left + 6, rct.Top + rct.Height / 2 - 6),
							new Point(rct.Left + 6, rct.Top + rct.Height / 2 + 6)
						});
                        e.Graphics.FillPolygon(Brushes.Black, new Point[] {
							new Point(rct.Right, rct.Top + rct.Height / 2),
							new Point(rct.Right - 6, rct.Top + rct.Height / 2 - 6),
							new Point(rct.Right - 6, rct.Top + rct.Height / 2 + 6)
						});
                    }
                    if ((item.Bewegingen & Auto.vrijheden.Verticaal) == Auto.vrijheden.Verticaal)
                    {
                        e.Graphics.FillPolygon(Brushes.Black, new Point[] {
							new Point(rct.Left + rct.Width / 2, rct.Top),
							new Point(rct.Left + rct.Width / 2 - 6, rct.Top + 6),
							new Point(rct.Left + rct.Width / 2 + 6, rct.Top + 6)
						});
                        e.Graphics.FillPolygon(Brushes.Black, new Point[] {
							new Point(rct.Left + rct.Width / 2, rct.Bottom),
							new Point(rct.Left + rct.Width / 2 - 6, rct.Bottom - 6),
							new Point(rct.Left + rct.Width / 2 + 6, rct.Bottom - 6)
						});
                    }
                    if (this.doelAuto == item)
                    {
                        e.Graphics.FillEllipse(Brushes.Black,
                            rct.Left + rct.Width / 2 - this.afm / 4,
                            rct.Top + rct.Height / 2 - this.afm / 4,
                            this.afm / 2,
                            this.afm / 2);
                    }
                }
            }
        }
        private void SpeelVeld_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            MouseDownAuto = MouseHover_auto();
			pt_mousedown = e.Location;

			if(MouseDownAuto != null)
			{
				switch(e.Button)
				{
					case MouseButtons.Left:
						mouseDownMode = enmousedownmode.Verplaatsen;
						break;
					case MouseButtons.Right:
						if(ontwerpen)
							cmsAuto.Show(MousePosition);
						break;
				}
			}
			else if(ontwerpen)
			{
				if(e.Button == MouseButtons.Left)
				{
					MouseDownAuto = new Auto(this);
					MouseDownAuto.Afmeting = new Size(1, 1);
					MouseDownAuto.Positie = pt_co(pt_mousedown);
					mouseDownMode = enmousedownmode.Nieuwe_auto;
				}
			}
        }
		#region Cms
		private ContextMenuStrip cmsAuto = new ContextMenuStrip();
		private ToolStripMenuItem tmiKleur = new ToolStripMenuItem("Kleur ...");
		private ToolStripMenuItem tmiVrijheden = new ToolStripMenuItem("Bewegingen");
		private ToolStripMenuItem tmiHorizontaal = new ToolStripMenuItem("Horizontaal");
		private ToolStripMenuItem tmiVerticaal = new ToolStripMenuItem("Verticaal");
		private ToolStripMenuItem tmiWissen = new ToolStripMenuItem("Wissen");
		#endregion
		private void SpeelVeld_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            //MouseDownAuto = null;
        }
        private void SpeelVeld_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (MouseDownAuto != null)
                {
                    Point pt = this.PointToClient(Control.MousePosition);
                    //pt_mousedown
                    if (ontwerpen)
                    {
                        if (mouseDownMode == enmousedownmode.Verplaatsen)
                        {
                            if (pt.X - pt_mousedown.X > afm)
                            {
                                if (MouseDownAuto.Positie.X + MouseDownAuto.Afmeting.Width - 1 != this.dimensie.Width)
                                {
                                    MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X + 1, MouseDownAuto.Positie.Y);
                                    pt_mousedown.Offset(afm, 0);
                                }
                            }
                            else if (pt.X - pt_mousedown.X < -afm)
                            {
                                if (MouseDownAuto.Positie.X != 1)
                                {
                                    MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X - 1, MouseDownAuto.Positie.Y);
                                    pt_mousedown.Offset(-afm, 0);
                                }
                            }
                            if (pt.Y - pt_mousedown.Y > afm)
                            {
                                if (MouseDownAuto.Positie.Y + MouseDownAuto.Afmeting.Height - 1 != this.dimensie.Height)
                                {
                                    MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X, MouseDownAuto.Positie.Y + 1);
                                    pt_mousedown.Offset(0, afm);
                                }
                            }
                            else if (pt.Y - pt_mousedown.Y < -afm)
                            {
                                if (MouseDownAuto.Positie.Y != 1)
                                {
                                    MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X, MouseDownAuto.Positie.Y - 1);
                                    pt_mousedown.Offset(0, -afm);
                                }
                            }
                        }
                        else
                        {
                            MouseDownAuto.Afmeting = new Size(Math.Abs(pt_co(pt_mousedown).X - pt_co(pt).X) + 1, Math.Abs(pt_co(pt_mousedown).Y - pt_co(pt).Y) + 1);
                            MouseDownAuto.Positie = new Point(Math.Min(pt_co(pt_mousedown).X, pt_co(pt).X), Math.Min(pt_co(pt_mousedown).Y, pt_co(pt).Y));
                        }
                    }
                    else
                    {
                        if ((MouseDownAuto.Bewegingen & Auto.vrijheden.Horizontaal) == Auto.vrijheden.Horizontaal)
                        {
                            if (pt.X - pt_mousedown.X > afm) //rechts
                            {
                                if (MouseDownAuto.Positie.X + MouseDownAuto.Afmeting.Width > dimensie.Width)
                                {
                                    if (this.openingPlaats != Plaats_opening.Rechts) goto volgende;
                                    if (!ReferenceEquals(this.doelAuto, MouseDownAuto)) goto volgende;
                                    if (MouseDownAuto.Positie.Y < openingPositie | MouseDownAuto.Positie.Y + MouseDownAuto.Afmeting.Height > this.openingPositie + this.openingBreedte)
                                        goto volgende;
                                }
                                for (int i = MouseDownAuto.Positie.Y; i < MouseDownAuto.Positie.Y + MouseDownAuto.Afmeting.Height; i++)
                                    if (co_auto(new Point(MouseDownAuto.Positie.X + MouseDownAuto.Afmeting.Width, i)) != null) goto volgende;

                                //auto verplaatsen
                                MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X + 1, MouseDownAuto.Positie.Y);
                                pt_mousedown.X += afm;
                            }
                            else if (pt_mousedown.X - pt.X > afm) //links
                            {
                                if (MouseDownAuto.Positie.X == 1)
                                {
                                    if (this.openingPlaats != Plaats_opening.Links) goto volgende;
                                    if (!ReferenceEquals(this.doelAuto, MouseDownAuto)) goto volgende;
                                    if (MouseDownAuto.Positie.Y < openingPositie | MouseDownAuto.Positie.Y + MouseDownAuto.Afmeting.Height > this.openingPositie + this.openingBreedte)
                                        goto volgende;
                                }
                                for (int i = MouseDownAuto.Positie.Y; i < MouseDownAuto.Positie.Y + MouseDownAuto.Afmeting.Height; i++)
                                    if (co_auto(new Point(MouseDownAuto.Positie.X - 1, i)) != null) goto volgende;

                                MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X - 1, MouseDownAuto.Positie.Y);
                                pt_mousedown.X -= afm;
                            }
                        }

                    volgende: if ((MouseDownAuto.Bewegingen & Auto.vrijheden.Verticaal) == Auto.vrijheden.Verticaal)
                        {
                            if (pt.Y - pt_mousedown.Y > afm) //omlaag
                            {
                                if (MouseDownAuto.Positie.Y + MouseDownAuto.Afmeting.Height > dimensie.Height)
                                {
                                    if (this.openingPlaats != Plaats_opening.Onderaan) return;
                                    if (!ReferenceEquals(this.doelAuto, MouseDownAuto)) return;
                                    if (MouseDownAuto.Positie.X < openingPositie | MouseDownAuto.Positie.X + MouseDownAuto.Afmeting.Width > this.openingPositie + this.openingBreedte)
                                        return;
                                }
                                if (ontwerpen) goto moveY1;
                                for (int i = MouseDownAuto.Positie.X; i < MouseDownAuto.Positie.X + MouseDownAuto.Afmeting.Width; i++)
                                    if (co_auto(new Point(i, MouseDownAuto.Positie.Y + MouseDownAuto.Afmeting.Height)) != null) return;

                            moveY1: MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X, MouseDownAuto.Positie.Y + 1);
                                pt_mousedown.Y += afm;
                            }
                            else if (pt_mousedown.Y - pt.Y > afm) //omhoog
                            {
                                if (MouseDownAuto.Positie.Y == 1)
                                {
                                    if (this.openingPlaats != Plaats_opening.Bovenaan) return;
                                    if (!ReferenceEquals(this.doelAuto, MouseDownAuto)) return;
                                    if (MouseDownAuto.Positie.X < openingPositie | MouseDownAuto.Positie.X + MouseDownAuto.Afmeting.Width > this.openingPositie + this.openingBreedte)
                                        return;
                                }
                                if (ontwerpen) goto moveY2;
                                for (int i = MouseDownAuto.Positie.X; i < MouseDownAuto.Positie.X + MouseDownAuto.Afmeting.Width; i++)
                                    if (co_auto(new Point(i, MouseDownAuto.Positie.Y - 1)) != null) return;

                            moveY2: MouseDownAuto.Positie = new Point(MouseDownAuto.Positie.X, MouseDownAuto.Positie.Y - 1);
                                pt_mousedown.Y -= afm;
                            }
                        }
                    }
                }
                else
                {
                    Application.DoEvents();
                }
            }
            else
            {
                Auto tmp = MouseHover_auto();
                if (tmp == null)
                    this.Cursor = Cursors.Default;
                else
                {
                    if (this.ontwerpen)
                        this.Cursor = Cursors.Hand;
                    else if ((tmp.Bewegingen & Auto.vrijheden.Horizontaal) == Auto.vrijheden.Horizontaal)
                    {
                        if ((tmp.Bewegingen & Auto.vrijheden.Verticaal) == Auto.vrijheden.Verticaal)
                            this.Cursor = Cursors.SizeAll;
                        else
                            this.Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        if ((tmp.Bewegingen & Auto.vrijheden.Verticaal) == Auto.vrijheden.Verticaal)
                            this.Cursor = Cursors.SizeNS;
                        else
                            this.Cursor = Cursors.No;
                    }
                }
            }
        }

        private enum enmousedownmode
        {
            Nieuwe_auto,
            Verplaatsen
        }
        private enmousedownmode mouseDownMode = enmousedownmode.Nieuwe_auto;

        private void SpeelVeld_LevelUitgespeeld(object sender, LevelUitgespeeldEventArgs e)
        {
            this.isMouseDown = false;
            Level++;
            //this.MouseDownAuto = null;
        }
        private void doelAuto_PositieVeranderd(object sender, EventArgs e)
        {
            switch (openingPlaats)
            {
                case Plaats_opening.Bovenaan:
                    if (doelAuto.Positie.Y + doelAuto.Afmeting.Height == 0)
                    {
                        LevelUitgespeeldEventArgs ee = new LevelUitgespeeldEventArgs(level);
                        OnLevelUitgespeeld(ee);
                    }
                    break;
                case Plaats_opening.Onderaan:
                    if (doelAuto.Positie.Y == this.dimensie.Height + 1)
                    {
                        LevelUitgespeeldEventArgs ee = new LevelUitgespeeldEventArgs(level);
                        OnLevelUitgespeeld(ee);
                    }
                    break;
                case Plaats_opening.Links:
                    if (doelAuto.Positie.X + doelAuto.Afmeting.Width == 0)
                    {
                        LevelUitgespeeldEventArgs ee = new LevelUitgespeeldEventArgs(level);
                        OnLevelUitgespeeld(ee);
                    }
                    break;
                case Plaats_opening.Rechts:
                    if (doelAuto.Positie.X == this.dimensie.Width + 1)
                    {
                        LevelUitgespeeldEventArgs ee = new LevelUitgespeeldEventArgs(level);
                        OnLevelUitgespeeld(ee);
                    }
                    break;
                default:

                    break;
            }
        }

        private Auto MouseHover_auto()
        {
            if (level > Levels.Count) return null;
            foreach (Auto item in this.Levels[level - 1])
                if (item.rct(this).Contains(this.PointToClient(Control.MousePosition)))
                    return item;
            return null;
        }
        private Auto co_auto(Point co)
        {
            foreach (Auto item in Levels[level - 1])
                if ((item.Positie.X <= co.X) & (co.X < item.Positie.X + item.Afmeting.Width))
                    if ((item.Positie.Y <= co.Y) & (co.Y < item.Positie.Y + item.Afmeting.Height))
                        return item;
            return null;
        }
        private Point pt_co(Point pt)
        {
            pt.Offset(-this.Padding.Left - this.randDikte, -this.Padding.Top - this.randDikte);
            Point co = new Point((pt.X - pt.X % afm) / afm + 1, (pt.Y - pt.Y % afm) / afm + 1);
            return co;
        }

        public Auto DoelAuto
        {
            get { return doelAuto; }
            set
            {
                if (doelAuto != null) doelAuto.PositieVeranderd -= doelAuto_PositieVeranderd;
                doelAuto = value;
                if (doelAuto != null) doelAuto.PositieVeranderd += doelAuto_PositieVeranderd;
            }
        }
        public bool AutoAfm
        {
            get { return autoAfm; }
            set { autoAfm = value; this.Invalidate(); }
        }
        public bool Ontwerpen
        {
            get { return ontwerpen; }
            set { ontwerpen = value; this.Invalidate(); }
        }
        public bool ToonRaster
        {
            get { return toonRaster; }
            set { toonRaster = value; this.Invalidate(); }
        }
        public Color RandKleur
        {
            get { return randKleur; }
            set { randKleur = value; this.Invalidate(); }
        }
        public int Afm
        {
            get { return afm; }
            set { afm = value; this.Invalidate(); }
        }
        public int OpeningBreedte
        {
            get { return openingBreedte; }
            set { openingBreedte = value; this.Invalidate(); }
        }
        public int OpeningPositie
        {
            get { return openingPositie; }
            set { openingPositie = value; this.Invalidate(); }
        }
        public int RandDikte
        {
            get { return randDikte; }
            set { randDikte = value; this.Invalidate(); }
        }
        public Plaats_opening OpeningPlaats
        {
            get { return openingPlaats; }
            set { openingPlaats = value; this.Invalidate(); }
        }
        public Size Dimensie
        {
            get { return dimensie; }
            set { dimensie = value; this.Invalidate(); }
        }

        public event LevelUitgespeeldEventHandler LevelUitgespeeld;
        public enum Plaats_opening
        {
            Links,
            Rechts,
            Bovenaan,
            Onderaan
        }

        private string bestandsnaam = "";
        private int level = 1;
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                this.Invalidate();
            }
        }
        public Collectie<Auto> Autos
        {
            get
            {
                while (Levels.Count < level)
                    Levels.Add(new Collectie<Auto>());
                return Levels[level - 1];
            }
        }
        public void Opslaan()
        {
            if (ontwerpen)
            {
                if (bestandsnaam == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Spelletjes/Rush Hour/";
                    sfd.Filter = "Rush Hour Levelpacks|*.rsh";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        bestandsnaam = sfd.FileName;
                    }
                }

                frmWachtwoord frm = new frmWachtwoord();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    object[] obj = new object[] { Levels, frm.Wachtwoord };
                    FileStream fs = new FileStream(bestandsnaam, FileMode.Create);

                    Rijndael rijAlg = Rijndael.Create();
                    rijAlg.Key = GetKey();
                    rijAlg.IV = GetIV();
                    ICryptoTransform encryptor = rijAlg.CreateEncryptor();

                    CryptoStream cs = new CryptoStream(fs, encryptor, CryptoStreamMode.Write);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(cs, obj);
                    cs.Close();
                }
            }
        }

        public void Openen()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Spelletjes/Rush Hour/";
            ofd.Filter = "Rush Hour Levelpacks|*.rsh";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bestandsnaam = ofd.FileName;
                FileStream fs = new FileStream(bestandsnaam, FileMode.Open);

                Rijndael rijAlg = Rijndael.Create();
                rijAlg.Key = GetKey();
                rijAlg.IV = GetIV();
                ICryptoTransform decryptor = rijAlg.CreateDecryptor();

                CryptoStream cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                object[] obj = (object[])formatter.Deserialize(cs);
                cs.Close();

                if (ontwerpen)
                {
                    string wachtwoord = (string)obj[1];
                    frmWachtwoord2 frm = new frmWachtwoord2();
                    if (frm.ShowDialog() != DialogResult.OK)
                        return;
                    else if (frm.Wachtwoord != wachtwoord)
                        return;
                }

                Levels = (Collectie<Collectie<Auto>>)obj[0];
                this.Invalidate();
            }
        }

        private Collectie<Collectie<Auto>> Levels = new Collectie<Collectie<Auto>>();

        public byte[] GetKey()
        {
            //Rijndael.Create().Key & Rijndael.Create().IV
            return new byte[] { 67, 165, 195, 8, 244, 218, 86, 121, 170, 128, 186, 136, 203, 173, 196, 56, 57, 65, 249, 18, 195, 55, 121, 186, 26, 9, 32, 0, 52, 63, 216, 102 };
        }
        public byte[] GetIV()
        {
            return new byte[] { 186, 255, 236, 144, 220, 148, 49, 66, 1, 224, 168, 95, 38, 36, 25, 207 };
        }
    }

    public class LevelUitgespeeldEventArgs : EventArgs
    {
        private int levelNummer = 0;
        public int LevelNummer
        {
            get { return levelNummer; }
        }

        public LevelUitgespeeldEventArgs(int nummer)
        {
            levelNummer = nummer;
        }
    }

    [Serializable()] public class Auto : ISerializable
    {
        public Auto(SpeelVeld objVeld)
        {
            veld = objVeld;
            veld.Autos.Add(this);
        }
        public Auto()
        {

        }
        ~Auto()
        {
            if (veld != null)
                if (veld.Autos != null)
                    veld.Autos.Remove(this);
            veld = null;
        }

        [NonSerialized(),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] private SpeelVeld veld = null;
        public SpeelVeld Veld()
        {
            return veld;
        }

        private Size afmeting = new Size(2, 1);
        public Size Afmeting
        {
            get { return afmeting; }
            set { afmeting = value; veld.Invalidate(); }
        }
        private Point positie = new Point(1, 1);
        public Point Positie
        {
            get { return positie; }
            set
            {
                Rectangle rct_oud = this.rct(veld); rct_oud.Inflate(1, 1);
                positie = value;
                Rectangle rct_nieuw = this.rct(veld); rct_nieuw.Inflate(1, 1);

                veld.Invalidate(rct_oud);
                veld.Invalidate(rct_nieuw);
                this.OnPositieVeranderd(new EventArgs());
            }
        }

        public event EventHandler PositieVeranderd;
        void OnPositieVeranderd(EventArgs e)
        {
            if (this.PositieVeranderd != null) this.PositieVeranderd(this, e);
        }

        private vrijheden bewegingen = vrijheden.Horizontaal | vrijheden.Verticaal;
        public vrijheden Bewegingen
        {
            get { return bewegingen; }
            set { bewegingen = value; }
        }
        public enum vrijheden
        {
            Horizontaal = 1,
            Verticaal = 2
        }
        private Color kleur = Color.Green;
        public Color Kleur
        {
            get { return kleur; }
            set { kleur = value; veld.Invalidate(); }
        }
        public Rectangle rct(SpeelVeld objVeld)
        {
            return new Rectangle(
                (this.positie.X - 1) * objVeld.Afm + objVeld.Padding.Left + objVeld.RandDikte,
                (this.Positie.Y - 1) * objVeld.Afm + objVeld.Padding.Top + objVeld.RandDikte,
                this.afmeting.Width * objVeld.Afm,
                this.afmeting.Height * objVeld.Afm);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) return;
            info.AddValue("Afmeting", afmeting);
            info.AddValue("Positie", positie);
            info.AddValue("Bewegingen", bewegingen);
            info.AddValue("Kleur", kleur);
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) return;
            GetObjectData(info, context);
        }
        protected Auto(SerializationInfo info, StreamingContext context)
        {
            if (info == null) return;
            afmeting = (Size)info.GetValue("Afmeting", typeof(Size));
            positie = (Point)info.GetValue("Positie", typeof(Point));
            bewegingen = (vrijheden)info.GetValue("Bewegingen", typeof(vrijheden));
            kleur = (Color)info.GetValue("Kleur", typeof(Color));
        }
    }

    public class SpeelVeldDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                if (((SpeelVeld)this.Control).AutoAfm)
                    return System.Windows.Forms.Design.SelectionRules.Moveable | System.Windows.Forms.Design.SelectionRules.Visible;
                else
                    return System.Windows.Forms.Design.SelectionRules.Moveable | System.Windows.Forms.Design.SelectionRules.AllSizeable;
            }
        }
    }
}