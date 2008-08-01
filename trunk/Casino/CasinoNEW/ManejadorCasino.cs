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
		
		public void EntrarCasino(int id, string usuario, string modo) {
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
					// El null es porque el mensaje de AceptarEntrada recibe el
					// saldo como parámetro, y en este caso (por ahora, el
					// del "administrador", no nos interesa.
					escritor.AceptarEntrada(id, usuario, modo, 0);
				}
				catch (AutenticacionException e) {
					string motivo = e.Message;
					escritor.DenegarEntrada(id, usuario, modo, motivo);
				}
			}
		}
		
		public void SalirCasino(int id, string usuario) {
			Casino c = Casino.GetInstance();
			if (!c.EstaAbierto())
				escritor.AceptarSalida(id, usuario);
			else {
				GestionadorUsuarios g = GestionadorUsuarios.GetInstance();
				try {
					g.Desloguear(id, usuario);
					escritor.AceptarSalida(id, usuario);
				}
				catch (DeslogueoException e) {
					string motivo = e.Message;
					escritor.DenegarSalida(id, usuario, motivo);
				}
			}
		}
		
	}
}
