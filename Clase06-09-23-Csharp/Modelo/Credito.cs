using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Credito: Venta
    {
        public static int x;
        public Credito()
        {
            x++;
        }

        public int GetX()
        {
            return x;
        }

        //atributos de la clase credito

        public int Letras { get; set; }
        public double CalculaMontoInteres()
        {
            switch (Letras)
            {
                case 3: return 5.0 / 100 * CalculaSubtotal();
                case 6: return 10.0 / 100 * CalculaSubtotal();
                case 9: return 15.0 / 100 * CalculaSubtotal();
                case 12: return 20.0 / 100 * CalculaSubtotal();
            }
            return 0;
        }

        public double CalculoMontoMensual()
        {
            return (CalculaSubtotal() + CalculaMontoInteres()) / Letras;
        }

    }
}
