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
    public partial class frmProveedor : Form
    {
        private static frmProveedor _Instancia;

        public static frmProveedor GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmProveedor();
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
        private string Numerico = "Campo Numerico - Leal Enterprise";

        //Variables para Eliminar y ejecutar los procedimientos Internos en los paneles
        //Datos Bancarios, Datos de Envio ETC donde se realizan multiplex registros
        private bool Eliminar_Banco = false;
        private bool Eliminar_Envio = false;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle_Banco;
        private DataTable DtDetalle_Envio;

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        public string Idproveedor, Tipo, Proveedor, Documento, Representante, Telefono, Movil, Correo, Pais, Ciudad, Nacionalidad, FechaDeInicio = "";

        //********** Variables para la Validacion de las Transacciones en SQL **************************************************

        private string Tran_Banco, Tran_Envio = "";

        //***************************************************************************************

        public frmProveedor()
        {
            InitializeComponent();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.Combobox_Sucurzal();
            this.Diseño_TablasGenerales();
            this.CBTipo.SelectedIndex = 0;

            //Focus a Texboxt
            this.TBNombre.Select();

            //Ocultacion de Texboxt
            this.TBIdbanco.Visible = false;
            this.TBIdproveedor.Visible = false;
            this.DGResultados.Enabled = false;

            //Color para Texboxt Buscar
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos  
            //this.TBCodigo.Enabled = false;
            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNombre.ReadOnly = false;
            this.TBNombre.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNombre.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBNombre.Text = Campo;
            this.TBDocumento.ReadOnly = false;
            this.TBDocumento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDocumento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDocumento.Text = Campo;
            this.TBRepresentante.ReadOnly = false;
            this.TBRepresentante.BackColor = Color.FromArgb(3, 155, 229);
            this.TBRepresentante.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBRepresentante.Text = Campo;
            this.TBPais.ReadOnly = false;
            this.TBPais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCiudad.ReadOnly = false;
            this.TBCiudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNacionalidad.ReadOnly = false;
            this.TBNacionalidad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBTelefono.ReadOnly = false;
            this.TBTelefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMovil.ReadOnly = false;
            this.TBMovil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCorreo.ReadOnly = false;
            this.TBCorreo.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Datos de Envio
            this.TBEnv_Pais.ReadOnly = false;
            this.TBEnv_Pais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEnv_Ciudad.ReadOnly = false;
            this.TBEnv_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEnv_Direccion.ReadOnly = false;
            this.TBEnv_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBReceptor.ReadOnly = false;
            this.TBReceptor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEnv_Telefono.ReadOnly = false;
            this.TBEnv_Telefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEnv_Movil.ReadOnly = false;
            this.TBEnv_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEnv_Observacion.ReadOnly = false;
            this.TBEnv_Observacion.BackColor = Color.FromArgb(3, 155, 229);

            //Datos Bancarios
            this.TBBanco.Enabled = false;
            this.TBBanco.BackColor = Color.FromArgb(245, 245, 245);
            this.TBBanco_Documento.Enabled = false;
            this.TBBanco_Documento.BackColor = Color.FromArgb(245, 245, 245);
            this.TBCuenta01.ReadOnly = false;
            this.TBCuenta01.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBIdproveedor.Clear();
            this.TBCodigo.Clear();
            this.CBTipo.SelectedIndex = 0;
            this.TBNombre.Clear();
            this.TBNombre.Text = Campo;
            this.TBDocumento.Clear();
            this.TBDocumento.Text = Campo;
            this.TBRepresentante.Clear();
            this.TBRepresentante.Text = Campo;
            this.TBCiudad.Clear();
            this.TBTelefono.Clear();
            this.TBMovil.Clear();
            this.TBPais.Clear();
            this.TBNacionalidad.Clear();
            this.TBCorreo.Clear();

            //Panel - Datos de Envio
            this.TBEnv_Pais.Clear();
            this.TBEnv_Ciudad.Clear();
            this.TBEnv_Direccion.Clear();
            this.TBReceptor.Clear();
            this.TBEnv_Telefono.Clear();
            this.TBEnv_Movil.Clear();
            this.TBEnv_Observacion.Clear();


            //Datos Financieros
            this.TBCuenta01.Clear();
            this.TBBanco.Clear();
            this.TBBanco_Documento.Clear();

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
                this.DtDetalle_Envio = new DataTable();
                this.DtDetalle_Envio.Columns.Add("Idproveedor", System.Type.GetType("System.Int32"));
                this.DtDetalle_Envio.Columns.Add("Receptor", System.Type.GetType("System.String"));
                this.DtDetalle_Envio.Columns.Add("Pais", System.Type.GetType("System.String"));
                this.DtDetalle_Envio.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Envio.Columns.Add("Dirección", System.Type.GetType("System.String"));
                this.DtDetalle_Envio.Columns.Add("Telefono", System.Type.GetType("System.String"));
                this.DtDetalle_Envio.Columns.Add("Movil", System.Type.GetType("System.String"));
                this.DtDetalle_Envio.Columns.Add("Observación", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Envio.DataSource = DtDetalle_Envio;

                //Panel - Datos Bancarios
                this.DtDetalle_Banco = new DataTable();
                this.DtDetalle_Banco.Columns.Add("Idproveedor", System.Type.GetType("System.Int32"));
                this.DtDetalle_Banco.Columns.Add("Idbanco", System.Type.GetType("System.Int32"));
                this.DtDetalle_Banco.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle_Banco.Columns.Add("Banco", System.Type.GetType("System.String"));
                this.DtDetalle_Banco.Columns.Add("Tipo", System.Type.GetType("System.String"));
                this.DtDetalle_Banco.Columns.Add("Cuenta", System.Type.GetType("System.Int32"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Bancario.DataSource = this.DtDetalle_Banco;

                //Medidas de las Columnas - Codigo de Barra
                //this.DGDetalle_CodigoDeBarra.Columns[1].Width = 370;

                //Formato de Celdas
                //this.DGDetalles_Lotes.Columns[2].DefaultCellStyle.Format = "##,##0.00";

                //************************************* Alineacion de las Celdas *************************************

                //Panel Datos Bancarios
                this.DGDetalle_Bancario.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Bancario.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel - Datos de Envio
                this.DGDetalle_Envio.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Envio.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //************************************* Aliniacion de Emcabezados *************************************

                //Panel Datos Bancarios
                this.DGDetalle_Bancario.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Bancario.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel - Datos de Envio
                this.DGDetalle_Envio.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Envio.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //************************************* Ocultacion de Columnas *************************************
                this.DGDetalle_Envio.Columns[0].Visible = false;
                this.DGDetalle_Bancario.Columns[0].Visible = false;
                this.DGDetalle_Bancario.Columns[1].Visible = false;

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

                this.btnModificar_Envio.Enabled = false;
                this.btnModificar_Bancos.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;

                this.btnModificar_Envio.Enabled = true;
                this.btnModificar_Bancos.Enabled = true;
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

        public void setBanco(string idbanco, string documento, string banco)
        {
            this.TBIdbanco.Text = idbanco;
            this.TBBanco_Documento.Text = documento;
            this.TBBanco.Text = banco;
        }

        private void Validaciones_SQL()
        {
            if (DGDetalle_Envio.Rows.Count == 0)
            {
                this.Tran_Envio = "1";
            }
            else
            {
                this.Tran_Envio = "0";
            }

            if (DGDetalle_Bancario.Rows.Count == 0)
            {
                this.Tran_Banco = "1";
            }
            else
            {
                this.Tran_Banco = "0";
            }
        }

        private void Actualizar_DetBanco()
        {
            this.DGDetalle_Bancario.DataSource = fProveedor.Lista_Banco(5, Convert.ToInt32(TBIdproveedor.Text));
            this.lblTotal_Banco.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Bancario.Rows.Count);
        }

        private void Actualizar_DetEnvio()
        {
            this.DGDetalle_Envio.DataSource = fProveedor.Lista_Envio(5, Convert.ToInt32(TBIdproveedor.Text));
            this.lblTotal_Envio.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Envio.Rows.Count);
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

                if (this.TBNombre.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Proveedor a registrar");
                }
                else if (this.TBDocumento.Text == Campo)
                {
                    MensajeError("Ingrese el numero del Documento del Proveedor");
                }
                else if (this.TBRepresentante.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Representante del Proveedor a registrar");
                }
                else if (this.CBTipo.SelectedIndex == 0)
                {
                    MensajeError("Seleccione el Tipo de Proveedor");
                }
                else if (this.CBSucurzal.SelectedIndex == 0)
                {
                    MensajeError("Seleccione la Sucurzal a la Cual Pertenece el Proveedor");
                }

                else
                {

                    this.Validaciones_SQL();

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fProveedor.Guardar_DatosBasicos

                            (

                                //Datos Auxiliares y llave primaria
                                1,

                                //Panel Datos Basicos
                                this.CBTipo.Text, this.TBNombre.Text, this.TBDocumento.Text, this.TBRepresentante.Text, this.TBPais.Text,
                                this.TBCiudad.Text, this.TBNacionalidad.Text,this.TBTelefono.Text, this.TBMovil.Text, this.TBCorreo.Text, this.DTFechadeinicio.Value,

                                //Panel Datos De Envio
                                this.DtDetalle_Envio,

                                //Panel Datos Financieros
                                this.DtDetalle_Banco,

                                 //Variables Para Confirmar el Insertar en la Transaccion en SQL
                                 //Donde esten las Validaciones IF NOT
                                 1, 1,

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Envio), Convert.ToInt32(Tran_Banco)
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fProveedor.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y llave primaria
                                 2, Convert.ToInt32(this.TBIdproveedor.Text),

                                //Panel Datos Basicos
                                this.CBTipo.Text, this.TBNombre.Text, this.TBDocumento.Text, this.TBRepresentante.Text, this.TBPais.Text,
                                this.TBCiudad.Text, this.TBNacionalidad.Text, this.TBTelefono.Text, this.TBMovil.Text, this.TBCorreo.Text, this.DTFechadeinicio.Value,

                                //Panel Datos De Envio
                                this.DtDetalle_Envio,

                                //Panel Datos Financieros
                                this.DtDetalle_Banco,

                                 //Variables Para Confirmar el Insertar en la Transaccion en SQL
                                 //Donde esten las Validaciones IF NOT
                                 1, 1,

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Envio), Convert.ToInt32(Tran_Banco)
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("El Proveedor: “" + this.TBNombre.Text + "” a Sido Registrado Exitosamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro del Proveedor: “" + this.TBNombre.Text + "” a Sido Actualizado Exitosamente");
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
                            Eliminacion = Convert.ToInt32(DGResultados.CurrentRow.Cells["Codigo"].Value.ToString());
                            Respuesta = Negocio.fProveedor.Eliminar(Eliminacion, 0);
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

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fProveedor.Buscar(this.TBBuscar.Text, 1);
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


        private void TBIdproveedor_TextChanged(object sender, EventArgs e)
        {
            //SE REALIZA LA CONSULTA A LA BASE DE DATOS POR MEDIO DEL Idcliente
            //Y ASI AUTOCOMPLETAR LOS CAMPOS DE TEXTOS NECESARIOS O CONSULTADOS
            
            try
            {
                if (TBIdproveedor.Text != string.Empty)
                {
                    // ENVIAN LOS DATOS A LA BASE DE DATOS Y SE EVALUAN QUE EXISTEN O ESTEN REGISTRADOS

                    DataTable Datos = Negocio.fProveedor.Buscar(this.TBIdproveedor.Text, 2);
                    //Evaluamos si  existen los Datos
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros en la base de datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        //Panel Datos Basicos
                        Tipo = Datos.Rows[0][0].ToString();
                        Proveedor = Datos.Rows[0][1].ToString();
                        Documento = Datos.Rows[0][2].ToString();
                        Representante = Datos.Rows[0][3].ToString();
                        Pais = Datos.Rows[0][4].ToString();
                        Ciudad = Datos.Rows[0][5].ToString();
                        Nacionalidad = Datos.Rows[0][6].ToString();
                        Telefono = Datos.Rows[0][7].ToString();
                        Movil = Datos.Rows[0][8].ToString();
                        Correo = Datos.Rows[0][9].ToString();
                        FechaDeInicio = Datos.Rows[0][10].ToString();

                        //SE PROCEDE A LLENAR LOS CAMPOS DE TEXTO SEGUN LA CONSULTA REALIZADA

                        this.CBTipo.Text = Tipo;
                        this.TBNombre.Text = Proveedor;
                        this.TBDocumento.Text = Documento;
                        this.TBRepresentante.Text = Representante;
                        this.TBPais.Text = Pais;
                        this.TBCiudad.Text = Ciudad;
                        this.TBNacionalidad.Text = Nacionalidad;
                        this.TBTelefono.Text = Telefono;
                        this.TBMovil.Text = Movil;
                        this.TBCorreo.Text = Correo;
                        this.DTFechadeinicio.Text = FechaDeInicio;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBTipo.SelectedIndex != 0)
            {
                this.TBNombre.Select();
            }
        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Editar == "1")
                {
                    this.Digitar = false;
                    this.TBIdproveedor.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                    this.TBNombre.Select();

                    //
                    //this.Digitar = false;
                    this.Eliminar_Banco = true;
                    this.Eliminar_Envio = true;

                    //
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
        private void DGResultados_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.Digitar = false;

                    if (Editar == "1")
                    {
                        //
                        this.TBIdproveedor.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);
                        this.TBNombre.Select();

                        //Se procede Habilitar los campos de Textos y Botones
                        //cuando se le realice el evento Clip del Boton Ediatar/Guardar

                        this.btnGuardar.Enabled = true;
                        this.btnCancelar.Enabled = true;

                        //Se cambia la imagen del Boton la cual inicialmente es Guardar
                        //Y se cambiar por la imagen Editar
                        this.btnGuardar.Image = Properties.Resources.BV_Editar;
                    }
                    else
                    {
                        MessageBox.Show("Acceso denegado para actualizar registros", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //******************** PANEL DATOS BASICOS ********************

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

                    this.TBRepresentante.Select();
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

        private void TBRepresentante_KeyUp(object sender, KeyEventArgs e)
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
                            this.TBRepresentante.Select();
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
                            this.TBRepresentante.Select();
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

                    this.TBNacionalidad.Select();
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

        private void TBNacionalidad_KeyUp(object sender, KeyEventArgs e)
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
                            this.TBNacionalidad.Select();
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
                            this.TBNacionalidad.Select();
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

                    this.TBMovil.Select();
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

        private void TBMovil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCorreo.Select();
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

        private void TBCorreo_KeyUp(object sender, KeyEventArgs e)
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

        //******************** PANEL DATOS DE ENVIO ********************

        private void TBReceptor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEnv_Pais.Select();
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
                            this.TBReceptor.Select();
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
                            this.TBReceptor.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBPais_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEnv_Ciudad.Select();
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
                            this.TBEnv_Pais.Select();
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
                            this.TBEnv_Pais.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCiudad_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEnv_Direccion.Select();
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
                            this.TBEnv_Ciudad.Select();
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
                            this.TBEnv_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccionPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEnv_Telefono.Select();
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
                            this.TBEnv_Direccion.Select();
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
                            this.TBEnv_Direccion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBTelefono_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEnv_Movil.Select();
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
                            this.TBEnv_Telefono.Select();
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
                            this.TBEnv_Telefono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEnv_Observacion.Select();
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
                            this.TBEnv_Movil.Select();
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
                            this.TBEnv_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBObservacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBReceptor.Select();
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
                            this.TBEnv_Observacion.Select();
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
                            this.TBEnv_Observacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCuenta01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    //this.TBBancoAuxiliar.Select();
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
                            this.TBCuenta01.Select();
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
                            this.TBCuenta01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //******************** FOCUS ENTER  DATOS BASICOS ********************

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

        private void TBRepresentante_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBRepresentante.Text == Campo)
            {
                this.TBRepresentante.BackColor = Color.Azure;
                this.TBRepresentante.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBRepresentante.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBRepresentante.BackColor = Color.Azure;
            }
        }

        private void TBPais_Enter(object sender, EventArgs e)
        {
            this.TBPais.BackColor = Color.Azure;
        }

        private void TBCiudad_Enter(object sender, EventArgs e)
        {
            this.TBCiudad.BackColor = Color.Azure;
        }

        private void TBNacionalidad_Enter(object sender, EventArgs e)
        {
            this.TBNacionalidad.BackColor = Color.Azure;
        }

        private void TBTelefono_Enter(object sender, EventArgs e)
        {
            this.TBTelefono.BackColor = Color.Azure;
        }

        private void TBMovil_Enter(object sender, EventArgs e)
        {
            this.TBMovil.BackColor = Color.Azure;
        }

        private void TBCorreo_Enter(object sender, EventArgs e)
        {
            this.TBCorreo.BackColor = Color.Azure;
        }

        //******************** FOCUS ENTER  DATOS DE ENVIO ********************

        private void TBReceptor_Enter(object sender, EventArgs e)
        {
            this.TBReceptor.BackColor = Color.Azure;
        }

        private void TBPais_01_Enter(object sender, EventArgs e)
        {
            this.TBEnv_Pais.BackColor = Color.Azure;
        }

        private void TBCiudad_01_Enter(object sender, EventArgs e)
        {
            this.TBEnv_Ciudad.BackColor = Color.Azure;
        }

        private void btnExaminar_Proveedor_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            frmFiltro_Banco frmFiltro_Banco = new frmFiltro_Banco();
            frmFiltro_Banco.ShowDialog();
        }

        private void btnAgregar_Envio_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBReceptor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre del Receptor de Envíos");
                        this.TBReceptor.Select();
                    }
                    
                    else
                    {
                        bool agregar = true;
                        
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Envio.NewRow();
                            fila["Idproveedor"] = Convert.ToInt32(this.TBIdproveedor_AutoSQL.Text);
                            fila["Receptor"] = this.TBReceptor.Text;
                            fila["País"] = this.TBEnv_Pais.Text;
                            fila["Ciudad"] = this.TBEnv_Ciudad.Text;
                            fila["Dirección"] = this.TBEnv_Direccion.Text;
                            fila["Teléfono"] = this.TBEnv_Telefono.Text;
                            fila["Móvil"] = this.TBEnv_Movil.Text;
                            fila["Observación"] = this.TBEnv_Observacion.Text;
                            this.DtDetalle_Envio.Rows.Add(fila);
                        }

                        //
                        this.TBReceptor.Clear();
                        this.TBEnv_Ciudad.Clear();
                        this.TBEnv_Direccion.Clear();
                        this.TBEnv_Movil.Clear();
                        this.TBEnv_Observacion.Clear();
                        this.TBEnv_Pais.Clear();
                        this.TBEnv_Telefono.Clear();
                    }
                }
                else
                {
                    string rptaDatosBasicos = "";

                    // <<<<<<------ Panel Datos Basicos ------>>>>>

                    if (this.TBReceptor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre del Receptor de Envíos");
                        this.TBReceptor.Select();
                    }

                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Añadir los Datos de Envió al Proveedor?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProveedor.Guardar_Envio

                                (
                                     //Datos Auxiliares
                                     1,

                                     //Datos Basicos
                                     this.TBReceptor.Text, this.TBEnv_Pais.Text, this.TBEnv_Ciudad.Text, this.TBEnv_Direccion.Text, this.TBEnv_Telefono.Text, this.TBEnv_Movil.Text, this.TBEnv_Observacion.Text

                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos de Envio del Proveedor: " + this.TBNombre.Text + " A Sido Registrado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBReceptor.Clear();
                            this.TBEnv_Ciudad.Clear();
                            this.TBEnv_Direccion.Clear();
                            this.TBEnv_Movil.Clear();
                            this.TBEnv_Observacion.Clear();
                            this.TBEnv_Pais.Clear();
                            this.TBEnv_Telefono.Clear();
                        }
                        else
                        {
                            this.TBReceptor.Select();
                        }

                        //
                        this.Actualizar_DetEnvio();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Bancos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBBanco.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique Banco que Desea Agregar");
                        this.TBBanco.Select();
                    }
                    else if (this.TBBanco_Documento.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Identificación o Codigo del Banco");
                        this.TBBanco_Documento.Select();
                    }
                    else if (this.CBTipoDeCuenta.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor Especifique el Tipo de Cuenta Bancaria");
                        this.CBTipoDeCuenta.Select();
                    }
                    else if (this.TBCuenta01.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Número de Cuenta Bancaria que Desea Agregar");
                        this.TBCuenta01.Select();
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Banco.Rows)
                        {
                            if (Convert.ToString(Fila["Idbanco"]) == TBIdbanco.Text)
                            {
                                this.MensajeError("El Banco que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Banco.NewRow();
                            fila["Idproveedor"] = Convert.ToInt32(this.TBIdproveedor_AutoSQL.Text);
                            fila["Idbanco"] = Convert.ToInt32(this.TBIdbanco.Text);
                            fila["Codigo"] = this.TBBanco_Documento.Text;
                            fila["Banco"] = this.TBBanco.Text;
                            fila["Tipo"] = this.CBTipoDeCuenta.SelectedIndex == 0;
                            fila["Cuenta"] = this.TBCuenta01.Text;
                            this.DtDetalle_Banco.Rows.Add(fila);
                        }

                        //
                        this.TBIdbanco.Clear();
                        this.TBBanco_Documento.Clear();
                        this.TBBanco.Clear();
                        this.CBTipoDeCuenta.SelectedIndex = 0;
                        this.TBCuenta01.Clear();
                    }
                }
                else
                {
                    string rptaDatosBasicos = "";

                    // <<<<<<------ Panel Datos Basicos ------>>>>>

                    if (this.TBBanco.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique Banco que Desea Agregar");
                        this.TBBanco.Select();
                    }
                    else if (this.TBBanco_Documento.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Identificación o Codigo del Banco");
                        this.TBBanco_Documento.Select();
                    }
                    else if (this.CBTipoDeCuenta.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor Especifique el Tipo de Cuenta Bancaria");
                        this.CBTipoDeCuenta.Select();
                    }
                    else if (this.TBCuenta01.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Número de Cuenta Bancaria que Desea Agregar");
                        this.TBCuenta01.Select();
                    }

                    else
                    {
                        foreach (DataRow Fila in DtDetalle_Banco.Rows)
                        {
                            if (Convert.ToString(Fila["Idbanco"]) == TBIdbanco.Text)
                            {
                                this.MensajeError("El Banco que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Banco a la Lista del Proveedor?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProveedor.Guardar_Banco

                                (
                                    //Datos Auxiliares
                                    1,
                                     //Datos Basicos
                                     Convert.ToInt32(this.TBIdbanco.Text), this.CBTipoDeCuenta.Text, Convert.ToInt64(this.TBCuenta01.Text)
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Banco: " + this.TBBanco.Text + " del Proveedor: " + TBNombre.Text + " A Sido Registrado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdbanco.Clear();
                            this.TBBanco_Documento.Clear();
                            this.TBBanco.Clear();
                            this.CBTipoDeCuenta.SelectedIndex = 0;
                            this.TBCuenta01.Clear();
                        }
                        else
                        {
                            this.TBCuenta01.Select();
                        }

                        //
                        this.Actualizar_DetBanco();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBDireccionPrincipal_Enter(object sender, EventArgs e)
        {
            this.TBEnv_Direccion.BackColor = Color.Azure;
        }

        private void TBTelefono_01_Enter(object sender, EventArgs e)
        {
            this.TBEnv_Telefono.BackColor = Color.Azure;
        }

        private void TBMovil_01_Enter(object sender, EventArgs e)
        {
            this.TBEnv_Movil.BackColor = Color.Azure;
        }

        private void TBObservacion_Enter(object sender, EventArgs e)
        {
            this.TBEnv_Observacion.BackColor = Color.Azure;
        }

        //******************** FOCUS ENTER  DATOS FINANCIEROS ********************

        private void TBCuenta01_Enter(object sender, EventArgs e)
        {
            this.TBCuenta01.BackColor = Color.Azure;
        }

        //******************** FOCUS LEAVE DATOS BASICOS ********************
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
                TBNombre.BackColor = Color.FromArgb(3, 155, 229);
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

        private void btnModificar_Bancos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Digitar)
                {
                    string rptaDatosBasicos = "";

                    if (this.TBBanco.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique Banco que Desea Agregar");
                        this.TBBanco.Select();
                    }
                    else if (this.TBBanco_Documento.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Identificación o Codigo del Banco");
                        this.TBBanco_Documento.Select();
                    }
                    else if (this.CBTipoDeCuenta.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor Especifique el Tipo de Cuenta Bancaria");
                        this.CBTipoDeCuenta.Select();
                    }
                    else if (this.TBCuenta01.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Número de Cuenta Bancaria que Desea Agregar");
                        this.TBCuenta01.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Modificar el Registro Bancario del Proveedor?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProveedor.Editar_Banco

                                (
                                    //Datos Auxiliares
                                    1, Convert.ToInt32(TBIdproveedor.Text),
                                     //Datos Basicos
                                     Convert.ToInt32(this.TBIdbanco.Text), this.CBTipoDeCuenta.Text, Convert.ToInt64(this.TBCuenta01.Text)
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Registro del Banco: " + this.TBBanco.Text + " A Sido Modificado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdbanco.Clear();
                            this.TBBanco_Documento.Clear();
                            this.TBBanco.Clear();
                            this.CBTipoDeCuenta.SelectedIndex = 0;
                            this.TBCuenta01.Clear();
                        }
                        else
                        {
                            this.TBCuenta01.Select();
                        }

                        //
                        this.Actualizar_DetBanco();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Banco_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Banco)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idbanco;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Bancario.SelectedRows.Count > 0)
                            {
                                Idbanco = Convert.ToInt32(DGDetalle_Bancario.CurrentRow.Cells[0].Value.ToString());
                                Respuesta = Negocio.fProveedor.Eliminar_Banco(Idbanco, 1);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro Bancario Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetBanco();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Bancario.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Banco.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Banco.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la Ubicacion que desea Remover del registo");
            }
        }

        private void btnModificar_Envio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Digitar)
                {
                    string rptaDatosBasicos = "";

                    if (this.TBReceptor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre del Receptor de Envíos");
                        this.TBReceptor.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Modificar los Datos de Envió al Proveedor?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProveedor.Editar_Envio

                                (
                                     //Datos Auxiliares y Llave Primaria
                                     2, Convert.ToInt32(TBIdproveedor.Text),

                                     //Datos Basicos
                                     this.TBReceptor.Text, this.TBEnv_Pais.Text, this.TBEnv_Ciudad.Text, this.TBEnv_Direccion.Text, this.TBEnv_Telefono.Text, this.TBEnv_Movil.Text, this.TBEnv_Observacion.Text
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos de Envio del Proveedor: " + this.TBNombre.Text + " Han Sido Modificado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBReceptor.Clear();
                            this.TBEnv_Ciudad.Clear();
                            this.TBEnv_Direccion.Clear();
                            this.TBEnv_Movil.Clear();
                            this.TBEnv_Observacion.Clear();
                            this.TBEnv_Pais.Clear();
                            this.TBEnv_Telefono.Clear();
                        }
                        else
                        {
                            this.TBReceptor.Select();
                        }

                        //
                        this.Actualizar_DetEnvio();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Envio_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Envio)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idenvio;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Envio.SelectedRows.Count > 0)
                            {
                                Idenvio = Convert.ToInt32(DGDetalle_Envio.CurrentRow.Cells[0].Value.ToString());
                                Respuesta = Negocio.fProveedor.Eliminar_Envio(Idenvio, 1);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Ubicación Eliminada Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetEnvio();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Envio.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Envio.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Envio.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la Ubicacion que desea Remover del registo");
            }
        }

        private void TBRepresentante_Leave(object sender, EventArgs e)
        {
            if (TBRepresentante.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBRepresentante.BackColor = Color.FromArgb(3, 155, 229);
                this.TBRepresentante.Text = Campo;
                this.TBRepresentante.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBRepresentante.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBPais_Leave(object sender, EventArgs e)
        {
            this.TBPais.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCiudad_Leave(object sender, EventArgs e)
        {
            this.TBCiudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBNacionalidad_Leave(object sender, EventArgs e)
        {
            this.TBNacionalidad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBTelefono_Leave(object sender, EventArgs e)
        {
            this.TBTelefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_Leave(object sender, EventArgs e)
        {
            this.TBMovil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCorreo_Leave(object sender, EventArgs e)
        {
            this.TBCorreo.BackColor = Color.FromArgb(3, 155, 229);
        }

        //******************** FOCUS LEAVE DATOS DE ENVIO ********************
        private void TBReceptor_Leave(object sender, EventArgs e)
        {
            this.TBReceptor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBPais_01_Leave(object sender, EventArgs e)
        {
            this.TBEnv_Pais.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCiudad_01_Leave(object sender, EventArgs e)
        {
            this.TBEnv_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccionPrincipal_Leave(object sender, EventArgs e)
        {
            this.TBEnv_Direccion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBTelefono_01_Leave(object sender, EventArgs e)
        {
            this.TBEnv_Telefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_01_Leave(object sender, EventArgs e)
        {
            this.TBEnv_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBObservacion_Leave(object sender, EventArgs e)
        {
            this.TBEnv_Observacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        //******************** FOCUS LEAVE DATOS FINANCIEROS ********************

        private void TBCuenta01_Leave(object sender, EventArgs e)
        {
            this.TBCuenta01.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void frmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
