// Jugador.cs created with MonoDevelop
// User: pablo at 4:07 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class Jugador
	{
		private string nombre;
		private Dinero credito;
		
		public Jugador(string usuario, Dinero saldo)
		{
			nombre = usuario;
			credito = saldo;
		}
		
		public string Nombre {
			get { return nombre; }
			set { nombre = value; }
		}
	}
}
