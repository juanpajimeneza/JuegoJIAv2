using Microsoft.VisualBasic;
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
            if (lstMaterias.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos una materia para continuar.",
                "Selección requerida", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }

            // Agregar todas las materias seleccionadas
            juego.JugadorActual.MateriaSeleccionada.Clear();
            foreach (string nombreMateria in lstMaterias.SelectedItems)
            {
                Materia materia = juego.Materias.Find(m => m.Nombre == nombreMateria);
                juego.JugadorActual.SeleccionMateria(materia);
            }

            juego.JugadorActual.indiceMateria = 0;
            juego.PrepararCuestionario(); // Preparará la primera materia
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

        private void FormSeleccionMateria_Load(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            lblTitulo.Left = (formWidth / 2) - (lblTitulo.Width / 2);
            lblTitulo.Top = formHeight / 4;

            lstMaterias.Left = (formWidth / 2) - (lstMaterias.Width / 2);
            lstMaterias.Top = (formHeight / 4) + lblTitulo.Height + 20;

            button1.Left = (formWidth / 2) - (button1.Width / 2);
            button1.Top = (formHeight / 4) + (lblTitulo.Height + 20 + lstMaterias.Height + 20);

        }

        private void FormSeleccionMateria_ClientSizeChanged(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            lblTitulo.Left = (formWidth / 2) - (lblTitulo.Width / 2);
            lblTitulo.Top = formHeight / 4;

            lstMaterias.Left = (formWidth / 2) - (lstMaterias.Width / 2);
            lstMaterias.Top = (formHeight / 4) + lblTitulo.Height + 20;

            button1.Left = (formWidth / 2) - (button1.Width / 2);
            button1.Top = (formHeight / 4) + (lblTitulo.Height + 20 + lstMaterias.Height + 20);

        }

        private void FormSeleccionMateria_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

}
