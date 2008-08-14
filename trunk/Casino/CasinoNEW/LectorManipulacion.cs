using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace CasinoNEW
{
	class LectorManipulacion : LectorXML
	{

		private ManejadorManipulacion manejador =
			new ManejadorManipulacion();

		public LectorManipulacion()
		{
			string a = Configuracion.DIRECTORIO_Lectura;
			
			string[] dirs = new string[]{a};
			this.Dirs = dirs;
		}

		private void DelegarManipularDados(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			XmlNode r = GetChildNode(root, "resultado");
			// dado1,dado2
			string resultado = r.InnerText;

			string[] partes = resultado.Split(new char[] {','});
			int dado1 = Int32.Parse(partes[0].Trim());
			int dado2 = Int32.Parse(partes[1].Trim());

			string stj = GetChildNode(root, "tipoDeJugada").InnerText;
			stj = stj.Replace(" ","");
			stj =stj.ToLower();
			TipoJugada tj = TipoJugada.Normal;
			if (stj == "feliz")
				tj = TipoJugada.Feliz;
			else if (stj == "todosponen")
				tj = TipoJugada.TodosPonen;

			manejador.ManipularMesaDados(id, usuario, dado1, dado2, tj);
		}

		public override bool Interpretar(string mensajeSinCaps,
			XmlDocument xmld)
		{
			switch (mensajeSinCaps)
			{
				case "manipulardados":
					DelegarManipularDados(xmld);
					return true;
			}
			return false;
		}
	}
}
