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
            int[] tupla2 = { 4, 3 };
            int[] tupla3 = { 4, 4 };
            /*bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5,10,tupla));
            bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5, 10, tupla));*/
            bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10 , 50, 100, tupla));
            //bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10, 5, 10, tupla2));
            /*bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            */bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla2));
            /*bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 5, 10, tupla));*/
            bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla3));
            /*bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));*/
            bitmonlandia.Posicionar_bitmons();

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
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

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
                            if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == true && bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == true)
                            {
                                bitmonlandia.GetLista()[bit].Reproduccion(bitmonlandia.GetLista()[pareja], size, bitmonlandia);
                            }
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

                    //Si sigue vivo despues de todo, hacerlo envejecer
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida()==true)
                    {
                        bitmonlandia.GetLista()[bit].Envejecer();
                    }

                }

                //Si han pasado 3 meses y algun Ent sigue vivo, spawnear uno
                if (mes % 3 == 0)
                {
                    bitmonlandia.PlantarEnt(size);
                }

                bitmonlandia.GetInformacion();
                Console.WriteLine("");
                Console.WriteLine("");
                bitmonlandia.GetMapa().ImprimirTablero();
                Console.WriteLine("Presione una ENTER para continuar");
                bitmonlandia.SetTiempoTranscurrido();
                Console.ReadLine();
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            /////////////////////////
            //Estadisticas finales

            //Tiempo de vida promedio Bitmon:
            bitmonlandia.TiempoDeVidaPromedioBitmon();
            Console.WriteLine("");

            ////////////////////////////////////////////
            //Tiempo de vida promedio de cada especie:
            //Taplan
            bitmonlandia.TiempoDeVidaPromedioEspecie("Taplan");

            //Dorvalo
            bitmonlandia.TiempoDeVidaPromedioEspecie("Dorvalo");

            //Gofue
            bitmonlandia.TiempoDeVidaPromedioEspecie("Gofue");

            //Doti
            bitmonlandia.TiempoDeVidaPromedioEspecie("Doti");

            //Wetar
            bitmonlandia.TiempoDeVidaPromedioEspecie("Wetar");

            //Ent
            bitmonlandia.TiempoDeVidaPromedioEspecie("Ent");
            Console.WriteLine("");

            /////////////////////////////////////////////////
            //Tasa de natalidad de cada especie:
            //Taplan
            bitmonlandia.TasaDeNatalidad("Taplan");

            //Dorvalo
            bitmonlandia.TasaDeNatalidad("Dorvalo");

            //Gofue
            bitmonlandia.TasaDeNatalidad("Gofue");

            //Doti
            bitmonlandia.TasaDeNatalidad("Doti");

            //Wetar
            bitmonlandia.TasaDeNatalidad("Wetar");

            //Ent
            bitmonlandia.TasaDeNatalidad("Ent");

            Console.WriteLine("");

            ////////////////////////////////////////////////
            //Tasa de mortalidad de cada especie:
            //Taplan
            bitmonlandia.TasaDeMortalidad("Taplan");

            //Dorvalo
            bitmonlandia.TasaDeMortalidad("Dorvalo");

            //Gofue
            bitmonlandia.TasaDeMortalidad("Gofue");

            //Doti
            bitmonlandia.TasaDeMortalidad("Doti");

            //Wetar
            bitmonlandia.TasaDeMortalidad("Wetar");

            //Ent
            bitmonlandia.TasaDeMortalidad("Ent");

            Console.WriteLine("");
            /////////////////////////////////////////////////
            //Cantidad de hijos por especie
            //Taplan
            bitmonlandia.HijosPromedioEspecie("Taplan");

            //Dorvalo
            bitmonlandia.HijosPromedioEspecie("Dorvalo");

            //Gofue
            bitmonlandia.HijosPromedioEspecie("Gofue");

            //Doti
            bitmonlandia.HijosPromedioEspecie("Doti");

            //Wetar
            bitmonlandia.HijosPromedioEspecie("Wetar");

            //Ent
            bitmonlandia.HijosPromedioEspecie("Ent");

            Console.WriteLine("");

            ////////////////////////////////////////////////
            //Listado de especies extintas:
            bitmonlandia.GetEspeciesExtintas();

            Console.WriteLine("");
            ///////////////////////////////////////////
            //Bithalla:







            Console.ReadLine();
        }
    }
}