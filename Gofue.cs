﻿using System;
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
                while (estado_De_Vida == true && peleador.GetEstadoDeVida() == true)
                {
                    puntos_De_Vida -= peleador.GetPuntosDeAtaque();
                    peleador.RecibirAtaque(puntos_De_Ataque);
                    CambiarEstadoDeVida();
                    peleador.CambiarEstadoDeVida();
                }
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
                pareja.SetTiempoDeVida((pareja.GetTiempoDeVida() * 3) / 10);
                int c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                int c2 = random.Next(size); // Asignacion de una coordenada aleatoria
                int[] tupla = { c1, c2 };

                //Veo si el bitmon caera fuera de los limites del mapa:
                while (bitmonlandia.GetMapa().GetTablero()[c1, c2, 1] != "   ")
                {
                    c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                    c2 = random.Next(size); // Asignacion de una coordenada aleatoria
                }

                //Estadisticas
                int pa = random.Next(10, ((puntos_De_Ataque + pareja.GetPuntosDeAtaque()) / 2));
                int pv = random.Next(10, ((puntos_De_Vida + pareja.GetPuntosDeVida()) / 2));

                switch (pareja.GetNombre())
                {
                    case "Gofue":
                        bitmonlandia.añadir_bitmon(new Wetar("Gofue", 15, pa, pv, tupla));
                        break;

                    case "Dorvalo":
                        bitmonlandia.añadir_bitmon(new Taplan("Dorvalo", 20, pa, pv, tupla));
                        break;

                    case "Doti":
                        bitmonlandia.añadir_bitmon(new Dorvalo("Doti", 30, pa, pv, tupla));
                        break;
                }
                hijos += 1;
                pareja.SetHijos();

            }
        }
    }
}