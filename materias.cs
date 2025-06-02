using JuegoJIAv2;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoJIAv2
{
    public class JJuego
    {
        public Jugador JugadorActual { get; set; }
        public List<Materia> Materias { get; set; }
        public bool EstaActivo { get; set; }
        private Aleatorizador aleatorizador;

        // Lista para almacenar las preguntas seleccionadas para el cuestionario
        public List<Pregunta> PreguntasSeleccionadas { get; private set; }

        // Índice de la pregunta actual
        public int PreguntaActualIndex { get; set; }
        public JJuego()
        {
            Materias = new List<Materia>();
            EstaActivo = false;
            aleatorizador = new Aleatorizador();
            PreguntasSeleccionadas = new List<Pregunta>();
            PreguntaActualIndex = 0;
            InicializarMaterias();
        }

        public void Iniciar(string nombreJugador)
        {
            EstaActivo = true;
            JugadorActual = new Jugador(nombreJugador);
        }



        // Método para seleccionar una materia
        public void SeleccionarMateria(int indiceMateria)
        {
            if (indiceMateria >= 0 && indiceMateria < Materias.Count)
            {
                JugadorActual.SeleccionMateria(Materias[indiceMateria]);
            }
        }

        // Método para preparar el cuestionario
        public void PrepararCuestionario()
        {
            if (JugadorActual.MateriaSeleccionada.Count == 0)
                return;
            Materia materiaSeleccionada = JugadorActual.MateriaSeleccionada[0];
            PreguntasSeleccionadas =    aleatorizador.Aleatorizar(materiaSeleccionada.GetPreguntas()).Take(10).ToList();
            PreguntaActualIndex = 0;
        }

        // Método para obtener la pregunta actual
        public Pregunta ObtenerPreguntaActual()
        {
            if (PreguntaActualIndex < PreguntasSeleccionadas.Count)
            {
                return PreguntasSeleccionadas[PreguntaActualIndex];
            }
            return null;
        }

        // Método para verificar la respuesta y avanzar a la siguiente pregunta

        public bool VerificarRespuesta(int indiceRespuesta)
        {
            Pregunta preguntaActual = ObtenerPreguntaActual();
            bool esCorrecta = false;
            if (preguntaActual != null)
            {
                esCorrecta =
                preguntaActual.VerificarRespuesta(indiceRespuesta);
                if (esCorrecta)
                {
                    JugadorActual.Puntaje += 10;
                }
            }
            PreguntaActualIndex++;
            return esCorrecta;
        }
        // Método para verificar si el cuestionario ha terminado

        public bool CuestionarioTerminado()
        {
            return PreguntaActualIndex >= PreguntasSeleccionadas.Count;
        }

        // Método para obtener los resultados finales
        public string[] ObtenerResultados()
        {
            string[] resultados = new string[4];
            resultados[0] = JugadorActual.Nombre;
            resultados[1] =
            JugadorActual.MateriaSeleccionada[0].Nombre;
            resultados[2] = JugadorActual.Puntaje.ToString();
            resultados[3] = (JugadorActual.Puntaje >= 60) ?
            "¡Aprobado! 🎉" : "No aprobado. ¡Sigue estudiando! 📚";
            return resultados;
        }


        public void Terminar()
        {
            EstaActivo = false;
            Console.WriteLine("¡Gracias por jugar!");
        }


        private void InicializarMaterias()
        {
            // Álgebra
            Materia algebra = new Materia("Álgebra");
            algebra.BancoPregunta.AddRange(new List<Pregunta>
            {
                new Pregunta("Si 3x + 5 = 2x - 7, ¿cuál es x?", new List<Respuesta>
                {
                    new Respuesta("-12", true),
                    new Respuesta("12", false),
                    new Respuesta("-6", false),
                    new Respuesta("6", false)
                }),
                new Pregunta("Ana tiene el doble de la edad de Luis. Si hoy suman 45 años, ¿cuántos años tiene Ana?", new List<Respuesta>
                {
                    new Respuesta("15", false),
                    new Respuesta("20", false),
                    new Respuesta("30", true),
                    new Respuesta("45", false)
                }),
                new Pregunta("Un rectángulo tiene largo 3x y ancho x. Si su perímetro es 40 cm, ¿cuál es su área?", new List<Respuesta>
                {
                    new Respuesta("15 cm²", false),
                    new Respuesta("30 cm²", false),
                    new Respuesta("75 cm²", true),
                    new Respuesta("100 cm²", false)
                }),
                new Pregunta("Si 2x - y = 4 y x + y = 5, ¿cuánto es x · y?", new List<Respuesta>
                {
                    new Respuesta("6", true),
                    new Respuesta("8", false),
                    new Respuesta("10", false),
                    new Respuesta("12", false)
                }),
                new Pregunta("¿Para qué valor de k la ecuación x² - kx + 9 = 0 tiene una raíz doble?", new List<Respuesta>
                {
                    new Respuesta("3", false),
                    new Respuesta("6", true),
                    new Respuesta("9", false),
                    new Respuesta("12", false)
                }),
                new Pregunta("Si un tren viaja 200 km y tarda 4 horas, ¿cuál es su velocidad?", new List<Respuesta>
                {
                    new Respuesta("40 km/h", false),
                    new Respuesta("50 km/h", true),
                    new Respuesta("60 km/h", false),
                    new Respuesta("80 km/h", false)
                }),
                new Pregunta("Si a + b = 5 y ab = 6, ¿cuánto es a² + b²?", new List<Respuesta>
                {
                    new Respuesta("13", true),
                    new Respuesta("25", false),
                    new Respuesta("37", false),
                    new Respuesta("49", false)
                }),
                new Pregunta("¿Qué ecuación es paralela a y = 2x + 1?", new List<Respuesta>
                {
                    new Respuesta("y = -2x", false),
                    new Respuesta("y = 2x - 3", true),
                    new Respuesta("y = (1/2)x", false),
                    new Respuesta("y = x + 1", false)
                }),
                new Pregunta("Si x/3 = y/6 y x + y = 18, ¿cuánto es x?", new List<Respuesta>
                {
                    new Respuesta("6", true),
                    new Respuesta("9", false),
                    new Respuesta("12", false),
                    new Respuesta("15", false)
                }),
                new Pregunta("Si 2x - 4 = 10, ¿cuál es x?", new List<Respuesta>
                {
                    new Respuesta("5", false),
                    new Respuesta("7", true),
                    new Respuesta("10", false),
                    new Respuesta("14", false)
                }),
                new Pregunta("Un número es 3 mayor que otro. Si su producto es 18, ¿cuál es el mayor?", new List<Respuesta>
                {
                    new Respuesta("3", false),
                    new Respuesta("6", true),
                    new Respuesta("9", false),
                    new Respuesta("12", false)
                }),
                new Pregunta("Si 2^x = 16, ¿cuánto es 3x - 1?", new List<Respuesta>
                {
                    new Respuesta("5", false),
                    new Respuesta("11", true),
                    new Respuesta("14", false),
                    new Respuesta("17", false)
                }),
                new Pregunta("¿Qué expresión es un número par?", new List<Respuesta>
                {
                    new Respuesta("2n + 1", false),
                    new Respuesta("3n", false),
                    new Respuesta("2n", true),
                    new Respuesta("n²", false)
                }),
                new Pregunta("Si |x + 2| = 5, ¿cuál es la suma de las soluciones?", new List<Respuesta>
                {
                    new Respuesta("3", false),
                    new Respuesta("-4", false),
                    new Respuesta("-2", true),
                    new Respuesta("10", false)
                }),
                new Pregunta("¿Cuánto es x en 3(x - 1) = 12?", new List<Respuesta>
                {
                    new Respuesta("3", false),
                    new Respuesta("5", true),
                    new Respuesta("6", false),
                    new Respuesta("15", false)
                }),
                new Pregunta("Si f(x) = x + 4 y g(x) = 2x, ¿cuánto es f(g(2))?", new List<Respuesta>
                {
                    new Respuesta("6", false),
                    new Respuesta("8", true),
                    new Respuesta("10", false),
                    new Respuesta("12", false)
                }),
                new Pregunta("Tres números consecutivos suman 36. ¿Cuál es el mayor?", new List<Respuesta>
                {
                    new Respuesta("11", false),
                    new Respuesta("12", false),
                    new Respuesta("13", true),
                    new Respuesta("14", false)
                }),
                new Pregunta("Si √x = 5, ¿cuánto es x?", new List<Respuesta>
                {
                    new Respuesta("5", false),
                    new Respuesta("10", false),
                    new Respuesta("15", false),
                    new Respuesta("25", true)
                }),
                new Pregunta("¿Qué valor de x resuelve x² = 25?", new List<Respuesta>
                {
                    new Respuesta("5", false),
                    new Respuesta("-5", false),
                    new Respuesta("5 y -5", true),
                    new Respuesta("10", false)
                }),
                new Pregunta("Si x = 3, ¿cuánto es 2x² - 5?", new List<Respuesta>
                {
                    new Respuesta("13", true),
                    new Respuesta("15", false),
                    new Respuesta("18", false),
                    new Respuesta("23", false)
                })
            });

            // Geometría y Trigonometría
            Materia geometria = new Materia("Geometría y Trigonometría");
            geometria.BancoPregunta.AddRange(new List<Pregunta>
            {
                new Pregunta("Convierte 5^x = 125 a su forma logarítmica:", new List<Respuesta>
                {
                    new Respuesta("log₅(125) = x", true),
                    new Respuesta("log₁₂₅(5) = x", false),
                    new Respuesta("logₓ(5) = 125", false)
                }),
                new Pregunta("¿Cuál es la solución de 2^(3x+1) = 16?", new List<Respuesta>
                {
                    new Respuesta("x = 1", true),
                    new Respuesta("x = 2", false),
                    new Respuesta("x = 0.5", false)
                }),
                new Pregunta("Un material radiactivo reduce su masa a la mitad cada 20 años. Si hay 80 gramos iniciales, ¿cuántos quedarán después de 60 años?", new List<Respuesta>
                {
                    new Respuesta("10 g", true),
                    new Respuesta("20 g", false),
                    new Respuesta("40 g", false)
                }),
                new Pregunta("La gráfica de y = log₂(x) tiene una asíntota en:", new List<Respuesta>
                {
                    new Respuesta("x = 0", true),
                    new Respuesta("y = 0", false),
                    new Respuesta("x = 1", false)
                }),
                new Pregunta("¿Qué propiedad se aplica en log(MN) = log(M) + log(N)?", new List<Respuesta>
                {
                    new Respuesta("Producto", true),
                    new Respuesta("Cociente", false),
                    new Respuesta("Potencia", false)
                }),
                new Pregunta("¿Cuál es la suma de los ángulos internos de un pentágono regular?", new List<Respuesta>
                {
                    new Respuesta("540°", true),
                    new Respuesta("360°", false),
                    new Respuesta("180°", false)
                }),
                new Pregunta("Un triángulo con lados 7 cm, 24 cm y 25 cm es:", new List<Respuesta>
                {
                    new Respuesta("Rectángulo", true),
                    new Respuesta("Equilátero", false),
                    new Respuesta("Obtusángulo", false)
                }),
                new Pregunta("En un triángulo isósceles, la altura correspondiente a la base también es:", new List<Respuesta>
                {
                    new Respuesta("Mediana y bisectriz", true),
                    new Respuesta("Solo mediana", false),
                    new Respuesta("Solo bisectriz", false)
                }),
                new Pregunta("El área de un hexágono regular inscrito en una circunferencia de radio 10 cm es:", new List<Respuesta>
                {
                    new Respuesta("150√3 cm²", true),
                    new Respuesta("100√2 cm²", false),
                    new Respuesta("200 cm²", false)
                }),
                new Pregunta("¿Qué postulado de Euclides establece que 'todos los ángulos rectos son iguales'?", new List<Respuesta>
                {
                    new Respuesta("Quinto postulado", false),
                    new Respuesta("Cuarto postulado", true),
                    new Respuesta("Tercer postulado", false)
                }),
                new Pregunta("En un triángulo rectángulo, si un cateto mide 5 cm y la hipotenusa 13 cm, ¿cuánto mide el otro cateto?", new List<Respuesta>
                {
                    new Respuesta("12 cm", true),
                    new Respuesta("10 cm", false),
                    new Respuesta("8 cm", false)
                }),
                new Pregunta("¿Cuál es el valor de sin(30°)?", new List<Respuesta>
                {
                    new Respuesta("1/2", true),
                    new Respuesta("√3/2", false),
                    new Respuesta("1", false)
                }),
                new Pregunta("Resuelve 2sin(x) - 1 = 0 en [0, 2π]:", new List<Respuesta>
                {
                    new Respuesta("π/6 y 5π/6", true),
                    new Respuesta("π/3 y 2π/3", false),
                    new Respuesta("π/4 y 3π/4", false)
                }),
                new Pregunta("La identidad tan(θ) · cot(θ) es igual a:", new List<Respuesta>
                {
                    new Respuesta("1", true),
                    new Respuesta("sin(θ)", false),
                    new Respuesta("cos(θ)", false)
                }),
                new Pregunta("Desde un punto en el suelo, el ángulo de elevación a un edificio es 60°. Si la distancia al edificio es 30 m, su altura es:", new List<Respuesta>
                {
                    new Respuesta("30√3 m", true),
                    new Respuesta("15√3 m", false),
                    new Respuesta("30 m", false)
                }),
                new Pregunta("¿Qué función modela un crecimiento bacteriano que se duplica cada 4 horas?", new List<Respuesta>
                {
                    new Respuesta("N(t) = N₀ · 2^(t/4)", true),
                    new Respuesta("N(t) = N₀ · e^(4t)", false),
                    new Respuesta("N(t) = N₀ · 4^t", false)
                }),
                new Pregunta("Si log₃(81) = x, ¿cuál es el valor de x?", new List<Respuesta>
                {
                    new Respuesta("4", true),
                    new Respuesta("3", false),
                    new Respuesta("27", false)
                }),
                new Pregunta("¿Cuál es el perímetro de un cuadrado inscrito en una circunferencia de radio 5 cm?", new List<Respuesta>
                {
                    new Respuesta("20√2 cm", true),
                    new Respuesta("25 cm", false),
                    new Respuesta("10√2 cm", false)
                }),
                new Pregunta("La identidad sin²(x) + cos²(x) es igual a:", new List<Respuesta>
                {
                    new Respuesta("1", true),
                    new Respuesta("tan(x)", false),
                    new Respuesta("sec(x)", false)
                }),
                new Pregunta("Un avión vuela a 10,000 m de altura. Si el ángulo de depresión a un barco es 30°, ¿a qué distancia horizontal está el barco?", new List<Respuesta>
                {
                    new Respuesta("10,000√3 m", true),
                    new Respuesta("10,000 m", false),
                    new Respuesta("5,000√3 m", false)
                })
            });

            // Desarrollo Personal - Solo agregando las primeras 10 para el ejemplo
            Materia desarrolloPersonal = new Materia("Desarrollo Personal");
            desarrolloPersonal.BancoPregunta.AddRange(new List<Pregunta>
            {
                new Pregunta("¿Qué es la autoestima?", new List<Respuesta>
                {
                    new Respuesta("La cantidad de amigos que tienes", false),
                    new Respuesta("La valoración que tienes de ti mismo", true),
                    new Respuesta("El dinero que ganas al mes", false),
                    new Respuesta("Tu habilidad para dibujar", false)
                }),
                new Pregunta("¿Cuál es un ejemplo de comunicación asertiva?", new List<Respuesta>
                {
                    new Respuesta("Gritar cuando estás enojado", false),
                    new Respuesta("Decir lo que piensas sin ofender a otros y respetando la opinión de los otros", true),
                    new Respuesta("Ignorar a las personas", false),
                    new Respuesta("Hablar solo cuando te lo pidan", false)
                }),
                new Pregunta("¿Qué ayuda a manejar el estrés?", new List<Respuesta>
                {
                    new Respuesta("Dormir menos", false),
                    new Respuesta("Hacer ejercicio y respirar profundamente", true),
                    new Respuesta("Comer mucha comida chatarra", false),
                    new Respuesta("Evitar hablar de tus problemas", false)
                }),
                new Pregunta("¿Qué es la inteligencia emocional?", new List<Respuesta>
                {
                    new Respuesta("Saber resolver ecuaciones matemáticas", false),
                    new Respuesta("Reconocer y manejar tus emociones y las de los demás", true),
                    new Respuesta("Memorizar muchos datos históricos", false),
                    new Respuesta("Tener muchos seguidores en redes sociales", false)
                }),
                new Pregunta("¿Cuál es un valor importante en las relaciones personales?", new List<Respuesta>
                {
                    new Respuesta("La envidia", false),
                    new Respuesta("El respeto", true),
                    new Respuesta("La impuntualidad", false),
                    new Respuesta("El egoísmo", false)
                }),
                new Pregunta("¿Qué es un proyecto de vida?", new List<Respuesta>
                {
                    new Respuesta("Un plan para ganar la lotería", false),
                    new Respuesta("Un conjunto de metas personales y profesionales", true),
                    new Respuesta("Una lista de compras del supermercado", false),
                    new Respuesta("Un videojuego favorito", false)
                }),
                new Pregunta("¿Qué promueve el trabajo en equipo?", new List<Respuesta>
                {
                    new Respuesta("La colaboración y el respeto", true),
                    new Respuesta("Competir individualmente", false),
                    new Respuesta("Evitar hablar con los compañeros", false),
                    new Respuesta("Hacer todo solo", false)
                }),
                new Pregunta("¿Qué es la empatía?", new List<Respuesta>
                {
                    new Respuesta("Ponerse en el lugar del otro", true),
                    new Respuesta("Ser el más fuerte del grupo", false),
                    new Respuesta("Tener la razón siempre", false),
                    new Respuesta("Ignorar los problemas ajenos", false)
                }),
                new Pregunta("¿Qué ayuda a tomar decisiones responsables?", new List<Respuesta>
                {
                    new Respuesta("Actuar sin pensar", false),
                    new Respuesta("Analizar las consecuencias", true),
                    new Respuesta("Seguir siempre lo que dicen los demás", false),
                    new Respuesta("Dejar todo al azar", false)
                }),
                new Pregunta("¿Cuál es una habilidad social importante?", new List<Respuesta>
                {
                    new Respuesta("Saber escuchar", true),
                    new Respuesta("Interrumpir a los demás", false),
                    new Respuesta("Hablar solo de uno mismo", false),
                    new Respuesta("Evitar contacto visual", false)
                }),
                new Pregunta("¿Qué significa resiliencia?", new List<Respuesta>
                {
                    new Respuesta("Rendirse ante los problemas", false),
                    new Respuesta("Superar adversidades y aprender de ellas", true),
                    new Respuesta("Evitar los desafíos", false),
                    new Respuesta("Culpar a otros por los errores", false)
                }),
                new Pregunta("¿Qué es un conflicto interpersonal?", new List<Respuesta>
                {
                    new Respuesta("Un problema matemático", false),
                    new Respuesta("Un desacuerdo entre personas", true),
                    new Respuesta("Una enfermedad contagiosa", false),
                    new Respuesta("Un juego de video", false)
                }),
                new Pregunta("¿Qué favorece una buena convivencia?", new List<Respuesta>
                {
                    new Respuesta("El respeto y la tolerancia", true),
                    new Respuesta("Criticar a los demás", false),
                    new Respuesta("Ignorar las reglas", false),
                    new Respuesta("Hablar mal de otros", false)
                }),
                new Pregunta("¿Qué es la asertividad?", new List<Respuesta>
                {
                    new Respuesta("Expresar opiniones de manera clara y respetuosa", true),
                    new Respuesta("Guardar silencio siempre", false),
                    new Respuesta("Ser agresivo al hablar", false),
                    new Respuesta("Cambiar de opinión frecuentemente", false)
                }),
                new Pregunta("¿Qué es la automotivación?", new List<Respuesta>
                {
                    new Respuesta("Encontrar razones propias para lograr metas", true),
                    new Respuesta("Esperar que otros te animen", false),
                    new Respuesta("Depender de premios materiales", false),
                    new Respuesta("Rendirse fácilmente", false)
                }),
                new Pregunta("¿Qué ayuda a mejorar la autoestima?", new List<Respuesta>
                {
                    new Respuesta("Compararse con otros", false),
                    new Respuesta("Reconocer las propias cualidades", true),
                    new Respuesta("Fijarse solo en los errores", false),
                    new Respuesta("Evitar nuevos retos", false)
                }),
                new Pregunta("¿Qué es el autocontrol?", new List<Respuesta>
                {
                    new Respuesta("Manejar impulsos y emociones", true),
                    new Respuesta("Dejarse llevar por el enojo", false),
                    new Respuesta("Hacer lo que otros digan", false),
                    new Respuesta("Evitar responsabilidades", false)
                }),
            }
            );
            Materias.Add(algebra);
            Materias.Add(geometria);
            Materias.Add(desarrolloPersonal);
            //Materias.Add();
        }
    }
}
