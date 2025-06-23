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
    public partial class FormHistoria : Form
    {
        private JJuego juego;

        public FormHistoria(JJuego juego)
        {
            InitializeComponent();
            this.juego = juego;


        }

        private void FormHistoria_Load(object sender, EventArgs e)
        {
            richTextBox1.Left = (this.ClientSize.Width - richTextBox1.Width) / 2;
            richTextBox1.Top = (this.ClientSize.Height - richTextBox1.Height) / 2;

            richTextBox1.Text =
              @"                                                                                                                                            EL ÚLTIMO EXÁMEN
                                                                                                                                                    Mi fracaso:
Miré el papel con mis calificaciones por tercera vez esa mañana. Los números rojos parecían burlarse de mí desde la hoja arrugada: tres materias reprobadas, dos apenas aprobadas con seis, y el resto con calificaciones que no alcanzaban para salvar mi promedio. Mi segundo semestre estaba perdido, y con él, probablemente mi futuro en la universidad.
El pasillo hacia la dirección nunca me había parecido tan largo. Cada paso resonaba en las paredes vacías del edificio administrativo, como si el eco mismo me recordara mi fracaso. Mis padres no lo sabían aún. ¿Cómo les diría que después de todo el esfuerzo que habían hecho para pagar mis estudios, yo había desperdiciado la oportunidad?

*La Propuesta
La directora era conocida por su severidad pero también por su extraña compasión hacia los estudiantes en problemas. Cuando toqué la puerta de su oficina, sentí como si estuviera tocando la puerta de mi destino.

—Pase adelante, Diego. Ya sé por qué está aquí.

La mujer de cabello gris me miró desde detrás de su escritorio, sus ojos penetrantes estudiando cada uno de mis gestos. Tragué saliva antes de hablar.

—Licenciada, yo... necesito una oportunidad. Sé que mis calificaciones no son buenas, pero puedo mejorar. Mi familia...

—Su familia confió en usted, Diego. Y usted los defraudó. 

Las palabras cayeron como piedras en el silencio de la oficina

—. Pero... continuó, y sentí un destello de esperanza— todos merecemos una segunda oportunidad. Aunque esta será la única que tendrá.

La directora abrió un cajón de su escritorio y sacó un folder grueso, lleno de papeles.

—Le voy a ofrecer un trato. Diez exámenes, uno por cada materia que ha cursado en estos dos semestres. Cada examen vale diez puntos. Para pasar al tercer semestre, necesita obtener al menos 75 puntos de los 100 posibles.
Sentí que el corazón se me aceleraba. Una oportunidad. 

Realmente me estaba dando una oportunidad.

—Pero hay condiciones —continuó la Directora, su voz volviéndose más seria.
-Si reprueba completamente dos materias, el trato se cancela automáticamente. No importa cuántos puntos tenga en las otras. Y si obtiene 74 puntos o menos, también reprueba. No hay excepciones, no hay puntos extra, no hay consideraciones especiales. ¿Entiende?

—Sí, licenciada. Entiendo.

—Una cosa más. He mezclado las preguntas. No serán solo de las materias obvias. Algunas preguntas de compuación aparecerán junto con matemáticas, algunas de Expresión oral  con Algeba. He hecho esto porque quiero ver si realmente ha aprendido algo en estos dos semestres, no solo si puede memorizar para un examen específico.


Asentí, sintiendo cómo la adrenalina comenzaba a correr por mis venas. Era mi oportunidad, tal vez la única que tendría.

—¿Cuándo empiezo?

La directora sonrió, pero no era una sonrisa amable. Era la sonrisa de alguien que había visto a muchos estudiantes fracasar en situaciones similares.

—Ahora mismo. Tiene dos horas para completar los diez exámenes. Y Diego... —se detuvo mientras me dirigía hacia la puerta— recuerde que la vida no siempre es justa. A veces, estar a un punto de distancia sigue siendo un fracaso. Espero que esté preparado para esa realidad.

Salí de la oficina con el folder en las manos, sintiendo el peso de mi futuro entre esas páginas. En dos horas sabría si continuaría mis estudios o si tendría que enfrentar a mi familia con la noticia de mi fracaso definitivo.
Me dirigí al aula asignada, donde me esperaba una mesa, una silla, y la prueba más importante de mi vida. Al abrir el folder, vi la primera pregunta y respiré profundo.

Mi segunda oportunidad había comenzado.
";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de selección de materia
            FormSeleccionMateria formSeleccion = new
            FormSeleccionMateria(juego);
            formSeleccion.Show();
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          

        }
    }
    
}
