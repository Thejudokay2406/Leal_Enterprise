namespace Presentacion
{
    partial class frmTotalizar_CotizacionDeCompra
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.TBDiasDeEntrega = new System.Windows.Forms.TextBox();
            this.CHVencimiento = new System.Windows.Forms.CheckBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.TBImpuesto_Valor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBDescuento_Porcentaje = new System.Windows.Forms.TextBox();
            this.TBDescuento = new System.Windows.Forms.TextBox();
            this.TBSubTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBValorGeneral = new System.Windows.Forms.TextBox();
            this.TBCreditoDisponible = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TBCreditoMora = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.TBTipoDePago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TBValorDeEnvio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Presentacion.Titulos.Totalizacion___Cotizacion_de_Compra;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(401, 25);
            this.panel3.TabIndex = 10;
            // 
            // TBDiasDeEntrega
            // 
            this.TBDiasDeEntrega.Location = new System.Drawing.Point(144, 57);
            this.TBDiasDeEntrega.Name = "TBDiasDeEntrega";
            this.TBDiasDeEntrega.Size = new System.Drawing.Size(250, 21);
            this.TBDiasDeEntrega.TabIndex = 1;
            // 
            // CHVencimiento
            // 
            this.CHVencimiento.AutoSize = true;
            this.CHVencimiento.Checked = true;
            this.CHVencimiento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHVencimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CHVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHVencimiento.Location = new System.Drawing.Point(144, 86);
            this.CHVencimiento.Name = "CHVencimiento";
            this.CHVencimiento.Size = new System.Drawing.Size(58, 17);
            this.CHVencimiento.TabIndex = 214;
            this.CHVencimiento.Text = "Si - No";
            this.CHVencimiento.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(208, 84);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(105, 21);
            this.dateTimePicker3.TabIndex = 213;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 15);
            this.label11.TabIndex = 212;
            this.label11.Text = "Aplica Vencimiento";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.TBImpuesto_Valor);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TBDescuento_Porcentaje);
            this.panel2.Controls.Add(this.TBDescuento);
            this.panel2.Controls.Add(this.TBSubTotal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TBValorGeneral);
            this.panel2.Location = new System.Drawing.Point(12, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 114);
            this.panel2.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Impuesto";
            // 
            // TBImpuesto_Valor
            // 
            this.TBImpuesto_Valor.Location = new System.Drawing.Point(144, 57);
            this.TBImpuesto_Valor.Name = "TBImpuesto_Valor";
            this.TBImpuesto_Valor.Size = new System.Drawing.Size(250, 21);
            this.TBImpuesto_Valor.TabIndex = 15;
            this.TBImpuesto_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Valor General";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sub Total";
            // 
            // TBDescuento_Porcentaje
            // 
            this.TBDescuento_Porcentaje.Location = new System.Drawing.Point(144, 30);
            this.TBDescuento_Porcentaje.Name = "TBDescuento_Porcentaje";
            this.TBDescuento_Porcentaje.Size = new System.Drawing.Size(70, 21);
            this.TBDescuento_Porcentaje.TabIndex = 14;
            this.TBDescuento_Porcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBDescuento
            // 
            this.TBDescuento.Location = new System.Drawing.Point(220, 30);
            this.TBDescuento.Name = "TBDescuento";
            this.TBDescuento.Size = new System.Drawing.Size(174, 21);
            this.TBDescuento.TabIndex = 3;
            this.TBDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBSubTotal
            // 
            this.TBSubTotal.Location = new System.Drawing.Point(144, 3);
            this.TBSubTotal.Name = "TBSubTotal";
            this.TBSubTotal.Size = new System.Drawing.Size(250, 21);
            this.TBSubTotal.TabIndex = 1;
            this.TBSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descuento Aplicado";
            // 
            // TBValorGeneral
            // 
            this.TBValorGeneral.Location = new System.Drawing.Point(144, 84);
            this.TBValorGeneral.Name = "TBValorGeneral";
            this.TBValorGeneral.Size = new System.Drawing.Size(250, 21);
            this.TBValorGeneral.TabIndex = 4;
            this.TBValorGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBCreditoDisponible
            // 
            this.TBCreditoDisponible.Location = new System.Drawing.Point(144, 29);
            this.TBCreditoDisponible.Name = "TBCreditoDisponible";
            this.TBCreditoDisponible.Size = new System.Drawing.Size(250, 21);
            this.TBCreditoDisponible.TabIndex = 214;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 15);
            this.label13.TabIndex = 213;
            this.label13.Text = "Credito Disponible";
            // 
            // TBCreditoMora
            // 
            this.TBCreditoMora.Location = new System.Drawing.Point(144, 3);
            this.TBCreditoMora.Name = "TBCreditoMora";
            this.TBCreditoMora.Size = new System.Drawing.Size(250, 21);
            this.TBCreditoMora.TabIndex = 212;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 15);
            this.label12.TabIndex = 211;
            this.label12.Text = "Credito en Mora";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.CHVencimiento);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.checkBox3);
            this.panel5.Controls.Add(this.dateTimePicker3);
            this.panel5.Controls.Add(this.TBDiasDeEntrega);
            this.panel5.Controls.Add(this.TBTipoDePago);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.TBValorDeEnvio);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(12, 227);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(401, 138);
            this.panel5.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dias de Entrega";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 15);
            this.label9.TabIndex = 184;
            this.label9.Text = "Imprimir Cotización al Finalizar";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(208, 111);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(63, 19);
            this.checkBox3.TabIndex = 185;
            this.checkBox3.Text = "Si - No";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // TBTipoDePago
            // 
            this.TBTipoDePago.Location = new System.Drawing.Point(144, 30);
            this.TBTipoDePago.Name = "TBTipoDePago";
            this.TBTipoDePago.Size = new System.Drawing.Size(250, 21);
            this.TBTipoDePago.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tipo de Pago";
            // 
            // TBValorDeEnvio
            // 
            this.TBValorDeEnvio.Location = new System.Drawing.Point(144, 3);
            this.TBValorDeEnvio.Name = "TBValorDeEnvio";
            this.TBValorDeEnvio.Size = new System.Drawing.Size(250, 21);
            this.TBValorDeEnvio.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor de Envio - Flete";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(12, 371);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 186;
            this.btnGuardar.Text = "Guardar";
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
            this.btnCancelar.Location = new System.Drawing.Point(322, 371);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 187;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TBCreditoDisponible);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.TBCreditoMora);
            this.panel1.Location = new System.Drawing.Point(12, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 58);
            this.panel1.TabIndex = 188;
            // 
            // frmTotalizar_CotizacionDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 409);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmTotalizar_CotizacionDeCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Totalizar - Cotizacion de Compra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTotalizar_CotizacionDeCompra_FormClosing);
            this.Load += new System.EventHandler(this.frmTotalizar_CotizacionDeCompra_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox CHVencimiento;
        public System.Windows.Forms.DateTimePicker dateTimePicker3;
        public System.Windows.Forms.TextBox TBDescuento_Porcentaje;
        public System.Windows.Forms.TextBox TBValorGeneral;
        public System.Windows.Forms.TextBox TBSubTotal;
        public System.Windows.Forms.TextBox TBDescuento;
        public System.Windows.Forms.TextBox TBTipoDePago;
        public System.Windows.Forms.TextBox TBValorDeEnvio;
        public System.Windows.Forms.TextBox TBDiasDeEntrega;
        public System.Windows.Forms.TextBox TBCreditoDisponible;
        public System.Windows.Forms.TextBox TBCreditoMora;
        public System.Windows.Forms.TextBox TBImpuesto_Valor;
    }
}