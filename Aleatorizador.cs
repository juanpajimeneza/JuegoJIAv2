using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoJIAv2
{
    public class Aleatorizador
    {
        private Random random;

        public Aleatorizador()
        {
            random = new Random();
        }

        public List<T> Aleatorizar<T>(List<T> lista)
        {
            List<T> listaAleatoria = new List<T>(lista);
            for (int i = listaAleatoria.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = listaAleatoria[i];
                listaAleatoria[i] = listaAleatoria[j];
                listaAleatoria[j] = temp;
            }
            return listaAleatoria;
        }

        public int AleatorioEntre(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
