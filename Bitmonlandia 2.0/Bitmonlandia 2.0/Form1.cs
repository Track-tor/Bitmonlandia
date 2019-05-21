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
    public partial class Form1 : Form
    {
        int seed = 0;
        int meses = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //Funcion para limpiar la pantalla
        private void PantallaNueva()
            {
                Controls.Clear();

                /*TableLayoutPanel tbp = new TableLayoutPanel();
                tbp.Location = new Point(341, 131);
                tbp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                tbp.ColumnCount = 2;
                tbp.RowCount = 2;
                tbp.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
                tbp.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
                tbp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                tbp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

                Panel p1 = new Panel();
                p1.BackColor = Color.Red;
                p1.Margin = new Padding(0, 0, 0, 0);

                Panel p2 = new Panel();
                p2.BackColor = Color.Green;
                p2.BorderStyle = BorderStyle.FixedSingle;
                p2.Margin = new Padding(0, 0, 0, 0);

                tbp.Controls.Add(p1, 0, 0);
                tbp.Controls.Add(p2, 0, 1);

                Controls.Add(tbp);*/
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
            lbl.Text = "Ingresa cantidad de meses a simular";
            lbl.Location = new Point(360,40);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.AutoSize = true;

            TextBox txb = new TextBox();
            txb.Name = "meses_ingresados";
            txb.Location = new Point(393, 71);

            Button but = new Button();
            but.Text = "OK";
            but.Location = new Point(393, 91);
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
