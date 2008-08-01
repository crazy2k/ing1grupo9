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
			if ((modo == "jugador" || modo == "manipulador" || 
			     modo == "observador") && (!c.EstaAbierto())) {
				string motivo = "El casino se halla cerrado en este momento.";
				escritor.DenegarEntrada(id, usuario, modo, motivo);
			}
			
			else {
				GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
				try { 
					g.Autenticar(id, usuario, modo);
					// El cero es porque el mensaje de AceptarEntrada recibe el
					// saldo como parámetro, y en este caso (por ahora, el
					// del "administrador", no nos interesa.
					// Como ahora 
					escritor.AceptarEntrada(id, usuario, modo, 0);
				}
				catch (AutenticacionException e) {
					string motivo = e.Message;
					escritor.DenegarEntrada(id, usuario, modo, motivo);
				}
			}
		}
	}
}
