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
            // Abrir el formulario de selección de materia
            FormSeleccionMateria formSeleccion = new
            FormSeleccionMateria(juego);
            formSeleccion.Show();
            this.Hide();
        }
    }
}
