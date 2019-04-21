using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Bitmonlandia
    {
        private int seed; //atricuto que dicta la configuracion inicial del mapa y de los bitmons
        private Mapa mapa; //atributo que guarda el mapa actual de la simulacion del mundo bitmon
        private List<Bitmon> lista_bitmons_totales = new List<Bitmon>(); //lista con todos los bitmons presentes en el mapa (vivos y muertos)
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

        public List<Bitmon> GetLista()
        {
            return lista_bitmons_totales;
        }


        public void añadir_bitmon(Bitmon bitmon)
        {
            lista_bitmons_totales.Add(bitmon);
        }
        public void Posicionar_bitmons(List<Bitmon> lista_bitmons_totales, string[] tablero)
        {

        }

        //Funcion que imprime el tablero en pantalla y da acceso a el map que es privado
        public Mapa GetMapa()
        {
            mapa.GetTablero();
            return mapa;
        }

        public void GetInformacion()
        {
            for (int i = 0; i < lista_bitmons_totales.Count(); i++)
            {
                Console.WriteLine("{0} : posicion:[{1},{2}], hp: {3}, estado:{4}",lista_bitmons_totales[i].GetNombre(), lista_bitmons_totales[i].GetPosicion()[0], lista_bitmons_totales[i].GetPosicion()[1], lista_bitmons_totales[i].GetPuntosDeVida(), lista_bitmons_totales[i].GetEstadoDeVida());

            }
        }

    }
}