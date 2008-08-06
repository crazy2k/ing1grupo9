using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace CasinoNEW
{
	/* Clase que representa al lector de los puertos:
	 * - administracion
	 */
	class LectorAdministracion : LectorXML
	{

		private ManejadorAdministracion manejador = 
			new ManejadorAdministracion();

		public LectorAdministracion()
		{
			// Ruta de los directorios de los que se leerán los mensajes.
			string a = Configuracion.DIRECTORIO_administracion;

			string[] dirs = new string[] {a};
			this.Dirs = dirs;
		}

		private void DelegarCerrarCasino(XmlDocument xmld)
		{

			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			manejador.CerrarCasino(id, usuario);
		}

		private void DelegarAbrirCasino(XmlDocument xmld)
		{

			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			manejador.AbrirCasino(id, usuario);
		}

		public override void Interpretar(string mensajeSinCaps,
			XmlDocument xmld)
		{
			switch (mensajeSinCaps)
			{
				case "cerrarcasino":
					DelegarCerrarCasino(xmld);
					break;
				case "abrircasino":
					DelegarAbrirCasino(xmld);
					break;
			}
		}
		
	}
}
