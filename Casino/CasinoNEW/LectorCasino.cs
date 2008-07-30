// LectorCasino.cs created with MonoDevelop
// User: pablo at 12:15 AM 7/30/2008
//

using System;
using System.Xml;
using System.IO;

namespace CasinoNEW
{
	
	public class LectorCasino : Lector
	{
		
		private ManejadorCasino manejador = new ManejadorCasino();

		public LectorCasino()
		{
			// Ruta del directorio del que se leerán los mensajes
			this.Dir = "dirCasino";
		}
		
		public override void Interpretar(string mensaje, FileInfo fi)
		{
			XmlDocument xmld = new XmlDocument();
			xmld.Load(fi.FullName);
			
			switch (mensaje) {
				case "entradaCasino":
					delegarEntradaCasino(xmld);
				break;
			}
		}

		private void delegarEntradaCasino(XmlDocument xmld) {

			XmlElement root = xmld.DocumentElement;
			string sid = root.GetAttribute("vTerm");
			int id = Int32.Parse(sid);

			string usuario = root.GetAttribute("usuario");
			XmlNode ma = root.FirstChild;
			string modo = ma.InnerText;
			
			manejador.entrarCasino(id, usuario, modo);

		}
	}
}
