// Jugador.cs created with MonoDevelop
// User: pablo at 4:07 PM 7/30/2008
//

using System;
using System.Collections.Generic;

using Dinero = System.Decimal;

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
			credito -= costo;
        }
        public void cobrar(Dinero ganancia)
        {
			credito += ganancia;
        }
        public void recibirApuesta(Apuesta a)
        {
			if (a.getValor() > credito)
				throw new Exception("Credito insuficiente.");
            apuestas.Add(a);
        }
	}
}
