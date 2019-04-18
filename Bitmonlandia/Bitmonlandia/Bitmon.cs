using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Bitmon
    {
        string tipo_De_Bitmon;
        private int tiempo_De_Vida;
        private bool estado_De_Vida;
        private int puntos_De_Ataque;
        private int puntos_De_Vida;
        private int [] posicion= new int[2];

        public Bitmon(string tipo_De_Bitmon, int tiempo_De_Vida,int puntos_De_Ataque,int puntos_De_Vida, int [] posicion)
        {
            this.tiempo_De_Vida = tiempo_De_Vida;
            this.estado_De_Vida = true;
            this.puntos_De_Ataque = puntos_De_Ataque;
            this.puntos_De_Vida = puntos_De_Ataque;
            this.posicion = posicion;
        }

        public virtual Bitmon Pelea(Bitmon peleador) // Pelea entre bitmons
        {

            return peleador;
        }

        public virtual Bitmon Reproduccion(Bitmon pareja) // Reproduccion de Bitmons
        {
            return pareja;
        }

        public virtual void Movimiento(Mapa mapa) // Movimiento de los Bitmons
        {

        }

        public bool GetEstadoDeVida()
        {
            return estado_De_Vida;
        }

        public string GetNombre()
        {

            return tipo_De_Bitmon;
        }
    }
}
