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
			this.ok = new System.Windows.Forms.Button();
			this.aceptado = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mensaje
			// 
			this.mensaje.Location = new System.Drawing.Point(12, 33);
			this.mensaje.Name = "mensaje";
			this.mensaje.Size = new System.Drawing.Size(287, 91);
			this.mensaje.TabIndex = 0;
			this.mensaje.Text = "Mensaje.";
			this.mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mensaje.Click += new System.EventHandler(this.mensaje_Click);
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(121, 127);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(57, 25);
			this.ok.TabIndex = 1;
			this.ok.Text = "OK";
			this.ok.UseVisualStyleBackColor = true;
			// 
			// aceptado
			// 
			this.aceptado.AutoSize = true;
			this.aceptado.Location = new System.Drawing.Point(13, 13);
			this.aceptado.Name = "aceptado";
			this.aceptado.Size = new System.Drawing.Size(68, 17);
			this.aceptado.TabIndex = 2;
			this.aceptado.Text = "Aceptado";
			// 
			// Cartelito
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 160);
			this.Controls.Add(this.aceptado);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.mensaje);
			this.Name = "Cartelito";
			this.Text = "Cartelito";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label mensaje;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Label aceptado;

	}
}