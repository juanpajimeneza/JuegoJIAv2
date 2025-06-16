namespace JuegoJIAv2
{
    partial class FormResultados
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
            lblTitulo = new Label();
            lblNombre = new Label();
            lblMateria = new Label();
            lblPuntaje = new Label();
            lblRespuestasCorrectas = new Label();
            lblResultado = new Label();
            btnJugarDeNuevo = new Button();
            btnSalir = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(86, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(78, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "label1";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(86, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 32);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "label1";
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Location = new Point(86, 90);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(78, 32);
            lblMateria.TabIndex = 2;
            lblMateria.Text = "label1";
            // 
            // lblPuntaje
            // 
            lblPuntaje.AutoSize = true;
            lblPuntaje.Location = new Point(86, 122);
            lblPuntaje.Name = "lblPuntaje";
            lblPuntaje.Size = new Size(78, 32);
            lblPuntaje.TabIndex = 3;
            lblPuntaje.Text = "label1";
            // 
            // lblRespuestasCorrectas
            // 
            lblRespuestasCorrectas.AutoSize = true;
            lblRespuestasCorrectas.Location = new Point(86, 154);
            lblRespuestasCorrectas.Name = "lblRespuestasCorrectas";
            lblRespuestasCorrectas.Size = new Size(78, 32);
            lblRespuestasCorrectas.TabIndex = 4;
            lblRespuestasCorrectas.Text = "label1";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(86, 186);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(78, 32);
            lblResultado.TabIndex = 5;
            lblResultado.Text = "label1";
            // 
            // btnJugarDeNuevo
            // 
            btnJugarDeNuevo.Location = new Point(444, 499);
            btnJugarDeNuevo.Name = "btnJugarDeNuevo";
            btnJugarDeNuevo.Size = new Size(228, 46);
            btnJugarDeNuevo.TabIndex = 6;
            btnJugarDeNuevo.Text = "Jugar de nuevo";
            btnJugarDeNuevo.UseVisualStyleBackColor = true;
            btnJugarDeNuevo.Click += btnJugarDeNuevo_Click_1;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(704, 499);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(114, 46);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnJugarDeNuevo);
            panel1.Controls.Add(lblNombre);
            panel1.Controls.Add(lblMateria);
            panel1.Controls.Add(lblResultado);
            panel1.Controls.Add(lblPuntaje);
            panel1.Controls.Add(lblRespuestasCorrectas);
            panel1.Location = new Point(155, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(1351, 570);
            panel1.TabIndex = 8;
            // 
            // FormResultados
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1588, 690);
            Controls.Add(panel1);
            Name = "FormResultados";
            Text = "Resultados";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombre;
        private Label lblMateria;
        private Label lblPuntaje;
        private Label lblRespuestasCorrectas;
        private Label lblResultado;
        private Button btnJugarDeNuevo;
        private Button btnSalir;
        private Panel panel1;
    }
}