using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CasinoNEW
{
	class EscritorManipulacion : EscritorXML
	{
		public void AceptarManipulacionDados(int id, string usuario)
		{
			string nombreArchivo = "respuestaManipulacionDados";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("manipulacionDados");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "si");

			Escribir(nombreArchivo, xd, id);
		}

		public void DenegarManipulacionDados(int id, string usuario)
		{
			string nombreArchivo = "respuestaManipulacionDados";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("manipulacionDados");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "no");

			Escribir(nombreArchivo, xd, id);
		}
	}
}
