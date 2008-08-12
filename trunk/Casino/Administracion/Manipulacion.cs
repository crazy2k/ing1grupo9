using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Administracion
{
	public partial class Manipulacion : Form
	{
		private ComunicadorManipulacionDados comunicador = new ComunicadorManipulacionDados();
		
		public Manipulacion()
		{
			InitializeComponent();
			tipoJugada.SelectedItem = tipoJugada.Items[0];
			dado1.SelectedItem = dado1.Items[0];
			dado2.SelectedItem = dado2.Items[0];
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void button_manipular_Click(object sender, EventArgs e)
		{
			Respuesta res = comunicador.ManipularDados(Terminal.Id, Terminal.Usuario,
				tipoJugada.Text, dado1.Text, dado2.Text);
			
			//MostrarCartelito
			Form cartel = new Cartelito(res.descripcion, res.aceptado);
			cartel.ShowDialog();

		}



	}
}