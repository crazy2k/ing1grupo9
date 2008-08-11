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
		private ComunicadorAdministracion escritor = new ComunicadorAdministracion();

		public Administracion()
		{
			InitializeComponent();
			tipoRanking.SelectedItem = tipoRanking.Items[0];
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}


		private void button2_Click(object sender, EventArgs e)
		{
			//escritor.pedirInformeRanking(tipoRanking.Text, cantidad.Text);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			escritor.PedirMovimientosPorJugador(nombreJugador.Text);
		}
	}
}