using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using View;
using Controllers;

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
            OpcionesIniciales OI = new OpcionesIniciales();
            Controller Cont = new Controller(OI);


            Application.Run(OI);

            Form form = Cont.GetForm();

            Application.Run(form);

            List<string> lista_palabras = new List<string>();
            List<List<string>> lista_listas_palabras = new List<List<string>>();

            lista_palabras = Cont.GetTextoResumen();
            lista_listas_palabras = Cont.GetTextoResumenParte2();

            ResumenGrafico resumen_grafico = new ResumenGrafico(lista_palabras, lista_listas_palabras);
            Application.Run(resumen_grafico);
        }
    }
}
