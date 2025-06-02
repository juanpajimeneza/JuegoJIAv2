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
    public partial class FormResultados : Form
    {
        private JJuego juego;
        public FormResultados(JJuego juego)
        {
            InitializeComponent();
            this.juego = juego;
            MostrarResultados();
        }
        private void MostrarResultados()
        {
            string[] resultados = juego.ObtenerResultados();
            lblNombre.Text = $"Jugador: {resultados[0]}";
            lblMateria.Text = $"Materia: {resultados[1]}";
            lblPuntaje.Text = $"Puntaje final: {resultados[2]}/100";
            lblRespuestasCorrectas.Text = $"Respuestas correctas:{ int.Parse(resultados[2]) / 10}/ 10";
            lblResultado.Text = resultados[3];

            // Cambiar el color según el resultado
            if (int.Parse(resultados[2]) >= 60)
            {
                lblResultado.ForeColor = Color.Green;
            }
            else
            {
                lblResultado.ForeColor = Color.Red;
            }
        }

        private void btnJugarDeNuevo_Click(object sender, EventArgs e)
        {
            // Crear un nuevo juego
            FormBienvenida formBienvenida = new FormBienvenida();
            formBienvenida.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormResultados_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
