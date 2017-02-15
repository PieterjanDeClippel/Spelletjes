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
	public partial class SizeInput : Form
	{
		private SizeInput()
		{
			InitializeComponent();
		}
		
		public static DialogResult ShowDialog(Size pref_size, string title, IWin32Window owner, out Size result)
		{
			result = pref_size;

			SizeInput dlg = new SizeInput();
			dlg.txtWidth.Text = pref_size.Width.ToString();
			dlg.txtHeight.Text = pref_size.Height.ToString();
			dlg.Text = title;

			DialogResult dr = owner == null ? ((Form)dlg).ShowDialog() : ((Form)dlg).ShowDialog(owner);

			if(dr == DialogResult.OK)
			{
				try
				{
					result = new Size(Convert.ToInt32(dlg.txtWidth.Text), Convert.ToInt32(dlg.txtHeight.Text));
				}
				catch (Exception)
				{ }
			}

			return dr;
		}

		public static DialogResult ShowDialog(Size pref_size, string title, out Size result)
		{
			return ShowDialog(pref_size, title, null, out result); // 110
		}
		public static DialogResult ShowDialog(Size pref_size, out Size result)
		{
			return ShowDialog(pref_size, "Afmeting", null, out result); // 100
		}
		public static DialogResult ShowDialog(Size pref_size, IWin32Window owner, out Size result)
		{
			return ShowDialog(pref_size, "Afmeting", owner, out result); // 101
		}
		public static DialogResult ShowDialog(out Size result)
		{
			return ShowDialog(new Size(), "Afmeting", null, out result); // 000
		}
		public static DialogResult ShowDialog(string title, IWin32Window owner, out Size result)
		{
			return ShowDialog(new Size(), title, owner, out result); // 011
		}
		public static DialogResult ShowDialog(IWin32Window owner, out Size result)
		{
			return ShowDialog(new Size(), "Afmeting", owner, out result); // 001
		}
		public static DialogResult ShowDialog(string title, out Size result)
		{
			return ShowDialog(new Size(), title, null, out result); // 010
		}
	}
}
