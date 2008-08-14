// Main.cs created with MonoDevelop
// User: pablo at 11:01 29/07/2008
//
using System;
using System.IO;

namespace CasinoNEW
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string Directorio = "\\Temp\\";
			DirectoryInfo di = new DirectoryInfo(Directorio);
			FileInfo[] files = di.GetFiles("*.xml");
			foreach (FileInfo fi in files)
			{
				//	Borrar:
				try
				{
					fi.Delete();
				}
				catch (Exception exp)
				{
					//			goto Borrar;
				}
			}

			Console.WriteLine("Casino Timbalistas");
			Poller p = new Poller();
			p.poll();
			Console.WriteLine("Se rompe todo");
		}
	}
}