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
            Form1 form1 = new Form1();
            Application.Run(form1);

            int seed = form1.GetSeed();
            int meses = form1.GetMeses();
            List<string> lista_palabras = new List<string>();
            List<List<string>> lista_listas_palabras = new List<List<string>>();

            if (seed == 1)
            {
                Form2 form2 = new Form2(seed, meses);
                Application.Run(form2);
                lista_palabras = form2.GetTextoResumen();
                lista_listas_palabras = form2.GetTextoResumenParte2();
            }

            /*else if (seed == 2)
            {
                Form3 form3 = new Form3(seed, meses);
                Application.Run(form3);
                lista_palabras = form3.GetTextoResumen();
                lista_listas_palabras = form2.GetTextoResumenParte2();
            }

            else if (seed == 3)
            {
                Form4 form4 = new Form4(seed, meses);
                Application.Run(form4);
                lista_palabras = form4.GetTextoResumen();
                lista_listas_palabras = form2.GetTextoResumenParte2();
            }*/

            ResumenGrafico resumen_grafico = new ResumenGrafico(lista_palabras, lista_listas_palabras);
            Application.Run(resumen_grafico);
        }
    }
}
