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
    //15x15
    public partial class Mapa15x15 : Form
    {

        //codigo para cargar la fuente a utilizar en el programa
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont
            , IntPtr pdv, [In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        static Random random = new Random();
        private int turno = 0;
        private int seed;
        private int mes_contador = 1;
        private int meses_a_simular;
        Bitmonlandia bitmonlandia;
        private string[,,] tablero;
        public Mapa15x15(int seed, int m)
        {
            InitializeComponent();
            this.seed = seed;
            this.meses_a_simular = m;
            bitmonlandia = new Bitmonlandia(seed);
            tablero = bitmonlandia.GetMapa().GetTablero();
            //Se le coloca fondo al forms con el mapa 15x15
            Bitmap fondo = new Bitmap(Application.StartupPath + @"\Fondo\b1.png");
            this.BackgroundImage = fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            ////////////////////////////////////////
            //Se imprime el mapa antes de la simulacion
            CrearTableroGrafico();
        }

        //Funcion para limpiar la pantalla
        private void PantallaNueva()
        {
            Controls.Clear();
        }

        //Funcion que se ocupa solo al principio, para crear e imprimir los terrenos graficamente
        private void CrearTableroGrafico()
        {
            //Le agrego los territorios
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
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

                    int size_celda = tableLayoutPanel1.GetColumnWidths()[0];
                    //Creo las dos casilla de fotos para los bitmons en una celda
                    PictureBox fto1 = new PictureBox();
                    fto1.Size = new Size(size_celda / 2, size_celda);
                    fto1.SizeMode = PictureBoxSizeMode.Zoom;
                    fto1.Location = new Point(0, 0);
                    p.Controls.Add(fto1);

                    PictureBox fto2 = new PictureBox();
                    fto2.Size = new Size(size_celda / 2, size_celda);
                    fto2.Location = new Point(fto1.Width, 0);
                    fto2.SizeMode = PictureBoxSizeMode.Zoom;
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
        private void ImprimirTableroGrafico()
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
        private void EscribirEnElRegistro(string orden)
        {
            Label l = new Label();
            l.BackColor = Color.Transparent;
            l.AutoSize = false;
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

        //Texto para el resumen de la simulacion
        public List<string> GetTextoResumen()
        {
            List<string> lista_palabras = new List<string>();

            //Empiezo a escribir en el archivo "resumen.txt"
            File.WriteAllText("resumen.txt", "\\\\\\\\\\\\Resumen de la simulacion\\\\\\\\\\\\\r\n");
            File.AppendAllText("resumen.txt", "\r\n");

            //Tiempo de vida promedio Bitmon:
            string text = bitmonlandia.TiempoDeVidaPromedioBitmon();
            lista_palabras.Add(text);
            File.AppendAllText("resumen.txt", "\r\n");

            ////////////////////////////////////////////
            //Tiempo de vida promedio de cada especie:
            File.AppendAllText("resumen.txt", "Tiempo de vida promedio de cada especie:\r\n");

            //Taplan
            text = bitmonlandia.TiempoDeVidaPromedioEspecie("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = bitmonlandia.TiempoDeVidaPromedioEspecie("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = bitmonlandia.TiempoDeVidaPromedioEspecie("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = bitmonlandia.TiempoDeVidaPromedioEspecie("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = bitmonlandia.TiempoDeVidaPromedioEspecie("Wetar");
            lista_palabras.Add(text);

            //Ent
            text = bitmonlandia.TiempoDeVidaPromedioEspecie("Ent");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            /////////////////////////////////////////////////////
            //Tasa de natalidad
            File.AppendAllText("resumen.txt", "Tasa de natalidad de cada especie:\r\n");

            //Taplan
            text = bitmonlandia.TasaDeNatalidad("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = bitmonlandia.TasaDeNatalidad("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = bitmonlandia.TasaDeNatalidad("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = bitmonlandia.TasaDeNatalidad("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = bitmonlandia.TasaDeNatalidad("Wetar");
            lista_palabras.Add(text);

            //Ent
            text = bitmonlandia.TasaDeNatalidad("Ent");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            ////////////////////////////////////////////////
            //Tasa de mortalidad de cada especie:
            File.AppendAllText("resumen.txt", "Tasa de mortalidad de cada especie:\r\n");
            //Taplan
            text = bitmonlandia.TasaDeMortalidad("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = bitmonlandia.TasaDeMortalidad("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = bitmonlandia.TasaDeMortalidad("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = bitmonlandia.TasaDeMortalidad("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = bitmonlandia.TasaDeMortalidad("Wetar");
            lista_palabras.Add(text);

            //Ent
            text = bitmonlandia.TasaDeMortalidad("Ent");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            /////////////////////////////////////////////////
            //Cantidad de hijos por especie
            File.AppendAllText("resumen.txt", "Cantidad de hijos promedio por especie:\r\n");

            //Taplan
            text = bitmonlandia.HijosPromedioEspecie("Taplan");
            lista_palabras.Add(text);

            //Dorvalo
            text = bitmonlandia.HijosPromedioEspecie("Dorvalo");
            lista_palabras.Add(text);

            //Gofue
            text = bitmonlandia.HijosPromedioEspecie("Gofue");
            lista_palabras.Add(text);

            //Doti
            text = bitmonlandia.HijosPromedioEspecie("Doti");
            lista_palabras.Add(text);

            //Wetar
            text = bitmonlandia.HijosPromedioEspecie("Wetar");
            lista_palabras.Add(text);

            File.AppendAllText("resumen.txt", "\r\n");

            return lista_palabras;
        }

        public List<List<string>> GetTextoResumenParte2()
        {
            List<List<string>> lista_palabras = new List<List<string>>();

            ////////////////////////////////////////////////
            //Listado de especies extintas:
            File.AppendAllText("resumen.txt", "Lista de especies extintas\r\n");
            List<string> lista_text = bitmonlandia.GetEspeciesExtintas();
            lista_palabras.Add(lista_text);

            File.AppendAllText("resumen.txt", "\r\n");

            ///////////////////////////////////////////
            //Bithalla:
            File.AppendAllText("resumen.txt", "Bithalla:\r\n");
            lista_text = bitmonlandia.Bithalla();
            lista_palabras.Add(lista_text);

            File.AppendAllText("resumen.txt", "\r\n");

            return lista_palabras;
        }

        private void Avanzar_Mes(object sender, EventArgs e)
        {
            //Verficamos si termino la simulacion
            if (mes_contador > meses_a_simular)
            {
                Close();
                return;
            }

            if (turno % 2 == 0)
            {
                //ciclo for para que los bitmons se muevan
                for (int bit = 0; bit < bitmonlandia.GetLista().Count; bit++)
                {
                    //vemos si es que el bitmon no esta muerto
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    string especie = bitmonlandia.GetLista()[bit].GetNombre();

                    //Movimiento:
                    if (especie != "Ent")
                    {
                        bitmonlandia.GetLista()[bit].Movimiento(bitmonlandia.GetMapa());
                    }
                }

                //se imprime el tablero grafico para ver los movimientos que ocurrieron dentro del mes
                ImprimirTableroGrafico();
                EscribirEnElRegistro("Los Bitmons se han movido");
                turno++;
            }

            else if (turno % 2 == 1)
            {
                //Se recorre la lista de bitmons para ver si hay bitmons en la misma casilla
                for (int bit = 0; bit < bitmonlandia.GetLista().Count; bit++)
                {
                    // vemos si es que el bitmon no esta muerto
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    //Selecciono el primer bitmon y veo su especie tambien:
                    string especie = bitmonlandia.GetLista()[bit].GetNombre();


                    //Y recorro la lista en busca de una coincidencia
                    for (int pareja = bit + 1; pareja < bitmonlandia.GetLista().Count; pareja++)
                    {
                        if (bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == false)
                        {
                            continue;
                        }

                        if (bitmonlandia.GetLista()[bit].GetPosicion()[0] == bitmonlandia.GetLista()[pareja].GetPosicion()[0] && bitmonlandia.GetLista()[bit].GetPosicion()[1] == bitmonlandia.GetLista()[pareja].GetPosicion()[1
                            ])
                        {
                            //Primero intentamos con pelea
                            bitmonlandia.GetLista()[bit].Pelea(bitmonlandia.GetLista()[pareja]);
                            string registro = String.Format("{0} peleó con {1}", bitmonlandia.GetLista()[bit].GetNombre(), bitmonlandia.GetLista()[pareja].GetNombre());

                            //Si no funciona, significa que se llevan bien para reproducirse
                            if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == true && bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == true)
                            {
                                registro = "";
                                int prob = random.Next(101);
                                if (prob <= 15)
                                {//probabilidad del 15% de reproducirse
                                    registro = String.Format("{0} se reprodujo con {1}", bitmonlandia.GetLista()[bit].GetNombre(), bitmonlandia.GetLista()[pareja].GetNombre());
                                    bitmonlandia.GetLista()[bit].Reproduccion(bitmonlandia.GetLista()[pareja], seed, bitmonlandia);
                                }
                            }
                            EscribirEnElRegistro(registro);
                        }




                        if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                        {
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[bit].GetPosicion()[0], bitmonlandia.GetLista()[bit].GetPosicion()[1], bitmonlandia.GetLista()[bit].GetCelda());
                            bitmonlandia.GetLista()[bit].LimpiarCadaver();
                        }

                        if (bitmonlandia.GetLista()[pareja].GetEstadoDeVida() == false)
                        {
                            bitmonlandia.GetMapa().RemoveBitmon(bitmonlandia.GetLista()[pareja].GetPosicion()[0], bitmonlandia.GetLista()[pareja].GetPosicion()[1], bitmonlandia.GetLista()[pareja].GetCelda());
                            bitmonlandia.GetLista()[pareja].LimpiarCadaver();
                        }

                    }

                    /*Comprobamos si sigue vivo este bitmon, para asi saber si moverlo y cambiar el terreno
                        * si corresponde*/
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == false)
                    {
                        continue;
                    }

                    //Ahora que sabemos que esta vivo cambiamos el terreno si corresponde
                    //Transformar terreno:
                    if (especie == "Gofue")
                    {
                        bitmonlandia.GetLista()[bit].Secar(bitmonlandia.GetMapa());
                    }

                    else if (especie == "Taplan")
                    {
                        bitmonlandia.GetLista()[bit].Plantar(bitmonlandia.GetMapa());
                    }

                    //Si sigue vivo despues de todo, hacerlo envejecer
                    if (bitmonlandia.GetLista()[bit].GetEstadoDeVida() == true)
                    {
                        bitmonlandia.GetLista()[bit].Envejecer(bitmonlandia.GetMapa());
                    }
                }

                //Si han pasado 3 meses y algun Ent sigue vivo, spawnear uno
                if (mes_contador % 3 == 0 && mes_contador != 0)
                {
                    EscribirEnElRegistro("Un nuevo Ent ha brotado");
                    bitmonlandia.PlantarEnt(seed);
                }

                EscribirEnElRegistro("mes");
                ImprimirTableroGrafico();
                mes_contador++;
                turno++;
            }
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
        }
    }
}
