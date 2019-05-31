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

namespace Bitmonlandia_2._0
{
    public partial class OpcionesIniciales : Form
    {

        //codigo para cargar la fuente a utilizar en el programa
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont
            ,IntPtr pdv,[In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        int seed = 0;
        int meses = 0;

        public OpcionesIniciales()
        {
            InitializeComponent();
            Bitmap fondo = new Bitmap(Application.StartupPath + @"\Fondo\b1.png");
            this.BackgroundImage = fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
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
        private  void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(ff, size, fontStyle);
        }


        //Funcion para limpiar la pantalla
        private void PantallaNueva()
        {
                Controls.Clear();
        }

        //Opciones de mapa
        private void click_MAPA_5X5(object sender, EventArgs e)
        {
            seed = 1;
            PantallaNueva();
            IngresarMeses();
        }

        private void click_MAPA_10x10(object sender, EventArgs e)
        {
            seed = 2;
            PantallaNueva();
            IngresarMeses();
        }

        private void click_MAPA_15x15(object sender, EventArgs e)
        {
            seed = 3;
            PantallaNueva();
            IngresarMeses();
        }
        ////////////////////////////////////////////////////////////////////////
        //Leer el texto ingresado (como un readline)
        private void ReadLineMeses(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if (c.Name == "meses_ingresados")
                {
                    try
                    {
                        meses = int.Parse(c.Text);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            PantallaNueva();
            Close();
            
        }

        //Agrego un textbox para que ingrese los meses a simular
        public void IngresarMeses()
        {
            Label lbl = new Label();
            lbl.BackColor = Color.Transparent;
            lbl.Anchor = AnchorStyles.None;
            lbl.Text = "Ingresa cantidad de meses a simular";
            lbl.Location = new Point(250, 50);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.AutoSize = true;

            TextBox txb = new TextBox(); 
            txb.Anchor = AnchorStyles.None;
            txb.Name = "meses_ingresados";
            txb.Location = new Point(465, 100);

            Button but = new Button();
            but.Text = "OK";
            but.Location = new Point(475, 290);
            but.Click += ReadLineMeses;

            LoadFont();
            AllocFont(font, lbl, 20);
            AllocFont(font, txb, 12);
            AllocFont(font, but, 10);

            Controls.Add(lbl);
            Controls.Add(txb);
            Controls.Add(but);
        }
        //////////////////////////////////////////////
        //Getters
        public int GetSeed()
        {
            return seed;
        }

        public int GetMeses()
        {
            return meses;
        }

        private void OpcionesIniciales_Load(object sender, EventArgs e)
        {
            LoadFont();
            AllocFont(font, this.button1, 20);
            AllocFont(font, this.button2, 20);
            AllocFont(font, this.button3, 20);
        }
    }
}
