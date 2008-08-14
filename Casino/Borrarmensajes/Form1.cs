using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Borrarmensajes
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void borrar_Click(object sender, EventArgs e)
		{
			string Directorio = "\\Temp\\";
			DirectoryInfo di = new DirectoryInfo(Directorio);
			FileInfo[] files = di.GetFiles("*.xml");
			foreach (FileInfo fi in files)
			{
			Borrar:
				try
				{
					fi.Delete();
				}
				catch (Exception exp)
				{
					goto Borrar;
				}
			}
		}
	}
}