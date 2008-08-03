// EscritorCasino.cs created with MonoDevelop
// User: pablo at 2:27 PM 7/30/2008
//

using System;
using System.Collections.Generic;
using System.Xml;
using Dinero = System.Decimal;
using Ficha = System.Int32;

namespace CasinoNEW
{
	
	
	public class EscritorCasino : Escritor
	{
		
		public EscritorCasino()
		{
		}
		
		public void AceptarEntrada(int id, string usuario, string modo,
		                           Dinero saldo, IList<Ficha> fichas) {
			// TODO: Fichas.
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

			EscribirXML(nombreArchivo, xd);
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
			
			EscribirXML(nombreArchivo, xd);
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
			
			EscribirXML(nombreArchivo, xd);
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
			
			EscribirXML(nombreArchivo, xd);
		}
	}
}
