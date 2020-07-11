namespace Presentacion
{
    partial class frmEmpleados
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
            this.label6 = new System.Windows.Forms.Label();
            this.TBCargo = new System.Windows.Forms.TextBox();
            this.TBProfesion = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.CBDepartamento = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TBIdempleado = new System.Windows.Forms.TextBox();
            this.TBDireccion01 = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.TBPais = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TBDescuento_Compra = new System.Windows.Forms.TextBox();
            this.TBMovil = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TBDocumento = new System.Windows.Forms.TextBox();
            this.TBComision = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TBFijo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBCiudad = new System.Windows.Forms.TextBox();
            this.TBEmpleado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBCorreo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.CBTipodecontrato = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TBCodigo);
            this.groupBox1.Controls.Add(this.CBTipodecontrato);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CBDepartamento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TBCargo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.TBEmpleado);
            this.groupBox1.Controls.Add(this.TBIdempleado);
            this.groupBox1.Controls.Add(this.TBProfesion);
            this.groupBox1.Controls.Add(this.TBDocumento);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TBPais);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.TBCiudad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TBFijo);
            this.groupBox1.Controls.Add(this.TBDireccion01);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TBComision);
            this.groupBox1.Controls.Add(this.TBMovil);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.TBCorreo);
            this.groupBox1.Controls.Add(this.TBDescuento_Compra);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 466);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leal Enterprise - Registro de Empleados";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Cargo a Ejercer";
            // 
            // TBCargo
            // 
            this.TBCargo.Location = new System.Drawing.Point(124, 344);
            this.TBCargo.Name = "TBCargo";
            this.TBCargo.Size = new System.Drawing.Size(258, 21);
            this.TBCargo.TabIndex = 30;
            this.TBCargo.Enter += new System.EventHandler(this.TBCargo_Enter);
            this.TBCargo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCargo_KeyUp);
            this.TBCargo.Leave += new System.EventHandler(this.TBCargo_Leave);
            // 
            // TBProfesion
            // 
            this.TBProfesion.Location = new System.Drawing.Point(124, 317);
            this.TBProfesion.Name = "TBProfesion";
            this.TBProfesion.Size = new System.Drawing.Size(258, 21);
            this.TBProfesion.TabIndex = 29;
            this.TBProfesion.Enter += new System.EventHandler(this.TBProfesion_Enter);
            this.TBProfesion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBProfesion_KeyUp);
            this.TBProfesion.Leave += new System.EventHandler(this.TBProfesion_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 320);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 15);
            this.label17.TabIndex = 28;
            this.label17.Text = "Profesion";
            // 
            // CBDepartamento
            // 
            this.CBDepartamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDepartamento.FormattingEnabled = true;
            this.CBDepartamento.Location = new System.Drawing.Point(124, 371);
            this.CBDepartamento.Name = "CBDepartamento";
            this.CBDepartamento.Size = new System.Drawing.Size(258, 23);
            this.CBDepartamento.Sorted = true;
            this.CBDepartamento.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "Direccion";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 15);
            this.label16.TabIndex = 26;
            this.label16.Text = "Departamento";
            // 
            // TBIdempleado
            // 
            this.TBIdempleado.Location = new System.Drawing.Point(178, 434);
            this.TBIdempleado.Name = "TBIdempleado";
            this.TBIdempleado.Size = new System.Drawing.Size(24, 21);
            this.TBIdempleado.TabIndex = 19;
            this.TBIdempleado.TextChanged += new System.EventHandler(this.TBIdempleado_TextChanged);
            // 
            // TBDireccion01
            // 
            this.TBDireccion01.Location = new System.Drawing.Point(82, 236);
            this.TBDireccion01.Name = "TBDireccion01";
            this.TBDireccion01.Size = new System.Drawing.Size(300, 21);
            this.TBDireccion01.TabIndex = 24;
            this.TBDireccion01.Enter += new System.EventHandler(this.TBDireccion01_Enter);
            this.TBDireccion01.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBDireccion01_KeyUp);
            this.TBDireccion01.Leave += new System.EventHandler(this.TBDireccion01_Leave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(292, 429);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 15);
            this.label18.TabIndex = 21;
            this.label18.Text = "Pais";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(11, 429);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // TBPais
            // 
            this.TBPais.Location = new System.Drawing.Point(82, 101);
            this.TBPais.Name = "TBPais";
            this.TBPais.Size = new System.Drawing.Size(300, 21);
            this.TBPais.TabIndex = 20;
            this.TBPais.Enter += new System.EventHandler(this.TBPais_Enter);
            this.TBPais.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBPais_KeyUp);
            this.TBPais.Leave += new System.EventHandler(this.TBPais_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Documento";
            // 
            // TBDescuento_Compra
            // 
            this.TBDescuento_Compra.Location = new System.Drawing.Point(124, 290);
            this.TBDescuento_Compra.Name = "TBDescuento_Compra";
            this.TBDescuento_Compra.Size = new System.Drawing.Size(258, 21);
            this.TBDescuento_Compra.TabIndex = 19;
            this.TBDescuento_Compra.Enter += new System.EventHandler(this.TBDescuento_Enter);
            this.TBDescuento_Compra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBDescuento_KeyUp);
            this.TBDescuento_Compra.Leave += new System.EventHandler(this.TBDescuento_Leave);
            // 
            // TBMovil
            // 
            this.TBMovil.Location = new System.Drawing.Point(82, 182);
            this.TBMovil.Name = "TBMovil";
            this.TBMovil.Size = new System.Drawing.Size(300, 21);
            this.TBMovil.TabIndex = 8;
            this.TBMovil.Enter += new System.EventHandler(this.TBMovil_Enter);
            this.TBMovil.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBMovil_KeyUp);
            this.TBMovil.Leave += new System.EventHandler(this.TBMovil_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 293);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 15);
            this.label20.TabIndex = 18;
            this.label20.Text = "Descu. de Compra";
            // 
            // TBDocumento
            // 
            this.TBDocumento.Location = new System.Drawing.Point(82, 74);
            this.TBDocumento.Name = "TBDocumento";
            this.TBDocumento.Size = new System.Drawing.Size(300, 21);
            this.TBDocumento.TabIndex = 18;
            this.TBDocumento.Enter += new System.EventHandler(this.TBDocumento_Enter);
            this.TBDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBDocumento_KeyUp);
            this.TBDocumento.Leave += new System.EventHandler(this.TBDocumento_Leave);
            // 
            // TBComision
            // 
            this.TBComision.Location = new System.Drawing.Point(124, 263);
            this.TBComision.Name = "TBComision";
            this.TBComision.Size = new System.Drawing.Size(258, 21);
            this.TBComision.TabIndex = 17;
            this.TBComision.Enter += new System.EventHandler(this.TBComision_Enter);
            this.TBComision.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBComision_KeyUp);
            this.TBComision.Leave += new System.EventHandler(this.TBComision_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Movil";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 266);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 15);
            this.label19.TabIndex = 16;
            this.label19.Text = "Comision de Venta";
            // 
            // TBFijo
            // 
            this.TBFijo.Location = new System.Drawing.Point(82, 155);
            this.TBFijo.Name = "TBFijo";
            this.TBFijo.Size = new System.Drawing.Size(300, 21);
            this.TBFijo.TabIndex = 7;
            this.TBFijo.Enter += new System.EventHandler(this.TBFijo_Enter);
            this.TBFijo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFijo_KeyUp);
            this.TBFijo.Leave += new System.EventHandler(this.TBFijo_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fijo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TBCiudad
            // 
            this.TBCiudad.Location = new System.Drawing.Point(82, 128);
            this.TBCiudad.Name = "TBCiudad";
            this.TBCiudad.Size = new System.Drawing.Size(300, 21);
            this.TBCiudad.TabIndex = 5;
            this.TBCiudad.Enter += new System.EventHandler(this.TBCiudad_Enter);
            this.TBCiudad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCiudad_KeyUp);
            this.TBCiudad.Leave += new System.EventHandler(this.TBCiudad_Leave);
            // 
            // TBEmpleado
            // 
            this.TBEmpleado.Location = new System.Drawing.Point(82, 47);
            this.TBEmpleado.Name = "TBEmpleado";
            this.TBEmpleado.Size = new System.Drawing.Size(300, 21);
            this.TBEmpleado.TabIndex = 1;
            this.TBEmpleado.Enter += new System.EventHandler(this.TBEmpleado_Enter);
            this.TBEmpleado.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBEmpleado_KeyUp);
            this.TBEmpleado.Leave += new System.EventHandler(this.TBEmpleado_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email";
            // 
            // TBCorreo
            // 
            this.TBCorreo.Location = new System.Drawing.Point(82, 209);
            this.TBCorreo.Name = "TBCorreo";
            this.TBCorreo.Size = new System.Drawing.Size(300, 21);
            this.TBCorreo.TabIndex = 13;
            this.TBCorreo.Enter += new System.EventHandler(this.TBCorreo_Enter);
            this.TBCorreo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCorreo_KeyUp);
            this.TBCorreo.Leave += new System.EventHandler(this.TBCorreo_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ciudad";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(141, 20);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(365, 21);
            this.TBBuscar.TabIndex = 3;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            this.TBBuscar.Enter += new System.EventHandler(this.TBBuscar_Enter);
            this.TBBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBBuscar_KeyUp);
            this.TBBuscar.Leave += new System.EventHandler(this.TBBuscar_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empleado a Consultar";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 437);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 15);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "------";
            // 
            // DGResultados
            // 
            this.DGResultados.AllowUserToAddRows = false;
            this.DGResultados.AllowUserToDeleteRows = false;
            this.DGResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGResultados.BackgroundColor = System.Drawing.Color.White;
            this.DGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGResultados.Location = new System.Drawing.Point(6, 47);
            this.DGResultados.Name = "DGResultados";
            this.DGResultados.ReadOnly = true;
            this.DGResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultados.Size = new System.Drawing.Size(500, 376);
            this.DGResultados.TabIndex = 0;
            this.DGResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGResultados_CellDoubleClick);
            this.DGResultados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGResultados_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TBBuscar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.DGResultados);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Location = new System.Drawing.Point(408, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 466);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Image = global::Presentacion.Botones.btnImprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(416, 429);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 30);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(320, 429);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // CBTipodecontrato
            // 
            this.CBTipodecontrato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBTipodecontrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipodecontrato.FormattingEnabled = true;
            this.CBTipodecontrato.Location = new System.Drawing.Point(124, 400);
            this.CBTipodecontrato.Name = "CBTipodecontrato";
            this.CBTipodecontrato.Size = new System.Drawing.Size(258, 23);
            this.CBTipodecontrato.Sorted = true;
            this.CBTipodecontrato.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 32;
            this.label8.Text = "Tipo de Contrato";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Codigo";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(82, 20);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(300, 21);
            this.TBCodigo.TabIndex = 35;
            this.TBCodigo.Enter += new System.EventHandler(this.TBCodigo_Enter);
            this.TBCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCodigo_KeyUp);
            this.TBCodigo.Leave += new System.EventHandler(this.TBCodigo_Leave);
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 487);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Empleados - Empleados";
            this.Load += new System.EventHandler(this.frmEmpleados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBIdempleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBEmpleado;
        private System.Windows.Forms.TextBox TBCorreo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBCiudad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBFijo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBMovil;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox TBDocumento;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TBPais;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBDireccion01;
        private System.Windows.Forms.TextBox TBComision;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TBDescuento_Compra;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CBDepartamento;
        private System.Windows.Forms.TextBox TBProfesion;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBCargo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CBTipodecontrato;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBCodigo;
    }
}