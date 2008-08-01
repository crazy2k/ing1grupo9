// EscritorCasino.cs created with MonoDevelop
// User: pablo at 2:27 PM 7/30/2008
//

using System;
using System.Xml;
using Dinero = System.Decimal;

namespace CasinoNEW
{
	
	
	public class EscritorCasino : Escritor
	{
		
		public EscritorCasino()
		{
		}
		
		public void DenegarEntrada(int id, string usuario, string modo,
		                           string motivo) {
		
		}
		
		public void AceptarEntrada(int id, string usuario, string modo,
		                           Dinero saldo) {
			string nombreArchivo;
			if (modo == "admin")
				nombreArchivo = "respuestaEntradaCasinoAdmin";
			else
				nombreArchivo = "respuestaEntradaCasino";
			
			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("entradaCasino");
			xd.AppendChild(root);
			
			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			
			AgregarElementoSimple(xd, root, "aceptado", "si");
			AgregarElementoSimple(xd, root, "modoAcceso", modo);
			AgregarElementoSimple(xd, root, "saldo", saldo.ToString());
			AgregarElementoSimple(xd, root, "descripcion", "");

			EscribirXML(nombreArchivo, xd);
		}
	}
}
