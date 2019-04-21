using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Bitmon
    {
        private Random random = new Random();

        protected string tipo_De_Bitmon = "";
        protected int tiempo_De_Vida;
        protected bool estado_De_Vida = true;
        protected int puntos_De_Ataque;
        protected int puntos_De_Vida;
        protected int [] posicion= new int[2];

        public Bitmon(string tipo_De_Bitmon, int tiempo_De_Vida,int puntos_De_Ataque,int puntos_De_Vida, int [] posicion)
        {
            this.tipo_De_Bitmon = tipo_De_Bitmon;
            this.tiempo_De_Vida = tiempo_De_Vida;
            this.puntos_De_Ataque = puntos_De_Ataque;
            this.puntos_De_Vida = puntos_De_Ataque;
            this.posicion = posicion;
        }

        public virtual Bitmon Pelea(Bitmon peleador) // Pelea entre bitmons
        {

            return peleador;
        }

        public virtual Bitmon Reproduccion(Bitmon pareja) // Reproduccion de Bitmons
        {
            return pareja;
        }

        public virtual void Movimiento(Mapa mapa) // Movimiento de los Bitmons
        {
            string[,,] tablero = mapa.GetTablero();
            int cant_filas = tablero.GetLength(0);
            int cant_columnas = tablero.GetLength(1);
            int x = posicion[0];
            int y = posicion[1];
            Console.WriteLine("ANTES: {0} {1}", posicion[0], posicion[1]);
            int vertical = random.Next(-1, 2);
            int horizontal = random.Next(-1, 2);

            //Veo si el bitmon caera fuera de los limites del mapa:
            while (((x + vertical) < 0) || ((y + horizontal) < 0) || ((x + vertical) >= cant_filas) || ((y + horizontal) >= cant_columnas))
            {
                vertical = random.Next(-1, 2);
                horizontal = random.Next(-1, 2);

            }
            Console.WriteLine("AVANZA: {0} {1}", vertical, horizontal);
            mapa.RemoveBitmon(x, y);
            posicion[0] += vertical;
            posicion[1] += horizontal;
            string sigla = tipo_De_Bitmon.Substring(0, 3);
            mapa.SetBitmon(sigla, posicion[0], posicion[1]);
            Console.WriteLine("AHORA: {0}: ({1},{2})", tipo_De_Bitmon, posicion[0], posicion[1]);
        }

        public bool GetEstadoDeVida()
        {
            return estado_De_Vida;
        }

        public string GetNombre()
        {

            return tipo_De_Bitmon;
        }

        public int[] GetPosicion()
        {
            return posicion;
        }

        /*Esta funcion es para que el Gofue transforme un terreno vegetacion en desiertico, o un terreno
        * de nieve en uno de agua:*/
        public void Secar(Mapa mapa)
        {
            int x = GetPosicion()[0];
            int y = GetPosicion()[1];
            string[,,] tablero = mapa.GetTablero();
            if (tablero[x, y, 0] == "V")
            {
                mapa.SetTerreno("D", x, y);
            }

            else if (tablero[x, y, 0] == "N")
            {
                mapa.SetTerreno("A", x, y);
            }
        }

        //Esta funcion es para que la plnta transforme un terreno desiertico en vegetacion
        public void Plantar(Mapa mapa)
        {
            int x = GetPosicion()[0];
            int y = GetPosicion()[1];
            string[,,] tablero = mapa.GetTablero();
            if (tablero[x, y, 0] == "D")
            {
                mapa.SetTerreno("V", x, y);
            }
        }
    }
}
