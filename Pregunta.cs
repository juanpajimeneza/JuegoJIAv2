using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoJIAv2
{
    public class Pregunta
    {
        public string Texto { get; set; }
        public List<Respuesta> Opciones { get; set; }
        public int Dificultad { get; set; }

        public Pregunta(string texto, List<Respuesta> opciones, int dificultad = 1)
        {
            Texto = texto;
            Opciones = opciones ?? new List<Respuesta>();
            Dificultad = dificultad;
        }

        public bool VerificarRespuesta(int indiceRespuesta)
        {
            if (indiceRespuesta >= 0 && indiceRespuesta < Opciones.Count)
            {
                return Opciones[indiceRespuesta].EsRespuestaCorrecta();
            }
            return false;
        }

        public void MostrarOpciones()
        {
            for (int i = 0; i < Opciones.Count; i++)
            {
                Console.WriteLine($"{(char)('a' + i)}) {Opciones[i].Texto}");
            }
        }
    }
}
