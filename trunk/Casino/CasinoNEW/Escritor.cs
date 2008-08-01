// Escritor.cs created with MonoDevelop
// User: pablo at 4:06 PM 8/1/2008
//

using System;
using System.Xml;

namespace CasinoNEW
{
	
	
	public abstract class Escritor
	{
		
		private string directorioEscritura = 
			Configuracion.DIRECTORIO_RESPUESTAS_CLIENTE;
		
		public Escritor()
		{
		}
		
		protected XmlDocument CrearDocumentoXML() {
			// Crear documento.
			XmlDocument xd = new XmlDocument();
			// Agregar declaración XML.
			XmlDeclaration declaration = 
				xd.CreateXmlDeclaration("1.0", "UTF-8", null);
			xd.AppendChild(declaration);
			return xd;
		}
				
		/*
		 * Agrega un atributo al elemento "e" con el nombre "nombre" y 
		 * el valor "valor". Usa el documento "d" para crear el atributo. (Esto
		 * último es así porque la biblioteca de XML es un asco.)
		 * 
		 * Se devuelve el atributo por si alguien lo precisa.
		 */
		protected XmlAttribute AgregarAtributo(XmlDocument d, XmlElement e,
		                                     string nombre, string valor) {
			XmlAttribute a = d.CreateAttribute(nombre);
			a.Value = valor;
			e.Attributes.Append(a);
			
			return a;
		}
		
		/*
		 * Agrega un elemento de nombre "nombre" sin atributos (eso significa 
		 * "simple") y con el contenido "contenido" dentro del elemento "e".
		 * Usa el documento "d" para crear el elemento. (Esto último se precisa
		 * porque la biblioteca de XML es un asco.)
		 * 
		 * Se devuelve el elemento por si alguien lo precisa.
		 */
		protected XmlElement AgregarElementoSimple(XmlDocument d, XmlElement e, 
		                                   string nombre, string contenido) {
			XmlElement elemento = d.CreateElement(nombre);
			elemento.InnerText = contenido;
			e.AppendChild(elemento);
			
			return elemento;
		}
		
		protected void EscribirXML(string nombreArchivo, XmlDocument d) {
			d.Save(directorioEscritura + nombreArchivo + ".xml");
		}

	}
}
