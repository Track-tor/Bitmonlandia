﻿using System;
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
                                                { { "V", "   " }, { "L", "   " }, { "A", "   " }, { "D", "Dor" }, { "N", "   " } }, 
                                                { { "V", "   " }, { "L", "   " }, { "L", "   " }, { "A", "   " }, { "N", "   " } } };
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
                    Console.Write("({0},{1})     ", tablero[i, j, 0].ToString(), tablero[i,j,1].ToString());
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

            }
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