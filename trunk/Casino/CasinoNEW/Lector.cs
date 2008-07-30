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
				Leer(fi.Name);
			}
		}
		
		public abstract void Leer(string archivo);
		
	}
}
