using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Organizador
{
	class Program
	{
		static void Main(string[] args)
		{
			DirectoryInfo[] dia = new DirectoryInfo[] {
				new DirectoryInfo(Configuracion.DIRECTORIO_Lectura_Servidor),
				new DirectoryInfo(Configuracion.DIRECTORIO_Escritura_Servidor)};

			foreach (DirectoryInfo di in dia) {
				FileInfo[] files = di.GetFiles("*.xml");
				foreach (FileInfo fi in files)
				{
		//		Borrar:
					try
					{
						fi.Delete();
					}
					catch (Exception e)
					{
			//			goto Borrar;
					}
				}
			}
			
			Console.WriteLine("Organizando Archivos...");
			Organizador o = new Organizador();
			while (true)
			{
				o.Organizar();				
			}
		}
	}
}
