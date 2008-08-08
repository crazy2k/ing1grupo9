using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Dinero = System.Decimal;

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

		public void InformarRanking(int id, string usuario,
			IList<UsuarioConSaldo> lucs)
		{
			string nombreArchivo = "respuestaRankingCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("ranking");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "si");
			XmlElement jugadores = xd.CreateElement("jugadores");
			root.AppendChild(jugadores);
			foreach (UsuarioConSaldo ucs in lucs)
			{
				XmlElement jugador = xd.CreateElement("jugador");
				jugadores.AppendChild(jugador);

				AgregarElementoSimple(xd, jugador, "nombre",
									  ucs.nombre);
				AgregarElementoSimple(xd, jugador, "monto",
									  ucs.saldo.ToString());
			}

			Escribir(nombreArchivo, xd);
		}

		public void DenegarRankingCasino(int id, string usuario)
		{
			string nombreArchivo = "respuestaRankingCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("ranking");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "no");
			XmlElement jugadores = xd.CreateElement("jugadores");
			root.AppendChild(jugadores);

			Escribir(nombreArchivo, xd);
		}

		public void InformarEstadoActual(int id, string usuario,
			Dinero saldoCasino, IList<UsuarioConSaldo> lucs) {
				string nombreArchivo = "respuestaEstadoActual";

				XmlDocument xd = CrearDocumentoXML();
				XmlElement root = xd.CreateElement("estadoActual");
				xd.AppendChild(root);

				AgregarAtributo(xd, root, "vTerm", id.ToString());
				AgregarAtributo(xd, root, "usuario", usuario);

				AgregarElementoSimple(xd, root, "aceptado", "si");
				AgregarElementoSimple(xd, root, "saldoCasino", 
					saldoCasino.ToString());

				XmlElement jugadores = xd.CreateElement("jugadores");
				root.AppendChild(jugadores);
				foreach (UsuarioConSaldo ucs in lucs)
				{
					XmlElement jugador = xd.CreateElement("jugador");
					jugadores.AppendChild(jugador);

					AgregarElementoSimple(xd, jugador, "nombre",
										  ucs.nombre);
					AgregarElementoSimple(xd, jugador, "saldo",
										  ucs.saldo.ToString());
				}

				Escribir(nombreArchivo, xd);
		}

		public void DenegarEstadoActual(int id, string usuario)
		{
			string nombreArchivo = "respuestaEstadoActual";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("estadoActual");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "no");

			XmlElement saldoCasino = xd.CreateElement("saldoCasino");
			root.AppendChild(saldoCasino);

			XmlElement jugadores = xd.CreateElement("jugadores");
			root.AppendChild(jugadores);

			Escribir(nombreArchivo, xd);
		}
	}
}
