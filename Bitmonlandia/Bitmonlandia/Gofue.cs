using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Gofue : Bitmon
    {
        //Tiempo de vida maximo segun esta especie = 15

        Random random = new Random();

        public Gofue(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }

        public override Bitmon Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Wetar"|| peleador.GetNombre() == "Taplan" || peleador.GetNombre() == "Ent")
            {
                string rival = peleador.GetNombre();
                int multiplicador = random.Next(10, 21);

                //Dependiendo del rival, los puntos de ataque del Bitmon cambian
                if (rival == "Wetar")
                {
                    puntos_De_Ataque += multiplicador;
                }

                else if (rival == "Ent")
                {
                    puntos_De_Ataque += 0;
                }

                else if (rival == "Taplan")
                {
                    puntos_De_Ataque -= multiplicador;
                }

                while (estado_De_Vida == true && peleador.GetEstadoDeVida() == true)
                {
                    puntos_De_Vida -= peleador.GetPuntosDeAtaque();
                    peleador.RecibirAtaque(puntos_De_Ataque);
                    CambiarEstadoDeVida();
                    peleador.CambiarEstadoDeVida();
                }
                SetGanador(estado_De_Vida);
                peleador.SetGanador(peleador.GetEstadoDeVida());
            }
            
            return base.Pelea(peleador);
        }

        /* Reproduccion de Bitmons consiste en que si la pareja es compatible, se instancia dentro de la lista de Bitmons 
        * un nuevo Bitmon de una especie aleatoria
       */
        
        public override void Reproduccion(Bitmon pareja, int size, Bitmonlandia bitmonlandia)
        {
            if (pareja.GetNombre() == "Gofue" || pareja.GetNombre() == "Dorvalo" || pareja.GetNombre() == "Doti")
            {
                tiempo_De_Vida += (tiempo_De_Vida * 3) / 10;
                pareja.SetTiempoDeVida(pareja.GetTiempoDeVida()+(pareja.GetTiempoDeVida() * 3) / 10);
                int c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                int c2 = random.Next(size); // Asignacion de una coordenada aleatoria

                Console.WriteLine("{0},{1}", c1, c2);
                //Veo si el bitmon caera fuera de los limites del mapa:
                while (bitmonlandia.GetMapa().GetTablero()[c1, c2, 1] != "   " && bitmonlandia.GetMapa().GetTablero()[c1, c2, 2] != "   ")
                {
                    c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                    Console.WriteLine("c1: {0}", c1);
                    c2 = random.Next(size); // Asignacion de una coordenada aleatoria
                    Console.WriteLine("c2: {0}", c2);
                    Console.WriteLine("");
                }

                int[] tupla = { c1, c2 };

                //Estadisticas
                int pa = random.Next(10, ((puntos_De_Ataque + pareja.GetPuntosDeAtaque()) / 2));
                int pv = random.Next(10, ((puntos_De_Vida + pareja.GetPuntosDeVida()) / 2));

                switch (pareja.GetNombre())
                {
                    case "Gofue":
                        bitmonlandia.añadir_bitmon(new Gofue("Gofue", 15, pa, pv, tupla));
                        break;

                    case "Dorvalo":
                        bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 20, pa, pv, tupla));
                        break;

                    case "Doti":
                        bitmonlandia.añadir_bitmon(new Doti("Doti", 30, pa, pv, tupla));
                        break;
                }
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
            else
            {
                tiempo_De_Vida -= 1;
            }
            meses_vividos += 1;
        }
    }
}
