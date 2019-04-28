using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Wetar:Bitmon
    {
        //Tiempo de vida maximo segun esta especie = 40

        private static Random random = new Random();

        public Wetar(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }
        public override Bitmon Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Gofue" || peleador.GetNombre() == "Dorvalo")
            {
                string rival = peleador.GetNombre();
                int multiplicador = random.Next(10, 21);

                //Dependiendo del rival, los puntos de ataque del Bitmon cambian
                if (rival == "Gofue")
                {
                    puntos_De_Ataque -= multiplicador;
                }
                else if (rival == "Dorvalo")
                {
                    puntos_De_Ataque -= multiplicador;
                }

                while (estado_De_Vida == true && peleador.GetEstadoDeVida() == true)
                {
                    puntos_De_Vida -= peleador.GetPuntosDeAtaque();
                    peleador.RecibirAtaque(puntos_De_Ataque);
                    CambiarEstadoDeVida();
                    peleador.CambiarEstadoDeVida();
                }
                SetGanador(estado_De_Vida);
                peleador.SetGanador(peleador.GetEstadoDeVida());

            }

            return base.Pelea(peleador);
        }

        /* Reproduccion de Bitmons consiste en que si la pareja es compatible, se instancia dentro de la lista de Bitmons 
        * un nuevo Bitmon de una especie aleatoria
       */
        public override void Reproduccion(Bitmon pareja, int size, Bitmonlandia bitmonlandia)
        {
            if (pareja.GetNombre() == "Taplan" || pareja.GetNombre() == "Wetar" || pareja.GetNombre() == "Doti")
            {
                tiempo_De_Vida += (tiempo_De_Vida * 3) / 10;
                pareja.SetTiempoDeVida(pareja.GetTiempoDeVida() + (pareja.GetTiempoDeVida() * 3) / 10);
                int c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                int c2 = random.Next(size); // Asignacion de una coordenada aleatoria

                //Veo si el bitmon caera fuera de los limites del mapa:
                int cont_de_escape = 0;
                while ((bitmonlandia.GetMapa().GetTablero()[c1, c2, 1] != "   " && bitmonlandia.GetMapa().GetTablero()[c1, c2, 2] != "   ") || bitmonlandia.GetMapa().GetTablero()[c1, c2, 0] != "A")
                {
                    //condicion de escape
                    if (cont_de_escape > 20)
                        return;
                    c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                    c2 = random.Next(size); // Asignacion de una coordenada aleatoria
                    cont_de_escape++;
                }

                int[] tupla = { c1, c2 };

                //Estadisticas
                int pa = random.Next(10, ((puntos_De_Ataque + pareja.GetPuntosDeAtaque()) / 2));
                int pv = random.Next(10, ((puntos_De_Vida + pareja.GetPuntosDeVida()) / 2));

                //Veamos la cantidad de hijos que han tenido ambos
                int hijos_padre = hijos;
                int hijos_pareja = pareja.GetHijos();
                string especie_hijo = "";

                int probabilidad = random.Next(0, 101);

                if (hijos_padre > hijos_pareja)
                {
                    if (probabilidad <= 70)
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }

                    else
                    {
                        especie_hijo = pareja.GetNombre();
                    }
                }

                else if (hijos_padre < hijos_pareja)
                {
                    if (probabilidad <= 70)
                    {
                        especie_hijo = pareja.GetNombre();
                    }

                    else
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }
                }

                else
                {
                    if (probabilidad <= 50)
                    {
                        especie_hijo = pareja.GetNombre();
                    }

                    else
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }
                }

                switch (especie_hijo)
                {
                    case "Taplan":
                        bitmonlandia.añadir_bitmon(new Taplan("Taplan", 50, pa, pv, tupla));
                        break;

                    case "Wetar":
                        bitmonlandia.añadir_bitmon(new Wetar("Wetar", 40, pa, pv, tupla));
                        break;

                    case "Doti":
                        bitmonlandia.añadir_bitmon(new Doti("Doti", 30, pa, pv, tupla));
                        break;
                }
                Console.WriteLine("Ha nacido un {0}", especie_hijo);

                hijos += 1;
                pareja.SetHijos();
            }
        }


        public override void Movimiento(Mapa mapa)
        {
            string[,,] tablero = mapa.GetTablero();
            int cant_filas = tablero.GetLength(0);
            int cant_columnas = tablero.GetLength(1);
            int x = posicion[0];
            int y = posicion[1];
            int vertical = random.Next(-1, 2);
            int horizontal = random.Next(-1, 2);

            //Veo si el bitmon caera fuera de los limites del mapa:
            while (((x + vertical) < 0) || ((y + horizontal) < 0) || ((x + vertical) >= cant_filas) || ((y + horizontal) >= cant_columnas) || (tablero[x+vertical,y+horizontal,0] != "A"))
            {
                vertical = random.Next(-1, 2);
                horizontal = random.Next(-1, 2);

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
