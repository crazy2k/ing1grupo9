using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CasinoNEW
{
	class LectorDados : LectorXML
	{
		private ManejadorDados manejador =
			new ManejadorDados();

		private void DelegarEntradaCraps(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			string smesa = root.GetAttribute("mesa");
			if (smesa == "")
				manejador.EntrarCrapsNuevaMesa(id, usuario);
			else
			{
				int mesa = Int32.Parse(smesa);
				manejador.EntrarCrapsMesa(id, usuario, mesa);
			}
		}

		public override void Interpretar(string mensajeSinCaps,
			XmlDocument xmld)
		{
			switch (mensajeSinCaps)
			{
				case "entradaCraps":
					DelegarEntradaCraps(xmld);
					break;
			}
		}

	}
}
