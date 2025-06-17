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
            PreguntasSeleccionadas = aleatorizador.Aleatorizar(materiaSeleccionada.GetPreguntas()).Take(10).ToList();
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
        public string[] ObtenerResultados(int indice)
        {
            string[] resultados = new string[4];
            resultados[0] = JugadorActual.Nombre;
            resultados[1] =
            JugadorActual.MateriaSeleccionada[0].Nombre;
            resultados[2] = JugadorActual.Puntaje.ToString();
            resultados[3] = (JugadorActual.Puntaje >= 70) ? "¡Aprobado! " : "No aprobado. ¡Sigue estudiando! ";
            return resultados;
        }


        public void Terminar()
        {
            EstaActivo = false;
            Console.WriteLine("¡Gracias por jugar!");
        }


        private void InicializarMaterias()
        {
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

            new Pregunta("¿Qué postulado de Euclides establece que \"todos los ángulos rectos son iguales\"?", new List<Respuesta>
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

                new Pregunta("¿Qué es un valor ético?", new List<Respuesta>
                {
                    new Respuesta("La honestidad", true),
                    new Respuesta("Engañar para ganar", false),
                    new Respuesta("Ser injusto", false),
                    new Respuesta("Ignorar las reglas", false)
                }),

                new Pregunta("¿Qué fomenta la confianza en uno mismo?", new List<Respuesta>
                {
                    new Respuesta("Lograr pequeñas metas", true),
                    new Respuesta("Depender siempre de otros", false),
                    new Respuesta("Evitar desafíos", false),
                    new Respuesta("Criticarse constantemente", false)
                }),

                new Pregunta("¿Qué es la responsabilidad social?", new List<Respuesta>
                {
                    new Respuesta("Contribuir al bienestar de la comunidad", true),
                    new Respuesta("Pensar solo en uno mismo", false),
                    new Respuesta("Ignorar problemas ambientales", false),
                    new Respuesta("No ayudar a nadie", false)
                })
            });
            Materia desarrolloHabilidadesPensamiento = new Materia("Desarrollo de Habilidades del Pensamiento");
            desarrolloHabilidadesPensamiento.BancoPregunta.AddRange(new List<Pregunta>
            {
                new Pregunta("¿Qué es el pensamiento crítico?", new List<Respuesta>
                {
                    new Respuesta("Memorizar información", false),
                    new Respuesta("Analizar y evaluar ideas de manera lógica", true),
                    new Respuesta("Creer todo lo que se escucha", false),
                    new Respuesta("Evitar hacer preguntas", false)
                }),

                new Pregunta("¿Qué es una inferencia?", new List<Respuesta>
                {
                    new Respuesta("Sacar conclusiones con base en pistas", true),
                    new Respuesta("Repetir información textual", false),
                    new Respuesta("Ignorar datos importantes", false),
                    new Respuesta("Copiar sin entender", false)
                }),

                new Pregunta("¿Qué ayuda a mejorar la memoria?", new List<Respuesta>
                {
                    new Respuesta("Dormir poco", false),
                    new Respuesta("Hacer resúmenes y mapas mentales", true),
                    new Respuesta("Evitar repasar", false),
                    new Respuesta("Estudiar solo una vez", false)
                }),

                new Pregunta("¿Qué es el razonamiento lógico?", new List<Respuesta>
                {
                    new Respuesta("Usar principios válidos para resolver problemas", true),
                    new Respuesta("Adivinar las respuestas", false),
                    new Respuesta("Seguir corazonadas", false),
                    new Respuesta("Ignorar evidencias", false)
                }),

                new Pregunta("¿Qué es una analogía?", new List<Respuesta>
                {
                    new Respuesta("Establecer relaciones entre conceptos similares", true),
                    new Respuesta("Repetir la misma palabra", false),
                    new Respuesta("Usar lenguaje complicado", false),
                    new Respuesta("Ignorar diferencias", false)
                }),

                new Pregunta("¿Qué es la síntesis?", new List<Respuesta>
                {
                    new Respuesta("Resumir ideas principales con tus palabras", true),
                    new Respuesta("Copiar texto literal", false),
                    new Respuesta("Agregar información innecesaria", false),
                    new Respuesta("Dejar incompleto un tema", false)
                }),

                new Pregunta("¿Qué es brainstorming?", new List<Respuesta>
                {
                    new Respuesta("Generar muchas ideas sin juzgarlas", true),
                    new Respuesta("Criticar ideas rápidamente", false),
                    new Respuesta("Trabajar solo", false),
                    new Respuesta("Evitar la creatividad", false)
                }),

                new Pregunta("¿Qué es el pensamiento creativo?", new List<Respuesta>
                {
                    new Respuesta("Encontrar soluciones originales", true),
                    new Respuesta("Seguir siempre lo establecido", false),
                    new Respuesta("Evitar cambios", false),
                    new Respuesta("Copiar ideas de otros", false)
                }),

                new Pregunta("¿Qué es una falacia?", new List<Respuesta>
                {
                    new Respuesta("Un error en el razonamiento", true),
                    new Respuesta("Una verdad absoluta", false),
                    new Respuesta("Una ley científica", false),
                    new Respuesta("Un dato comprobado", false)
                }),

                new Pregunta("¿Qué es la deducción?", new List<Respuesta>
                {
                    new Respuesta("Partir de una generalidad para llegar a lo particular", true),
                    new Respuesta("Usar solo emociones", false),
                    new Respuesta("Ignorar premisas", false),
                    new Respuesta("Inventar sin fundamentos", false)
                }),

                new Pregunta("¿Qué es la inducción?", new List<Respuesta>
                {
                    new Respuesta("Partir de casos particulares para generalizar", true),
                    new Respuesta("Repetir sin analizar", false),
                    new Respuesta("Ignorar ejemplos", false),
                    new Respuesta("Usar solo opiniones", false)
                }),

                new Pregunta("¿Qué es un mapa mental?", new List<Respuesta>
                {
                    new Respuesta("Un diagrama que organiza ideas visualmente", true),
                    new Respuesta("Una lista sin orden", false),
                    new Respuesta("Un texto largo", false),
                    new Respuesta("Un dibujo abstracto", false)
                }),

                new Pregunta("¿Qué es el análisis?", new List<Respuesta>
                {
                    new Respuesta("Dividir un problema en partes para entenderlo", true),
                    new Respuesta("Ignorar detalles", false),
                    new Respuesta("Dar opiniones sin base", false),
                    new Respuesta("Memorizar sin comprender", false)
                }),

                new Pregunta("¿Qué es una hipótesis?", new List<Respuesta>
                {
                    new Respuesta("Una suposición a comprobar", true),
                    new Respuesta("Un hecho comprobado", false),
                    new Respuesta("Una opinión sin fundamento", false),
                    new Respuesta("Un dato irrelevante", false)
                }),

                new Pregunta("¿Qué es la metacognición?", new List<Respuesta>
                {
                    new Respuesta("Pensar sobre cómo aprendemos", true),
                    new Respuesta("Memorizar sin reflexión", false),
                    new Respuesta("Ignorar errores", false),
                    new Respuesta("Copiar información", false)
                }),

                new Pregunta("¿Qué es un argumento válido?", new List<Respuesta>
                {
                    new Respuesta("Uno con premisas que apoyan la conclusión", true),
                    new Respuesta("Una opinión sin pruebas", false),
                    new Respuesta("Un ataque personal", false),
                    new Respuesta("Una creencia sin lógica", false)
                }),

                new Pregunta("¿Qué es la abstracción?", new List<Respuesta>
                {
                    new Respuesta("Considerar las características esenciales de un concepto", true),
                    new Respuesta("Enfocarse en detalles irrelevantes", false),
                    new Respuesta("Ignorar patrones", false),
                    new Respuesta("Memorizar sin entender", false)
                }),

                new Pregunta("¿Qué es una paradoja?", new List<Respuesta>
                {
                    new Respuesta("Una idea que parece contradictoria pero puede ser cierta", true),
                    new Respuesta("Una mentira comprobada", false),
                    new Respuesta("Un dato sin importancia", false),
                    new Respuesta("Una regla inflexible", false)
                }),

                new Pregunta("¿Qué es el pensamiento lateral?", new List<Respuesta>
                {
                    new Respuesta("Resolver problemas con enfoques no convencionales", true),
                    new Respuesta("Seguir siempre lo obvio", false),
                    new Respuesta("Evitar la creatividad", false),
                    new Respuesta("Copiar soluciones", false)
                }),

                new Pregunta("¿Qué es una premisa?", new List<Respuesta>
                {
                    new Respuesta("Una idea que sirve de base para un argumento", true),
                    new Respuesta("Una conclusión sin apoyo", false),
                    new Respuesta("Una opinión personal", false),
                    new Respuesta("Un dato irrelevante", false)
                })
            });
            Materia biologiaBasica = new Materia("Biología Básica");
            biologiaBasica.BancoPregunta.AddRange(new List<Pregunta>
            {
                new Pregunta("¿Cuál es la función principal de las mitocondrias en la célula?", new List<Respuesta>
                {
                    new Respuesta("Almacenar agua", false),
                    new Respuesta("Producir energía en forma de ATP", true),
                    new Respuesta("Sintetizar proteínas", false)
                }),

                new Pregunta("¿Qué organelo celular contiene el material genético en células eucariotas?", new List<Respuesta>
                {
                    new Respuesta("Aparato de Golgi", false),
                    new Respuesta("Retículo endoplásmico", false),
                    new Respuesta("Núcleo", true)
                }),

                new Pregunta("La fotosíntesis ocurre principalmente en:", new List<Respuesta>
                {
                    new Respuesta("Mitocondrias", false),
                    new Respuesta("Cloroplastos", true),
                    new Respuesta("Ribosomas", false)
                }),

                new Pregunta("¿Cuál es la unidad funcional del riñón?", new List<Respuesta>
                {
                    new Respuesta("Alvéolo", false),
                    new Respuesta("Nefrona", true),
                    new Respuesta("Neurona", false)
                }),

                new Pregunta("El proceso de división celular que da lugar a células reproductivas se llama:", new List<Respuesta>
                {
                    new Respuesta("Mitosis", false),
                    new Respuesta("Meiosis", true),
                    new Respuesta("Citocinesis", false)
                }),

                new Pregunta("¿Qué vitamina se produce en la piel con ayuda de la luz solar?", new List<Respuesta>
                {
                    new Respuesta("Vitamina C", false),
                    new Respuesta("Vitamina A", false),
                    new Respuesta("Vitamina D", true)
                }),

                new Pregunta("Las células sanguíneas responsables de la coagulación son:", new List<Respuesta>
                {
                    new Respuesta("Leucocitos", false),
                    new Respuesta("Plaquetas", true),
                    new Respuesta("Eritrocitos", false)
                }),

                new Pregunta("¿Cuál es el órgano más grande del cuerpo humano?", new List<Respuesta>
                {
                    new Respuesta("Intestino delgado", false),
                    new Respuesta("Corazón", false),
                    new Respuesta("Piel", true)
                }),

                new Pregunta("La molécula que almacena la información genética es:", new List<Respuesta>
                {
                    new Respuesta("ARN", false),
                    new Respuesta("ADN", true),
                    new Respuesta("Proteína", false)
                }),

                new Pregunta("¿Qué estructura celular es responsable de la síntesis de proteínas?", new List<Respuesta>
                {
                    new Respuesta("Lisosoma", false),
                    new Respuesta("Vacuola", false),
                    new Respuesta("Ribosoma", true)
                }),

                new Pregunta("El proceso de intercambio gaseoso en los pulmones ocurre en:", new List<Respuesta>
                {
                    new Respuesta("Bronquios", false),
                    new Respuesta("Alvéolos", true),
                    new Respuesta("Tráquea", false)
                }),

                new Pregunta("¿Cuál es la principal función del sistema linfático?", new List<Respuesta>
                {
                    new Respuesta("Transportar oxígeno", false),
                    new Respuesta("Defender el organismo", true),
                    new Respuesta("Digerir alimentos", false)
                }),

                new Pregunta("Las hormonas son producidas por:", new List<Respuesta>
                {
                    new Respuesta("Músculos", false),
                    new Respuesta("Neuronas", false),
                    new Respuesta("Glándulas endocrinas", true)
                }),

                new Pregunta("¿Qué tipo de tejido conecta los músculos con los huesos?", new List<Respuesta>
                {
                    new Respuesta("Cartílago", false),
                    new Respuesta("Tendón", true),
                    new Respuesta("Ligamento", false)
                }),

                new Pregunta("La unidad básica del sistema nervioso es:", new List<Respuesta>
                {
                    new Respuesta("Dendrita", false),
                    new Respuesta("Axón", false),
                    new Respuesta("Neurona", true)
                }),

                new Pregunta("¿Cuál es la función principal del páncreas?", new List<Respuesta>
                {
                    new Respuesta("Filtrar la sangre", false),
                    new Respuesta("Producir bilis", false),
                    new Respuesta("Secretar insulina y enzimas digestivas", true)
                }),

                new Pregunta("Los cromosomas están formados principalmente por:", new List<Respuesta>
                {
                    new Respuesta("Lípidos", false),
                    new Respuesta("ADN y proteínas", true),
                    new Respuesta("Carbohidratos", false)
                }),

                new Pregunta("¿Qué estructura del ojo es responsable de enfocar la luz?", new List<Respuesta>
                {
                    new Respuesta("Retina", false),
                    new Respuesta("Cristalino", true),
                    new Respuesta("Córnea", false)
                }),

                new Pregunta("La homeostasis se refiere a:", new List<Respuesta>
                {
                    new Respuesta("Producción de hormonas", false),
                    new Respuesta("Digestión de alimentos", false),
                    new Respuesta("Mantener el equilibrio interno", true)
                }),

                new Pregunta("¿Cuál es la función principal de los glóbulos blancos?", new List<Respuesta>
                {
                    new Respuesta("Transportar oxígeno", false),
                    new Respuesta("Coagular la sangre", false),
                    new Respuesta("Defender contra patógenos", true)
                })
            });
            // Computación Básica
            Materia computacionbasica = new Materia("Computación Básica");
            computacionbasica.BancoPregunta.AddRange(new List<Pregunta>
            {
                new Pregunta("¿Cuál es la función principal del sistema operativo?", new List<Respuesta>
                {
                    new Respuesta("Reproducir música", false),
                    new Respuesta("Administrar los recursos del hardware y software", true),
                    new Respuesta("Únicamente ejecutar videojuegos", false)
                }),
                new Pregunta("¿Qué es un algoritmo?", new List<Respuesta>
                {
                    new Respuesta("Serie de pasos ordenados para resolver un problema", true),
                    new Respuesta("Un programa de computadora", false),
                    new Respuesta("Un dispositivo de entrada", false)
                }),
                new Pregunta("¿Qué significa CPU?", new List<Respuesta>
                {
                    new Respuesta("Control de Programas Unidos", false),
                    new Respuesta("Unidad Central de Procesamiento", true),
                    new Respuesta("Centro de Procesos Únicos", false)
                }),
                new Pregunta("En programación, ¿qué es una variable?", new List<Respuesta>
                {
                    new Respuesta("Un número fijo que no cambia", false),
                    new Respuesta("Un espacio en memoria que almacena datos", true),
                    new Respuesta("Una operación matemática", false)
                }),
                new Pregunta("¿Cuál es un ejemplo de software de sistema?", new List<Respuesta>
                {
                    new Respuesta("Microsoft Word", false),
                    new Respuesta("Adobe Photoshop", false),
                    new Respuesta("Windows 10", true)
                }),
                new Pregunta("¿Qué es un diagrama de flujo?", new List<Respuesta>
                {
                    new Respuesta("Representación gráfica de un algoritmo", true),
                    new Respuesta("Un tipo de gráfica estadística", false),
                    new Respuesta("Un dibujo decorativo", false)
                }),
                new Pregunta("¿Qué es la memoria RAM?", new List<Respuesta>
                {
                    new Respuesta("Un disco duro", false),
                    new Respuesta("Memoria de acceso aleatorio temporal", true),
                    new Respuesta("Un procesador secundario", false)
                }),
                new Pregunta("¿Cuál es un dispositivo de entrada?", new List<Respuesta>
                {
                    new Respuesta("Teclado", true),
                    new Respuesta("Monitor", false),
                    new Respuesta("Impresora", false)
                }),
                new Pregunta("¿Qué es un ciclo en programación?", new List<Respuesta>
                {
                    new Respuesta("Un error en el programa", false),
                    new Respuesta("Una estructura que repite instrucciones", true),
                    new Respuesta("Un tipo de variable", false)
                }),
                new Pregunta("¿Qué significa WWW?", new List<Respuesta>
                {
                    new Respuesta("World Wide Web Services", false),
                    new Respuesta("World Wide Web", true),
                    new Respuesta("World Web Windows", false)
                }),
                new Pregunta("¿Qué es un puerto USB?", new List<Respuesta>
                {
                    new Respuesta("Interfaz para conectar dispositivos", true),
                    new Respuesta("Un tipo de memoria", false),
                    new Respuesta("Un programa de computadora", false)
                }),
                new Pregunta("¿Cuál es la función del disco duro?", new List<Respuesta>
                {
                    new Respuesta("Procesar datos", false),
                    new Respuesta("Almacenar información permanentemente", true),
                    new Respuesta("Mostrar imágenes", false)
                }),
                new Pregunta("¿Qué es un compilador?", new List<Respuesta>
                {
                    new Respuesta("Programa que traduce código a lenguaje máquina", true),
                    new Respuesta("Un tipo de virus", false),
                    new Respuesta("Un dispositivo de almacenamiento", false)
                }),
                new Pregunta("¿Qué es una red LAN?", new List<Respuesta>
                {
                    new Respuesta("Un tipo de programa", false),
                    new Respuesta("Red de área local", true),
                    new Respuesta("Un sistema operativo", false)
                }),
                new Pregunta("¿Qué es un bit?", new List<Respuesta>
                {
                    new Respuesta("Unidad mínima de información digital", true),
                    new Respuesta("Un tipo de archivo", false),
                    new Respuesta("Un programa pequeño", false)
                }),
                new Pregunta("¿Cuál es la función principal del navegador web?", new List<Respuesta>
                {
                    new Respuesta("Editar documentos", false),
                    new Respuesta("Acceder a páginas web", true),
                    new Respuesta("Almacenar archivos", false)
                }),
                new Pregunta("¿Qué es un periférico?", new List<Respuesta>
                {
                    new Respuesta("Dispositivo auxiliar del computador", true),
                    new Respuesta("Un tipo de memoria", false),
                    new Respuesta("Un programa del sistema", false)
                }),
                new Pregunta("¿Qué es un archivo ejecutable?", new List<Respuesta>
                {
                    new Respuesta("Un documento de texto", false),
                    new Respuesta("Archivo que contiene un programa", true),
                    new Respuesta("Una imagen digital", false)
                }),
                new Pregunta("¿Qué es el hardware?", new List<Respuesta>
                {
                    new Respuesta("Componentes físicos de la computadora", true),
                    new Respuesta("Programas instalados", false),
                    new Respuesta("Archivos guardados", false)
                }),
                new Pregunta("¿Qué es un sistema binario?", new List<Respuesta>
                {
                    new Respuesta("Un tipo de programa", false),
                    new Respuesta("Un dispositivo de entrada", false),
                    new Respuesta("Sistema numérico base 2", true)
                })
            });

            // Filosofía II
            Materia filosofiaII = new Materia("Filosofía II");
            filosofiaII.BancoPregunta.AddRange(new List<Pregunta>
            {
                new Pregunta("¿Qué forma del pensamiento se define como 'la representación mental de un objeto'?", new List<Respuesta>
                {
                    new Respuesta("Concepto", true),
                    new Respuesta("Juicio", false),
                    new Respuesta("Raciocinio", false)
                }),
                new Pregunta("Un raciocinio está compuesto por:", new List<Respuesta>
                {
                    new Respuesta("Premisas y conclusión", true),
                    new Respuesta("Sujeto y predicado", false),
                    new Respuesta("Hipótesis y teoría", false)
                }),
                new Pregunta("¿Cuál es el objetivo principal de la lógica formal?", new List<Respuesta>
                {
                    new Respuesta("Analizar la estructura válida de los argumentos", true),
                    new Respuesta("Estudiar las emociones humanas", false),
                    new Respuesta("Explorar la historia de la filosofía", false)
                }),
                new Pregunta("Un ejemplo de proposición categórica es:", new List<Respuesta>
                {
                    new Respuesta("Todos los humanos son mortales", true),
                    new Respuesta("Si llueve, entonces la calle se moja", false),
                    new Respuesta("¡Estudia para el examen!", false)
                }),
                new Pregunta("¿Qué tipo de razonamiento parte de premisas generales para llegar a una conclusión específica?", new List<Respuesta>
                {
                    new Respuesta("Deductivo", true),
                    new Respuesta("Inductivo", false),
                    new Respuesta("Analógico", false)
                }),
                new Pregunta("La conectiva lógica que representa 'si... entonces...' es:", new List<Respuesta>
                {
                    new Respuesta("Condicional (→)", true),
                    new Respuesta("Conjunción (∧)", false),
                    new Respuesta("Disyunción (∨)", false)
                }),
                new Pregunta("La proposición 'No es cierto que Juan estudie y no apruebe' se simboliza como:", new List<Respuesta>
                {
                    new Respuesta("¬(P ∧ ¬Q)", true),
                    new Respuesta("P → Q", false),
                    new Respuesta("P ∨ Q", false)
                }),
                new Pregunta("Una tabla de verdad con todas sus salidas verdaderas se llama:", new List<Respuesta>
                {
                    new Respuesta("Tautología", true),
                    new Respuesta("Contradicción", false),
                    new Respuesta("Indeterminación", false)
                }),
                new Pregunta("¿Cuál es la negación de 'Hoy es lunes o martes'?", new List<Respuesta>
                {
                    new Respuesta("Hoy no es lunes y no es martes", true),
                    new Respuesta("Hoy no es lunes o no es martes", false),
                    new Respuesta("Si hoy es lunes, entonces no es martes", false)
                }),
                new Pregunta("La proposición 'P ∧ Q' es verdadera solo cuando:", new List<Respuesta>
                {
                    new Respuesta("P y Q son verdaderas", true),
                    new Respuesta("Al menos una es verdadera", false),
                    new Respuesta("Ambas son falsas", false)
                }),
                new Pregunta("En un silogismo, el término que aparece en ambas premisas pero no en la conclusión se llama:", new List<Respuesta>
                {
                    new Respuesta("Término medio", true),
                    new Respuesta("Término mayor", false),
                    new Respuesta("Término menor", false)
                }),
                new Pregunta("Según las leyes del silogismo, ¿cuál es un modo válido de la primera figura?", new List<Respuesta>
                {
                    new Respuesta("AAA (Barbara)", true),
                    new Respuesta("EIO (Ferio)", false),
                    new Respuesta("AEO (Camestres)", false)
                }),
                new Pregunta("El método que verifica la validez de un argumento asignando valores de verdad a las proposiciones es:", new List<Respuesta>
                {
                    new Respuesta("Tablas de verdad", true),
                    new Respuesta("Inferencia inmediata", false),
                    new Respuesta("Analogía", false)
                }),
                new Pregunta("Si tenemos 'P → Q' y '¬Q', ¿qué conclusión se obtiene por modus tollens?", new List<Respuesta>
                {
                    new Respuesta("¬P", true),
                    new Respuesta("Q", false),
                    new Respuesta("P", false)
                }),
                new Pregunta("Un argumento inválido que parece correcto se denomina:", new List<Respuesta>
                {
                    new Respuesta("Falacia", true),
                    new Respuesta("Tautología", false),
                    new Respuesta("Paradoja", false)
                }),
                new Pregunta("¿Qué competencia general busca Filosofía II según el plan de estudios?", new List<Respuesta>
                {
                    new Respuesta("Demostrar la validez formal de razonamientos", true),
                    new Respuesta("Analizar textos literarios", false),
                    new Respuesta("Estudiar ética contemporánea", false)
                }),
                new Pregunta("La evaluación formativa en Filosofía II incluye:", new List<Respuesta>
                {
                    new Respuesta("Portafolio de evidencias y retroalimentación", true),
                    new Respuesta("Solo exámenes escritos", false),
                    new Respuesta("Trabajos artísticos", false)
                }),
                new Pregunta("¿Qué instrumento se usa para validar argumentos mediante conectivas lógicas?", new List<Respuesta>
                {
                    new Respuesta("Tablas de verdad", true),
                    new Respuesta("Encuestas", false),
                    new Respuesta("Diagramas de Venn", false)
                }),
                new Pregunta("Un ejemplo de falacia de ambigüedad es:", new List<Respuesta>
                {
                    new Respuesta("Equivocación (usar una palabra con dos significados)", true),
                    new Respuesta("Argumento ad hominem", false),
                    new Respuesta("Generalización apresurada", false)
                }),
                new Pregunta("Filosofía II, debe promover:", new List<Respuesta>
                {
                    new Respuesta("Pensamiento crítico y trabajo colaborativo", true),
                    new Respuesta("Memorización de fechas históricas", false),
                    new Respuesta("Creación de obras de arte", false)
                })
            });
            Materia orientacionJuvenil = new Materia("Orientación Juvenil y Profesional");
            orientacionJuvenil.BancoPregunta.AddRange(new List<Pregunta>
       {
           new Pregunta("¿Qué es la orientación juvenil?", new List<Respuesta>
           {
               new Respuesta("Un deporte", false),
               new Respuesta("Una guía para el desarrollo personal", true),
               new Respuesta("Una materia de matemáticas", false),
               new Respuesta("Una técnica de baile", false)
           }),

           new Pregunta("¿Qué área se trabaja en la orientación juvenil?", new List<Respuesta>
           {
               new Respuesta("Solo la física", false),
               new Respuesta("Solo la económica", false),
               new Respuesta("Desarrollo personal y social", true),
               new Respuesta("Solo la tecnológica", false)
           }),

           new Pregunta("¿Qué aspecto es importante en la adolescencia?", new List<Respuesta>
           {
               new Respuesta("Aprender a bailar", false),
               new Respuesta("Construir la identidad personal", true),
               new Respuesta("Correr maratones", false),
               new Respuesta("Ganar dinero", false)
           }),

           new Pregunta("¿Qué se entiende por autoestima?", new List<Respuesta>
           {
               new Respuesta("Juzgar a otros", false),
               new Respuesta("Valorarse a uno mismo", true),
               new Respuesta("Criticar a los demás", false),
               new Respuesta("Perder el tiempo", false)
           }),

           new Pregunta("¿Qué significa 'proyecto de vida'?", new List<Respuesta>
           {
               new Respuesta("Hacer muchos amigos", false),
               new Respuesta("Comer en restaurantes caros", false),
               new Respuesta("Planear metas y acciones para el futuro", true),
               new Respuesta("Viajar sin rumbo", false)
           }),

           new Pregunta("¿Qué es un valor?", new List<Respuesta>
           {
               new Respuesta("Algo que se compra", false),
               new Respuesta("Un principio que guía nuestras acciones", true),
               new Respuesta("Un objeto de moda", false),
               new Respuesta("Un trabajo aburrido", false)
           }),

           new Pregunta("¿Cuál es un valor importante en la adolescencia?", new List<Respuesta>
           {
               new Respuesta("La envidia", false),
               new Respuesta("La solidaridad", true),
               new Respuesta("La pereza", false),
               new Respuesta("El egoísmo", false)
           }),

           new Pregunta("¿Qué ayuda a mejorar la comunicación entre jóvenes?", new List<Respuesta>
           {
               new Respuesta("Gritar", false),
               new Respuesta("Escuchar con atención", true),
               new Respuesta("Interrumpir siempre", false),
               new Respuesta("Ignorar lo que dicen", false)
           }),

           new Pregunta("¿Qué son las habilidades sociales?", new List<Respuesta>
           {
               new Respuesta("Ser famoso en redes", false),
               new Respuesta("Saber relacionarse y convivir con otros", true),
               new Respuesta("Jugar videojuegos", false),
               new Respuesta("Hacer tareas solo", false)
           }),

           new Pregunta("¿Qué significa ser asertivo?", new List<Respuesta>
           {
               new Respuesta("Gritar para imponerse", false),
               new Respuesta("Callarse siempre", false),
               new Respuesta("Expresar opiniones respetuosamente", true),
               new Respuesta("Huir de los problemas", false)
           }),

           new Pregunta("¿Qué es la empatía?", new List<Respuesta>
           {
               new Respuesta("Burlarse de otros", false),
               new Respuesta("Ignorar los sentimientos", false),
               new Respuesta("Comprender las emociones ajenas", true),
               new Respuesta("Solo pensar en uno mismo", false)
           }),

           new Pregunta("¿Qué tipo de metas se deben plantear?", new List<Respuesta>
           {
               new Respuesta("Irrealizables", false),
               new Respuesta("Claras y alcanzables", true),
               new Respuesta("Muy confusas", false),
               new Respuesta("Siempre copiadas de otros", false)
           }),

           new Pregunta("¿Qué influencia es importante en la adolescencia?", new List<Respuesta>
           {
               new Respuesta("La moda", false),
               new Respuesta("Los videojuegos", false),
               new Respuesta("El grupo de amigos", true),
               new Respuesta("Las películas", false)
           }),

           new Pregunta("¿Qué actitud es importante para el trabajo en equipo?", new List<Respuesta>
           {
               new Respuesta("Mandar a todos", false),
               new Respuesta("No escuchar a nadie", false),
               new Respuesta("Colaborar y respetar opiniones", true),
               new Respuesta("Ignorar a los demás", false)
           }),

           new Pregunta("¿Qué puede afectar negativamente la autoestima?", new List<Respuesta>
           {
               new Respuesta("Reconocer logros", false),
               new Respuesta("Recibir apoyo", false),
               new Respuesta("Recibir críticas destructivas", true),
               new Respuesta("Establecer metas", false)
           }),

           new Pregunta("¿Qué es una adicción?", new List<Respuesta>
           {
               new Respuesta("Un hobby", false),
               new Respuesta("Una dependencia dañina a una sustancia o actividad", true),
               new Respuesta("Una moda", false),
               new Respuesta("Un deporte extremo", false)
           }),

           new Pregunta("¿Qué es la resiliencia?", new List<Respuesta>
           {
               new Respuesta("Rendirse fácilmente", false),
               new Respuesta("Recuperarse de situaciones difíciles", true),
               new Respuesta("Olvidar todo", false),
               new Respuesta("No esforzarse en nada", false)
           }),

           new Pregunta("¿Qué tipo de comunicación es más efectiva?", new List<Respuesta>
           {
               new Respuesta("Asertiva", true),
               new Respuesta("Pasiva", false),
               new Respuesta("Agresiva", false),
               new Respuesta("Manipuladora", false)
           }),

           new Pregunta("¿Qué actitud ayuda a alcanzar tus metas?", new List<Respuesta>
           {
               new Respuesta("Ser perezoso", false),
               new Respuesta("Tener perseverancia", true),
               new Respuesta("Dejarlo todo para después", false),
               new Respuesta("Echarle la culpa a otros", false)
           }),

           new Pregunta("¿Qué es la toma de decisiones?", new List<Respuesta>
           {
               new Respuesta("Evitar los problemas", false),
               new Respuesta("Delegar todo a los demás", false),
               new Respuesta("Elegir entre varias opciones de manera consciente", true),
               new Respuesta("Hacer todo sin pensar", false)
           })
       });
            Materia historiaMexico = new Materia("Historia de México Contemporáneo II");
            historiaMexico.BancoPregunta.AddRange(new List<Pregunta>
       {
           new Pregunta("¿Qué estudia la Historia como ciencia?", new List<Respuesta>
           {
               new Respuesta("El futuro", false),
               new Respuesta("El pasado humano", true),
               new Respuesta("La ciencia ficción", false),
               new Respuesta("La literatura", false)
           }),

           new Pregunta("¿Qué es una corriente de interpretación histórica?", new List<Respuesta>
           {
               new Respuesta("Un tipo de arte", false),
               new Respuesta("Una manera de analizar los hechos históricos", true),
               new Respuesta("Una red social", false),
               new Respuesta("Un tipo de deporte", false)
           }),

           new Pregunta("¿Qué culturas se consideran base de la identidad nacional?", new List<Respuesta>
           {
               new Respuesta("Griegos", false),
               new Respuesta("Romanos", false),
               new Respuesta("Mesoamericanas", true),
               new Respuesta("Chinos", false)
           }),

           new Pregunta("¿Qué área NO fue parte de Mesoamérica?", new List<Respuesta>
           {
               new Respuesta("Centro de México", false),
               new Respuesta("Península de Yucatán", false),
               new Respuesta("Desierto de Sonora", true),
               new Respuesta("Guatemala", false)
           }),

           new Pregunta("¿Qué característica principal tenían las culturas mesoamericanas?", new List<Respuesta>
           {
               new Respuesta("Eran nómadas", false),
               new Respuesta("Eran sedentarias y agrícolas", true),
               new Respuesta("Vivían en cuevas", false),
               new Respuesta("No tenían escritura", false)
           }),

           new Pregunta("¿Qué evento europeo del siglo XV impulsó la colonización de América?", new List<Respuesta>
           {
               new Respuesta("Revolución Francesa", false),
               new Respuesta("Independencia de Estados Unidos", false),
               new Respuesta("Grandes exploraciones marítimas", true),
               new Respuesta("Primera Guerra Mundial", false)
           }),

           new Pregunta("¿Quién dirigió el primer viaje que llegó a América en 1492?", new List<Respuesta>
           {
               new Respuesta("Hernán Cortés", false),
               new Respuesta("Cristóbal Colón", true),
               new Respuesta("Simón Bolívar", false),
               new Respuesta("Miguel Hidalgo", false)
           }),

           new Pregunta("¿Qué sistema político dominaba en Europa en los siglos XV y XVI?", new List<Respuesta>
           {
               new Respuesta("Democracia", false),
               new Respuesta("Monarquías absolutas", true),
               new Respuesta("Comunismo", false),
               new Respuesta("Anarquismo", false)
           }),

           new Pregunta("¿Qué factor facilitó la conquista de México?", new List<Respuesta>
           {
               new Respuesta("El uso de carros de guerra", false),
               new Respuesta("La alianza de los españoles con pueblos indígenas enemigos de los mexicas", true),
               new Respuesta("La protección de los dioses mexicas", false),
               new Respuesta("El clima cálido", false)
           }),

           new Pregunta("¿Quién lideró la conquista de Tenochtitlán?", new List<Respuesta>
           {
               new Respuesta("Simón Bolívar", false),
               new Respuesta("Hernán Cortés", true),
               new Respuesta("Cristóbal Colón", false),
               new Respuesta("Francisco Pizarro", false)
           }),

           new Pregunta("¿Qué institución española administraba las colonias en América?", new List<Respuesta>
           {
               new Respuesta("La Santa Inquisición", false),
               new Respuesta("La Real Audiencia", false),
               new Respuesta("La Casa de Contratación", true),
               new Respuesta("La ONU", false)
           }),

           new Pregunta("¿Qué estructura económica se implantó en América durante la Colonia?", new List<Respuesta>
           {
               new Respuesta("Capitalismo", false),
               new Respuesta("Feudalismo", false),
               new Respuesta("Mercantilismo", true),
               new Respuesta("Socialismo", false)
           }),

           new Pregunta("¿Qué fue una de las principales contribuciones coloniales a la identidad nacional?", new List<Respuesta>
           {
               new Respuesta("Los caballos", true),
               new Respuesta("La independencia", false),
               new Respuesta("La electricidad", false),
               new Respuesta("La televisión", false)
           }),

           new Pregunta("¿En qué año inició la lucha de Independencia de México?", new List<Respuesta>
           {
               new Respuesta("1810", true),
               new Respuesta("1910", false),
               new Respuesta("1821", false),
               new Respuesta("1521", false)
           }),

           new Pregunta("¿Qué sacerdote inició el movimiento de Independencia?", new List<Respuesta>
           {
               new Respuesta("José María Morelos", false),
               new Respuesta("Miguel Hidalgo y Costilla", true),
               new Respuesta("Vicente Guerrero", false),
               new Respuesta("Ignacio Allende", false)
           }),

           new Pregunta("¿Qué factor externo influyó en el inicio de la Independencia de México?", new List<Respuesta>
           {
               new Respuesta("La Revolución Industrial", false),
               new Respuesta("La Independencia de Estados Unidos", true),
               new Respuesta("La Guerra de Vietnam", false),
               new Respuesta("La Revolución Rusa", false)
           }),

           new Pregunta("¿Qué grupos defendían ideas distintas en el siglo XIX en México?", new List<Respuesta>
           {
               new Respuesta("Liberales y conservadores", true),
               new Respuesta("Socialistas y comunistas", false),
               new Respuesta("Anarquistas y fascistas", false),
               new Respuesta("Romanos y griegos", false)
           }),

           new Pregunta("¿Qué presidente mexicano impulsó las Leyes de Reforma?", new List<Respuesta>
           {
               new Respuesta("Porfirio Díaz", false),
               new Respuesta("Benito Juárez", true),
               new Respuesta("Miguel Hidalgo", false),
               new Respuesta("Vicente Guerrero", false)
           }),

           new Pregunta("¿Qué modelo económico surgió en México tras la Reforma Liberal?", new List<Respuesta>
           {
               new Respuesta("Feudalismo", false),
               new Respuesta("Capitalismo", true),
               new Respuesta("Comunismo", false),
               new Respuesta("Mercantilismo", false)
           }),

           new Pregunta("¿Qué periodo gobernó Porfirio Díaz?", new List<Respuesta>
           {
               new Respuesta("1810–1821", false),
               new Respuesta("1876–1911", true),
               new Respuesta("1940–1950", false),
               new Respuesta("1990–2000", false)
           })
       });

            Materias.Add(algebra);
            Materias.Add(geometria);
            Materias.Add(desarrolloPersonal);
            Materias.Add(desarrolloHabilidadesPensamiento);
            Materias.Add(biologiaBasica);
            Materias.Add(computacionbasica);
            Materias.Add(filosofiaII);
            Materias.Add(orientacionJuvenil);
            Materias.Add(historiaMexico);

            //Materias.Add();

        }



    }
}
