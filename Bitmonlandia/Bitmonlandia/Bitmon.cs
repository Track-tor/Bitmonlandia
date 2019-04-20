using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Bitmon
    {
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
