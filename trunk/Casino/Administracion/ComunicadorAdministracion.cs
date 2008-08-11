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

		public Respuesta CerrarCasino(int id, string usuario)
		{
			string nombreArchivo = "cerrarCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("cerrarCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			Escribir(nombreArchivo, xd, id);

			//Ahora la respuesta:
			XmlDocument xmlResCerrar = EsperarRespuesta(id,
				usuario, "respuestaCerrarCasino");
			Respuesta res = LeerRespuestaCerrar(id, usuario, xmlResCerrar);
			return res;
		}

		public Respuesta AbrirCasino(int id, string usuario)
		{
			string nombreArchivo = "abrirCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("abrirCasino");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			Escribir(nombreArchivo, xd, id);
			//Ahora la respuesta:
			XmlDocument xmlRes = EsperarRespuesta(id,
				usuario, "respuestaAbrirCasino");
			Respuesta res = LeerRespuestaAbrir(id, usuario, xmlRes);
			return res;
		}

		public Respuesta PedirInformeRanking(int id, string usuario, string tipo,
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
			//Ahora la respuesta:
			XmlDocument xmlRes = EsperarRespuesta(id,
				usuario, "respuestaRankingCasino");
			Respuesta res = LeerRespuestaRanking(id, usuario, xmlRes);
			return res;
		}

		public Respuesta PedirMovimientosPorJugador(int id, string usuario, string nombreJugador)
		{
			string nombreArchivo = "movimientosJugador";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("movimientoJugador");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			AgregarElementoSimple(xd, root, "jugador", nombreJugador);

			Escribir(nombreArchivo, xd, id);
			//Ahora la respuesta:
			XmlDocument xmlRes = EsperarRespuesta(id,
				usuario, "respuestaMovimientosJugador");
			Respuesta res = LeerRespuestaMovimientos(id, usuario, xmlRes);
			return res;
		}
		
		public Respuesta PedirInformeEstadoCasino(int id, string usuario)
		{
			string nombreArchivo = "informeEstadoActual";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("estadoActual");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);

			Escribir(nombreArchivo, xd, id);
			//Ahora la respuesta:
			XmlDocument xmlRes = EsperarRespuesta(id,
				usuario, "respuestaEstadoActual");
			Respuesta res = LeerRespuestaEstado(id, usuario, xmlRes);
			return res;
		}



		public Respuesta LeerRespuestaCerrar(int id, string usuario,
			XmlDocument xmld)
		{
			return LeerRespuestaGenerico(id, usuario, xmld);
		}

		public Respuesta LeerRespuestaAbrir(int id, string usuario,
			XmlDocument xmld)
		{
			return LeerRespuestaGenerico(id, usuario, xmld);
		}

		public Respuesta LeerRespuestaRanking(int id, string usuario,
			XmlDocument xmld)
		{
			return LeerRespuestaGenerico(id, usuario, xmld);
		}

		public Respuesta LeerRespuestaMovimientos(int id, string usuario,
			XmlDocument xmld)
		{
			return LeerRespuestaGenerico(id, usuario, xmld);
		}

		public Respuesta LeerRespuestaEstado(int id, string usuario,
			XmlDocument xmld)
		{
			return LeerRespuestaGenerico(id, usuario, xmld);
		}


	}
}
