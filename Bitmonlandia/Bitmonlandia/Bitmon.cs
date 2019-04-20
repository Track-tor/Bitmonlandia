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
            int vertical = 0;
            int horizontal = 0;

            //Veo si el bitmon esta en los limites del mapa:
            //Esta en la esquina superior izquierda del tablero?
            if (x == 0 && y == 0)
            {
                vertical = random.Next(0, 2);
                horizontal = random.Next(0, 2);
            }

            //Esta en el borde superior del tablero??
            else if (x == 0 && y != cant_columnas - 1 && y != 0)
            {
                vertical = random.Next(0, 2);
                horizontal = random.Next(-1, 2);
            }

            //Esta en la esquina superior derecha del tablero??
            else if (x == 0 && y == cant_columnas - 1)
            {
                vertical = random.Next(0, 2);
                horizontal = random.Next(-1, 1);
            }

            //Esta en el borde derecha del tablero??
            else if (x != 0 && x != cant_filas - 1 && y == cant_columnas - 1)
            {
                vertical = random.Next(-1, 2);
                horizontal = random.Next(-1, 1);
            }

            //Esta en la esquina inferior derecha del tablero??
            else if (x == cant_filas - 1 && y == cant_columnas - 1)
            {
                vertical = random.Next(-1, 1);
                horizontal = random.Next(-1, 1);
            }

            //Esta en el borde inferior del tablero??
            else if (x == cant_filas - 1 && y != cant_columnas - 1 && y != 0)
            {
                vertical = random.Next(-1, 1);
                horizontal = random.Next(-1, 2);
            }

            //Esta en la esquina inferior izquierda del tablero??
            else if (x == cant_filas - 1 && y == 0)
            {
                vertical = random.Next(-1, 1);
                horizontal = random.Next(0, 2);
            }

            //Esta en el borde izquierdo del tablero??
            else if (x != 0 && x != cant_filas - 1 && y == 0)
            {
                vertical = random.Next(-1, 2);
                horizontal = random.Next(0, 2);
            }

            //No esta en los bordes
            else
            {
                vertical = random.Next(-1, 2);
                horizontal = random.Next(-1, 2);
            }

            mapa.RemoveBitmon(x, y);
            posicion[0] += vertical;
            posicion[1] += horizontal;
            string sigla = tipo_De_Bitmon.Substring(0,3);
            mapa.SetBitmon(sigla, x + vertical, y + horizontal);
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
