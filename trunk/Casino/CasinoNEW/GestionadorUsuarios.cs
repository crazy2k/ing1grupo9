// GestionadorUsuarios.cs created with MonoDevelop
// User: pablo at 12:24 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class GestionadorUsuarios
	{
		private static GestionadorUsuarios instance = null;
		
		private LectorConfigCasino lconfig = LectorConfigCasino.GetInstance();
		
		private GestionadorUsuarios()
		{
			
		}
		
		public static GestionadorUsuarios GetInstance() {
			if (instance == null)
				instance = new GestionadorUsuarios();
			return instance;
		}
		
		public void Autenticar(int id, string usuario, string modo) {
			
		}
		
	}
}
