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
    public partial class frmGrupoCliente : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";

        //Variable para Captura el Empleado Logueado
        public int Idempleado;

        // ******************************************* Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar ************************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        public frmGrupoCliente()
        {
            InitializeComponent();
        }

        private void frmGrupoCliente_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();

            //Focus a Texboxt y Combobox
            this.TBGrupo.Select();

            //Ocultacion de Texboxt
            this.TBIdgrupo.Visible = false;
        }

        private void Habilitar()
        {
            //Datos Basicos
            this.TBGrupo.ReadOnly = false;
            this.TBGrupo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBGrupo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBGrupo.Text = Campo;
            this.TBDescripcion.ReadOnly = false;
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDescripcion.Text = Campo;
            
            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos

            this.TBGrupo.Text = Campo;
            this.TBDescripcion.Clear();

            this.TBBuscar.Clear();

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBGrupo.Select();
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";

                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";

                this.btnCancelar.Enabled = true;
            }
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBGrupo.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Grupo a registrar");
                }
                                
                else
                {
                    if (this.Digitar)
                    {
                        //rptaDatosBasicos = fCliente.Guardar_DatosBasicos

                        //    (
                        //         //Datos Auxiliares
                        //         1,

                        //         //Panel Datos Basicos
                        //         Convert.ToInt32(this.CBTipo.SelectedValue), this.TBCodigo.Text, this.TBNombre.Text, this.TBDocumento.Text, this.TBTelefono.Text,
                        //         this.TBMovil.Text, this.TBCorreo.Text, this.TBPais.Text, this.TBCiudad.Text, this.TBDepartamento.Text,

                        //         //
                        //         this.TBPais_01.Text, this.TBCiudad_01.Text, this.TBReceptor.Text, this.TBDireccionPrincipal.Text, this.TBDireccion01.Text,
                        //         this.TBDireccion02.Text, this.TBTelefono_01.Text, this.TBMovil_01.Text, this.TBObservacion_01.Text,

                        //         //
                        //         this.CBTieneCredito.Text, this.TBLimiteDeCredito.Text, this.TBDiasdecredito.Text, this.TBDiasDeProrroga.Text,
                        //         this.TBInteresesmora.Text, this.TBCreditoMinimo.Text, this.TBCreditoMaximo.Text,

                        //         1
                        //    );
                    }

                    else
                    {
                        //rptaDatosBasicos = fCliente.Editar_DatosBasicos

                        //    (
                        //         //Datos Auxiliares
                        //         1, Convert.ToInt32(this.TBIdcliente.Text),

                        //         //Panel Datos Basicos
                        //         Convert.ToInt32(this.CBTipo.SelectedValue), this.TBCodigo.Text, this.TBNombre.Text, this.TBDocumento.Text, this.TBTelefono.Text,
                        //         this.TBMovil.Text, this.TBCorreo.Text, this.TBPais.Text, this.TBCiudad.Text, this.TBDepartamento.Text,

                        //         //
                        //         this.TBPais_01.Text, this.TBCiudad_01.Text, this.TBReceptor.Text, this.TBDireccionPrincipal.Text, this.TBDireccion01.Text,
                        //         this.TBDireccion02.Text, this.TBTelefono_01.Text, this.TBMovil_01.Text, this.TBObservacion_01.Text,

                        //         //
                        //         this.CBTieneCredito.Text, this.TBLimiteDeCredito.Text, this.TBDiasdecredito.Text, this.TBDiasDeProrroga.Text,
                        //         this.TBInteresesmora.Text, this.TBCreditoMinimo.Text, this.TBCreditoMaximo.Text,

                        //         2
                        //    );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Grupo de Cliente: " + this.TBGrupo.Text + " Registrado Exitosamente");
                        }
                        else
                        {
                            this.MensajeOk("Registro del Grupo de Cliente: " + this.TBGrupo.Text + " Actualizado Exitosamente");
                        }
                    }
                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Solicitud Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (Guardar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }

                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = true;
                        this.Botones();
                        this.Limpiar_Datos();
                    }
                }

                else
                {
                    if (Editar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = true;
                        this.Botones();
                        this.Limpiar_Datos();
                    }
                }
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
                this.Digitar = true;
                this.Botones();
                this.Limpiar_Datos();

                this.TBBuscar.Clear();

                //Se Limpian las Filas y Columnas de la tabla
                this.DGResultados.DataSource = null;
                this.lblTotal.Text = "Datos Registrados: 0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar == "1")
                {

                    DialogResult Opcion;
                    string Respuesta = "";
                    int Eliminacion;

                    Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        if (DGResultados.SelectedRows.Count > 0)
                        {
                            Eliminacion = Convert.ToInt32(DGResultados.CurrentRow.Cells["Codigo"].Value.ToString());
                            Respuesta = Negocio.fGrupoDeCliente.Eliminar(Eliminacion, 0);
                        }

                        if (Respuesta.Equals("OK"))
                        {
                            this.MensajeOk("Registro de Grupo de Cliente: " + this.TBGrupo.Text + " Eliminado Exitosamente");
                        }
                        else
                        {
                            this.MensajeError(Respuesta);
                        }

                        //Botones Comunes
                        this.TBBuscar.Clear();
                        this.Limpiar_Datos();
                    }
                }
                else
                {
                    MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fGrupoDeCliente.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultadoss.Columns[1].Visible = false;

                        this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                        this.DGResultados.Enabled = true;
                    }
                    else
                    {
                        //Se Limpian las Filas y Columnas de la tabla
                        this.DGResultados.DataSource = null;
                        this.DGResultados.Enabled = false;
                        this.lblTotal.Text = "Datos Registrados: 0";
                    }
                }
                else
                {
                    MessageBox.Show(" El Usuario Iniciado no Contiene Permisos Para Realizar Consultas", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Editar == "1")
                {
                    //
                    this.Digitar = false;
                    this.Botones();

                    //Se procede a completar los campos de textos segun
                    //la consulta realizada en la base de datos
                    this.TBIdgrupo.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

                }
                else
                {
                    MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Actualizar Datos en el Sistema", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
