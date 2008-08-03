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

		// Diccionario <id, usuario>
		IDictionary<int, string> ids = new Dictionary<int, string>();
		// Diccionario <usuario, modo> (modo es "jugador", "administrador", ...) 
		IDictionary<string, string> modos = new Dictionary<string, string>();
		
		public IList<Jugador> JugadoresActivos
		{
			get{ return jugadoresActivos; }
		}
		
		public IList<Observador> Observadores
		{
			get{ return observadores; }
		}
		
		private GestionadorUsuarios()
		{
			
		}
		
		public static GestionadorUsuarios GetInstance() {
			if (instance == null)
				instance = new GestionadorUsuarios();
			return instance;
		}
		
		public Dinero Autenticar(int id, string usuario, string modo) {
			if (EstaAutenticado(usuario)) {
				throw new AutenticacionException("Ya se encuentra"
				                                 + "autenticado.");
			}
			
			switch (modo) {
			case "jugador":
				Jugador j = IngresarJugador(id, usuario);
				return j.Credito;
			case "administrador":
				IngresarAdministrador(id, usuario);
				return 0;
			default:
				return 0;
			}
		}
		
		public void Desloguear(int id, string usuario) {
			if (!EstaAutenticado(usuario)) {
				throw new DeslogueoException("El usuario no se halla " +
				                             "autenticado");
			}
			
			string modo = modos[usuario];
			switch (modo) {
			case "jugador":
				SacarJugador(id, usuario);
				break;
			case "administrador":
				SacarAdministrador(id, usuario);
				break;
			}
		}
		
		private void IngresarAdministrador(int id, string usuario) {
			// Para los administradores no me piden informes ni nada, así que
			// cuando entra uno que no estaba autenticado, simplemente
			// creo un Administrador nuevo.
			Administrador a = new Administrador(usuario);
			administradores.Add(a);
			
			Agregar(id, usuario, "admin");
		}
		
		private Jugador IngresarJugador(int id, string usuario) {
			Jugador j = GetJugador(usuario, false);
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
				j = nj;
			}
			
			Agregar(id, usuario, "jugador");
			return j;
		}
		
		private void SacarAdministrador(int id, string usuario) {
			Administrador a = GetAdministrador(usuario);
			if (a != null) {
				administradores.Remove(a);
				
				Quitar(id, usuario);
			}
		}
		
		private void SacarJugador(int id, string usuario) {
			Jugador j = GetJugador(usuario, true);
			if (j != null) {
				jugadoresActivos.Remove(j);
				jugadoresInactivos.Add(j);
				
				Quitar(id, usuario);
			}
			else {
				throw new DeslogueoException("El jugador no se encuentra " +
				                             "en la lista de jugadores "
				                             + "activos.");
			}
		}
		
		private void Agregar(int id, string usuario, string modo) {
			ids.Add(id, usuario);
			modos.Add(usuario, modo);
		}
		
		private void Quitar(int id, string usuario) {
			ids.Remove(id);
			modos.Remove(usuario);
		}
		
		private Administrador GetAdministrador(string usuario) {
			foreach (Administrador a in administradores)
				if (a.Nombre == usuario)
					return a;
			return null;
		}
		
		private Jugador GetJugador(string usuario, bool activo) {
			if (activo) {
				foreach (Jugador j in jugadoresActivos)
					if (j.Nombre == usuario)
						return j;
			}
			else {
				foreach (Jugador j in jugadoresInactivos)
					if (j.Nombre == usuario)
						return j;
			}
			return null;
		}
		
		private bool EstaAutenticado(string usuario) {
			return ids.Values.Contains(usuario);
		}
	}
}
