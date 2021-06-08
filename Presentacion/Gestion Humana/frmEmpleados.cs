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
        private static frmEmpleados _Instancia;

        public static frmEmpleados GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmEmpleados();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";

        //Variable para Captura el Empleado Logueado
        public int Idempleado;

        //********** Variables para AutoComplementar Combobox, Codigo_AutoIncrementable y Chexboxt segun la Consulta en SQL *************************

        private string Departamento_SQL, Contrato_SQL, Sucurzal_SQL, Operacion, AutoIncrementable = "";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar ****************************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Parametros para AutoCompletar los Texboxt ************************************************************

        //Llaves Primarias
        private string Idcontrato, Idsucurzal, Iddepartamento,

        //Datos Basicos
        Codigo, Empleado, Documento, Profesion, Cargo, Email, Foto,
        
        //Datos de Comunicacion Domiciliario
        Pais_Dom, Ciudad_Dom, Fijo_Dom, Extension_Dom, Movil_Dom, Direccion_Dom,

        //Datos de Comunicacion Empresarial
        Pais_Emp, Ciudad_Emp, Fijo_Emp, Extension_Emp, Movil_Emp, Direccion_Emp = "";

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
            this.Auto_CodigoSQL();

            //Focus a Texboxt y Combobox
            this.TBEmpleado.Select();

            //Ocultacion de Texboxt
            this.TBIdempleado.Visible = false;
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            //this.TBCodigo.ReadOnly = false;
            //this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEmpleado.ReadOnly = false;
            this.TBEmpleado.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEmpleado.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBEmpleado.Text = Campo;
            this.TBDocumento.ReadOnly = false;
            this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDocumento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDocumento.Text = Campo;
            this.TBProfesion.ReadOnly = false;
            this.TBProfesion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCargo.ReadOnly = false;
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
            this.CBDepartamento.Enabled = true;
            this.CBDepartamento.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Contacto Domiciliario
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
            this.TBDireccion_Dom.ReadOnly = false;
            this.TBDireccion_Dom.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Contacto Empresarial
            this.TBPais_Emp.ReadOnly = false;
            this.TBPais_Emp.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCiudad_Emp.ReadOnly = false;
            this.TBCiudad_Emp.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFijo_Emp.ReadOnly = false;
            this.TBFijo_Emp.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExtension_Emp.ReadOnly = false;
            this.TBExtension_Emp.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCorreo.ReadOnly = false;
            this.TBCorreo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMovil_Emp.ReadOnly = false;
            this.TBMovil_Emp.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDireccion_Emp.ReadOnly = false;
            this.TBDireccion_Emp.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBIdempleado.Clear();
            //this.TBCodigo.Clear();
            this.TBEmpleado.Clear();
            this.TBEmpleado.Text = Campo;
            this.TBEmpleado.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDocumento.Clear();
            this.TBDocumento.Text = Campo;
            this.TBDocumento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBProfesion.Clear();
            this.TBCargo.Clear();
            this.CBSucurzal.SelectedIndex = 0;
            this.CBDepartamento.SelectedIndex = 0;
            this.CBTipodecontrato.SelectedIndex = 0;

            //Datos de Contacto Domiciliario
            this.TBPais_Dom.Clear();
            this.TBCiudad_Dom.Clear();
            this.TBFijo_Dom.Clear();
            this.TBExtension_Dom.Clear();
            this.TBCorreo.Clear();
            this.TBMovil_Dom.Clear();
            this.TBDireccion_Dom.Clear();

            //Datos de Contacto Empresarial
            this.TBPais_Emp.Clear();
            this.TBCiudad_Emp.Clear();
            this.TBFijo_Emp.Clear();
            this.TBExtension_Emp.Clear();
            this.TBCorreo.Clear();
            this.TBMovil_Emp.Clear();
            this.TBDireccion_Emp.Clear();

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBEmpleado.Select();

            this.Auto_CodigoSQL();

            this.PB_FotoEmpleado.Image = Properties.Resources.Logo_Leal_Enterprise;
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
        }

        private void Auto_CodigoSQL()
        {
            try
            {
                DataTable Datos = Negocio.fGestion_Empleados.AutoIncrementable(Convert.ToInt32(0));
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count != 0)
                {
                    //MessageBox.Show("Niveles de Seguridad no Cumplidos", "Leal Enterprise - Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.TBCodigo.Enabled = true;

                    Operacion = Datos.Rows[0][0].ToString();
                    AutoIncrementable = Datos.Rows[0][1].ToString();

                    if (Operacion == "A")
                    {
                        this.TBCodigo.Enabled = false;
                        this.TBCodigo.Text = "1";
                        this.TBCodigo.BackColor = Color.FromArgb(245, 245, 245);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

                this.CBSucurzal.DataSource = fSucurzal.Lista(3);
                this.CBSucurzal.ValueMember = "Codigo";
                this.CBSucurzal.DisplayMember = "Sucursal";
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
                            this.MensajeOk("Procedimiento de Digitalización Exitoso - Leal Enterprise \n\n" + "El Empleado: “" + this.TBEmpleado.Text + "” a Sido Registrado.");
                        }

                        else
                        {
                            this.MensajeOk("Procedimiento de Actualización Exitoso - Leal Enterprise \n\n" + "El Registro del Empleado(a): “" + this.TBEmpleado.Text + "” a Sido Modificado.");
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
                //Metodo Guardar y editar

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
                            Eliminacion = Convert.ToInt32(DGResultados.CurrentRow.Cells[0].Value.ToString());
                            Respuesta = Negocio.fGestion_Empleados.Eliminar(Eliminacion, 0);
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
                        this.TBEmpleado.Select();
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
                        this.DGResultados.DataSource = fGestion_Empleados.Buscar(this.TBBuscar.Text, 1);
                        this.DGResultados.Columns[0].Visible = false;

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
                    this.TBIdempleado.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["ID"].Value);

                    //
                    this.Botones();
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
            this.TBBuscar.BackColor = Color.Azure;
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

        private void TBPais_Dom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCiudad_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void TBCiudad_Dom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFijo_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void TBFijo_Dom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExtension_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void TBExtension_Dom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBMovil_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void TBMovil_Dom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDireccion_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBMovil_Dom.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBMovil_Dom.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccion_Dom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBPais_Emp.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBDireccion_Dom.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDireccion_Dom.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBPais_Emp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCiudad_Emp.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBPais_Emp.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBPais_Emp.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCiudad_Emp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFijo_Emp.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBCiudad_Emp.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCiudad_Emp.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFijo_Emp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExtension_Emp.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBFijo_Emp.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFijo_Emp.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExtension_Emp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBMovil_Emp.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBExtension_Emp.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBExtension_Emp.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil_Emp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDireccion_Emp.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBMovil_Emp.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBMovil_Emp.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccion_Emp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEmpleado.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBDireccion_Emp.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Clases y Focus
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDireccion_Emp.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBPais_Dom_Enter(object sender, EventArgs e)
        {
            this.TBPais_Dom.BackColor = Color.Azure;
        }

        private void TBCiudad_Dom_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBCiudad_Dom.BackColor = Color.Azure;
        }

        private void TBFijo_Dom_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBFijo_Dom.BackColor = Color.Azure;
        }

        private void TBExtension_Dom_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBExtension_Dom.BackColor = Color.Azure;
        }

        private void TBMovil_Dom_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBMovil_Dom.BackColor = Color.Azure;
        }

        private void TBDireccion_Dom_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBDireccion_Dom.BackColor = Color.Azure;
        }

        private void TBPais_Emp_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBPais_Emp.BackColor = Color.Azure;
        }

        private void TBCiudad_Emp_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBCiudad_Emp.BackColor = Color.Azure;
        }

        private void TBFijo_Emp_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBFijo_Emp.BackColor = Color.Azure;
        }

        private void TBExtension_Emp_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBExtension_Emp.BackColor = Color.Azure;
        }

        private void TBMovil_Emp_Enter(object sender, EventArgs e)
        {
            this.TBMovil_Emp.BackColor = Color.Azure;
        }

        private void TBDireccion_Emp_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBDireccion_Emp.BackColor = Color.Azure;
        }

        private void TBPais_Dom_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBPais_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCiudad_Dom_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBCiudad_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFijo_Dom_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFijo_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBExtension_Dom_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExtension_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_Dom_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBMovil_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void frmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void TBDireccion_Dom_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBDireccion_Dom.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBPais_Emp_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBPais_Emp.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCiudad_Emp_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBCiudad_Emp.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFijo_Emp_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFijo_Emp.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBExtension_Emp_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExtension_Emp.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_Emp_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBMovil_Emp.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion_Emp_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBDireccion_Emp.BackColor = Color.FromArgb(3, 155, 229);
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEmpleado.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                DataTable Datos = Negocio.fGestion_Empleados.Buscar(this.TBIdempleado.Text, 2);

                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Llaves Primarias
                    Idcontrato = Datos.Rows[0][0].ToString();
                    Idsucurzal = Datos.Rows[0][1].ToString();
                    Iddepartamento = Datos.Rows[0][2].ToString();

                    //Panel Datos Basicos
                    Codigo = Datos.Rows[0][3].ToString();
                    Empleado = Datos.Rows[0][4].ToString();
                    Documento = Datos.Rows[0][5].ToString();
                    Profesion = Datos.Rows[0][6].ToString();                
                    Cargo = Datos.Rows[0][7].ToString();
                    Email = Datos.Rows[0][8].ToString();

                    //Datos de Envio Domiciliario
                    Pais_Dom = Datos.Rows[0][9].ToString();
                    Ciudad_Dom = Datos.Rows[0][10].ToString();
                    Fijo_Dom = Datos.Rows[0][11].ToString();
                    Extension_Dom = Datos.Rows[0][12].ToString();
                    Movil_Dom = Datos.Rows[0][13].ToString();
                    Direccion_Dom = Datos.Rows[0][14].ToString();

                    //Datos de Envio Empresarial
                    Pais_Emp = Datos.Rows[0][15].ToString();
                    Ciudad_Emp = Datos.Rows[0][16].ToString();
                    Fijo_Emp = Datos.Rows[0][17].ToString();
                    Extension_Emp = Datos.Rows[0][18].ToString();
                    Movil_Emp = Datos.Rows[0][19].ToString();
                    Direccion_Emp = Datos.Rows[0][20].ToString();
                    Foto = Datos.Rows[0][21].ToString();


                    //Se procede a completar los campos de texto segun las consulta
                    //Realizada anteriormente en la base de datos

                    this.Departamento_SQL = Iddepartamento;
                    this.CBDepartamento.SelectedValue = Departamento_SQL;

                    this.Sucurzal_SQL = Idsucurzal;
                    this.CBSucurzal.SelectedValue = Sucurzal_SQL;

                    this.Contrato_SQL = Idcontrato;
                    this.CBTipodecontrato.SelectedValue = Contrato_SQL;

                    //Panel Datos Basicos
                    this.TBCodigo.Text = Codigo;
                    this.TBEmpleado.Text = Empleado;
                    this.TBDocumento.Text = Documento;
                    this.TBProfesion.Text = Profesion;
                    this.TBCargo.Text = Cargo;
                    this.TBCorreo.Text = Email;

                    //Datos de Envio Domiciliario
                    this.TBPais_Dom.Text = Pais_Dom;
                    this.TBCiudad_Dom.Text = Ciudad_Dom;
                    this.TBFijo_Dom.Text = Fijo_Dom;
                    this.TBExtension_Dom.Text = Extension_Dom;
                    this.TBMovil_Dom.Text = Movil_Dom;
                    this.TBDireccion_Dom.Text = Direccion_Dom;

                    //Datos de Envio Empresarial
                    this.TBPais_Emp.Text = Pais_Emp;
                    this.TBCiudad_Emp.Text = Ciudad_Emp;
                    this.TBFijo_Emp.Text = Fijo_Emp;
                    this.TBExtension_Emp.Text = Extension_Emp;
                    this.TBMovil_Emp.Text = Movil_Emp;
                    this.TBDireccion_Emp.Text = Direccion_Emp;
                    
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBProfesion.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCiudad_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFijo_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExtension_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBPais_Dom.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCargo.Select();
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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                //Clases y Focus
                                this.Guardar_SQL();
                            }
                            else
                            {
                                                            MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

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
