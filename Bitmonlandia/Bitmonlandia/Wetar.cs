using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Wetar:Bitmon
    {  
        private static Random random = new Random();

        public Wetar(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }
        public override Bitmon Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Gofue" | peleador.GetNombre() == "Dorvalo")
            {

            }

            return base.Pelea(peleador);
        }

        public override Bitmon Reproduccion(Bitmon pareja)
        {
            if (pareja.GetNombre() == "Ent" | pareja.GetNombre() == "Taplan" | pareja.GetNombre() == "Wetar" | pareja.GetNombre() == "Doti")
            {

            }
            return base.Reproduccion(pareja);
        }
        public override void Movimiento(Mapa mapa)
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
                while (true) {
                    vertical = random.Next(0, 2);
                    horizontal = random.Next(0, 2);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //Esta en el borde superior del tablero??
            else if (x == 0 && y != cant_columnas - 1 && y != 0)
            {
                while (true)
                {
                    vertical = random.Next(0, 2);
                    horizontal = random.Next(-1, 2);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //Esta en la esquina superior derecha del tablero??
            else if (x == 0 && y == cant_columnas - 1)
            {
                while (true)
                {
                    vertical = random.Next(0, 2);
                    horizontal = random.Next(-1, 1);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //Esta en el borde derecha del tablero??
            else if (x != 0 && x != cant_filas - 1 && y == cant_columnas - 1)
            {
                while (true)
                {
                    vertical = random.Next(-1, 2);
                    horizontal = random.Next(-1, 1);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //Esta en la esquina inferior derecha del tablero??
            else if (x == cant_filas - 1 && y == cant_columnas - 1)
            {
                while (true)
                {
                    vertical = random.Next(-1, 1);
                    horizontal = random.Next(-1, 1);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //Esta en el borde inferior del tablero??
            else if (x == cant_filas - 1 && y != cant_columnas - 1 && y != 0)
            {
                while (true)
                {
                    vertical = random.Next(-1, 1);
                    horizontal = random.Next(-1, 2);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //Esta en la esquina inferior izquierda del tablero??
            else if (x == cant_filas - 1 && y == 0)
            {
                while (true)
                {
                    vertical = random.Next(-1, 1);
                    horizontal = random.Next(0, 2);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //Esta en el borde izquierdo del tablero??
            else if (x != 0 && x != cant_filas - 1 && y == 0)
            {
                while (true)
                {
                    vertical = random.Next(-1, 2);
                    horizontal = random.Next(0, 2);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            //No esta en los bordes
            else
            {
                while (true)
                {
                    vertical = random.Next(-1, 2);
                    horizontal = random.Next(-1, 2);
                    if (tablero[x + vertical, y + horizontal, 0] == "A")
                    {
                        break;
                    }
                }
            }

            mapa.RemoveBitmon(x, y);
            posicion[0] += vertical;
            posicion[1] += horizontal;
            string sigla = tipo_De_Bitmon.Substring(0, 3);
            mapa.SetBitmon(sigla, posicion[0], posicion[1]);
            Console.WriteLine("{0}: ({1},{2})", tipo_De_Bitmon, posicion[0], posicion[1]);
        }
    }
}
