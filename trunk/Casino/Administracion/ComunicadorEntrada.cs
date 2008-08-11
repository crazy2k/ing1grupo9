using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using Dinero = System.Decimal;

namespace Administracion
{
	class ComunicadorEntrada : ComunicadorXML
	{

		private int id;
		private string usuario;

		public void Entrar(string id, string usuario, string modo)
		{
			string nombreArchivo = "entradaCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("entradaCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id);
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "modoAcceso", modo);

			Escribir(nombreArchivo, xd, Int32.Parse(id));
		}

		public void AbrirCasino()
		{
			string nombreArchivo = "abrirCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("abrirCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			Escribir(nombreArchivo, xd, id);
		}

		public void PedirInformeRanking(string tipo,
			string cantidad)
		{
			string nombreArchivo = "rankingCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("ranking");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "tipoRanking", tipo);
			AgregarElementoSimple(xd, root, "longitud", cantidad);
			
			Escribir(nombreArchivo, xd, id);
		}

		public void PedirMovimientosPorJugador(string nombreJugador)
		{
			string nombreArchivo = "movimientosJugador";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("movimientoJugador");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "jugador", nombreJugador);

			Escribir(nombreArchivo, xd, id);
		}

		public ComunicadorEntrada()
		{
			// Ruta de los directorios de los que se leerán los mensajes.
			string a = "\\Temp";

			string[] dirs = new string[] {a};
			this.Dirs = dirs;
		}

		public override void Interpretar(string mensajeSinCaps,
			XmlDocument xmld)
		{
	/*		switch (mensajeSinCaps)
			{
				case "cerrarcasino":
					DelegarCerrarCasino(xmld);
					break; 
			} */
		}
		public XmlDocument EsperarRespuestaEntrada() {
			while (true)
			{
				foreach (string dir in this.Dirs)
				{
					DirectoryInfo di = new DirectoryInfo(dir);
					FileInfo[] files = di.GetFiles("*.xml");

					foreach (FileInfo fi in files)
					{
						string mensaje = GetMensaje(fi);
						if (mensaje == "respuestaEntradaCasino")
						{
							XmlDocument xmld = new XmlDocument();
							xmld.Load(fi.FullName);
							return xmld;
						}
					}
				}
			}
		}
		public bool LeerRespuestaEntrada(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			XmlNode tr = GetChildNode(root, "aceptado");
			string aceptado = tr.InnerText;
			if (aceptado == "si")
			{
				id = GetIdTerminal(root);
				usuario = GetUsuario(root);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
