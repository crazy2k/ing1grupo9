// EscritorCasino.cs created with MonoDevelop
// User: pablo at 2:27 PM 7/30/2008
//

using System;
using System.Collections.Generic;
using System.Xml;
using Dinero = System.Decimal;
using Ficha = System.Decimal;

namespace CasinoNEW
{
	
	
	public class EscritorCasino : EscritorXML
	{
		
		public EscritorCasino()
		{
		}
		
		public void AceptarEntrada(int id, string usuario, string modo,
		                           Dinero saldo, IList<Ficha> fichas) {
			string nombreArchivo;
			//if (modo == "admin")
			//	nombreArchivo = "respuestaEntradaCasinoAdmin";
			//else
			//	nombreArchivo = "respuestaEntradaCasino";
			
			nombreArchivo = "respuestaEntradaCasino";
			
			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("entradaCasino");
			xd.AppendChild(root);
			
			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			
			AgregarElementoSimple(xd, root, "aceptado", "si");
			AgregarElementoSimple(xd, root, "modoAcceso", modo);
			AgregarElementoSimple(xd, root, "saldo", saldo.ToString());

			XmlElement fichasH = xd.CreateElement("fichasHabilitadas");
			root.AppendChild(fichasH);
			foreach (Ficha f in fichas)
				AgregarElementoSimple(xd, fichasH, "valorFicha",
				                      f.ToString());
			
			AgregarElementoSimple(xd, root, "descripcion", "");

			Escribir(nombreArchivo, xd, id);
		}
		
		public void DenegarEntrada(int id, string usuario, string modo,
		                           string motivo) {
			string nombreArchivo = "respuestaEntradaCasino";
			
			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("entradaCasino");
			xd.AppendChild(root);
			
			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			
			AgregarElementoSimple(xd, root, "aceptado", "no");
			AgregarElementoSimple(xd, root, "modoAcceso", modo);
			AgregarElementoSimple(xd, root, "saldo", "");
			AgregarElementoSimple(xd, root, "descripcion", motivo);
			
			Escribir(nombreArchivo, xd, id);
		}

		
		public void AceptarSalida(int id, string usuario) {
			string nombreArchivo = "respuestaSalidaCasino";
			
			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("salidaCasino");
			xd.AppendChild(root);
			
			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			
			AgregarElementoSimple(xd, root, "aceptado", "si");
			AgregarElementoSimple(xd, root, "descripcion", "");
			
			Escribir(nombreArchivo, xd, id);
		}
		
