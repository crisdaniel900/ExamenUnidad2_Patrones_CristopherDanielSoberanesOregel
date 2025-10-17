using System;
using System.Collections.Generic;

namespace CentralDeAbastosConPallets
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Central de Abastos - Singleton + Object Pool";

            //Aqui es donde se general el objeto y se hace el pedido 
            CentralDeAbastos central1 = CentralDeAbastos.Instance;
            CentralDeAbastos central2 = CentralDeAbastos.Instance;
            CentralDeAbastos central3 = CentralDeAbastos.Instance;

            //Aqui se comprueba el pedido que cuaje como singleton
            Console.WriteLine(" COMPROBACIÓN DEL PATRÓN SINGLETON:");
            bool aqui_va_el_singlleton_profe = ReferenceEquals(central1, central2) &&
                                               ReferenceEquals(central2, central3);


            Console.WriteLine($"¿Lleva singleton profe? {aqui_va_el_singlleton_profe}\n");

            // Un menu asi bien chikistrikis, pa que se vea en atxion todo esta vaina
            Console.WriteLine("PEDIDOS ENTRANTES A LA CENTRAL DE ABASTOS\n" +
                              "1. Manzanas\n" +
                              "2. Bananas\n" +
                              "3. Naranjas\n" +
                              "4. Uvas\n" +
                              "5. Liberar un pallet\n" +
                              "6. Mostrar estado del pool\n" +
                              "X. Salir\n");

            List<Pallet> palletsEnUso = new List<Pallet>();
            string opcion;

            do
            {
                Console.Write("\nSeleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion.ToLower())
                {
                    case "1":
                        palletsEnUso.Add(central1.ProcesarPedido("Manzanas"));
                        break;
                    case "2":
                        palletsEnUso.Add(central1.ProcesarPedido("Bananas"));
                        break;
                    case "3":
                        palletsEnUso.Add(central1.ProcesarPedido("Naranjas"));
                        break;
                    case "4":
                        palletsEnUso.Add(central1.ProcesarPedido("Uvas"));
                        break;
                    case "5":
                        if (palletsEnUso.Count > 0)
                        {
                            Pallet p = palletsEnUso[0];
                            palletsEnUso.RemoveAt(0);
                            central1.LiberarPallet(p);
                        }
                        else
                        {
                            Console.WriteLine("❗ No hay pallets en uso para liberar.");
                        }
                        break;
                    case "6":
                        central1.MostrarEstadoPool();
                        break;
                    case "x":
                        Console.WriteLine("\n Cerrando pedidos...");
                        break;
                    default:
                        Console.WriteLine(" Opción no válida.");
                        break;
                }

            } while (opcion.ToLower() != "x");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
