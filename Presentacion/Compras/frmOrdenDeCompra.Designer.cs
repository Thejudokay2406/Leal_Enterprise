namespace Presentacion
{
    partial class frmOrdenDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenDeCompra));
            this.TBCotizacion = new System.Windows.Forms.TextBox();
            this.TBIdbodega = new System.Windows.Forms.TextBox();
            this.TBIdproveedor = new System.Windows.Forms.TextBox();
            this.TBIddetalle = new System.Windows.Forms.TextBox();
            this.TBIdproducto = new System.Windows.Forms.TextBox();
            this.lblTotal_Detalles = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TBGrupo = new System.Windows.Forms.TextBox();
            this.TBStock = new System.Windows.Forms.TextBox();
            this.TBProducto = new System.Windows.Forms.TextBox();
            this.DGDetalleDeIngreso = new System.Windows.Forms.DataGridView();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBCodigo_Producto = new System.Windows.Forms.TextBox();
            this.TBProveedor = new System.Windows.Forms.TextBox();
            this.TBCodigo_Proveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrecios = new System.Windows.Forms.Button();
            this.TBCreditoDisponible = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBCreditoEnMora = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBTipodepago = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TBIdcotizacion = new System.Windows.Forms.TextBox();
            this.TBIdordendecompra = new System.Windows.Forms.TextBox();
            this.btnExaminar_Cotizacion = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.TBValorCompra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBValorVenta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TBValorPromedio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.TBMarca = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBValorCompra_Final = new System.Windows.Forms.TextBox();
            this.TBValorCotizado = new System.Windows.Forms.TextBox();
            this.TBCodigo_Bodega = new System.Windows.Forms.TextBox();
            this.btnExaminar_Bodega = new System.Windows.Forms.Button();
            this.TBBodega = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnExaminar_Proveedor = new System.Windows.Forms.Button();
            this.btnExaminar_Producto = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminar_Resultados = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CBFechas = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Medida = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalleDeIngreso)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // TBCotizacion
            // 
            this.TBCotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCotizacion.Location = new System.Drawing.Point(285, 20);
            this.TBCotizacion.Name = "TBCotizacion";
            this.TBCotizacion.Size = new System.Drawing.Size(210, 21);
            this.TBCotizacion.TabIndex = 175;
            this.TBCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCotizacion.Enter += new System.EventHandler(this.TBDescripcion_Enter);
            this.TBCotizacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCotizacion_KeyPress);
            this.TBCotizacion.Leave += new System.EventHandler(this.TBDescripcion_Leave);
            // 
            // TBIdbodega
            // 
            this.TBIdbodega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBIdbodega.Location = new System.Drawing.Point(223, 455);
            this.TBIdbodega.Name = "TBIdbodega";
            this.TBIdbodega.Size = new System.Drawing.Size(10, 21);
            this.TBIdbodega.TabIndex = 118;
            // 
            // TBIdproveedor
            // 
            this.TBIdproveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBIdproveedor.Location = new System.Drawing.Point(271, 455);
            this.TBIdproveedor.Name = "TBIdproveedor";
            this.TBIdproveedor.Size = new System.Drawing.Size(10, 21);
            this.TBIdproveedor.TabIndex = 117;
            // 
            // TBIddetalle
            // 
            this.TBIddetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBIddetalle.Location = new System.Drawing.Point(255, 455);
            this.TBIddetalle.Name = "TBIddetalle";
            this.TBIddetalle.Size = new System.Drawing.Size(10, 21);
            this.TBIddetalle.TabIndex = 116;
            this.TBIddetalle.TextChanged += new System.EventHandler(this.TBIddetalle_TextChanged);
            // 
            // TBIdproducto
            // 
            this.TBIdproducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBIdproducto.Location = new System.Drawing.Point(239, 455);
            this.TBIdproducto.Name = "TBIdproducto";
            this.TBIdproducto.Size = new System.Drawing.Size(10, 21);
            this.TBIdproducto.TabIndex = 115;
            this.TBIdproducto.TextChanged += new System.EventHandler(this.TBIdproducto_TextChanged);
            // 
            // lblTotal_Detalles
            // 
            this.lblTotal_Detalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal_Detalles.AutoSize = true;
            this.lblTotal_Detalles.Location = new System.Drawing.Point(516, 458);
            this.lblTotal_Detalles.Name = "lblTotal_Detalles";
            this.lblTotal_Detalles.Size = new System.Drawing.Size(68, 15);
            this.lblTotal_Detalles.TabIndex = 118;
            this.lblTotal_Detalles.Text = "Productos: ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 157;
            this.label2.Text = "Marca";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 444);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 15);
            this.label31.TabIndex = 165;
            this.label31.Text = "Grupo";
            // 
            // TBGrupo
            // 
            this.TBGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBGrupo.Location = new System.Drawing.Point(54, 441);
            this.TBGrupo.Name = "TBGrupo";
            this.TBGrupo.Size = new System.Drawing.Size(160, 21);
            this.TBGrupo.TabIndex = 164;
            this.TBGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBStock
            // 
            this.TBStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBStock.Location = new System.Drawing.Point(54, 468);
            this.TBStock.Name = "TBStock";
            this.TBStock.Size = new System.Drawing.Size(160, 21);
            this.TBStock.TabIndex = 162;
            this.TBStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBProducto
            // 
            this.TBProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProducto.Location = new System.Drawing.Point(215, 101);
            this.TBProducto.Name = "TBProducto";
            this.TBProducto.Size = new System.Drawing.Size(280, 21);
            this.TBProducto.TabIndex = 150;
            this.TBProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DGDetalleDeIngreso
            // 
            this.DGDetalleDeIngreso.AllowUserToAddRows = false;
            this.DGDetalleDeIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGDetalleDeIngreso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGDetalleDeIngreso.BackgroundColor = System.Drawing.Color.White;
            this.DGDetalleDeIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Medida});
            this.DGDetalleDeIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGDetalleDeIngreso.Location = new System.Drawing.Point(6, 155);
            this.DGDetalleDeIngreso.Name = "DGDetalleDeIngreso";
            this.DGDetalleDeIngreso.RowHeadersVisible = false;
            this.DGDetalleDeIngreso.Size = new System.Drawing.Size(795, 253);
            this.DGDetalleDeIngreso.TabIndex = 141;
            this.DGDetalleDeIngreso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGDetalleDeIngreso_CellClick);
            this.DGDetalleDeIngreso.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGDetalleDeIngreso_CellEndEdit);
            // 
            // TBCodigo
            // 
            this.TBCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo.Location = new System.Drawing.Point(69, 20);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(140, 21);
            this.TBCodigo.TabIndex = 139;
            this.TBCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo.Enter += new System.EventHandler(this.TBCodigo_Enter);
            this.TBCodigo.Leave += new System.EventHandler(this.TBCodigo_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 138;
            this.label7.Text = "Codigo";
            // 
            // TBCodigo_Producto
            // 
            this.TBCodigo_Producto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCodigo_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Producto.Location = new System.Drawing.Point(69, 101);
            this.TBCodigo_Producto.Name = "TBCodigo_Producto";
            this.TBCodigo_Producto.Size = new System.Drawing.Size(140, 21);
            this.TBCodigo_Producto.TabIndex = 130;
            this.TBCodigo_Producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo_Producto.Enter += new System.EventHandler(this.TBCodigo_Producto_Enter);
            this.TBCodigo_Producto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCodigo_Producto_KeyPress);
            this.TBCodigo_Producto.Leave += new System.EventHandler(this.TBCodigo_Producto_Leave);
            // 
            // TBProveedor
            // 
            this.TBProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProveedor.Location = new System.Drawing.Point(215, 47);
            this.TBProveedor.Name = "TBProveedor";
            this.TBProveedor.Size = new System.Drawing.Size(280, 21);
            this.TBProveedor.TabIndex = 126;
            this.TBProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCodigo_Proveedor
            // 
            this.TBCodigo_Proveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCodigo_Proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Proveedor.Location = new System.Drawing.Point(69, 47);
            this.TBCodigo_Proveedor.Name = "TBCodigo_Proveedor";
            this.TBCodigo_Proveedor.Size = new System.Drawing.Size(140, 21);
            this.TBCodigo_Proveedor.TabIndex = 125;
            this.TBCodigo_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo_Proveedor.Enter += new System.EventHandler(this.TBCodigo_Proveedor_Enter);
            this.TBCodigo_Proveedor.Leave += new System.EventHandler(this.TBCodigo_Proveedor_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "Proveedor";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 106;
            this.label6.Text = "Producto";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnPrecios);
            this.groupBox1.Controls.Add(this.TBCreditoDisponible);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TBCreditoEnMora);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CBTipodepago);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.TBIdcotizacion);
            this.groupBox1.Controls.Add(this.TBIdordendecompra);
            this.groupBox1.Controls.Add(this.btnExaminar_Cotizacion);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.TBValorCompra);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TBValorVenta);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.TBValorPromedio);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.TBMarca);
            this.groupBox1.Controls.Add(this.TBGrupo);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.TBStock);
            this.groupBox1.Controls.Add(this.TBCodigo_Bodega);
            this.groupBox1.Controls.Add(this.btnExaminar_Bodega);
            this.groupBox1.Controls.Add(this.TBBodega);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblTotal_Detalles);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TBCodigo_Proveedor);
            this.groupBox1.Controls.Add(this.TBProveedor);
            this.groupBox1.Controls.Add(this.btnExaminar_Proveedor);
            this.groupBox1.Controls.Add(this.TBCodigo_Producto);
            this.groupBox1.Controls.Add(this.btnExaminar_Producto);
            this.groupBox1.Controls.Add(this.TBCotizacion);
            this.groupBox1.Controls.Add(this.TBCodigo);
            this.groupBox1.Controls.Add(this.DGDetalleDeIngreso);
            this.groupBox1.Controls.Add(this.TBProducto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 497);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Ordenes de Compra - Leal Enterprise";
            // 
            // btnPrecios
            // 
            this.btnPrecios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrecios.BackColor = System.Drawing.Color.Transparent;
            this.btnPrecios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrecios.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrecios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrecios.Image = global::Presentacion.Botones.btnPrecios;
            this.btnPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrecios.Location = new System.Drawing.Point(711, 414);
            this.btnPrecios.Name = "btnPrecios";
            this.btnPrecios.Size = new System.Drawing.Size(90, 30);
            this.btnPrecios.TabIndex = 219;
            this.btnPrecios.Text = "Precios";
            this.btnPrecios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrecios.UseVisualStyleBackColor = false;
            this.btnPrecios.Click += new System.EventHandler(this.btnPrecios_Click);
            // 
            // TBCreditoDisponible
            // 
            this.TBCreditoDisponible.Location = new System.Drawing.Point(605, 128);
            this.TBCreditoDisponible.Name = "TBCreditoDisponible";
            this.TBCreditoDisponible.Size = new System.Drawing.Size(196, 21);
            this.TBCreditoDisponible.TabIndex = 218;
            this.TBCreditoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 217;
            this.label3.Text = "Credito Disp.";
            // 
            // TBCreditoEnMora
            // 
            this.TBCreditoEnMora.Location = new System.Drawing.Point(316, 128);
            this.TBCreditoEnMora.Name = "TBCreditoEnMora";
            this.TBCreditoEnMora.Size = new System.Drawing.Size(200, 21);
            this.TBCreditoEnMora.TabIndex = 216;
            this.TBCreditoEnMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 215;
            this.label4.Text = "Credito en Mora";
            // 
            // CBTipodepago
            // 
            this.CBTipodepago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBTipodepago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipodepago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTipodepago.FormattingEnabled = true;
            this.CBTipodepago.Location = new System.Drawing.Point(69, 128);
            this.CBTipodepago.Name = "CBTipodepago";
            this.CBTipodepago.Size = new System.Drawing.Size(140, 21);
            this.CBTipodepago.Sorted = true;
            this.CBTipodepago.TabIndex = 214;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 15);
            this.label20.TabIndex = 213;
            this.label20.Text = "Pago";
            // 
            // TBIdcotizacion
            // 
            this.TBIdcotizacion.Location = new System.Drawing.Point(609, 455);
            this.TBIdcotizacion.Name = "TBIdcotizacion";
            this.TBIdcotizacion.Size = new System.Drawing.Size(13, 21);
            this.TBIdcotizacion.TabIndex = 212;
            this.TBIdcotizacion.TextChanged += new System.EventHandler(this.TBIdcotizacion_TextChanged);
            // 
            // TBIdordendecompra
            // 
            this.TBIdordendecompra.Location = new System.Drawing.Point(590, 455);
            this.TBIdordendecompra.Name = "TBIdordendecompra";
            this.TBIdordendecompra.Size = new System.Drawing.Size(13, 21);
            this.TBIdordendecompra.TabIndex = 211;
            this.TBIdordendecompra.TextChanged += new System.EventHandler(this.TBIdordendecompra_TextChanged);
            // 
            // btnExaminar_Cotizacion
            // 
            this.btnExaminar_Cotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar_Cotizacion.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.btnExaminar_Cotizacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Cotizacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Cotizacion.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Cotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Cotizacion.Location = new System.Drawing.Point(500, 20);
            this.btnExaminar_Cotizacion.Name = "btnExaminar_Cotizacion";
            this.btnExaminar_Cotizacion.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Cotizacion.TabIndex = 210;
            this.btnExaminar_Cotizacion.UseVisualStyleBackColor = true;
            this.btnExaminar_Cotizacion.Click += new System.EventHandler(this.btnExaminar_Cotizacion_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(215, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 15);
            this.label19.TabIndex = 209;
            this.label19.Text = "Cotización";
            // 
            // TBValorCompra
            // 
            this.TBValorCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBValorCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorCompra.Location = new System.Drawing.Point(325, 441);
            this.TBValorCompra.Name = "TBValorCompra";
            this.TBValorCompra.Size = new System.Drawing.Size(160, 21);
            this.TBValorCompra.TabIndex = 205;
            this.TBValorCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 206;
            this.label5.Text = "Valor de Compra";
            // 
            // TBValorVenta
            // 
            this.TBValorVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBValorVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorVenta.Location = new System.Drawing.Point(325, 468);
            this.TBValorVenta.Name = "TBValorVenta";
            this.TBValorVenta.Size = new System.Drawing.Size(160, 21);
            this.TBValorVenta.TabIndex = 201;
            this.TBValorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 417);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 15);
            this.label14.TabIndex = 204;
            this.label14.Text = "Valor Promedio";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 471);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 15);
            this.label15.TabIndex = 202;
            this.label15.Text = "Valor de Venta";
            // 
            // TBValorPromedio
            // 
            this.TBValorPromedio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBValorPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorPromedio.Location = new System.Drawing.Point(325, 414);
            this.TBValorPromedio.Name = "TBValorPromedio";
            this.TBValorPromedio.Size = new System.Drawing.Size(160, 21);
            this.TBValorPromedio.TabIndex = 203;
            this.TBValorPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 471);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 198;
            this.label8.Text = "Stock";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(519, 414);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 176;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(615, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 181;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(711, 450);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 180;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Datos_Click);
            // 
            // TBMarca
            // 
            this.TBMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMarca.Location = new System.Drawing.Point(54, 414);
            this.TBMarca.Name = "TBMarca";
            this.TBMarca.Size = new System.Drawing.Size(160, 21);
            this.TBMarca.TabIndex = 156;
            this.TBMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.TBValorCompra_Final);
            this.panel1.Controls.Add(this.TBValorCotizado);
            this.panel1.Location = new System.Drawing.Point(531, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 102);
            this.panel1.TabIndex = 196;
            // 
            // TBValorCompra_Final
            // 
            this.TBValorCompra_Final.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBValorCompra_Final.BackColor = System.Drawing.Color.Silver;
            this.TBValorCompra_Final.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBValorCompra_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorCompra_Final.Location = new System.Drawing.Point(114, 77);
            this.TBValorCompra_Final.Name = "TBValorCompra_Final";
            this.TBValorCompra_Final.Size = new System.Drawing.Size(150, 19);
            this.TBValorCompra_Final.TabIndex = 2;
            this.TBValorCompra_Final.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBValorCotizado
            // 
            this.TBValorCotizado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBValorCotizado.BackColor = System.Drawing.Color.Silver;
            this.TBValorCotizado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBValorCotizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorCotizado.Location = new System.Drawing.Point(114, 44);
            this.TBValorCotizado.Name = "TBValorCotizado";
            this.TBValorCotizado.Size = new System.Drawing.Size(150, 19);
            this.TBValorCotizado.TabIndex = 1;
            this.TBValorCotizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCodigo_Bodega
            // 
            this.TBCodigo_Bodega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCodigo_Bodega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Bodega.Location = new System.Drawing.Point(69, 74);
            this.TBCodigo_Bodega.Name = "TBCodigo_Bodega";
            this.TBCodigo_Bodega.Size = new System.Drawing.Size(140, 21);
            this.TBCodigo_Bodega.TabIndex = 194;
            this.TBCodigo_Bodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCodigo_Bodega.Enter += new System.EventHandler(this.TBCodigo_Bodega_Enter);
            this.TBCodigo_Bodega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCodigo_Bodega_KeyPress);
            this.TBCodigo_Bodega.Leave += new System.EventHandler(this.TBCodigo_Bodega_Leave);
            // 
            // btnExaminar_Bodega
            // 
            this.btnExaminar_Bodega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar_Bodega.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.btnExaminar_Bodega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Bodega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Bodega.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Bodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Bodega.Location = new System.Drawing.Point(500, 74);
            this.btnExaminar_Bodega.Name = "btnExaminar_Bodega";
            this.btnExaminar_Bodega.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Bodega.TabIndex = 190;
            this.btnExaminar_Bodega.UseVisualStyleBackColor = true;
            this.btnExaminar_Bodega.Click += new System.EventHandler(this.btnExaminar_Bodega_Click);
            // 
            // TBBodega
            // 
            this.TBBodega.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBodega.Location = new System.Drawing.Point(215, 74);
            this.TBBodega.Name = "TBBodega";
            this.TBBodega.Size = new System.Drawing.Size(280, 21);
            this.TBBodega.TabIndex = 189;
            this.TBBodega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 15);
            this.label16.TabIndex = 188;
            this.label16.Text = "Bodega";
            // 
            // btnExaminar_Proveedor
            // 
            this.btnExaminar_Proveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar_Proveedor.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.btnExaminar_Proveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Proveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Proveedor.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Proveedor.Location = new System.Drawing.Point(500, 47);
            this.btnExaminar_Proveedor.Name = "btnExaminar_Proveedor";
            this.btnExaminar_Proveedor.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Proveedor.TabIndex = 129;
            this.btnExaminar_Proveedor.UseVisualStyleBackColor = true;
            this.btnExaminar_Proveedor.Click += new System.EventHandler(this.btnExaminar_Proveedor_Click);
            // 
            // btnExaminar_Producto
            // 
            this.btnExaminar_Producto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar_Producto.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.btnExaminar_Producto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Producto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Producto.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Producto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Producto.Location = new System.Drawing.Point(500, 101);
            this.btnExaminar_Producto.Name = "btnExaminar_Producto";
            this.btnExaminar_Producto.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Producto.TabIndex = 131;
            this.btnExaminar_Producto.UseVisualStyleBackColor = true;
            this.btnExaminar_Producto.Click += new System.EventHandler(this.btnExaminar_Producto_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnEliminar_Resultados);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.DGResultados);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.CBFechas);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.TBBuscar);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TBIdproveedor);
            this.groupBox2.Controls.Add(this.TBIdproducto);
            this.groupBox2.Controls.Add(this.TBIdbodega);
            this.groupBox2.Controls.Add(this.TBIddetalle);
            this.groupBox2.Location = new System.Drawing.Point(828, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 497);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consulta de Cotizacion de Compra - Leal Enterprise";
            // 
            // btnEliminar_Resultados
            // 
            this.btnEliminar_Resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar_Resultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_Resultados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar_Resultados.FlatAppearance.BorderSize = 0;
            this.btnEliminar_Resultados.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar_Resultados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar_Resultados.Location = new System.Drawing.Point(301, 450);
            this.btnEliminar_Resultados.Name = "btnEliminar_Resultados";
            this.btnEliminar_Resultados.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar_Resultados.TabIndex = 192;
            this.btnEliminar_Resultados.Text = "Eliminar";
            this.btnEliminar_Resultados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar_Resultados.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 458);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Datos Registrados en el Sistema: ";
            // 
            // DGResultados
            // 
            this.DGResultados.AllowUserToAddRows = false;
            this.DGResultados.AllowUserToDeleteRows = false;
            this.DGResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGResultados.BackgroundColor = System.Drawing.Color.White;
            this.DGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGResultados.Location = new System.Drawing.Point(6, 74);
            this.DGResultados.Name = "DGResultados";
            this.DGResultados.ReadOnly = true;
            this.DGResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultados.Size = new System.Drawing.Size(481, 370);
            this.DGResultados.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(386, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(252, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Fin";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(210, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "Inicio";
            // 
            // CBFechas
            // 
            this.CBFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBFechas.AutoSize = true;
            this.CBFechas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBFechas.Location = new System.Drawing.Point(141, 47);
            this.CBFechas.Name = "CBFechas";
            this.CBFechas.Size = new System.Drawing.Size(55, 17);
            this.CBFechas.TabIndex = 3;
            this.CBFechas.Text = "Si - No";
            this.CBFechas.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Consulta entre Fechas";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Image = global::Presentacion.Botones.btnImprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(397, 450);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 30);
            this.btnImprimir.TabIndex = 187;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar.Location = new System.Drawing.Point(140, 20);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(347, 21);
            this.TBBuscar.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Cotización de Compra";
            // 
            // Medida
            // 
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            // 
            // frmOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 520);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmOrdenDeCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras - Orden de Compra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrdenDeCompra_FormClosing);
            this.Load += new System.EventHandler(this.frmOrdenDeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalleDeIngreso)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TBGrupo;
        private System.Windows.Forms.TextBox TBStock;
        public System.Windows.Forms.TextBox TBIdbodega;
        public System.Windows.Forms.TextBox TBIdproveedor;
        public System.Windows.Forms.TextBox TBIddetalle;
        public System.Windows.Forms.TextBox TBIdproducto;
        private System.Windows.Forms.Label lblTotal_Detalles;
        private System.Windows.Forms.TextBox TBProducto;
        public System.Windows.Forms.DataGridView DGDetalleDeIngreso;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExaminar_Producto;
        public System.Windows.Forms.TextBox TBCodigo_Producto;
        private System.Windows.Forms.Button btnExaminar_Proveedor;
        private System.Windows.Forms.TextBox TBProveedor;
        private System.Windows.Forms.TextBox TBCodigo_Proveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBCotizacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExaminar_Bodega;
        private System.Windows.Forms.TextBox TBBodega;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox TBCodigo_Bodega;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBValorCompra_Final;
        private System.Windows.Forms.TextBox TBValorCotizado;
        private System.Windows.Forms.TextBox TBMarca;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminar_Resultados;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox CBFechas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TBValorCompra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBValorVenta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TBValorPromedio;
        private System.Windows.Forms.Button btnExaminar_Cotizacion;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TBIdordendecompra;
        private System.Windows.Forms.TextBox TBIdcotizacion;
        public System.Windows.Forms.TextBox TBCreditoDisponible;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TBCreditoEnMora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBTipodepago;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnPrecios;
        private System.Windows.Forms.DataGridViewComboBoxColumn Medida;
    }
}