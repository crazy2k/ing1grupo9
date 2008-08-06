using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoNEW
{
	class EscritorAdministracion : EscritorXML
	{
		public void DenegarCerrarCasino(int id, string usuario)
		{
			string nombreArchivo = "respuestaCerrarCasino";
			
			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("cerrarCasino");
			xd.AppendChild(root);
			
			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			
			AgregarElementoSimple(xd, root, "aceptado", "no");
			
			Escribir(nombreArchivo, xd);
		}

		public void AceptarCerrarCasino(int id, string usuario)
		{
			string nombreArchivo = "respuestaCerrarCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("cerrarCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "si");

			Escribir(nombreArchivo, xd);
		}
	}
}
