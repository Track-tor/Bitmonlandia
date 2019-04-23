﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Bitmonlandia
    {
        private Random random = new Random();

        private int seed; //atricuto que dicta la configuracion inicial del mapa y de los bitmons
        private Mapa mapa; //atributo que guarda el mapa actual de la simulacion del mundo bitmon
        private List<Bitmon> lista_bitmons_totales = new List<Bitmon>(); //lista con todos los bitmons presentes en el mapa (vivos y muertos)
        private int tiempo_Transcurrido = 0;
        private int hijos_ents = 0;

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
                    muertos++;
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
            string sigla = bitmon.GetNombre().Substring(0, 3);
            int x = bitmon.GetPosicion()[0];
            int y = bitmon.GetPosicion()[1];
            if (GetMapa().GetTablero()[x,y,1]=="   ")
            {
                mapa.SetBitmon(sigla, x, y, 1);
            }

            else if (GetMapa().GetTablero()[x, y, 2] == "   ")
            {
                mapa.SetBitmon(sigla, x, y, 2);
            }
        }

        //Funcion que posiciona los bitmons INICIALES
        public void PosicionInicialBitmons()
        {
            for (int bit =0; bit<lista_bitmons_totales.Count(); bit++)
            {
                string sigla = lista_bitmons_totales[bit].GetNombre().Substring(0, 3);
                int x = lista_bitmons_totales[bit].GetPosicion()[0];
                int y = lista_bitmons_totales[bit].GetPosicion()[1];
                mapa.SetBitmon(sigla, x, y, 1);
            }
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

        //Spawnear Ent
        public void PlantarEnt(int size)
        {
            int c1 = random.Next(size); // Asignacion de una coordenada aleatoria
            int c2 = random.Next(size); // Asignacion de una coordenada aleatoria
            int[] tupla = { c1, c2 };

            //Veo si el bitmon caera fuera de los limites del mapa:
            while (GetMapa().GetTablero()[c1, c2, 1] != "   " && GetMapa().GetTablero()[c1, c2, 2] != "   ")
            {
                c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                c2 = random.Next(size); // Asignacion de una coordenada aleatoria
            }

            //Estadisticas
            int pa = random.Next(10, 50);
            int pv = random.Next(10, 100);
            añadir_bitmon(new Ent("Ent", 15, pa, pv, tupla));
            hijos_ents += 1;

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
                float resultado = (float)(suma / cantidad_muertos);
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
                float resultado = (float)(suma / cantidad_muertos);
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
            float n_nacimientos = 0;
            float poblacion_total = 0;
            if (especie != "Ent")
            {
                for (int bit = 0; bit < GetLista().Count(); bit++)
                {
                    if (GetLista()[bit].GetEstadoDeVida() == true && GetLista()[bit].GetNombre() == especie)
                    {
                        poblacion_total += (float)GetLista()[bit].GetMesesVividos();
                        n_nacimientos += (float)GetLista()[bit].GetHijos();
                    }
                }
            }

            else
            {
                for (int bit = 0; bit < GetLista().Count(); bit++)
                {
                    if (GetLista()[bit].GetEstadoDeVida() == true && GetLista()[bit].GetNombre() == especie)
                    {
                        poblacion_total += (float)GetLista()[bit].GetMesesVividos();
                    }
                }
                n_nacimientos = hijos_ents;
            }


            if (n_nacimientos > 0 && poblacion_total>0)
            {
                float resultado = ((float)(n_nacimientos / poblacion_total))*1000;
                Console.WriteLine("Tasa bruta de natalidad {0}: {1}", especie, resultado);
            }

            else
            {
                Console.WriteLine("No hay un tasa bruta de nacimiento {0} ya que se ha extinguido la especia", especie);
            }

        }

        //Tasas de mortalidad de cada especie:
        public void TasaDeMortalidad(string especie)
        {
            float n_muertos = 0;
            float poblacion_total = GetLista().Count();
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == false && GetLista()[bit].GetNombre() == especie)
                {
                    n_muertos += 1;
                }
            }

            if (n_muertos > 0 && poblacion_total > 0)
            {
                float resultado = ((float)(n_muertos / poblacion_total))*100;
                Console.WriteLine("Tasa bruta de mortalidad {0}: {1}", especie, resultado);
            }

            else
            {
                Console.WriteLine("No hay un tasa bruta de mortalidad {0} ya que no ha muerto ninguno", especie);
            }
        }

        //Promedio de hijos por especie:
        public void HijosPromedioEspecie(string especie)
        {
            float n_nacimientos = 0;
            float poblacion_total = 0;
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetNombre() == especie)
                {
                    poblacion_total += (float)GetLista()[bit].GetMesesVividos();
                    n_nacimientos += (float)GetLista()[bit].GetHijos();
                }
            }

            if (n_nacimientos > 0 && poblacion_total > 0)
            {
                float resultado = ((float)(n_nacimientos / poblacion_total)) * 1000;
                Console.WriteLine("Cantidad de hijos promedio {0}: {1}", especie, resultado);
            }

            else
            {
                Console.WriteLine("No hay cantidad de hijos promedio {0} ya que ninguno ha tenido hijos", especie);
            }


        }

        //Listado especies extintas:
        public void GetEspeciesExtintas()
        {
            int n_tap = 0;
            int n_dor = 0;
            int n_dot = 0;
            int n_ent = 0;
            int n_gof = 0;
            int n_wet = 0;

            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == true)
                {
                    switch (GetLista()[bit].GetNombre())
                    {
                        case "Taplan":
                            n_tap += 1;
                            break;

                        case "Dorvalo":
                            n_dor += 1;
                            break;

                        case "Doti":
                            n_dot += 1;
                            break;

                        case "Ent":
                            n_ent += 1;
                            break;

                        case "Gofue":
                            n_gof += 1;
                            break;

                        case "Wetar":
                            n_wet += 1;
                            break;
                    }
                }
            }

            if (n_tap!=0 && n_dor!=0 && n_dot != 0 && n_ent != 0 && n_wet != 0 && n_gof != 0)
            {
                Console.WriteLine("No hay especies extintas");
            }

            else
            {
                Console.WriteLine("Lista de especies extintas:");
                if (n_tap == 0)
                {
                    Console.WriteLine("Taplan");
                }

                if (n_dor == 0)
                {
                    Console.WriteLine("Dorvalo");
                }

                if (n_dot == 0)
                {
                    Console.WriteLine("Doti");
                }

                if (n_ent == 0)
                {
                    Console.WriteLine("Ent");
                }

                if (n_gof == 0)
                {
                    Console.WriteLine("Gofue");
                }

                if (n_wet == 0)
                {
                    Console.WriteLine("Wetar");
                }
            }
        }
    }
}