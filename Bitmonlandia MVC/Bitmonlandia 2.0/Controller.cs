using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Models;
using View;

namespace Controllers
{
    class Controller
    {
        OpcionesIniciales Op;
        Model M;
        Mapa5x5 view5 = null;
        Mapa10x10 view10 = null;
        Mapa15x15 view15 = null;

        int meses = 0;
        int seed;
        public Controller(OpcionesIniciales op)
        {
            Op = op;

            Op.Op1 += Opcion1;
            Op.Op2 += Opcion2;
            Op.Op3 += Opcion3;
        }

        public void Opcion1()
        {
            seed = 1;
            meses = Op.getmeses();
            M = new Model(seed,meses);
            view5 = new Mapa5x5();
            view5.On += avanzar;
            view5.Inicio += inicio;
        }

        public void Opcion2()
        {
            seed = 2;
            meses = Op.getmeses();
            M = new Model(seed, meses);
            view10 = new Mapa10x10();
            view10.Inicio += inicio;
            view10.On += avanzar;
        }

        public void Opcion3()
        {
            seed = 3;
            meses = Op.getmeses();
            M = new Model(seed, meses);
            view15 = new Mapa15x15();
            view15.Inicio += inicio;
            view15.On += avanzar;
        }

        public void avanzar()
        {
            if (M.GetMes() > meses)
            {
                if (seed == 1)
                {
                    view5.Close();
                }
                else if (seed == 2)
                {
                    view10.Close();
                }
                else if (seed == 3)
                {
                    view15.Close();
                }
            }
            else
            {
                M.Simulacion();
                if (seed == 1)
                {
                    view5.ImprimirTableroGrafico(M.GetTablero());
                    view5.EscribirEnElRegistro(M.GetRegistro(), M.GetMes());
                    if (M.GetTurno() % 2 == 1) view5.EscribirEnElRegistro("mes", M.GetMes());
                }
                else if (seed == 2)
                {
                    view10.ImprimirTableroGrafico(M.GetTablero());
                    view10.EscribirEnElRegistro(M.GetRegistro(), M.GetMes());
                    if (M.GetTurno() % 2 == 1) view10.EscribirEnElRegistro("mes", M.GetMes());
                }
                else if (seed == 3)
                {
                    view15.ImprimirTableroGrafico(M.GetTablero());
                    view15.EscribirEnElRegistro(M.GetRegistro(), M.GetMes());
                    if(M.GetTurno() % 2 == 1) view15.EscribirEnElRegistro("mes", M.GetMes());
                }
            }
        }

        public void inicio()
        {
            if (seed == 1)
            {
                view5.CrearTableroGrafico(M.GetTablero());
            }
            else if (seed == 2)
            {
                view10.CrearTableroGrafico(M.GetTablero());
            }
            else if (seed == 3)
            {
                view15.CrearTableroGrafico(M.GetTablero());
            }
        }

        public Form GetForm()
        {
            if (seed == 1)
            {
                return view5;
            }
            else if (seed == 2)
            {
                return view10;
            }
            else if (seed == 3)
            {
                return view15;
            }
            else return null;
        }

        public List<string> GetTextoResumen()
        {
            List<string> lista_palabras = new List<string>();

            //Empiezo a escribir en el archivo "resumen.txt"
            File.WriteAllText("resumen.txt", "\\\\\\\\\\\\Resumen de la simulacion\\\\\\\\\\\\\r\n");
            File.AppendAllText("resumen.txt", "\r\n");

            //Tiempo de vida promedio Bitmon:
            string text = M.GetBitmonlandia().TiempoDeVidaPromedioBitmon();
            lista_palabras.Add(text);
            File.AppendAllText("resumen.txt", "\r\n");

            ////////////////////////////////////////////
            //Tiempo de vida promedio de cada especie:
            File.AppendAllText("resumen.txt", "Tiempo de vida promedio de cada especie:\r\n");

            //Taplan
            text = M.GetBitmonlandia().TiempoDeVidaPromedioEspecie("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = M.GetBitmonlandia().TiempoDeVidaPromedioEspecie("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = M.GetBitmonlandia().TiempoDeVidaPromedioEspecie("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = M.GetBitmonlandia().TiempoDeVidaPromedioEspecie("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = M.GetBitmonlandia().TiempoDeVidaPromedioEspecie("Wetar");
            lista_palabras.Add(text);

            //Ent
            text = M.GetBitmonlandia().TiempoDeVidaPromedioEspecie("Ent");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            /////////////////////////////////////////////////////
            //Tasa de natalidad
            File.AppendAllText("resumen.txt", "Tasa de natalidad de cada especie:\r\n");

            //Taplan
            text = M.GetBitmonlandia().TasaDeNatalidad("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = M.GetBitmonlandia().TasaDeNatalidad("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = M.GetBitmonlandia().TasaDeNatalidad("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = M.GetBitmonlandia().TasaDeNatalidad("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = M.GetBitmonlandia().TasaDeNatalidad("Wetar");
            lista_palabras.Add(text);

            //Ent
            text = M.GetBitmonlandia().TasaDeNatalidad("Ent");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            ////////////////////////////////////////////////
            //Tasa de mortalidad de cada especie:
            File.AppendAllText("resumen.txt", "Tasa de mortalidad de cada especie:\r\n");
            //Taplan
            text = M.GetBitmonlandia().TasaDeMortalidad("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = M.GetBitmonlandia().TasaDeMortalidad("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = M.GetBitmonlandia().TasaDeMortalidad("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = M.GetBitmonlandia().TasaDeMortalidad("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = M.GetBitmonlandia().TasaDeMortalidad("Wetar");
            lista_palabras.Add(text);

            //Ent
            text = M.GetBitmonlandia().TasaDeMortalidad("Ent");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            /////////////////////////////////////////////////
            //Cantidad de hijos por especie
            File.AppendAllText("resumen.txt", "Cantidad de hijos promedio por especie:\r\n");

            //Taplan
            text = M.GetBitmonlandia().HijosPromedioEspecie("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = M.GetBitmonlandia().HijosPromedioEspecie("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = M.GetBitmonlandia().HijosPromedioEspecie("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = M.GetBitmonlandia().HijosPromedioEspecie("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = M.GetBitmonlandia().HijosPromedioEspecie("Wetar");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            return lista_palabras;
        }

        public List<List<string>> GetTextoResumenParte2()
        {
            List<List<string>> lista_palabras = new List<List<string>>();

            ////////////////////////////////////////////////
            //Listado de especies extintas:
            File.AppendAllText("resumen.txt", "Lista de especies extintas\r\n");
            List<string> lista_text =  M.GetBitmonlandia().GetEspeciesExtintas();
            lista_palabras.Add(lista_text);

            File.AppendAllText("resumen.txt", "\r\n");

            ///////////////////////////////////////////
            //Bithalla:
            File.AppendAllText("resumen.txt", "Bithalla:\r\n");
            lista_text=  M.GetBitmonlandia().Bithalla();
            lista_palabras.Add(lista_text);

            File.AppendAllText("resumen.txt", "\r\n");

            return lista_palabras;
        }
    }
}
