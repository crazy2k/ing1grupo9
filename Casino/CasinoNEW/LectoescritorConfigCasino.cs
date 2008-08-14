// LectorConfigCasino.cs created with MonoDevelop
// User: pablo at 1:56 PM 7/30/2008
//

using System;
using System.IO;
using System.Collections.Generic;
using Dinero = System.Decimal;

namespace CasinoNEW
{
	
	public class LectoescritorConfigCasino
	{
		
		private struct InfoUsuario {
			public string modo;
			public Dinero saldo;
		}
		public bool EsAdmin(string usuario) 
		{
			return (usuarios.ContainsKey(usuario) && usuarios[usuario].modo == "administrador");
		}
		
		public bool EsManip(string usuario)
		{
			return (usuarios.ContainsKey(usuario) && usuarios[usuario].modo == "manipulador");
		}

		private static LectoescritorConfigCasino instance = null;
		
		private IDictionary<string, InfoUsuario> usuarios = 
			new Dictionary<string, InfoUsuario>();
		
		private LectoescritorConfigCasino()
		{
			string nombreArchivo = Configuracion.ARCHIVO_USUARIOS;
			
			CargarDesde(nombreArchivo);
			
		}
		
		public static LectoescritorConfigCasino GetInstance() {
			if (instance == null)
				instance = new LectoescritorConfigCasino();
			return instance;
		}
		
		private void CargarDesde(string nombreArchivo) {
			
			using (StreamReader sr = new StreamReader(nombreArchivo)) {
				string linea;
				
				while ((linea = sr.ReadLine()) != null) {
					string[] partes = linea.Split(new char[] {','});
					LimpiarPartes(partes);
					
					string nombre = partes[0];
					
					InfoUsuario iu = new InfoUsuario();
					iu.modo = partes[1];
					iu.saldo = new Dinero(double.Parse(partes[2]));
					
					usuarios.Add(nombre, iu);
				}
			}
		}
		
		private void LimpiarPartes(string[] partes) {
			int len = partes.Length;
			
			for (int i = 0; i < len; i++) {
				partes[i] = partes[i].Trim();
			}
		}
		
		public Dinero GetSaldo(string usuario) {
			if (usuarios.ContainsKey(usuario) &&
				usuarios[usuario].modo.ToLower() == "jugador")
				return usuarios[usuario].saldo;
			else
				throw new Exception("Jugador no valido");
		}

		public void Actualizar(IList<Jugador> js)
		{
			foreach (Jugador j in js)
				if (usuarios.ContainsKey(j.Nombre))
				{
					InfoUsuario iu = new InfoUsuario();
					iu.modo = "jugador";
					iu.saldo = j.Credito;

					usuarios[j.Nombre] = iu;
				}

            TextWriter tw = new StreamWriter(Configuracion.ARCHIVO_USUARIOS);

			foreach (KeyValuePair<string, InfoUsuario> kv in usuarios)
			{
				tw.WriteLine(kv.Key + "," + kv.Value.modo + "," +
					kv.Value.saldo.ToString());
			}
			tw.Close();
		}

		public void GuardarSaldoCasino(Dinero saldo)
		{
			TextWriter tw =
				new StreamWriter(Configuracion.ARCHIVO_SALDO_CASINO);
			tw.WriteLine(saldo.ToString());
			tw.Close();
		}

	}
}
