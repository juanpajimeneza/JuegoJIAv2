namespace JuegoJIAv2
{
    partial class FormSeleccionMateria
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
            lstMaterias = new ListBox();
            button1 = new Button();
            lblnota = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(165, 36);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(261, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Selecciona una materia";
            lblTitulo.Click += label1_Click;
            // 
            // lstMaterias
            // 
            lstMaterias.FormattingEnabled = true;
            lstMaterias.Location = new Point(163, 96);
            lstMaterias.Name = "lstMaterias";
            lstMaterias.SelectionMode = SelectionMode.MultiExtended;
            lstMaterias.Size = new Size(1132, 388);
            lstMaterias.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(601, 654);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 2;
            button1.Text = "Continuar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblnota
            // 
            lblnota.AutoSize = true;
            lblnota.Location = new Point(165, 512);
            lblnota.Name = "lblnota";
            lblnota.Size = new Size(523, 32);
            lblnota.TabIndex = 3;
            lblnota.Text = "Puntaje minimo es 750 (cada materia te da 100)";
            lblnota.Click += label1_Click_1;
            // 
            // FormSeleccionMateria
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1410, 756);
            Controls.Add(lblnota);
            Controls.Add(button1);
            Controls.Add(lstMaterias);
            Controls.Add(lblTitulo);
            Name = "FormSeleccionMateria";
            Text = "Seleccion de Materia";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormSeleccionMateria_FormClosed_1;
            Load += FormSeleccionMateria_Load;
            ClientSizeChanged += FormSeleccionMateria_ClientSizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private ListBox lstMaterias;
        private Button button1;
        private Label lblnota;
    }
}