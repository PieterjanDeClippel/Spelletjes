using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Dude
{
	public class Bestand
	{
		public Bestand(string strBestandsnaam)
		{
			bestandsnaam = strBestandsnaam;
			if (!File.Exists(strBestandsnaam))
			{
				FileStream fs = new FileStream(strBestandsnaam, FileMode.CreateNew);
				fs.Write(new byte[] { }, 0, 0);
				fs.Close();
			}
		}

		private string bestandsnaam;
		public string Bestandsnaam
		{
			get { return bestandsnaam; }
		}

		public string Tekst
		{
			get
			{
				StreamReader reader = new StreamReader(bestandsnaam);
				string resultaat = reader.ReadToEnd();
				reader.Close();
				reader = null;
				if (gecodeerd) return Ontsleutel(resultaat);
				else return resultaat;
			}
			set
			{
				string tekstje = "";
				if (gecodeerd) tekstje = Versleutel(value);
				else tekstje = value;
				StreamWriter writer = new StreamWriter(bestandsnaam);
				writer.Write(tekstje);
				writer.Close();
				writer = null;
			}
		}

		private bool gecodeerd;
		public bool Gecodeerd
		{
			get { return gecodeerd; }
			set
			{
				if (gecodeerd == value) return;
				string tekstje = Tekst;
				gecodeerd = value;
				Tekst = tekstje;
			}
		}
		private static string Versleutel(string Tekst)
		{
			string resultaat = "";
			for (int i = 0; i < Tekst.Length; i++)
			{
				int ascii = Convert.ToInt16(Tekst[i]);
				ascii = (ascii * 7 + 32) % 256;
				resultaat += Convert.ToChar(ascii);
			}
			return resultaat;
		}
		private static string Ontsleutel(string Tekst)
		{
			string resultaat = "";
			for (int i = 0; i < Tekst.Length; i++)
			{
				int ascii = Convert.ToInt16(Tekst[i]);
				ascii = (ascii - 32) / 7;
				if (ascii < 0) ascii += 256;
				resultaat += Convert.ToChar(ascii);
			}
			return resultaat;
		}

		public int AantalTekens(string teken)
		{
			string txtje = Tekst.Replace(teken, Convert.ToChar(31).ToString());
			return txtje.Split(Convert.ToChar(31)).Count() - 1;
		}
		public static int AantalTekens(string txt, string Teken)
		{
			string txtje = txt.Replace(Teken, Convert.ToChar(31).ToString());
			return txtje.Split(Convert.ToChar(31)).Count() - 1;
		}
		public string LeesDeel(string scheidingsteken, int index)
		{
			return LeesDeel(Tekst, scheidingsteken, index);
		}
		public static string LeesDeel(string tekst, string scheidingsteken, int index)
		{
			string txt = tekst.Replace(scheidingsteken, Convert.ToChar(31).ToString());
			return txt.Split(Convert.ToChar(31))[index];
		}


	}
}
