using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rush_Hour
{
	public partial class Spelen : Form
	{
		public Spelen()
		{
			InitializeComponent();
            
			Auto A1 = new Auto(speelVeld1);
			A1.Afmeting = new Size(2, 1);
			A1.Kleur = Color.Cyan;
			A1.Positie = new Point(1, 1);
			A1.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A2 = new Auto(speelVeld1);
			A2.Afmeting = new Size(2, 2);
			A2.Kleur = Color.Red;
			A2.Positie = new Point(1, 2);
			A2.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;
			speelVeld1.DoelAuto = A2;

			Auto A3 = new Auto(speelVeld1);
			A3.Afmeting = new Size(2, 1);
			A3.Kleur = Color.Cyan;
			A3.Positie = new Point(1, 4);
			A3.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A4 = new Auto(speelVeld1);
			A4.Afmeting = new Size(1, 2);
			A4.Kleur = Color.Cyan;
			A4.Positie = new Point(3, 2);
			A4.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A5 = new Auto(speelVeld1);
			A5.Afmeting = new Size(2, 1);
			A5.Kleur = Color.Cyan;
			A5.Positie = new Point(4, 1);
			A5.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A6 = new Auto(speelVeld1);
			A6.Afmeting = new Size(2, 1);
			A6.Kleur = Color.Cyan;
			A6.Positie = new Point(4, 4);
			A6.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A7 = new Auto(speelVeld1);
			A7.Afmeting = new Size(1, 1);
			A7.Kleur = Color.Pink;
			A7.Positie = new Point(4, 2);
			A7.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A8 = new Auto(speelVeld1);
			A8.Afmeting = new Size(1, 1);
			A8.Kleur = Color.Pink;
			A8.Positie = new Point(5, 2);
			A8.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A9 = new Auto(speelVeld1);
			A9.Afmeting = new Size(1, 1);
			A9.Kleur = Color.Pink;
			A9.Positie = new Point(4, 3);
			A9.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;

			Auto A10 = new Auto(speelVeld1);
			A10.Afmeting = new Size(1, 1);
			A10.Kleur = Color.Pink;
			A10.Positie = new Point(5, 3);
			A10.Bewegingen = Auto.vrijheden.Horizontaal | Auto.vrijheden.Verticaal;
			
			speelVeld1.LevelUitgespeeld += speelVeld1_LevelUitgespeeld;
		}

		void speelVeld1_LevelUitgespeeld(object sender, LevelUitgespeeldEventArgs e)
		{
			MessageBox.Show("U hebt level " + e.LevelNummer.ToString() + " uitgespeeld");
		}

        private void btnDelen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HttpWebRequest ftpRequest = (HttpWebRequest)WebRequest.Create("https://" + "www.pieterjandeclippel.be/RushHour/upload.php");
                ftpRequest.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                ftpRequest.ContentType = @"application/x-www-form-urlencoded";
                ftpRequest.Method = WebRequestMethods.Http.Post;

                // Upload the file.
                using (FileStream fileStream = File.OpenRead(ofd.FileName))
                {
                    using (Stream ftpStream = ftpRequest.GetRequestStream())
                    {
                        fileStream.CopyTo(ftpStream);
                        ftpStream.Close();
                    }
                    HttpWebResponse ftpResponse = (HttpWebResponse)ftpRequest.GetResponse();
                    MessageBox.Show(Enum.GetName(typeof(FtpStatusCode), ftpResponse.StatusCode));
                    ftpResponse.Close();
                }
            }
        }
        private void getListing(object sender, EventArgs e)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://192.168.0.233/");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpRequest.Credentials = new NetworkCredential("pi", "gt86VrS%34_1F");

            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            MessageBox.Show(reader.ReadToEnd());

            reader.Close();
            response.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string data = "voornaam=Pieterjan&achternaam=DeClippel";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://pieterjandeclippel.be/RushHour/download.php");
            request.Method = WebRequestMethods.Http.Post;
            request.ContentLength = data.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            Stream dataStream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(dataStream);
            writer.Write(data);
            writer.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string result = reader.ReadToEnd();
            MessageBox.Show(result);
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            speelVeld1.Opslaan();
        }

        private void btnOpenen_Click(object sender, EventArgs e)
        {
            speelVeld1.Openen();
        }

        private void btnVorige_Click(object sender, EventArgs e)
        {
            speelVeld1.Level--;
        }

        private void btnVolgende_Click(object sender, EventArgs e)
        {
            speelVeld1.Level++;
        }

		private void button1_Click(object sender, EventArgs e)
		{
			Ontwerpen frm = new Ontwerpen();
			frm.Show();
		}
	}
}
