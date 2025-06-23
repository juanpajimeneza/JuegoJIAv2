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
            lblmateria.Text = juego.JugadorActual.MateriaSeleccionada[juego.JugadorActual.indiceMateria].Nombre;
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
                RadioButton rb = (RadioButton)pnlOpciones.Controls[$"rbOpcion{i + 1}"];
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
                //lblestado.Text = "Por favor, selecciona una respuesta.";
                //MessageBox.Show("Por favor, selecciona una respuesta.",
                //"Selección requerida", MessageBoxButtons.OK,
                //MessageBoxIcon.Information);
                return;
            }

            // Verificar la respuesta
            bool esCorrecta = juego.VerificarRespuesta(indiceRespuesta);

            // Mostrar retroalimentación
            string mensaje = esCorrecta ? "¡Correcto! +10 puntos" :
            "Incorrecto.";
            if (esCorrecta)
            {
                lblestado.ForeColor = Color.Green;
            }
            else
            {
                lblestado.ForeColor = Color.Red;
            }
            lblestado.Text = mensaje;
            //MessageBox.Show(mensaje, "Resultado",
            //MessageBoxButtons.OK,
            //esCorrecta ? MessageBoxIcon.Information :
            //MessageBoxIcon.Warning);

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
            // Intentar avanzar a la siguiente materia
            if (juego.AvanzarMateria())
            {
                // Reiniciar preguntas para nueva materia
                MostrarPreguntaActual();
            }
            else
            {
                // Ya no hay más materias, ir a resultados finales
                FormResultados formResultados = new FormResultados(juego);
                formResultados.Show();
                this.Hide(); // Opcional: ocultar el formulario actual
            }
        }

        private void FormPregunta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormPregunta_Load(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            lblmateria.Left = (formWidth / 2) - (lblmateria.Width / 2);
            lblmateria.Top = formHeight / 4 - lblContador.Height - 20;

            lblContador.Left = (formWidth / 2) - (lblContador.Width / 2);
            lblContador.Top = formHeight / 4;

            lblPregunta.Left = (formWidth / 2) - (lblPregunta.Width / 2);
            lblPregunta.Top = (formHeight / 4) + lblContador.Height + 20;

            pnlOpciones.Left = (formWidth / 2) - (pnlOpciones.Width / 2);
            pnlOpciones.Top = (formHeight / 4) + (lblContador.Height + 20 + lblPregunta.Height + 20);

            lblestado.Left = (formWidth / 2) - (lblestado.Width / 2);
            lblestado.Top = (formHeight / 4) + (lblContador.Height + 20 + lblPregunta.Height + 20 + pnlOpciones.Height + 20);

            btnConfirmar.Left = (formWidth / 2) - (btnConfirmar.Width / 2);
            btnConfirmar.Top = (formHeight / 4) + (lblContador.Height + 20 + lblPregunta.Height + 20 + pnlOpciones.Height + 20 + lblestado.Height + 20);
        }

        private void FormPregunta_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormPregunta_ClientSizeChanged(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            lblmateria.Left = (formWidth / 2) - (lblmateria.Width / 2);
            lblmateria.Top = formHeight / 4 - lblContador.Height - 20;

            lblContador.Left = (formWidth / 2) - (lblContador.Width / 2);
            lblContador.Top = formHeight / 4;

            lblPregunta.Left = (formWidth / 2) - (lblPregunta.Width / 2);
            lblPregunta.Top = (formHeight / 4) + lblContador.Height + 20;

            pnlOpciones.Left = (formWidth / 2) - (pnlOpciones.Width / 2);
            pnlOpciones.Top = (formHeight / 4) + (lblContador.Height + 20 + lblPregunta.Height + 20);

            lblestado.Left = (formWidth / 2) - (lblestado.Width / 2);
            lblestado.Top = (formHeight / 4) + (lblContador.Height + 20 + lblPregunta.Height + 20 + pnlOpciones.Height + 20);

            btnConfirmar.Left = (formWidth / 2) - (btnConfirmar.Width / 2);
            btnConfirmar.Top = (formHeight / 4) + (lblContador.Height + 20 + lblPregunta.Height + 20 + pnlOpciones.Height + 20 + lblestado.Height + 20);

        }

        private void rbOpcion1_CheckedChanged(object sender, EventArgs e)
        {

            btnConfirmar_Click(sender, e);

        }

        private void rbOpcion2_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmar_Click(sender, e);
        }

        private void rbOpcion3_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmar_Click(sender, e);
        }

        private void rbOpcion4_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmar_Click(sender, e);
        }
    }
}
