namespace Administracion
{
	partial class Entrada
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
			this.idTerminal = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.nombreUsuario = new System.Windows.Forms.TextBox();
			this.admin = new System.Windows.Forms.RadioButton();
			this.manip = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.button_Salir = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// idTerminal
			// 
			this.idTerminal.Location = new System.Drawing.Point(166, 35);
			this.idTerminal.MaxLength = 4;
			this.idTerminal.Name = "idTerminal";
			this.idTerminal.Size = new System.Drawing.Size(100, 22);
			this.idTerminal.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Identificador terminal";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(31, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Nombre de usuario";
			// 
			// nombreUsuario
			// 
			this.nombreUsuario.Location = new System.Drawing.Point(166, 80);
			this.nombreUsuario.Name = "nombreUsuario";
			this.nombreUsuario.Size = new System.Drawing.Size(100, 22);
			this.nombreUsuario.TabIndex = 5;
			// 
			// admin
			// 
			this.admin.AutoSize = true;
			this.admin.Checked = true;
			this.admin.Location = new System.Drawing.Point(91, 132);
			this.admin.Name = "admin";
			this.admin.Size = new System.Drawing.Size(116, 21);
			this.admin.TabIndex = 6;
			this.admin.TabStop = true;
			this.admin.Text = "Administrador";
			this.admin.UseVisualStyleBackColor = true;
			// 
			// manip
			// 
			this.manip.AutoSize = true;
			this.manip.Location = new System.Drawing.Point(91, 160);
			this.manip.Name = "manip";
			this.manip.Size = new System.Drawing.Size(107, 21);
			this.manip.TabIndex = 7;
			this.manip.Text = "Manipulador";
			this.manip.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(34, 217);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Entrar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button_Salir
			// 
			this.button_Salir.Enabled = false;
			this.button_Salir.Location = new System.Drawing.Point(191, 217);
			this.button_Salir.Name = "button_Salir";
			this.button_Salir.Size = new System.Drawing.Size(75, 23);
			this.button_Salir.TabIndex = 9;
			this.button_Salir.Text = "Salir";
			this.button_Salir.UseVisualStyleBackColor = true;
			this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
			// 
			// Entrada
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 271);
			this.Controls.Add(this.button_Salir);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.manip);
			this.Controls.Add(this.admin);
			this.Controls.Add(this.nombreUsuario);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.idTerminal);
			this.Name = "Entrada";
			this.Text = "Entrada";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox idTerminal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox nombreUsuario;
		private System.Windows.Forms.RadioButton admin;
		private System.Windows.Forms.RadioButton manip;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button_Salir;
	}
}

