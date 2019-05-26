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

namespace Bitmonlandia_2._0
{
    public partial class OpcionesIniciales : Form
    {
        int seed = 0;
        int meses = 0;

        public OpcionesIniciales()
        {
            InitializeComponent();
            Bitmap fondo = new Bitmap(Application.StartupPath + @"\Fondo\fondo2.jpg");
            this.BackgroundImage = fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(150,50);
            label1.BackColor = Color.Transparent;
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
                    meses = int.Parse(c.Text);
                }
            }
            PantallaNueva();
            Close();
            
        }

        //Agrego un textbox para que ingrese los meses a simular
        public void IngresarMeses()
        {
            Label lbl = new Label();
            lbl.Font = new Font("Impact", 20);
            lbl.BackColor = Color.Transparent;
            lbl.Anchor = AnchorStyles.None;
            lbl.Text = "Ingresa cantidad de meses a simular";
            lbl.Location = new Point(350, 50);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.AutoSize = true;

            TextBox txb = new TextBox(); 
            txb.Font = new Font("Impact", 12);
            txb.Anchor = AnchorStyles.None;
            txb.Name = "meses_ingresados";
            txb.Location = new Point(500, 100);

            Button but = new Button();
            but.Font = new Font("Impact", 10);
            but.Text = "OK";
            but.Location = new Point(480, 290);
            but.Click += ReadLineMeses;



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
    }
}
