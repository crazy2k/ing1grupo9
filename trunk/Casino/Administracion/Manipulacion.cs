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
		public Manipulacion()
		{
			InitializeComponent();
			comboBox1.SelectedItem = comboBox1.Items[0];
			comboBox2.SelectedItem = comboBox2.Items[0];
			comboBox3.SelectedItem = comboBox3.Items[0];
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}
	}
}