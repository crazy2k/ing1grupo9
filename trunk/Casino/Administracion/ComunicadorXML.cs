using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Administracion
{
	public abstract class ComunicadorXML : Comunicador
	{
		protected int GetIdTerminal(XmlElement e) {
			string sid = e.GetAttribute("vTerm");
			return Int32.Parse(sid);
		}

		protected string GetUsuario(XmlElement e) {
			return e.GetAttribute("usuario");
		}

		public XmlElement GetChildNode(XmlElement root, string nombreTag)
		{
			foreach (XmlElement e in root.ChildNodes)
			{
				if (e.Name == nombreTag)
					return e;
			}
			return null;
		}

		public string GetTextFromChildNode(XmlElement root, string nombreTag)
		{
			return GetChildNode(root, nombreTag).InnerText;
		}

		protected XmlDocument CrearDocumentoXML()
		{
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
											 string nombre, string valor)
		{
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
										   string nombre, string contenido)
		{
			XmlElement elemento = d.CreateElement(nombre);
			elemento.InnerText = contenido;
			e.AppendChild(elemento);

			return elemento;
		}

		protected override void Escribir(string nombreArchivo, Object o,
			int id)
		{
			XmlDocument d = (XmlDocument)o;
			// Acá asumo que ninguna terminal virtual tiene un id
			// de más de 4 dígitos.
			string idTerminal = id.ToString().PadLeft(4, '0');
			string numeroDeGrupo =
				Configuracion.NUMERO_GRUPO.ToString().PadLeft(2, '0');
			d.Save(this.DirectorioEscritura + nombreArchivo + numeroDeGrupo +
				idTerminal + ".xml");
		}

		protected Respuesta LeerRespuestaGenerico(int id, string usuario, XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			Respuesta res = new Respuesta();

			res.descripcion = "";

			string aceptado = GetTextFromChildNode(root, "aceptado");
			res.aceptado = (aceptado == "si");

			return res;
		}
		
		public XmlDocument EsperarRespuesta(int id, string usuario, string tag)
		{
			while (true)
			{
				foreach (string dir in this.Dirs)
				{
					DirectoryInfo di = new DirectoryInfo(dir);
					FileInfo[] files = di.GetFiles("*.xml");

					foreach (FileInfo fi in files)
					{
						string mensaje = GetMensaje(fi);
						string idTerminal = GetTerminal(fi);
						string idGrupo = GetGrupo(fi);
						if (mensaje == tag && Int32.Parse(idTerminal) == id
							&& Int32.Parse(idGrupo) == Configuracion.NUMERO_GRUPO)
						{
							XmlDocument xmld = new XmlDocument();
						IntentarLeer:
							try
							{
								xmld.Load(fi.FullName);
							}
							catch (Exception e)
							{
								goto IntentarLeer;
							}
						IntentarBorrar:
							try
							{
								fi.Delete();
							}
							catch (Exception e) {
								goto IntentarBorrar;
							}
							return xmld;
						}
					}
				}
			}
		}
	}
}
