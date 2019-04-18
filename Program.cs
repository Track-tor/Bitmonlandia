using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmonlandia bitmonlandia = new Bitmonlandia();
            int[] tupla = { 1, 2 };

            bitmonlandia.lista_bitmons_totales.Add(new Ent("Ent",1, 2, 3,tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Ent("Ent",1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Taplan("Taplan",1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Taplan("Taplan", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Doti("Doti", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Doti("Doti", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Dorvalo("Dorvalo", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Dorvalo("Dorvalo", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Wetar("Wetar", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Wetar("Wetar", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Gofue("Gofue", 1, 2, 3, tupla));
            bitmonlandia.lista_bitmons_totales.Add(new Gofue("Gofue", 1, 2, 3, tupla));

        }
    }
}
