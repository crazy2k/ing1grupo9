namespace Administracion
{
	partial class Manipulacion
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
			this.tipoJugada = new System.Windows.Forms.ComboBox();
			this.dado1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dado2 = new System.Windows.Forms.ComboBox();
			this.button_manipular = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tipoJugada
			// 
			this.tipoJugada.CausesValidation = false;
			this.tipoJugada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tipoJugada.FormattingEnabled = true;
			this.tipoJugada.Items.AddRange(new object[] {
            "Normal",
            "Feliz",
            "Todos Ponen"});
			this.tipoJugada.Location = new System.Drawing.Point(78, 39);
			this.tipoJugada.Name = "tipoJugada";
			this.tipoJugada.Size = new System.Drawing.Size(121, 24);
			this.tipoJugada.TabIndex = 0;
			// 
			// dado1
			// 
			this.dado1.CausesValidation = false;
			this.dado1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dado1.FormattingEnabled = true;
			this.dado1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
			this.dado1.Location = new System.Drawing.Point(78, 118);
			this.dado1.Name = "dado1";
			this.dado1.Size = new System.Drawing.Size(121, 24);
			this.dado1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(85, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tipo de jugada";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(105, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Dado 1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(105, 145);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Dado 2";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// dado2
			// 
			this.dado2.CausesValidation = false;
			this.dado2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dado2.FormattingEnabled = true;
			this.dado2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
			this.dado2.Location = new System.Drawing.Point(78, 165);
			this.dado2.Name = "dado2";
			this.dado2.Size = new System.Drawing.Size(121, 24);
			this.dado2.TabIndex = 5;
			// 
			// button_manipular
			// 
			this.button_manipular.Location = new System.Drawing.Point(99, 229);
			this.button_manipular.Name = "button_manipular";
			this.button_manipular.Size = new System.Drawing.Size(89, 29);
			this.button_manipular.TabIndex = 6;
			this.button_manipular.Text = "Manipular";
			this.button_manipular.UseVisualStyleBackColor = true;
			this.button_manipular.Click += new System.EventHandler(this.button_manipular_Click);
			// 
			// Manipulacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 270);
			this.Controls.Add(this.button_manipular);
			this.Controls.Add(this.dado2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dado1);
			this.Controls.Add(this.tipoJugada);
			this.Name = "Manipulacion";
			this.Text = "Manipulacion";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox dado1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button_manipular;
		private System.Windows.Forms.ComboBox dado2;
		private System.Windows.Forms.ComboBox tipoJugada;

	}
}

