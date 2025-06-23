using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JuegoJIAv2
{
    public partial class FormBienvenida : Form
    {
        private JJuego juego;
        public FormBienvenida()
        {
            InitializeComponent();
            juego = new JJuego();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingresa tu nombre paracomenzar.", "Nombre requerido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }

            // Iniciar el juego con el nombre del jugador

            juego.Iniciar(nombre);
            // Abrir el formulario de historia
            FormHistoria formHistoria = new FormHistoria(juego);
            formHistoria.Show();
            // Abrir el formulario de selección de materia
            //FormSeleccionMateria formSeleccion = new
            //FormSeleccionMateria(juego);
            //formSeleccion.Show();
            //this.Hide();
        }

        private void FormBienvenida_Load(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            lblTitulo.Left = (formWidth / 2) - (lblTitulo.Width / 2);
            lblTitulo.Top = formHeight / 4;

            lblNombre.Left = (formWidth / 2) - (lblNombre.Width / 2);
            lblNombre.Top = (formHeight / 4) + lblTitulo.Height + 20;

            txtNombre.Left = (formWidth / 2) - (txtNombre.Width / 2);
            txtNombre.Top = (formHeight / 4) + (lblTitulo.Height + 20 + lblNombre.Height + 20);

            btnComenzar.Left = (formWidth / 2) - (btnComenzar.Width / 2);
            btnComenzar.Top = (formHeight / 4) + (lblTitulo.Height + 20 + lblNombre.Height + 20 + txtNombre.Height + 20);
        }

        private void FormBienvenida_ClientSizeChanged(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            lblTitulo.Left = (formWidth / 2) - (lblTitulo.Width / 2);
            lblTitulo.Top = formHeight / 4;

            lblNombre.Left = (formWidth / 2) - (lblNombre.Width / 2);
            lblNombre.Top = (formHeight / 4) + lblTitulo.Height + 20;

            txtNombre.Left = (formWidth / 2) - (txtNombre.Width / 2);
            txtNombre.Top = (formHeight / 4) + (lblTitulo.Height + 20 + lblNombre.Height + 20);

            btnComenzar.Left = (formWidth / 2) - (btnComenzar.Width / 2);
            btnComenzar.Top = (formHeight / 4) + (lblTitulo.Height + 20 + lblNombre.Height + 20 + txtNombre.Height + 20);
        }

        private void FormBienvenida_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
