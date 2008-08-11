using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Administracion
{
	class ComunicadorManipulacionDados : ComunicadorXML
	{
		public Respuesta ManipularDados(int id, string usuario,
			string tipoJugada, string dado1, string dado2)
		{
			string nombreArchivo = "manipularDados";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("manipularDados");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "resultado", dado1 + "," + dado2);
			AgregarElementoSimple(xd, root, "tipoDeJugada", tipoJugada);

			Escribir(nombreArchivo, xd, id);

			//Ahora la respuesta:
			XmlDocument xmlResManip = EsperarRespuesta(id,
				usuario, "respuestaManipulacionDados");
			Respuesta res = LeerRespuestaManipulacion(id, usuario, xmlResManip);
			return res;
		}

		public Respuesta LeerRespuestaManipulacion(int id, string usuario, XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			Respuesta res = new Respuesta();

			res.descripcion = "";

			string aceptado = GetTextFromChildNode(root, "aceptado");
			res.aceptado = (aceptado == "si");

			return res;
		}
	}
			
}
