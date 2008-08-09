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

			Escribir(nombreArchivo, xd, id);
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

			Escribir(nombreArchivo, xd, id);
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

			Escribir(nombreArchivo, xd, id);
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

			Escribir(nombreArchivo, xd, id);
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

			Escribir(nombreArchivo, xd, id);
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

			Escribir(nombreArchivo, xd, id);
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

				Escribir(nombreArchivo, xd, id);
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

			Escribir(nombreArchivo, xd, id);
		}

		public void InformarMovimientosPorJugador(int id, string usuario,
			IList<ValorPremios> lvps)
		{
			string nombreArchivo = "respuestaMovimientosJugador";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("movimientoJugador");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "si");

			XmlElement apuestas = xd.CreateElement("apuestas");
			root.AppendChild(apuestas);
			foreach (ValorPremios vps in lvps)
			{
				XmlElement apuesta = xd.CreateElement("apuesta");
				apuestas.AppendChild(apuesta);

				AgregarElementoSimple(xd, apuesta, "montoApostado",
					vps.valorApuesta.ToString());
				AgregarElementoSimple(xd, apuesta, "premioFeliz",
					vps.montos.montoFeliz.ToString());
				AgregarElementoSimple(xd, apuesta, "descuentoTP",
					vps.montos.montoTodosPonen.ToString());
				AgregarElementoSimple(xd, apuesta, "montoGanado",
					vps.montos.premioJugada.ToString());
			}
			Escribir(nombreArchivo, xd, id);
		}

		public void DenegarMovimientosPorJugador(int id, string usuario)
		{
			string nombreArchivo = "respuestaMovimientosJugador";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("movimientoJugador");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "aceptado", "no");

			XmlElement apuestas = xd.CreateElement("apuestas");
			root.AppendChild(apuestas);

			Escribir(nombreArchivo, xd, id);
		}

	}
}
