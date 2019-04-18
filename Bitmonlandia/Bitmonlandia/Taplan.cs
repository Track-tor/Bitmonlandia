using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Taplan:Bitmon
    {
        public Taplan(int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }
        public override Bitmon Pelea(Bitmon peleador)
        {
            return base.Pelea(peleador);
        }

        public override Bitmon Reproduccion(Bitmon pareja)
        {
            return base.Reproduccion(pareja);
        }

        public override void Movimiento(Mapa mapa)
        {
            base.Movimiento(mapa);
        }

    }
}
