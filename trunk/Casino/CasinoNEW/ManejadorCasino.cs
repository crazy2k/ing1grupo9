// ManejadorCasino.cs created with MonoDevelop
// User: pablo at 12:14 PM 7/30/2008
//

using System;

namespace CasinoNEW
{
	
	
	public class ManejadorCasino
	{
		private EscritorCasino escritor = new EscritorCasino();
		
		public ManejadorCasino()
		{
		}
		
		public void entrarCasino(int id, string usuario, string modo) {
			Casino c = Casino.GetInstance();
			if (!c.EstaAbierto()) {
				string motivo = "El casino se halla cerrado en este momento.";
				escritor.DenegarEntrada(id, usuario, modo, motivo);
			}
			else {
				AutenticacionUsuario(id, usuario, modo);
			}
		}
		
		private void AutenticacionUsuario(int id, string usuario, string modo) {
			GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
			try { 
				g.Autenticar(id, usuario, modo);
			}
			catch (AutenticacionException e) {
				string motivo = e.Message;
				escritor.DenegarEntrada(id, usuario, modo, motivo);
			}
		}

	}
}
