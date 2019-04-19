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
            bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5,10,tupla));
            bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));
            Mapa mapa = bitmonlandia.GetMapa();

            //////////////////////////////////////////////////////////////
            //Simulacion por meses:
            Console.WriteLine("Cuantos meses deasea simular");
            int cantidad_meses = int.Parse(Console.ReadLine());

            for (int mes=0; mes<cantidad_meses; mes++)
            {
                List<Bitmon> lista = bitmonlandia.GetLista();

                //Se recorre la lista de bitmons para ver si hay bitmons en la misma casilla
                for (int bit=0; bit< lista.Count; bit++)
                {
                    //Selecciono el primer bitmon y veo su especie tambien:
                    Bitmon bitmonA = lista[bit];
                    string especie = bitmonA.GetNombre();

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

                        /*Comprobamos si sigue vivo este bitmon, para asi saber si moverlo y cambiar el terreno
                         * si corresponde*/
                        if (bitmonA.GetEstadoDeVida() == false)
                            {
                                continue;
                            }

                        //Ahora que sabemos que esta vivo lo movemos y cambiamos el terreno si corresponde
                        //Transformar terreno:
                        if (especie == "Gofue")
                            {
                                bitmonA.Secar(mapa);
                            }

                        else if (especie == "Taplan")
                            {
                                bitmonA.Plantar(mapa);
                            }
                        }

                        //Moverse:
                        //
                    }
                }













                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadLine();
            }
        }
    }
}