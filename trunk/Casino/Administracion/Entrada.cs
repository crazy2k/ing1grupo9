using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Administracion
{
	public partial class Entrada : Form
	{

		private ComunicadorEntrada com = new ComunicadorEntrada();

		public Entrada()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string modo = (admin.Checked) ? "administrador" : "manipulador";
			com.Entrar(idTerminal.Text, nombreUsuario.Text , modo);

			XmlDocument xmlResEntrada = com.EsperarRespuestaEntrada();

			if (com.LeerRespuestaEntrada(xmlResEntrada))
			{
				//Application.Exit();
				Form manip = new Manipulacion();
				manip.ShowDialog();
			}
			//Application.Exit();
			Form manip2 = new Administracion();
			manip2.ShowDialog();
		}
	}
}