using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rush_Hour
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            string map = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Spelletjes/Rush Hour/";
            if (!Directory.Exists(map)) Directory.CreateDirectory(map);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Spelen());
		}
	}
}
