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
            
            Console.WriteLine("# BITMONLANDIA # \n");
            Console.WriteLine("Escoge una de las siguentes opciones para generar BITMONLANDIA:\n");
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("{1} MAPA: 5X5 // BITMONS: Dorvalo-Taplan-Wetar // TERRENOS: Desierto-Agua-Lava-Vegetacion  ");
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("{2} MAPA: 10X10 // BITMONS: ~ // TERRENOS: ~ ");
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("{3} MAPA: 15X15 // BITMONS: ~ // TERRENOS: ~ \n");
            Console.ForegroundColor = ConsoleColor.White; Console.Write("Opcion: ");
            string opcion = (Console.ReadLine());
            while (opcion != "1" && opcion != "2" && opcion != "3")
            {
                Console.WriteLine("Opcion inválida, intente de nuevo");
                opcion = (Console.ReadLine());
            }
            Console.Write("\n");
            Bitmonlandia bitmonlandia = new Bitmonlandia(Convert.ToInt32(opcion));

            int size;
            switch (Convert.ToInt32(opcion))
            {
                case (1):
                    size = 5;
                    break;

                case (2):
                    size = 10;
                    break;

                case (3):
                    size = 15;
                    break;

            }

            int[] tupla = { 1, 2 };
            int[] tupla2 = { 4, 3 };
            int[] tupla3 = { 4, 4 };
            /*bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5,10,tupla));
            bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5, 10, tupla));*/
            bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10 , 5, 10, tupla));
            //bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10, 5, 10, tupla2));
            /*bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            */bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 5, 10, tupla2));
            /*bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 5, 10, tupla));*/
            bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 5, 10, tupla3));
            /*bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));*/

            //-----------------------------------------------MENU----------------------------------------------------------------------
            
            
            //Mapa mapa  bitmonlandia.GetMapa(); *Instancie el mapa de manera que se pueda colocar la opcion*
            Console.WriteLine("--------------------# MAPA INICIAL #---------------------\n");
            bitmonlandia.GetMapa().ImprimirTablero();

            //////////////////////////////////////////////////////////////
            //Simulacion por meses:
            Console.Write("¿Cuantos meses desea simular?: ");
            int cantidad_meses = int.Parse(Console.ReadLine());
            Console.Write("\n");

            for (int mes=0; mes<cantidad_meses; mes++)
            {
                Console.WriteLine("Mes: {0}", mes);
                List<Bitmon> lista = bitmonlandia.GetLista();

                //Se recorre la lista de bitmons para ver si hay bitmons en la misma casilla
                for (int bit=0; bit< lista.Count; bit++)
                {
                    //Selecciono el primer bitmon y veo su especie tambien:
                    Bitmon bitmonA = lista[bit];
                    string especie = bitmonA.GetNombre();


                    //Y recorro la lista en busca de una coincidencia
                    for (int pareja = 0; pareja < lista.Count; pareja++)
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
                            bitmonA.Secar(bitmonlandia.GetMapa());
                        }

                    else if (especie == "Taplan")
                        {
                            bitmonA.Plantar(bitmonlandia.GetMapa());
                        }
                        

                    //Moverse:
                    if (especie != "Ent")
                    {
                        bitmonA.Movimiento(bitmonlandia.GetMapa());
                    }
                    
                }

                bitmonlandia.GetInformacion();
                Console.WriteLine("");
                Console.WriteLine("");
                bitmonlandia.GetMapa().ImprimirTablero();
                Console.WriteLine("Presione una ENTER para continuar");
                Console.ReadLine();
            }
        }
    }
}