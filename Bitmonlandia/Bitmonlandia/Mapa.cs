using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Mapa
    {
        /* Terrenos:
         * Vegetacion = V
         * Acuatico = A
         * Desierto = D
         * Nieve = N
         * Lava = L
         */


        private int alto;
        private int ancho;
        private int preset;
        private string[,,] tablero;


        public Mapa(int preset)
        {   //{Terreno, Bitmon en el terreno}
            this.preset = preset;
            if (preset == 1)
            {
                alto = 5;
                ancho = 5;
                tablero = new string[5, 5, 2] { { { "D", "   " }, { "V", "   " }, { "A", "   " }, { "A", "   " }, { "N", "   " } }, 
                                                { { "D", "   " }, { "A", "   " }, { "A", "Tap" }, { "A", "   " }, { "N", "   " } }, 
                                                { { "D", "   " }, { "A", "   " }, { "A", "   " }, { "D", "   " }, { "V", "   " } }, 
                                                { { "V", "   " }, { "L", "   " }, { "L", "   " }, { "D", "   " }, { "A", "   " } }, 
                                                { { "V", "   " }, { "L", "   " }, { "L", "   " }, { "A", "Dor" }, { "A", "Wet" } } };
            }
            else if (preset == 2)
            {
                alto = 10;
                ancho = 10;
                tablero = new string[10, 10, 2] { { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } } };
            }
            else if (preset == 3)
            {
                alto = 15;
                ancho = 15;
                tablero = new string[15, 15, 2] { { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } },
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                  { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } } };
            }

        }

        public void ImprimirTablero()
        {
            //Imprimir tablero en pantalla
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    switch (tablero[i, j, 0])
                    {
                        case "V":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case "A":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;

                        case "D":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;

                        case "N":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case "L":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;

                    }
                    Console.Write("[{0}:", tablero[i, j, 0].ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0}", tablero[i, j, 1].ToString());
                    switch (tablero[i, j, 0])
                    {
                        case "V":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case "A":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;

                        case "D":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;

                        case "N":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case "L":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;

                    }
                    Console.Write("]     ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string [,,] GetTablero()
        {
            return tablero;
        }

        //Funcion para cambiar el terrrno del tablero ya que es private
        public void SetTerreno(string terreno, int x, int y)
        {
            this.tablero[x,y,0] = terreno;
        }

        //Funcion para agregar el bitmon a la cordenada deseada (vital para Moverse())
        public void SetBitmon(string especie, int x, int y)
        {
            this.tablero[x, y, 1] = especie;
        }

        //Funcion para quitar el bitmon de la cordenada deseada (vital para Moverse())
        public void RemoveBitmon(int x, int y)
        {
            this.tablero[x, y, 1] = "   ";
        }
    }
}