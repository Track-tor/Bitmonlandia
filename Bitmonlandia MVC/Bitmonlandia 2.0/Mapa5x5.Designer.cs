namespace View
{
    partial class Mapa5x5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Boton_Mes = new System.Windows.Forms.Button();
            this.Registro_titulo = new System.Windows.Forms.Label();
            this.Cuadro_Registro = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(357, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 690);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Boton_Mes
            // 
            this.Boton_Mes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Boton_Mes.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boton_Mes.Location = new System.Drawing.Point(133, 289);
            this.Boton_Mes.Name = "Boton_Mes";
            this.Boton_Mes.Size = new System.Drawing.Size(184, 168);
            this.Boton_Mes.TabIndex = 1;
            this.Boton_Mes.Text = "Avanzar Simulacion";
            this.Boton_Mes.UseVisualStyleBackColor = true;
            this.Boton_Mes.Click += new System.EventHandler(this.Boton_Mes_Click);
            // 
            // Registro_titulo
            // 
            this.Registro_titulo.BackColor = System.Drawing.Color.Transparent;
            this.Registro_titulo.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registro_titulo.Location = new System.Drawing.Point(50, 50);
            this.Registro_titulo.Margin = new System.Windows.Forms.Padding(0);
            this.Registro_titulo.Name = "Registro_titulo";
            this.Registro_titulo.Size = new System.Drawing.Size(339, 43);
            this.Registro_titulo.TabIndex = 2;
            this.Registro_titulo.Text = "REGISTRO";
            this.Registro_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cuadro_Registro
            // 
            this.Cuadro_Registro.AutoScroll = true;
            this.Cuadro_Registro.BackColor = System.Drawing.Color.Transparent;
            this.Cuadro_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cuadro_Registro.Location = new System.Drawing.Point(89, 171);
            this.Cuadro_Registro.Name = "Cuadro_Registro";
            this.Cuadro_Registro.Size = new System.Drawing.Size(268, 492);
            this.Cuadro_Registro.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Bitmonlandia_2._0.Properties.Resources.pergamino;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Cuadro_Registro);
            this.panel1.Controls.Add(this.Registro_titulo);
            this.panel1.Location = new System.Drawing.Point(1085, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 705);
            this.panel1.TabIndex = 4;
            // 
            // Mapa5x5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 752);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Boton_Mes);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Mapa5x5";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Mapa5x5_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Boton_Mes;
        private System.Windows.Forms.Label Registro_titulo;
        private System.Windows.Forms.FlowLayoutPanel Cuadro_Registro;
        private System.Windows.Forms.Panel panel1;
    }
}