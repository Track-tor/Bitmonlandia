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
            Bitmonlandia bitmonlandia = new Bitmonlandia(3);

            int[] tupla = { 1, 2 };
            bitmonlandia.añadir_bitmon(new Ent(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Ent(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Taplan(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Taplan(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Doti(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Doti(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Dorvalo(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Dorvalo(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Wetar(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Wetar(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Gofue(1, 2, 3, tupla));
            bitmonlandia.añadir_bitmon(new Gofue(1, 2, 3, tupla));
            bitmonlandia.GetMapa();
        }
    }
}