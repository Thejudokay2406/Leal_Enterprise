namespace Presentacion
{
    partial class frmCotizacionDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCotizacionDeCompra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBIdordendecompra = new System.Windows.Forms.TextBox();
            this.CBTipodepago = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotal_Detalles = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar_Detalles = new System.Windows.Forms.Button();
            this.btnExaminar_Proveedor = new System.Windows.Forms.Button();
            this.TBProducto = new System.Windows.Forms.TextBox();
            this.TBCodigo_Producto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBBodega = new System.Windows.Forms.TextBox();
            this.TBProveedor = new System.Windows.Forms.TextBox();
            this.TBOrdendecompra = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBDescuento = new System.Windows.Forms.TextBox();
            this.TBValorFinal = new System.Windows.Forms.TextBox();
            this.TBSubTotal = new System.Windows.Forms.TextBox();
            this.DGDetalles = new System.Windows.Forms.DataGridView();
            this.btnExaminar_Producto = new System.Windows.Forms.Button();
            this.btnExaminar_Bodega = new System.Windows.Forms.Button();
            this.TBCodigo_Bodega = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBCodigo_Proveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBIdbodega = new System.Windows.Forms.TextBox();
            this.TBIdproveedor = new System.Windows.Forms.TextBox();
            this.TBIddetalle = new System.Windows.Forms.TextBox();
            this.TBIdproducto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminar_Resultados = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.CBFechas = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CBLista = new System.Windows.Forms.ComboBox();
            this.CHProveedor = new System.Windows.Forms.CheckBox();
            this.CHBodega = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalles)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CHBodega);
            this.groupBox1.Controls.Add(this.CHProveedor);
            this.groupBox1.Controls.Add(this.CBLista);
            this.groupBox1.Controls.Add(this.TBIdordendecompra);
            this.groupBox1.Controls.Add(this.CBTipodepago);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblTotal_Detalles);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnEliminar_Detalles);
            this.groupBox1.Controls.Add(this.btnExaminar_Proveedor);
            this.groupBox1.Controls.Add(this.TBProducto);
            this.groupBox1.Controls.Add(this.TBCodigo_Producto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TBBodega);
            this.groupBox1.Controls.Add(this.TBProveedor);
            this.groupBox1.Controls.Add(this.TBOrdendecompra);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.DGDetalles);
            this.groupBox1.Controls.Add(this.btnExaminar_Producto);
            this.groupBox1.Controls.Add(this.btnExaminar_Bodega);
            this.groupBox1.Controls.Add(this.TBCodigo_Bodega);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TBCodigo_Proveedor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBCodigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cotizacion de Compra - Leal Enterprise";
            // 
            // TBIdordendecompra
            // 
            this.TBIdordendecompra.Location = new System.Drawing.Point(150, 502);
            this.TBIdordendecompra.Name = "TBIdordendecompra";
            this.TBIdordendecompra.Size = new System.Drawing.Size(100, 22);
            this.TBIdordendecompra.TabIndex = 215;
            // 
            // CBTipodepago
            // 
            this.CBTipodepago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBTipodepago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipodepago.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTipodepago.FormattingEnabled = true;
            this.CBTipodepago.Location = new System.Drawing.Point(75, 133);
            this.CBTipodepago.Name = "CBTipodepago";
            this.CBTipodepago.Size = new System.Drawing.Size(140, 23);
            this.CBTipodepago.Sorted = true;
            this.CBTipodepago.TabIndex = 204;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 17);
            this.label10.TabIndex = 203;
            this.label10.Text = "Pago";
            // 
            // lblTotal_Detalles
            // 
            this.lblTotal_Detalles.AutoSize = true;
            this.lblTotal_Detalles.Location = new System.Drawing.Point(6, 508);
            this.lblTotal_Detalles.Name = "lblTotal_Detalles";
            this.lblTotal_Detalles.Size = new System.Drawing.Size(133, 17);
            this.lblTotal_Detalles.TabIndex = 194;
            this.lblTotal_Detalles.Text = "Productos Agregados: ";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(677, 501);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 188;
            this.btnGuardar.Text = "Guardar - F10";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(551, 501);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 190;
            this.btnCancelar.Text = "Cancelar - F9";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar_Detalles
            // 
            this.btnEliminar_Detalles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_Detalles.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar_Detalles.FlatAppearance.BorderSize = 0;
            this.btnEliminar_Detalles.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar_Detalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar_Detalles.Location = new System.Drawing.Point(425, 501);
            this.btnEliminar_Detalles.Name = "btnEliminar_Detalles";
            this.btnEliminar_Detalles.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar_Detalles.TabIndex = 189;
            this.btnEliminar_Detalles.Text = "Eliminar - F4";
            this.btnEliminar_Detalles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar_Detalles.UseVisualStyleBackColor = true;
            this.btnEliminar_Detalles.Click += new System.EventHandler(this.btnEliminar_Detalles_Click);
            // 
            // btnExaminar_Proveedor
            // 
            this.btnExaminar_Proveedor.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.btnExaminar_Proveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Proveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Proveedor.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Proveedor.Location = new System.Drawing.Point(497, 49);
            this.btnExaminar_Proveedor.Name = "btnExaminar_Proveedor";
            this.btnExaminar_Proveedor.Size = new System.Drawing.Size(25, 22);
            this.btnExaminar_Proveedor.TabIndex = 185;
            this.btnExaminar_Proveedor.UseVisualStyleBackColor = true;
            this.btnExaminar_Proveedor.Click += new System.EventHandler(this.btnExaminar_Proveedor_Click);
            // 
            // TBProducto
            // 
            this.TBProducto.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProducto.Location = new System.Drawing.Point(221, 105);
            this.TBProducto.Name = "TBProducto";
            this.TBProducto.Size = new System.Drawing.Size(270, 22);
            this.TBProducto.TabIndex = 184;
            this.TBProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCodigo_Producto
            // 
            this.TBCodigo_Producto.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Producto.Location = new System.Drawing.Point(75, 105);
            this.TBCodigo_Producto.Name = "TBCodigo_Producto";
            this.TBCodigo_Producto.Size = new System.Drawing.Size(140, 22);
            this.TBCodigo_Producto.TabIndex = 183;
            this.TBCodigo_Producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo_Producto.Enter += new System.EventHandler(this.TBCodigo_Producto_Enter);
            this.TBCodigo_Producto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCodigo_Producto_KeyPress);
            this.TBCodigo_Producto.Leave += new System.EventHandler(this.TBCodigo_Producto_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 182;
            this.label5.Text = "Producto";
            // 
            // TBBodega
            // 
            this.TBBodega.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBodega.Location = new System.Drawing.Point(221, 77);
            this.TBBodega.Name = "TBBodega";
            this.TBBodega.Size = new System.Drawing.Size(270, 22);
            this.TBBodega.TabIndex = 181;
            this.TBBodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBProveedor
            // 
            this.TBProveedor.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProveedor.Location = new System.Drawing.Point(221, 49);
            this.TBProveedor.Name = "TBProveedor";
            this.TBProveedor.Size = new System.Drawing.Size(270, 22);
            this.TBProveedor.TabIndex = 180;
            this.TBProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBOrdendecompra
            // 
            this.TBOrdendecompra.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBOrdendecompra.Location = new System.Drawing.Point(221, 21);
            this.TBOrdendecompra.Name = "TBOrdendecompra";
            this.TBOrdendecompra.Size = new System.Drawing.Size(301, 22);
            this.TBOrdendecompra.TabIndex = 179;
            this.TBOrdendecompra.Enter += new System.EventHandler(this.TBDescripcion_Enter);
            this.TBOrdendecompra.Leave += new System.EventHandler(this.TBDescripcion_Leave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Presentacion.Tablas.Valor_Final___Cotizacion_de_Compra;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.TBDescuento);
            this.panel1.Controls.Add(this.TBValorFinal);
            this.panel1.Controls.Add(this.TBSubTotal);
            this.panel1.Location = new System.Drawing.Point(529, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 106);
            this.panel1.TabIndex = 178;
            // 
            // TBDescuento
            // 
            this.TBDescuento.BackColor = System.Drawing.Color.Silver;
            this.TBDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBDescuento.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDescuento.Location = new System.Drawing.Point(106, 58);
            this.TBDescuento.Name = "TBDescuento";
            this.TBDescuento.Size = new System.Drawing.Size(155, 16);
            this.TBDescuento.TabIndex = 3;
            this.TBDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBDescuento.Enter += new System.EventHandler(this.TBDescuento_Enter);
            this.TBDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDescuento_KeyPress);
            this.TBDescuento.Leave += new System.EventHandler(this.TBDescuento_Leave);
            // 
            // TBValorFinal
            // 
            this.TBValorFinal.BackColor = System.Drawing.Color.Silver;
            this.TBValorFinal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBValorFinal.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorFinal.Location = new System.Drawing.Point(106, 84);
            this.TBValorFinal.Name = "TBValorFinal";
            this.TBValorFinal.Size = new System.Drawing.Size(155, 16);
            this.TBValorFinal.TabIndex = 2;
            this.TBValorFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBSubTotal
            // 
            this.TBSubTotal.BackColor = System.Drawing.Color.Silver;
            this.TBSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBSubTotal.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBSubTotal.Location = new System.Drawing.Point(106, 32);
            this.TBSubTotal.Name = "TBSubTotal";
            this.TBSubTotal.Size = new System.Drawing.Size(155, 16);
            this.TBSubTotal.TabIndex = 0;
            this.TBSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DGDetalles
            // 
            this.DGDetalles.AllowUserToAddRows = false;
            this.DGDetalles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGDetalles.BackgroundColor = System.Drawing.Color.White;
            this.DGDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDetalles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGDetalles.Location = new System.Drawing.Point(6, 162);
            this.DGDetalles.Name = "DGDetalles";
            this.DGDetalles.RowHeadersVisible = false;
            this.DGDetalles.Size = new System.Drawing.Size(791, 333);
            this.DGDetalles.TabIndex = 177;
            this.DGDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGDetalles_CellContentClick);
            this.DGDetalles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGDetalles_CellEndEdit);
            // 
            // btnExaminar_Producto
            // 
            this.btnExaminar_Producto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExaminar_Producto.BackgroundImage")));
            this.btnExaminar_Producto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Producto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Producto.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Producto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Producto.Location = new System.Drawing.Point(497, 105);
            this.btnExaminar_Producto.Name = "btnExaminar_Producto";
            this.btnExaminar_Producto.Size = new System.Drawing.Size(25, 22);
            this.btnExaminar_Producto.TabIndex = 176;
            this.btnExaminar_Producto.UseVisualStyleBackColor = true;
            this.btnExaminar_Producto.Click += new System.EventHandler(this.btnExaminar_Producto_Click);
            // 
            // btnExaminar_Bodega
            // 
            this.btnExaminar_Bodega.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExaminar_Bodega.BackgroundImage")));
            this.btnExaminar_Bodega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Bodega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Bodega.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Bodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Bodega.Location = new System.Drawing.Point(497, 77);
            this.btnExaminar_Bodega.Name = "btnExaminar_Bodega";
            this.btnExaminar_Bodega.Size = new System.Drawing.Size(25, 22);
            this.btnExaminar_Bodega.TabIndex = 175;
            this.btnExaminar_Bodega.UseVisualStyleBackColor = true;
            this.btnExaminar_Bodega.Click += new System.EventHandler(this.btnExaminar_Bodega_Click);
            // 
            // TBCodigo_Bodega
            // 
            this.TBCodigo_Bodega.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Bodega.Location = new System.Drawing.Point(75, 77);
            this.TBCodigo_Bodega.Name = "TBCodigo_Bodega";
            this.TBCodigo_Bodega.Size = new System.Drawing.Size(140, 22);
            this.TBCodigo_Bodega.TabIndex = 7;
            this.TBCodigo_Bodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo_Bodega.Enter += new System.EventHandler(this.TBCodigo_Bodega_Enter);
            this.TBCodigo_Bodega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCodigo_Bodega_KeyPress);
            this.TBCodigo_Bodega.Leave += new System.EventHandler(this.TBCodigo_Bodega_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bodega";
            // 
            // TBCodigo_Proveedor
            // 
            this.TBCodigo_Proveedor.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Proveedor.Location = new System.Drawing.Point(75, 49);
            this.TBCodigo_Proveedor.Name = "TBCodigo_Proveedor";
            this.TBCodigo_Proveedor.Size = new System.Drawing.Size(140, 22);
            this.TBCodigo_Proveedor.TabIndex = 3;
            this.TBCodigo_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo_Proveedor.Enter += new System.EventHandler(this.TBCodigo_Proveedor_Enter);
            this.TBCodigo_Proveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCodigo_Proveedor_KeyPress);
            this.TBCodigo_Proveedor.Leave += new System.EventHandler(this.TBCodigo_Proveedor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proveedor";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo.Location = new System.Drawing.Point(75, 21);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(140, 22);
            this.TBCodigo.TabIndex = 1;
            this.TBCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo.Enter += new System.EventHandler(this.TBCodigo_Enter);
            this.TBCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCodigo_KeyPress);
            this.TBCodigo.Leave += new System.EventHandler(this.TBCodigo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // TBIdbodega
            // 
            this.TBIdbodega.Location = new System.Drawing.Point(164, 502);
            this.TBIdbodega.Name = "TBIdbodega";
            this.TBIdbodega.Size = new System.Drawing.Size(10, 22);
            this.TBIdbodega.TabIndex = 198;
            // 
            // TBIdproveedor
            // 
            this.TBIdproveedor.Location = new System.Drawing.Point(212, 502);
            this.TBIdproveedor.Name = "TBIdproveedor";
            this.TBIdproveedor.Size = new System.Drawing.Size(10, 22);
            this.TBIdproveedor.TabIndex = 197;
            // 
            // TBIddetalle
            // 
            this.TBIddetalle.Location = new System.Drawing.Point(196, 502);
            this.TBIddetalle.Name = "TBIddetalle";
            this.TBIddetalle.Size = new System.Drawing.Size(10, 22);
            this.TBIddetalle.TabIndex = 196;
            // 
            // TBIdproducto
            // 
            this.TBIdproducto.Location = new System.Drawing.Point(180, 502);
            this.TBIdproducto.Name = "TBIdproducto";
            this.TBIdproducto.Size = new System.Drawing.Size(10, 22);
            this.TBIdproducto.TabIndex = 195;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnEliminar_Resultados);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.DGResultados);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.CBFechas);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TBBuscar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TBIdbodega);
            this.groupBox2.Controls.Add(this.TBIdproducto);
            this.groupBox2.Controls.Add(this.TBIdproveedor);
            this.groupBox2.Controls.Add(this.TBIddetalle);
            this.groupBox2.Location = new System.Drawing.Point(822, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 537);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consulta de Cotizacion de Compra - Leal Enterprise";
            // 
            // btnEliminar_Resultados
            // 
            this.btnEliminar_Resultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_Resultados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar_Resultados.FlatAppearance.BorderSize = 0;
            this.btnEliminar_Resultados.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar_Resultados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar_Resultados.Location = new System.Drawing.Point(241, 498);
            this.btnEliminar_Resultados.Name = "btnEliminar_Resultados";
            this.btnEliminar_Resultados.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar_Resultados.TabIndex = 192;
            this.btnEliminar_Resultados.Text = "Eliminar - F4";
            this.btnEliminar_Resultados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar_Resultados.UseVisualStyleBackColor = true;
            this.btnEliminar_Resultados.Click += new System.EventHandler(this.btnEliminar_Resultados_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 505);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(116, 17);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Datos Registrados: ";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Image = global::Presentacion.Botones.btnImprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(367, 498);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 30);
            this.btnImprimir.TabIndex = 193;
            this.btnImprimir.Text = "Imprimir - F11";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // DGResultados
            // 
            this.DGResultados.AllowUserToAddRows = false;
            this.DGResultados.AllowUserToDeleteRows = false;
            this.DGResultados.BackgroundColor = System.Drawing.Color.White;
            this.DGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGResultados.Location = new System.Drawing.Point(6, 105);
            this.DGResultados.Name = "DGResultados";
            this.DGResultados.ReadOnly = true;
            this.DGResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultados.Size = new System.Drawing.Size(481, 387);
            this.DGResultados.TabIndex = 8;
            this.DGResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGResultados_CellDoubleClick);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(293, 77);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 22);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 77);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // CBFechas
            // 
            this.CBFechas.AutoSize = true;
            this.CBFechas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFechas.Location = new System.Drawing.Point(144, 53);
            this.CBFechas.Name = "CBFechas";
            this.CBFechas.Size = new System.Drawing.Size(55, 17);
            this.CBFechas.TabIndex = 3;
            this.CBFechas.Text = "Si - No";
            this.CBFechas.UseVisualStyleBackColor = true;
            this.CBFechas.CheckedChanged += new System.EventHandler(this.CBFechas_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Consulta entre Fechas";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(140, 23);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(347, 22);
            this.TBBuscar.TabIndex = 1;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cotización de Compra";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 199;
            this.label7.Text = "Fecha Inicial";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 200;
            this.label8.Text = "Fecha Final";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(419, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 22);
            this.button1.TabIndex = 216;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CBLista
            // 
            this.CBLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBLista.FormattingEnabled = true;
            this.CBLista.Location = new System.Drawing.Point(487, 133);
            this.CBLista.Name = "CBLista";
            this.CBLista.Size = new System.Drawing.Size(310, 23);
            this.CBLista.TabIndex = 217;
            // 
            // CHProveedor
            // 
            this.CHProveedor.AutoSize = true;
            this.CHProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CHProveedor.Location = new System.Drawing.Point(221, 134);
            this.CHProveedor.Name = "CHProveedor";
            this.CHProveedor.Size = new System.Drawing.Size(134, 21);
            this.CHProveedor.TabIndex = 218;
            this.CHProveedor.Text = "Lista por Proveedor";
            this.CHProveedor.UseVisualStyleBackColor = true;
            this.CHProveedor.CheckedChanged += new System.EventHandler(this.CHProveedor_CheckedChanged);
            // 
            // CHBodega
            // 
            this.CHBodega.AutoSize = true;
            this.CHBodega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CHBodega.Location = new System.Drawing.Point(361, 135);
            this.CHBodega.Name = "CHBodega";
            this.CHBodega.Size = new System.Drawing.Size(120, 21);
            this.CHBodega.TabIndex = 219;
            this.CHBodega.Text = "Lista por Bodega";
            this.CHBodega.UseVisualStyleBackColor = true;
            this.CHBodega.CheckedChanged += new System.EventHandler(this.CHBodega_CheckedChanged);
            // 
            // frmCotizacionDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1327, 563);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmCotizacionDeCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archivo - Cotizacion de Compra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCotizacionDeCompra_FormClosing);
            this.Load += new System.EventHandler(this.frmCotizacionDeCompra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBCodigo_Proveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBCodigo_Bodega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExaminar_Producto;
        private System.Windows.Forms.Button btnExaminar_Bodega;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGDetalles;
        private System.Windows.Forms.TextBox TBBodega;
        private System.Windows.Forms.TextBox TBProveedor;
        private System.Windows.Forms.TextBox TBOrdendecompra;
        private System.Windows.Forms.Button btnExaminar_Proveedor;
        private System.Windows.Forms.TextBox TBProducto;
        private System.Windows.Forms.TextBox TBCodigo_Producto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox CBFechas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar_Detalles;
        private System.Windows.Forms.Button btnEliminar_Resultados;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblTotal_Detalles;
        public System.Windows.Forms.TextBox TBIdbodega;
        public System.Windows.Forms.TextBox TBIdproveedor;
        public System.Windows.Forms.TextBox TBIddetalle;
        public System.Windows.Forms.TextBox TBIdproducto;
        private System.Windows.Forms.ComboBox CBTipodepago;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox TBValorFinal;
        public System.Windows.Forms.TextBox TBSubTotal;
        public System.Windows.Forms.TextBox TBDescuento;
        private System.Windows.Forms.TextBox TBIdordendecompra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CBLista;
        private System.Windows.Forms.CheckBox CHBodega;
        private System.Windows.Forms.CheckBox CHProveedor;
    }
}