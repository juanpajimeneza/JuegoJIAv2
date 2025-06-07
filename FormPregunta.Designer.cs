namespace JuegoJIAv2
{
    partial class FormPregunta
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
            lblContador = new Label();
            lblPregunta = new Label();
            rbOpcion1 = new RadioButton();
            rbOpcion2 = new RadioButton();
            rbOpcion3 = new RadioButton();
            rbOpcion4 = new RadioButton();
            btnConfirmar = new Button();
            pnlOpciones = new Panel();
            pnlOpciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(191, 84);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(78, 32);
            lblContador.TabIndex = 0;
            lblContador.Text = "label1";
            // 
            // lblPregunta
            // 
            lblPregunta.AutoSize = true;
            lblPregunta.Location = new Point(191, 131);
            lblPregunta.Name = "lblPregunta";
            lblPregunta.Size = new Size(78, 32);
            lblPregunta.TabIndex = 1;
            lblPregunta.Text = "label2";
            // 
            // rbOpcion1
            // 
            rbOpcion1.AutoSize = true;
            rbOpcion1.Location = new Point(28, 16);
            rbOpcion1.Name = "rbOpcion1";
            rbOpcion1.Size = new Size(184, 36);
            rbOpcion1.TabIndex = 2;
            rbOpcion1.TabStop = true;
            rbOpcion1.Text = "radioButton1";
            rbOpcion1.UseVisualStyleBackColor = true;
            // 
            // rbOpcion2
            // 
            rbOpcion2.AutoSize = true;
            rbOpcion2.Location = new Point(28, 58);
            rbOpcion2.Name = "rbOpcion2";
            rbOpcion2.Size = new Size(184, 36);
            rbOpcion2.TabIndex = 3;
            rbOpcion2.TabStop = true;
            rbOpcion2.Text = "radioButton2";
            rbOpcion2.UseVisualStyleBackColor = true;
            // 
            // rbOpcion3
            // 
            rbOpcion3.AutoSize = true;
            rbOpcion3.Location = new Point(28, 100);
            rbOpcion3.Name = "rbOpcion3";
            rbOpcion3.Size = new Size(184, 36);
            rbOpcion3.TabIndex = 4;
            rbOpcion3.TabStop = true;
            rbOpcion3.Text = "radioButton3";
            rbOpcion3.UseVisualStyleBackColor = true;
            // 
            // rbOpcion4
            // 
            rbOpcion4.AutoSize = true;
            rbOpcion4.Location = new Point(28, 142);
            rbOpcion4.Name = "rbOpcion4";
            rbOpcion4.Size = new Size(184, 36);
            rbOpcion4.TabIndex = 5;
            rbOpcion4.TabStop = true;
            rbOpcion4.Text = "radioButton4";
            rbOpcion4.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(369, 406);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(150, 46);
            btnConfirmar.TabIndex = 6;
            btnConfirmar.Text = "Continuar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // pnlOpciones
            // 
            pnlOpciones.Controls.Add(rbOpcion1);
            pnlOpciones.Controls.Add(rbOpcion2);
            pnlOpciones.Controls.Add(rbOpcion4);
            pnlOpciones.Controls.Add(rbOpcion3);
            pnlOpciones.Location = new Point(191, 210);
            pnlOpciones.Name = "pnlOpciones";
            pnlOpciones.Size = new Size(400, 200);
            pnlOpciones.TabIndex = 7;
            // 
            // FormPregunta
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlOpciones);
            Controls.Add(btnConfirmar);
            Controls.Add(lblPregunta);
            Controls.Add(lblContador);
            Name = "FormPregunta";
            Text = "FormPregunta";
            pnlOpciones.ResumeLayout(false);
            pnlOpciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContador;
        private Label lblPregunta;
        private RadioButton rbOpcion1;
        private RadioButton rbOpcion2;
        private RadioButton rbOpcion3;
        private RadioButton rbOpcion4;
        private Button btnConfirmar;
        private Panel pnlOpciones;
    }
}