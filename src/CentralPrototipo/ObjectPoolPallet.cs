using CentralDeAbastosConPallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeAbastosConPallets
{
    public class PoolPallets
    {

        //PRIVADO PROFE, pegueme pero no me deje 
        //controla directamente los objetos(Pallets) que se pueden prestar y devolver
        private readonly Stack<Pallet> palletsDisponibles = new Stack<Pallet>();
        private readonly int maximoPallets = 3;

        public PoolPallets(int maximo)
        {
            maximoPallets = maximo;
            for (int i = 1; i <= maximo; i++)
                palletsDisponibles.Push(new Pallet($"Pallet-{i}"));

            Console.WriteLine($" Pool inicializado con {maximo} pallets disponibles.\n");
        }

        public Pallet AsignarPallet()
        {
            if (palletsDisponibles.Count > 0)
            {
                Pallet p = palletsDisponibles.Pop();
                Console.WriteLine($" {p.Nombre} ha sido asignado.");
                Console.WriteLine($" Pallets disponibles: {palletsDisponibles.Count}\n");
                return p;
            }
            else
            {
                Console.WriteLine("  No hay pallets disponibles actualmente.\n");
                return null;
            }
        }

        public void LiberarPallet(Pallet p)
        {
            if (palletsDisponibles.Count < maximoPallets)
            {
                p.Vaciar();
                palletsDisponibles.Push(p);
                Console.WriteLine($" {p.Nombre} regresó al pool.");
                Console.WriteLine($" Pallets disponibles: {palletsDisponibles.Count}\n");
            }
            else
            {
                Console.WriteLine("  El pool ya está completo, no se puede devolver más pallets.\n");
            }
        }

        public void MostrarEstado()
        {
            Console.WriteLine($" Pallets disponibles actualmente: {palletsDisponibles.Count}\n");
        }
    }
}
