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
        private static frmDepartamento _Instancia;

        public static frmDepartamento GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmDepartamento();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *****************************************************************************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //Variables para AutoComplementar los Texboxt *******************************************************************************************************************************************************
        public string Idempleado, Empleado, Departamento, Descripcion, AreaPrincipal, AreaAuxiliar, Apertura = "";
        
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
            this.TBIdempleado.Visible = false;
            this.TBIddepartamento.Visible = false;
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            this.TBDepartamento.ReadOnly = false;
            this.TBDepartamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDepartamento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDepartamento.Text = Campo;
            this.TBDirector.Enabled = false;
            this.TBDirector.BackColor = Color.FromArgb(3, 155, 229);
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

        public void setEmpleado(string idempleado, string empleado)
        {
            this.TBIdempleado.Text = idempleado;
            this.TBDirector.Text = empleado;
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

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBDepartamento.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Departamento a registrar");
                }
                else if (this.TBDirector.Text == Campo)
                {
                    MensajeError("Ingrese el Empleado a Cargo del Departamento a Registrar");
                }

                else
                {
                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fGestion_Departameto.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 1,

                                 //Panel Datos Basicos
                                 this.TBDepartamento.Text, this.TBAreaPrincipal.Text, this.TBAreaAuxiliar.Text, this.dateTimePicker1.Value, this.TBDescripcion.Text
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fGestion_Departameto.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 2, Convert.ToInt32(TBIddepartamento.Text),

                                 //Panel Datos Basicos
                                 this.TBDepartamento.Text, this.TBAreaPrincipal.Text, this.TBAreaAuxiliar.Text, this.dateTimePicker1.Value, this.TBDescripcion.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("El Departamento: " + this.TBDepartamento.Text + " a Sido Registrado");
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
                            Respuesta = Negocio.fGestion_Departameto.Eliminar(Eliminacion, 0);
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
                        this.TBDepartamento.Select();
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
                        this.DGResultados.DataSource = fGestion_Departameto.Buscar(this.TBBuscar.Text, 1);
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
                    this.TBDepartamento.Select();
                    this.TBIddepartamento.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

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

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            frmFiltro_Empleado frmFiltro_Empleado = new frmFiltro_Empleado();
            frmFiltro_Empleado.ShowDialog();
        }

        private void TBDepartamento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDepartamento.Text == Campo)
            {
                this.TBDepartamento.BackColor = Color.Azure;
                this.TBDepartamento.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDepartamento.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDepartamento.BackColor = Color.Azure;
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

        private void TBDescripcion_Enter(object sender, EventArgs e)
        {
            this.TBDescripcion.BackColor = Color.Azure;
        }

        private void TBAreaPrincipal_Enter(object sender, EventArgs e)
        {
            this.TBAreaPrincipal.BackColor = Color.Azure;
        }

        private void TBAreaAuxiliar_Enter(object sender, EventArgs e)
        {
            this.TBAreaAuxiliar.BackColor = Color.Azure;
        }

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.Azure;
        }

        private void TBDepartamento_Leave(object sender, EventArgs e)
        {
            if (TBDepartamento.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDepartamento.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDepartamento.Text = Campo;
                this.TBDepartamento.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBDepartamento.BackColor = Color.FromArgb(3, 155, 229);
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
                this.TBDirector.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDescripcion_Leave(object sender, EventArgs e)
        {
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBAreaPrincipal_Leave(object sender, EventArgs e)
        {
            this.TBAreaPrincipal.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBAreaAuxiliar_Leave(object sender, EventArgs e)
        {
            this.TBAreaAuxiliar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDepartamento_KeyUp(object sender, KeyEventArgs e)
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
                            this.TBDepartamento.Select();
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
                            this.TBDepartamento.Select();
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

                    this.TBAreaPrincipal.Select();
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
                            this.TBDescripcion.Select();
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

        private void TBAreaPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBAreaAuxiliar.Select();
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
                            this.TBAreaPrincipal.Select();
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
                            this.TBAreaPrincipal.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBAreaAuxiliar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDepartamento.Select();
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
                            this.TBAreaAuxiliar.Select();
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
                            this.TBAreaAuxiliar.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmDepartamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void TBIddepartamento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fGestion_Departameto.Buscar(this.TBIddepartamento.Text, 4);

                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Llaves Primarias
                    Idempleado = Datos.Rows[0][0].ToString();
                    Empleado = Datos.Rows[0][1].ToString();
                    Departamento = Datos.Rows[0][2].ToString();

                    //Panel Datos Basicos
                    AreaPrincipal = Datos.Rows[0][3].ToString();
                    AreaAuxiliar = Datos.Rows[0][4].ToString();
                    Descripcion = Datos.Rows[0][5].ToString();
                    
                    //Se procede a completar los campos de texto segun las consulta
                    //Realizada anteriormente en la base de datos

                    //Panel Datos Basicos
                    this.TBIdempleado.Text = Idempleado;
                    this.TBDepartamento.Text = Departamento;
                    this.TBAreaPrincipal.Text = AreaPrincipal;
                    this.TBAreaAuxiliar.Text = AreaAuxiliar;
                    this.TBDescripcion.Text = Descripcion;
                    //this.dateTimePicker1.Value = Apertura.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
