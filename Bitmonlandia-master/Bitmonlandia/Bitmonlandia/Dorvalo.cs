using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Dorvalo:Bitmon
    {
        Random random = new Random();

        public Dorvalo(string tipo_De_Bitmon,int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion): base(tipo_De_Bitmon,tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion) 
        {

        }

        public override Bitmon Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Wetar" || peleador.GetNombre() == "Taplan" || peleador.GetNombre() == "Ent")
            {
                while (estado_De_Vida == true && peleador.GetEstadoDeVida() == true)
                {
                    puntos_De_Vida -= peleador.GetPuntosDeAtaque();
                    peleador.RecibirAtaque(puntos_De_Ataque);
                    CambiarEstadoDeVida();
                    peleador.CambiarEstadoDeVida();
                    Console.WriteLine($"{peleador.GetNombre()} perdio vida ");
                    Console.WriteLine($"{GetNombre()} perdio vida ");
                }
            }

            return base.Pelea(peleador);
        }

        /* Reproduccion de Bitmons consiste en que si la pareja es compatible, se instancia dentro de la lista de Bitmons 
         * un nuevo Bitmon de una especie aleatoria
        */
        public override Bitmon Reproduccion(Bitmon pareja, int size, Bitmonlandia bitmonlandia)
        {
            if (pareja.GetNombre() == "Gofue" | pareja.GetNombre() == "Dorvalo" | pareja.GetNombre() == "Doti")
            {
                int num = random.Next(1,7); // Numero aleatorio que genere un bitmon aleatorio
                int c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                int c2 = random.Next(size); // Asignacion de una coordenada aleatoria
                int[] tupla = { c1, c2 };
                switch (num)
                {
                    case 1:
                        bitmonlandia.añadir_bitmon(new Wetar("Wetar",10,10,10,tupla));
                        break;
                    case 2:
                        bitmonlandia.añadir_bitmon(new Taplan("Taplan",10,10,10,tupla));
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
            return base.Reproduccion(pareja, size, bitmonlandia);
        }

        public override void Movimiento(Mapa mapa)
        {
            string[,,] tablero = mapa.GetTablero();
            int cant_filas = tablero.GetLength(0);
            int cant_columnas = tablero.GetLength(1);
            int x = posicion[0];
            int y = posicion[1];
            int vertical = random.Next(-2, 3);
            int horizontal = random.Next(-2, 3);

            //Veo si el bitmon caera fuera de los limites del mapa:
            while ((x + vertical < 0) || (y + horizontal < 0) || (x + vertical >= cant_filas) || (y + horizontal >= cant_columnas))
            {
                vertical = random.Next(-2, 3);
                horizontal = random.Next(-2, 3);
            }
            int celda_antigua = celda;
            int celda_nueva = celda;

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
    }
}
