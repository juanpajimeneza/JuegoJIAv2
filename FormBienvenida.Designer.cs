namespace JuegoJIAv2
{
    partial class FormBienvenida
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnComenzar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(351, 74);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(354, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "¡Bienvenido al Juego Educativo!";
            // 
            // btnComenzar
            // 
            btnComenzar.Location = new Point(317, 362);
            btnComenzar.Name = "btnComenzar";
            btnComenzar.Size = new Size(150, 46);
            btnComenzar.TabIndex = 1;
            btnComenzar.Text = "button1";
            btnComenzar.UseVisualStyleBackColor = true;
            btnComenzar.Click += btnComenzar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(303, 298);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 39);
            txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(361, 209);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(216, 32);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Ingresa tu nombre:";
            // 
            // FormBienvenida
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(btnComenzar);
            Controls.Add(lblTitulo);
            Name = "FormBienvenida";
            Text = "Bienvenida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnComenzar;
        private TextBox txtNombre;
        private Label lblNombre;
    }
}
