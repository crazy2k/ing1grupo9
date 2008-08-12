using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Administracion
{
	public partial class Administracion : Form
	{
		private ComunicadorAdministracion comunicador = new ComunicadorAdministracion();
		

		public Administracion()
		{
			InitializeComponent();
			tipoRanking.SelectedItem = tipoRanking.Items[0];
		}



		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}


		private void button_ranking_Click(object sender, EventArgs e)
		{
			try
			{
				Int32.Parse(cantidad.Text);
				Respuesta res = comunicador.PedirInformeRanking(Terminal.Id, Terminal.Usuario, tipoRanking.Text, cantidad.Text);
				//MostrarCartelito con: res.descripcion
				Form cartel = new Cartelito(res.descripcion, res.aceptado);
				cartel.ShowDialog();
			}
			catch (Exception ex) {
				//MostrarCartelito con: ingrese una cantidad
				Form cartel1 = new Cartelito("Ingrese una cantidad válida.", false);
				cartel1.ShowDialog();
			}
		}

		private void button_movPorJug_Click(object sender, EventArgs e)
		{
			Respuesta res = comunicador.PedirMovimientosPorJugador(Terminal.Id, Terminal.Usuario, nombreJugador.Text);
			//MostrarCartelito con: res.descripcion
			Form cartel = new Cartelito(res.descripcion, res.aceptado);
			cartel.ShowDialog();


		}

		private void button_estadoActual_Click(object sender, EventArgs e)
		{
			Respuesta res = comunicador.PedirInformeEstadoCasino(Terminal.Id, Terminal.Usuario);
			//MostrarCartelito con: res.descripcion
			Form cartel = new Cartelito(res.descripcion, res.aceptado);
			cartel.ShowDialog();

		}

		private void abrirCasino_Click(object sender, EventArgs e)
		{
			Respuesta res = comunicador.AbrirCasino(Terminal.Id, Terminal.Usuario);
			//MostrarCartelito con: res.descripcion
			Form cartel = new Cartelito(res.descripcion, res.aceptado);
			cartel.ShowDialog();

		}

		private void cerrarCasino_Click(object sender, EventArgs e)
		{
			Respuesta res = comunicador.CerrarCasino(Terminal.Id, Terminal.Usuario);
			//MostrarCartelito con: res.descripcion
			Form cartel = new Cartelito(res.descripcion, res.aceptado);
			cartel.ShowDialog();

		}
	}
}