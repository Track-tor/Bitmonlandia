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
        {
            this.preset = preset;
            if (preset == 1)
            {
                alto = 5;
                ancho = 5;
                tablero = new string[5, 5, 2] { { { "F", "A" }, { "B", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } }, 
                                                { { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" }, { "A", "A" } } };
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

        public string[,,] GetTablero()
        {
            //Imprimir tablero en pantalla
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    Console.Write(string.Format("{0} ", tablero[i, j, 0]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            return tablero;
        }

        //Funcion para cambiar el terrrno del tablero ya que es private
        public void SetTerreno(string terreno, int x, int y)
        {
            this.tablero[x,y,0] = terreno;
        }

    }
}