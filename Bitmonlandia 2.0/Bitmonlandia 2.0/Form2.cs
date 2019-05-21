using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitmonlandia_2._0
{
    //5x5
    public partial class Form2 : Form
    {
        static Random random = new Random();
        private int seed;
        private int meses;
        private string[,,] tablero;
        public Form2(int seed, int meses)
        {
            InitializeComponent();
            this.seed = seed;
            this.meses = meses;
            Bitmonlandia bitmonlandia = new Bitmonlandia(seed);
            tablero = bitmonlandia.GetMapa().GetTablero();

            ////////////////////////////////////////
            //Se imprime el mapa antes de la simulacion
            ImprimirPrimeraVez();
        }

        //Funcion que se ocupa solo al principio, para imprimir los terrenos y los bitmons
        private void ImprimirPrimeraVez()
        {
            //Le agrego los territorios
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Panel p = new Panel();
                    p.Margin = new Padding(0, 0, 0, 0);

                    if (tablero[i, j, 0] == "L")
                    {
                        p.BackColor = Color.Red;
                    }

                    else if (tablero[i, j, 0] == "D")
                    {
                        p.BackColor = Color.Yellow;
                    }

                    else if (tablero[i, j, 0] == "V")
                    {
                        p.BackColor = Color.Green;
                    }

                    else if (tablero[i, j, 0] == "A")
                    {
                        p.BackColor = Color.DarkBlue;
                    }

                    else if (tablero[i, j, 0] == "N")
                    {
                        p.BackColor = Color.White;
                    }
                    tableLayoutPanel1.Controls.Add(p, j, i);
                }
            }
        }
    }
}
