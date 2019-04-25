using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bitmonlandia
{
    class Program
    {
        static Random random = new Random();

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
            

            // TO DO : LOS BITMONS HAY QUE INSTANCIARLOS DENTRO DE BITMONLANDIA(y bien posicionados)!!!
            /*bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5,10,tupla));
            bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10, 5, 10, tupla2));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));
            bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 5, 10, tupla));*/
            

            Console.WriteLine("--------------------# MAPA INICIAL #---------------------\n");
            bitmonlandia.GetMapa().ImprimirTablero();

            //--------------------------Simulacion por meses------------------------------------
            Console.Write("¿Cuantos meses desea simular?: ");
            int cantidad_meses = int.Parse(Console.ReadLine());
            Console.Write("\n");

            for (int mes = 0; mes < cantidad_meses; mes++)
            {
                

                //ciclo for para que los bitmons se muevan
                for (int bit = 0; bit < bitmonlandia.GetLista().Count; bit++)
                {
                    //vemos si es que el bitmon no esta muerto
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    string especie = bitmonlandia.GetLista()[bit].GetNombre();

                    //Movimiento:
                    if (especie != "Ent")
                    {
                        bitmonlandia.GetLista()[bit].Movimiento(bitmonlandia.GetMapa());
                    }

                }
                //se imprime el tablero para ver los movimientos que ocurrieron dentro del mes
                Console.WriteLine("Mes: {0}", mes);
                Console.WriteLine("");
                Console.WriteLine("Los bitmons se han movido!");
                bitmonlandia.GetMapa().ImprimirTablero();
                Console.WriteLine("Presione una ENTER para continuar");
                Console.ReadLine();

                //Se recorre la lista de bitmons para ver si hay bitmons en la misma casilla
                for (int bit = 0; bit < bitmonlandia.GetLista().Count; bit++)
                {
                    // vemos si es que el bitmon no esta muerto
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    //Selecciono el primer bitmon y veo su especie tambien:
                    string especie = bitmonlandia.GetLista()[bit].GetNombre();


                    //Y recorro la lista en busca de una coincidencia
                    for (int pareja = bit+1; pareja < bitmonlandia.GetLista().Count; pareja++)
                    {

                        if (bitmonlandia.GetLista()[bit].GetPosicion()[0] == bitmonlandia.GetLista()[pareja].GetPosicion()[0] && bitmonlandia.GetLista()[bit].GetPosicion()[1] == bitmonlandia.GetLista()[pareja].GetPosicion()[1
                            ])
                        {
                            //Primero intentamos con pelea
                            bitmonlandia.GetLista()[bit].Pelea(bitmonlandia.GetLista()[pareja]);

                            //Si no funciona, significa que se llevan bien para reproducirse
                            if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == true && bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == true)
                            {
                                int prob = random.Next(101);
                                if(prob <= 30)
                                    bitmonlandia.GetLista()[bit].Reproduccion(bitmonlandia.GetLista()[pareja], size, bitmonlandia);
                            }
                        }




                        if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                        {
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[bit].GetPosicion()[0], bitmonlandia.GetLista()[bit].GetPosicion()[1], bitmonlandia.GetLista()[bit].GetCelda());
                            bitmonlandia.GetLista()[bit].LimpiarCadaver();
                        }

                        if (bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == false)
                        {
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[pareja].GetPosicion()[0], bitmonlandia.GetLista()[pareja].GetPosicion()[1], bitmonlandia.GetLista()[pareja].GetCelda());
                            bitmonlandia.GetLista()[pareja].LimpiarCadaver();
                        }

                    }

                    /*Comprobamos si sigue vivo este bitmon, para asi saber si moverlo y cambiar el terreno
                        * si corresponde*/
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                        {
                            continue;
                        }

                    //Ahora que sabemos que esta vivo cambiamos el terreno si corresponde
                    //Transformar terreno:
                    if (especie == "Gofue")
                        {
                        bitmonlandia.GetLista()[bit].Secar(bitmonlandia.GetMapa());
                        }

                    else if (especie == "Taplan")
                        {
                        bitmonlandia.GetLista()[bit].Plantar(bitmonlandia.GetMapa());
                        }

                    //Si sigue vivo despues de todo, hacerlo envejecer
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida()==true)
                    {
                        bitmonlandia.GetLista()[bit].Envejecer(bitmonlandia.GetMapa());
                    }

                }

                //Si han pasado 3 meses y algun Ent sigue vivo, spawnear uno
                if (mes % 3 == 0 && mes!=0)
                {
                    bitmonlandia.PlantarEnt(size);
                }

                //bitmonlandia.GetInformacion();
                Console.WriteLine("Mes: {0}", mes);
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
            Console.WriteLine("--------------------------------# Resumen de la simulacion #-------------------------------------");
            Console.WriteLine("");
            File.WriteAllText("resumen.txt", "\\\\\\\\\\\\Resumen de la simulacion\\\\\\\\\\\\\r\n");
            File.AppendAllText("resumen.txt", "\r\n");

            //Tiempo de vida promedio Bitmon:
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Tiempo de vida promedio Bitmon:");
            Console.ForegroundColor = ConsoleColor.White; bitmonlandia.TiempoDeVidaPromedioBitmon();
            Console.WriteLine("");
            File.AppendAllText("resumen.txt", "\r\n");

            ////////////////////////////////////////////
            //Tiempo de vida promedio de cada especie:
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Tiempo de vida promedio de cada especie:");
            Console.ForegroundColor = ConsoleColor.White;
            File.AppendAllText("resumen.txt", "Tiempo de vida promedio de cada especie:\r\n");
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
            File.AppendAllText("resumen.txt", "\r\n");

            /////////////////////////////////////////////////
            //Tasa de natalidad de cada especie:
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("Tasa de natalidad de cada especie:");
            Console.ForegroundColor = ConsoleColor.White;
            File.AppendAllText("resumen.txt", "Tasa de natalidad de cada especie:\r\n");
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
            File.AppendAllText("resumen.txt", "\r\n");

            ////////////////////////////////////////////////
            //Tasa de mortalidad de cada especie:
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Tasa de mortalidad de cada especie:");
            Console.ForegroundColor = ConsoleColor.White;
            File.AppendAllText("resumen.txt", "Tasa de mortalidad de cada especie:\r\n");
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
            File.AppendAllText("resumen.txt","\r\n");
            /////////////////////////////////////////////////
            //Cantidad de hijos por especie
            Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine("Cantidad de hijos por especie:");
            Console.ForegroundColor = ConsoleColor.White;
            File.AppendAllText("resumen.txt", "Cantidad de hijos por especie:\r\n");
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

            Console.WriteLine("");
            File.AppendAllText("resumen.txt", "\r\n");

            ////////////////////////////////////////////////
            //Listado de especies extintas:
            Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("Lista de especies extintas:");
            Console.ForegroundColor = ConsoleColor.White;
            File.AppendAllText("resumen.txt", "Lista de especies extintas\r\n");
            bitmonlandia.GetEspeciesExtintas();

            Console.WriteLine("");
            File.AppendAllText("resumen.txt", "\r\n");
            ///////////////////////////////////////////
            //Bithalla:
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("Bithalla:");
            Console.ForegroundColor = ConsoleColor.White;
            File.AppendAllText("resumen.txt", "Bithalla:\r\n");
            bitmonlandia.Bithalla();

            Console.WriteLine("");
            File.AppendAllText("resumen.txt", "\r\n");

            Console.ReadLine();
        }


    }
}