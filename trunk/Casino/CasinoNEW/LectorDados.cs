using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Dinero = System.Decimal;


namespace CasinoNEW
{
	class LectorDados : LectorXML
	{
		private ManejadorDados manejador =
			new ManejadorDados();

		public LectorDados()
		{
			string a = Configuracion.DIRECTORIO_Lectura;
			
			string[] dirs = new string[] { a};
			this.Dirs = dirs;
		}

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

		private void DelegarSalidaCraps(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);

			int mesa = Int32.Parse(root.GetAttribute("mesa"));
			manejador.SalirCraps(id, usuario, mesa);
		}

		private void DelegarApuestaCraps(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);
			int idMesa = Int32.Parse(root.GetAttribute("mesa"));

			XmlElement opcionApuesta = GetChildNode(root, "opcionApuesta");

			string ta = GetTextFromChildNode(opcionApuesta,
				"tipoApuesta");
			TipoApuestaDados tipoApuesta = GetTipoApuestaFromText(ta);

			string pa = GetTextFromChildNode(opcionApuesta,
				"puntajeApostado");
			int puntajeApostado = Int32.Parse(pa);

			XmlElement valorApuesta = GetChildNode(root, "valorApuesta");
			// Se lee un único <fichaValor>
			XmlElement fichaValor = GetChildNode(valorApuesta, "fichaValor");
			int cantidadFichas =
				Int32.Parse(GetTextFromChildNode(fichaValor, "cantidad"));
			Dinero valorFichas =
				Dinero.Parse(GetTextFromChildNode(fichaValor, "valor"));

			manejador.Apostar(id, usuario, idMesa, tipoApuesta,
				puntajeApostado, valorFichas, cantidadFichas);

		}

		private TipoApuestaDados GetTipoApuestaFromText(string tipoApuesta)
		{
			switch (tipoApuesta)
			{
				case "pase":
					return TipoApuestaDados.Pass;
					break;
				case "no pase":
					return TipoApuestaDados.NoPass;
					break;
				case "venir":
					return TipoApuestaDados.Venir;
					break;
				case "no venir":
					return TipoApuestaDados.NoVenir;
					break;
				case "campo":
					return TipoApuestaDados.Campo;
					break;
				case "a ganar":
					return TipoApuestaDados.AGanar;
					break;
				case "en contra":
					return TipoApuestaDados.EnContra;
					break;
				default:
					return TipoApuestaDados.Pass;
			}
		}

		private void DelegarTiroCraps(XmlDocument xmld)
		{
			XmlElement root = xmld.DocumentElement;

			int id = GetIdTerminal(root);
			string usuario = GetUsuario(root);
			int idMesa = Int32.Parse(root.GetAttribute("mesa"));

			manejador.Tirar(id, usuario, idMesa);
		}


		public override bool Interpretar(string mensajeSinCaps,
			XmlDocument xmld)
		{
			switch (mensajeSinCaps)
			{
				case "entradacraps":
					DelegarEntradaCraps(xmld);
					return true;
				case "salidacraps":
					DelegarSalidaCraps(xmld);
					return true;
				case "apuestacraps":
					DelegarApuestaCraps(xmld);
					return true;
				case "tirocraps":
					DelegarTiroCraps(xmld);
					return true;
			}
			return false;
		}

	}
}
