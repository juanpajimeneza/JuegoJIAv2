using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoJIAv2
{
    public partial class FormSeleccionMateria : Form
    {
        private JJuego juego;
        public FormSeleccionMateria(JJuego juego)
        {
            InitializeComponent();
            this.juego = juego;
            CargarMaterias();
        }

        private void CargarMaterias()
        {
            // Limpiar la lista
            lstMaterias.Items.Clear();
            // Agregar cada materia a la lista
            foreach (Materia materia in juego.Materias)
            {
                lstMaterias.Items.Add(materia.Nombre);
            }
            // Seleccionar la primera materia por defecto
            if (lstMaterias.Items.Count > 0)
            {
                lstMaterias.SelectedIndex = 0;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (lstMaterias.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona una materia para continuar.",
                "Selección requerida", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            // Seleccionar la materia en el juego
            juego.SeleccionarMateria(lstMaterias.SelectedIndex);
            // Preparar el cuestionario
            juego.PrepararCuestionario();
            // Abrir el formulario de preguntas
            FormPregunta formPregunta = new FormPregunta(juego);
            formPregunta.Show();
            this.Hide();
        }

        private void FormSeleccionMateria_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
