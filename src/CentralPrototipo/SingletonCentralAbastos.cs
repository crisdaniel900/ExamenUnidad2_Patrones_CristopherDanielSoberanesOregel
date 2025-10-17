using CentralDeAbastosConPallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PATRÓN SINGLETON: CENTRAL DE ABASTOS (que luego se me olvida que show)

namespace CentralDeAbastosConPallets
{
    public class CentralDeAbastos
    {
            private static CentralDeAbastos _instance;
            private static readonly object _lock = new object();
            //Aqui se hace privada PROFE
            private PoolPallets poolPallets; // Object Pool interno

        // Constructor privado
        private CentralDeAbastos()
        {
            Console.WriteLine(" Central de abastos, que va a querer WERITO...\n");
           //Y aqui se usa la privada( si te gananan los nervios revisa la linea 16 pa saber porque se hace privada)
            poolPallets = new PoolPallets(3); // Pool con 3 pallets
        }

        // Propiedad Singleton
        public static CentralDeAbastos Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new CentralDeAbastos();
                    }
                }
                return _instance;
            }
        }

        // Método para procesar pedidos y asignar un pallet
        public Pallet ProcesarPedido(string fruta)
        {
            Console.WriteLine($" Pedido recibido: {fruta}");
            Pallet pallet = poolPallets.AsignarPallet();

            if (pallet != null)
            {
                pallet.Cargar(fruta);
                Console.WriteLine($"  {fruta} está siendo transportada en {pallet.Nombre}.\n");
            }
            else
            {
                Console.WriteLine($" No hay pallets disponibles para transportar {fruta}. Espere un momento...\n");
            }

            return pallet;
        }

        // Método para liberar un pallet (regresarlo al pool)
        public void LiberarPallet(Pallet pallet)
        {
            poolPallets.LiberarPallet(pallet);
        }

        // Método para verificar el Object Pool
        public void MostrarEstadoPool()
        {
            poolPallets.MostrarEstado();
        }
    }
}
