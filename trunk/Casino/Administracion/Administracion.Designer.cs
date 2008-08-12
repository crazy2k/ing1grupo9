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
			this.abrirCasino = new System.Windows.Forms.Button();
			this.button_ranking = new System.Windows.Forms.Button();
			this.button_movPorJug = new System.Windows.Forms.Button();
			this.button_estadoActual = new System.Windows.Forms.Button();
			this.cerrarCasino = new System.Windows.Forms.Button();
			this.tipoRanking = new System.Windows.Forms.ComboBox();
			this.cantidad = new System.Windows.Forms.TextBox();
			this.nombreJugador = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// abrirCasino
			// 
			this.abrirCasino.Location = new System.Drawing.Point(83, 36);
			this.abrirCasino.Name = "abrirCasino";
			this.abrirCasino.Size = new System.Drawing.Size(121, 30);
			this.abrirCasino.TabIndex = 0;
			this.abrirCasino.Text = "Abrir casino";
			this.abrirCasino.UseVisualStyleBackColor = true;
			this.abrirCasino.Click += new System.EventHandler(this.abrirCasino_Click);
			// 
			// button_ranking
			// 
			this.button_ranking.Location = new System.Drawing.Point(34, 135);
			this.button_ranking.Name = "button_ranking";
			this.button_ranking.Size = new System.Drawing.Size(235, 32);
			this.button_ranking.TabIndex = 1;
			this.button_ranking.Text = "Pedir ranking de jugadores";
			this.button_ranking.UseVisualStyleBackColor = true;
			this.button_ranking.Click += new System.EventHandler(this.button_ranking_Click);
			// 
			// button_movPorJug
			// 
			this.button_movPorJug.Location = new System.Drawing.Point(34, 170);
			this.button_movPorJug.Name = "button_movPorJug";
			this.button_movPorJug.Size = new System.Drawing.Size(235, 32);
			this.button_movPorJug.TabIndex = 2;
			this.button_movPorJug.Text = "Pedir movimientos por jugador";
			this.button_movPorJug.UseVisualStyleBackColor = true;
			this.button_movPorJug.Click += new System.EventHandler(this.button_movPorJug_Click);
			// 
			// button_estadoActual
			// 
			this.button_estadoActual.Location = new System.Drawing.Point(34, 206);
			this.button_estadoActual.Name = "button_estadoActual";
			this.button_estadoActual.Size = new System.Drawing.Size(235, 32);
			this.button_estadoActual.TabIndex = 3;
			this.button_estadoActual.Text = "Pedir estado actual";
			this.button_estadoActual.UseVisualStyleBackColor = true;
			this.button_estadoActual.Click += new System.EventHandler(this.button_estadoActual_Click);
			// 
			// cerrarCasino
			// 
			this.cerrarCasino.Location = new System.Drawing.Point(83, 72);
			this.cerrarCasino.Name = "cerrarCasino";
			this.cerrarCasino.Size = new System.Drawing.Size(121, 30);
			this.cerrarCasino.TabIndex = 4;
			this.cerrarCasino.Text = "Cerrar casino";
			this.cerrarCasino.UseVisualStyleBackColor = true;
			this.cerrarCasino.Click += new System.EventHandler(this.cerrarCasino_Click);
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
			// Administracion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(543, 270);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nombreJugador);
			this.Controls.Add(this.cantidad);
			this.Controls.Add(this.tipoRanking);
			this.Controls.Add(this.cerrarCasino);
			this.Controls.Add(this.button_estadoActual);
			this.Controls.Add(this.button_movPorJug);
			this.Controls.Add(this.button_ranking);
			this.Controls.Add(this.abrirCasino);
			this.Name = "Administracion";
			this.Text = "Administracion";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button abrirCasino;
		private System.Windows.Forms.Button button_ranking;
		private System.Windows.Forms.Button button_movPorJug;
		private System.Windows.Forms.Button button_estadoActual;
		private System.Windows.Forms.Button cerrarCasino;
		private System.Windows.Forms.ComboBox tipoRanking;
		private System.Windows.Forms.TextBox cantidad;
		private System.Windows.Forms.TextBox nombreJugador;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

