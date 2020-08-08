namespace Presentacion
{
    partial class frmServicio
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
            this.TBIdservicio = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBServicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBClase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBCosto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TBComision = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.TBValor01 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TBValor03 = new System.Windows.Forms.TextBox();
            this.TBValor02 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DGResultado_Impuesto = new System.Windows.Forms.DataGridView();
            this.TBBuscar_Impuesto = new System.Windows.Forms.TextBox();
            this.lblTotal_Impuesto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExaminar_Impuesto = new System.Windows.Forms.Button();
            this.btnAgregar_Impuesto = new System.Windows.Forms.Button();
            this.btnEliminar_Impuesto = new System.Windows.Forms.Button();
            this.brnEditar_Impuesto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultado_Impuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBIdservicio);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leal Enterprise - Registro de Servicios Ofrecidos";
            // 
            // TBIdservicio
            // 
            this.TBIdservicio.Location = new System.Drawing.Point(112, 338);
            this.TBIdservicio.Name = "TBIdservicio";
            this.TBIdservicio.Size = new System.Drawing.Size(26, 21);
            this.TBIdservicio.TabIndex = 30;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(304, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseDown);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(6, 333);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGuardar_MouseDown);
            this.btnGuardar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            this.btnGuardar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGuardar_MouseMove);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Codigo";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Location = new System.Drawing.Point(84, 6);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(300, 21);
            this.TBCodigo.TabIndex = 27;
            this.TBCodigo.Enter += new System.EventHandler(this.TBCodigo_Enter);
            this.TBCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCodigo_KeyUp);
            this.TBCodigo.Leave += new System.EventHandler(this.TBCodigo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicio";
            // 
            // TBServicio
            // 
            this.TBServicio.Location = new System.Drawing.Point(84, 33);
            this.TBServicio.Name = "TBServicio";
            this.TBServicio.Size = new System.Drawing.Size(300, 21);
            this.TBServicio.TabIndex = 1;
            this.TBServicio.Enter += new System.EventHandler(this.TBServicio_Enter);
            this.TBServicio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBServicio_KeyUp);
            this.TBServicio.Leave += new System.EventHandler(this.TBServicio_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción";
            // 
            // TBDescripcion
            // 
            this.TBDescripcion.Location = new System.Drawing.Point(84, 60);
            this.TBDescripcion.Name = "TBDescripcion";
            this.TBDescripcion.Size = new System.Drawing.Size(300, 21);
            this.TBDescripcion.TabIndex = 3;
            this.TBDescripcion.Enter += new System.EventHandler(this.TBDescripcion_Enter);
            this.TBDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBDescripcion_KeyUp);
            this.TBDescripcion.Leave += new System.EventHandler(this.TBDescripcion_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clase";
            // 
            // TBClase
            // 
            this.TBClase.Location = new System.Drawing.Point(84, 87);
            this.TBClase.Name = "TBClase";
            this.TBClase.Size = new System.Drawing.Size(300, 21);
            this.TBClase.TabIndex = 5;
            this.TBClase.Enter += new System.EventHandler(this.TBClase_Enter);
            this.TBClase.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBClase_KeyUp);
            this.TBClase.Leave += new System.EventHandler(this.TBClase_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Costo";
            // 
            // TBCosto
            // 
            this.TBCosto.Location = new System.Drawing.Point(84, 114);
            this.TBCosto.Name = "TBCosto";
            this.TBCosto.Size = new System.Drawing.Size(300, 21);
            this.TBCosto.TabIndex = 9;
            this.TBCosto.Enter += new System.EventHandler(this.TBCosto_Enter);
            this.TBCosto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCosto_KeyUp);
            this.TBCosto.Leave += new System.EventHandler(this.TBCosto_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Comision";
            // 
            // TBComision
            // 
            this.TBComision.Location = new System.Drawing.Point(186, 141);
            this.TBComision.Name = "TBComision";
            this.TBComision.Size = new System.Drawing.Size(198, 21);
            this.TBComision.TabIndex = 13;
            this.TBComision.Enter += new System.EventHandler(this.TBComision_Enter);
            this.TBComision.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBComision_KeyUp);
            this.TBComision.Leave += new System.EventHandler(this.TBComision_Leave);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Image = global::Presentacion.Botones.btnImprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(420, 333);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 30);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnImprimir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseDown);
            this.btnImprimir.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnImprimir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(324, 333);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEliminar_MouseDown);
            this.btnEliminar.MouseLeave += new System.EventHandler(this.btnEliminar_MouseLeave);
            this.btnEliminar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEliminar_MouseMove);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(127, 20);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(383, 21);
            this.TBBuscar.TabIndex = 3;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Servicio a Consultar";
            // 
            // DGResultados
            // 
            this.DGResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGResultados.BackgroundColor = System.Drawing.Color.White;
            this.DGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGResultados.Location = new System.Drawing.Point(6, 47);
            this.DGResultados.Name = "DGResultados";
            this.DGResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultados.Size = new System.Drawing.Size(504, 280);
            this.DGResultados.TabIndex = 0;
            this.DGResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGResultados_CellDoubleClick);
            this.DGResultados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGResultados_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.TBBuscar);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.DGResultados);
            this.groupBox2.Location = new System.Drawing.Point(429, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 369);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 341);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 15);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "------";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(398, 307);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.TBComision);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.TBCodigo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TBCosto);
            this.tabPage1.Controls.Add(this.TBServicio);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TBClase);
            this.tabPage1.Controls.Add(this.TBDescripcion);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(390, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Basicos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAgregar_Impuesto);
            this.tabPage2.Controls.Add(this.btnEliminar_Impuesto);
            this.tabPage2.Controls.Add(this.brnEditar_Impuesto);
            this.tabPage2.Controls.Add(this.TBBuscar_Impuesto);
            this.tabPage2.Controls.Add(this.lblTotal_Impuesto);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnExaminar_Impuesto);
            this.tabPage2.Controls.Add(this.DGResultado_Impuesto);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(390, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Impuestos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.TBValor01);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.TBValor03);
            this.tabPage3.Controls.Add(this.TBValor02);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(390, 279);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Precios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(390, 279);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Materiales";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Valor 01";
            // 
            // TBValor01
            // 
            this.TBValor01.Location = new System.Drawing.Point(85, 102);
            this.TBValor01.Name = "TBValor01";
            this.TBValor01.Size = new System.Drawing.Size(250, 21);
            this.TBValor01.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "Valor 02";
            // 
            // TBValor03
            // 
            this.TBValor03.Location = new System.Drawing.Point(85, 156);
            this.TBValor03.Name = "TBValor03";
            this.TBValor03.Size = new System.Drawing.Size(250, 21);
            this.TBValor03.TabIndex = 29;
            // 
            // TBValor02
            // 
            this.TBValor02.Location = new System.Drawing.Point(85, 129);
            this.TBValor02.Name = "TBValor02";
            this.TBValor02.Size = new System.Drawing.Size(250, 21);
            this.TBValor02.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "Valor 03";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 141);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 21);
            this.textBox1.TabIndex = 29;
            // 
            // DGResultado_Impuesto
            // 
            this.DGResultado_Impuesto.AllowUserToAddRows = false;
            this.DGResultado_Impuesto.AllowUserToDeleteRows = false;
            this.DGResultado_Impuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGResultado_Impuesto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGResultado_Impuesto.BackgroundColor = System.Drawing.Color.White;
            this.DGResultado_Impuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultado_Impuesto.Location = new System.Drawing.Point(6, 48);
            this.DGResultado_Impuesto.Name = "DGResultado_Impuesto";
            this.DGResultado_Impuesto.ReadOnly = true;
            this.DGResultado_Impuesto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultado_Impuesto.Size = new System.Drawing.Size(378, 189);
            this.DGResultado_Impuesto.TabIndex = 0;
            // 
            // TBBuscar_Impuesto
            // 
            this.TBBuscar_Impuesto.Location = new System.Drawing.Point(70, 6);
            this.TBBuscar_Impuesto.Name = "TBBuscar_Impuesto";
            this.TBBuscar_Impuesto.Size = new System.Drawing.Size(283, 21);
            this.TBBuscar_Impuesto.TabIndex = 154;
            this.TBBuscar_Impuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotal_Impuesto
            // 
            this.lblTotal_Impuesto.AutoSize = true;
            this.lblTotal_Impuesto.Location = new System.Drawing.Point(6, 30);
            this.lblTotal_Impuesto.Name = "lblTotal_Impuesto";
            this.lblTotal_Impuesto.Size = new System.Drawing.Size(31, 15);
            this.lblTotal_Impuesto.TabIndex = 152;
            this.lblTotal_Impuesto.Text = "------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 153;
            this.label4.Text = "Impuesto";
            // 
            // btnExaminar_Impuesto
            // 
            this.btnExaminar_Impuesto.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.btnExaminar_Impuesto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar_Impuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar_Impuesto.FlatAppearance.BorderSize = 0;
            this.btnExaminar_Impuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar_Impuesto.Location = new System.Drawing.Point(359, 6);
            this.btnExaminar_Impuesto.Name = "btnExaminar_Impuesto";
            this.btnExaminar_Impuesto.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar_Impuesto.TabIndex = 155;
            this.btnExaminar_Impuesto.UseVisualStyleBackColor = true;
            // 
            // btnAgregar_Impuesto
            // 
            this.btnAgregar_Impuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar_Impuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar_Impuesto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar_Impuesto.FlatAppearance.BorderSize = 0;
            this.btnAgregar_Impuesto.Image = global::Presentacion.Botones.btnAgregar;
            this.btnAgregar_Impuesto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar_Impuesto.Location = new System.Drawing.Point(102, 243);
            this.btnAgregar_Impuesto.Name = "btnAgregar_Impuesto";
            this.btnAgregar_Impuesto.Size = new System.Drawing.Size(90, 30);
            this.btnAgregar_Impuesto.TabIndex = 158;
            this.btnAgregar_Impuesto.Text = "Agregar";
            this.btnAgregar_Impuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar_Impuesto.UseVisualStyleBackColor = true;
            // 
            // btnEliminar_Impuesto
            // 
            this.btnEliminar_Impuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar_Impuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_Impuesto.FlatAppearance.BorderSize = 0;
            this.btnEliminar_Impuesto.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar_Impuesto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar_Impuesto.Location = new System.Drawing.Point(198, 243);
            this.btnEliminar_Impuesto.Name = "btnEliminar_Impuesto";
            this.btnEliminar_Impuesto.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar_Impuesto.TabIndex = 156;
            this.btnEliminar_Impuesto.Text = "Eliminar";
            this.btnEliminar_Impuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar_Impuesto.UseVisualStyleBackColor = true;
            // 
            // brnEditar_Impuesto
            // 
            this.brnEditar_Impuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brnEditar_Impuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brnEditar_Impuesto.FlatAppearance.BorderSize = 0;
            this.brnEditar_Impuesto.Image = global::Presentacion.Botones.btnEditar;
            this.brnEditar_Impuesto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brnEditar_Impuesto.Location = new System.Drawing.Point(294, 243);
            this.brnEditar_Impuesto.Name = "brnEditar_Impuesto";
            this.brnEditar_Impuesto.Size = new System.Drawing.Size(90, 30);
            this.brnEditar_Impuesto.TabIndex = 157;
            this.brnEditar_Impuesto.Text = "Modificar";
            this.brnEditar_Impuesto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brnEditar_Impuesto.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Image = global::Presentacion.Botones.btnAgregar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(102, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 166;
            this.button1.Text = "Agregar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Image = global::Presentacion.Botones.btnEliminar;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(198, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 30);
            this.button2.TabIndex = 164;
            this.button2.Text = "Eliminar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Image = global::Presentacion.Botones.btnEditar;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(294, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 30);
            this.button3.TabIndex = 165;
            this.button3.Text = "Modificar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(283, 21);
            this.textBox2.TabIndex = 162;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 160;
            this.label6.Text = "------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 161;
            this.label7.Text = "Material";
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Presentacion.Botones.btnExaminar;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(359, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 21);
            this.button4.TabIndex = 163;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(378, 189);
            this.dataGridView1.TabIndex = 159;
            // 
            // frmServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 392);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archivo - Servicio";
            this.Load += new System.EventHandler(this.frmServicio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultado_Impuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TBComision;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBClase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBServicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.TextBox TBIdservicio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBValor01;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBValor03;
        private System.Windows.Forms.TextBox TBValor02;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView DGResultado_Impuesto;
        private System.Windows.Forms.TextBox TBBuscar_Impuesto;
        private System.Windows.Forms.Label lblTotal_Impuesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExaminar_Impuesto;
        private System.Windows.Forms.Button btnAgregar_Impuesto;
        private System.Windows.Forms.Button btnEliminar_Impuesto;
        private System.Windows.Forms.Button brnEditar_Impuesto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}