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
		
		private LectoescritorConfigCasino lconfig = LectoescritorConfigCasino.GetInstance();
		
		IList<Jugador> jugadoresActivos = new List<Jugador>();
		IList<Jugador> jugadoresInactivos = new List<Jugador>();
		IList<Administrador> administradores = new List<Administrador>();
		IList<Observador> observadores = new List<Observador>();
		IList<Manipulador> manipuladores = new List<Manipulador>();

		// Diccionario <id, usuario>
		IDictionary<int, string> ids = new Dictionary<int, string>();
		// Diccionario <usuario, modo> (modo es "jugador", "administrador", ...) 
		IDictionary<string, string> modos = new Dictionary<string, string>();
		
		public void Reset(){
//			ids.Clear();
//			modos.Clear();
			foreach (int ident in ids.Keys)
			{
				if (modos[ids[ident]] == "jugador")
				{
					modos.Remove(ids[ident]);
					ids.Remove(ident);
				}
			}
			jugadoresActivos.Clear();
			jugadoresInactivos.Clear();
//			administradores.Clear();
			observadores.Clear();
//			manipuladores.Clear();
		}
		
		public int GetId(string usuario){
			if ( ! ids.Values.Contains(usuario)) 
				throw new Exception("El usuario no se encuentra en el casino");
			foreach (int id in ids.Keys){
				if (ids[id] == usuario) return id;
			}
			return -1;
		}
		
		public IList<Jugador> JugadoresActivos
		{
			get{ return jugadoresActivos; }
		}

		public IList<Jugador> JugadoresInactivos
		{
			get { return jugadoresInactivos; }
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
				                                 + " autenticado.");
			}
			
			switch (modo) {
			case "jugador":
				Jugador j = IngresarJugador(id, usuario);
				return j.Credito;
			case "administrador":
				IngresarAdministrador(id, usuario);
				return 0;
			case "manipulador":
				IngresarManipulador(id, usuario);
				return 0;
			case "observador":
				throw new Exception("El sistema no se encuentra preparado para observadores");
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
			case "manipulador":
				SacarManipulador(id, usuario);
				break;
			}
		}
		
		private void IngresarAdministrador(int id, string usuario) {
			// Para los administradores no me piden informes ni nada, así que
			// cuando entra uno que no estaba autenticado, simplemente
			// creo un Administrador nuevo.
			if (!lconfig.EsAdmin(usuario))
				throw new AutenticacionException("El usuario no es un administrador valido del sistema.:`(");
			Administrador a = new Administrador(usuario);
			administradores.Add(a);
			
			Agregar(id, usuario, "administrador");
		}

		private void IngresarManipulador(int id, string usuario)
		{
			// Para los manipuladores no me piden informes ni nada, así que
			// cuando entra uno que no estaba autenticado, simplemente
			// creo un Manipulador nuevo.
			if (!lconfig.EsManip(usuario))
				throw new AutenticacionException("El usuario no es un manipulador valido del sistema.:`(");
			Manipulador m = new ManipuladorDados(usuario);
			manipuladores.Add(m);

			Agregar(id, usuario, "manipulador");
		}
		
		private Jugador IngresarJugador(int id, string usuario) {
			Jugador j = GetJugador(usuario, false);
			// El jugador ya ingresó hoy.
			if (j != null) {
				Agregar(id, usuario, "jugador");
				jugadoresInactivos.Remove(j);
			}
			// EL jugador no ingresó hoy.
			else {
				Dinero saldo = lconfig.GetSaldo(usuario);
				Jugador nj = new Jugador(usuario, saldo);
				j = nj;
				Agregar(id, usuario, "jugador");
			}
			jugadoresActivos.Add(j);
			return j;
		}
		
		private void SacarAdministrador(int id, string usuario) {
			Administrador a = GetAdministrador(usuario);
			if (a != null) {
				administradores.Remove(a);
				
				Quitar(id, usuario);
			}
		}

		private void SacarManipulador(int id, string usuario)
		{
			Manipulador m = GetManipulador(usuario);
			if (m != null)
			{
				manipuladores.Remove(m);
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
			if (ids.ContainsKey(id))
				throw new Exception("Esta terminal ya se ancuentra en uso");
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

		private Manipulador GetManipulador(string usuario)
		{
			foreach (Manipulador m in manipuladores)
				if (m.Nombre == usuario)
					return m;
			return null;
		}

		public Administrador GetAdmin(string usuario)
		{
			Administrador a = GetAdministrador(usuario);
			if (a != null)
				return a;
			else
			throw new NoAdministradorException();
		}

		public Manipulador GetManip(string usuario)
		{
			Manipulador m = GetManipulador(usuario);
			if (m != null)
				return m;

			throw new NoManipuladorException();
		}
		public Jugador GetJugador(string usuario){
			Jugador j = GetJugador(usuario, true);
			if (j == null) throw new Exception("Jugador invalido");
			return j;
		}
		
		public Jugador GetJugador(string usuario, bool activo) {
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
		public void CheckID(int id, string usuario)
		{
			KeyValuePair<int,string> kv =
				new KeyValuePair<int,string>(id,usuario);
			if (!ids.Contains(kv))
				throw new Exception("Usuario no admitido en esta terminal");

		}

		public void ActualizarLista()
		{
			lconfig.Actualizar(JugadoresInactivos);
		}

		public void GuardarSaldoCasino()
		{
			lconfig.GuardarSaldoCasino(Casino.GetInstance().getSaldoActual());
		}
	}
}
