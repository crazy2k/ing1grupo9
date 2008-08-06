// Administrador.cs created with MonoDevelop
// User: pablo at 4:07 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class Administrador : Usuario
	{
		
		public Administrador(string nombre)
		{
		}

		public void CerrarCasino()
		{
			Casino.GetInstance().Cerrar();
		}
	}
}
