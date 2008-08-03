// ManejadorCasino.cs created with MonoDevelop
// User: pablo at 12:14 PM 7/30/2008
//

using System;
using Dinero = System.Decimal;

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
					Dinero saldo = g.Autenticar(id, usuario, modo);

					escritor.AceptarEntrada(id, usuario, modo, saldo,
					                        Casino.GetInstance().GetFichas());
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
