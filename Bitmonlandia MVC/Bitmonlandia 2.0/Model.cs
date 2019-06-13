using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Model
    {
        static Random random = new Random();
        private int turno = 0;
        private int seed;
        private int mes_contador = 1;
        private int meses_a_simular;
        Bitmonlandia bitmonlandia;
        private string[,,] tablero;
        string registro = "";

        public Model(int seed, int m)
        {
            this.seed = seed;
            this.meses_a_simular = m;
            bitmonlandia = new Bitmonlandia(seed);
            tablero = bitmonlandia.GetMapa().GetTablero();
        }

        public void Simulacion()
        {
            registro = "";
            //Verficamos si termino la simulacion
            if (mes_contador > meses_a_simular)
            {
                return ;
            }

            if (turno % 2 == 0)
            {
                //ciclo for para que los bitmons se muevan
                for (int bit = 0; bit < bitmonlandia.GetLista().Count; bit++)
                {
                    //vemos si es que el bitmon no esta muerto
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    string especie = bitmonlandia.GetLista()[bit].GetNombre();

                    //Movimiento:
                    if (especie != "Ent")
                    {
                        bitmonlandia.GetLista()[bit].Movimiento(bitmonlandia.GetMapa());
                    }
                }

                
                turno++;
            }

            else if (turno % 2 == 1)
            {
                //Se recorre la lista de bitmons para ver si hay bitmons en la misma casilla
                for (int bit = 0; bit < bitmonlandia.GetLista().Count; bit++)
                {
                    // vemos si es que el bitmon no esta muerto
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    //Selecciono el primer bitmon y veo su especie tambien:
                    string especie = bitmonlandia.GetLista()[bit].GetNombre();


                    //Y recorro la lista en busca de una coincidencia
                    for (int pareja = bit + 1; pareja < bitmonlandia.GetLista().Count; pareja++)
                    {
                        if (bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == false)
                        {
                            continue;
                        }

                        if (bitmonlandia.GetLista()[bit].GetPosicion()[0] == bitmonlandia.GetLista()[pareja].GetPosicion()[0] && bitmonlandia.GetLista()[bit].GetPosicion()[1] == bitmonlandia.GetLista()[pareja].GetPosicion()[1
                            ])
                        {
                            //Primero intentamos con pelea
                            bitmonlandia.GetLista()[bit].Pelea(bitmonlandia.GetLista()[pareja]);
                            registro += String.Format("{0} peleó con {1}\n", bitmonlandia.GetLista()[bit].GetNombre(), bitmonlandia.GetLista()[pareja].GetNombre());

                            //Si no funciona, significa que se llevan bien para reproducirse
                            if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == true && bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == true)
                            {
                                int prob = random.Next(101);
                                if (prob <= 15)
                                {//probabilidad del 15% de reproducirse
                                    registro = String.Format("{0} se reprodujo con {1}\n", bitmonlandia.GetLista()[bit].GetNombre(), bitmonlandia.GetLista()[pareja].GetNombre());
                                    bitmonlandia.GetLista()[bit].Reproduccion(bitmonlandia.GetLista()[pareja], seed, bitmonlandia);
                                }
                            }
                        }




                        if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                        {
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[bit].GetPosicion()[0], bitmonlandia.GetLista()[bit].GetPosicion()[1], bitmonlandia.GetLista()[bit].GetCelda());
                            bitmonlandia.GetLista()[bit].LimpiarCadaver();
                        }

                        if (bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == false)
                        {
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[pareja].GetPosicion()[0], bitmonlandia.GetLista()[pareja].GetPosicion()[1], bitmonlandia.GetLista()[pareja].GetCelda());
                            bitmonlandia.GetLista()[pareja].LimpiarCadaver();
                        }

                    }

                    /*Comprobamos si sigue vivo este bitmon, para asi saber si moverlo y cambiar el terreno
                        * si corresponde*/
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    //Ahora que sabemos que esta vivo cambiamos el terreno si corresponde
                    //Transformar terreno:
                    if (especie == "Gofue")
                    {
                        bitmonlandia.GetLista()[bit].Secar(bitmonlandia.GetMapa());
                    }

                    else if (especie == "Taplan")
                    {
                        bitmonlandia.GetLista()[bit].Plantar(bitmonlandia.GetMapa());
                    }

                    //Si sigue vivo despues de todo, hacerlo envejecer
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == true)
                    {
                        bitmonlandia.GetLista()[bit].Envejecer(bitmonlandia.GetMapa());
                    }
                }

                //Si han pasado 3 meses y algun Ent sigue vivo, spawnear uno
                if (mes_contador % 3 == 0 && mes_contador != 0)
                {
                    bitmonlandia.PlantarEnt(seed);
                }

                mes_contador++;
                turno++;
            }
        }

        public string[,,] GetTablero()
        {
            return tablero;
        }

        public string GetRegistro()
        {
            return registro;
        }

        public int GetMes()
        {
            return mes_contador;
        }

        public Bitmonlandia GetBitmonlandia()
        {
            return bitmonlandia;
        }

        public int GetTurno()
        {
            return turno;
        }
    }
}
