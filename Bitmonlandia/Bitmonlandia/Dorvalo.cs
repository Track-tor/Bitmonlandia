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
    }
}
