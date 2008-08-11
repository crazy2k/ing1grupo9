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
			Terminal.Id = Int32.Parse(idTerminal.Text);
			Terminal.Usuario = nombreUsuario.Text;

			Respuesta res = com.Entrar(idTerminal.Text, nombreUsuario.Text , modo);

			if (res.aceptado)
			{
				Terminal.Id = Int32.Parse(idTerminal.Text);
				Terminal.Usuario = nombreUsuario.Text;
				if (admin.Checked)
				{
					Form administrac = new Administracion();
					administrac.ShowDialog();
				}
				else
				{
					Form manip = new Manipulacion();
					manip.ShowDialog();
				}
			}
			else
			{
				//MostrarCartelito con: res.descripcion
				Form cartel = new Cartelito(res.descripcion, res.aceptado);
				cartel.ShowDialog();

				Application.Restart();
			}

		}
	}
}