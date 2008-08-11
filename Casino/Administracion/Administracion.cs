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

		private void button1_Click(object sender, EventArgs e)
		{
			comunicador.AbrirCasino(Terminal.Id, Terminal.Usuario);
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}


		private void button_ranking_Click(object sender, EventArgs e)
		{
			comunicador.PedirInformeRanking(Terminal.Id, Terminal.Usuario, tipoRanking.Text, cantidad.Text);
		}

		private void button_movPorJug_Click(object sender, EventArgs e)
		{
			comunicador.PedirMovimientosPorJugador(Terminal.Id, Terminal.Usuario, nombreJugador.Text);
		}

		private void button_estadoActual_Click(object sender, EventArgs e)
		{
			comunicador.PedirInformeEstadoCasino(Terminal.Id, Terminal.Usuario);
		}
	}
}