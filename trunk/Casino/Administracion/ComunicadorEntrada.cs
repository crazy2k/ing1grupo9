using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using Dinero = System.Decimal;

namespace Administracion
{
	public struct Respuesta
	{
		public bool aceptado;
		public string descripcion;
	}

	public class ComunicadorEntrada : ComunicadorXML
	{

		public Respuesta Entrar(string id, string usuario, string modo)
		{
			string nombreArchivo = "entradaCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("entradaCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id);
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "modoAcceso", modo);

			Escribir(nombreArchivo, xd, Int32.Parse(id));

			//Ahora la respuesta...
			XmlDocument xmlResEntrada = EsperarRespuesta(Int32.Parse(id), 
				usuario, "respuestaEntradaCasino");
			Respuesta res = LeerRespuestaEntrada(Int32.Parse(id), usuario, xmlResEntrada);
			return res;
		}

		public void AbrirCasino(int id, string usuario)
		{
			string nombreArchivo = "abrirCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("abrirCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			Escribir(nombreArchivo, xd, id);
		}


		public ComunicadorEntrada()
		{
			// Ruta de los directorios de los que se leerán los mensajes.
			string a = "\\Temp";

			string[] dirs = new string[] {a};
			this.Dirs = dirs;
		}

		public Respuesta LeerRespuestaEntrada(int id, string usuario, XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;
			
			Respuesta res = new Respuesta();

			res.descripcion = GetTextFromChildNode(root, "descripcion");
			
			string aceptado = GetTextFromChildNode(root, "aceptado");
			res.aceptado = (aceptado == "si");
			
			return res;
		}
	}
}
