﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Doti:Bitmon
    {
        public Doti(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }

        public override Bitmon Pelea(Bitmon peleador)
        {
            return base.Pelea(peleador);
        }

        public override Bitmon Reproduccion(Bitmon pareja)
        {
            if (pareja.GetNombre() == "Gofue" | pareja.GetNombre() == "Dorvalo" | pareja.GetNombre() == "Doti"| pareja.GetNombre() == "Wetar" | pareja.GetNombre() == "Taplan" | pareja.GetNombre() == "Ent")
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
