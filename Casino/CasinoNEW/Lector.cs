// Lector.cs created with MonoDevelop
// User: pablo at 6:12 PM 7/29/2008
//

using System;
using System.IO;

namespace CasinoNEW
{
	
	
	public abstract class Lector
	{
		private string dir;
		
		public Lector()
		{
		}
		
		public string Dir {
			get {
				return dir;
			}
			set {
				dir = value;
			}
		}
		
		public void Leer() {
			DirectoryInfo di = new DirectoryInfo(this.Dir);
			FileInfo[] files = di.GetFiles("*.xml");
			
			foreach (FileInfo fi in files) {
				string mensaje = GetMensaje(fi);
				Interpretar(mensaje, fi);
			}
		}
		
		public string GetMensaje(FileInfo archivo) {
			string nombreArchivo = archivo.Name;
			
			string[] partes = nombreArchivo.Split(new char[] {'.'});
            string completo = partes[0];
            string mensaje = completo.Substring(0, completo.Length - 6);
			
			return mensaje;
		}
		
		public abstract void Interpretar(string mensaje, FileInfo fi);
		
	}
}
