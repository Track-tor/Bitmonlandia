using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Ent:Bitmon
    {
        public Ent(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
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
        { }
            return base.Reproduccion(pareja);
        }

        public override void Movimiento(Mapa mapa)
        {
            base.Movimiento(mapa);
        }
    }
}
