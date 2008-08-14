using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Borrador
{
	class Program
	{
		static void Main(string[] args)
		{	
			string Directorio = "\\Temp\\";
			DirectoryInfo di = new DirectoryInfo(Directorio);

			while (true){
				Console.Clear();
				Console.WriteLine("Presione Intro antes de enviar cualquier mensaje");
				Console.ReadLine();
				FileInfo[] files = di.GetFiles("*.xml");
				foreach (FileInfo fi in files)
				{
				Borrar:
					try
					{
						fi.Delete();
					}
					catch (Exception e)
					{
						goto Borrar;
					}
				}
			}
		}
	}
}
