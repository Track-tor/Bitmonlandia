namespace Bitmonlandia_2._0
{
    partial class Form2
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
            this.Cuadro_Registro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(270, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 530);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Boton_Mes
            // 
            this.Boton_Mes.Location = new System.Drawing.Point(42, 249);
            this.Boton_Mes.Name = "Boton_Mes";
            this.Boton_Mes.Size = new System.Drawing.Size(168, 168);
            this.Boton_Mes.TabIndex = 1;
            this.Boton_Mes.Text = "Avanzar Simulacion";
            this.Boton_Mes.UseVisualStyleBackColor = true;
            this.Boton_Mes.Click += new System.EventHandler(this.Avanzar_Mes);
            // 
            // Registro_titulo
            // 
            this.Registro_titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Registro_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Registro_titulo.Location = new System.Drawing.Point(0, 0);
            this.Registro_titulo.Margin = new System.Windows.Forms.Padding(0);
            this.Registro_titulo.Name = "Registro_titulo";
            this.Registro_titulo.Size = new System.Drawing.Size(234, 35);
            this.Registro_titulo.TabIndex = 2;
            this.Registro_titulo.Text = "REGISTRO";
            this.Registro_titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Cuadro_Registro
            // 
            this.Cuadro_Registro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cuadro_Registro.Controls.Add(this.Registro_titulo);
            this.Cuadro_Registro.Location = new System.Drawing.Point(830, 153);
            this.Cuadro_Registro.Name = "Cuadro_Registro";
            this.Cuadro_Registro.Size = new System.Drawing.Size(235, 301);
            this.Cuadro_Registro.TabIndex = 3;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 634);
            this.Controls.Add(this.Cuadro_Registro);
            this.Controls.Add(this.Boton_Mes);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Cuadro_Registro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Boton_Mes;
        private System.Windows.Forms.Label Registro_titulo;
        private System.Windows.Forms.FlowLayoutPanel Cuadro_Registro;
    }
}