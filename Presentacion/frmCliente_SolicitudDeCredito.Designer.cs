
namespace Presentacion
{
    partial class frmCliente_SolicitudDeCredito
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
            this.btnModificar_Credito = new System.Windows.Forms.Button();
            this.lblTotal_Credito = new System.Windows.Forms.Label();
            this.DGDetalle_Credito = new System.Windows.Forms.DataGridView();
            this.DTCre_Emision = new System.Windows.Forms.DateTimePicker();
            this.label33 = new System.Windows.Forms.Label();
            this.DTCre_Solicitud = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.TBCre_TasaAnual = new System.Windows.Forms.TextBox();
            this.TBCre_TasaMensual = new System.Windows.Forms.TextBox();
            this.TBCre_CuotaMeses = new System.Windows.Forms.TextBox();
            this.TBCre_InteresMora = new System.Windows.Forms.TextBox();
            this.TBCre_DiasDeProrroga = new System.Windows.Forms.TextBox();
            this.TBCre_Valor = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnEliminar_Credito = new System.Windows.Forms.Button();
            this.btnAgregar_Credito = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalle_Credito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModificar_Credito);
            this.groupBox1.Controls.Add(this.lblTotal_Credito);
            this.groupBox1.Controls.Add(this.DGDetalle_Credito);
            this.groupBox1.Controls.Add(this.DTCre_Emision);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.DTCre_Solicitud);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label71);
            this.groupBox1.Controls.Add(this.TBCre_TasaAnual);
            this.groupBox1.Controls.Add(this.TBCre_TasaMensual);
            this.groupBox1.Controls.Add(this.TBCre_CuotaMeses);
            this.groupBox1.Controls.Add(this.TBCre_InteresMora);
            this.groupBox1.Controls.Add(this.TBCre_DiasDeProrroga);
            this.groupBox1.Controls.Add(this.TBCre_Valor);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.btnEliminar_Credito);
            this.groupBox1.Controls.Add(this.btnAgregar_Credito);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnModificar_Credito
            // 
            this.btnModificar_Credito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar_Credito.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnModificar_Credito.FlatAppearance.BorderSize = 0;
            this.btnModificar_Credito.Image = global::Presentacion.Botones.btnEditar;
            this.btnModificar_Credito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar_Credito.Location = new System.Drawing.Point(396, 376);
            this.btnModificar_Credito.Name = "btnModificar_Credito";
            this.btnModificar_Credito.Size = new System.Drawing.Size(120, 30);
            this.btnModificar_Credito.TabIndex = 192;
            this.btnModificar_Credito.Text = "Modificar - F8";
            this.btnModificar_Credito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar_Credito.UseVisualStyleBackColor = true;
            // 
            // lblTotal_Credito
            // 
            this.lblTotal_Credito.AutoSize = true;
            this.lblTotal_Credito.Location = new System.Drawing.Point(2, 383);
            this.lblTotal_Credito.Name = "lblTotal_Credito";
            this.lblTotal_Credito.Size = new System.Drawing.Size(124, 17);
            this.lblTotal_Credito.TabIndex = 191;
            this.lblTotal_Credito.Text = "Datos Registrados: 0";
            // 
            // DGDetalle_Credito
            // 
            this.DGDetalle_Credito.AllowUserToAddRows = false;
            this.DGDetalle_Credito.AllowUserToDeleteRows = false;
            this.DGDetalle_Credito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGDetalle_Credito.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGDetalle_Credito.BackgroundColor = System.Drawing.Color.White;
            this.DGDetalle_Credito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDetalle_Credito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGDetalle_Credito.Location = new System.Drawing.Point(2, 133);
            this.DGDetalle_Credito.Name = "DGDetalle_Credito";
            this.DGDetalle_Credito.ReadOnly = true;
            this.DGDetalle_Credito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGDetalle_Credito.Size = new System.Drawing.Size(644, 237);
            this.DGDetalle_Credito.TabIndex = 188;
            // 
            // DTCre_Emision
            // 
            this.DTCre_Emision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTCre_Emision.Location = new System.Drawing.Point(475, 77);
            this.DTCre_Emision.Name = "DTCre_Emision";
            this.DTCre_Emision.Size = new System.Drawing.Size(171, 22);
            this.DTCre_Emision.TabIndex = 187;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(327, 79);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(106, 17);
            this.label33.TabIndex = 186;
            this.label33.Text = "Fecha de Emisión";
            // 
            // DTCre_Solicitud
            // 
            this.DTCre_Solicitud.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTCre_Solicitud.Location = new System.Drawing.Point(150, 77);
            this.DTCre_Solicitud.Name = "DTCre_Solicitud";
            this.DTCre_Solicitud.Size = new System.Drawing.Size(171, 22);
            this.DTCre_Solicitud.TabIndex = 185;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 79);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(109, 17);
            this.label29.TabIndex = 184;
            this.label29.Text = "Fecha de Solicitud";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(327, 52);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(127, 17);
            this.label71.TabIndex = 183;
            this.label71.Text = "Tasa de Interes Anual";
            // 
            // TBCre_TasaAnual
            // 
            this.TBCre_TasaAnual.Location = new System.Drawing.Point(475, 49);
            this.TBCre_TasaAnual.Name = "TBCre_TasaAnual";
            this.TBCre_TasaAnual.Size = new System.Drawing.Size(171, 22);
            this.TBCre_TasaAnual.TabIndex = 182;
            this.TBCre_TasaAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCre_TasaMensual
            // 
            this.TBCre_TasaMensual.Location = new System.Drawing.Point(150, 49);
            this.TBCre_TasaMensual.Name = "TBCre_TasaMensual";
            this.TBCre_TasaMensual.Size = new System.Drawing.Size(171, 22);
            this.TBCre_TasaMensual.TabIndex = 180;
            this.TBCre_TasaMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCre_CuotaMeses
            // 
            this.TBCre_CuotaMeses.Location = new System.Drawing.Point(527, 21);
            this.TBCre_CuotaMeses.Name = "TBCre_CuotaMeses";
            this.TBCre_CuotaMeses.Size = new System.Drawing.Size(119, 22);
            this.TBCre_CuotaMeses.TabIndex = 179;
            this.TBCre_CuotaMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCre_InteresMora
            // 
            this.TBCre_InteresMora.Location = new System.Drawing.Point(475, 105);
            this.TBCre_InteresMora.Name = "TBCre_InteresMora";
            this.TBCre_InteresMora.Size = new System.Drawing.Size(171, 22);
            this.TBCre_InteresMora.TabIndex = 177;
            this.TBCre_InteresMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCre_DiasDeProrroga
            // 
            this.TBCre_DiasDeProrroga.Location = new System.Drawing.Point(150, 105);
            this.TBCre_DiasDeProrroga.Name = "TBCre_DiasDeProrroga";
            this.TBCre_DiasDeProrroga.Size = new System.Drawing.Size(171, 22);
            this.TBCre_DiasDeProrroga.TabIndex = 175;
            this.TBCre_DiasDeProrroga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCre_Valor
            // 
            this.TBCre_Valor.Location = new System.Drawing.Point(150, 21);
            this.TBCre_Valor.Name = "TBCre_Valor";
            this.TBCre_Valor.Size = new System.Drawing.Size(171, 22);
            this.TBCre_Valor.TabIndex = 172;
            this.TBCre_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(6, 52);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(142, 17);
            this.label51.TabIndex = 181;
            this.label51.Text = "Tasa de Interes Mensual";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(134, 17);
            this.label22.TabIndex = 178;
            this.label22.Text = "Valor Inicial del Credíto";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(327, 108);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(144, 17);
            this.label31.TabIndex = 176;
            this.label31.Text = "Tasa de Interes por Mora";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 108);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(101, 17);
            this.label30.TabIndex = 174;
            this.label30.Text = "Dias de Prorroga";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(327, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(194, 17);
            this.label28.TabIndex = 173;
            this.label28.Text = "Cuota de Financiamiento (Meses)";
            // 
            // btnEliminar_Credito
            // 
            this.btnEliminar_Credito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_Credito.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar_Credito.FlatAppearance.BorderSize = 0;
            this.btnEliminar_Credito.Image = global::Presentacion.Botones.btnEliminar;
            this.btnEliminar_Credito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar_Credito.Location = new System.Drawing.Point(522, 376);
            this.btnEliminar_Credito.Name = "btnEliminar_Credito";
            this.btnEliminar_Credito.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar_Credito.TabIndex = 190;
            this.btnEliminar_Credito.Text = "Eliminar - F4";
            this.btnEliminar_Credito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar_Credito.UseVisualStyleBackColor = true;
            // 
            // btnAgregar_Credito
            // 
            this.btnAgregar_Credito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar_Credito.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar_Credito.FlatAppearance.BorderSize = 0;
            this.btnAgregar_Credito.Image = global::Presentacion.Botones.btnAgregar;
            this.btnAgregar_Credito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar_Credito.Location = new System.Drawing.Point(270, 376);
            this.btnAgregar_Credito.Name = "btnAgregar_Credito";
            this.btnAgregar_Credito.Size = new System.Drawing.Size(120, 30);
            this.btnAgregar_Credito.TabIndex = 189;
            this.btnAgregar_Credito.Text = "Agregar - F3";
            this.btnAgregar_Credito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar_Credito.UseVisualStyleBackColor = true;
            // 
            // frmCliente_SolicitudDeCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 454);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCliente_SolicitudDeCredito";
            this.Text = "frmCliente_SolicitudDeCredito";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGDetalle_Credito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnModificar_Credito;
        private System.Windows.Forms.Label lblTotal_Credito;
        private System.Windows.Forms.DataGridView DGDetalle_Credito;
        private System.Windows.Forms.DateTimePicker DTCre_Emision;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DateTimePicker DTCre_Solicitud;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox TBCre_TasaAnual;
        private System.Windows.Forms.TextBox TBCre_TasaMensual;
        private System.Windows.Forms.TextBox TBCre_CuotaMeses;
        private System.Windows.Forms.TextBox TBCre_InteresMora;
        private System.Windows.Forms.TextBox TBCre_DiasDeProrroga;
        private System.Windows.Forms.TextBox TBCre_Valor;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnEliminar_Credito;
        private System.Windows.Forms.Button btnAgregar_Credito;
    }
}