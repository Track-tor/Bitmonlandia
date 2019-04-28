using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Ent:Bitmon
    {
        //Tiempo de vida maximo segun esta especie = 100

        Random random = new Random();

        public Ent(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }
        public override Bitmon Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Gofue" || peleador.GetNombre() == "Dorvalo" || peleador.GetNombre() == "Taplan" || peleador.GetNombre() == "Wetar")
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
                    puntos_De_Ataque += multiplicador;
                }
                else if (rival == "Wetar")
                {


                    puntos_De_Ataque -= multiplicador;
                }
                else if (rival == "Taplan")
                {
                    puntos_De_Ataque += 0;
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

        public override void Reproduccion(Bitmon pareja, int size, Bitmonlandia bitmonlandia)
        {
        }

        // Reduce el tiempo de vida del Bitmon dependiendo de el terreno en donde se encuentre
        public override void Envejecer(Mapa mapa)
        {
            int x = GetPosicion()[0];
            int y = GetPosicion()[1];
            string[,,] tablero = mapa.GetTablero();
            terreno = tablero[x, y, 0];

            if (terreno == "L")
            {
                tiempo_De_Vida -= 2;
            }
            else if (terreno == "N")
            {
                tiempo_De_Vida -= 2;
            }
            else
            {
                tiempo_De_Vida -= 1;
            }
            meses_vividos += 1;
        }
    }

}

