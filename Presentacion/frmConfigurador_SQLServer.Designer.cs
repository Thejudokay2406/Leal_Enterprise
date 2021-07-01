
namespace Presentacion
{
    partial class frmConfigurador_SQLServer
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLectura = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TBServidor = new System.Windows.Forms.TextBox();
            this.TBUsuario = new System.Windows.Forms.TextBox();
            this.TBContraseña = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBBase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBBase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TBContraseña);
            this.groupBox1.Controls.Add(this.TBUsuario);
            this.groupBox1.Controls.Add(this.TBServidor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnLectura);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 356);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(26, 351);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Lectura SQL2";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLectura
            // 
            this.btnLectura.Location = new System.Drawing.Point(26, 283);
            this.btnLectura.Name = "btnLectura";
            this.btnLectura.Size = new System.Drawing.Size(120, 30);
            this.btnLectura.TabIndex = 2;
            this.btnLectura.Text = "Lectura SQL";
            this.btnLectura.UseVisualStyleBackColor = true;
            this.btnLectura.Click += new System.EventHandler(this.btnLectura_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Guardar SQL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Servidor";
            // 
            // TBServidor
            // 
            this.TBServidor.Location = new System.Drawing.Point(99, 63);
            this.TBServidor.Name = "TBServidor";
            this.TBServidor.Size = new System.Drawing.Size(238, 21);
            this.TBServidor.TabIndex = 8;
            // 
            // TBUsuario
            // 
            this.TBUsuario.Location = new System.Drawing.Point(99, 90);
            this.TBUsuario.Name = "TBUsuario";
            this.TBUsuario.Size = new System.Drawing.Size(238, 21);
            this.TBUsuario.TabIndex = 9;
            // 
            // TBContraseña
            // 
            this.TBContraseña.Location = new System.Drawing.Point(99, 117);
            this.TBContraseña.Name = "TBContraseña";
            this.TBContraseña.Size = new System.Drawing.Size(238, 21);
            this.TBContraseña.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Contraseña";
            // 
            // TBBase
            // 
            this.TBBase.Location = new System.Drawing.Point(99, 36);
            this.TBBase.Name = "TBBase";
            this.TBBase.Size = new System.Drawing.Size(238, 21);
            this.TBBase.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Base";
            // 
            // frmConfigurador_SQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 439);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmConfigurador_SQLServer";
            this.Text = "frmConfigurador_SQLServer";
            this.Load += new System.EventHandler(this.frmConfigurador_SQLServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLectura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBContraseña;
        private System.Windows.Forms.TextBox TBUsuario;
        private System.Windows.Forms.TextBox TBServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBBase;
        private System.Windows.Forms.Label label4;
    }
}