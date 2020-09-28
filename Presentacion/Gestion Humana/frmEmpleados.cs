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
    public partial class frmEmpleados : Form
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

        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.AutoCompletar_Combobox();

            //Focus a Texboxt y Combobox
            this.TBEmpleado.Select();

            //Ocultacion de Texboxt
            this.TBIdempleado.Visible = false;
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEmpleado.ReadOnly = false;
            this.TBEmpleado.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEmpleado.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBEmpleado.Text = Campo;
            this.TBDocumento.ReadOnly = false;
            this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDocumento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDocumento.Text = Campo;
            this.TBPais_Dom.ReadOnly = false;
            this.TBPais_Dom.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCiudad_Dom.ReadOnly = false;
            this.TBCiudad_Dom.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFijo_Dom.ReadOnly = false;
            this.TBFijo_Dom.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExtension_Dom.ReadOnly = false;
            this.TBExtension_Dom.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCorreo.ReadOnly = false;
            this.TBCorreo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMovil_Dom.ReadOnly = false;
            this.TBMovil_Dom.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Datos Financieros - Otros Datos
            this.TBProfesion.ReadOnly = false;
            this.TBProfesion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCargo.ReadOnly = false;
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
            this.CBDepartamento.Enabled = true;
            this.CBDepartamento.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBCodigo.Clear();
            this.TBEmpleado.Clear();
            this.TBEmpleado.Text = Campo;
            this.TBDocumento.Clear();
            this.TBDocumento.Text = Campo;
            this.TBPais_Dom.Clear();
            this.TBCiudad_Dom.Clear();
            this.TBFijo_Dom.Clear();
            this.TBExtension_Dom.Clear();
            this.TBCorreo.Clear();
            this.TBMovil_Dom.Clear();

            //Panel - Datos Financieros - Otros Datos
            this.TBProfesion.Clear();
            this.TBCargo.Clear();
            this.CBDepartamento.SelectedIndex = 0;
            this.CBTipodecontrato.SelectedIndex = 0;

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBEmpleado.Select();
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

        private void AutoCompletar_Combobox()
        {
            try
            {
                this.CBTipodecontrato.DataSource = fGestion_TipoDeContrato.Lista();
                this.CBTipodecontrato.ValueMember = "ID";
                this.CBTipodecontrato.DisplayMember = "Contrato";

                this.CBDepartamento.DataSource = fGestion_Departameto.Lista();
                this.CBDepartamento.ValueMember = "ID";
                this.CBDepartamento.DisplayMember = "Departamento";

                this.CBSucurzal.DataSource = fSucurzal.Lista();
                this.CBSucurzal.ValueMember = "Codigo";
                this.CBSucurzal.DisplayMember = "Sucurzal";
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

                if (this.TBEmpleado.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Empleado a registrar");
                }
                else if (this.TBDocumento.Text == Campo)
                {
                    MensajeError("Ingrese el Numero de Documento del Empleado a registrar");
                }

                else
                {
                    //Parametros para poder guardar la imagen del producto

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.PB_FotoEmpleado.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] Imagen_Producto = ms.GetBuffer();

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fGestion_Empleados.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 1, Convert.ToInt32(CBDepartamento.SelectedValue), Convert.ToInt32(this.CBTipodecontrato.SelectedValue), Convert.ToInt32(CBSucurzal.SelectedValue),

                                 //Panel Datos Basicos
                                 this.TBCodigo.Text, this.TBEmpleado.Text, this.TBDocumento.Text, this.TBProfesion.Text, this.TBCargo.Text, this.TBCorreo.Text, this.TBPais_Dom.Text, this.TBCiudad_Dom.Text, this.TBFijo_Dom.Text, this.TBExtension_Dom.Text, this.TBMovil_Dom.Text, this.TBDireccion_Dom.Text, this.TBPais_Emp.Text, this.TBCiudad_Emp.Text, this.TBFijo_Emp.Text, this.TBExtension_Emp.Text, this.TBMovil_Emp.Text, this.TBDireccion_Emp.Text, Imagen_Producto
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fGestion_Empleados.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 2, Convert.ToInt32(this.TBIdempleado.Text), Convert.ToInt32(CBDepartamento.SelectedValue), Convert.ToInt32(this.CBTipodecontrato.SelectedValue), Convert.ToInt32(CBSucurzal.SelectedValue),

                                 //Panel Datos Basicos
                                 this.TBCodigo.Text, this.TBEmpleado.Text, this.TBDocumento.Text, this.TBProfesion.Text, this.TBCargo.Text, this.TBCorreo.Text, this.TBPais_Dom.Text, this.TBCiudad_Dom.Text, this.TBFijo_Dom.Text, this.TBExtension_Dom.Text, this.TBMovil_Dom.Text, this.TBDireccion_Dom.Text, this.TBPais_Emp.Text, this.TBCiudad_Emp.Text, this.TBFijo_Emp.Text, this.TBExtension_Emp.Text, this.TBMovil_Emp.Text, this.TBDireccion_Emp.Text, Imagen_Producto
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Empleado: " + this.TBEmpleado.Text + " a Sido Registrado");
                        }

                        else
                        {
                            this.MensajeOk("El Registro del Empleado: "+this.TBEmpleado.Text+" a Sido Actualizado");
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
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fGestion_Empleados.Buscar(this.TBBuscar.Text, 1);
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

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Digitar = false;

                if (Editar == "1")
                {
                    //
                    this.TBEmpleado.Select();

                    this.TBIdempleado.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

                    //
                    this.Limpiar_Datos();

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
                    this.Digitar = false;

                    if (Editar == "1")
                    {
                        //
                        this.TBEmpleado.Select();
                        this.TBIdempleado.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

                        //Se procede Habilitar los campos de Textos y Botones
                        //cuando se le realice el evento Clip del Boton Ediatar/Guardar

                        this.Habilitar();
                        this.btnGuardar.Enabled = true;
                        this.btnCancelar.Enabled = true;

                        //
                        this.Limpiar_Datos();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Actualizar Datos", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBEmpleado_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBEmpleado.Text == Campo)
            {
                this.TBEmpleado.BackColor = Color.Azure;
                this.TBEmpleado.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBEmpleado.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBEmpleado.BackColor = Color.Azure;
            }
        }

        private void TBDocumento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDocumento.Text == Campo)
            {
                this.TBDocumento.BackColor = Color.Azure;
                this.TBDocumento.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDocumento.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDocumento.BackColor = Color.Azure;
            }
        }

        private void TBPais_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBPais_Dom.Text == Campo)
            {
                this.TBPais_Dom.BackColor = Color.Azure;
                this.TBPais_Dom.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBPais_Dom.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBPais_Dom.BackColor = Color.Azure;
            }
        }

        private void TBCiudad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCiudad_Dom.Text == Campo)
            {
                this.TBCiudad_Dom.BackColor = Color.Azure;
                this.TBCiudad_Dom.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCiudad_Dom.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCiudad_Dom.BackColor = Color.Azure;
            }
        }

        private void TBFijo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBFijo_Dom.Text == Campo)
            {
                this.TBFijo_Dom.BackColor = Color.Azure;
                this.TBFijo_Dom.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBFijo_Dom.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBFijo_Dom.BackColor = Color.Azure;
            }
        }

        private void TBMovil_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBExtension_Dom.Text == Campo)
            {
                this.TBExtension_Dom.BackColor = Color.Azure;
                this.TBExtension_Dom.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBExtension_Dom.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBExtension_Dom.BackColor = Color.Azure;
            }
        }

        private void TBCorreo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCorreo.Text == Campo)
            {
                this.TBCorreo.BackColor = Color.Azure;
                this.TBCorreo.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCorreo.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCorreo.BackColor = Color.Azure;
            }
        }

        private void TBDireccion01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBMovil_Dom.Text == Campo)
            {
                this.TBMovil_Dom.BackColor = Color.Azure;
                this.TBMovil_Dom.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBMovil_Dom.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBMovil_Dom.BackColor = Color.Azure;
            }
        }

        //**************************** FOCUS ENTER - Datos Financieros *******************************
        
        private void TBProfesion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBProfesion.Text == Campo)
            {
                this.TBProfesion.BackColor = Color.Azure;
                this.TBProfesion.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBProfesion.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBProfesion.BackColor = Color.Azure;
            }
        }

        private void TBCargo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCargo.Text == Campo)
            {
                this.TBCargo.BackColor = Color.Azure;
                this.TBCargo.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCargo.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCargo.BackColor = Color.Azure;
            }
        }

        //**************************** FOCUS ENTER - Datos de Consulta *******************************
        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBBuscar.Text == Campo)
            {
                this.TBBuscar.BackColor = Color.Azure;
                this.TBBuscar.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBBuscar.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBBuscar.BackColor = Color.Azure;
            }
        }

        //**************************** FOCUS LEAVE - Datos Basicos *******************************

        private void TBEmpleado_Leave(object sender, EventArgs e)
        {
            if (TBEmpleado.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBEmpleado.BackColor = Color.FromArgb(3, 155, 229);
                this.TBEmpleado.Text = Campo;
                this.TBEmpleado.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBEmpleado.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDocumento_Leave(object sender, EventArgs e)
        {
            if (TBDocumento.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDocumento.Text = Campo;
                this.TBDocumento.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBPais_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBPais_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCiudad_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBCiudad_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFijo_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFijo_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExtension_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCorreo_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBCorreo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion01_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBMovil_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBEmpleado.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBEmpleado.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBEmpleado.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCodigo_Enter(object sender, EventArgs e)
        {
            this.TBCodigo.BackColor = Color.Azure;
        }

        private void PB_FotoEmpleado_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.PB_FotoEmpleado.SizeMode = PictureBoxSizeMode.StretchImage;
                this.PB_FotoEmpleado.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void TBCodigo_Leave(object sender, EventArgs e)
        {
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBIdempleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fProducto_Inventario.Buscar(this.TBIdempleado.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    ////Panel Datos Basicos - Llaves Primarias
                    //Idmarca = Datos.Rows[0][0].ToString();
                    //Idgrupo = Datos.Rows[0][1].ToString();
                    //Idtipo = Datos.Rows[0][2].ToString();
                    //Idempaque = Datos.Rows[0][3].ToString();
                    //Idbodega = Datos.Rows[0][4].ToString();
                    //Idproveedor = Datos.Rows[0][5].ToString();
                    //Idimpuesto = Datos.Rows[0][6].ToString();

                    ////Panel Datos Basicos
                    //Codigo = Datos.Rows[0][7].ToString();
                    //Nombre = Datos.Rows[0][8].ToString();
                    //Referencia = Datos.Rows[0][9].ToString();
                    //Descripcion = Datos.Rows[0][10].ToString();
                    //Presentacion = Datos.Rows[0][11].ToString();
                    //Proveedor = Datos.Rows[0][12].ToString();
                    //Impuesto = Datos.Rows[0][13].ToString();
                    ////Impuesto_Valor = Datos.Rows[0][14].ToString();
                    //UnidadDeVenta = Datos.Rows[0][15].ToString();
                    ////ValorUnidad = Datos.Rows[0][16].ToString();
                    //ManejaVencimiento = Datos.Rows[0][17].ToString();
                    //ManjenaImpuesto = Datos.Rows[0][18].ToString();
                    //Importado = Datos.Rows[0][19].ToString();
                    //Exportado = Datos.Rows[0][20].ToString();
                    //Ofertable = Datos.Rows[0][21].ToString();
                    ////VentaImpuesto = Datos.Rows[0][22].ToString();
                    //ComisionEmpleado = Datos.Rows[0][23].ToString();

                    ////Panel - Valores
                    //Valor_Promedio = Datos.Rows[0][24].ToString();
                    //Valor_Final = Datos.Rows[0][25].ToString();
                    //Valor_Excento = Datos.Rows[0][26].ToString();
                    //Valor_NoExcento = Datos.Rows[0][27].ToString();
                    //Valor_Mayorista = Datos.Rows[0][28].ToString();
                    //Comision = Datos.Rows[0][29].ToString();
                    //Valor_Comision = Datos.Rows[0][30].ToString();
                    //Minimo_Cliente = Datos.Rows[0][31].ToString();
                    //Maximo_Cliente = Datos.Rows[0][32].ToString();
                    //Minimo_Mayorista = Datos.Rows[0][33].ToString();
                    //Maximo_Mayorista = Datos.Rows[0][34].ToString();

                    ////
                    //Ubicacion = Datos.Rows[0][35].ToString();
                    //Estante = Datos.Rows[0][36].ToString();
                    //Nivel = Datos.Rows[0][37].ToString();
                    //Imagen = Datos.Rows[0][38].ToString();

                    ////
                    //Lote = Datos.Rows[0][39].ToString();
                    //Valor_Lote = Datos.Rows[0][40].ToString();
                    //Fecha_Vencimiento = Datos.Rows[0][41].ToString();

                    ////
                    //CodigoDeBarra = Datos.Rows[0][42].ToString();


                    ////Se procede a completar los campos de texto segun las consulta
                    ////Realizada anteriormente en la base de datos

                    //this.Marca_SQL = Idmarca;
                    //this.CBMarca.SelectedValue = Marca_SQL;

                    //this.Grupo_SQL = Idgrupo;
                    //this.CBGrupo.SelectedValue = Grupo_SQL;

                    //this.Tipo_SQL = Idtipo;
                    //this.CBTipo.SelectedValue = Tipo_SQL;

                    //this.Empaque_SQL = Idempaque;
                    //this.CBEmpaque.SelectedValue = Empaque_SQL;

                    //this.Bodega_SQL = Idbodega;
                    //this.CBBodega.SelectedValue = Bodega_SQL;

                    ////Panel Datos Basicos
                    //this.TBCodigo.Text = Codigo;
                    //this.TBIdproveedor.Text = Idproveedor;
                    //this.TBIdimpuesto.Text = Idimpuesto;

                    ////Panel Datos Basicos
                    //this.TBCodigo.Text = Codigo;
                    //this.TBNombre.Text = Nombre;
                    //this.TBReferencia.Text = Referencia;
                    //this.TBDescripcion01.Text = Descripcion;
                    //this.TBPresentacion.Text = Presentacion;
                    //this.CBUnidad.Text = UnidadDeVenta;

                    ////Panel - Valores
                    //this.TBCompraPromedio.Text = Valor_Promedio;
                    //this.TBCompraFinal.Text = Valor_Final;
                    //this.TBValorVenta_Excento.Text = Valor_Excento;
                    //this.TBValorVenta_NoExcento.Text = Valor_NoExcento;
                    //this.TBVentaMayorista.Text = Valor_Mayorista;
                    //this.TBComision_Porcentaje.Text = Comision;
                    //this.TBComision_Valor.Text = Valor_Comision;
                    //this.TBVentaMinina_Cliente.Text = Minimo_Cliente;
                    //this.TBVentaMaxima_Cliente.Text = Maximo_Cliente;
                    //this.TBVentaMinima_Mayorista.Text = Minimo_Mayorista;
                    //this.TBVentaMaxima_Mayorista.Text = Maximo_Mayorista;

                    ////
                    //this.TBUbicacion.Text = Ubicacion;
                    //this.TBEstante.Text = Estante;
                    //this.TBNivel.Text = Nivel;
                    ////this.PB_Imagen.Image = Imagen;

                    ////
                    //this.TBLotedeingreso.Text = Lote;
                    //this.TBValor_Lote.Text = Valor_Lote;
                    //this.DTLote_Vencimiento.Text = Fecha_Vencimiento;

                    ////
                    //this.TBBuscar_CodigodeBarra.Text = CodigoDeBarra;
                    //this.TBBuscar_Proveedor.Text = Proveedor;
                    //this.TBBuscar_Impuesto.Text = Impuesto;

                    ////Se proceden a Validar los Chexboxt si estan activos o no

                    //if (ManejaVencimiento == "0")
                    //{
                    //    this.CBVencimiento.Checked = false;
                    //}
                    //else
                    //{
                    //    this.CBVencimiento.Checked = true;
                    //}

                    //if (Importado == "0")
                    //{
                    //    this.CBImportado.Checked = false;
                    //}
                    //else
                    //{
                    //    this.CBImportado.Checked = true;
                    //}

                    //if (Exportado == "0")
                    //{
                    //    this.CBExportado.Checked = false;
                    //}
                    //else
                    //{
                    //    this.CBExportado.Checked = true;
                    //}

                    //if (ManjenaImpuesto == "0")
                    //{
                    //    this.CBImpuesto.Checked = false;
                    //}
                    //else
                    //{
                    //    this.CBImpuesto.Checked = true;
                    //}

                    //if (Ofertable == "0")
                    //{
                    //    this.CBOfertable.Checked = false;
                    //}
                    //else
                    //{
                    //    this.CBOfertable.Checked = true;
                    //}

                    //if (ComisionEmpleado == "0")
                    //{
                    //    this.CBManejaComision.Checked = false;
                    //}
                    //else
                    //{
                    //    this.CBManejaComision.Checked = true;
                    //}

                    ////Se realizan las consultas para llenar los DataGriview donde se mostrarian las ubicaciones, codigos de barra.

                    ////this.DGResultados.DataSource = fProducto_Inventario.Buscar(this.TBBuscar.Text, 1);
                    ////this.DGResultados.Columns[0].Visible = false;

                    ////lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //**************************** FOCUS Leave - Datos Financieros *******************************
        private void TBProfesion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBProfesion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCargo_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBEmpleado_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDocumento.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBEmpleado.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBEmpleado.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBPais_Dom.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
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

        private void TBPais_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCiudad_Dom.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBPais_Dom.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBPais_Dom.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBFijo_Dom.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCiudad_Dom.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCiudad_Dom.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFijo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBExtension_Dom.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFijo_Dom.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFijo_Dom.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCorreo.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBExtension_Dom.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBExtension_Dom.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBMovil_Dom.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
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

        private void TBProfesion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCargo.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBProfesion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBProfesion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCargo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCodigo.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCargo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCargo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    //this.TBComision.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
