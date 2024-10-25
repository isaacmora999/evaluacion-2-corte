using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO2SGUNDOCORTE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Multiplicacion multiplicacion = new Multiplicacion();

            // Solicitar al usuario el número entre 1 y 10
            Console.WriteLine("Ingrese un número entero entre 1 y 10:");
            int numero = int.Parse(Console.ReadLine());

            if (numero >= 1 && numero <= 10)
            {
                // Guardar la tabla de multiplicar en el archivo binario
                multiplicacion.GuardarTablaEnFichero(numero);

                // Mostrar la tabla de multiplicar desde el archivo binario
                multiplicacion.MostrarTablaDeFichero(numero);
            }
            else
            {
                Console.WriteLine("Número inválido. Debe ser un entero entre 1 y 10.");
            }

            Console.ReadKey();
        }
    }
}
