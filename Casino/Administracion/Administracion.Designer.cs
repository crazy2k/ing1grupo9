namespace Administracion
{
	partial class Administracion
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.tipoRanking = new System.Windows.Forms.ComboBox();
			this.cantidad = new System.Windows.Forms.TextBox();
			this.nombreJugador = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(83, 36);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(121, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "Abrir casino";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(34, 135);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(235, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "Pedir ranking de jugadores";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(34, 170);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(235, 32);
			this.button3.TabIndex = 2;
			this.button3.Text = "Pedir movimientos por jugador";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(34, 206);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(235, 32);
			this.button4.TabIndex = 3;
			this.button4.Text = "Pedir estado actual";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(83, 72);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(121, 30);
			this.button5.TabIndex = 4;
			this.button5.Text = "Cerrar casino";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// tipoRanking
			// 
			this.tipoRanking.FormattingEnabled = true;
			this.tipoRanking.Items.AddRange(new object[] {
            "ganadores",
            "perdedores"});
			this.tipoRanking.Location = new System.Drawing.Point(275, 139);
			this.tipoRanking.Name = "tipoRanking";
			this.tipoRanking.Size = new System.Drawing.Size(121, 24);
			this.tipoRanking.TabIndex = 5;
			// 
			// cantidad
			// 
			this.cantidad.Location = new System.Drawing.Point(402, 140);
			this.cantidad.Name = "cantidad";
			this.cantidad.Size = new System.Drawing.Size(100, 22);
			this.cantidad.TabIndex = 6;
			// 
			// nombreJugador
			// 
			this.nombreJugador.Location = new System.Drawing.Point(349, 170);
			this.nombreJugador.Name = "nombreJugador";
			this.nombreJugador.Size = new System.Drawing.Size(100, 22);
			this.nombreJugador.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(399, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Cantidad:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(279, 173);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 17);
			this.label2.TabIndex = 9;
			this.label2.Text = "Jugador:";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(543, 270);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nombreJugador);
			this.Controls.Add(this.cantidad);
			this.Controls.Add(this.tipoRanking);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Administracion";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ComboBox tipoRanking;
		private System.Windows.Forms.TextBox cantidad;
		private System.Windows.Forms.TextBox nombreJugador;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

