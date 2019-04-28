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
                tablero = new string[5, 5, 3] { { { "V", "   ","   "}, { "V", "   ","   "},{ "V", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                { { "V", "   ","   "}, { "V", "   ","   "},{ "V", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                { { "D", "   ","   "}, { "D", "   ","   "},{ "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                { { "L", "   ","   "}, { "L", "   ","   "},{ "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}},
                                                { { "L", "   ","   "}, { "L", "   ","   "},{ "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}}};
            }
            else if (preset == 2)
            {
                alto = 10;
                ancho = 10;
                tablero = new string[10, 10, 3] { { { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "A", "   ","   "}, { "L", "   ","   "} },
                                                  { { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "A", "   ","   "}, { "L", "   ","   "} },
                                                  { { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "} },
                                                  { { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "A", "   ","   "} },
                                                  { { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "V", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "A", "   ","   "} },
                                                  { { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "V", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "A", "   ","   "} },
                                                  { { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "A", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "} },
                                                  { { "A", "   ","   "}, { "A", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "A", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "} },
                                                  { { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "A", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "} },
                                                  { { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "} } };
            }
            else if (preset == 3)
            {
                alto = 15;
                ancho = 15;
                tablero = new string[15, 15, 3] { { { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "A", "   ","   "}, { "A", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "A", "   ","   "}, { "A", "   ","   "}, { "A", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "A", "   ","   "}, { "A", "   ","   "}, { "N", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "L", "   ","   "}, { "L", "   ","   "}, { "N", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "V", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "L", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "L", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "L", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "L", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}},
                                                  { { "L", "   ","   "}, { "L", "   ","   "}, { "L", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "D", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}, { "N", "   ","   "}} };
            }

        }

        public void ImprimirTablero()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            //Imprimir tablero en pantalla
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    switch (tablero[i, j, 0])
                    {
                        case "V":
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;

                        case "A":
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;

                        case "D":
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;

                        case "N":
                            Console.BackgroundColor = ConsoleColor.White;
                            break;

                        case "L":
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            break;

                    }
                    Console.Write(" [{0}] ", tablero[i, j, 1].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");

                for (int j = 0; j < alto; j++)
                {
                    switch (tablero[i, j, 0])
                    {
                        case "V":
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;

                        case "A":
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;

                        case "D":
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;

                        case "N":
                            Console.BackgroundColor = ConsoleColor.White;
                            break;

                        case "L":
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            break;

                    }
                    Console.Write(" [{0}] ", tablero[i, j, 2].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");

            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string[,,] GetTablero()
        {
            return tablero;
        }

        //Funcion para cambiar el terreno del tablero ya que es private
        public void SetTerreno(string terreno, int x, int y)
        {
            this.tablero[x, y, 0] = terreno;
        }

        //Funcion para agregar el bitmon a la cordenada deseada (vital para Moverse())
        public void SetBitmon(string especie, int x, int y, int celda)
        {
            this.tablero[x, y, celda] = especie;
        }

        //Funcion para quitar el bitmon de la cordenada deseada (vital para Moverse())
        public void RemoveBitmon(int x, int y, int celda)
        {
            if(x != -1 && y != -1)
                this.tablero[x, y, celda] = "   ";
        }
    }
}