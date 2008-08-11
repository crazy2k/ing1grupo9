using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Administracion
{
	public partial class Cartelito : Form
	{
		public Cartelito(string texto, bool mensajeAceptado)
		{
			InitializeComponent();
			mensaje.Text = texto;
			if (mensajeAceptado)
				aceptado.Text = "En horabuena, su mensaje ha sido aceptado!!!";
			else
				aceptado.Text = "Siga participando, su mensaje ha sido denegado.";
		}

		private void mensaje_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}