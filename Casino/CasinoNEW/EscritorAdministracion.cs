using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CasinoNEW
{
	class EscritorAdministracion : EscritorXML
	{

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

		public void AceptarAbrirCasino(int id, string usuario)
		{
			string nombreArchivo = "respuestaAbrirCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("abrirCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "si");

			Escribir(nombreArchivo, xd);
		}

		public void DenegarAbrirCasino(int id, string usuario)
		{
			string nombreArchivo = "respuestaAbrirCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("abrirCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "no");

			Escribir(nombreArchivo, xd);
		}
	}
}
