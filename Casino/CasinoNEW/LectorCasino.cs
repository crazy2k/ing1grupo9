// LectorCasino.cs created with MonoDevelop
// User: pablo at 12:15 AM 7/30/2008
//

using System;
using System.Xml;

namespace CasinoNEW
{
	
	
	public class LectorCasino : Lector
	{

		public LectorCasino()
		{
			// Ruta del directorio del que se leerán los mensajes
			this.Dir = "dirCasino";
		}
		
		public override void Leer(string nombreArchivo)
        {
            string[] partes = nombreArchivo.Split(new char[] {'.'});
            string completo = partes[0];
            string mensaje = completo.Substring(0, completo.Length - 6);

			string archivo = this.Dir + nombreArchivo;
            XmlDocument xmld = new XmlDocument();
            xmld.Load(archivo);

            switch(mensaje) {
                case "entradaCasino":
                    parsearEntradaCasino(xmld);
                break;
            }
			
        }

        private void parsearEntradaCasino(XmlDocument xmld) {
            XmlElement root = xmld.DocumentElement;
            string id = root.GetAttribute("vTerm");
            string usuario = root.GetAttribute("usuario");
            //XmlElement ma = root.;

        }
	}
}
