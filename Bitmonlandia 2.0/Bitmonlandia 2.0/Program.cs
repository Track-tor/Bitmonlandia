using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitmonlandia_2._0
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpcionesIniciales form1 = new OpcionesIniciales();
            Application.Run(form1);

            int seed = form1.GetSeed();
            int meses = form1.GetMeses();
            List<string> lista_palabras = new List<string>();
            List<List<string>> lista_listas_palabras = new List<List<string>>();

            if (seed == 1)
            {
                Mapa5x5 mapa5x5 = new Mapa5x5(seed, meses);
                Application.Run(mapa5x5);
                lista_palabras = mapa5x5.GetTextoResumen();
                lista_listas_palabras = mapa5x5.GetTextoResumenParte2();
            }

            else if (seed == 2)
            {
                Mapa10x10 mapa10x10 = new Mapa10x10(seed, meses);
                Application.Run(mapa10x10);
                lista_palabras = mapa10x10.GetTextoResumen();
                lista_listas_palabras = mapa10x10.GetTextoResumenParte2();
            }

            else if (seed == 3)
            {
                Mapa15x15 mapa15x15 = new Mapa15x15(seed, meses);
                Application.Run(mapa15x15);
                lista_palabras = mapa15x15.GetTextoResumen();
                lista_listas_palabras = mapa15x15.GetTextoResumenParte2();
            }

            ResumenGrafico resumen_grafico = new ResumenGrafico(lista_palabras, lista_listas_palabras);
            Application.Run(resumen_grafico);
        }
    }
}
