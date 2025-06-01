using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoJIAv2
{
    /// <summary>
    /// Clase que proporciona funcionalidades para aleatorizar elementos en el juego
    /// </summary>
    public static class Aleatorizador
    {
        private static Random random = new Random();

        /// <summary>
        /// Método para mezclar una lista de elementos
        /// </summary>
        /// <typeparam name="T">Tipo de elementos en la lista</typeparam>
        /// <param name="lista">Lista a mezclar</param>
        public static void MezclarLista<T>(List<T> lista)
        {
            int n = lista.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T valor = lista[k];
                lista[k] = lista[n];
                lista[n] = valor;
            }
        }

        /// <summary>
        /// Método para seleccionar elementos aleatorios de una lista
        /// </summary>
        /// <typeparam name="T">Tipo de elementos en la lista</typeparam>
        /// <param name="lista">Lista de origen</param>
        /// <param name="cantidad">Cantidad de elementos a seleccionar</param>
        /// <returns>Lista con los elementos seleccionados aleatoriamente</returns>
        public static List<T> SeleccionarElementosAleatorios<T>(List<T> lista, int cantidad)
        {
            // Verificar que haya suficientes elementos en la lista
            if (lista.Count <= cantidad)
            {
                return new List<T>(lista);
            }

            // Crear una copia de la lista original para no modificarla
            List<T> copiaLista = new List<T>(lista);
            List<T> elementosSeleccionados = new List<T>();

            // Seleccionar elementos aleatorios
            for (int i = 0; i < cantidad; i++)
            {
                int indice = random.Next(copiaLista.Count);
                elementosSeleccionados.Add(copiaLista[indice]);
                copiaLista.RemoveAt(indice);
            }

            return elementosSeleccionados;
        }

        /// <summary>
        /// Método para obtener un número aleatorio entre un rango
        /// </summary>
        /// <param name="minimo">Valor mínimo (inclusive)</param>
        /// <param name="maximo">Valor máximo (exclusive)</param>
        /// <returns>Número aleatorio</returns>
        public static int ObtenerNumeroAleatorio(int minimo, int maximo)
        {
            return random.Next(minimo, maximo);
        }

        /// <summary>
        /// Método para obtener un elemento aleatorio de una lista
        /// </summary>
        /// <typeparam name="T">Tipo de elementos en la lista</typeparam>
        /// <param name="lista">Lista de origen</param>
        /// <returns>Elemento aleatorio</returns>
        public static T ObtenerElementoAleatorio<T>(List<T> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                throw new ArgumentException("La lista no puede estar vacía");
            }

            int indice = random.Next(lista.Count);
            return lista[indice];
        }
    }
}
