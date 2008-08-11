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

	
		private void DelegarRankingCasino(XmlDocument xmld)
		{

			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			XmlNode tr = GetChildNode(root, "tipoRanking");
			string tipoRanking = tr.InnerText;

			XmlNode l = GetChildNode(root, "longitud");
			int longitud = Int32.Parse(l.InnerText);

			manejador.PedirRankingCasino(id, usuario, tipoRanking, longitud);
		}

		private void DelegarEstadoActualCasino(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			manejador.PedirEstadoActual(id, usuario);
		}

		private void DelegarMovimientosPorJugador(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			XmlNode j = GetChildNode(root, "jugador");
			string jugador = j.InnerText;

			manejador.PedirMovimientosPorJugador(id, usuario, jugador);
		}

		public override bool Interpretar(string mensajeSinCaps,
			XmlDocument xmld)
		{
			switch (mensajeSinCaps)
			{
				case "cerrarcasino":
					DelegarCerrarCasino(xmld);
					return true;
				case "abrircasino":
					DelegarAbrirCasino(xmld);
					return true;
				case "rankingcasino":
					DelegarRankingCasino(xmld);
					return true;
				case "informeestadoactual":
					DelegarEstadoActualCasino(xmld);
					return true;
				case "movimientosjugador":
					DelegarMovimientosPorJugador(xmld);
					return true;
			}
			return false;
		}
		
	}
}
