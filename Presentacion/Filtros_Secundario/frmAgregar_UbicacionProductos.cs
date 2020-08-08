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
    public partial class frmAgregar_UbicacionProductos : Form
    {
        public frmAgregar_UbicacionProductos()
        {
            InitializeComponent();
        }

        private void frmAgregar_UbicacionProductos_Load(object sender, EventArgs e)
        {
            //Inicio de Clases
            this.Habilitar();
            this.AutoCompletar_Combobox();

            this.TBIdproducto_UB.Visible = false;
        }

        private void Habilitar()
        {

            this.TBUbicacion_UB.Select();

            //Panel - Datos Basicos
            this.TBCodigo_UB.Enabled = false;
            this.TBCodigo_UB.BackColor = Color.FromArgb(72, 209, 204);
            this.TBNombre_UB.Enabled = false;
            this.TBNombre_UB.BackColor = Color.FromArgb(72, 209, 204);
            this.TBDescripcion_UB.Enabled = false;
            this.TBDescripcion_UB.BackColor = Color.FromArgb(72, 209, 204);
            this.TBReferencia_UB.Enabled = false;
            this.TBReferencia_UB.BackColor = Color.FromArgb(72, 209, 204);
            this.TBPresentacion_UB.Enabled = false;
            this.TBPresentacion_UB.BackColor = Color.FromArgb(72, 209, 204);
                        
            //Panel - Ubicacion
            this.TBUbicacion_UB.ReadOnly = false;
            this.TBUbicacion_UB.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEstante_UB.ReadOnly = false;
            this.TBEstante_UB.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNivel_UB.ReadOnly = false;
            this.TBNivel_UB.BackColor = Color.FromArgb(3, 155, 229);

        }

        private void AutoCompletar_Combobox()
        {
            this.CBBodega_UB.DataSource = fBodega.Lista();
            this.CBBodega_UB.ValueMember = "Codigo";
            this.CBBodega_UB.DisplayMember = "Bodega";
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

                if (this.TBUbicacion_UB.Text == String.Empty)
                {
                    this.MensajeError("Por favor Especifique la Ubicación dentro de la Bodega seleccionada");
                    this.TBUbicacion_UB.Select();
                }
                else if (this.TBEstante_UB.Text == String.Empty)
                {
                    this.MensajeError("Por favor Especifique el Estante de Ubicación Dentro de la Bodega seleccionada");
                    this.TBEstante_UB.Select();
                }
                else if (this.TBNivel_UB.Text == String.Empty)
                {
                    this.MensajeError("Por favor Especifique el Nivel Dentro del Estante Dentro de la Bodega seleccionada");
                    this.TBNivel_UB.Select();
                }
                else if (this.CBBodega_UB.SelectedIndex == 0)
                {
                    this.MensajeError("Por favor Seleccione la Bodega de Almacenamiento del Producto: " + TBNombre_UB.Text + " Con Codigo: " + TBCodigo_UB.Text);
                    this.TBUbicacion_UB.Select();
                }

                else
                {
                    rptaDatosBasicos = fProductos.Guardar_Ubicacion

                            (
                                 //Datos Basicos
                                 Convert.ToInt32(this.TBIdproducto_UB.Text), Convert.ToInt32(this.CBBodega_UB.SelectedValue),this.TBUbicacion_UB.Text,this.TBEstante_UB.Text,this.TBNivel_UB.Text,
                                
                                //Datos Auxiliares
                                1
                            );

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        this.MensajeOk("Ubicación del Producto: " + TBNombre_UB.Text + " con Codigo: " + this.TBCodigo_UB.Text + " Registrada Exitosamente");
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
