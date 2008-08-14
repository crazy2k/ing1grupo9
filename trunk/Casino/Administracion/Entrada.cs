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

			if (idTerminal.Text == "")
			{
				Form cartel =
					new Cartelito("Debe escribir un número de terminal", false);
				cartel.ShowDialog();
				return;
			}

			Terminal.Id = Int32.Parse(idTerminal.Text);
			Terminal.Usuario = nombreUsuario.Text;

			Respuesta res = com.Entrar(idTerminal.Text, nombreUsuario.Text , modo);

			if (res.aceptado)
			{
				SwitchSalir();
				
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

				//Application.Restart();
			}

		}
		private void SwitchSalir() {
			bool prop = button_Salir.Enabled;

			idTerminal.Enabled = prop;
			nombreUsuario.Enabled = prop;
			button1.Enabled = prop;
			button_Salir.Enabled = !prop;
			admin.Enabled = prop;
			manip.Enabled = prop;
		}

		private void button_Salir_Click(object sender, EventArgs e)
		{
			Terminal.Id = Int32.Parse(idTerminal.Text);
			Terminal.Usuario = nombreUsuario.Text;

			Respuesta res = com.Salir(idTerminal.Text, nombreUsuario.Text);

			if (res.aceptado)
				SwitchSalir();
				
			//MostrarCartelito con: res.descripcion
			Form cartel = new Cartelito(res.descripcion, res.aceptado);
			cartel.ShowDialog();
		}
	}
}