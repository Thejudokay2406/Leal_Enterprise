namespace Presentacion
{
    partial class frmFiltro_Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltro_Producto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGFiltro_Resultados = new System.Windows.Forms.DataGridView();
            this.TBIdproducto = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.TBPresentacion = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.TBDescripcion01 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBReferencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBMarca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TBStock = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBlote = new System.Windows.Forms.TextBox();
            this.TBMaximaMayorista = new System.Windows.Forms.TextBox();
            this.TBMinimoMayorista = new System.Windows.Forms.TextBox();
            this.TBUnidad = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TBMaximoCliente = new System.Windows.Forms.TextBox();
            this.TBMininoCliente = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TBBodega = new System.Windows.Forms.TextBox();
            this.TBUnidadDeVenta = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_Resultados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGFiltro_Resultados);
            this.groupBox1.Controls.Add(this.TBIdproducto);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.TBBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Productos y Datos Basicos - Leal Enterprise";
            // 
            // DGFiltro_Resultados
            // 
            this.DGFiltro_Resultados.AllowUserToAddRows = false;
            this.DGFiltro_Resultados.AllowUserToDeleteRows = false;
            this.DGFiltro_Resultados.BackgroundColor = System.Drawing.Color.White;
            this.DGFiltro_Resultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGFiltro_Resultados.Location = new System.Drawing.Point(6, 47);
            this.DGFiltro_Resultados.Name = "DGFiltro_Resultados";
            this.DGFiltro_Resultados.ReadOnly = true;
            this.DGFiltro_Resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGFiltro_Resultados.Size = new System.Drawing.Size(500, 286);
            this.DGFiltro_Resultados.TabIndex = 3;
            this.DGFiltro_Resultados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGFiltro_Resultados_CellClick);
            this.DGFiltro_Resultados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGResultados_KeyPress);
            // 
            // TBIdproducto
            // 
            this.TBIdproducto.Location = new System.Drawing.Point(421, 345);
            this.TBIdproducto.Name = "TBIdproducto";
            this.TBIdproducto.Size = new System.Drawing.Size(65, 21);
            this.TBIdproducto.TabIndex = 5;
            this.TBIdproducto.TextChanged += new System.EventHandler(this.TBIdproducto_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(152, 342);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(111, 15);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Datos Registrados:";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(133, 20);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(373, 21);
            this.TBBuscar.TabIndex = 1;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            this.TBBuscar.Enter += new System.EventHandler(this.TBBuscar_Enter);
            this.TBBuscar.Leave += new System.EventHandler(this.TBBuscar_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto a Consultar";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.Image = global::Presentacion.Properties.Resources.btnAgregar;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(6, 339);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 30);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar Producto";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // TBPresentacion
            // 
            this.TBPresentacion.Location = new System.Drawing.Point(91, 128);
            this.TBPresentacion.Name = "TBPresentacion";
            this.TBPresentacion.Size = new System.Drawing.Size(300, 21);
            this.TBPresentacion.TabIndex = 37;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 131);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 15);
            this.label25.TabIndex = 36;
            this.label25.Text = "Presentacion";
            // 
            // TBDescripcion01
            // 
            this.TBDescripcion01.Location = new System.Drawing.Point(91, 101);
            this.TBDescripcion01.Name = "TBDescripcion01";
            this.TBDescripcion01.Size = new System.Drawing.Size(300, 21);
            this.TBDescripcion01.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "Descripcion";
            // 
            // TBReferencia
            // 
            this.TBReferencia.Location = new System.Drawing.Point(91, 74);
            this.TBReferencia.Name = "TBReferencia";
            this.TBReferencia.Size = new System.Drawing.Size(300, 21);
            this.TBReferencia.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Referencia";
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(91, 47);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(300, 21);
            this.TBNombre.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Producto";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(91, 20);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(300, 21);
            this.TBCodigo.TabIndex = 29;
            this.TBCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Codigo";
            // 
            // TBMarca
            // 
            this.TBMarca.Location = new System.Drawing.Point(91, 155);
            this.TBMarca.Name = "TBMarca";
            this.TBMarca.Size = new System.Drawing.Size(300, 21);
            this.TBMarca.TabIndex = 155;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 149;
            this.label6.Text = "Marca";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 167;
            this.label8.Text = "Lote";
            // 
            // TBStock
            // 
            this.TBStock.Location = new System.Drawing.Point(91, 209);
            this.TBStock.Name = "TBStock";
            this.TBStock.Size = new System.Drawing.Size(300, 21);
            this.TBStock.TabIndex = 166;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 165;
            this.label7.Text = "Stock Disp.";
            // 
            // TBlote
            // 
            this.TBlote.Location = new System.Drawing.Point(91, 236);
            this.TBlote.Name = "TBlote";
            this.TBlote.Size = new System.Drawing.Size(300, 21);
            this.TBlote.TabIndex = 168;
            // 
            // TBMaximaMayorista
            // 
            this.TBMaximaMayorista.Location = new System.Drawing.Point(311, 73);
            this.TBMaximaMayorista.Name = "TBMaximaMayorista";
            this.TBMaximaMayorista.Size = new System.Drawing.Size(80, 21);
            this.TBMaximaMayorista.TabIndex = 164;
            this.TBMaximaMayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBMinimoMayorista
            // 
            this.TBMinimoMayorista.Location = new System.Drawing.Point(113, 73);
            this.TBMinimoMayorista.Name = "TBMinimoMayorista";
            this.TBMinimoMayorista.Size = new System.Drawing.Size(80, 21);
            this.TBMinimoMayorista.TabIndex = 163;
            this.TBMinimoMayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBUnidad
            // 
            this.TBUnidad.Location = new System.Drawing.Point(86, 20);
            this.TBUnidad.Name = "TBUnidad";
            this.TBUnidad.Size = new System.Drawing.Size(107, 21);
            this.TBUnidad.TabIndex = 169;
            this.TBUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(199, 76);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(108, 15);
            this.label40.TabIndex = 162;
            this.label40.Text = "Maxima Mayorista";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 77);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(105, 15);
            this.label38.TabIndex = 161;
            this.label38.Text = "Minima Mayorista";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 170;
            this.label9.Text = "Bodega";
            // 
            // TBMaximoCliente
            // 
            this.TBMaximoCliente.Location = new System.Drawing.Point(311, 47);
            this.TBMaximoCliente.Name = "TBMaximoCliente";
            this.TBMaximoCliente.Size = new System.Drawing.Size(80, 21);
            this.TBMaximoCliente.TabIndex = 160;
            this.TBMaximoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBMininoCliente
            // 
            this.TBMininoCliente.Location = new System.Drawing.Point(113, 47);
            this.TBMininoCliente.Name = "TBMininoCliente";
            this.TBMininoCliente.Size = new System.Drawing.Size(80, 21);
            this.TBMininoCliente.TabIndex = 159;
            this.TBMininoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(199, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 15);
            this.label17.TabIndex = 158;
            this.label17.Text = "Maximo Personal";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 15);
            this.label16.TabIndex = 157;
            this.label16.Text = "Minimo Personal";
            // 
            // TBBodega
            // 
            this.TBBodega.Location = new System.Drawing.Point(91, 182);
            this.TBBodega.Name = "TBBodega";
            this.TBBodega.Size = new System.Drawing.Size(300, 21);
            this.TBBodega.TabIndex = 171;
            // 
            // TBUnidadDeVenta
            // 
            this.TBUnidadDeVenta.Location = new System.Drawing.Point(202, 20);
            this.TBUnidadDeVenta.Name = "TBUnidadDeVenta";
            this.TBUnidadDeVenta.Size = new System.Drawing.Size(189, 21);
            this.TBUnidadDeVenta.TabIndex = 154;
            this.TBUnidadDeVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 15);
            this.label27.TabIndex = 152;
            this.label27.Text = "Unidad";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TBStock);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TBMarca);
            this.groupBox2.Controls.Add(this.TBPresentacion);
            this.groupBox2.Controls.Add(this.TBlote);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.TBBodega);
            this.groupBox2.Controls.Add(this.TBCodigo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TBDescripcion01);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TBReferencia);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TBNombre);
            this.groupBox2.Location = new System.Drawing.Point(530, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 269);
            this.groupBox2.TabIndex = 173;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Basicos del Producto - Leal Enterprise";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.TBMaximoCliente);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Controls.Add(this.TBMaximaMayorista);
            this.groupBox3.Controls.Add(this.TBUnidadDeVenta);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.TBUnidad);
            this.groupBox3.Controls.Add(this.TBMinimoMayorista);
            this.groupBox3.Controls.Add(this.TBMininoCliente);
            this.groupBox3.Location = new System.Drawing.Point(530, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 100);
            this.groupBox3.TabIndex = 174;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cantidades Autorizadas del Producto - Leal Enterprise";
            // 
            // frmFiltro_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(946, 396);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFiltro_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro de Producto - Leal Enterprise";
            this.Load += new System.EventHandler(this.frmFiltro_Producto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_Resultados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGFiltro_Resultados;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBPresentacion;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox TBDescripcion01;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBReferencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBMarca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox TBIdproducto;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox TBUnidadDeVenta;
        private System.Windows.Forms.TextBox TBBodega;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TBMininoCliente;
        private System.Windows.Forms.TextBox TBMaximoCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox TBUnidad;
        private System.Windows.Forms.TextBox TBMinimoMayorista;
        private System.Windows.Forms.TextBox TBMaximaMayorista;
        private System.Windows.Forms.TextBox TBlote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBStock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}