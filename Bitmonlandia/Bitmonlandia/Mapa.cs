using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Mapa
    {
        private int alto;
        private int ancho;
        private string[,,] tablero;

        public Mapa(int alto, int ancho)
        {
            this.alto = alto;
            this.ancho = ancho;
            tablero = new string[ancho, alto, 2];
        }

        public string[,,] GetTablero()
        {
            return tablero;

        }

    }
}