		public void DenegarSalida(int id, string usuario, string motivo) {
			string nombreArchivo = "respuestaSalidaCasino";
			
			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("salidaCasino");
			xd.AppendChild(root);
			
			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			
			AgregarElementoSimple(xd, root, "aceptado", "no");
			AgregarElementoSimple(xd, root, "descripcion", motivo);
			
			Escribir(nombreArchivo, xd, id);
		}
		public void ResponderEstadoCasino(int id, string usuario,
		                                  IList<Jugador> jugadores,
		                                  IList<Observador> observadores,
		                                  IList<Juego> juegos,
		                                  IDictionary<string, Dinero> pozos) {
			string nombreArchivo = "respuestaEstadoCasino";

			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("estadoCasino");
			xd.AppendChild(root);
			
			AgregarAtributo(xd, root, "vTerm", id.ToString());
			AgregarAtributo(xd, root, "usuario", usuario);
			
			XmlElement tagJugadores = xd.CreateElement("jugadores");
			root.AppendChild(tagJugadores);
			foreach (Jugador j in jugadores) {
				// Cambio para que ande con el cliente de la cátedra.
				//XmlElement tagJugador = xd.CreateElement("jugador");
				//AgregarAtributo(xd, tagJugador, "nombre", j.Nombre);
				//tagJugadores.AppendChild(tagJugador);
				AgregarElementoSimple(xd, tagJugadores, "jugador", j.Nombre);
			}
			
			XmlElement tagObservadores = xd.CreateElement("observadores");
			root.AppendChild(tagObservadores);
			foreach (Observador o in observadores) {
				// Cambio para que ande con el cliente de la cátedra.
				//XmlElement tagObservador = xd.CreateElement("observador");
				//AgregarAtributo(xd, tagObservador, "nombre", o.Nombre);
				//tagObservadores.AppendChild(tagObservador);
				AgregarElementoSimple(xd, tagObservadores, "observador",
					o.Nombre);
			}

			XmlElement tagJuegos = xd.CreateElement("juego");
			root.AppendChild(tagJuegos);

			XmlElement tagTragamonedas = xd.CreateElement("tragamonedas");
			tagJuegos.AppendChild(tagTragamonedas);
			AgregarElementoSimple(xd, tagTragamonedas, "pozoProgresivo", "10");
			XmlElement tagMesasTragamonedas = xd.CreateElement("mesasTragamonedas");
			tagTragamonedas.AppendChild(tagMesasTragamonedas);

			foreach (Juego j in juegos) {
				XmlElement tagJuego = xd.CreateElement(j.Nombre.ToLower());
				tagJuegos.AppendChild(tagJuego);
				
				// El protocolo es muy feo en esta parte. Para dados
				// exige <mesasDados> <mesaDados> .. </mesaDados> </mesasDados> 
				// ¿Para qué escribir de nuevo el nombre del juego? Para
				// eso está el árbol de XML.
				string pl = j.Nombre[0].ToString().ToUpper();
				string nombreEnMayus = pl + j.Nombre.Substring(1);
				
				XmlElement tagMesas = xd.CreateElement("mesas" + nombreEnMayus);
				tagJuego.AppendChild(tagMesas);
				
				IList<Mesa> mesas = j.getMesas();
				
				foreach (Mesa m in mesas) {
					XmlElement tagMesa = xd.CreateElement("mesa" +
					                                      nombreEnMayus);
					AgregarAtributo(xd, tagMesa, "id", m.Id.ToString());
					tagMesas.AppendChild(tagMesa);
					
					XmlElement tagMesaJugadores = xd.CreateElement("jugadores");
					tagMesa.AppendChild(tagMesaJugadores);
					
					IList<Jugador> participantes = m.GetParticipantes();
					foreach (Jugador jug in participantes) {
						AgregarElementoSimple(xd, tagMesaJugadores,
						                      "jugador", jug.Nombre);
					}
					
					// Se terminó la generalidad. Lo siguiente es sólo
					// para craps:
					if (j.Nombre.ToLower() == "craps")
						GenerarEstadoMesaCraps(xd, tagMesa, m);
				}
				XmlElement tagPozosCasino = xd.CreateElement("pozos");
				root.AppendChild(tagPozosCasino);

				foreach (KeyValuePair<string, Dinero> kv in pozos)
					AgregarElementoSimple(xd, tagPozosCasino, kv.Key,
						kv.Value.ToString());
			}

			Escribir(nombreArchivo, xd, id);
		}
		
		private void GenerarEstadoMesaCraps(XmlDocument xd, XmlElement tagMesa,
		                                    Mesa m) {
			XmlElement proximoTiro = xd.CreateElement("proximoTiro");
			tagMesa.AppendChild(proximoTiro);
			
			MesaDados md = (MesaDados)m;
			Jugador t = md.Crupier.Tirador;
			AgregarElementoSimple(xd, proximoTiro, "tirador",
			                      t.Nombre);
			string ets = md.Crupier.EsTiroSalida ? "si" : "no";
			AgregarElementoSimple(xd, proximoTiro, "tiroSalida", 
			                      ets);
			string punto = md.Crupier.GetPunto().ToString();
			AgregarElementoSimple(xd, proximoTiro, "punto", punto);
			
			XmlElement ultimoTiro = xd.CreateElement("ultimoTiro");
			tagMesa.AppendChild(ultimoTiro);
			string ultimoTirador = md.Crupier.TiradorAnterior.Nombre;
			AgregarElementoSimple(xd, ultimoTiro, "tirador",
			                      ultimoTirador);
			ResultadoDados rd = md.Crupier.UltimoResultado;
			string ultimoResultado = rd == null ? "" : rd.ToString();
			AgregarElementoSimple(xd, ultimoTiro, "resultado",
						                      ultimoResultado);
		}
		
		public void ResponderEstadoCasinoCerrado(int id, string usuario) { 
			string nombreArchivo = "respuestaEstadoCasino";
			
			XmlDocument xd = CrearDocumentoXML();
			XmlElement root = xd.CreateElement("estadoCasino");
			xd.AppendChild(root);
			
			Escribir(nombreArchivo, xd, id);
		}
	}
}
