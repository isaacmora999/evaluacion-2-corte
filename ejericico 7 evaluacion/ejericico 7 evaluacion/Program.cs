using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejericico_7_evaluacion
{
    public class Venta
    {
        public int IDProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Total => Cantidad * Precio;
    }

    public class ProgramaVentas
    {
        private const string archivoVentas = "ventas.dat";

        // Método para agregar una venta
        public static void AgregarVenta(Venta venta)
        {
            List<Venta> ventas = LeerVentas();
            ventas.Add(venta);
            GuardarVentas(ventas);
            Console.WriteLine("Venta registrada correctamente.");
        }

        // Método para leer ventas desde el archivo binario
        private static List<Venta> LeerVentas()
        {
            if (!File.Exists(archivoVentas))
                return new List<Venta>();

            using (FileStream fs = new FileStream(archivoVentas, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                List<Venta> ventas = new List<Venta>();
                while (fs.Position < fs.Length)
                {
                    int idProducto = reader.ReadInt32();
                    int cantidad = reader.ReadInt32();
                    decimal precio = reader.ReadDecimal();
                    ventas.Add(new Venta { IDProducto = idProducto, Cantidad = cantidad, Precio = precio });
                }
                return ventas;
            }
        }

        // Método para guardar ventas en el archivo binario
        private static void GuardarVentas(List<Venta> ventas)
        {
            using (FileStream fs = new FileStream(archivoVentas, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (var venta in ventas)
                {
                    writer.Write(venta.IDProducto);
                    writer.Write(venta.Cantidad);
                    writer.Write(venta.Precio);
                }
            }
        }

        // Método para consultar y mostrar las ventas
        public static void ConsultarVentas()
        {
            List<Venta> ventas = LeerVentas();
            if (ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
                return;
            }

            Console.WriteLine("Ventas registradas:");
            foreach (var venta in ventas)
            {
                Console.WriteLine($"ID Producto: {venta.IDProducto}, Cantidad: {venta.Cantidad}, Precio: {venta.Precio:C}, Total: {venta.Total:C}");
            }
        }

        // Método para mostrar el total de ventas, la venta más alta y la más baja
        public static void MostrarEstadisticas()
        {
            List<Venta> ventas = LeerVentas();
            if (ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
                return;
            }

            decimal totalVentas = 0;
            decimal ventaMasAlta = decimal.MinValue;
            decimal ventaMasBaja = decimal.MaxValue;

            foreach (var venta in ventas)
            {
                totalVentas += venta.Total;
                if (venta.Total > ventaMasAlta)
                    ventaMasAlta = venta.Total;
                if (venta.Total < ventaMasBaja)
                    ventaMasBaja = venta.Total;
            }

            Console.WriteLine($"Total de ventas: {totalVentas:C}");
            Console.WriteLine($"Venta más alta: {ventaMasAlta:C}");
            Console.WriteLine($"Venta más baja: {ventaMasBaja:C}");
        }

        // Menú principal
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Sistema de Ventas ---");
                Console.WriteLine("1. Agregar Venta");
                Console.WriteLine("2. Consultar Ventas");
                Console.WriteLine("3. Mostrar Estadísticas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("ID del Producto: ");
                        int idProducto = int.Parse(Console.ReadLine());
                        Console.Write("Cantidad: ");
                        int cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine());

                        Venta venta = new Venta { IDProducto = idProducto, Cantidad = cantidad, Precio = precio };
                        AgregarVenta(venta);
                        break;

                    case "2":
                        ConsultarVentas();
                        break;

                    case "3":
                        MostrarEstadisticas();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
    