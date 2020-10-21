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
    public partial class frmTipoDeContrato : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";


        //Variable para Captura el Empleado Logueado
        public int Idempleado;

        //********** Variables para la Validacion de los checkbox en el Pane Datos Basicos

        private string Checkbox_Vencimiento, Checkbox_Ofertable, Checkbox_Impuesto, Checkbox_Importado = "";
        private string Checkbox_Comision, Checkbox_Exportado = "";

        //********** Variables para AutoComplementar Combobox y Chexboxt segun la Consulta en SQL **********

        //Panel Datos Basicos
        private string Departamento_SQL, Contrato_SQL = "";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        private string Codigo, Nombre, Documento, Pais, Ciudad, Fijo, Movil = "";
        private string Email, Direccion, Comision, Descuento, Profesion, Cargo = "";

        public frmTipoDeContrato()
        {
            InitializeComponent();
        }

        private void frmTipoDeContrato_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();

            //Focus a Texboxt y Combobox
            this.TBContrato.Select();

            //Ocultacion de Texboxt
            this.TBIdcontrato.Visible = false;
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            this.TBContrato.ReadOnly = false;
            this.TBContrato.BackColor = Color.FromArgb(3, 155, 229);
            this.TBContrato.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBContrato.Text = Campo;
            this.TBSueldo.ReadOnly = false;
            this.TBSueldo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBSueldo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBSueldo.Text = Campo;
            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion.ReadOnly = false;
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);

            //Combobox
            this.CBMoneda.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBContrato.Clear();
            this.TBContrato.Text = Campo;
            this.TBSueldo.Clear();
            this.TBSueldo.Text = Campo;
            this.TBCodigo.Clear();
            this.TBDescripcion.Clear();
            this.CBMoneda.SelectedItem = 0;

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBContrato.Select();
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

                if (this.TBContrato.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Contrato a registrar");
                }
                else if (this.TBSueldo.Text == Campo)
                {
                    MensajeError("Ingrese el Sueldo Basico del Contrato a registrar");
                }

                else
                {
                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fGestion_TipoDeContrato.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 1,

                                 //Panel Datos Basicos
                                 this.TBCodigo.Text, this.TBContrato.Text, this.TBSueldo.Text, this.CBMoneda.Text, this.TBDescripcion.Text
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fGestion_TipoDeContrato.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 2, Convert.ToInt32(this.TBIdcontrato.Text),

                                 //Panel Datos Basicos
                                 this.TBCodigo.Text, this.TBContrato.Text, this.TBSueldo.Text, this.CBMoneda.Text, this.TBDescripcion.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Contrato: " + this.TBContrato.Text + " Registrado Correctamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro del Contrato: " + this.TBContrato.Text + " a Sido Actualizado");
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
                        this.Digitar = false;
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
                this.Limpiar_Datos();
                this.TBBuscar.Clear();

                //Se Limpian las Filas y Columnas de la tabla
                this.DGResultado.DataSource = null;
                this.DGResultado.Enabled = false;
                this.lblTotal.Text = "Datos Registrados: 0";

                //Se restablece la imagen predeterminada del boton
                //this.btnGuardar.Image = Properties.Resources.BV_Guardar;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

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
                        this.DGResultado.DataSource = fGestion_TipoDeContrato.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultadoss.Columns[1].Visible = false;

                        lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultado.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                        this.DGResultado.Enabled = true;
                    }
                    else
                    {

                        //Se Limpian las Filas y Columnas de la tabla
                        this.DGResultado.DataSource = null;
                        this.DGResultado.Enabled = false;
                        this.lblTotal.Text = "Datos Registrados: 0";

                        this.btnEliminar.Enabled = false;
                        this.btnImprimir.Enabled = false;
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

        private void DGResultado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Digitar = false;

                if (Editar == "1")
                {
                    //
                    //this.TBEmpleado.Select();

                    //this.TBIdempleado.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

                    ////
                    //this.Limpiar_Datos();
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
