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
            CrearTableroGrafico();
        }

        //Funcion que se ocupa solo al principio, para crear e imprimir los terrenos graficamente
        private void CrearTableroGrafico()
        {
            //Le agrego los territorios
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Panel p = new Panel();
                    p.Margin = new Padding(0, 0, 0, 0);
                    p.Dock = DockStyle.Fill; 

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

                    //Creo las dos casilla de fotos para los bitmons en una celda
                    PictureBox fto1 = new PictureBox();
                    fto1.SizeMode = PictureBoxSizeMode.Zoom;
                    p.Controls.Add(fto1);

                    PictureBox fto2 = new PictureBox();
                    fto2.Location = new Point(0, fto1.Height);
                    fto2.SizeMode = PictureBoxSizeMode.Zoom;
                    p.Controls.Add(fto2);

                    //Añado bitmons si es que estan en la casilla 1
                    if(tablero[i,j,1] == "Dor")
                    {
                        fto1.Image = Image.FromFile("Dorvalo.png");
                    }

                    else if (tablero[i, j, 1] == "Wet")
                    {
                        fto1.Image = Image.FromFile("Wetar.png");
                    }

                    else if (tablero[i, j, 1] == "Gof")
                    {
                        fto1.Image = Image.FromFile("Gofue.png");
                    }

                    else if (tablero[i, j, 1] == "Ent")
                    {
                        fto1.Image = Image.FromFile("Ent.png");
                    }

                    else if (tablero[i, j, 1] == "Dot")
                    {
                        fto1.Image = Image.FromFile("Doti.png");
                    }

                    else if (tablero[i, j, 1] == "Tap")
                    {
                        fto1.Image = Image.FromFile("Taplan.png");
                    }

                    //Hago lo mismo par la casilla 2
                    if (tablero[i, j, 2] == "Dor")
                    {
                        fto2.Image = Image.FromFile("Dorvalo.png");
                    }

                    else if (tablero[i, j, 2] == "Wet")
                    {
                        fto2.Image = Image.FromFile("Wetar.png");
                    }

                    else if (tablero[i, j, 2] == "Gof")
                    {
                        fto2.Image = Image.FromFile("Gofue.png");
                    }

                    else if (tablero[i, j, 2] == "Ent")
                    {
                        fto2.Image = Image.FromFile("Ent.png");
                    }

                    else if (tablero[i, j, 2] == "Dot")
                    {
                        fto2.Image = Image.FromFile("Doti.png");
                    }

                    else if (tablero[i, j, 2] == "Tap")
                    {
                        fto2.Image = Image.FromFile("Taplan.png");
                    }

                    tableLayoutPanel1.Controls.Add(p, j, i);
                }
            }
        }

        //Funcion queavanza el mes y mueve los bitmons y demás
        private void AvanzarMes()
        {

        }
    }
}
