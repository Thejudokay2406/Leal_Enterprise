namespace Presentacion
{
    partial class frmRegularizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegularizacion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.CBOrden = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGDetalleDeIngreso = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnExaminar_Comprobante = new System.Windows.Forms.Button();
            this.TBCodigo_Comprobante = new System.Windows.Forms.TextBox();
            this.btnExaminar_Producto = new System.Windows.Forms.Button();
            this.TBCodigo_Producto = new System.Windows.Forms.TextBox();
            this.btnExaminar_Bodega = new System.Windows.Forms.Button();
            this.TBBodega = new System.Windows.Forms.TextBox();
            this.TBCodigo_Bodega = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBComprobante = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBProducto = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.IDIngresos = new System.Windows.Forms.TextBox();
            this.TBIdproducto = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalleDeIngreso)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.IDIngresos);
            this.groupBox1.Controls.Add(this.TBIdproducto);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1065, 519);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso a Bodegas - Leal Enterprise";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Image = global::Presentacion.Botones.btnImprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(963, 483);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 30);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(867, 483);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(106, 483);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(10, 483);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1051, 458);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.CBOrden);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DGDetalleDeIngreso);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.btnExaminar_Comprobante);
            this.tabPage1.Controls.Add(this.TBCodigo_Comprobante);
            this.tabPage1.Controls.Add(this.btnExaminar_Producto);
            this.tabPage1.Controls.Add(this.TBCodigo_Producto);
            this.tabPage1.Controls.Add(this.btnExaminar_Bodega);
            this.tabPage1.Controls.Add(this.TBBodega);
            this.tabPage1.Controls.Add(this.TBCodigo_Bodega);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.TBComprobante);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.TBProducto);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1043, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos de Ingreso";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(599, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 21);
            this.dateTimePicker1.TabIndex = 145;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(511, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 144;
            this.label4.Text = "Fecha";
            // 
            // CBOrden
            // 
            this.CBOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBOrden.FormattingEnabled = true;
            this.CBOrden.Location = new System.Drawing.Point(68, 60);
            this.CBOrden.Name = "CBOrden";
            this.CBOrden.Size = new System.Drawing.Size(181, 21);
            this.CBOrden.TabIndex = 143;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 142;
            this.label1.Text = "Orden";
            // 
            // DGDetalleDeIngreso
            // 
            this.DGDetalleDeIngreso.AllowUserToAddRows = false;
            this.DGDetalleDeIngreso.AllowUserToDeleteRows = false;
            this.DGDetalleDeIngreso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGDetalleDeIngreso.BackgroundColor = System.Drawing.Color.White;
            this.DGDetalleDeIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDetalleDeIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGDetalleDeIngreso.Location = new System.Drawing.Point(9, 87);
            this.DGDetalleDeIngreso.Name = "DGDetalleDeIngreso";
            this.DGDetalleDeIngreso.ReadOnly = true;
            this.DGDetalleDeIngreso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGDetalleDeIngreso.Size = new System.Drawing.Size(1026, 337);
            this.DGDetalleDeIngreso.TabIndex = 141;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(255, 63);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(108, 15);
            this.lblTotal.TabIndex = 118;
            this.lblTotal.Text = "Productos en Lista";
            // 
            // btnExaminar_Comprobante
            // 
            this.btnExaminar_Comprobante.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExaminar_Comprobante.BackgroundImage")));
            this.btnExaminar_Comprobante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Comprobante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Comprobante.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Comprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Comprobante.Location = new System.Drawing.Point(755, 7);
            this.btnExaminar_Comprobante.Name = "btnExaminar_Comprobante";
            this.btnExaminar_Comprobante.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Comprobante.TabIndex = 133;
            this.btnExaminar_Comprobante.UseVisualStyleBackColor = true;
            // 
            // TBCodigo_Comprobante
            // 
            this.TBCodigo_Comprobante.Location = new System.Drawing.Point(599, 7);
            this.TBCodigo_Comprobante.Name = "TBCodigo_Comprobante";
            this.TBCodigo_Comprobante.Size = new System.Drawing.Size(150, 21);
            this.TBCodigo_Comprobante.TabIndex = 132;
            this.TBCodigo_Comprobante.Text = "802.007.113-5";
            this.TBCodigo_Comprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExaminar_Producto
            // 
            this.btnExaminar_Producto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExaminar_Producto.BackgroundImage")));
            this.btnExaminar_Producto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Producto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Producto.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Producto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Producto.Location = new System.Drawing.Point(224, 33);
            this.btnExaminar_Producto.Name = "btnExaminar_Producto";
            this.btnExaminar_Producto.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Producto.TabIndex = 131;
            this.btnExaminar_Producto.UseVisualStyleBackColor = true;
            // 
            // TBCodigo_Producto
            // 
            this.TBCodigo_Producto.Location = new System.Drawing.Point(68, 33);
            this.TBCodigo_Producto.Name = "TBCodigo_Producto";
            this.TBCodigo_Producto.Size = new System.Drawing.Size(150, 21);
            this.TBCodigo_Producto.TabIndex = 130;
            this.TBCodigo_Producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnExaminar_Bodega
            // 
            this.btnExaminar_Bodega.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExaminar_Bodega.BackgroundImage")));
            this.btnExaminar_Bodega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Bodega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Bodega.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Bodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Bodega.Location = new System.Drawing.Point(224, 6);
            this.btnExaminar_Bodega.Name = "btnExaminar_Bodega";
            this.btnExaminar_Bodega.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Bodega.TabIndex = 128;
            this.btnExaminar_Bodega.UseVisualStyleBackColor = true;
            // 
            // TBBodega
            // 
            this.TBBodega.Location = new System.Drawing.Point(255, 6);
            this.TBBodega.Name = "TBBodega";
            this.TBBodega.Size = new System.Drawing.Size(250, 21);
            this.TBBodega.TabIndex = 127;
            this.TBBodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCodigo_Bodega
            // 
            this.TBCodigo_Bodega.Location = new System.Drawing.Point(68, 6);
            this.TBCodigo_Bodega.Name = "TBCodigo_Bodega";
            this.TBCodigo_Bodega.Size = new System.Drawing.Size(150, 21);
            this.TBCodigo_Bodega.TabIndex = 124;
            this.TBCodigo_Bodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 122;
            this.label5.Text = "Bodega";
            // 
            // TBComprobante
            // 
            this.TBComprobante.Location = new System.Drawing.Point(786, 7);
            this.TBComprobante.Name = "TBComprobante";
            this.TBComprobante.Size = new System.Drawing.Size(250, 21);
            this.TBComprobante.TabIndex = 103;
            this.TBComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 106;
            this.label6.Text = "Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "Sucurzal";
            // 
            // TBProducto
            // 
            this.TBProducto.Location = new System.Drawing.Point(255, 33);
            this.TBProducto.Name = "TBProducto";
            this.TBProducto.Size = new System.Drawing.Size(250, 21);
            this.TBProducto.TabIndex = 105;
            this.TBProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGResultados);
            this.tabPage2.Controls.Add(this.TBBuscar);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1043, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta de Ingreso";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGResultados
            // 
            this.DGResultados.AllowUserToAddRows = false;
            this.DGResultados.AllowUserToDeleteRows = false;
            this.DGResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGResultados.BackgroundColor = System.Drawing.Color.White;
            this.DGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGResultados.Location = new System.Drawing.Point(9, 33);
            this.DGResultados.Name = "DGResultados";
            this.DGResultados.ReadOnly = true;
            this.DGResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultados.Size = new System.Drawing.Size(945, 391);
            this.DGResultados.TabIndex = 2;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(125, 6);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(829, 21);
            this.TBBuscar.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Ingreso a Consultar";
            // 
            // IDIngresos
            // 
            this.IDIngresos.Location = new System.Drawing.Point(290, 486);
            this.IDIngresos.Name = "IDIngresos";
            this.IDIngresos.Size = new System.Drawing.Size(19, 21);
            this.IDIngresos.TabIndex = 116;
            // 
            // TBIdproducto
            // 
            this.TBIdproducto.Location = new System.Drawing.Point(315, 486);
            this.TBIdproducto.Name = "TBIdproducto";
            this.TBIdproducto.Size = new System.Drawing.Size(15, 21);
            this.TBIdproducto.TabIndex = 115;
            // 
            // frmRegularizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1089, 540);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmRegularizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegularizacion";
            this.Load += new System.EventHandler(this.frmRegularizacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalleDeIngreso)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DGDetalleDeIngreso;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExaminar_Producto;
        private System.Windows.Forms.TextBox TBCodigo_Producto;
        private System.Windows.Forms.Button btnExaminar_Bodega;
        private System.Windows.Forms.TextBox TBBodega;
        private System.Windows.Forms.TextBox TBCodigo_Bodega;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TBProducto;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox IDIngresos;
        public System.Windows.Forms.TextBox TBIdproducto;
        private System.Windows.Forms.ComboBox CBOrden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExaminar_Comprobante;
        private System.Windows.Forms.TextBox TBCodigo_Comprobante;
        private System.Windows.Forms.TextBox TBComprobante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
    }
}