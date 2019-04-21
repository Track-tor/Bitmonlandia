using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Taplan:Bitmon
    {
        public Taplan(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
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

        public override Bitmon Reproduccion(Bitmon pareja)
        {
            if (pareja.GetNombre() == "Ent" | pareja.GetNombre() == "Taplan" | pareja.GetNombre() == "Wetar" | pareja.GetNombre() == "Doti")
            {

            }
            return base.Reproduccion(pareja);
        }
    }
}
