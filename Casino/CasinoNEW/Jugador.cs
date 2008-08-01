// Jugador.cs created with MonoDevelop
// User: pablo at 4:07 PM 7/30/2008
//

using System;
using System.Collections.Generic;

namespace CasinoNEW
{
	
	
	public class Jugador
	{
		private string nombre;
		private Dinero credito;
        private List<Apuesta> apuestas = new List<Apuesta>();
		
		public Jugador(string usuario, Dinero saldo)
		{
			nombre = usuario;
			credito = saldo;
		}
		
		public string Nombre {
			get { return nombre; }
			set { nombre = value; }
		}

        public void pagar(Dinero costo)
        {
          //  credito -= costo; despues defino los operadores
        }
        public void cobrar(Dinero ganancia)
        {
          //  credito += ganancia; idem
        }
        public void recibirApuesta(Apuesta a)
        {
            apuestas.Add(a);
        }
	}
}
