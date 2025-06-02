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
    public partial class FormPregunta : Form
    {
        private JJuego juego;
        private Pregunta preguntaActual;
        public FormPregunta(JJuego juego)
        {
            InitializeComponent();
            this.juego = juego;
            MostrarPreguntaActual();
        }
        private void MostrarPreguntaActual()
        {
            // Obtener la pregunta actual
            preguntaActual = juego.ObtenerPreguntaActual();
            if (preguntaActual == null)
            {
                // Si no hay más preguntas, mostrar resultados
                MostrarResultados();
                return;
            }
            // Actualizar el contador de preguntas
            lblContador.Text = $"Pregunta {juego.PreguntaActualIndex + 1}/10";

            // Mostrar el texto de la pregunta
            lblPregunta.Text = preguntaActual.Texto;
            // Limpiar selecciones anteriores
            foreach (RadioButton rb in pnlOpciones.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
            // Mostrar las opciones de respuesta
            for (int i = 0; i < preguntaActual.Opciones.Count; i++)
            {
                RadioButton rb = (RadioButton)pnlOpciones.Controls[$"rbOpcion{i + 1}"];
                rb.Text = preguntaActual.Opciones[i].Texto;
                rb.Visible = true;
            }

            // Ocultar opciones no utilizadas
            for (int i = preguntaActual.Opciones.Count; i < 4; i++)
            {
                RadioButton rb =(RadioButton)pnlOpciones.Controls[$"rbOpcion{i + 1}"];
                rb.Visible = false;
            }

        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una respuesta
            int indiceRespuesta = -1;
            for (int i = 0; i < 4; i++)
            {
                RadioButton rb =
                (RadioButton)pnlOpciones.Controls[$"rbOpcion{i + 1}"];
                if (rb.Visible && rb.Checked)
                {
                    indiceRespuesta = i;
                    break;
                }
            }

            if (indiceRespuesta == -1)
            {
                MessageBox.Show("Por favor, selecciona una respuesta.",
                "Selección requerida", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }

            // Verificar la respuesta
            bool esCorrecta =juego.VerificarRespuesta(indiceRespuesta);

            // Mostrar retroalimentación
            string mensaje = esCorrecta ? "¡Correcto! +10 puntos" :
            "Incorrecto.";
            MessageBox.Show(mensaje, "Resultado",
            MessageBoxButtons.OK,
            esCorrecta ? MessageBoxIcon.Information :
            MessageBoxIcon.Warning);

            // Verificar si el cuestionario ha terminado
            if (juego.CuestionarioTerminado())
            {
                MostrarResultados();
            }
            else
            {
                // Mostrar la siguiente pregunta
                MostrarPreguntaActual();
            }

        }
        private void MostrarResultados()
        { 
            // Abrir el formulario de resultados
            FormResultados formResultados = new FormResultados(juego);
            formResultados.Show();
            this.Hide();
        }
        private void FormPregunta_FormClosed(object sender,FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
