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

            int seed = form1.GetSize();
            int meses = form1.GetMeses();
            Bitmonlandia bitmonlandia = new Bitmonlandia(seed);

            Form2 mapa = new Form2();
            Application.Run(mapa);
        }
    }
}
