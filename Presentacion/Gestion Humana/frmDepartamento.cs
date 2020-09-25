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
    public partial class frmDepartamento : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";


        //Variable para Captura el Empleado Logueado
        public int Idempleado;

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar = "";
        public string Editar = "";
        public string Consultar = "";
        public string Eliminar = "";
        public string Imprimir = "";

        //Parametros para AutoCompletar los Texboxt

        
        public frmDepartamento()
        {
            InitializeComponent();
        }

        private void frmDepartamento_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();

            //Focus a Texboxt y Combobox
            this.TBDepartamento.Select();

            //Ocultacion de Texboxt
            this.TBIddepartamento.Visible = false;
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            this.TBDepartamento.ReadOnly = false;
            this.TBDepartamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDepartamento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDepartamento.Text = Campo;
            this.TBDirector.ReadOnly = false;
            this.TBDirector.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDirector.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDirector.Text = Campo;
            this.TBAreaPrincipal.ReadOnly = false;
            this.TBAreaPrincipal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBAreaAuxiliar.ReadOnly = false;
            this.TBAreaAuxiliar.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion.ReadOnly = false;
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
            
            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBDepartamento.Clear();
            this.TBDepartamento.Text = Campo;
            this.TBDirector.Clear();
            this.TBDirector.Text = Campo;
            this.TBAreaPrincipal.Clear();
            this.TBAreaAuxiliar.Clear();
            this.TBDescripcion.Clear();
            
            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBDepartamento.Select();
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

                if (this.TBDepartamento.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Empleado a registrar");
                }
                else if (this.TBDirector.Text == Campo)
                {
                    MensajeError("Ingrese el Numero de Documento del Empleado a registrar");
                }

                else
                {
                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fGestion_Departameto.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 1, Convert.ToInt32(TBIdempleado.Text),

                                 //Panel Datos Basicos
                                 this.TBDepartamento.Text, this.TBAreaPrincipal.Text, this.TBAreaAuxiliar.Text, this.dateTimePicker1.Value, this.TBDescripcion.Text
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fGestion_Departameto.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 2, Convert.ToInt32(TBIddepartamento.Text), Convert.ToInt32(TBIdempleado.Text),

                                 //Panel Datos Basicos
                                 this.TBDepartamento.Text, this.TBAreaPrincipal.Text, this.TBAreaAuxiliar.Text, this.dateTimePicker1.Value, this.TBDescripcion.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Departamento: " + this.TBDepartamento.Text + " Registrado Correctamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro del Departamento: " + this.TBDepartamento.Text + " a Sido Actualizado");
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
            MessageBox.Show(mensaje, "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                DGResultados.DataSource = null;
                this.DGResultados.Enabled = false;
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

        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExaminar_Proveedor_Click(object sender, EventArgs e)
        {

        }
    }
}
