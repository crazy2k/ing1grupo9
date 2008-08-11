using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using Dinero = System.Decimal;

namespace Administracion
{
	class ComunicadorAdministracion : ComunicadorXML
	{

		private int id = 8;
		private string usuario = "ocho";

		public override void Interpretar(string mensaje, FileInfo fi)
		{ }

		public override void Interpretar(string mensajeSinCaps,
			XmlDocument xmld) { }

		public void CerrarCasino()
		{
			string nombreArchivo = "cerrarCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("cerrarCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			Escribir(nombreArchivo, xd, id);
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


	}
}
