using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busqueda_binaria_sem10
{
    internal class Busqueda
    {
        private int[] vector;

        public void Cargar()
        {
            Console.WriteLine("Búsqueda binaria:");
            Console.WriteLine("Ingrese 10 elementos:");
            vector = new int[10];
            for (int f = 0; f < vector.Length; f++)
            {
                Console.Write($"Ingrese elemento {f + 1}: ");
                vector[f] = int.Parse(Console.ReadLine());
            }
        }

        public void OrdenarBurbuja()
        {
            int n = vector.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        int temp = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = temp;
                    }
                }
            }
        }

        public void Buscar(int num)
        {
            int l = 0;
            int h = vector.Length - 1;
            int m;
            bool found = false;

            while (l <= h)
            {
                m = (l + h) / 2;
                if (vector[m] == num)
                {
                    found = true;
                    Console.WriteLine($"\nEl elemento {num} está en la posición {m + 1}.");
                    return;
                }
                if (vector[m] < num)
                    l = m + 1;
                else
                    h = m - 1;
            }

            if (!found)
            {
                Console.WriteLine($"\nEl elemento {num} no está en el arreglo.");
            }
        }

        public int ContarOcurrencias(int num)
        {
            int ocurrencias = 0;
            foreach (int elemento in vector)
            {
                if (elemento == num)
                {
                    ocurrencias++;
                }
            }
            return ocurrencias;
        }

        public void Imprimir()
        {
            Console.WriteLine("Elementos del arreglo ordenado:");
            for (int f = 0; f < vector.Length; f++)
            {
                Console.Write(vector[f] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Busqueda pv = new Busqueda();
            pv.Cargar();
            pv.OrdenarBurbuja();
            pv.Imprimir();

            Console.WriteLine("\nIngrese el elemento a buscar:");
            int num = int.Parse(Console.ReadLine());
            pv.Buscar(num);

            int ocurrencias = pv.ContarOcurrencias(num);
            Console.WriteLine($"\nEl número {num} aparece {ocurrencias} veces en el arreglo.");

            Console.ReadKey();
        }
    }
}