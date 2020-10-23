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
            this.btnAgregarEmpl_Factura = new System.Windows.Forms.Button();
            this.lblTotal_Facturacion = new System.Windows.Forms.Label();
            this.DGFiltro_Resultados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TBBuscar_Factura = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAgregarEmpl_General = new System.Windows.Forms.Button();
            this.lblTotal_General = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.TBBuscar_General = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBDepartamento = new System.Windows.Forms.TextBox();
            this.TBPresentacion = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.TBCodigo = new System.Windows.Forms.TextBox();
            this.TBDescripcion01 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBDocumento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBEmpleado = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_Resultados)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 399);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Empleado y Datos Basicos - Leal Enterprise";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(504, 368);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAgregarEmpl_Factura);
            this.tabPage1.Controls.Add(this.lblTotal_Facturacion);
            this.tabPage1.Controls.Add(this.DGFiltro_Resultados);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TBBuscar_Factura);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(496, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filtro de Facturación";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAgregarEmpl_Factura
            // 
            this.btnAgregarEmpl_Factura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarEmpl_Factura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpl_Factura.FlatAppearance.BorderSize = 0;
            this.btnAgregarEmpl_Factura.Image = global::Presentacion.Properties.Resources.btnAgregar;
            this.btnAgregarEmpl_Factura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEmpl_Factura.Location = new System.Drawing.Point(6, 304);
            this.btnAgregarEmpl_Factura.Name = "btnAgregarEmpl_Factura";
            this.btnAgregarEmpl_Factura.Size = new System.Drawing.Size(140, 30);
            this.btnAgregarEmpl_Factura.TabIndex = 6;
            this.btnAgregarEmpl_Factura.Text = "Agregar Empleado";
            this.btnAgregarEmpl_Factura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEmpl_Factura.UseVisualStyleBackColor = true;
            this.btnAgregarEmpl_Factura.Click += new System.EventHandler(this.btnAgregarEmpl_Factura_Click);
            // 
            // lblTotal_Facturacion
            // 
            this.lblTotal_Facturacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal_Facturacion.AutoSize = true;
            this.lblTotal_Facturacion.Location = new System.Drawing.Point(152, 312);
            this.lblTotal_Facturacion.Name = "lblTotal_Facturacion";
            this.lblTotal_Facturacion.Size = new System.Drawing.Size(104, 15);
            this.lblTotal_Facturacion.TabIndex = 5;
            this.lblTotal_Facturacion.Text = "Datos Registrados:";
            // 
            // DGFiltro_Resultados
            // 
            this.DGFiltro_Resultados.AllowUserToAddRows = false;
            this.DGFiltro_Resultados.AllowUserToDeleteRows = false;
            this.DGFiltro_Resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGFiltro_Resultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGFiltro_Resultados.BackgroundColor = System.Drawing.Color.White;
            this.DGFiltro_Resultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGFiltro_Resultados.Location = new System.Drawing.Point(8, 35);
            this.DGFiltro_Resultados.Name = "DGFiltro_Resultados";
            this.DGFiltro_Resultados.ReadOnly = true;
            this.DGFiltro_Resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGFiltro_Resultados.Size = new System.Drawing.Size(480, 263);
            this.DGFiltro_Resultados.TabIndex = 3;
            this.DGFiltro_Resultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGFiltro_Resultados_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empleado a Consultar";
            // 
            // TBBuscar_Factura
            // 
            this.TBBuscar_Factura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar_Factura.Location = new System.Drawing.Point(137, 6);
            this.TBBuscar_Factura.Name = "TBBuscar_Factura";
            this.TBBuscar_Factura.Size = new System.Drawing.Size(351, 23);
            this.TBBuscar_Factura.TabIndex = 1;
            this.TBBuscar_Factura.TextChanged += new System.EventHandler(this.TBBuscar_Factura_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAgregarEmpl_General);
            this.tabPage2.Controls.Add(this.lblTotal_General);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.TBBuscar_General);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(496, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Filtro General";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAgregarEmpl_General
            // 
            this.btnAgregarEmpl_General.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarEmpl_General.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpl_General.FlatAppearance.BorderSize = 0;
            this.btnAgregarEmpl_General.Image = global::Presentacion.Properties.Resources.btnAgregar;
            this.btnAgregarEmpl_General.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEmpl_General.Location = new System.Drawing.Point(6, 304);
            this.btnAgregarEmpl_General.Name = "btnAgregarEmpl_General";
            this.btnAgregarEmpl_General.Size = new System.Drawing.Size(140, 30);
            this.btnAgregarEmpl_General.TabIndex = 11;
            this.btnAgregarEmpl_General.Text = "Agregar Empleado";
            this.btnAgregarEmpl_General.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEmpl_General.UseVisualStyleBackColor = true;
            this.btnAgregarEmpl_General.Click += new System.EventHandler(this.btnAgregarEmpl_General_Click);
            // 
            // lblTotal_General
            // 
            this.lblTotal_General.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal_General.AutoSize = true;
            this.lblTotal_General.Location = new System.Drawing.Point(152, 312);
            this.lblTotal_General.Name = "lblTotal_General";
            this.lblTotal_General.Size = new System.Drawing.Size(104, 15);
            this.lblTotal_General.TabIndex = 10;
            this.lblTotal_General.Text = "Datos Registrados:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Location = new System.Drawing.Point(8, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(480, 263);
            this.dataGridView1.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Empleado a Consultar";
            // 
            // TBBuscar_General
            // 
            this.TBBuscar_General.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar_General.Location = new System.Drawing.Point(137, 6);
            this.TBBuscar_General.Name = "TBBuscar_General";
            this.TBBuscar_General.Size = new System.Drawing.Size(351, 23);
            this.TBBuscar_General.TabIndex = 8;
            this.TBBuscar_General.TextChanged += new System.EventHandler(this.TBBuscar_General_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TBDepartamento);
            this.groupBox2.Controls.Add(this.TBPresentacion);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.TBCodigo);
            this.groupBox2.Controls.Add(this.TBDescripcion01);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TBDocumento);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TBEmpleado);
            this.groupBox2.Location = new System.Drawing.Point(534, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 398);
            this.groupBox2.TabIndex = 174;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Basicos del Producto - Leal Enterprise";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Codigo";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 149;
            this.label6.Text = "Departamento";
            // 
            // TBDepartamento
            // 
            this.TBDepartamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDepartamento.Location = new System.Drawing.Point(91, 155);
            this.TBDepartamento.Name = "TBDepartamento";
            this.TBDepartamento.Size = new System.Drawing.Size(300, 23);
            this.TBDepartamento.TabIndex = 155;
            // 
            // TBPresentacion
            // 
            this.TBPresentacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBPresentacion.Location = new System.Drawing.Point(91, 128);
            this.TBPresentacion.Name = "TBPresentacion";
            this.TBPresentacion.Size = new System.Drawing.Size(300, 23);
            this.TBPresentacion.TabIndex = 37;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 131);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 15);
            this.label25.TabIndex = 36;
            this.label25.Text = "Cargo";
            // 
            // TBCodigo
            // 
            this.TBCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBCodigo.Location = new System.Drawing.Point(91, 20);
            this.TBCodigo.Name = "TBCodigo";
            this.TBCodigo.Size = new System.Drawing.Size(300, 23);
            this.TBCodigo.TabIndex = 29;
            // 
            // TBDescripcion01
            // 
            this.TBDescripcion01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDescripcion01.Location = new System.Drawing.Point(91, 101);
            this.TBDescripcion01.Name = "TBDescripcion01";
            this.TBDescripcion01.Size = new System.Drawing.Size(300, 23);
            this.TBDescripcion01.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Empleado";
            // 
            // TBDocumento
            // 
            this.TBDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDocumento.Location = new System.Drawing.Point(91, 74);
            this.TBDocumento.Name = "TBDocumento";
            this.TBDocumento.Size = new System.Drawing.Size(300, 23);
            this.TBDocumento.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "Profesión";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Documento";
            // 
            // TBEmpleado
            // 
            this.TBEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBEmpleado.Location = new System.Drawing.Point(91, 47);
            this.TBEmpleado.Name = "TBEmpleado";
            this.TBEmpleado.Size = new System.Drawing.Size(300, 23);
            this.TBEmpleado.TabIndex = 31;
            // 
            // frmFiltro_Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 419);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmFiltro_Empleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro de Empleado - Leal Enterprise";
            this.Load += new System.EventHandler(this.frmFiltro_Empleado_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGFiltro_Resultados)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGFiltro_Resultados;
        private System.Windows.Forms.TextBox TBBuscar_Factura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBDepartamento;
        private System.Windows.Forms.TextBox TBPresentacion;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox TBCodigo;
        private System.Windows.Forms.TextBox TBDescripcion01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBEmpleado;
        private System.Windows.Forms.Button btnAgregarEmpl_Factura;
        private System.Windows.Forms.Label lblTotal_Facturacion;
        private System.Windows.Forms.Button btnAgregarEmpl_General;
        private System.Windows.Forms.Label lblTotal_General;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBBuscar_General;
    }
}