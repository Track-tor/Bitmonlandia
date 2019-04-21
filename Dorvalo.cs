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
            if (peleador.GetNombre() == "Wetar" | peleador.GetNombre() == "Taplan" | peleador.GetNombre() == "Ent")
            {
                while (estado_De_Vida == true | peleador.GetEstadoDeVida() == true)
                {
                    puntos_De_Vida -= peleador.GetPuntosDeAtaque();
                    peleador.RecibirAtaque(puntos_De_Ataque);
                }
            }

            return base.Pelea(peleador);
        }

        public override Bitmon Reproduccion(Bitmon pareja)
        {
            if (pareja.GetNombre() == "Gofue" | pareja.GetNombre() == "Dorvalo" | pareja.GetNombre() == "Doti")
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
            int vertical = random.Next(-2, 3);
            int horizontal = random.Next(-2, 3);

            //Veo si el bitmon caera fuera de los limites del mapa:
            while ( (x+vertical<0) || (y+horizontal<0) || (x+vertical>=cant_filas) || (y+horizontal>=cant_columnas) )
            {
                vertical = random.Next(-2, 3);
                horizontal = random.Next(-2, 3);
            }

            mapa.RemoveBitmon(x, y);
            posicion[0] += vertical;
            posicion[1] += horizontal;
            string sigla = tipo_De_Bitmon.Substring(0, 3);
            mapa.SetBitmon(sigla, x + vertical, y + horizontal);
            Console.WriteLine("{0}: ({1},{2})", tipo_De_Bitmon, posicion[0], posicion[1]);
        }
    }
}
