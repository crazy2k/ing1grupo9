// LectorCasino.cs created with MonoDevelop
// User: pablo at 12:15 AM 7/30/2008
//

using System;
using System.Xml;
using System.IO;

namespace CasinoNEW
{
	
	/* Clase que representa al lector de los puertos:
	 * - accesoYVistaCasino
	 * - accesoCasinoAdminManip
	 */
	public class LectorCasino : LectorXML
	{
		
		private ManejadorCasino manejador = new ManejadorCasino();

		public LectorCasino()
		{
			// Ruta de los directorios de los que se leerán los mensajes.
			string a = Configuracion.DIRECTORIO_Lectura;
			//string b = Configuracion.DIRECTORIO_accesoCasinoAdminManip;

			string[] dirs = new string[] {a}; //{a, b};
			this.Dirs = dirs;
		}
		
		private void DelegarEntradaCasino(XmlDocument xmld) {

			XmlElement root = xmld.DocumentElement;
			
			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			XmlNode ma = root.FirstChild;
			string modo = ma.InnerText;
			
			manejador.EntrarCasino(id, usuario, modo);
		}
		
		private void DelegarSalidaCasino(XmlDocument xmld) {
			XmlElement root = xmld.DocumentElement;
			
			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);
			
			manejador.SalirCasino(id, usuario);
		}
		
		private void DelegarEstadoCasino(XmlDocument xmld) {
			XmlElement root = xmld.DocumentElement;
			
			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);
			
			manejador.PedirEstadoCasino(id, usuario);
		}
		
		
		public override bool Interpretar(string mensajeSinCaps,
			XmlDocument xmld)
		{
			switch (mensajeSinCaps) {
				case "entradacasino":
				//case "entradacasinoadmin":
					DelegarEntradaCasino(xmld);
					return true;
				case "salidacasino":
				//case "salidacasinoadmin":
					DelegarSalidaCasino(xmld);
					return true;
				case "pedidoestadocasino":
					DelegarEstadoCasino(xmld);
					return true;
			}
			return false;
		}
	}
}
