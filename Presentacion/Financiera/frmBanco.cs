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
    public partial class frmBanco : Form
    {// Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //Variables de Validaciones
        public int Idempleado; //Variable para Captura el Empleado Logueado
        private string Campo = "Campo Obligatorio";

        //Variables para Eliminar y ejecutar los procedimientos Internos en los paneles
        //Datos de Contacto ETC donde se realizan multiplex registros
        private bool Eliminar_Contacto = false;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle_Contacto;

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Variables para la Validacion de las Transacciones en SQL **************************************************
        private string Tran_Contacto = "";

        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        private string Idbanco, Banco, Documento, Representante, Pais, Ciudad, Area, Direccion01, Direccion02, Telefono01, Telefon02, Movil01, Movil02, Extension01, Extension02, PaginaWEB = "";

        //Panel Datos de Contacto
        private string Cont_Asesor, Cont_Cargo, Cont_Ciudad, Cont_Telefono, Cont_Extension, Cont_Movil, Cont_Area, Cont_Observacion = "";

        //***************************************************************************************
        public frmBanco()
        {
            InitializeComponent();
        }

        private void frmBanco_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.Diseño_TablasGenerales();
            this.AutoIncrementable_SQL();

            //Focus a Texboxt
            this.TBNombre.Select();

            //Ocultacion de Texboxt
            this.TBIdbanco.Visible = false;
            this.TBIdbanco_AutoSQL.Visible = false;
            this.DGResultados.Enabled = false;

            //Color para Texboxt Buscar
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            this.TBNombre.ReadOnly = false;
            this.TBNombre.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNombre.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBNombre.Text = Campo;
            this.TBDocumento.ReadOnly = false;
            this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDocumento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDocumento.Text = Campo;
            this.TBPais.ReadOnly = false;
            this.TBPais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBPais.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBPais.Text = Campo;
            this.TBCiudad.ReadOnly = false;
            this.TBCiudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCiudad.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCiudad.Text = Campo;
            this.TBArea.ReadOnly = false;
            this.TBArea.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDireccion01.ReadOnly = false;
            this.TBDireccion01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDireccion02.ReadOnly = false;
            this.TBDireccion02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBTelefono.ReadOnly = false;
            this.TBTelefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBTelefono02.ReadOnly = false;
            this.TBTelefono02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExtension01.ReadOnly = false;
            this.TBExtension01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExtension02.ReadOnly = false;
            this.TBExtension02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMovil01.ReadOnly = false;
            this.TBMovil01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMovil02.ReadOnly = false;
            this.TBMovil02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBPaginaWEB.ReadOnly = false;
            this.TBPaginaWEB.BackColor = Color.FromArgb(3, 155, 229);

            //
            this.TBAsesor.ReadOnly = false;
            this.TBAsesor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCargo.ReadOnly = false;
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCont_Ciudad.ReadOnly = false;
            this.TBCont_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
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
            this.TBNombre.Clear();
            this.TBNombre.Text = Campo;
            this.TBNombre.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDocumento.Clear();
            this.TBDocumento.Text = Campo;
            this.TBDocumento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBPais.Clear();
            this.TBPais.Text = Campo;
            this.TBPais.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCiudad.Clear();
            this.TBCiudad.Text = Campo;
            this.TBCiudad.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBArea.Clear();
            this.TBDireccion01.Clear();
            this.TBDireccion02.Clear();
            this.TBPaginaWEB.Clear();

            //
            this.TBAsesor.Clear();
            this.TBCargo.Clear();
            this.TBCont_Ciudad.Clear();
            this.TBCont_Telefono.Clear();
            this.TBCont_Extension.Clear();
            this.TBCont_Movil.Clear();
            this.TBCont_Area.Clear();
            this.TBCont_Observacion.Clear();

            //se realiza la seleccion al campo de texto para asi este salte
            //al campo siguiente inicial el cual es TBNombre.Text
            this.TCPrincipal.SelectedIndex = 0;
            this.TBNombre.Select();
        }

        private void Diseño_TablasGenerales()
        {
            try
            {
                //Panel - Datos de Envio
                this.DtDetalle_Contacto = new DataTable();
                this.DtDetalle_Contacto.Columns.Add("Idbanco", System.Type.GetType("System.Int32"));
                this.DtDetalle_Contacto.Columns.Add("Asesor", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Cargo", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Telefono", System.Type.GetType("System.Int64"));
                this.DtDetalle_Contacto.Columns.Add("Extensión", System.Type.GetType("System.Int64"));
                this.DtDetalle_Contacto.Columns.Add("Movil", System.Type.GetType("System.Int64"));
                this.DtDetalle_Contacto.Columns.Add("Área", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Observación", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Contacto.DataSource = DtDetalle_Contacto;

                //Medidas de las Columnas - Codigo de Barra
                //this.DGDetalle_CodigoDeBarra.Columns[1].Width = 370;

                //Formato de Celdas
                //this.DGDetalles_Lotes.Columns[2].DefaultCellStyle.Format = "##,##0.00";

                //************************************* Alineacion de las Celdas *************************************

                //Panel Datos Bancarios
                this.DGDetalle_Contacto.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Contacto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Contacto.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //************************************* Aliniacion de Emcabezados *************************************

                //Panel Datos Bancarios
                this.DGDetalle_Contacto.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Contacto.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Contacto.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //************************************* Ocultacion de Columnas *************************************
                this.DGDetalle_Contacto.Columns[0].Visible = false;
                //this.DGDetalle_Bancario.Columns[0].Visible = false;
                //this.DGDetalle_Bancario.Columns[1].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void AutoIncrementable_SQL()
        {
            try
            {
                DataTable Datos = Negocio.fBanco.AutoComplementar_SQL(0);
                //Evaluamos si  existen los Datos

                if (Datos.Rows.Count == 0)
                {
                    TBIdbanco_AutoSQL.Text = "1";
                    //TBCodigoID.Text = "1";
                    //MessageBox.Show("No se Encontraron Registros en la Base de Datos", "Sistema Instituto Fundecar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    Idbanco = Datos.Rows[0][0].ToString();

                    //Se procede a completar los campos de texto segun las consulta realizada anteriormente en la base de datos
                    this.TBIdbanco_AutoSQL.Text = Idbanco;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;

                this.btnModificar_Banco.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;

                this.btnModificar_Banco.Enabled = true;
            }
        }

        private void Actualizar_DetContacto()
        {
            this.DGDetalle_Contacto.DataSource = fBanco.Lista_Contacto(6, Convert.ToInt32(TBIdbanco.Text)); ;
            this.lblTotal_Contacto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Contacto.Rows.Count);
        }

        private void Validaciones_SQL()
        {
            //Se valida el valor de los checbox que se encuentran en el panel de datos basicos
            //En el cual si este esta seleccionado su valor sera 1 y si no esta seleccionado este seria 0
            if (DGDetalle_Contacto.Rows.Count == 0)
            {
                this.Tran_Contacto = "1";
            }
            else
            {
                this.Tran_Contacto = "0";
            }

            //SI LOS CAMPOS NUMERICOS SE ENCUENTRAN VACIOS ESTOS SE LLENARAN CON CEROS
            if (TBTelefono.Text == string.Empty)
            {
                this.TBTelefono.Text = "0";
            }

            if (TBTelefono02.Text == string.Empty)
            {
                this.TBTelefono02.Text = "0";
            }

            if (TBMovil01.Text == string.Empty)
            {
                this.TBMovil01.Text = "0";
            }

            if (TBMovil02.Text == string.Empty)
            {
                this.TBMovil02.Text = "0";
            }

            if (TBExtension01.Text == string.Empty)
            {
                this.TBExtension01.Text = "0";
            }

            if (TBExtension02.Text == string.Empty)
            {
                this.TBExtension02.Text = "0";
            }

        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBNombre.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre del Banco a Registrar.");
                    this.TBNombre.Focus();
                }
                else if (this.TBDocumento.Text == Campo)
                {
                    MensajeError("Ingrese el numero de Identificación del Banco.");
                    this.TBDocumento.Focus();
                }
                else if (this.TBPais.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre del Pais de Origen de Banco.");
                    this.TBPais.Focus();
                }
                else if (this.TBCiudad.Text == Campo)
                {
                    MensajeError("Por Favor Ingrese la Ciudad a la Cual Pertenece el Banco o su Sucurzal.");
                    this.TBCiudad.Focus();
                }

                else
                {
                    //
                    this.Validaciones_SQL();

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fBanco.Guardar_DatosBasicos

                            (

                                //Datos Auxiliares y llave primaria
                                1,

                                //Panel Datos Basicos
                                this.TBNombre.Text, Convert.ToInt64(this.TBDocumento.Text), this.TBPais.Text, this.TBCiudad.Text, this.TBArea.Text, this.TBDireccion01.Text, this.TBDireccion02.Text, Convert.ToInt64(this.TBTelefono.Text), Convert.ToInt64(this.TBExtension01.Text), Convert.ToInt64(this.TBTelefono02.Text), Convert.ToInt64(this.TBExtension02.Text), Convert.ToInt64(this.TBMovil01.Text), Convert.ToInt64(this.TBMovil02.Text), this.TBPaginaWEB.Text,

                                 //Tabla de Detalles - Contacto
                                 this.DtDetalle_Contacto,

                                 //Variables Para Confirmar el Insertar en la Transaccion en SQL
                                 //Donde esten las Validaciones IF NOT
                                 1,

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Contacto)
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fBanco.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y llave primaria
                                 2, Convert.ToInt32(this.TBIdbanco.Text),

                                //Panel Datos Basicos
                                this.TBNombre.Text, Convert.ToInt64(this.TBDocumento.Text), this.TBPais.Text, this.TBCiudad.Text, this.TBArea.Text, this.TBDireccion01.Text, this.TBDireccion02.Text, Convert.ToInt64(this.TBTelefono.Text), Convert.ToInt64(this.TBExtension01.Text), Convert.ToInt64(this.TBTelefono02.Text), Convert.ToInt64(this.TBExtension02.Text), Convert.ToInt64(this.TBMovil01.Text), Convert.ToInt64(this.TBMovil02.Text), this.TBPaginaWEB.Text,

                                 //Tabla de Detalles - Contacto
                                 this.DtDetalle_Contacto,

                                 //Variables Para Confirmar el Insertar en la Transaccion en SQL
                                 //Donde esten las Validaciones IF NOT
                                 1,

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Contacto)
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        //SE LIMPIAN LOS CAMPOS DE TEXTO NUMERICOS Y DESPUES LO GENERALES AL PRESIONAR OK EN LA INTERFAS
                        this.TBTelefono.Clear();
                        this.TBTelefono02.Clear();
                        this.TBExtension01.Clear();
                        this.TBExtension02.Clear();
                        this.TBMovil01.Clear();
                        this.TBMovil02.Clear();

                        if (this.Digitar)
                        {
                            this.MensajeOk("El Banco: “" + this.TBNombre.Text + "” a Sido Registrado Exitosamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro del Banco: “" + this.TBNombre.Text + "” a Sido Actualizado Exitosamente");
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
                this.Diseño_TablasGenerales();

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

                        //Se regresa el focus al campo principal
                        this.TCPrincipal.SelectedIndex = 0;
                        this.TBNombre.Select();
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

        private void btnAgregar_Banco_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBAsesor.Text == string.Empty)
                    {
                        this.MensajeError("Por Favor Especifique el Nombre del Asesor del Banco.");
                        this.TBAsesor.Select();
                    }
                    else
                    {
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

                        DataRow fila = this.DtDetalle_Contacto.NewRow();
                        fila["Idbanco"] = Convert.ToInt32(this.TBIdbanco_AutoSQL.Text);
                        fila["Asesor"] = this.TBAsesor.Text;
                        fila["Cargo"] = this.TBCargo.Text;
                        fila["Ciudad"] = this.TBCont_Ciudad.Text;
                        fila["Telefono"] = Convert.ToInt64(this.TBCont_Telefono.Text);
                        fila["Extensión"] = Convert.ToInt64(this.TBCont_Extension.Text);
                        fila["Movil"] = Convert.ToInt64(this.TBCont_Movil.Text);
                        fila["Área"] = this.TBCont_Area.Text;
                        fila["Observación"] = this.TBCont_Observacion.Text;
                        this.DtDetalle_Contacto.Rows.Add(fila);

                        this.lblTotal_Contacto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Contacto.Rows.Count);

                        //
                        this.TBAsesor.Clear();
                        this.TBCargo.Clear();
                        this.TBCont_Ciudad.Clear();
                        this.TBCont_Telefono.Clear();
                        this.TBCont_Extension.Clear();
                        this.TBCont_Movil.Clear();
                        this.TBCont_Area.Clear();
                        this.TBCont_Observacion.Clear();
                    }
                }
                else
                {
                    if (this.TBAsesor.Text == String.Empty)
                    {
                        this.MensajeError("Por Favor Especifique el Nombre del Asesor del Banco.");
                        this.TBAsesor.Select();
                    }
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
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar la Ubicacion del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fBanco.Guardar_Contacto

                                    (
                                        //Datos Auxiliares
                                        1, Convert.ToInt32(TBIdbanco.Text),

                                        //Datos Basicos
                                        this.TBAsesor.Text, this.TBCargo.Text, this.TBCont_Ciudad.Text, Convert.ToInt64(this.TBCont_Telefono.Text), Convert.ToInt64(this.TBCont_Extension.Text), Convert.ToInt64(this.TBCont_Movil.Text), this.TBCont_Area.Text, this.TBCont_Observacion.Text
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Contacto: " + TBAsesor.Text + " del Banco: " + this.TBNombre.Text + " a Sido Registrado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBAsesor.Clear();
                            this.TBCargo.Clear();
                            this.TBCont_Ciudad.Clear();
                            this.TBCont_Telefono.Clear();
                            this.TBCont_Extension.Clear();
                            this.TBCont_Movil.Clear();
                            this.TBCont_Area.Clear();
                            this.TBCont_Observacion.Clear();

                            this.Actualizar_DetContacto();
                        }
                        else
                        {
                            this.TBAsesor.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Banco_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                rptaDatosBasicos = fBanco.Editar_Contacto

                            (
                                 //Datos Auxiliares
                                 2, Convert.ToInt32(this.TBIdbanco.Text),

                                 //Panel Datos Basicos
                                 this.TBAsesor.Text, this.TBCargo.Text, this.TBCont_Ciudad.Text, Convert.ToInt64(this.TBCont_Telefono.Text), Convert.ToInt64(this.TBCont_Extension.Text), Convert.ToInt64(this.TBCont_Movil.Text), this.TBCont_Area.Text, this.TBCont_Observacion.Text
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("Los Datos de Contacto del Banco: “" + this.TBNombre.Text + "” a Sido Actualizada Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    this.TBAsesor.Clear();
                    this.TBCargo.Clear();
                    this.TBCont_Ciudad.Clear();
                    this.TBCont_Telefono.Clear();
                    this.TBCont_Extension.Clear();
                    this.TBCont_Movil.Clear();
                    this.TBCont_Area.Clear();
                    this.TBCont_Observacion.Clear();

                    this.Actualizar_DetContacto();
                }

                else
                {
                    this.MensajeError(rptaDatosBasicos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Banco_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Contacto)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idbanco, Idubicacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Contacto.SelectedRows.Count > 0)
                            {
                                Idbanco = Convert.ToInt32(DGDetalle_Contacto.CurrentRow.Cells[0].Value.ToString());
                                Respuesta = Negocio.fBanco.Eliminar_Contacto(Idbanco, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Contacto Bancario Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetContacto();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Contacto.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Contacto.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Contacto.Rows.Remove(row);
                    this.lblTotal_Contacto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Contacto.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por Favor Seleccione el Contacto que Desea Remover del Registo");
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
                        this.DGResultados.DataSource = fBanco.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultados.Columns[1].Visible = false;

                        lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                        this.DGResultados.Enabled = true;
                    }
                    else
                    {
                        this.Limpiar_Datos();

                        //Se Limpian las Filas y Columnas de la tabla
                        DGResultados.DataSource = null;
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

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Editar == "1")
                {
                    this.TBIdbanco.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                    this.TBNombre.Focus();

                    //
                    this.Eliminar_Contacto = true;

                    //
                    this.Digitar = false;
                    this.Botones();
                    this.TCPrincipal.SelectedIndex = 0;
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
                        this.TBIdbanco.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                        this.TBNombre.Focus();

                        //
                        this.Eliminar_Contacto = true;

                        //
                        this.Digitar = false;
                        this.Botones();
                        this.TCPrincipal.SelectedIndex = 0;
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

        private void TBBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Tab))
                {
                    this.DGResultados.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void TBCiudad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCiudad.Text == Campo)
            {
                this.TBCiudad.BackColor = Color.Azure;
                this.TBCiudad.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCiudad.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCiudad.BackColor = Color.Azure;
                this.TBCiudad.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBPais_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBPais.Text == Campo)
            {
                this.TBPais.BackColor = Color.Azure;
                this.TBPais.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBPais.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBPais.BackColor = Color.Azure;
                this.TBPais.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBAsesor_Enter(object sender, EventArgs e)
        {
            this.TBAsesor.BackColor = Color.Azure;
        }

        private void TBCargo_Enter(object sender, EventArgs e)
        {
            this.TBCargo.BackColor = Color.Azure;
        }

        private void TBCont_Ciudad_Enter(object sender, EventArgs e)
        {
            this.TBCont_Ciudad.BackColor = Color.Azure;
        }

        private void TBCont_Telefono_Enter(object sender, EventArgs e)
        {
            this.TBCont_Telefono.BackColor = Color.Azure;
        }

        private void TBCont_Extension_Enter(object sender, EventArgs e)
        {
            this.TBCont_Extension.BackColor = Color.Azure;
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
            this.TBAsesor.BackColor = Color.FromArgb(3, 155, 229);
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
                this.TBDocumento.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBNombre_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBNombre.Text == Campo)
            {
                this.TBNombre.BackColor = Color.Azure;
                this.TBNombre.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBNombre.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBNombre.BackColor = Color.Azure;
                this.TBNombre.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBArea_Enter(object sender, EventArgs e)
        {
            this.TBArea.BackColor = Color.Azure;
        }

        private void TBDireccion01_Enter(object sender, EventArgs e)
        {
            this.TBDireccion01.BackColor = Color.Azure;
        }

        private void TBDireccion02_Enter(object sender, EventArgs e)
        {
            this.TBDireccion02.BackColor = Color.Azure;
        }

        private void TBTelefono_Enter(object sender, EventArgs e)
        {
            this.TBTelefono.BackColor = Color.Azure;
        }

        private void TBTelefono02_Enter(object sender, EventArgs e)
        {
            this.TBTelefono02.BackColor = Color.Azure;
        }

        private void TBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDocumento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBNombre.Select();
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
                            this.TBNombre.Select();
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
                    this.TBPais.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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

        private void TBPais_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBCiudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBPais.Select();
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
                            this.TBPais.Select();
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
                    this.TBArea.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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

        private void TBArea_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBDireccion01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBArea.Select();
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
                            this.TBArea.Select();
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
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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

        private void TBDireccion02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBTelefono.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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

        private void TBTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBExtension01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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

        private void TBExtension01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBTelefono02.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBExtension01.Select();
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
                            this.TBExtension01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBTelefono02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBExtension02.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBTelefono02.Select();
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
                            this.TBTelefono02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExtension02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBMovil01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBExtension02.Select();
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
                            this.TBExtension02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBMovil02.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBMovil01.Select();
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
                            this.TBMovil01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBPaginaWEB.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBMovil02.Select();
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
                            this.TBMovil02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBPaginaWEB_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBNombre.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                    this.Diseño_TablasGenerales();

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
                            this.TBPaginaWEB.Select();
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
                            this.TBPaginaWEB.Select();
                        }
                    }
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
                    this.Diseño_TablasGenerales();

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
                    this.Diseño_TablasGenerales();

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
                    this.Diseño_TablasGenerales();

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
                    this.Diseño_TablasGenerales();

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
                    this.Diseño_TablasGenerales();

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
                    this.Diseño_TablasGenerales();

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
                    this.Diseño_TablasGenerales();

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
                    this.Diseño_TablasGenerales();

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

        private void frmBanco_Activated(object sender, EventArgs e)
        {
            this.TBNombre.Focus();
        }

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.Azure;
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBIdbanco_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBIdbanco_AutoSQL_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBExtension01_Enter(object sender, EventArgs e)
        {
            this.TBExtension01.BackColor = Color.Azure;
        }

        private void TBExtension02_Enter(object sender, EventArgs e)
        {
            this.TBExtension02.BackColor = Color.Azure;
        }

        private void TBMovil01_Enter(object sender, EventArgs e)
        {
            this.TBMovil01.BackColor = Color.Azure;
        }

        private void TBMovil02_Enter(object sender, EventArgs e)
        {
            this.TBMovil02.BackColor = Color.Azure;
        }

        private void TBPaginaWEB_Enter(object sender, EventArgs e)
        {
            this.TBPaginaWEB.BackColor = Color.Azure;
        }

        //***********************************************************************************
        private void TBNombre_Leave(object sender, EventArgs e)
        {
            if (TBNombre.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBNombre.BackColor = Color.FromArgb(3, 155, 229);
                this.TBNombre.Text = Campo;
                this.TBNombre.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBNombre.BackColor = Color.FromArgb(3, 155, 229);
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
                this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBPais_Leave(object sender, EventArgs e)
        {
            if (TBPais.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBPais.BackColor = Color.FromArgb(3, 155, 229);
                this.TBPais.Text = Campo;
                this.TBPais.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBPais.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCiudad_Leave(object sender, EventArgs e)
        {
            if (TBCiudad.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCiudad.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCiudad.Text = Campo;
                this.TBCiudad.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCiudad.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBArea_Leave(object sender, EventArgs e)
        {
            this.TBArea.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion01_Leave(object sender, EventArgs e)
        {
            this.TBDireccion01.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion02_Leave(object sender, EventArgs e)
        {
            this.TBDireccion02.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBTelefono_Leave(object sender, EventArgs e)
        {
            this.TBTelefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBExtension01_Leave(object sender, EventArgs e)
        {
            this.TBExtension01.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBTelefono02_Leave(object sender, EventArgs e)
        {
            this.TBTelefono02.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBExtension02_Leave(object sender, EventArgs e)
        {
            this.TBExtension02.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil01_Leave(object sender, EventArgs e)
        {
            this.TBMovil01.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil02_Leave(object sender, EventArgs e)
        {
            this.TBMovil02.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBPaginaWEB_Leave(object sender, EventArgs e)
        {
            this.TBPaginaWEB.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCargo_Leave(object sender, EventArgs e)
        {
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCont_Ciudad_Leave(object sender, EventArgs e)
        {
            this.TBCont_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
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
    }
}
