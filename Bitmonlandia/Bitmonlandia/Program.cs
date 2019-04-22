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
            //-----------------------------------------------MENU----------------------------------------------------------------------
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

            int size = 0;
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
            //------------------------ Instancia de Bitmons---------------------------------------------
            int[] tupla = { 1, 2 };
            int[] tupla2 = { 0, 4 };
            int[] tupla3 = { 2, 1 };
            int[] tupla4 = { 4, 1 };
            int[] tupla5 = { 2, 4 };
            int[] tupla6 = { 4, 4 };
            int[] tupla7 = { 4, 3 };
            int[] tupla8 = { 2, 3 };
            /*bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5,10,tupla));
            bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5, 10, tupla));*/
            bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10 , 50, 80, tupla));
            bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10, 70, 80, tupla2));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 20, 80, tupla2));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 65, 80, tupla3));
            bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 80, tupla4));
            //bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 40, 100, tupla5));
            bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 80, 80, tupla6));
            bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 50, 80, tupla7));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 20, 80, tupla8));
            //bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 30, 100, tupla4));
            
            Console.WriteLine("--------------------# MAPA INICIAL #---------------------\n");
            bitmonlandia.GetMapa().ImprimirTablero();

            //--------------------------Simulacion por meses------------------------------------
            Console.Write("¿Cuantos meses desea simular?: ");
            int cantidad_meses = int.Parse(Console.ReadLine());
            Console.Write("\n");

            for (int mes = 0; mes < cantidad_meses; mes++)
            {
                Console.WriteLine("Mes: {0}", mes);

                //Se recorre la lista de bitmons para ver si hay bitmons en la misma casilla
                for (int bit = 0; bit < bitmonlandia.GetLista().Count; bit++)
                {
                    //Selecciono el primer bitmon y veo su especie tambien:
                    string especie = bitmonlandia.GetLista()[bit].GetNombre();

                    //Y recorro la lista en busca de una coincidencia
                    for (int pareja = 0; pareja < bitmonlandia.GetLista().Count; pareja++)
                    {
                        //No queremos que se junte con él mismo asi que lo omitimos
                        if (pareja == bit)
                        {
                            continue;
                        }

                        if (bitmonlandia.GetLista()[bit].GetPosicion()[0] == bitmonlandia.GetLista()[pareja].GetPosicion()[0] && bitmonlandia.GetLista()[bit].GetPosicion()[1] == bitmonlandia.GetLista()[pareja].GetPosicion()[1
                            ])
                        {
                            //Primero intentamos con pelea
                            bitmonlandia.GetLista()[bit].Pelea(bitmonlandia.GetLista()[pareja]);

                            //Si no funciona, significa que se llevan bien para reproducirse
                            
                            bitmonlandia.GetLista()[bit].Reproduccion(bitmonlandia.GetLista()[pareja], size, bitmonlandia);
                        }

                        if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[bit].GetPosicion()[0], bitmonlandia.GetLista()[bit].GetPosicion()[1], bitmonlandia.GetLista()[bit].GetCelda());

                        if (bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == false)
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[pareja].GetPosicion()[0], bitmonlandia.GetLista()[pareja].GetPosicion()[1], bitmonlandia.GetLista()[pareja].GetCelda());
                    }

                    /*Comprobamos si sigue vivo este bitmon, para asi saber si moverlo y cambiar el terreno
                        * si corresponde*/
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                        {
                            continue;
                        }

                    //Ahora que sabemos que esta vivo lo movemos y cambiamos el terreno si corresponde
                    //Transformar terreno:
                    if (especie == "Gofue")
                        {
                        bitmonlandia.GetLista()[bit].Secar(bitmonlandia.GetMapa());
                        }

                    else if (especie == "Taplan")
                        {
                        bitmonlandia.GetLista()[bit].Plantar(bitmonlandia.GetMapa());
                        }
                        

                    //Moverse:
                    if (especie != "Ent")
                    {
                        bitmonlandia.GetLista()[bit].Movimiento(bitmonlandia.GetMapa());
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