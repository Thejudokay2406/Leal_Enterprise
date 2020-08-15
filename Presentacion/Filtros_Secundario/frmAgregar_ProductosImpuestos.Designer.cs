namespace Presentacion
{
    partial class frmAgregar_ImpuestosProductos
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
            this.TBIdproducto_IM = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.TBDescripcion_IM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBValor_IM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBImpuesto_IM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBCodigo_IM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBIdproducto_IM);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.TBDescripcion_IM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TBValor_IM);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TBImpuesto_IM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBCodigo_IM);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificación de Impuestos - Leal Enterprise";
            // 
            // TBIdproducto_IM
            // 
            this.TBIdproducto_IM.Location = new System.Drawing.Point(130, 133);
            this.TBIdproducto_IM.Name = "TBIdproducto_IM";
            this.TBIdproducto_IM.Size = new System.Drawing.Size(49, 21);
            this.TBIdproducto_IM.TabIndex = 49;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Image = global::Presentacion.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(285, 128);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 47;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Image = global::Presentacion.Botones.btnGuardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(9, 128);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 46;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // TBDescripcion_IM
            // 
            this.TBDescripcion_IM.Location = new System.Drawing.Point(91, 101);
            this.TBDescripcion_IM.Name = "TBDescripcion_IM";
            this.TBDescripcion_IM.Size = new System.Drawing.Size(284, 21);
            this.TBDescripcion_IM.TabIndex = 35;
            this.TBDescripcion_IM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "Descripción";
            // 
            // TBValor_IM
            // 
            this.TBValor_IM.Location = new System.Drawing.Point(91, 74);
            this.TBValor_IM.Name = "TBValor_IM";
            this.TBValor_IM.Size = new System.Drawing.Size(284, 21);
            this.TBValor_IM.TabIndex = 33;
            this.TBValor_IM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Valor";
            // 
            // TBImpuesto_IM
            // 
            this.TBImpuesto_IM.Location = new System.Drawing.Point(91, 47);
            this.TBImpuesto_IM.Name = "TBImpuesto_IM";
            this.TBImpuesto_IM.Size = new System.Drawing.Size(284, 21);
            this.TBImpuesto_IM.TabIndex = 31;
            this.TBImpuesto_IM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Impuesto";
            // 
            // TBCodigo_IM
            // 
            this.TBCodigo_IM.Location = new System.Drawing.Point(91, 20);
            this.TBCodigo_IM.Name = "TBCodigo_IM";
            this.TBCodigo_IM.Size = new System.Drawing.Size(284, 21);
            this.TBCodigo_IM.TabIndex = 29;
            this.TBCodigo_IM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Codigo";
            // 
            // frmAgregar_ImpuestosProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 183);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmAgregar_ImpuestosProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar - Impuestos de Productos";
            this.Load += new System.EventHandler(this.frmAgregar_ImpuestosProductos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TBIdproducto_IM;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox TBDescripcion_IM;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TBValor_IM;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TBImpuesto_IM;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TBCodigo_IM;
        private System.Windows.Forms.Label label1;
    }
}