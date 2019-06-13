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
    //10x10
    public partial class Form3 : Form
    {
        static Random random = new Random();
        private int seed;
        private int meses;
        private string[,,] tablero;
        public Form3(int seed, int meses)
        {
            this.seed = seed;
            this.meses = meses;
            Bitmonlandia bitmonlandia = new Bitmonlandia(seed);
            tablero = bitmonlandia.GetMapa().GetTablero();

            ///////////////////////////////////////
            //Creo el tablelayoutpanel
            TableLayoutPanel tbp = new TableLayoutPanel();
            tbp.Location = new Point(141, 31);
            tbp.Anchor = AnchorStyles.None;
            tbp.Size = new Size(200 * seed, 200 * seed);
            tbp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tbp.ColumnCount = 10;
            tbp.RowCount = 10;
            //Le agrego las fila y columnas al tablelayoutpanel
            for (int i = 0; i < 5 * seed; i++)
            {
                tbp.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
                tbp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }
            ////////////////////////////////////////
            //Se imprime el mapa antes de la simulacion
            ImprimirPrimeraVez(tbp);
            InitializeComponent();
        }

        //Funcion que se ocupa solo al principio, para imprimir los terrenos y los bitmons
        private void ImprimirPrimeraVez(TableLayoutPanel tbp)
        {
            //Le agrego los territorios
            for (int i = 0; i < 5 * seed; i++)
            {
                for (int j = 0; j < 5 * seed; j++)
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
                    //Si hay un bitmon agregarle la fto de bitmon
                    if (tablero[i, j, 1] == "Dor")
                    {
                        PictureBox picture = new PictureBox();
                        picture.Image = Image.FromFile("Dorvalo.png");
                        picture.Dock = DockStyle.Fill;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        p.Controls.Add(picture);
                    }

                    else if (tablero[i, j, 1] == "Tap")
                    {
                        PictureBox picture = new PictureBox();
                        picture.Image = Image.FromFile("Taplan.png");
                        picture.Dock = DockStyle.Fill;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        p.Controls.Add(picture);
                    }

                    else if (tablero[i, j, 1] == "Gof")
                    {
                        PictureBox picture = new PictureBox();
                        picture.Image = Image.FromFile("Gofue.png");
                        picture.Dock = DockStyle.Fill;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        p.Controls.Add(picture);
                    }

                    else if (tablero[i, j, 1] == "Wet")
                    {
                        PictureBox picture = new PictureBox();
                        picture.Image = Image.FromFile("Wetar.png");
                        picture.Dock = DockStyle.Fill;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        p.Controls.Add(picture);
                    }

                    else if (tablero[i, j, 1] == "Dot")
                    {
                        PictureBox picture = new PictureBox();
                        picture.Image = Image.FromFile("Doti.png");
                        picture.Dock = DockStyle.Fill;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        p.Controls.Add(picture);
                    }

                    else if (tablero[i, j, 1] == "Ent")
                    {
                        PictureBox picture = new PictureBox();
                        picture.Image = Image.FromFile("Ent.png");
                        picture.Dock = DockStyle.Fill;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        p.Controls.Add(picture);
                    }

                    tbp.Controls.Add(p, j, i);
                }
            }
            Controls.Add(tbp);
        }
    }
}
