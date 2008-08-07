using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using Dinero = System.Decimal;



namespace CasinoNEW
{
	public struct UsuarioConSaldo
	{
		public string nombre;
		public Dinero saldo;
	}

	public class GeneradorInformes
	{
		public IList<UsuarioConSaldo> Ranking(string tipoRanking,
			int longitud)
		{
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();

			// Horrible, pero no queda otra.
			List<Jugador> js = (List<Jugador>)g.JugadoresInactivos;
	
			js.Sort(delegate(Jugador j1, Jugador j2) {
				return j1.Credito.CompareTo(j2.Credito); });

			tipoRanking = tipoRanking.ToLower();

			if (tipoRanking == "ganadores")
				js.Reverse();
			
			// Le quito los elementos que no necesito devolver.
			js.RemoveRange(longitud, js.Count - 1);

			IList<UsuarioConSaldo> lucs = ToWritable(js);

			return lucs;
		}

		private IList<UsuarioConSaldo> ToWritable(IList<Jugador> js)
		{
			IList<UsuarioConSaldo> lucs = new List<UsuarioConSaldo>();
			foreach (Jugador j in js) {
				UsuarioConSaldo ucs = new UsuarioConSaldo();
				ucs.nombre = j.Nombre;
				ucs.saldo = j.Credito;

				lucs.Add(ucs);
			}

			return lucs;
		}



	}
}
