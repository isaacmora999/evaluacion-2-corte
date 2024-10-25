using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO2SGUNDOCORTE
{
    internal class Multiplicacion
    {
        // Función para generar la tabla de multiplicar y guardarla en un archivo binario
        public void GuardarTablaEnFichero(int numero)
        {
            string archivo = $"tabla-{numero}.dat";
            FileStream fileStream = new FileStream(archivo, FileMode.Create);
            BinaryWriter escritor = new BinaryWriter(fileStream, Encoding.UTF8);

            // Guardar la tabla de multiplicar en el archivo
            for (int i = 1; i <= 10; i++)
            {
                int resultado = numero * i;
                escritor.Write($"{numero} x {i} = {resultado}");
            }

            escritor.Close();
            fileStream.Close();
        }

        // Función para leer y mostrar la tabla de multiplicar desde el archivo binario
        public void MostrarTablaDeFichero(int numero)
        {
            string archivo = $"tabla-{numero}.dat";

            if (File.Exists(archivo))
            {
                FileStream fileStream = new FileStream(archivo, FileMode.Open);
                BinaryReader lector = new BinaryReader(fileStream, Encoding.UTF8);

                Console.WriteLine($"Tabla de multiplicar del {numero}:");

                while (fileStream.Position < fileStream.Length)
                {
                    Console.WriteLine(lector.ReadString());
                }

                lector.Close();
                fileStream.Close();
            }
            else
            {
                Console.WriteLine($"El archivo {archivo} no existe.");
            }
        }
    }
}
