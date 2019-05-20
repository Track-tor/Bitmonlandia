using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia_2._0
{
    class Doti:Bitmon
    {
        //Tiempo de vida maximo segun esta especie = 30

        Random random = new Random();

        public Doti(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }

        /* Reproduccion de Bitmons consiste en que si la pareja es compatible, se instancia dentro de la lista de Bitmons 
        * un nuevo Bitmon de una especie aleatoria
       */
        public override void Reproduccion(Bitmon pareja, int size, Bitmonlandia bitmonlandia)
        {
            if (pareja.GetNombre() != "Ent")
            {

                tiempo_De_Vida += (tiempo_De_Vida * 3) / 10;
                pareja.SetTiempoDeVida(pareja.GetTiempoDeVida() + (pareja.GetTiempoDeVida() * 3) / 10);
                int c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                int c2 = random.Next(size); // Asignacion de una coordenada aleatoria

                //Veo si el bitmon caera fuera de los limites del mapa:
                int cont_de_escape = 0;
                while (bitmonlandia.GetMapa().GetTablero()[c1, c2, 1] != "   " && bitmonlandia.GetMapa().GetTablero()[c1, c2, 2] != "   ")
                {

                    //condicion de escape
                    if (cont_de_escape > 20)
                        return;
                    c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                    c2 = random.Next(size); // Asignacion de una coordenada aleatoria
                    cont_de_escape++;
                }

                int[] tupla = { c1, c2 };

                //Estadisticas
                int pa = random.Next(10, ((puntos_De_Ataque + pareja.GetPuntosDeAtaque()) / 2));
                int pv = random.Next(10, ((puntos_De_Vida + pareja.GetPuntosDeVida()) / 2));

                //Veamos la cantidad de hijos que han tenido ambos
                int hijos_padre = hijos;
                int hijos_pareja = pareja.GetHijos();
                string especie_hijo = "";

                int probabilidad = random.Next(0, 101);

                if (hijos_padre > hijos_pareja)
                {
                    if (probabilidad <= 70)
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }

                    else
                    {
                        especie_hijo = pareja.GetNombre();
                    }
                }

                else if (hijos_padre < hijos_pareja)
                {
                    if (probabilidad <= 70)
                    {
                        especie_hijo = pareja.GetNombre();
                    }

                    else
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }
                }

                else
                {
                    if (probabilidad <= 50)
                    {
                        especie_hijo = pareja.GetNombre();
                    }

                    else
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }
                }

                switch (especie_hijo)
                {
                    case "Taplan":
                        bitmonlandia.añadir_bitmon(new Taplan("Taplan", 50, pa, pv, tupla));
                        break;

                    case "Dorvalo":
                        bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 20, pa, pv, tupla));
                        break;

                    case "Gofue":
                        bitmonlandia.añadir_bitmon(new Gofue("Gofue", 15, pa, pv, tupla));
                        break;

                    case "Wetar":
                        bitmonlandia.añadir_bitmon(new Wetar("Wetar", 40, pa, pv, tupla));
                        break;

                    case "Doti":
                        bitmonlandia.añadir_bitmon(new Doti("Doti", 30, pa, pv, tupla));
                        break;
                }
                Console.WriteLine("Ha nacido un {0}", especie_hijo);
                hijos += 1;
                pareja.SetHijos();
            }
        }

        // Reduce el tiempo de vida del Bitmon dependiendo de el terreno en donde se encuentre
        public override void Envejecer(Mapa mapa)
        {
            int x = GetPosicion()[0];
            int y = GetPosicion()[1];
            string[,,] tablero = mapa.GetTablero();
            terreno = tablero[x, y, 0];

            if (terreno == "A")
            {
                tiempo_De_Vida -= 2;
            }
            else if (terreno == "L")
            {
                tiempo_De_Vida -= 2;
            }
            else
            {
                tiempo_De_Vida -= 1;
            }
            meses_vividos += 1;
        }
    }
}
