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
    public partial class ResumenGrafico : Form
    {
        public ResumenGrafico(List<string> lista_strings, List<List<string>> lista_listas_strings)
        {
            InitializeComponent();

            //Tasa de vida promedio bitmon
            t_v_p_bitmon.Text = lista_strings[0];

            //Tasa de vida promedio por especie
            t_v_p_taplan.Text = lista_strings[1];
            t_v_p_dorvalo.Text = lista_strings[2];
            t_v_p_gofue.Text = lista_strings[3];
            t_v_p_doti.Text = lista_strings[4];
            t_v_p_wetar.Text = lista_strings[5];
            t_v_p_ent.Text = lista_strings[6];

            //Tasa de natalidad
            t_n_taplan.Text = lista_strings[7];
            t_n_dorvalo.Text = lista_strings[8];
            t_n_gofue.Text = lista_strings[9];
            t_n_doti.Text = lista_strings[10];
            t_n_wetar.Text = lista_strings[11];
            t_n_ent.Text = lista_strings[12];

            //Tasa de mortalidad
            t_m_taplan.Text = lista_strings[13];
            t_m_dorvalo.Text = lista_strings[14];
            t_m_gofue.Text = lista_strings[15];
            t_m_doti.Text = lista_strings[16];
            t_m_wetar.Text = lista_strings[17];
            t_m_ent.Text = lista_strings[18];

            //Hijos Promedio
            h_p_taplan.Text = lista_strings[19];
            h_p_dorvalo.Text = lista_strings[20];
            h_p_gofue.Text = lista_strings[21];
            h_p_doti.Text = lista_strings[22];
            h_p_wetar.Text = lista_strings[23];

            //Bithalla
            if (lista_listas_strings[1].Count() >1) {
                b_taplan.Text = lista_listas_strings[1][0];
                b_dorvalo.Text = lista_listas_strings[1][1];
                b_gofue.Text = lista_listas_strings[1][2];
                b_doti.Text = lista_listas_strings[1][3];
                b_wetar.Text = lista_listas_strings[1][4];
                b_ent.Text = lista_listas_strings[1][5];
            }

            else
            {
                b_taplan.Text = lista_listas_strings[1][0];
                b_dorvalo.Text = "";
                b_gofue.Text = "";
                b_doti.Text = "";
                b_wetar.Text = "";
                b_ent.Text = "";
            }

            //Especies Extintas
            int contador_especies_extintas = lista_listas_strings[0].Count();
            for (int i=0; i< contador_especies_extintas; i++)
            {
                Label l = new Label();
                l.Font = new Font("Microsoft Sans Serif", 10F);
                l.Size = new Size(357, 30);
                l.Text = lista_listas_strings[0][i];
                especies_extintas.Controls.Add(l);
            }

        }
    }
}
