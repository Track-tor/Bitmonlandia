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
        float n_nacimientos = 0;

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

        //Agregar en un mes cada vez que esta funcion es llamada
        public void SetTiempoTranscurrido()
        {
            tiempo_Transcurrido += 1;
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

        //Tiempo de vida promedio Bitmon:
        public void TiempoDeVidaPromedioBitmon()
        {
            float suma = 0;
            float cantidad_muertos = 0;
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == false)
                {
                    suma += (float) GetLista()[bit].GetMesesVividos();
                    cantidad_muertos += 1;
                }
            }

            if (cantidad_muertos> 0)
            {
                int resultado = (int)(suma / cantidad_muertos);
                Console.WriteLine("Tiempo de vida promedio Bitmon: {0} meses", resultado);
            }

            else
            {
                Console.WriteLine("No hay un tiempo de vida promedio Bitmon ya que no han habido muertos");
            }
        }

        //Tiempo de vida promedio de cada especie:
        public void TiempoDeVidaPromedioEspecie(string especie)
        {
            float suma = 0;
            float cantidad_muertos = 0;
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == false && GetLista()[bit].GetNombre()==especie)
                {
                    suma += (float)GetLista()[bit].GetMesesVividos();
                    cantidad_muertos += 1;
                }
            }

            if (cantidad_muertos > 0)
            {
                int resultado = (int)(suma / cantidad_muertos);
                Console.WriteLine("Tiempo de vida promedio {0}: {1} meses", especie, resultado);
            }

            else
            {
                Console.WriteLine("No hay un tiempo de vida promedio {0} ya que no han habido {1}s muertos", especie, especie);
            }
        }

        //Tasas de natalidad de cada especie:
        public void TasaDeNatalidad(string especie)
        {
            float poblacion_total = 0;
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == true && GetLista()[bit].GetNombre() == especie)
                {
                    poblacion_total += (float)GetLista()[bit].GetMesesVividos();
                }
            }
        }

        //Tasas de mortalidad de cada especie:
        public void TasaDeMortalidad()
        {

        }






    }
}