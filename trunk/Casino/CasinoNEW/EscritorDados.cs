using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CasinoNEW
{
	class EscritorDados : EscritorXML
	{

		public void AceptarEntrada(int id, string usuario, int idMesa,
			string descripcion)
		{
			string nombreArchivo = "respuestaEntradaCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("entradaCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "si");
			AgregarElementoSimple(xd, root, "descripcion", descripcion);

			Escribir(nombreArchivo, xd, id);
		}

		public void DenegarEntrada(int id, string usuario, int idMesa,
			string descripcion)
		{
			string nombreArchivo = "respuestaEntradaCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("entradaCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "no");
			AgregarElementoSimple(xd, root, "descripcion", descripcion);

			Escribir(nombreArchivo, xd, id);
		}

		public void AceptarSalida(int id, string usuario, int idMesa,
			string descripcion)
		{
			string nombreArchivo = "respuestaSalidaCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("salidaCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "si");
			AgregarElementoSimple(xd, root, "descripcion", descripcion);

			Escribir(nombreArchivo, xd, id);
		}

		public void DenegarSalida(int id, string usuario, int idMesa,
		string descripcion)
		{
			string nombreArchivo = "respuestaSalidaCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("salidaCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "no");
			AgregarElementoSimple(xd, root, "descripcion", descripcion);

			Escribir(nombreArchivo, xd, id);
		}

		public void NotificarEstado()
		{

		}

		public void ResponderApuestaAceptada(int id, string usuario,
			int idMesa)
		{
			string nombreArchivo = "respuestaApuestaCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("apuestaCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "si");

			Escribir(nombreArchivo, xd, id);
		}

		public void ResponderApuestaDenegada(int id, string usuario,
			int idMesa)
		{
			string nombreArchivo = "respuestaApuestaCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("apuestaCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "no");

			Escribir(nombreArchivo, xd, id);
		}

		/*
		 * public void ResponderTiroAceptado(int id, string usuario,
			int idMesa)
		{
			string nombreArchivo = "respuestaTiroCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("tiroCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "si");

			Escribir(nombreArchivo, xd, id);
		}
		 */

		public void ResponderTiroDenegado(int id, string usuario,
			int idMesa)
		{
			string nombreArchivo = "respuestaTiroCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("tiroCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "no");
			XmlElement resultado = xd.CreateElement("resultado");
			root.AppendChild(resultado);

			Escribir(nombreArchivo, xd, id);
		}



	}
}
