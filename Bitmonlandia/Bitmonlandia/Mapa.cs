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
        private int preset;
        private string[,,] tablero;

        public Mapa(int alto, int ancho, int preset)
        {
            this.alto = alto;
            this.ancho = ancho;
            this.preset = preset;
            if (preset == 1)
            {
                tablero = new string[5, 5, 2] { { {"",""}, { "", "" }, { "", "" }, { "", ""}, { "", "" } },{ { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" } },{ { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" } },{ { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" } },{ { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" } } };
            }
            else if (preset == 2)
            {
                tablero = new string[ancho, alto, 2];
            }
            else if (preset == 3)
            {
                tablero = new string[ancho, alto, 2];
            }
            
        }

        public string[,,] GetTablero()
        {
            return tablero;
        }

    }
}
