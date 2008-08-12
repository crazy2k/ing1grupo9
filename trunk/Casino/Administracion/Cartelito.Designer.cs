namespace Administracion
{
	partial class Cartelito
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mensaje = new System.Windows.Forms.Label();
			this.aceptado = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mensaje
			// 
			this.mensaje.Location = new System.Drawing.Point(12, 70);
			this.mensaje.Name = "mensaje";
			this.mensaje.Size = new System.Drawing.Size(287, 81);
			this.mensaje.TabIndex = 0;
			this.mensaje.Text = "Mensaje.";
			this.mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mensaje.Click += new System.EventHandler(this.mensaje_Click);
			// 
			// aceptado
			// 
			this.aceptado.Location = new System.Drawing.Point(13, 13);
			this.aceptado.Name = "aceptado";
			this.aceptado.Size = new System.Drawing.Size(286, 57);
			this.aceptado.TabIndex = 2;
			this.aceptado.Text = "Aceptado";
			// 
			// Cartelito
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 160);
			this.Controls.Add(this.aceptado);
			this.Controls.Add(this.mensaje);
			this.Name = "Cartelito";
			this.Text = "Cartelito";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label mensaje;
		private System.Windows.Forms.Label aceptado;

	}
}