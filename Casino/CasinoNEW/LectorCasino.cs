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
	public class LectorCasino : Lector
	{
		
		private ManejadorCasino manejador = new ManejadorCasino();

		public LectorCasino()
		{
			// Ruta de los directorios de los que se leerán los mensajes.
			string a = Configuracion.DIRECTORIO_accesoYVistaCasino;
			string b = Configuracion.DIRECTORIO_accesoCasinoAdminManip;

			string[] dirs = new string[] {a, b};
			this.Dirs = dirs;
		}
		
		protected int GetIdTerminal(XmlElement e) {
			string sid = e.GetAttribute("vTerm");
			return Int32.Parse(sid);
		}

		protected string GetUsuario(XmlElement e) {
			return e.GetAttribute("usuario");
		}
		
		private void delegarSalidaCasino(XmlDocument xmld) {
			XmlElement root = xmld.DocumentElement;
			
			int id = GetIdTerminal(root);
			string usuario =  GetUsuario(root);
			
			manejador.SalirCasino(id, usuario);
		}
		
		private void delegarEntradaCasino(XmlDocument xmld) {

			XmlElement root = xmld.DocumentElement;
			string sid = root.GetAttribute("vTerm");
			int id = Int32.Parse(sid);

			string usuario = root.GetAttribute("usuario");
			XmlNode ma = root.FirstChild;
			string modo = ma.InnerText;
			
			manejador.EntrarCasino(id, usuario, modo);
		}
		
		public override void Interpretar(string mensaje, FileInfo fi)
		{
			XmlDocument xmld = new XmlDocument();
			xmld.Load(fi.FullName);
			
			switch (mensaje) {
				case "entradaCasino":
				case "entradaCasinoAdmin":
					delegarEntradaCasino(xmld);
				break;
				case "SalidaCasino":
					delegarSalidaCasino(xmld);
				break;
			}
		}
	}
}
