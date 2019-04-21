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
        Bitmonlandia bitmonlandia = new Bitmonlandia(1);

        public Wetar(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }
        public override Bitmon Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Gofue" | peleador.GetNombre() == "Dorvalo")
            {
                while (estado_De_Vida == true | peleador.GetEstadoDeVida() == true)
                {
                    puntos_De_Vida -= peleador.GetPuntosDeAtaque();
                    peleador.RecibirAtaque(puntos_De_Ataque);
                }
            }

            return base.Pelea(peleador);
        }

        /* Reproduccion de Bitmons consiste en que si la pareja es compatible, se instancia dentro de la lista de Bitmons 
        * un nuevo Bitmon de una especie aleatoria
       */
        public override Bitmon Reproduccion(Bitmon pareja)
        {
            if (pareja.GetNombre() == "Ent" | pareja.GetNombre() == "Taplan" | pareja.GetNombre() == "Wetar" | pareja.GetNombre() == "Doti")
            {
                int num = random.Next(1, 7); // Numero aleatorio que genere un bitmon aleatorio
                int c1 = random.Next(5); // Asignacion de una coordenada aleatoria
                int c2 = random.Next(5); // Asignacion de una coordenada aleatoria
                int[] tupla = { c1, c2 };
                switch (num)
                {
                    case 1:
                        bitmonlandia.añadir_bitmon(new Wetar("Wetar", 10, 10, 10, tupla));
                        break;
                    case 2:
                        bitmonlandia.añadir_bitmon(new Taplan("Taplan", 10, 10, 10, tupla));
                        break;
                    case 3:
                        bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 10, 10, 10, tupla));
                        break;
                    case 4:
                        bitmonlandia.añadir_bitmon(new Doti("Doti", 10, 10, 10, tupla));
                        break;
                    case 5:
                        bitmonlandia.añadir_bitmon(new Gofue("Gofue", 10, 10, 10, tupla));
                        break;
                    case 6:
                        bitmonlandia.añadir_bitmon(new Ent("Ent", 10, 10, 10, tupla));
                        break;
                }

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
