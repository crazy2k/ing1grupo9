using System;
using System.Collections.Generic;
using System.Text;

namespace Administracion
{
	class Terminal
	{
		private static int id;

		public static int Id
		{
			get { return id; }
			set { id = value; }
		}

		private static string usuario;

		public static string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
	}
}
