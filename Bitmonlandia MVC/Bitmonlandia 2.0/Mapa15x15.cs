using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace View
{
    //15x15
    public partial class Mapa15x15 : Form
    {
        //codigo para cargar la fuente a utilizar en el programa
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont
            , IntPtr pdv, [In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        public event Action Inicio;
        public event Action On;

        public Mapa15x15()
        {
            InitializeComponent();

            //Se le coloca fondo al forms con el mapa 15x15
            Bitmap fondo = new Bitmap(Application.StartupPath + @"\Fondo\b1.png");
            this.BackgroundImage = fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        //Funcion para limpiar la pantalla
        private void PantallaNueva()
        {
            Controls.Clear();
        }

        //Funcion que se ocupa solo al principio, para crear e imprimir los terrenos graficamente
        public void CrearTableroGrafico(string[,,] tablero)
        {
            //Le agrego los territorios
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Panel p = new Panel();
                    p.Margin = new Padding(0, 0, 0, 0);
                    p.Dock = DockStyle.Fill;
                    p.BackgroundImageLayout = ImageLayout.Stretch;
                    if (tablero[i, j, 0] == "L")
                    {
                        p.BackgroundImage = Image.FromFile("lava.png");

                    }

                    else if (tablero[i, j, 0] == "D")
                    {
                        p.BackgroundImage = Image.FromFile("arena.jpg");
                    }

                    else if (tablero[i, j, 0] == "V")
                    {
                        p.BackgroundImage = Image.FromFile("pasto.jpg");
                    }

                    else if (tablero[i, j, 0] == "A")
                    {
                        p.BackgroundImage = Image.FromFile("agua.png");
                    }

                    else if (tablero[i, j, 0] == "N")
                    {
                        p.BackgroundImage = Image.FromFile("nieve.jpg");
                    }

                    int size_celda = tableLayoutPanel1.GetColumnWidths()[0];
                    //Creo las dos casilla de fotos para los bitmons en una celda
                    PictureBox fto1 = new PictureBox();
                    fto1.Size = new Size(size_celda / 2, size_celda);
                    fto1.SizeMode = PictureBoxSizeMode.Zoom;
                    fto1.Location = new Point(0, 0);
                    fto1.BackColor = Color.Transparent;
                    p.Controls.Add(fto1);

                    PictureBox fto2 = new PictureBox();
                    fto2.Size = new Size(size_celda / 2, size_celda);
                    fto2.Location = new Point(fto1.Width, 0);
                    fto2.SizeMode = PictureBoxSizeMode.Zoom;
                    fto2.BackColor = Color.Transparent;
                    p.Controls.Add(fto2);

                    //Añado bitmons si es que estan en la casilla 1
                    if (tablero[i, j, 1] == "Dor")
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

        //Funcion que cambia el tablero grafico de acuerdo a la simulacion
        public void ImprimirTableroGrafico(string[,,] tablero)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    //Selecciono el control de la celda
                    Control c = tableLayoutPanel1.GetControlFromPosition(j, i);
                    Panel p;

                    //Verifico que el control sea el panel de la celda
                    while (true)
                    {
                        try
                        {
                            p = (Panel)c;
                            break;
                        }
                        catch { };
                    }

                    //Cambio el color de la celda de acuerdo al territorio
                    if (tablero[i, j, 0] == "L")
                    {
                        p.BackgroundImage = Image.FromFile("lava.png");

                    }

                    else if (tablero[i, j, 0] == "D")
                    {
                        p.BackgroundImage = Image.FromFile("arena.jpg");
                    }

                    else if (tablero[i, j, 0] == "V")
                    {
                        p.BackgroundImage = Image.FromFile("pasto.jpg");
                    }

                    else if (tablero[i, j, 0] == "A")
                    {
                        p.BackgroundImage = Image.FromFile("agua.png");
                    }

                    else if (tablero[i, j, 0] == "N")
                    {
                        p.BackgroundImage = Image.FromFile("nieve.jpg");
                    }
                    //Agrego bitmons a las casillas si es que estan
                    int casilla = 1;
                    foreach (PictureBox fto in p.Controls)
                    {
                        if (tablero[i, j, casilla] == "   ")
                        {
                            fto.Image = null;
                        }

                        else if (tablero[i, j, casilla] == "Dor")
                        {
                            fto.Image = Image.FromFile("Dorvalo.png");
                        }

                        else if (tablero[i, j, casilla] == "Wet")
                        {
                            fto.Image = Image.FromFile("Wetar.png");
                        }

                        else if (tablero[i, j, casilla] == "Gof")
                        {
                            fto.Image = Image.FromFile("Gofue.png");
                        }

                        else if (tablero[i, j, casilla] == "Ent")
                        {
                            fto.Image = Image.FromFile("Ent.png");
                        }

                        else if (tablero[i, j, casilla] == "Dot")
                        {
                            fto.Image = Image.FromFile("Doti.png");
                        }

                        else if (tablero[i, j, casilla] == "Tap")
                        {
                            fto.Image = Image.FromFile("Taplan.png");
                        }
                        casilla++;
                    }
                }
            }
        }

        //Funcion para escribir en el cuadro registro eventos que sucedan en el juego
        public void EscribirEnElRegistro(string orden, int mes_contador)
        {
            Label l = new Label();
            l.BackColor = Color.Transparent;
            l.AutoSize = true;
            l.Size = new Size(235, 13);
            l.Text = orden;

            if (orden == "")
            {
                return;
            }

            else if (orden == "mes")
            {
                Label espacio = new Label();
                espacio.BackColor = Color.Transparent;
                espacio.AutoSize = false;
                espacio.Size = new Size(235, 13);
                espacio.Text = "--------------------------------------------------------------------------";
                Cuadro_Registro.Controls.Add(espacio);

                l.Text = String.Format("Mes {0}", mes_contador);
            }

            //////////////
            //Veo si el cuadro registro esta lleno para vaciarlo
            if (Cuadro_Registro.Controls.Count > 40)
            {
                while (Cuadro_Registro.Controls.Count > 1)
                {
                    if (Cuadro_Registro.Controls[1].Name != "Registro_titulo")
                    {
                        Cuadro_Registro.Controls[1].Dispose();
                    }
                }
            }

            Cuadro_Registro.Controls.Add(l);
        }

        //funcion que carga la fuente a utilizar en el programa
        private void LoadFont()
        {
            byte[] fontArray = Bitmonlandia_2._0.Properties.Resources.Diary_of_an_8_bit_mage;
            int dataLenght = Bitmonlandia_2._0.Properties.Resources.Diary_of_an_8_bit_mage.Length;

            IntPtr ptrdata = Marshal.AllocCoTaskMem(dataLenght);

            Marshal.Copy(fontArray, 0, ptrdata, dataLenght);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrdata, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrdata, dataLenght);

            Marshal.FreeCoTaskMem(ptrdata);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);
        }

        //funcion que le hace alloc a la font
        private void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(ff, size, fontStyle);
        }

        private void Mapa15x15_Load(object sender, EventArgs e)
        {
            LoadFont();
            AllocFont(font, this.Boton_Mes, 20);
            AllocFont(font, this.Registro_titulo, 20);
            AllocFont(font, this.Cuadro_Registro, 8);
            if (Inicio != null) Inicio();
        }

        private void Boton_Mes_Click(object sender, EventArgs e)
        {
            if (On != null) On();
        }
    }
}
