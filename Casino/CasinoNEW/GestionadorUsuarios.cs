// GestionadorUsuarios.cs created with MonoDevelop
// User: pablo at 12:24 PM 7/30/2008
//

using System;
using System.Collections.Generic;
using Dinero = System.Decimal;

namespace CasinoNEW
{
	
	
	public class GestionadorUsuarios
	{
		private static GestionadorUsuarios instance = null;
		
		private LectorConfigCasino lconfig = LectorConfigCasino.GetInstance();
		
		IList<Jugador> jugadoresActivos = new List<Jugador>();
		IList<Jugador> jugadoresInactivos = new List<Jugador>();
		IList<Administrador> administradores = new List<Administrador>();
		IList<Observador> observadores = new List<Observador>();
		IList<Manipulador> manipuladores = new List<Manipulador>();
		
		IDictionary<int, string> ids = new Dictionary<int, string>();
		
		public IList<Jugador> JugadoresActivos
		{
			get{ return jugadoresActivos; }
		}
		
		private GestionadorUsuarios()
		{
			
		}
		
		public static GestionadorUsuarios GetInstance() {
			if (instance == null)
				instance = new GestionadorUsuarios();
			return instance;
		}
		
		public void Autenticar(int id, string usuario, string modo) {
			if (EstaAutenticado(usuario)) {
				throw new AutenticacionException("Ya se encuentra autenticado.");
			}
			
			switch (modo) {
			case "jugador":
				IngresarJugador(id, usuario);
				break;
			case "administrador":
				IngresarAdministrador(id, usuario);
				break;
			}
		}
		
		private bool EstaAutenticado(string usuario) {
			return ids.Values.Contains(usuario);
		}
		
		private void IngresarAdministrador(int id, string usuario) {
			// Para los administradores no me piden informes ni nada, así que
			// cuando entra uno que no estaba autenticado, simplemente
			// creo un Administrador nuevo.
			Administrador a = new Administrador(usuario);
			administradores.Add(a);
		}
		
		private void IngresarJugador(int id, string usuario) {
			Jugador j = GetJugadorInactivo(usuario);
			// El jugador ya ingresó hoy.
			if (j != null) {
				jugadoresInactivos.Remove(j);
				jugadoresActivos.Add(j);
			}
			// EL jugador no ingresó hoy.
			else {
				Dinero saldo = lconfig.GetSaldo(usuario);
				Jugador nj = new Jugador(usuario, saldo);
				jugadoresActivos.Add(nj);
			}
		}
		
		private Jugador GetJugadorInactivo(string usuario) {
			foreach (Jugador j in jugadoresInactivos)
				if (j.Nombre == usuario)
					return j;
			return null;
		}
		
		private class JugadorNoIngresoHoyException : ApplicationException { }
		
	}
}
