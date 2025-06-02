using JuegoJIAv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoJIAv2
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public int Puntaje { get; set; }
        public List<Materia> MateriaSeleccionada { get; set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Puntaje = 0;
            MateriaSeleccionada = new List<Materia>();
        }

        public void SeleccionMateria(Materia materia)
        {
            if (!MateriaSeleccionada.Contains(materia))
            {
                MateriaSeleccionada.Add(materia);
            }
        }
    }
}
