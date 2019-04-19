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


            //////////////////////////////////////////////////////////////
            //Simulacion por meses:
            string opcion = "0";
            int mes = 0;

            while (opcion == "0")
            {
                List<Bitmon> lista = bitmonlandia.GetLista();

                //Se recorre la lista de bitmons para ver si hay bitmons en la misma casilla
                for (int bit=0; bit< lista.Count; bit++)
                {
                    //Selecciono el primer bitmon
                    Bitmon bitmonA = lista[bit];
                    //Y recorro la lista en busca de una coincidencia
                    for (int pareja = 0; pareja<lista.Count; pareja++)
                    {
                        //No queremos que se junte con él mismo asi que lo omitimos
                        if (pareja == bit)
                        {
                            continue;
                        }

                        if (lista[bit].GetPosicion() == lista[pareja].GetPosicion())
                        {
                            //Primero intentamos con pelea
                            lista[bit].Pelea(lista[pareja]);

                            //Si no funciona, significa que se llevan bien para reproducirse
                            lista[bit].Reproduccion(lista[pareja]);
                        }
                    }
                }









                //Seguir con la simulacion???
                Console.WriteLine("[0] Continuar");
                Console.WriteLine("[1] Finalizar la simulacion");
                opcion = Console.ReadLine();
                if (opcion == "0")
                {
                    mes++;
                }
                
            }
        }
    }
}