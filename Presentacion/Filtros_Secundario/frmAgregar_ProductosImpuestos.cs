using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;

namespace Presentacion
{
    public partial class frmAgregar_ImpuestosProductos : Form
    {
        public frmAgregar_ImpuestosProductos()
        {
            InitializeComponent();
        }

        private void frmAgregar_ImpuestosProductos_Load(object sender, EventArgs e)
        {

            //
            this.Habilitar();
        }

        private void Habilitar()
        {

            this.TBImpuesto_IM.Select();

            //Panel - Datos Basicos
            this.TBCodigo_IM.Enabled = false;
            this.TBCodigo_IM.BackColor = Color.FromArgb(72, 209, 204);
            this.TBImpuesto_IM.Enabled = false;
            this.TBImpuesto_IM.BackColor = Color.FromArgb(72, 209, 204);
            this.TBDescripcion_IM.Enabled = false;
            this.TBDescripcion_IM.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_IM.Enabled = false;
            this.TBValor_IM.BackColor = Color.FromArgb(72, 209, 204);
        }

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBCodigo_IM.Text == String.Empty)
                {
                    this.MensajeError("Por favor Especifique el Codigo ID del Impuesto");
                    this.TBCodigo_IM.Select();
                }
                else if (this.TBImpuesto_IM.Text == String.Empty)
                {
                    this.MensajeError("Por favor Especifique el Impuesto que Desea Agregar");
                    this.TBImpuesto_IM.Select();
                }
                else
                {
                    rptaDatosBasicos = fProductos.Guardar_Impuesto

                            (
                                 //Datos Basicos
                                 Convert.ToInt32(this.TBIdproducto_IM.Text),Convert.ToInt32(TBCodigo_IM.Text),this.TBImpuesto_IM.Text,this.TBValor_IM.Text,this.TBDescripcion_IM.Text,
                                //Datos Auxiliares
                                2
                            );

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        this.MensajeOk("Impueto: " + TBImpuesto_IM.Text + " con Codigo: " + this.TBCodigo_IM.Text + " a Sido Agregado Exitosamente");
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }
                }
                //
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Metodo Guardar y editar
                this.Guardar_SQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                //
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
