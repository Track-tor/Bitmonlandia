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
        protected int celda = 1;
        protected int [] posicion= new int[2];
        protected int hijos = 0;
        protected int meses_vividos = 0;


        public Bitmon(string tipo_De_Bitmon, int tiempo_De_Vida,int puntos_De_Ataque,int puntos_De_Vida, int [] posicion)
        {
            this.tipo_De_Bitmon = tipo_De_Bitmon;
            this.tiempo_De_Vida = tiempo_De_Vida;
            this.puntos_De_Ataque = puntos_De_Ataque;
            this.puntos_De_Vida = puntos_De_Ataque;
            this.posicion = posicion;
        }

        //Gets De Atributos

        public bool GetEstadoDeVida()
        {
            return estado_De_Vida;
        }

        public int GetPuntosDeVida()
        {
            return puntos_De_Vida;
        }

        public int GetPuntosDeAtaque()
        {
            return puntos_De_Ataque;
        }

        public string GetNombre()
        {

            return tipo_De_Bitmon;
        }

        public int[] GetPosicion()
        {
            return posicion;
        }

        public int GetCelda()
        {
            return celda;
        }

        public void Envejecer()
        {
            tiempo_De_Vida -= 1;
            meses_vividos += 1;
        }

        //Sets

      
        // El Bitmon recibe el ataque
        public void RecibirAtaque(int puntos_De_Ataque)
        {
            this.puntos_De_Vida -= puntos_De_Ataque;
        }

        // Cambia el estado de vida del Bitmon cuando los puntos de vida son menores a 0
        public void CambiarEstadoDeVida()
        {
            if (puntos_De_Vida <= 0)
            {
                this.estado_De_Vida = false;
            }
        }

        // Pelea entre bitmons
        public virtual Bitmon Pelea(Bitmon peleador) 
        {

            return peleador;
        }

        // Reproduccion de Bitmons
        public virtual Bitmon Reproduccion(Bitmon pareja, int size, Bitmonlandia bitmonlandia) 
        {
            return pareja;
        }

        // Movimiento de los Bitmons
        public virtual void Movimiento(Mapa mapa)
        {
            string[,,] tablero = mapa.GetTablero();
            int cant_filas = tablero.GetLength(0);
            int cant_columnas = tablero.GetLength(1);
            int x = posicion[0];
            int y = posicion[1];
            int vertical = random.Next(-1, 2);
            int horizontal = random.Next(-1, 2);

            //Veo si el bitmon caera fuera de los limites del mapa:
            while (((x + vertical) < 0) || ((y + horizontal) < 0) || ((x + vertical) >= cant_filas) || ((y + horizontal) >= cant_columnas))
            {
                vertical = random.Next(-1, 2);
                horizontal = random.Next(-1, 2);

            }

            int celda_antigua = celda;
            int celda_nueva = 1;

            //Veo si esta ocupada la celda a la cual se va a mover
            while (tablero[x + vertical, y + horizontal, celda_nueva] != "   ")
            {
                //Si ya no hay mas espacio a donde se va a mover, se quedar en el mismo lugar
                if (celda_nueva == 2 && (tablero[x + vertical, y + horizontal, celda_nueva] != "   "))
                {
                    celda_nueva = celda;
                    vertical = 0;
                    horizontal = 0;
                    break;
                }
                celda_nueva++;
            }

            mapa.RemoveBitmon(x, y, celda_antigua);
            posicion[0] += vertical;
            posicion[1] += horizontal;
            celda = celda_nueva; 
            string sigla = tipo_De_Bitmon.Substring(0, 3);
            mapa.SetBitmon(sigla, posicion[0], posicion[1], celda_nueva);
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

        //Esta funcion es para que el Taplan transforme un terreno desiertico en vegetacion
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
