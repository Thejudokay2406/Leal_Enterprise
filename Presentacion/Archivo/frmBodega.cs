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
    public partial class frmBodega : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        private string Campo = "Campo Obligatorio";

        // ***************************************************** Variable para Captura el Empleado Logueado ****************************************************

        public int Idempleado;

        // ***************************************************** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *********************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        // ***************************************************** Parametros para AutoCompletar los Texboxt *****************************************************

        //Panel Datos Basicos - Llaves Primarias
        public string Idbodega, Idsucurzal = "";

        //Panel Datos Basicos
        private string Nombre, Documento, Descripcion, Director, Ciudad, Telefono, Movil, Correo, Zona, Dimensiones, Direccion01, Direccion02 = "";

        //Panel Datos Datos de Pagos
        private string Autorizacion_Pagos, Aut_InicioLaboral, Aut_FinalLaboral, Aut_Lunes, Aut_Martes, Aut_Miercoles, Aut_Jueves, Aut_Viernes, Aut_Sabado, Aut_Domingo, Aut_Bono, Aut_Credito, Aut_Debito, Aut_Efectivo, Aut_Sodexo, Aut_Transferencia, Aut_Cheques, Aut_Otros = "";

        //Panel Datos de Despacho
        private string Despacho, Des_InicioLaboral, Des_FinalLaboral, Des_Lunes, Des_Martes, Des_Miercoles, Des_Jueves, Des_Viernes, Des_Sabado, Des_Domingo, Des_Encargado, Des_Observacion = "";

        //Panel Datos de Recepcion
        private string Recepcion, Rec_InicioLaboral, Rec_FinalLaboral, Rec_Lunes, Rec_Martes, Rec_Miercoles, Rec_Jueves, Rec_Viernes, Rec_Sabado, Rec_Domingo, Rec_Encargado, Rec_Observacion = "";

        // ***************************************************** Parametros para Validar los Chexbox en General ************************************************

        private string ChbPagos_Lunes, ChbPagos_Martes, ChbPagos_Miercoles, ChbPagos_Jueves, ChbPagos_Viernes, ChbPagos_Sabado, ChbPagos_Domingo = "";
        private string ChbMetodos_Bono, ChbMetodos_Cheque, ChbMetodos_Credito, ChbMetodos_Debito, ChbMetodos_Efectivo, ChbMetodos_Sodexo, ChbMetodos_Transferencia, ChbMetodos_Otros = "";
        private string ChbRecepcion_Lunes, ChbRecepcion_Martes, ChbRecepcion_Miercoles, ChbRecepcion_Jueves, ChbRecepcion_Viernes, ChbRecepcion_Sabado, ChbRecepcion_Domingo = "";
        private string ChbDespacho_Lunes, ChbDespacho_Martes, ChbDespacho_Miercoles, ChbDespacho_Jueves, ChbDespacho_Viernes, ChbDespacho_Sabado, ChbDespacho_Domingo = "";

        public frmBodega()
        {
            InitializeComponent();
        }

        private void frmBodega_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.Combobox_Sucurzal();

            //Focus a Texboxt y Combobox
            this.TBBodega.Select();
            this.CBZona.SelectedIndex = 0;

            //Ocultacion de Texboxt
            this.TBIdbodega.Visible = false;
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos

            this.TBBodega.ReadOnly = false;
            this.TBBodega.BackColor = Color.FromArgb(3, 155, 229);
            this.TBBodega.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBBodega.Text = Campo;
            this.TBDocumento.ReadOnly = false;
            this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion.ReadOnly = false;
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDescripcion.Text = Campo;
            this.TBDirector.ReadOnly = false;
            this.TBDirector.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDirector.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDirector.Text = Campo;

            this.TBCiudad.ReadOnly = false;
            this.TBCiudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMovil.ReadOnly = false;
            this.TBMovil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBTelefono.ReadOnly = false;
            this.TBTelefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCorreo.ReadOnly = false;
            this.TBCorreo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDireccion01.ReadOnly = false;
            this.TBDireccion01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDireccion02.ReadOnly = false;
            this.TBDireccion02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMedidas.ReadOnly = false;
            this.TBMedidas.BackColor = Color.FromArgb(3, 155, 229);

            //Dias de Pagos
            this.TBAutorizacion_Pagos.ReadOnly = false;
            this.TBAutorizacion_Pagos.BackColor = Color.FromArgb(3, 155, 229);
            this.TBInicioHorario_Pagos.ReadOnly = false;
            this.TBInicioHorario_Pagos.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFinHorario_Pagos.ReadOnly = false;
            this.TBFinHorario_Pagos.BackColor = Color.FromArgb(3, 155, 229);

            //Dias de Recepcion
            this.TBRecepcion.ReadOnly = false;
            this.TBRecepcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBInicioRecepcion.ReadOnly = false;
            this.TBInicioRecepcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFinRecepcion.ReadOnly = false;
            this.TBFinRecepcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEncargado_Recepcion.ReadOnly = false;
            this.TBEncargado_Recepcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBObservacion_Recepcion.ReadOnly = false;
            this.TBObservacion_Recepcion.BackColor = Color.FromArgb(3, 155, 229);

            //Dias de Despacho
            this.TBDespacho.ReadOnly = false;
            this.TBDespacho.BackColor = Color.FromArgb(3, 155, 229);
            this.TBInicioDespacho.ReadOnly = false;
            this.TBInicioDespacho.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFinDeDespacho.ReadOnly = false;
            this.TBFinDeDespacho.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEncargado_Despacho.ReadOnly = false;
            this.TBEncargado_Despacho.BackColor = Color.FromArgb(3, 155, 229);
            this.TBObservacion_Despacho.ReadOnly = false;
            this.TBObservacion_Despacho.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos

            this.TBIdbodega.Clear();
            this.CBSucurzal.SelectedIndex = 0;
            this.CBZona.SelectedIndex = 0;
            this.TBBodega.Clear();
            this.TBBodega.Text = Campo;
            this.TBDocumento.Clear();
            this.TBDescripcion.Clear();
            this.TBDescripcion.Text = Campo;
            this.TBDirector.Clear();
            this.TBDirector.Text = Campo;

            this.TBCiudad.Clear();
            this.TBMovil.Clear();
            this.TBTelefono.Clear();
            this.TBCorreo.Clear();
            this.TBDireccion01.Clear();
            this.TBDireccion02.Clear();
            this.TBMedidas.Clear();

            //Dias de Recepcion
            this.TBRecepcion.Clear();
            this.TBInicioRecepcion.Clear();
            this.TBFinRecepcion.Clear();
            this.TBEncargado_Recepcion.Clear();
            this.TBObservacion_Recepcion.Clear();

            //Dias de Despacho
            this.TBDespacho.Clear();
            this.TBInicioDespacho.Clear();
            this.TBFinDeDespacho.Clear();
            this.TBEncargado_Despacho.Clear();
            this.TBObservacion_Despacho.Clear();

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TCPrincipal.SelectedIndex = 0;
            this.TBDireccion02.Select();
        }
        
        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";

                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
        }

        private void Combobox_Sucurzal()
        {
            try
            {
                this.CBSucurzal.DataSource = fSucurzal.Lista();
                this.CBSucurzal.ValueMember = "Codigo";
                this.CBSucurzal.DisplayMember = "Sucurzal";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Validaciones_Chexbox()
        {
            try
            {
                //Panel Dato de Pagos

                if (CHLunes_Pagos.Checked)
                {
                    ChbPagos_Lunes = "1";
                }
                else
                {
                    ChbPagos_Lunes = "0";
                }

                if (CHMartes_Pagos.Checked)
                {
                    ChbPagos_Martes = "1";
                }
                else
                {
                    ChbPagos_Martes = "0";
                }

                if (CHMiercoles_Pagos.Checked)
                {
                    ChbPagos_Miercoles = "1";
                }
                else
                {
                    ChbPagos_Miercoles = "0";
                }

                if (CHJueves_Pagos.Checked)
                {
                    ChbPagos_Jueves = "1";
                }
                else
                {
                    ChbPagos_Jueves = "0";
                }

                if (CHViernes_Pagos.Checked)
                {
                    ChbPagos_Viernes = "1";
                }
                else
                {
                    ChbPagos_Viernes = "0";
                }

                if (CHSabado_Pagos.Checked)
                {
                    ChbPagos_Sabado = "1";
                }
                else
                {
                    ChbPagos_Sabado = "0";
                }

                if (CHDomingo_Pagos.Checked)
                {
                    ChbPagos_Domingo = "1";
                }
                else
                {
                    ChbPagos_Domingo = "0";
                }

                //
                if (CHBono.Checked)
                {
                    ChbMetodos_Bono = "1";
                }
                else
                {
                    ChbMetodos_Bono = "0";
                }

                if (CHCheques.Checked)
                {
                    ChbMetodos_Cheque = "1";
                }
                else
                {
                    ChbMetodos_Cheque = "0";
                }

                if (CHEfectivo.Checked)
                {
                    ChbMetodos_Efectivo = "1";
                }
                else
                {
                    ChbMetodos_Efectivo = "0";
                }

                if (CHCredito.Checked)
                {
                    ChbMetodos_Credito = "1";
                }
                else
                {
                    ChbMetodos_Credito = "0";
                }

                if (CHDebito.Checked)
                {
                    ChbMetodos_Debito = "1";
                }
                else
                {
                    ChbMetodos_Debito = "0";
                }

                if (CHTransferencia.Checked)
                {
                    ChbMetodos_Transferencia = "1";
                }
                else
                {
                    ChbMetodos_Transferencia = "0";
                }

                if (CHSodexo.Checked)
                {
                    ChbMetodos_Sodexo = "1";
                }
                else
                {
                    ChbMetodos_Sodexo = "0";
                }

                if (CHOtros.Checked)
                {
                    ChbMetodos_Otros = "1";
                }
                else
                {
                    ChbMetodos_Otros = "0";
                }

                //Panel Datos de Recepcion
                if (CHLunes_Recepcion.Checked)
                {
                    ChbRecepcion_Lunes = "1";
                }
                else
                {
                    ChbRecepcion_Lunes = "0";
                }

                if (CHMartes_Recepcion.Checked)
                {
                    ChbRecepcion_Martes = "1";
                }
                else
                {
                    ChbRecepcion_Martes = "0";
                }

                if (CHMiercoles_Recepcion.Checked)
                {
                    ChbRecepcion_Miercoles = "1";
                }
                else
                {
                    ChbRecepcion_Miercoles = "0";
                }

                if (CHJueves_Recepcion.Checked)
                {
                    ChbRecepcion_Jueves = "1";
                }
                else
                {
                    ChbRecepcion_Jueves = "0";
                }

                if (CHViernes_Recepcion.Checked)
                {
                    ChbRecepcion_Viernes = "1";
                }
                else
                {
                    ChbRecepcion_Viernes = "0";
                }

                if (CHSabado_Recepcion.Checked)
                {
                    ChbRecepcion_Sabado = "1";
                }
                else
                {
                    ChbRecepcion_Sabado = "0";
                }

                if (CHDomingo_Recepcion.Checked)
                {
                    ChbRecepcion_Domingo = "1";
                }
                else
                {
                    ChbRecepcion_Domingo = "0";
                }

                //Panel Datos de Despacho
                if (CHLunes_Despacho.Checked)
                {
                    ChbDespacho_Lunes = "1";
                }
                else
                {
                    ChbDespacho_Lunes = "0";
                }

                if (CHMartes_Despacho.Checked)
                {
                    ChbDespacho_Martes = "1";
                }
                else
                {
                    ChbDespacho_Martes = "0";
                }

                if (CHMiercoles_Despacho.Checked)
                {
                    ChbDespacho_Miercoles = "1";
                }
                else
                {
                    ChbDespacho_Miercoles = "0";
                }

                if (CHJueves_Despacho.Checked)
                {
                    ChbDespacho_Jueves = "1";
                }
                else
                {
                    ChbDespacho_Jueves = "0";
                }

                if (CHViernes_Despacho.Checked)
                {
                    ChbDespacho_Viernes = "1";
                }
                else
                {
                    ChbDespacho_Viernes = "0";
                }

                if (CHSabado_Despacho.Checked)
                {
                    ChbDespacho_Sabado = "1";
                }
                else
                {
                    ChbDespacho_Sabado = "0";
                }

                if (CHDomingo_Despacho.Checked)
                {
                    ChbDespacho_Domingo = "1";
                }
                else
                {
                    ChbDespacho_Domingo = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBBodega.Text == Campo)
                {
                    MensajeError("Ingrese el nombre de la Bodega a registrar");
                }
                else if (this.TBDescripcion.Text == Campo)
                {
                    MensajeError("Ingrese la descripcion de la bodega a registrar");
                }
                else if (this.TBDirector.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Director o Responsable de la bodega");
                }
                else if (this.CBSucurzal.SelectedIndex == 0)
                {
                    MensajeError("Seleccione la sucurzal a la cual pernecera la bodega");
                }
                else
                {
                    this.Validaciones_Chexbox();

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fBodega.Guardar_DatosBasicos
                            (
                                //Datos Auxiliares
                                1,

                                //Panel Datos Basicos
                                Convert.ToInt32(this.CBSucurzal.SelectedValue), this.TBBodega.Text, this.TBDocumento.Text, this.TBDescripcion.Text, this.TBDirector.Text, this.TBCiudad.Text, this.TBTelefono.Text, this.TBMovil.Text, this.TBCorreo.Text, this.TBMedidas.Text, this.TBDireccion01.Text, this.TBDireccion02.Text, this.CBZona.Text,

                                //Panel - Datos de Pago
                                this.TBAutorizacion_Pagos.Text, this.TBInicioHorario_Pagos.Text, this.TBFinHorario_Pagos.Text, Convert.ToInt32(ChbPagos_Lunes), Convert.ToInt32(ChbPagos_Martes), Convert.ToInt32(ChbPagos_Miercoles), Convert.ToInt32(ChbPagos_Jueves), Convert.ToInt32(ChbPagos_Viernes), Convert.ToInt32(ChbPagos_Sabado), Convert.ToInt32(ChbPagos_Domingo), Convert.ToInt32(ChbMetodos_Bono), Convert.ToInt32(ChbMetodos_Cheque), Convert.ToInt32(ChbMetodos_Credito), Convert.ToInt32(ChbMetodos_Debito), Convert.ToInt32(ChbMetodos_Efectivo), Convert.ToInt32(ChbMetodos_Sodexo), Convert.ToInt32(ChbMetodos_Transferencia), Convert.ToInt32(ChbMetodos_Otros),

                                //
                                this.TBRecepcion.Text, TBInicioRecepcion.Text, TBFinRecepcion.Text, Convert.ToInt32(ChbRecepcion_Lunes), Convert.ToInt32(ChbRecepcion_Martes), Convert.ToInt32(ChbRecepcion_Miercoles), Convert.ToInt32(ChbRecepcion_Jueves), Convert.ToInt32(ChbRecepcion_Viernes), Convert.ToInt32(ChbRecepcion_Sabado), Convert.ToInt32(ChbRecepcion_Domingo), this.TBEncargado_Recepcion.Text, this.TBObservacion_Recepcion.Text,

                                //
                                this.TBDespacho.Text, this.TBInicioDespacho.Text, this.TBFinDeDespacho.Text, Convert.ToInt32(this.ChbDespacho_Lunes), Convert.ToInt32(this.ChbDespacho_Martes), Convert.ToInt32(this.ChbDespacho_Miercoles), Convert.ToInt32(this.ChbDespacho_Jueves), Convert.ToInt32(this.ChbDespacho_Viernes), Convert.ToInt32(this.ChbDespacho_Sabado), Convert.ToInt32(this.ChbDespacho_Domingo), this.TBEncargado_Despacho.Text, this.TBObservacion_Despacho.Text
                            );
                    }
                    
                    else
                    {
                        rptaDatosBasicos = fBodega.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llave Primaria
                                 2, Convert.ToInt32(TBIdbodega.Text),

                                //Panel Datos Basicos
                                Convert.ToInt32(this.CBSucurzal.SelectedValue), this.TBBodega.Text, this.TBDocumento.Text, this.TBDescripcion.Text, this.TBDirector.Text, this.TBCiudad.Text, this.TBTelefono.Text, this.TBMovil.Text, this.TBCorreo.Text, this.TBMedidas.Text, this.TBDireccion01.Text, this.TBDireccion02.Text, this.CBZona.Text,

                                //Panel - Datos de Pago
                                this.TBAutorizacion_Pagos.Text, this.TBInicioHorario_Pagos.Text, this.TBFinHorario_Pagos.Text, Convert.ToInt32(ChbPagos_Lunes), Convert.ToInt32(ChbPagos_Martes), Convert.ToInt32(ChbPagos_Miercoles), Convert.ToInt32(ChbPagos_Jueves), Convert.ToInt32(ChbPagos_Viernes), Convert.ToInt32(ChbPagos_Sabado), Convert.ToInt32(ChbPagos_Domingo), Convert.ToInt32(ChbMetodos_Bono), Convert.ToInt32(ChbMetodos_Cheque), Convert.ToInt32(ChbMetodos_Credito), Convert.ToInt32(ChbMetodos_Debito), Convert.ToInt32(ChbMetodos_Efectivo), Convert.ToInt32(ChbMetodos_Sodexo), Convert.ToInt32(ChbMetodos_Transferencia), Convert.ToInt32(ChbMetodos_Otros),

                                //
                                this.TBRecepcion.Text, TBInicioRecepcion.Text, TBFinRecepcion.Text, Convert.ToInt32(ChbRecepcion_Lunes), Convert.ToInt32(ChbRecepcion_Martes), Convert.ToInt32(ChbRecepcion_Miercoles), Convert.ToInt32(ChbRecepcion_Jueves), Convert.ToInt32(ChbRecepcion_Viernes), Convert.ToInt32(ChbRecepcion_Sabado), Convert.ToInt32(ChbRecepcion_Domingo), this.TBEncargado_Recepcion.Text, this.TBObservacion_Recepcion.Text,

                                //
                                this.TBDespacho.Text, this.TBInicioDespacho.Text, this.TBFinDeDespacho.Text, Convert.ToInt32(this.ChbDespacho_Lunes), Convert.ToInt32(this.ChbDespacho_Martes), Convert.ToInt32(this.ChbDespacho_Miercoles), Convert.ToInt32(this.ChbDespacho_Jueves), Convert.ToInt32(this.ChbDespacho_Viernes), Convert.ToInt32(this.ChbDespacho_Sabado), Convert.ToInt32(this.ChbDespacho_Domingo), this.TBEncargado_Despacho.Text, this.TBObservacion_Despacho.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("La Bodega: “" + this.TBBodega.Text + "” a Sido Registrado Exitosamente");
                        }
                        else
                        {
                            this.MensajeOk("El Registro de La Bodega: “" + this.TBBodega.Text + "” a Sido Actualizado Exitosamente");
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

                //Focus
                this.TBBodega.Select();
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
                            Respuesta = Negocio.fBodega.Eliminar(Eliminacion, 0);
                        }

                        if (Respuesta.Equals("OK"))
                        {
                            this.MensajeOk("Registro Eliminado Correctamente");
                        }
                        else
                        {
                            this.MensajeError(Respuesta);
                        }

                        //Botones Comunes
                        this.Limpiar_Datos();
                        this.TBBuscar.Clear();

                        //Se regresa el focus al campo principal
                        this.TCPrincipal.SelectedIndex = 0;
                        this.TBBodega.Select();
                    }
                }
                else
                {
                    MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        this.DGResultados.DataSource = fBodega.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultadoss.Columns[1].Visible = false;

                        lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

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

        private void TBIdbodega_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fBodega.AutoComplementar_SQL(this.TBIdbodega.Text);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    Idsucurzal = Datos.Rows[0][0].ToString();
                    Nombre = Datos.Rows[0][1].ToString();
                    Descripcion = Datos.Rows[0][2].ToString();
                    Director = Datos.Rows[0][3].ToString();
                    Ciudad = Datos.Rows[0][4].ToString();
                    Telefono = Datos.Rows[0][5].ToString();
                    Movil = Datos.Rows[0][6].ToString();
                    Correo = Datos.Rows[0][7].ToString();
                    Zona = Datos.Rows[0][8].ToString();
                    Dimensiones = Datos.Rows[0][51].ToString();
                    Direccion01 = Datos.Rows[0][52].ToString();
                    Direccion02 = Datos.Rows[0][53].ToString();

                    //Panel Autorizacion de Pagos
                    Autorizacion_Pagos = Datos.Rows[0][9].ToString();
                    Aut_InicioLaboral = Datos.Rows[0][10].ToString();
                    Aut_FinalLaboral = Datos.Rows[0][11].ToString();
                    Aut_Lunes = Datos.Rows[0][12].ToString();
                    Aut_Martes = Datos.Rows[0][13].ToString();
                    Aut_Miercoles = Datos.Rows[0][14].ToString();
                    Aut_Jueves = Datos.Rows[0][15].ToString();
                    Aut_Viernes = Datos.Rows[0][16].ToString();
                    Aut_Sabado = Datos.Rows[0][17].ToString();
                    Aut_Domingo = Datos.Rows[0][18].ToString();
                    Aut_Bono = Datos.Rows[0][19].ToString();
                    Aut_Cheques = Datos.Rows[0][20].ToString();
                    Aut_Credito = Datos.Rows[0][21].ToString();
                    Aut_Debito = Datos.Rows[0][22].ToString();
                    Aut_Efectivo = Datos.Rows[0][23].ToString();
                    Aut_Sodexo = Datos.Rows[0][24].ToString();
                    Aut_Transferencia = Datos.Rows[0][25].ToString();
                    Aut_Otros = Datos.Rows[0][26].ToString();

                    //Panel Despachos
                    Despacho = Datos.Rows[0][27].ToString();
                    Des_InicioLaboral = Datos.Rows[0][28].ToString();
                    Des_FinalLaboral = Datos.Rows[0][29].ToString();
                    Des_Lunes = Datos.Rows[0][30].ToString();
                    Des_Martes = Datos.Rows[0][31].ToString();
                    Des_Miercoles = Datos.Rows[0][32].ToString();
                    Des_Jueves = Datos.Rows[0][33].ToString();
                    Des_Viernes = Datos.Rows[0][34].ToString();
                    Des_Sabado = Datos.Rows[0][35].ToString();
                    Des_Domingo = Datos.Rows[0][36].ToString();
                    Des_Encargado = Datos.Rows[0][37].ToString();
                    Des_Observacion = Datos.Rows[0][38].ToString();

                    //Panel Recepcion
                    Recepcion = Datos.Rows[0][39].ToString();
                    Rec_InicioLaboral = Datos.Rows[0][40].ToString();
                    Rec_FinalLaboral = Datos.Rows[0][41].ToString();
                    Rec_Lunes = Datos.Rows[0][42].ToString();
                    Rec_Martes = Datos.Rows[0][43].ToString();
                    Rec_Miercoles = Datos.Rows[0][44].ToString();
                    Rec_Jueves = Datos.Rows[0][45].ToString();
                    Rec_Viernes = Datos.Rows[0][46].ToString();
                    Rec_Sabado = Datos.Rows[0][47].ToString();
                    Rec_Domingo = Datos.Rows[0][48].ToString();
                    Rec_Encargado = Datos.Rows[0][49].ToString();
                    Rec_Observacion = Datos.Rows[0][50].ToString();

                    //Se procede a completar los campos de texto segun las consulta Realizada anteriormente en la base de datos

                    this.CBSucurzal.SelectedValue = Idsucurzal;
                    this.CBZona.Text = Zona;
                    this.TBBodega.Text = Nombre;
                    this.TBDocumento.Text = Documento;
                    this.TBDescripcion.Text = Descripcion;
                    this.TBDirector.Text = Director;
                    this.TBCiudad.Text = Ciudad;
                    this.TBTelefono.Text = Telefono;
                    this.TBMovil.Text = Movil;
                    this.TBCorreo.Text = Correo;
                    this.TBDireccion01.Text = Direccion01;
                    this.TBDireccion02.Text = Direccion02;
                    this.TBMedidas.Text = Dimensiones;

                    //
                    this.TBAutorizacion_Pagos.Text = Autorizacion_Pagos;
                    this.TBInicioHorario_Pagos.Text = Aut_InicioLaboral;
                    this.TBFinHorario_Pagos.Text = Aut_FinalLaboral;
                    
                    //
                    this.TBRecepcion.Text = Recepcion;
                    this.TBInicioRecepcion.Text = Rec_InicioLaboral;
                    this.TBFinRecepcion.Text = Rec_FinalLaboral;

                    //
                    this.TBDespacho.Text = Despacho;
                    this.TBInicioDespacho.Text = Des_InicioLaboral;
                    this.TBFinDeDespacho.Text = Des_FinalLaboral;

                    //Se validan los Chebox si estan activos o no son activos

                    //Panel Datos Pagos ***********************************************************************************************************
                    if (this.ChbPagos_Lunes=="1")
                    {
                        this.CHLunes_Pagos.Checked = true;
                    }
                    else
                    {
                        this.CHLunes_Pagos.Checked = false;
                    }

                    if (this.ChbPagos_Martes=="1")
                    {
                        this.CHMartes_Pagos.Checked = true;
                    }
                    else
                    {
                        this.CHMartes_Pagos.Checked = false;
                    }

                    if (this.ChbPagos_Miercoles == "1")
                    {
                        this.CHMiercoles_Pagos.Checked = true;
                    }
                    else
                    {
                        this.CHMiercoles_Pagos.Checked = false;
                    }

                    if (this.ChbPagos_Jueves == "1")
                    {
                        this.CHJueves_Pagos.Checked = true;
                    }
                    else
                    {
                        this.CHJueves_Pagos.Checked = false;
                    }

                    if (this.ChbPagos_Viernes == "1")
                    {
                        this.CHViernes_Pagos.Checked = true;
                    }
                    else
                    {
                        this.CHViernes_Pagos.Checked = false;
                    }

                    if (this.ChbPagos_Sabado == "1")
                    {
                        this.CHSabado_Pagos.Checked = true;
                    }
                    else
                    {
                        this.CHSabado_Pagos.Checked = false;
                    }

                    if (this.ChbPagos_Domingo == "1")
                    {
                        this.CHDomingo_Pagos.Checked = true;
                    }
                    else
                    {
                        this.CHDomingo_Pagos.Checked = false;
                    }

                    if (this.ChbMetodos_Bono == "1")
                    {
                        this.CHBono.Checked = true;
                    }
                    else
                    {
                        this.CHBono.Checked = false;
                    }

                    if (this.ChbMetodos_Credito == "1")
                    {
                        this.CHCredito.Checked = true;
                    }
                    else
                    {
                        this.CHCredito.Checked = false;
                    }

                    if (this.ChbMetodos_Debito == "1")
                    {
                        this.CHDebito.Checked = true;
                    }
                    else
                    {
                        this.CHDebito.Checked = false;
                    }

                    if (this.ChbMetodos_Efectivo == "1")
                    {
                        this.CHEfectivo.Checked = true;
                    }
                    else
                    {
                        this.CHEfectivo.Checked = false;
                    }

                    if (this.ChbMetodos_Sodexo == "1")
                    {
                        this.CHSodexo.Checked = true;
                    }
                    else
                    {
                        this.CHSodexo.Checked = false;
                    }

                    if (this.ChbMetodos_Transferencia == "1")
                    {
                        this.CHTransferencia.Checked = true;
                    }
                    else
                    {
                        this.CHTransferencia.Checked = false;
                    }

                    if (this.ChbMetodos_Cheque == "1")
                    {
                        this.CHCheques.Checked = true;
                    }
                    else
                    {
                        this.CHCheques.Checked = false;
                    }

                    if (this.ChbMetodos_Otros == "1")
                    {
                        this.CHOtros.Checked = true;
                    }
                    else
                    {
                        this.CHOtros.Checked = false;
                    }

                    // Panel Datos de Despacho ***********************************************************************************************************

                    if (this.ChbDespacho_Lunes == "1")
                    {
                        this.CHLunes_Despacho.Checked = true;
                    }
                    else
                    {
                        this.CHLunes_Despacho.Checked = false;
                    }

                    if (this.ChbDespacho_Martes == "1")
                    {
                        this.CHMartes_Despacho.Checked = true;
                    }
                    else
                    {
                        this.CHMartes_Despacho.Checked = false;
                    }

                    if (this.ChbDespacho_Miercoles == "1")
                    {
                        this.CHMiercoles_Despacho.Checked = true;
                    }
                    else
                    {
                        this.CHMiercoles_Despacho.Checked = false;
                    }

                    if (this.ChbDespacho_Jueves == "1")
                    {
                        this.CHJueves_Despacho.Checked = true;
                    }
                    else
                    {
                        this.CHJueves_Despacho.Checked = false;
                    }

                    if (this.ChbDespacho_Viernes == "1")
                    {
                        this.CHViernes_Despacho.Checked = true;
                    }
                    else
                    {
                        this.CHViernes_Despacho.Checked = false;
                    }

                    if (this.ChbDespacho_Sabado == "1")
                    {
                        this.CHSabado_Despacho.Checked = true;
                    }
                    else
                    {
                        this.CHSabado_Despacho.Checked = false;
                    }

                    if (this.ChbDespacho_Domingo == "1")
                    {
                        this.CHDomingo_Despacho.Checked = true;
                    }
                    else
                    {
                        this.CHDomingo_Despacho.Checked = false;
                    }

                    //Panel Datos de Recepcion ***********************************************************************************************************

                    if (this.ChbRecepcion_Lunes == "1")
                    {
                        this.CHLunes_Recepcion.Checked = true;
                    }
                    else
                    {
                        this.CHLunes_Recepcion.Checked = false;
                    }

                    if (this.ChbRecepcion_Martes == "1")
                    {
                        this.CHMartes_Recepcion.Checked = true;
                    }
                    else
                    {
                        this.CHMartes_Recepcion.Checked = false;
                    }

                    if (this.ChbRecepcion_Miercoles == "1")
                    {
                        this.CHMiercoles_Recepcion.Checked = true;
                    }
                    else
                    {
                        this.CHMiercoles_Recepcion.Checked = false;
                    }

                    if (this.ChbRecepcion_Jueves == "1")
                    {
                        this.CHJueves_Recepcion.Checked = true;
                    }
                    else
                    {
                        this.CHJueves_Recepcion.Checked = false;
                    }

                    if (this.ChbRecepcion_Viernes == "1")
                    {
                        this.CHViernes_Recepcion.Checked = true;
                    }
                    else
                    {
                        this.CHViernes_Recepcion.Checked = false;
                    }

                    if (this.ChbRecepcion_Sabado == "1")
                    {
                        this.CHSabado_Recepcion.Checked = true;
                    }
                    else
                    {
                        this.CHSabado_Recepcion.Checked = false;
                    }

                    if (this.ChbRecepcion_Domingo == "1")
                    {
                        this.CHDomingo_Recepcion.Checked = true;
                    }
                    else
                    {
                        this.CHDomingo_Recepcion.Checked = false;
                    }

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
                    this.TBIdbodega.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);
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

        private void DGResultados_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (Editar == "1")
                    {
                        //
                        this.Digitar = false;
                        this.Botones();

                        //Se procede a completar los campos de textos segun
                        //la consulta realizada en la base de datos
                        this.TBIdbodega.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Actualizar Datos en el Sistema", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBSucurzal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBSucurzal.SelectedIndex == 0)
            {
                this.TBBodega.Select();
            }
            else
            {
                this.TBBodega.Select();
            }
        }

        //******************** FOCUS ENTER DATOS BASICOS ********************
        private void TBBodega_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBBodega.Text == Campo)
            {
                this.TBBodega.BackColor = Color.Azure;
                this.TBBodega.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBBodega.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBBodega.BackColor = Color.Azure;
            }
        }

        private void TBDescripcion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDescripcion.Text == Campo)
            {
                this.TBDescripcion.BackColor = Color.Azure;
                this.TBDescripcion.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDescripcion.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDescripcion.BackColor = Color.Azure;
            }
        }

        private void TBDirector_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDirector.Text == Campo)
            {
                this.TBDirector.BackColor = Color.Azure;
                this.TBDirector.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDirector.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDirector.BackColor = Color.Azure;
            }
        }

        private void TBCiudad_Enter(object sender, EventArgs e)
        {
            this.TBCiudad.BackColor = Color.Azure;
        }

        private void TBMovil_Enter(object sender, EventArgs e)
        {
            this.TBMovil.BackColor = Color.Azure;
        }

        private void TBTelefono_Enter(object sender, EventArgs e)
        {
            this.TBTelefono.BackColor = Color.Azure;
        }

        private void TBCorreo_Enter(object sender, EventArgs e)
        {
            this.TBCorreo.BackColor = Color.Azure;
        }

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.Azure;
        }

        //******************** FOCUS LEVAE  DATOS BASICOS ********************
        private void TBBodega_Leave(object sender, EventArgs e)
        {
            if (TBBodega.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBBodega.BackColor = Color.FromArgb(3, 155, 229);
                this.TBBodega.Text = Campo;
                this.TBBodega.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBBodega.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDescripcion_Leave(object sender, EventArgs e)
        {
            if (TBDescripcion.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDescripcion.Text = Campo;
                this.TBDescripcion.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDirector_Leave(object sender, EventArgs e)
        {
            if (TBDirector.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDirector.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDirector.Text = Campo;
                this.TBDirector.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBDirector.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCiudad_Leave(object sender, EventArgs e)
        {
            this.TBCiudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_Leave(object sender, EventArgs e)
        {
            this.TBMovil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBTelefono_Leave(object sender, EventArgs e)
        {
            this.TBTelefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCorreo_Leave(object sender, EventArgs e)
        {
            this.TBCorreo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMedidas_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDireccion01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccion01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDireccion02.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMedidas_Enter(object sender, EventArgs e)
        {
            this.TBMedidas.BackColor = Color.Azure;
        }

        private void TBDireccion01_Enter(object sender, EventArgs e)
        {
            this.TBDireccion01.BackColor = Color.Azure;
        }

        private void TBDireccion01_Leave(object sender, EventArgs e)
        {
            this.TBDireccion01.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion02_Enter(object sender, EventArgs e)
        {
            this.TBDireccion02.BackColor = Color.Azure;
        }

        private void TBDireccion02_Leave(object sender, EventArgs e)
        {
            this.TBDireccion02.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMedidas_Leave(object sender, EventArgs e)
        {
            this.TBMedidas.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBBodega.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBAutorizacion_Pagos_Enter(object sender, EventArgs e)
        {
            this.TBAutorizacion_Pagos.BackColor = Color.Azure;
        }

        private void TBInicioHorario_Pagos_Enter(object sender, EventArgs e)
        {
            this.TBInicioHorario_Pagos.BackColor = Color.Azure;
        }

        private void TBFinHorario_Pagos_Enter(object sender, EventArgs e)
        {
            this.TBFinHorario_Pagos.BackColor = Color.Azure;
        }

        private void TBRecepcion_Enter(object sender, EventArgs e)
        {
            this.TBRecepcion.BackColor = Color.Azure;
        }

        private void TBInicioRecepcion_Enter(object sender, EventArgs e)
        {
            this.TBInicioRecepcion.BackColor = Color.Azure;
        }

        private void TBFinRecepcion_Enter(object sender, EventArgs e)
        {
            this.TBFinRecepcion.BackColor = Color.Azure;
        }

        private void TBDespacho_Enter(object sender, EventArgs e)
        {
            this.TBDespacho.BackColor = Color.Azure;
        }

        private void TBEncargado_Recepcion_Enter(object sender, EventArgs e)
        {
            this.TBEncargado_Recepcion.BackColor = Color.Azure;
        }

        private void TBObservacion_Recepcion_Enter(object sender, EventArgs e)
        {
            this.TBObservacion_Recepcion.BackColor = Color.Azure;
        }

        private void TBEncargado_Despacho_Enter(object sender, EventArgs e)
        {
            this.TBEncargado_Despacho.BackColor = Color.Azure;
        }

        private void TBObservacion_Despacho_Enter(object sender, EventArgs e)
        {
            this.TBObservacion_Despacho.BackColor = Color.Azure;
        }

        private void TBAutorizacion_Pagos_Leave(object sender, EventArgs e)
        {
            this.TBAutorizacion_Pagos.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBInicioHorario_Pagos_Leave(object sender, EventArgs e)
        {
            this.TBInicioHorario_Pagos.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFinHorario_Pagos_Leave(object sender, EventArgs e)
        {
            this.TBFinHorario_Pagos.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBInicioRecepcion_Leave(object sender, EventArgs e)
        {
            this.TBInicioRecepcion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFinRecepcion_Leave(object sender, EventArgs e)
        {
            this.TBFinRecepcion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBEncargado_Recepcion_Leave(object sender, EventArgs e)
        {
            this.TBEncargado_Recepcion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBObservacion_Recepcion_Leave(object sender, EventArgs e)
        {
            this.TBObservacion_Recepcion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBInicioDespacho_Enter(object sender, EventArgs e)
        {
            this.TBInicioDespacho.BackColor = Color.Azure;
        }

        private void TBFinDeDespacho_Enter(object sender, EventArgs e)
        {
            this.TBFinDeDespacho.BackColor = Color.Azure;
        }

        private void TBEncargado_Despacho_Leave(object sender, EventArgs e)
        {
            this.TBEncargado_Despacho.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBObservacion_Despacho_Leave(object sender, EventArgs e)
        {
            this.TBObservacion_Despacho.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFinDeDespacho_Leave(object sender, EventArgs e)
        {
            this.TBFinDeDespacho.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBInicioDespacho_Leave(object sender, EventArgs e)
        {
            this.TBInicioDespacho.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDespacho_Leave(object sender, EventArgs e)
        {
            this.TBDespacho.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBRecepcion_Leave(object sender, EventArgs e)
        {
            this.TBRecepcion.BackColor = Color.FromArgb(3, 155, 229);
        }

        //******************** FOCUS LEVAE  DATOS AUXILIARES ********************

        private void TBDireccion01_Leave_1(object sender, EventArgs e)
        {
            this.TBDireccion01.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion02_Leave_1(object sender, EventArgs e)
        {
            this.TBDireccion02.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBodega_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDocumento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBBodega.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBBodega.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDirector.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDescripcion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDescripcion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDirector_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCiudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDirector.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDirector.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCiudad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBMovil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCiudad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCiudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBTelefono.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBMovil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBMovil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCorreo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBTelefono.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBTelefono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBMedidas.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCorreo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBRecepcion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDespacho.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBRecepcion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBRecepcion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDocumento_Enter(object sender, EventArgs e)
        {
            this.TBDocumento.BackColor = Color.Azure;
        }

        private void TBDocumento_Leave(object sender, EventArgs e)
        {
            this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDescripcion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDocumento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDocumento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccion01_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDireccion02.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDireccion01.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDireccion01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccion02_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBRecepcion.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDireccion02.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                            this.Limpiar_Datos();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDireccion02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
