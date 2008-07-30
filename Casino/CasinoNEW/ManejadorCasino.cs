// ManejadorCasino.cs created with MonoDevelop
// User: pablo at 12:14 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class ManejadorCasino
	{
		
		public ManejadorCasino()
		{
		}
		
		public void entrarCasino(int id, string usuario, string modo) {
			GestionadorUsuarios g = GestionadorUsuarios.getInstance();
			g.autenticar(id, usuario, modo);
		}
	}
}
