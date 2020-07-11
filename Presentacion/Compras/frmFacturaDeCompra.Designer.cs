namespace Presentacion
{
    partial class frmFacturaDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturaDeCompra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBValorVenta_Final = new System.Windows.Forms.TextBox();
            this.TBCreditoDisponible = new System.Windows.Forms.TextBox();
            this.TBValorCompra_Final = new System.Windows.Forms.TextBox();
            this.TBValorPromedio_Final = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.CBOperacion = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.TBIdbodega = new System.Windows.Forms.TextBox();
            this.TBIdproveedor = new System.Windows.Forms.TextBox();
            this.TBCodigo_Proveedor = new System.Windows.Forms.TextBox();
            this.TBIddetalle = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.TBIdproducto = new System.Windows.Forms.TextBox();
            this.TBProveedor = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TBCodigo_Producto = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TBOrdendecompra = new System.Windows.Forms.TextBox();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DGDetalleDeIngreso = new System.Windows.Forms.DataGridView();
            this.TBProducto = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExaminar_Ubucacion = new System.Windows.Forms.Button();
            this.TBUnidad_Valor = new System.Windows.Forms.TextBox();
            this.TBUnidad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TBNivel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TBEstante = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TBMarca = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TBUbicacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TBCompraPromedio = new System.Windows.Forms.TextBox();
            this.TBVentaMayorista = new System.Windows.Forms.TextBox();
            this.TBCompraFinal = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TBValorVenta_SinImpuesto = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TBValorVenta = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalleDeIngreso)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.CBOperacion);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.TBIdbodega);
            this.groupBox1.Controls.Add(this.TBIdproveedor);
            this.groupBox1.Controls.Add(this.TBCodigo_Proveedor);
            this.groupBox1.Controls.Add(this.TBIddetalle);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.TBIdproducto);
            this.groupBox1.Controls.Add(this.TBProveedor);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.TBCodigo_Producto);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.TBOrdendecompra);
            this.groupBox1.Controls.Add(this.TBCodigo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DGDetalleDeIngreso);
            this.groupBox1.Controls.Add(this.TBProducto);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 523);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Ordenes de Compra - Leal Enterprise";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.TBValorVenta_Final);
            this.panel1.Controls.Add(this.TBCreditoDisponible);
            this.panel1.Controls.Add(this.TBValorCompra_Final);
            this.panel1.Controls.Add(this.TBValorPromedio_Final);
            this.panel1.Location = new System.Drawing.Point(745, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 120);
            this.panel1.TabIndex = 188;
            // 
            // TBValorVenta_Final
            // 
            this.TBValorVenta_Final.BackColor = System.Drawing.Color.Silver;
            this.TBValorVenta_Final.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBValorVenta_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorVenta_Final.Location = new System.Drawing.Point(180, 100);
            this.TBValorVenta_Final.Name = "TBValorVenta_Final";
            this.TBValorVenta_Final.Size = new System.Drawing.Size(190, 17);
            this.TBValorVenta_Final.TabIndex = 184;
            // 
            // TBCreditoDisponible
            // 
            this.TBCreditoDisponible.BackColor = System.Drawing.Color.Silver;
            this.TBCreditoDisponible.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBCreditoDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCreditoDisponible.Location = new System.Drawing.Point(180, 28);
            this.TBCreditoDisponible.Name = "TBCreditoDisponible";
            this.TBCreditoDisponible.Size = new System.Drawing.Size(190, 17);
            this.TBCreditoDisponible.TabIndex = 183;
            this.TBCreditoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBValorCompra_Final
            // 
            this.TBValorCompra_Final.BackColor = System.Drawing.Color.Silver;
            this.TBValorCompra_Final.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBValorCompra_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorCompra_Final.Location = new System.Drawing.Point(180, 76);
            this.TBValorCompra_Final.Name = "TBValorCompra_Final";
            this.TBValorCompra_Final.Size = new System.Drawing.Size(190, 17);
            this.TBValorCompra_Final.TabIndex = 170;
            this.TBValorCompra_Final.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBValorPromedio_Final
            // 
            this.TBValorPromedio_Final.BackColor = System.Drawing.Color.Silver;
            this.TBValorPromedio_Final.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBValorPromedio_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorPromedio_Final.Location = new System.Drawing.Point(180, 52);
            this.TBValorPromedio_Final.Name = "TBValorPromedio_Final";
            this.TBValorPromedio_Final.Size = new System.Drawing.Size(190, 17);
            this.TBValorPromedio_Final.TabIndex = 169;
            this.TBValorPromedio_Final.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Image = global::Presentacion.Botones.btnImprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(1038, 486);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 30);
            this.btnImprimir.TabIndex = 187;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // CBOperacion
            // 
            this.CBOperacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBOperacion.FormattingEnabled = true;
            this.CBOperacion.Items.AddRange(new object[] {
            "-",
            "Consulta",
            "Registro"});
            this.CBOperacion.Location = new System.Drawing.Point(896, 18);
            this.CBOperacion.Name = "CBOperacion";
            this.CBOperacion.Size = new System.Drawing.Size(195, 21);
            this.CBOperacion.TabIndex = 186;
            this.CBOperacion.SelectedIndexChanged += new System.EventHandler(this.CBOperacion_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(782, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 15);
            this.label12.TabIndex = 185;
            this.label12.Text = "Tipo de Operación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 138;
            this.label7.Text = "Codigo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 106;
            this.label6.Text = "Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "Proveedor";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(942, 486);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 181;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // TBIdbodega
            // 
            this.TBIdbodega.Location = new System.Drawing.Point(1022, 47);
            this.TBIdbodega.Name = "TBIdbodega";
            this.TBIdbodega.Size = new System.Drawing.Size(10, 21);
            this.TBIdbodega.TabIndex = 118;
            // 
            // TBIdproveedor
            // 
            this.TBIdproveedor.Location = new System.Drawing.Point(1070, 47);
            this.TBIdproveedor.Name = "TBIdproveedor";
            this.TBIdproveedor.Size = new System.Drawing.Size(10, 21);
            this.TBIdproveedor.TabIndex = 117;
            // 
            // TBCodigo_Proveedor
            // 
            this.TBCodigo_Proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Proveedor.Location = new System.Drawing.Point(69, 45);
            this.TBCodigo_Proveedor.Name = "TBCodigo_Proveedor";
            this.TBCodigo_Proveedor.Size = new System.Drawing.Size(181, 21);
            this.TBCodigo_Proveedor.TabIndex = 125;
            this.TBCodigo_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBIddetalle
            // 
            this.TBIddetalle.Location = new System.Drawing.Point(1054, 47);
            this.TBIddetalle.Name = "TBIddetalle";
            this.TBIddetalle.Size = new System.Drawing.Size(10, 21);
            this.TBIddetalle.TabIndex = 116;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(745, 486);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 176;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // TBIdproducto
            // 
            this.TBIdproducto.Location = new System.Drawing.Point(1038, 47);
            this.TBIdproducto.Name = "TBIdproducto";
            this.TBIdproducto.Size = new System.Drawing.Size(10, 21);
            this.TBIdproducto.TabIndex = 115;
            // 
            // TBProveedor
            // 
            this.TBProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProveedor.Location = new System.Drawing.Point(256, 45);
            this.TBProveedor.Name = "TBProveedor";
            this.TBProveedor.Size = new System.Drawing.Size(520, 21);
            this.TBProveedor.TabIndex = 126;
            this.TBProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(841, 486);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 180;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(863, 44);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker1.TabIndex = 179;
            // 
            // TBCodigo_Producto
            // 
            this.TBCodigo_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo_Producto.Location = new System.Drawing.Point(69, 72);
            this.TBCodigo_Producto.Name = "TBCodigo_Producto";
            this.TBCodigo_Producto.Size = new System.Drawing.Size(181, 21);
            this.TBCodigo_Producto.TabIndex = 130;
            this.TBCodigo_Producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(782, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 15);
            this.label20.TabIndex = 178;
            this.label20.Text = "Vencimiento";
            // 
            // TBOrdendecompra
            // 
            this.TBOrdendecompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBOrdendecompra.Location = new System.Drawing.Point(367, 18);
            this.TBOrdendecompra.Name = "TBOrdendecompra";
            this.TBOrdendecompra.Size = new System.Drawing.Size(409, 21);
            this.TBOrdendecompra.TabIndex = 175;
            // 
            // TBCodigo
            // 
            this.TBCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodigo.Location = new System.Drawing.Point(69, 18);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(181, 21);
            this.TBCodigo.TabIndex = 139;
            this.TBCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 174;
            this.label5.Text = "Orden de Compra";
            // 
            // DGDetalleDeIngreso
            // 
            this.DGDetalleDeIngreso.AllowUserToAddRows = false;
            this.DGDetalleDeIngreso.BackgroundColor = System.Drawing.Color.White;
            this.DGDetalleDeIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDetalleDeIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGDetalleDeIngreso.Location = new System.Drawing.Point(9, 99);
            this.DGDetalleDeIngreso.Name = "DGDetalleDeIngreso";
            this.DGDetalleDeIngreso.RowHeadersVisible = false;
            this.DGDetalleDeIngreso.Size = new System.Drawing.Size(1119, 255);
            this.DGDetalleDeIngreso.TabIndex = 141;
            // 
            // TBProducto
            // 
            this.TBProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBProducto.Location = new System.Drawing.Point(256, 72);
            this.TBProducto.Name = "TBProducto";
            this.TBProducto.Size = new System.Drawing.Size(520, 21);
            this.TBProducto.TabIndex = 150;
            this.TBProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExaminar_Ubucacion);
            this.groupBox3.Controls.Add(this.TBUnidad_Valor);
            this.groupBox3.Controls.Add(this.TBUnidad);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.TBNivel);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.TBEstante);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.TBMarca);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TBUbicacion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(431, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 154);
            this.groupBox3.TabIndex = 167;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos de Ubicacion del Producto - Leal Enterprise";
            // 
            // btnExaminar_Ubucacion
            // 
            this.btnExaminar_Ubucacion.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.btnExaminar_Ubucacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Ubucacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Ubucacion.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Ubucacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Ubucacion.Location = new System.Drawing.Point(275, 20);
            this.btnExaminar_Ubucacion.Name = "btnExaminar_Ubucacion";
            this.btnExaminar_Ubucacion.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Ubucacion.TabIndex = 174;
            this.btnExaminar_Ubucacion.UseVisualStyleBackColor = true;
            // 
            // TBUnidad_Valor
            // 
            this.TBUnidad_Valor.Location = new System.Drawing.Point(130, 125);
            this.TBUnidad_Valor.Name = "TBUnidad_Valor";
            this.TBUnidad_Valor.Size = new System.Drawing.Size(170, 21);
            this.TBUnidad_Valor.TabIndex = 183;
            this.TBUnidad_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBUnidad
            // 
            this.TBUnidad.Location = new System.Drawing.Point(60, 125);
            this.TBUnidad.Name = "TBUnidad";
            this.TBUnidad.Size = new System.Drawing.Size(64, 21);
            this.TBUnidad.TabIndex = 182;
            this.TBUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 15);
            this.label13.TabIndex = 181;
            this.label13.Text = "Nivel";
            // 
            // TBNivel
            // 
            this.TBNivel.Location = new System.Drawing.Point(60, 98);
            this.TBNivel.Name = "TBNivel";
            this.TBNivel.Size = new System.Drawing.Size(240, 21);
            this.TBNivel.TabIndex = 180;
            this.TBNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 15);
            this.label11.TabIndex = 179;
            this.label11.Text = "Estante";
            // 
            // TBEstante
            // 
            this.TBEstante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEstante.Location = new System.Drawing.Point(60, 72);
            this.TBEstante.Name = "TBEstante";
            this.TBEstante.Size = new System.Drawing.Size(240, 21);
            this.TBEstante.TabIndex = 178;
            this.TBEstante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 177;
            this.label10.Text = "Unidad";
            // 
            // TBMarca
            // 
            this.TBMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMarca.Location = new System.Drawing.Point(60, 46);
            this.TBMarca.Name = "TBMarca";
            this.TBMarca.Size = new System.Drawing.Size(240, 21);
            this.TBMarca.TabIndex = 176;
            this.TBMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 174;
            this.label8.Text = "Marca";
            // 
            // TBUbicacion
            // 
            this.TBUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBUbicacion.Location = new System.Drawing.Point(60, 20);
            this.TBUbicacion.Name = "TBUbicacion";
            this.TBUbicacion.Size = new System.Drawing.Size(209, 21);
            this.TBUbicacion.TabIndex = 171;
            this.TBUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 170;
            this.label9.Text = "Bodega";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(782, 73);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(126, 15);
            this.lblTotal.TabIndex = 118;
            this.lblTotal.Text = "Productos Ingresados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.TBCompraPromedio);
            this.groupBox2.Controls.Add(this.TBVentaMayorista);
            this.groupBox2.Controls.Add(this.TBCompraFinal);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TBValorVenta_SinImpuesto);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.TBValorVenta);
            this.groupBox2.Location = new System.Drawing.Point(9, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 154);
            this.groupBox2.TabIndex = 166;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valores Basicos del Producto  - Leal Enterprise";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 15);
            this.label2.TabIndex = 157;
            this.label2.Text = "Valor de Compra Promedio";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 125);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(142, 15);
            this.label31.TabIndex = 165;
            this.label31.Text = "Valor de Venta Mayorista";
            // 
            // TBCompraPromedio
            // 
            this.TBCompraPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCompraPromedio.Location = new System.Drawing.Point(168, 20);
            this.TBCompraPromedio.Name = "TBCompraPromedio";
            this.TBCompraPromedio.Size = new System.Drawing.Size(240, 21);
            this.TBCompraPromedio.TabIndex = 156;
            this.TBCompraPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBVentaMayorista
            // 
            this.TBVentaMayorista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBVentaMayorista.Location = new System.Drawing.Point(168, 124);
            this.TBVentaMayorista.Name = "TBVentaMayorista";
            this.TBVentaMayorista.Size = new System.Drawing.Size(240, 21);
            this.TBVentaMayorista.TabIndex = 164;
            this.TBVentaMayorista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCompraFinal
            // 
            this.TBCompraFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCompraFinal.Location = new System.Drawing.Point(168, 46);
            this.TBCompraFinal.Name = "TBCompraFinal";
            this.TBCompraFinal.Size = new System.Drawing.Size(240, 21);
            this.TBCompraFinal.TabIndex = 158;
            this.TBCompraFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 100);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(152, 15);
            this.label32.TabIndex = 163;
            this.label32.Text = "Valor de Venta No Excento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 15);
            this.label4.TabIndex = 159;
            this.label4.Text = "Valor de Compra Final";
            // 
            // TBValorVenta_SinImpuesto
            // 
            this.TBValorVenta_SinImpuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorVenta_SinImpuesto.Location = new System.Drawing.Point(168, 72);
            this.TBValorVenta_SinImpuesto.Name = "TBValorVenta_SinImpuesto";
            this.TBValorVenta_SinImpuesto.Size = new System.Drawing.Size(240, 21);
            this.TBValorVenta_SinImpuesto.TabIndex = 162;
            this.TBValorVenta_SinImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 73);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(133, 15);
            this.label26.TabIndex = 160;
            this.label26.Text = "Valor de Venta Excento";
            // 
            // TBValorVenta
            // 
            this.TBValorVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBValorVenta.Location = new System.Drawing.Point(168, 98);
            this.TBValorVenta.Name = "TBValorVenta";
            this.TBValorVenta.Size = new System.Drawing.Size(240, 21);
            this.TBValorVenta.TabIndex = 161;
            this.TBValorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmFacturaDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 545);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmFacturaDeCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras - Factura de Compra";
            this.Load += new System.EventHandler(this.frmFacturaDeCompra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalleDeIngreso)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox CBOperacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox TBCodigo_Proveedor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox TBProveedor;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.TextBox TBCodigo_Producto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TBOrdendecompra;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView DGDetalleDeIngreso;
        private System.Windows.Forms.TextBox TBCreditoDisponible;
        private System.Windows.Forms.TextBox TBValorPromedio_Final;
        private System.Windows.Forms.TextBox TBValorCompra_Final;
        public System.Windows.Forms.TextBox TBIdbodega;
        public System.Windows.Forms.TextBox TBIdproveedor;
        public System.Windows.Forms.TextBox TBIddetalle;
        public System.Windows.Forms.TextBox TBIdproducto;
        private System.Windows.Forms.TextBox TBProducto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExaminar_Ubucacion;
        private System.Windows.Forms.TextBox TBUnidad_Valor;
        private System.Windows.Forms.TextBox TBUnidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TBNivel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBEstante;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBMarca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBUbicacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TBCompraPromedio;
        private System.Windows.Forms.TextBox TBVentaMayorista;
        private System.Windows.Forms.TextBox TBCompraFinal;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBValorVenta_SinImpuesto;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox TBValorVenta;
        private System.Windows.Forms.TextBox TBValorVenta_Final;
        private System.Windows.Forms.Panel panel1;
    }
}