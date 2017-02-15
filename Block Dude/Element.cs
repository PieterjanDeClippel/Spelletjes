using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Dude
{
	public class Element
	{
		#region Locatie
		private Point locatie = new Point(0, 0);
		public Point Locatie
		{
			get { return locatie; }
			set
			{
				ElementVeranderdEventArgs ee = new ElementVeranderdEventArgs("Locatie", locatie, value);
				locatie = value;
				if (ElementVeranderd != null) ElementVeranderd(this, ee);
			}
		}
        public void Val(SpeelVeld veld)
        {
            while (checkValbaar(veld.GetElementVanPositie(locatie.X, locatie.Y - 1)))
            {
                Locatie = new Point(locatie.X, locatie.Y - 1);
                if (locatie.Y == -1) return;
            }
        }
        private bool checkValbaar(Element el)
        {
            if (el == null) return true;
            if (el.soort == enSoort.Deur & soort == enSoort.Petie) return true;
            //if (el.soort == enSoort.Petie) return true;
            return false;
        }
		#endregion
		#region Element Veranderd
		public partial class ElementVeranderdEventArgs : EventArgs
		{
			#region Property
			private string property = "";
			public string Property
			{
				get { return property; }
			}
			#endregion
			#region OldValue
			private object oldValue = null;
			public object OldValue
			{
				get { return oldValue; }
			}
			#endregion
			#region NewValue
			private object newValue = null;
			public object NewValue
			{
				get { return newValue; }
			}
			#endregion
			public ElementVeranderdEventArgs(string Property, object OldValue, object NewValue)
			{
				property = Property;
				oldValue = OldValue;
				newValue = NewValue;
			}
		}
		public delegate void ElementVeranderdEventHandler(object sender, ElementVeranderdEventArgs e);
		public event ElementVeranderdEventHandler ElementVeranderd;
		#endregion
		#region Type
		public enum enSoort
		{
			Petie = 0,
			Deur = 1,
			Steen = 2,
			Blok = 3
		}
		private enSoort soort = enSoort.Blok;
		public enSoort Soort
		{
			get { return soort; }
			set
			{
				ElementVeranderdEventArgs ee = new ElementVeranderdEventArgs("Soort", soort, value);
				soort = value;
				if(ElementVeranderd != null) ElementVeranderd(this, ee);
			}
		}
		#endregion
		#region KijkRichting
		public enum enKijkRichting
		{
			Links,
			Rechts
		}
		private enKijkRichting kijkRichting = enKijkRichting.Links;
		public enKijkRichting KijkRichting
		{
			get { return kijkRichting; }
			set
			{
				ElementVeranderdEventArgs ee = new ElementVeranderdEventArgs("KijkRichting", kijkRichting, value);
				kijkRichting = value;
				ElementVeranderd(this, ee);
			}
		}
		#endregion
        #region FromString ToString
        public override string ToString()
        {
            return locatie.X.ToString() + "," + locatie.Y.ToString() + "," + ((int)soort).ToString();
        }
        public void FromString(string tekst)
        {
            string[] items = tekst.Split(',');
            soort = (enSoort)Convert.ToInt16(items[2]);
            Locatie = new Point(Convert.ToInt16(items[0]), Convert.ToInt16(items[1]));
        }
        #endregion
    }

}
