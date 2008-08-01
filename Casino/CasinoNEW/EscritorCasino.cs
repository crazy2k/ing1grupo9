// EscritorCasino.cs created with MonoDevelop
// User: pablo at 2:27 PM 7/30/2008
//

using System;
using System.Xml;

namespace CasinoNEW
{
	
	
	public class EscritorCasino
	{
		
		public EscritorCasino()
		{
		}
		
		public void DenegarEntrada(int id, string usuario, string modo,
		                           string motivo) {
		
		}
		
		protected ArchivoXML CrearArchivoXML(string nombreArchivo) {
			return new ArchivoXML(Configuracion.DIRECTORIO_RESPUESTAS_CLIENTE +
			                      nombreArchivo);
		}
		protected class ArchivoXML {
			private string nombre;
			
			public ArchivoXML(string nombreArchivo) {
				nombre = nombreArchivo;
				
				XmlDocument xd = new XmlDocument();
				XmlDeclaration declaration = 
					xd.CreateXmlDeclaration("1.0", "UTF-8", null);
				xd.AppendChild(declaration);
			}
		}
		
		public void AceptarEntrada(int id, string usuario, string modo,
		                           Dinero saldo) {
			string nombreArchivo;
			if (modo == "admin")
				nombreArchivo = "respuestaEntradaCasinoAdmin";
			else
				nombreArchivo = "respuestaEntradaCasino";
			
			XmlDocument d = CrearDocumentoXML(nombreArchivo);
			
			XmlElement root = xd.CreateElement("entradaCasino");
			
			XmlAttribute a1 = xd.CreateAttribute("vTerm");
			a.Value = id.ToString();
			XmlAttribute a2 = xd.CreateAttribute("usuario");
			a.Value = usuario;
			
			root.Attributes.Append(a1);
			root.Attributes.Append(a2);
			
			xd.AppendChild(root);
			
			XmlElement aceptado = xd.CreateElement("aceptado");
			aceptado.InnerText = "si";
			XmlElement modoAcceso = xd.CreateElement("modoAcceso");
			aceptado.InnerText = modo;
			XmlElement saldo = xd.CreateElement("saldo");
			aceptado.InnerText = saldo.ToString();
			XmlElement descripcion = xd.CreateElement("descripcion");
			aceptado.InnerText = "";
			
			root.AppendChild(aceptado);
			root.AppendChild(modoAcceso);
			root.AppendChild(saldo);
			root.AppendChild(descripcion);
		
		}
	}
}
