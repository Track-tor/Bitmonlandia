using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Bitmonlandia
    {
        private int seed;

        private Mapa mapa; //lista con todos los bitmons presentes en el mapa (vivos y muertos)

        private List<Bitmon> lista_bitmons_totales = new List<Bitmon>(); //mapa a utilizar en el mundo bitmon, que se obtiene con GetTbalero() ya que es private
        private int tiempo_Transcurrido = 0;

        public Bitmonlandia(int seed)
        {
            this.seed = seed;
            mapa = new Mapa(seed);
        }

        //Metodos:
        //Esta funcion retorna el tiempo transcurrido en meses que esta en private en esta clase
        public int GetTiempoTranscurrido()
        {
            return tiempo_Transcurrido;
        }

        /*recibe como argumneto la lista de bitmons vivos y muertos y
          entrega la cantidad de bitmons que se encuentran en el bithalla, si esta
          muerto lo elimino de la lista y resto en uno el indice b*/
        public int Bithalla(List<Bitmon> lista_bitmons_totales)
        {
            int muertos = 0;
            for (int b = 0; b < lista_bitmons_totales.Count(); b++)
            {
                if (lista_bitmons_totales[b].GetEstadoDeVida() == false)
                {
                    lista_bitmons_totales.Remove(lista_bitmons_totales[b]);
                    muertos++;
                    b--;
                }
            }

            return muertos;
        }

        public void añadir_bitmon(Bitmon bitmon)
        {
            lista_bitmons_totales.Add(bitmon);
        }
        public void Posicionar_bitmons(List<Bitmon> lista_bitmons_totales, string[] tablero)
        {

        }
        public void GetMapa()
        {
            mapa.GetTablero();
        }

    }
}