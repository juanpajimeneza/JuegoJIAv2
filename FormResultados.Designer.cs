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
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(117, 50);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(78, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "label1";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(117, 92);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 32);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "label1";
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Location = new Point(117, 124);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(78, 32);
            lblMateria.TabIndex = 2;
            lblMateria.Text = "label1";
            // 
            // lblPuntaje
            // 
            lblPuntaje.AutoSize = true;
            lblPuntaje.Location = new Point(117, 156);
            lblPuntaje.Name = "lblPuntaje";
            lblPuntaje.Size = new Size(78, 32);
            lblPuntaje.TabIndex = 3;
            lblPuntaje.Text = "label1";
            // 
            // lblRespuestasCorrectas
            // 
            lblRespuestasCorrectas.AutoSize = true;
            lblRespuestasCorrectas.Location = new Point(117, 188);
            lblRespuestasCorrectas.Name = "lblRespuestasCorrectas";
            lblRespuestasCorrectas.Size = new Size(78, 32);
            lblRespuestasCorrectas.TabIndex = 4;
            lblRespuestasCorrectas.Text = "label1";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(117, 220);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(78, 32);
            lblResultado.TabIndex = 5;
            lblResultado.Text = "label1";
            // 
            // btnJugarDeNuevo
            // 
            btnJugarDeNuevo.Location = new Point(207, 306);
            btnJugarDeNuevo.Name = "btnJugarDeNuevo";
            btnJugarDeNuevo.Size = new Size(114, 46);
            btnJugarDeNuevo.TabIndex = 6;
            btnJugarDeNuevo.Text = "button1";
            btnJugarDeNuevo.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(353, 306);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(114, 46);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "button2";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormResultados
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnJugarDeNuevo);
            Controls.Add(lblResultado);
            Controls.Add(lblRespuestasCorrectas);
            Controls.Add(lblPuntaje);
            Controls.Add(lblMateria);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Name = "FormResultados";
            Text = "Resultados";
            ResumeLayout(false);
            PerformLayout();
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
    }
}