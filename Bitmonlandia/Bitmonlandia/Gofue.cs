﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Gofue : Bitmon
    {
        public Gofue(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }

        /*Esta funcion es para que la planta transforme un terreno vegatcion en desiertico, o un terreno
         * de nieve en uno de agua:*/
        public void Secar(Mapa mapa)
        {
            //
        }


        public override Bitmon Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Wetar"| peleador.GetNombre() == "Taplan" | peleador.GetNombre() == "Ent")
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
            base.Movimiento(mapa);
        }
    }
}
