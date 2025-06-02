using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoJIAv2
{
    public class Respuesta
    {
        public string Texto { get; set; }
        public bool EsCorrecta { get; set; }

        public Respuesta(string texto, bool esCorrecta)
        {
            Texto = texto;
            EsCorrecta = esCorrecta;
        }

        public bool EsRespuestaCorrecta()
        {
            return EsCorrecta;
        }
    }

}
