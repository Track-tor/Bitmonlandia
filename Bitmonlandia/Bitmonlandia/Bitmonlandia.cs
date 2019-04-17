using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Bitmonlandia
    {
        Mapa mapa = new Mapa();
        //lista con todos los bitmons presentes en el mapa (vivos y muertos)
        List<Bitmon> lista_bitmons_totales = new List<Bitmon>();

        //va a partir con 2 bitmons de cada especie
        Ent ent1 = new Ent();
        Ent ent2 = new Ent();
        Taplan taplan1 = new Taplan();
        Taplan taplan2 = new Taplan();
        Doti doti1 = new Doti();
        Doti doti2 = new Doti();
        Dorvalo dorvalo1 = new Dorvalo();
        Dorvalo dorvalo2 = new Dorvalo();
        Gofue gofue1 = new Gofue();
        Gofue gofue2 = new Gofue();
        Wetar wetar1 = new Wetar();
        Wetar wetar2 = new Wetar();
        lista_bitmon_totales.Add(ent1);
        lista_bitmon_totales.Add(ent2);
        lista_bitmon_totales.Add(taplan1);
        lista_bitmon_totales.Add(taplan2);
        lista_bitmon_totales.Add(doti1);
        lista_bitmon_totales.Add(doti2);
        lista_bitmon_totales.Add(dorvalo1);
        lista_bitmon_totales.Add(dorvalo2);
        lista_bitmon_totales.Add(gofue1);
        lista_bitmon_totales.Add(gofue2);
        lista_bitmon_totales.Add(wetar1);
        lista_bitmon_totales.Add(wetar2);

        //mapa a utilizar en el mundo bitmon, que se obtiene con GetTbalero() ya que es private
        private string[] tablero = mapa.GetTablero();


        private int tiempo_Transcurrido = 0;

        //Metodos:
        //Esta funcion retorna el tiempo transcurrido en meses que esta en private en esta clase
        public int GetTiempoTranscurrido()
        {
            return tiempo_Transcurrido;
        }

        /*recibe como argumneto la lista de bitmons vivos y muertos y
          entrega la cantidad de bitmons que se encuentran en el bithalla, si esta
          muerto lo elimino de la lista y resto en uno el indice b*/
        public int Bithalla(List <Bitmon> lista_bitmons_totales)
        {
            int muertos=0;
            for (int b = 0; b<lista_bitmons_totales.Count(); b++)
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

        public void Posicionar_bitmons( List<Bitmon> lista_bitmons_totales, string[] tablero)
        {

        }
    }
}
