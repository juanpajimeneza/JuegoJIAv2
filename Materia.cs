using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoJIAv2
{
    public class Materia
    {
        public string Nombre { get; set; }
        public List<Pregunta> BancoPregunta { get; set; }
        public bool Estado { get; set; }

        public Materia(string nombre)
        {
            Nombre = nombre;
            BancoPregunta = new List<Pregunta>();
            Estado = true;
        }

        public List<Pregunta> GetPreguntas()
        {
            return BancoPregunta;
        }

        public void CambiarEstado()
        {
            Estado = !Estado;
        }
    }

}
