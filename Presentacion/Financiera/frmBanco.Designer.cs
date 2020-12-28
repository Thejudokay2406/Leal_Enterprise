
namespace Presentacion
{
    partial class frmBanco
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.TCPrincipal = new System.Windows.Forms.TabControl();
            this.TPDatosBasicos = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.TBExtension02 = new System.Windows.Forms.TextBox();
            this.TBExtension01 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.TBMovil02 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TBTelefono02 = new System.Windows.Forms.TextBox();
            this.TBDireccion02 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TBPaginaWEB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TBMovil01 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TBDireccion01 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TBArea = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBCiudad = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBPais = new System.Windows.Forms.TextBox();
            this.TBDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.TBCont_Area = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TBCont_Ciudad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TBCont_Telefono = new System.Windows.Forms.TextBox();
            this.TBCont_Observacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TBCont_Movil = new System.Windows.Forms.TextBox();
            this.TBAsesor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TBCont_Extension = new System.Windows.Forms.TextBox();
            this.TBCargo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DGDetalle_Contacto = new System.Windows.Forms.DataGridView();
            this.lblTotal_Contacto = new System.Windows.Forms.Label();
            this.btnModificar_Banco = new System.Windows.Forms.Button();
            this.btnEliminar_Banco = new System.Windows.Forms.Button();
            this.btnAgregar_Banco = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TBIdbanco = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.TBIdbanco_AutoSQL = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.TCPrincipal.SuspendLayout();
            this.TPDatosBasicos.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalle_Contacto)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.TCPrincipal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Bancos - Leal Enterprise";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(132, 398);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar - F9";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(6, 398);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar - F10";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(311, 398);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar - F4";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::Presentacion.Botones.btnImprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(437, 398);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 30);
            this.btnImprimir.TabIndex = 11;
            this.btnImprimir.Text = "Imprimir - F11";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // TCPrincipal
            // 
            this.TCPrincipal.Controls.Add(this.TPDatosBasicos);
            this.TCPrincipal.Controls.Add(this.tabPage2);
            this.TCPrincipal.Location = new System.Drawing.Point(6, 21);
            this.TCPrincipal.Name = "TCPrincipal";
            this.TCPrincipal.SelectedIndex = 0;
            this.TCPrincipal.Size = new System.Drawing.Size(551, 371);
            this.TCPrincipal.TabIndex = 8;
            // 
            // TPDatosBasicos
            // 
            this.TPDatosBasicos.Controls.Add(this.label22);
            this.TPDatosBasicos.Controls.Add(this.TBExtension02);
            this.TPDatosBasicos.Controls.Add(this.TBExtension01);
            this.TPDatosBasicos.Controls.Add(this.label21);
            this.TPDatosBasicos.Controls.Add(this.TBMovil02);
            this.TPDatosBasicos.Controls.Add(this.label18);
            this.TPDatosBasicos.Controls.Add(this.label17);
            this.TPDatosBasicos.Controls.Add(this.TBTelefono02);
            this.TPDatosBasicos.Controls.Add(this.TBDireccion02);
            this.TPDatosBasicos.Controls.Add(this.label16);
            this.TPDatosBasicos.Controls.Add(this.TBPaginaWEB);
            this.TPDatosBasicos.Controls.Add(this.label15);
            this.TPDatosBasicos.Controls.Add(this.TBMovil01);
            this.TPDatosBasicos.Controls.Add(this.label14);
            this.TPDatosBasicos.Controls.Add(this.TBTelefono);
            this.TPDatosBasicos.Controls.Add(this.label13);
            this.TPDatosBasicos.Controls.Add(this.TBDireccion01);
            this.TPDatosBasicos.Controls.Add(this.label12);
            this.TPDatosBasicos.Controls.Add(this.TBArea);
            this.TPDatosBasicos.Controls.Add(this.label5);
            this.TPDatosBasicos.Controls.Add(this.label1);
            this.TPDatosBasicos.Controls.Add(this.TBCiudad);
            this.TPDatosBasicos.Controls.Add(this.TBNombre);
            this.TPDatosBasicos.Controls.Add(this.label4);
            this.TPDatosBasicos.Controls.Add(this.label2);
            this.TPDatosBasicos.Controls.Add(this.TBPais);
            this.TPDatosBasicos.Controls.Add(this.TBDocumento);
            this.TPDatosBasicos.Controls.Add(this.label3);
            this.TPDatosBasicos.Location = new System.Drawing.Point(4, 26);
            this.TPDatosBasicos.Name = "TPDatosBasicos";
            this.TPDatosBasicos.Padding = new System.Windows.Forms.Padding(3);
            this.TPDatosBasicos.Size = new System.Drawing.Size(543, 341);
            this.TPDatosBasicos.TabIndex = 0;
            this.TPDatosBasicos.Text = "Datos Basicos";
            this.TPDatosBasicos.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(350, 233);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 17);
            this.label22.TabIndex = 27;
            this.label22.Text = "Extensión";
            // 
            // TBExtension02
            // 
            this.TBExtension02.Location = new System.Drawing.Point(417, 230);
            this.TBExtension02.Name = "TBExtension02";
            this.TBExtension02.Size = new System.Drawing.Size(120, 22);
            this.TBExtension02.TabIndex = 26;
            this.TBExtension02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBExtension02.Enter += new System.EventHandler(this.TBExtension02_Enter);
            this.TBExtension02.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBExtension02_KeyUp);
            this.TBExtension02.Leave += new System.EventHandler(this.TBExtension02_Leave);
            // 
            // TBExtension01
            // 
            this.TBExtension01.Location = new System.Drawing.Point(417, 202);
            this.TBExtension01.Name = "TBExtension01";
            this.TBExtension01.Size = new System.Drawing.Size(120, 22);
            this.TBExtension01.TabIndex = 25;
            this.TBExtension01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBExtension01.Enter += new System.EventHandler(this.TBExtension01_Enter);
            this.TBExtension01.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBExtension01_KeyUp);
            this.TBExtension01.Leave += new System.EventHandler(this.TBExtension01_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(350, 205);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 17);
            this.label21.TabIndex = 24;
            this.label21.Text = "Extensión";
            // 
            // TBMovil02
            // 
            this.TBMovil02.Location = new System.Drawing.Point(353, 258);
            this.TBMovil02.Name = "TBMovil02";
            this.TBMovil02.Size = new System.Drawing.Size(184, 22);
            this.TBMovil02.TabIndex = 23;
            this.TBMovil02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBMovil02.Enter += new System.EventHandler(this.TBMovil02_Enter);
            this.TBMovil02.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBMovil02_KeyUp);
            this.TBMovil02.Leave += new System.EventHandler(this.TBMovil02_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 261);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 17);
            this.label18.TabIndex = 22;
            this.label18.Text = "Movil Principal";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 233);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 17);
            this.label17.TabIndex = 21;
            this.label17.Text = "Telefono Aux.";
            // 
            // TBTelefono02
            // 
            this.TBTelefono02.Location = new System.Drawing.Point(94, 230);
            this.TBTelefono02.Name = "TBTelefono02";
            this.TBTelefono02.Size = new System.Drawing.Size(250, 22);
            this.TBTelefono02.TabIndex = 20;
            this.TBTelefono02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBTelefono02.Enter += new System.EventHandler(this.TBTelefono02_Enter);
            this.TBTelefono02.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBTelefono02_KeyUp);
            this.TBTelefono02.Leave += new System.EventHandler(this.TBTelefono02_Leave);
            // 
            // TBDireccion02
            // 
            this.TBDireccion02.Location = new System.Drawing.Point(94, 174);
            this.TBDireccion02.Name = "TBDireccion02";
            this.TBDireccion02.Size = new System.Drawing.Size(443, 22);
            this.TBDireccion02.TabIndex = 19;
            this.TBDireccion02.Enter += new System.EventHandler(this.TBDireccion02_Enter);
            this.TBDireccion02.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBDireccion02_KeyUp);
            this.TBDireccion02.Leave += new System.EventHandler(this.TBDireccion02_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 17);
            this.label16.TabIndex = 18;
            this.label16.Text = "Dirección Aux.";
            // 
            // TBPaginaWEB
            // 
            this.TBPaginaWEB.Location = new System.Drawing.Point(94, 286);
            this.TBPaginaWEB.Name = "TBPaginaWEB";
            this.TBPaginaWEB.Size = new System.Drawing.Size(443, 22);
            this.TBPaginaWEB.TabIndex = 17;
            this.TBPaginaWEB.Enter += new System.EventHandler(this.TBPaginaWEB_Enter);
            this.TBPaginaWEB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBPaginaWEB_KeyUp);
            this.TBPaginaWEB.Leave += new System.EventHandler(this.TBPaginaWEB_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 17);
            this.label15.TabIndex = 16;
            this.label15.Text = "Pagina WEB";
            // 
            // TBMovil01
            // 
            this.TBMovil01.Location = new System.Drawing.Point(94, 258);
            this.TBMovil01.Name = "TBMovil01";
            this.TBMovil01.Size = new System.Drawing.Size(181, 22);
            this.TBMovil01.TabIndex = 15;
            this.TBMovil01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBMovil01.Enter += new System.EventHandler(this.TBMovil01_Enter);
            this.TBMovil01.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBMovil01_KeyUp);
            this.TBMovil01.Leave += new System.EventHandler(this.TBMovil01_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(281, 261);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Movil Aux.";
            // 
            // TBTelefono
            // 
            this.TBTelefono.Location = new System.Drawing.Point(94, 202);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(250, 22);
            this.TBTelefono.TabIndex = 13;
            this.TBTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBTelefono.Enter += new System.EventHandler(this.TBTelefono_Enter);
            this.TBTelefono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBTelefono_KeyUp);
            this.TBTelefono.Leave += new System.EventHandler(this.TBTelefono_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Telefono";
            // 
            // TBDireccion01
            // 
            this.TBDireccion01.Location = new System.Drawing.Point(94, 146);
            this.TBDireccion01.Name = "TBDireccion01";
            this.TBDireccion01.Size = new System.Drawing.Size(443, 22);
            this.TBDireccion01.TabIndex = 11;
            this.TBDireccion01.Enter += new System.EventHandler(this.TBDireccion01_Enter);
            this.TBDireccion01.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBDireccion01_KeyUp);
            this.TBDireccion01.Leave += new System.EventHandler(this.TBDireccion01_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Dirección";
            // 
            // TBArea
            // 
            this.TBArea.Location = new System.Drawing.Point(94, 118);
            this.TBArea.Name = "TBArea";
            this.TBArea.Size = new System.Drawing.Size(443, 22);
            this.TBArea.TabIndex = 9;
            this.TBArea.Enter += new System.EventHandler(this.TBArea_Enter);
            this.TBArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBArea_KeyUp);
            this.TBArea.Leave += new System.EventHandler(this.TBArea_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Area";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // TBCiudad
            // 
            this.TBCiudad.Location = new System.Drawing.Point(94, 90);
            this.TBCiudad.Name = "TBCiudad";
            this.TBCiudad.Size = new System.Drawing.Size(443, 22);
            this.TBCiudad.TabIndex = 7;
            this.TBCiudad.Enter += new System.EventHandler(this.TBCiudad_Enter);
            this.TBCiudad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCiudad_KeyUp);
            this.TBCiudad.Leave += new System.EventHandler(this.TBCiudad_Leave);
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(94, 6);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(443, 22);
            this.TBNombre.TabIndex = 1;
            this.TBNombre.Enter += new System.EventHandler(this.TBNombre_Enter);
            this.TBNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBNombre_KeyUp);
            this.TBNombre.Leave += new System.EventHandler(this.TBNombre_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Identificación";
            // 
            // TBPais
            // 
            this.TBPais.Location = new System.Drawing.Point(94, 62);
            this.TBPais.Name = "TBPais";
            this.TBPais.Size = new System.Drawing.Size(443, 22);
            this.TBPais.TabIndex = 5;
            this.TBPais.Enter += new System.EventHandler(this.TBPais_Enter);
            this.TBPais.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBPais_KeyUp);
            this.TBPais.Leave += new System.EventHandler(this.TBPais_Leave);
            // 
            // TBDocumento
            // 
            this.TBDocumento.Location = new System.Drawing.Point(94, 34);
            this.TBDocumento.Name = "TBDocumento";
            this.TBDocumento.Size = new System.Drawing.Size(443, 22);
            this.TBDocumento.TabIndex = 3;
            this.TBDocumento.Enter += new System.EventHandler(this.TBDocumento_Enter);
            this.TBDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBDocumento_KeyUp);
            this.TBDocumento.Leave += new System.EventHandler(this.TBDocumento_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "País";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.TBCont_Area);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.TBCont_Ciudad);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.TBCont_Telefono);
            this.tabPage2.Controls.Add(this.TBCont_Observacion);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.TBCont_Movil);
            this.tabPage2.Controls.Add(this.TBAsesor);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.TBCont_Extension);
            this.tabPage2.Controls.Add(this.TBCargo);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.DGDetalle_Contacto);
            this.tabPage2.Controls.Add(this.lblTotal_Contacto);
            this.tabPage2.Controls.Add(this.btnModificar_Banco);
            this.tabPage2.Controls.Add(this.btnEliminar_Banco);
            this.tabPage2.Controls.Add(this.btnAgregar_Banco);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(543, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contacto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 17);
            this.label20.TabIndex = 193;
            this.label20.Text = "Observación";
            // 
            // TBCont_Area
            // 
            this.TBCont_Area.Location = new System.Drawing.Point(374, 90);
            this.TBCont_Area.Name = "TBCont_Area";
            this.TBCont_Area.Size = new System.Drawing.Size(163, 22);
            this.TBCont_Area.TabIndex = 192;
            this.TBCont_Area.Enter += new System.EventHandler(this.TBCont_Area_Enter);
            this.TBCont_Area.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCont_Area_KeyUp);
            this.TBCont_Area.Leave += new System.EventHandler(this.TBCont_Area_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(307, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 17);
            this.label19.TabIndex = 191;
            this.label19.Text = "Ciudad";
            // 
            // TBCont_Ciudad
            // 
            this.TBCont_Ciudad.Location = new System.Drawing.Point(374, 34);
            this.TBCont_Ciudad.Name = "TBCont_Ciudad";
            this.TBCont_Ciudad.Size = new System.Drawing.Size(163, 22);
            this.TBCont_Ciudad.TabIndex = 190;
            this.TBCont_Ciudad.Enter += new System.EventHandler(this.TBCont_Ciudad_Enter);
            this.TBCont_Ciudad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCont_Ciudad_KeyUp);
            this.TBCont_Ciudad.Leave += new System.EventHandler(this.TBCont_Ciudad_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(307, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 189;
            this.label11.Text = "Extensión";
            // 
            // TBCont_Telefono
            // 
            this.TBCont_Telefono.Location = new System.Drawing.Point(94, 62);
            this.TBCont_Telefono.Name = "TBCont_Telefono";
            this.TBCont_Telefono.Size = new System.Drawing.Size(207, 22);
            this.TBCont_Telefono.TabIndex = 188;
            this.TBCont_Telefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCont_Telefono.Enter += new System.EventHandler(this.TBCont_Telefono_Enter);
            this.TBCont_Telefono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCont_Telefono_KeyUp);
            this.TBCont_Telefono.Leave += new System.EventHandler(this.TBCont_Telefono_Leave);
            // 
            // TBCont_Observacion
            // 
            this.TBCont_Observacion.Location = new System.Drawing.Point(94, 118);
            this.TBCont_Observacion.Name = "TBCont_Observacion";
            this.TBCont_Observacion.Size = new System.Drawing.Size(443, 22);
            this.TBCont_Observacion.TabIndex = 187;
            this.TBCont_Observacion.Enter += new System.EventHandler(this.TBCont_Observacion_Enter);
            this.TBCont_Observacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCont_Observacion_KeyUp);
            this.TBCont_Observacion.Leave += new System.EventHandler(this.TBCont_Observacion_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 186;
            this.label6.Text = "Area";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 178;
            this.label7.Text = "Asesor";
            // 
            // TBCont_Movil
            // 
            this.TBCont_Movil.Location = new System.Drawing.Point(94, 90);
            this.TBCont_Movil.Name = "TBCont_Movil";
            this.TBCont_Movil.Size = new System.Drawing.Size(207, 22);
            this.TBCont_Movil.TabIndex = 185;
            this.TBCont_Movil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCont_Movil.Enter += new System.EventHandler(this.TBCont_Movil_Enter);
            this.TBCont_Movil.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCont_Movil_KeyUp);
            this.TBCont_Movil.Leave += new System.EventHandler(this.TBCont_Movil_Leave);
            // 
            // TBAsesor
            // 
            this.TBAsesor.Location = new System.Drawing.Point(94, 6);
            this.TBAsesor.Name = "TBAsesor";
            this.TBAsesor.Size = new System.Drawing.Size(443, 22);
            this.TBAsesor.TabIndex = 179;
            this.TBAsesor.Enter += new System.EventHandler(this.TBAsesor_Enter);
            this.TBAsesor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBAsesor_KeyUp);
            this.TBAsesor.Leave += new System.EventHandler(this.TBAsesor_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 184;
            this.label8.Text = "Movil";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 180;
            this.label9.Text = "Cargo";
            // 
            // TBCont_Extension
            // 
            this.TBCont_Extension.Location = new System.Drawing.Point(374, 62);
            this.TBCont_Extension.Name = "TBCont_Extension";
            this.TBCont_Extension.Size = new System.Drawing.Size(163, 22);
            this.TBCont_Extension.TabIndex = 183;
            this.TBCont_Extension.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBCont_Extension.Enter += new System.EventHandler(this.TBCont_Extension_Enter);
            this.TBCont_Extension.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCont_Extension_KeyUp);
            this.TBCont_Extension.Leave += new System.EventHandler(this.TBCont_Extension_Leave);
            // 
            // TBCargo
            // 
            this.TBCargo.Location = new System.Drawing.Point(94, 34);
            this.TBCargo.Name = "TBCargo";
            this.TBCargo.Size = new System.Drawing.Size(207, 22);
            this.TBCargo.TabIndex = 181;
            this.TBCargo.Enter += new System.EventHandler(this.TBCargo_Enter);
            this.TBCargo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBCargo_KeyUp);
            this.TBCargo.Leave += new System.EventHandler(this.TBCargo_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 182;
            this.label10.Text = "Telefono";
            // 
            // DGDetalle_Contacto
            // 
            this.DGDetalle_Contacto.AllowUserToAddRows = false;
            this.DGDetalle_Contacto.AllowUserToDeleteRows = false;
            this.DGDetalle_Contacto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGDetalle_Contacto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGDetalle_Contacto.BackgroundColor = System.Drawing.Color.White;
            this.DGDetalle_Contacto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDetalle_Contacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGDetalle_Contacto.Location = new System.Drawing.Point(6, 146);
            this.DGDetalle_Contacto.Name = "DGDetalle_Contacto";
            this.DGDetalle_Contacto.ReadOnly = true;
            this.DGDetalle_Contacto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGDetalle_Contacto.Size = new System.Drawing.Size(531, 153);
            this.DGDetalle_Contacto.TabIndex = 177;
            // 
            // lblTotal_Contacto
            // 
            this.lblTotal_Contacto.AutoSize = true;
            this.lblTotal_Contacto.Location = new System.Drawing.Point(6, 311);
            this.lblTotal_Contacto.Name = "lblTotal_Contacto";
            this.lblTotal_Contacto.Size = new System.Drawing.Size(118, 17);
            this.lblTotal_Contacto.TabIndex = 173;
            this.lblTotal_Contacto.Text = "Datos Agregados: 0";
            // 
            // btnModificar_Banco
            // 
            this.btnModificar_Banco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar_Banco.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnModificar_Banco.FlatAppearance.BorderSize = 0;
            this.btnModificar_Banco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar_Banco.Image = global::Presentacion.Botones.btnEditar;
            this.btnModificar_Banco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar_Banco.Location = new System.Drawing.Point(291, 305);
            this.btnModificar_Banco.Name = "btnModificar_Banco";
            this.btnModificar_Banco.Size = new System.Drawing.Size(120, 30);
            this.btnModificar_Banco.TabIndex = 176;
            this.btnModificar_Banco.Text = "Modificar - F8";
            this.btnModificar_Banco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar_Banco.UseVisualStyleBackColor = true;
            this.btnModificar_Banco.Click += new System.EventHandler(this.btnModificar_Banco_Click);
            // 
            // btnEliminar_Banco
            // 
            this.btnEliminar_Banco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_Banco.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar_Banco.FlatAppearance.BorderSize = 0;
            this.btnEliminar_Banco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar_Banco.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar_Banco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar_Banco.Location = new System.Drawing.Point(417, 305);
            this.btnEliminar_Banco.Name = "btnEliminar_Banco";
            this.btnEliminar_Banco.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar_Banco.TabIndex = 175;
            this.btnEliminar_Banco.Text = "Eliminar - F4";
            this.btnEliminar_Banco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar_Banco.UseVisualStyleBackColor = true;
            this.btnEliminar_Banco.Click += new System.EventHandler(this.btnEliminar_Banco_Click);
            // 
            // btnAgregar_Banco
            // 
            this.btnAgregar_Banco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar_Banco.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar_Banco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar_Banco.Image = global::Presentacion.Botones.btnAgregar;
            this.btnAgregar_Banco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar_Banco.Location = new System.Drawing.Point(165, 305);
            this.btnAgregar_Banco.Name = "btnAgregar_Banco";
            this.btnAgregar_Banco.Size = new System.Drawing.Size(120, 30);
            this.btnAgregar_Banco.TabIndex = 174;
            this.btnAgregar_Banco.Text = "Agregar - F3";
            this.btnAgregar_Banco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar_Banco.UseVisualStyleBackColor = true;
            this.btnAgregar_Banco.Click += new System.EventHandler(this.btnAgregar_Banco_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TBIdbanco_AutoSQL);
            this.groupBox2.Controls.Add(this.TBIdbanco);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.TBBuscar);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.DGResultados);
            this.groupBox2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(583, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 434);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Leal Enterprise - Consulta de Proveedores";
            // 
            // TBIdbanco
            // 
            this.TBIdbanco.Location = new System.Drawing.Point(141, 400);
            this.TBIdbanco.Name = "TBIdbanco";
            this.TBIdbanco.Size = new System.Drawing.Size(28, 22);
            this.TBIdbanco.TabIndex = 4;
            this.TBIdbanco.TextChanged += new System.EventHandler(this.TBIdbanco_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 23);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(118, 17);
            this.label31.TabIndex = 5;
            this.label31.Text = "Bancos Registrados";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(130, 20);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(380, 22);
            this.TBBuscar.TabIndex = 4;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            this.TBBuscar.Enter += new System.EventHandler(this.TBBuscar_Enter);
            this.TBBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBBuscar_KeyPress);
            this.TBBuscar.Leave += new System.EventHandler(this.TBBuscar_Leave);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 403);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(26, 17);
            this.lblTotal.TabIndex = 3;
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
            this.DGResultados.Size = new System.Drawing.Size(504, 344);
            this.DGResultados.TabIndex = 0;
            this.DGResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGResultados_CellDoubleClick);
            this.DGResultados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGResultados_KeyPress);
            // 
            // TBIdbanco_AutoSQL
            // 
            this.TBIdbanco_AutoSQL.Location = new System.Drawing.Point(175, 400);
            this.TBIdbanco_AutoSQL.Name = "TBIdbanco_AutoSQL";
            this.TBIdbanco_AutoSQL.Size = new System.Drawing.Size(41, 22);
            this.TBIdbanco_AutoSQL.TabIndex = 6;
            this.TBIdbanco_AutoSQL.TextChanged += new System.EventHandler(this.TBIdbanco_AutoSQL_TextChanged);
            // 
            // frmBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financiera - Leal Enterprise";
            this.Activated += new System.EventHandler(this.frmBanco_Activated);
            this.Load += new System.EventHandler(this.frmBanco_Load);
            this.groupBox1.ResumeLayout(false);
            this.TCPrincipal.ResumeLayout(false);
            this.TPDatosBasicos.ResumeLayout(false);
            this.TPDatosBasicos.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalle_Contacto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.TextBox TBCiudad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBPais;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl TCPrincipal;
        private System.Windows.Forms.TabPage TPDatosBasicos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TBArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView DGDetalle_Contacto;
        private System.Windows.Forms.Label lblTotal_Contacto;
        private System.Windows.Forms.Button btnModificar_Banco;
        private System.Windows.Forms.Button btnEliminar_Banco;
        private System.Windows.Forms.Button btnAgregar_Banco;
        private System.Windows.Forms.TextBox TBCont_Observacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBCont_Movil;
        private System.Windows.Forms.TextBox TBAsesor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBCont_Extension;
        private System.Windows.Forms.TextBox TBCargo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBCont_Telefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBMovil01;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TBDireccion01;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TBPaginaWEB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TBMovil02;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TBTelefono02;
        private System.Windows.Forms.TextBox TBDireccion02;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TBIdbanco;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TBCont_Ciudad;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TBCont_Area;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox TBExtension02;
        private System.Windows.Forms.TextBox TBExtension01;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TBIdbanco_AutoSQL;
    }
}