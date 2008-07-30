// LectorConfigCasino.cs created with MonoDevelop
// User: pablo at 1:56 PM 7/30/2008
//

using System;
using System.IO;
using System.Collections.Generic;

namespace CasinoNEW
{
	
	
	public class LectorConfigCasino
	{
		private static LectorConfigCasino instance = null;
		private IDictionary<string, string> d = new Dictionary<string, string>();
		
		private LectorConfigCasino()
		{
			string nombreArchivo = Configuracion.ARCHIVO_USUARIOS;
			
			CargarDesde(nombreArchivo);
			
		}
		
		public static LectorConfigCasino GetInstance() {
			if (instance == null)
				instance = new LectorConfigCasino();
			return instance;
		}
		
		private void CargarDesde(string nombreArchivo) {
			
			using (StreamReader sr = new StreamReader(nombreArchivo)) {
				string linea;
				
				while ((linea = sr.ReadLine()) != null) {
					string[] partes = linea.Split(new char[] {','});
					LimpiarPartes(partes);
					
					string nombre = partes[0];
					string modo = partes[1];
					
					Agregar(nombre, modo);
				}
			}
		}
		
		private void Agregar(string nombre, string modo) {
			d.Add(nombre, modo);
		}
		
		private void LimpiarPartes(string[] partes) {
			int len = partes.Length;
			
			for (int i = 0; i < len; i++) {
				partes[i] = partes[i].Trim();
			}
		}

	}
}
