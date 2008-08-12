// Lector.cs created with MonoDevelop
// User: pablo at 6:12 PM 7/29/2008
//

using System;
using System.IO;

namespace Administracion
{
	
	
	public abstract class Comunicador
	{
		private string[] dirs = new string[] { "\\Temp\\" };
		
		public Comunicador()
		{
		}
		
		public string[] Dirs {
			get {
				return dirs;
			}
			set {
				dirs = value;
			}
		}
		
		
		public string GetMensaje(FileInfo archivo) {
			string nombreArchivo = archivo.Name;
			
			string[] partes = nombreArchivo.Split(new char[] {'.'});
            string completo = partes[0];
            string mensaje = completo.Substring(0, completo.Length - 6);
			
			return mensaje;
		}
		public string GetGrupo(FileInfo archivo)
		{
			string nombreArchivo = archivo.Name;

			string[] partes = nombreArchivo.Split(new char[] { '.' });
			string completo = partes[0];
			string mensaje = completo.Substring(completo.Length - 6, 2);

			return mensaje;
		}
		public string GetTerminal(FileInfo archivo)
		{
			string nombreArchivo = archivo.Name;

			string[] partes = nombreArchivo.Split(new char[] { '.' });
			string completo = partes[0];
			string mensaje = completo.Substring(completo.Length - 4, 4);

			return mensaje;
		}
		
		private string directorioEscritura =
		"\\Temp\\Servidor\\";

		protected string DirectorioEscritura
		{
			get { return directorioEscritura; }
		}
		protected abstract void Escribir(string nombreArchivo, Object o,
			int idTerminal);
		
	}
}
