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
    public partial class frmBanco_Contacto : Form
    {
        private static frmBanco_Contacto _Instancia;

        public static frmBanco_Contacto GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmBanco_Contacto();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //Variables de Validaciones
        public int Idempleado; //Variable para Captura el Empleado Logueado
        private string Campo = "Campo Obligatorio";

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        private string Idcontacto, codigo, Banco, Asesor, Cargo, Ciudad, Telefono, Extension, Movil, Area, Observacion = "";

        public frmBanco_Contacto()
        {
            InitializeComponent();
        }

        private void frmBanco_Contacto_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();

            //Focus a Texboxt
            this.TBAsesor.Select();

            //Ocultacion de Texboxt
            this.TBIdbanco.Visible = false;
            this.TBIdcontacto.Visible = false;

            //Color para Texboxt Buscar
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }
        private void Habilitar()
        {
            //Panel - Datos Basicos
            this.TBCodigo_Banco.Enabled = false;
            this.TBCodigo_Banco.BackColor = Color.FromArgb(245, 245, 245);
            this.TBBanco.Enabled = false;
            this.TBBanco.BackColor = Color.FromArgb(245, 245, 245);

            //
            this.TBAsesor.ReadOnly = false;
            this.TBAsesor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBAsesor.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBAsesor.Text = Campo;
            this.TBCargo.ReadOnly = false;
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCargo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCargo.Text = Campo;
            this.TBCont_Ciudad.ReadOnly = false;
            this.TBCont_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCont_Ciudad.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCont_Ciudad.Text = Campo;
            this.TBCont_Telefono.ReadOnly = false;
            this.TBCont_Telefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCont_Extension.ReadOnly = false;
            this.TBCont_Extension.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCont_Movil.ReadOnly = false;
            this.TBCont_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCont_Area.ReadOnly = false;
            this.TBCont_Area.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCont_Observacion.ReadOnly = false;
            this.TBCont_Observacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBIdbanco.Clear();
            this.TBIdcontacto.Clear();
            this.TBCodigo_Banco.Clear();
            this.TBBanco.Clear();

            this.TBAsesor.Clear();
            this.TBAsesor.Text = Campo;
            this.TBAsesor.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCargo.Clear();
            this.TBCargo.Text = Campo;
            this.TBCargo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCont_Ciudad.Clear();
            this.TBCont_Ciudad.Text = Campo;
            this.TBCont_Ciudad.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCont_Telefono.Clear();
            this.TBCont_Extension.Clear();
            this.TBCont_Movil.Clear();
            this.TBCont_Area.Clear();
            this.TBCont_Observacion.Clear();

            //
            this.TBAsesor.Select();
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

        public void setBanco(string idbanco, string documento, string banco)
        {
            this.TBIdbanco.Text = idbanco;
            this.TBCodigo_Banco.Text = documento;
            this.TBBanco.Text = banco;
        }

        private void Validaciones_SQL()
        {
            //SI LOS CAMPOS NUMERICOS SE ENCUENTRAN VACIOS ESTOS SE LLENARAN CON CEROS
            if (TBCont_Telefono.Text == string.Empty)
            {
                this.TBCont_Telefono.Text = "0";
            }

            if (TBCont_Extension.Text == string.Empty)
            {
                this.TBCont_Extension.Text = "0";
            }

            if (TBCont_Movil.Text == string.Empty)
            {
                this.TBCont_Movil.Text = "0";
            }
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBAsesor.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre del Asesor.");
                    this.TBAsesor.Focus();
                }
                else if (this.TBCargo.Text == Campo)
                {
                    MensajeError("Ingrese el Cargo del Asesor a Registrar.");
                    this.TBCargo.Focus();
                }
                
                else
                {
                    //
                    this.Validaciones_SQL();

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fBanco.Guardar_Contacto

                            (

                                //Datos Auxiliares y llave primaria
                                1, Convert.ToInt32(this.TBIdbanco.Text),

                                //Panel Datos Basicos
                                this.TBAsesor.Text, this.TBCargo.Text, this.TBCont_Ciudad.Text, Convert.ToInt64(this.TBCont_Telefono.Text), Convert.ToInt64(this.TBCont_Extension.Text), Convert.ToInt64(this.TBCont_Movil.Text), this.TBCont_Area.Text, this.TBCont_Observacion.Text
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fBanco.Editar_Contacto

                            (
                                 //Datos Auxiliares y llave primaria
                                 2, Convert.ToInt32(this.TBIdcontacto.Text), Convert.ToInt32(this.TBIdcontacto.Text),

                                //Panel Datos Basicos
                                this.TBAsesor.Text, this.TBCargo.Text, this.TBCont_Ciudad.Text, Convert.ToInt64(this.TBCont_Telefono.Text), Convert.ToInt64(this.TBCont_Extension.Text), Convert.ToInt64(this.TBCont_Movil.Text), this.TBCont_Area.Text, this.TBCont_Observacion.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            //SE LIMPIAN LOS CAMPOS DE TEXTO NUMERICOS Y DESPUES LO GENERALES AL PRESIONAR OK EN LA INTERFAS
                            this.TBCont_Telefono.Clear();
                            this.TBCont_Extension.Clear();
                            this.TBCont_Movil.Clear();

                            this.MensajeOk("El Contacto Bancario: “" + this.TBAsesor.Text + "” a Sido Registrado Exitosamente");
                        }

                        else
                        {
                            //SE LIMPIAN LOS CAMPOS DE TEXTO NUMERICOS Y DESPUES LO GENERALES AL PRESIONAR OK EN LA INTERFAS
                            this.TBCont_Telefono.Clear();
                            this.TBCont_Extension.Clear();
                            this.TBCont_Movil.Clear();

                            this.MensajeOk("El Registro del Contacto Bancario: “" + this.TBAsesor.Text + "” a Sido Actualizado Exitosamente");
                        }

                        //Llamada de Clase
                        this.Digitar = true;
                        this.Botones();
                        this.Limpiar_Datos();
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }
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
                            Eliminacion = Convert.ToInt32(DGResultados.CurrentRow.Cells[0].Value.ToString());
                            Respuesta = Negocio.fBanco.Eliminar(Eliminacion, 0);
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
                        this.Digitar = true;
                        this.TBBuscar.Clear();
                        this.Botones();
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

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            frmFiltro_Banco frmFiltro_Banco = new frmFiltro_Banco();
            frmFiltro_Banco.ShowDialog();
        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Editar == "1")
                {
                    this.TBIdcontacto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                    this.TBAsesor.Select();

                    //
                    this.Digitar = false;
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
                    if (Editar == "1")
                    {
                        this.TBIdcontacto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                        this.TBAsesor.Focus();

                        //
                        this.Digitar = false;
                        this.Botones();
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

        private void TBIdcontacto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBIdcontacto.Text != string.Empty)
                {
                    DataTable Datos = Negocio.fBanco.Existencia_Contacto(Convert.ToInt32(this.TBIdcontacto.Text), 1);
                    //Evaluamos si  existen los Datos
                    if (Datos.Rows.Count == 0)
                    {
                        //MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Captura de Valores en la Base de Datos

                        //Panel Datos Basicos - Campos Obligatorios
                        Idcontacto = Datos.Rows[0][0].ToString();
                        codigo = Datos.Rows[0][1].ToString();
                        Banco = Datos.Rows[0][2].ToString();
                        Asesor = Datos.Rows[0][3].ToString();
                        Cargo = Datos.Rows[0][4].ToString();
                        Ciudad = Datos.Rows[0][5].ToString();

                        //Panel Datos Basicos - Campos NO Obligatorios
                        Telefono = Datos.Rows[0][6].ToString();
                        Extension = Datos.Rows[0][7].ToString();
                        Movil = Datos.Rows[0][8].ToString();
                        Area = Datos.Rows[0][9].ToString();
                        Observacion = Datos.Rows[0][10].ToString();

                        //Se procede a completar los campos de texto segun las consulta
                        //Realizada anteriormente en la base de datos

                        if (Telefono == "0")
                        {
                            this.TBCont_Telefono.Clear();
                        }
                        else
                        {
                            this.TBCont_Telefono.Text = Telefono;
                        }

                        if (Extension == "0")
                        {
                            this.TBCont_Extension.Clear();
                        }
                        else
                        {
                            this.TBCont_Extension.Text = Extension;
                        }

                        if (Movil == "0")
                        {
                            this.TBCont_Movil.Clear();
                        }
                        else
                        {
                            this.TBCont_Movil.Text = Movil;
                        }


                        //Panel Datos Basicos
                        this.TBCodigo_Banco.Text = codigo;
                        this.TBBanco.Text = Banco;
                        this.TBAsesor.Text = Asesor;
                        this.TBCargo.Text = Cargo;
                        this.TBCont_Ciudad.Text = Ciudad;
                        //this.TBCont_Telefono.Text = Direccion01;
                        //this.TBCont_Extension.Text = Direccion02;
                        //this.TBCont_Movil.Text = Direccion02;
                        this.TBCont_Area.Text = Area;
                        this.TBCont_Observacion.Text = Observacion;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fBanco.Buscar_Contacto(1, this.TBBuscar.Text);
                        this.DGResultados.Columns[1].Visible = false;

                        this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                        this.DGResultados.Enabled = true;
                    }
                    else
                    {
                        //this.Limpiar_Datos();

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
                    MessageBox.Show("El usuario iniciado no tiene permisos para realizar consultas en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBAsesor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCargo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBAsesor.Select();
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
                            this.TBAsesor.Select();
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

                    this.TBCont_Ciudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            //Llamada de Clase
                            this.Digitar = false;
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

        private void TBCont_Ciudad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCont_Telefono.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCont_Ciudad.Select();
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
                            this.TBCont_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCont_Telefono_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCont_Extension.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCont_Telefono.Select();
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
                            this.TBCont_Telefono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCont_Extension_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCont_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCont_Extension.Select();
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
                            this.TBCont_Extension.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCont_Movil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCont_Area.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCont_Movil.Select();
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
                            this.TBCont_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCont_Area_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCont_Observacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCont_Area.Select();
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
                            this.TBCont_Area.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCont_Observacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBAsesor.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();


                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCont_Observacion.Select();
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
                            this.TBCont_Observacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBAsesor_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBAsesor.Text == Campo)
            {
                this.TBAsesor.BackColor = Color.Azure;
                this.TBAsesor.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBAsesor.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBAsesor.BackColor = Color.Azure;
                this.TBAsesor.ForeColor = Color.FromArgb(0, 0, 0);
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
                this.TBCargo.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBCont_Ciudad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCont_Ciudad.Text == Campo)
            {
                this.TBCont_Ciudad.BackColor = Color.Azure;
                this.TBCont_Ciudad.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCont_Ciudad.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCont_Ciudad.BackColor = Color.Azure;
                this.TBCont_Ciudad.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBCont_Telefono_Enter(object sender, EventArgs e)
        {
            this.TBCont_Telefono.BackColor = Color.Azure;
        }

        private void TBCont_Extension_Enter(object sender, EventArgs e)
        {
            this.TBCont_Extension.BackColor = Color.Azure;
        }

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.Azure;
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCont_Movil_Enter(object sender, EventArgs e)
        {
            this.TBCont_Movil.BackColor = Color.Azure;
        }

        private void TBCont_Area_Enter(object sender, EventArgs e)
        {
            this.TBCont_Area.BackColor = Color.Azure;
        }

        private void TBCont_Observacion_Enter(object sender, EventArgs e)
        {
            this.TBCont_Observacion.BackColor = Color.Azure;
        }

        private void TBAsesor_Leave(object sender, EventArgs e)
        {
            if (TBAsesor.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBAsesor.BackColor = Color.FromArgb(3, 155, 229);
                this.TBAsesor.Text = Campo;
                this.TBAsesor.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBAsesor.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCargo_Leave(object sender, EventArgs e)
        {
            if (TBCargo.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCargo.Text = Campo;
                this.TBCargo.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCont_Ciudad_Leave(object sender, EventArgs e)
        {
            if (TBCont_Ciudad.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCont_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCont_Ciudad.Text = Campo;
                this.TBCont_Ciudad.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCont_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCont_Telefono_Leave(object sender, EventArgs e)
        {
            this.TBCont_Telefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCont_Extension_Leave(object sender, EventArgs e)
        {
            this.TBCont_Extension.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCont_Movil_Leave(object sender, EventArgs e)
        {
            this.TBCont_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCont_Area_Leave(object sender, EventArgs e)
        {
            this.TBCont_Area.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCont_Observacion_Leave(object sender, EventArgs e)
        {
            this.TBCont_Observacion.BackColor = Color.FromArgb(3, 155, 229);
        }
        private void frmBanco_Contacto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

    }
}
