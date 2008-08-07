using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace CasinoNEW
{
	public abstract class LectorXML : Lector
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
	
		public override void Interpretar(string mensaje, FileInfo fi)
		{

			XmlDocument xmld = new XmlDocument();
			xmld.Load(fi.FullName);

			string mensajeSinCaps = mensaje.ToLower();

			Interpretar(mensajeSinCaps, xmld);
		}

		public abstract void Interpretar(string mensajeSinCaps,
			XmlDocument xmld);
	}
}
