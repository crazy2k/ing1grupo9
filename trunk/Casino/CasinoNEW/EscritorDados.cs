using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Ficha = System.Decimal;
using Cantidad = System.Int32;



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

		public void NotificarEstado(int id, string usuario, int idMesa,
			IList<Jugador> jugadores, Jugador proxTirador, bool proxTiroSalida,
			int punto, Jugador ultimoTirador, Resultado ultimoResultado,
			Dictionary<Jugador, IList<Premio>> premios,
			IDictionary<Jugador, IList<ApuestaDados>> apuestas)
		{
			string nombreArchivo = "EstadoCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("estadoMesaCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			XmlElement tagJugadores = xd.CreateElement("jugadores");
			root.AppendChild(tagJugadores);
			foreach (Jugador j in jugadores)
			{
				XmlElement tagJugador = xd.CreateElement("jugador");
				AgregarAtributo(xd, tagJugador, "nombre", j.Nombre);
			}

			XmlElement tagProximoTiro = xd.CreateElement("proximoTiro");
			root.AppendChild(tagProximoTiro);
			AgregarElementoSimple(xd, tagProximoTiro, "tirador",
				proxTirador.Nombre);

			string esTiroSalida = (proxTiroSalida) ? "si" : "no";
			AgregarElementoSimple(xd, tagProximoTiro, "tiroSalida",
				esTiroSalida);

			string spunto = (punto != 0) ? punto.ToString() : "";
			AgregarElementoSimple(xd, tagProximoTiro, "punto",
				spunto);

			XmlElement tagUltimoTiro = xd.CreateElement("ultimoTiro");
			root.AppendChild(tagUltimoTiro);

			AgregarElementoSimple(xd, tagUltimoTiro, "tirador",
				ultimoTirador.Nombre);
			AgregarElementoSimple(xd, tagUltimoTiro, "resultado",
				ultimoResultado.ToString());

			XmlElement tagPremios = xd.CreateElement("premios");
			tagUltimoTiro.AppendChild(tagPremios);
			foreach (KeyValuePair<Jugador, IList<Premio>> jlp in premios) {
				foreach (Premio p in jlp.Value) {
					XmlElement tagPremio = xd.CreateElement("premio");
					tagPremios.AppendChild(tagPremio);

					// TODO: El premio no conoce al ganador. ¿Arreglar?
					AgregarElementoSimple(xd, tagPremio,
						"apostador", jlp.Key.Nombre);

					AgregarElementoSimple(xd, tagPremio, "montoPremioJugada",
						p.MontoPremioJugada.ToString());
					AgregarElementoSimple(xd, tagPremio, "montoPremioJugadaFeliz",
						p.MontoPremioJF.ToString());
					AgregarElementoSimple(xd, tagPremio,
						"montoRetenidoJugadaTodosponen",
						p.MontoRetencionJTP.ToString());
				}
			}

			XmlElement tagApuestasVigentes =
				xd.CreateElement("apuestasVigentes");
			root.AppendChild(tagApuestasVigentes);

			foreach (KeyValuePair<Jugador, IList<ApuestaDados>> kv in apuestas) {
				foreach (ApuestaDados a in kv.Value) {
					XmlElement tagApuesta = xd.CreateElement("apuesta");
					tagApuestasVigentes.AppendChild(tagApuesta);

					string apostador = kv.Key.Nombre;
					AgregarElementoSimple(xd, tagApuesta, "apostador", apostador);

					XmlElement tagOpcionApuesta =
						xd.CreateElement("opcionApuesta");
					tagApuesta.AppendChild(tagOpcionApuesta);
					string tipo = "";
					string puntaje = "";
					if (a is ApuestaPassNoPass) {
						ApuestaPassNoPass ac = (ApuestaPassNoPass)a;
						tipo = (ac.AFavor) ? "pase" : "no pase";
					}
					else if (a is ApuestaVenirNoVenir) {
						ApuestaVenirNoVenir ac = (ApuestaVenirNoVenir)a;
						tipo = (ac.AFavor) ? "venir" : "no venir";
						puntaje = ac.Puntaje.ToString();
					}
					else if (a is ApuestaDeCampo)
					{
						tipo = "campo";
					}
					else if (a is ApuestaGanarEnContra)
					{
						ApuestaGanarEnContra ac = (ApuestaGanarEnContra)a;
						tipo = (ac.AFavor) ? "a ganar" : "en contra";
						puntaje = ac.Puntaje.ToString();
					}
					AgregarElementoSimple(xd, tagOpcionApuesta,
							"tipoApuesta", tipo);

					AgregarElementoSimple(xd, tagOpcionApuesta,
							"puntajeApostado", puntaje);

					XmlElement tagValorApuesta =
						xd.CreateElement("valorApuesta");
					tagApuesta.AppendChild(tagValorApuesta);

					foreach (KeyValuePair<Ficha, Cantidad> f in a.Fichas)
					{
						XmlElement tagFichaValor =
							xd.CreateElement("fichaValor");
						tagValorApuesta.AppendChild(tagFichaValor);

						AgregarElementoSimple(xd, tagFichaValor, "cantidad",
							f.Value.ToString());
						AgregarElementoSimple(xd, tagFichaValor, "valor",
							f.Key.ToString());
					}
				}
			}


			Escribir(nombreArchivo, xd, id);
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

			public void ResponderTiroAceptado(int id, string usuario,
				int idMesa, int dado1, int dado2, TipoJugada tj)
		{
			string nombreArchivo = "respuestaTiroCraps";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("tiroCraps");
			xd.AppendChild(root);

			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			AgregarAtributo(xd, root, "mesa", idMesa.ToString());

			AgregarElementoSimple(xd, root, "aceptado", "si");
			string tipoJugada = "";
			if (tj == TipoJugada.Feliz)
				tipoJugada = "feliz";
			else if (tj == TipoJugada.Normal)
				tipoJugada = "normal";
			else if (tj == TipoJugada.TodosPonen)
				tipoJugada = "todosponen";

			AgregarElementoSimple(xd, root, "tipoJugada", tipoJugada);

			XmlElement resultado = xd.CreateElement("resultado");
			root.AppendChild(resultado);

			AgregarElementoSimple(xd, resultado, "dado1", dado1.ToString());
			AgregarElementoSimple(xd, resultado, "dado2", dado2.ToString());

			Escribir(nombreArchivo, xd, id);
		}

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
