using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using grinlib.CommonTools;

namespace GrinMediaInfo
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new frmMain());
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}
	}
}
