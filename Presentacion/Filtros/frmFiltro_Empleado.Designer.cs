namespace Presentacion
{
    partial class frmFiltro_Empleado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.TBBuscar_Facturacion = new System.Windows.Forms.TextBox();
            this.btnAgregarEmpl_Factura = new System.Windows.Forms.Button();
            this.lblTotal_Facturacion = new System.Windows.Forms.Label();
            this.DGFiltro_Facturacion = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAgregarEmpl_General = new System.Windows.Forms.Button();
            this.lblTotal_General = new System.Windows.Forms.Label();
            this.DGFiltro_General = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.TBBuscar_General = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TBIdempleado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBCorreo = new System.Windows.Forms.TextBox();
            this.TBDepartamento = new System.Windows.Forms.TextBox();
            this.TBSucursal = new System.Windows.Forms.TextBox();
            this.TBContrato = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TBProfesion = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TBEmpleado = new System.Windows.Forms.TextBox();
            this.TBCargo = new System.Windows.Forms.TextBox();
            this.TBDocumento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_Facturacion)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_General)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 386);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Empleado y Datos Basicos - Leal Enterprise";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(593, 353);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TBBuscar_Facturacion);
            this.tabPage1.Controls.Add(this.btnAgregarEmpl_Factura);
            this.tabPage1.Controls.Add(this.lblTotal_Facturacion);
            this.tabPage1.Controls.Add(this.DGFiltro_Facturacion);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(585, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filtro de Facturación";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Empleado a Consultar";
            // 
            // TBBuscar_Facturacion
            // 
            this.TBBuscar_Facturacion.Location = new System.Drawing.Point(144, 7);
            this.TBBuscar_Facturacion.Name = "TBBuscar_Facturacion";
            this.TBBuscar_Facturacion.Size = new System.Drawing.Size(435, 22);
            this.TBBuscar_Facturacion.TabIndex = 7;
            this.TBBuscar_Facturacion.TextChanged += new System.EventHandler(this.TBBuscar_Facturacion_TextChanged);
            this.TBBuscar_Facturacion.Enter += new System.EventHandler(this.TBBuscar_Facturacion_Enter);
            this.TBBuscar_Facturacion.Leave += new System.EventHandler(this.TBBuscar_Facturacion_Leave);
            // 
            // btnAgregarEmpl_Factura
            // 
            this.btnAgregarEmpl_Factura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpl_Factura.FlatAppearance.BorderSize = 0;
            this.btnAgregarEmpl_Factura.Image = global::Presentacion.Properties.Resources.btnAgregar;
            this.btnAgregarEmpl_Factura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEmpl_Factura.Location = new System.Drawing.Point(459, 287);
            this.btnAgregarEmpl_Factura.Name = "btnAgregarEmpl_Factura";
            this.btnAgregarEmpl_Factura.Size = new System.Drawing.Size(120, 30);
            this.btnAgregarEmpl_Factura.TabIndex = 6;
            this.btnAgregarEmpl_Factura.Text = "Agregar - F3";
            this.btnAgregarEmpl_Factura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEmpl_Factura.UseVisualStyleBackColor = true;
            this.btnAgregarEmpl_Factura.Click += new System.EventHandler(this.btnAgregarEmpl_Factura_Click);
            // 
            // lblTotal_Facturacion
            // 
            this.lblTotal_Facturacion.AutoSize = true;
            this.lblTotal_Facturacion.Location = new System.Drawing.Point(6, 294);
            this.lblTotal_Facturacion.Name = "lblTotal_Facturacion";
            this.lblTotal_Facturacion.Size = new System.Drawing.Size(113, 17);
            this.lblTotal_Facturacion.TabIndex = 5;
            this.lblTotal_Facturacion.Text = "Datos Registrados:";
            // 
            // DGFiltro_Facturacion
            // 
            this.DGFiltro_Facturacion.AllowUserToAddRows = false;
            this.DGFiltro_Facturacion.AllowUserToDeleteRows = false;
            this.DGFiltro_Facturacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGFiltro_Facturacion.BackgroundColor = System.Drawing.Color.White;
            this.DGFiltro_Facturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGFiltro_Facturacion.Location = new System.Drawing.Point(8, 40);
            this.DGFiltro_Facturacion.Name = "DGFiltro_Facturacion";
            this.DGFiltro_Facturacion.ReadOnly = true;
            this.DGFiltro_Facturacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGFiltro_Facturacion.Size = new System.Drawing.Size(571, 241);
            this.DGFiltro_Facturacion.TabIndex = 3;
            this.DGFiltro_Facturacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGFiltro_Facturacion_CellClick);
            this.DGFiltro_Facturacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGFiltro_Facturacion_CellDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAgregarEmpl_General);
            this.tabPage2.Controls.Add(this.lblTotal_General);
            this.tabPage2.Controls.Add(this.DGFiltro_General);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.TBBuscar_General);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(585, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Filtro General";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAgregarEmpl_General
            // 
            this.btnAgregarEmpl_General.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpl_General.FlatAppearance.BorderSize = 0;
            this.btnAgregarEmpl_General.Image = global::Presentacion.Properties.Resources.btnAgregar;
            this.btnAgregarEmpl_General.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEmpl_General.Location = new System.Drawing.Point(459, 287);
            this.btnAgregarEmpl_General.Name = "btnAgregarEmpl_General";
            this.btnAgregarEmpl_General.Size = new System.Drawing.Size(120, 30);
            this.btnAgregarEmpl_General.TabIndex = 11;
            this.btnAgregarEmpl_General.Text = "Agregar - F3";
            this.btnAgregarEmpl_General.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEmpl_General.UseVisualStyleBackColor = true;
            this.btnAgregarEmpl_General.Click += new System.EventHandler(this.btnAgregarEmpl_General_Click);
            // 
            // lblTotal_General
            // 
            this.lblTotal_General.AutoSize = true;
            this.lblTotal_General.Location = new System.Drawing.Point(6, 294);
            this.lblTotal_General.Name = "lblTotal_General";
            this.lblTotal_General.Size = new System.Drawing.Size(113, 17);
            this.lblTotal_General.TabIndex = 10;
            this.lblTotal_General.Text = "Datos Registrados:";
            // 
            // DGFiltro_General
            // 
            this.DGFiltro_General.AllowUserToAddRows = false;
            this.DGFiltro_General.AllowUserToDeleteRows = false;
            this.DGFiltro_General.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGFiltro_General.BackgroundColor = System.Drawing.Color.White;
            this.DGFiltro_General.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGFiltro_General.Location = new System.Drawing.Point(8, 40);
            this.DGFiltro_General.Name = "DGFiltro_General";
            this.DGFiltro_General.ReadOnly = true;
            this.DGFiltro_General.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGFiltro_General.Size = new System.Drawing.Size(571, 241);
            this.DGFiltro_General.TabIndex = 9;
            this.DGFiltro_General.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGFiltro_General_CellDoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Empleado a Consultar";
            // 
            // TBBuscar_General
            // 
            this.TBBuscar_General.Location = new System.Drawing.Point(144, 7);
            this.TBBuscar_General.Name = "TBBuscar_General";
            this.TBBuscar_General.Size = new System.Drawing.Size(435, 22);
            this.TBBuscar_General.TabIndex = 8;
            this.TBBuscar_General.TextChanged += new System.EventHandler(this.TBBuscar_General_TextChanged);
            this.TBBuscar_General.Enter += new System.EventHandler(this.TBBuscar_General_Enter);
            this.TBBuscar_General.Leave += new System.EventHandler(this.TBBuscar_General_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TBIdempleado);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TBCorreo);
            this.groupBox2.Controls.Add(this.TBDepartamento);
            this.groupBox2.Controls.Add(this.TBSucursal);
            this.groupBox2.Controls.Add(this.TBContrato);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.TBProfesion);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.TBEmpleado);
            this.groupBox2.Controls.Add(this.TBCargo);
            this.groupBox2.Controls.Add(this.TBDocumento);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TBCodigo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(623, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 386);
            this.groupBox2.TabIndex = 174;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Basicos del Producto - Leal Enterprise";
            // 
            // TBIdempleado
            // 
            this.TBIdempleado.Location = new System.Drawing.Point(9, 342);
            this.TBIdempleado.Name = "TBIdempleado";
            this.TBIdempleado.Size = new System.Drawing.Size(100, 22);
            this.TBIdempleado.TabIndex = 9;
            this.TBIdempleado.TextChanged += new System.EventHandler(this.TBIdempleado_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 14);
            this.label4.TabIndex = 57;
            this.label4.Text = "Email";
            // 
            // TBCorreo
            // 
            this.TBCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCorreo.Location = new System.Drawing.Point(85, 242);
            this.TBCorreo.Name = "TBCorreo";
            this.TBCorreo.Size = new System.Drawing.Size(298, 22);
            this.TBCorreo.TabIndex = 56;
            // 
            // TBDepartamento
            // 
            this.TBDepartamento.Location = new System.Drawing.Point(85, 105);
            this.TBDepartamento.Name = "TBDepartamento";
            this.TBDepartamento.Size = new System.Drawing.Size(298, 22);
            this.TBDepartamento.TabIndex = 55;
            // 
            // TBSucursal
            // 
            this.TBSucursal.Location = new System.Drawing.Point(85, 77);
            this.TBSucursal.Name = "TBSucursal";
            this.TBSucursal.Size = new System.Drawing.Size(298, 22);
            this.TBSucursal.TabIndex = 54;
            // 
            // TBContrato
            // 
            this.TBContrato.Location = new System.Drawing.Point(85, 49);
            this.TBContrato.Name = "TBContrato";
            this.TBContrato.Size = new System.Drawing.Size(298, 22);
            this.TBContrato.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nombre";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 14);
            this.label17.TabIndex = 44;
            this.label17.Text = "Profesión";
            // 
            // TBProfesion
            // 
            this.TBProfesion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBProfesion.Location = new System.Drawing.Point(85, 187);
            this.TBProfesion.Name = "TBProfesion";
            this.TBProfesion.Size = new System.Drawing.Size(298, 22);
            this.TBProfesion.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 106);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 14);
            this.label16.TabIndex = 42;
            this.label16.Text = "Depart.";
            // 
            // TBEmpleado
            // 
            this.TBEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBEmpleado.Location = new System.Drawing.Point(85, 133);
            this.TBEmpleado.Name = "TBEmpleado";
            this.TBEmpleado.Size = new System.Drawing.Size(298, 22);
            this.TBEmpleado.TabIndex = 39;
            // 
            // TBCargo
            // 
            this.TBCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCargo.Location = new System.Drawing.Point(85, 214);
            this.TBCargo.Name = "TBCargo";
            this.TBCargo.Size = new System.Drawing.Size(298, 22);
            this.TBCargo.TabIndex = 46;
            // 
            // TBDocumento
            // 
            this.TBDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDocumento.Location = new System.Drawing.Point(85, 160);
            this.TBDocumento.Name = "TBDocumento";
            this.TBDocumento.Size = new System.Drawing.Size(298, 22);
            this.TBDocumento.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 14);
            this.label10.TabIndex = 41;
            this.label10.Text = "Documento";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 47;
            this.label6.Text = "Cargo";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(85, 21);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(298, 22);
            this.TBCodigo.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 14);
            this.label8.TabIndex = 48;
            this.label8.Text = "Contrato";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 50;
            this.label3.Text = "Código";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 14);
            this.label12.TabIndex = 52;
            this.label12.Text = "Sucursal";
            // 
            // frmFiltro_Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmFiltro_Empleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro de Empleado - Leal Enterprise";
            this.Load += new System.EventHandler(this.frmFiltro_Empleado_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_Facturacion)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_General)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGFiltro_Facturacion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregarEmpl_Factura;
        private System.Windows.Forms.Label lblTotal_Facturacion;
        private System.Windows.Forms.Button btnAgregarEmpl_General;
        private System.Windows.Forms.Label lblTotal_General;
        private System.Windows.Forms.DataGridView DGFiltro_General;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBBuscar_General;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBBuscar_Facturacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TBProfesion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TBEmpleado;
        private System.Windows.Forms.TextBox TBCargo;
        private System.Windows.Forms.TextBox TBDocumento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TBDepartamento;
        private System.Windows.Forms.TextBox TBSucursal;
        private System.Windows.Forms.TextBox TBContrato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBCorreo;
        private System.Windows.Forms.TextBox TBIdempleado;
    }
}