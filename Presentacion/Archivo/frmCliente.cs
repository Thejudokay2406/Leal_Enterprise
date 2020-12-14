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
    public partial class frmCliente : Form
    {
        //Instancia para el Filtro de los Clientes 
        private static frmCliente _Instancia;

        public static frmCliente GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmCliente();
            }
            return _Instancia;
        }


        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";

        //Variables para Eliminar y ejecutar los procedimientos Internos en los paneles
        private bool Eliminar_Facturacion = false;
        private bool Eliminar_Credito = false;
        private bool Eliminar_Despacho = false;
        private bool Eliminar_Financiera = false;
        private bool Eliminar_Contacto = false;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle_Facturacion;
        private DataTable DtDetalle_Credito;
        private DataTable DtDetalle_Despacho;
        private DataTable DtDetalle_Financiera;
        private DataTable DtDetalle_Contacto;

        //********** Variables para la Validacion de los checkbox en el Pane Datos Basicos**************************************

        private string Checkbox_Contado, Checkbox_Efectivo, Checkbox_Debito, Checkbox_Credito = "";

        //********** Variables para la Validacion de las Transacciones en SQL **************************************************

        private string Tran_Facturacion, Tran_Credito, Tran_Despacho, Tran_Financiera, Tran_Contacto = "";

        //********** Variables para AutoComplementar Combobox y Chexboxt segun la Consulta en SQL ******************************

        private string Grupo_SQL, Tipo_SQL = "";

        // ******************************************* Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar ************************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        // ******************************************* Parametros para AutoCompletar los Texboxt *********************************************************

        //Panel Datos Basicos
        private string Idcliente, Idtipo, Idgrupo, Codigo, Cliente, Documento, Telefono, Movil, TelefonoAux, MovilAux, Correo, Pais, Ciudad, Departamento, Web, Direccion, Observacion, Efectivo, Credito, Debito, Contado = "";
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.Auto_Combobox();
            this.Diseño_TablasGenerales();
            this.AutoIncrementable_SQL();

            //Focus a Texboxt y Combobox
            this.TBDat_Nombre.Select();

            //Ocultacion de Texboxt
            this.TBIdcliente.Visible = false;
            this.TBIdbanco.Visible = false;
            this.TBIdempleado.Visible = false;
            this.TBIdcliente_AutoSQL.Visible = false;

            this.TBIdfacturacion.Visible = false;
            this.TBIdcredito.Visible = false;
            this.TBIdfinanciera.Visible = false;
            this.TBIddespacho.Visible = false;
            this.TBIdcontacto.Visible = false;

            //this.TBIdcliente_AutoSQL.Visible = false;
        }

        private void Habilitar()
        {
            //Datos Basicos
            this.CBTipo.Enabled = true;
            this.CBTipo.BackColor = Color.FromArgb(3, 155, 229);
            this.CBGrupo.Enabled = true;
            this.CBGrupo.BackColor = Color.FromArgb(3, 155, 229);

            this.TBDat_Codigo.ReadOnly = false;
            this.TBDat_Codigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Codigo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Codigo.Text = Campo;
            this.TBDat_Nombre.ReadOnly = false;
            this.TBDat_Nombre.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Nombre.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Nombre.Text = Campo;
            this.TBDat_Documento.ReadOnly = false;
            this.TBDat_Documento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Documento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Documento.Text = Campo;
            this.TBDat_Telefono.ReadOnly = false;
            this.TBDat_Telefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Movil.ReadOnly = false;
            this.TBDat_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_TelefonoAux.ReadOnly = false;
            this.TBDat_TelefonoAux.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_MovilAux.ReadOnly = false;
            this.TBDat_MovilAux.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Correo.ReadOnly = false;
            this.TBDat_Correo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Pais.ReadOnly = false;
            this.TBDat_Pais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Ciudad.ReadOnly = false;
            this.TBDat_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Departamento.ReadOnly = false;
            this.TBDat_Departamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_PaginaWeb.ReadOnly = false;
            this.TBDat_PaginaWeb.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Direccion.ReadOnly = false;
            this.TBDat_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Observacion.ReadOnly = false;
            this.TBDat_Observacion.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Envio
            this.TBDes_Sucurzal.ReadOnly = false;
            this.TBDes_Sucurzal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Pais.ReadOnly = false;
            this.TBDes_Pais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Ciudad.ReadOnly = false;
            this.TBDes_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Departamento.ReadOnly = false;
            this.TBDes_Departamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Receptor.ReadOnly = false;
            this.TBDes_Receptor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Barrio.ReadOnly = false;
            this.TBDes_Barrio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Apartamento.ReadOnly = false;
            this.TBDes_Apartamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Direccion.ReadOnly = false;
            this.TBDes_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Movil.ReadOnly = false;
            this.TBDes_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Observacion.ReadOnly = false;
            this.TBDes_Observacion.BackColor = Color.FromArgb(3, 155, 229);

            //Datos Financieros
            this.TBFin_CodigoBanco.Enabled = false;
            this.TBFin_CodigoBanco.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFin_Banco.Enabled = false;
            this.TBFin_Banco.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFin_NumCuenta.ReadOnly = false;
            this.TBFin_NumCuenta.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Creditos
            this.TBCre_Valor.ReadOnly = false;
            this.TBCre_Valor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_CuotaMeses.ReadOnly = false;
            this.TBCre_CuotaMeses.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_DiasDeProrroga.ReadOnly = false;
            this.TBCre_DiasDeProrroga.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_InteresMora.ReadOnly = false;
            this.TBCre_InteresMora.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_TasaAnual.ReadOnly = false;
            this.TBCre_TasaAnual.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_TasaMensual.ReadOnly = false;
            this.TBCre_TasaMensual.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Facturacion
            this.TBFac_Cliente.ReadOnly = false;
            this.TBFac_Cliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Asesor.Enabled = false;
            this.TBFac_Asesor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFac_DocumentoCliente.ReadOnly = false;
            this.TBFac_DocumentoCliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_CodigoAsesor.Enabled = false;
            this.TBFac_CodigoAsesor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFac_Movil.ReadOnly = false;
            this.TBFac_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Correo.ReadOnly = false;
            this.TBFac_Correo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Pais.ReadOnly = false;
            this.TBFac_Pais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Ciudad.ReadOnly = false;
            this.TBFac_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Departamento.ReadOnly = false;
            this.TBFac_Departamento.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Contacto
            this.TBCon_Contacto.ReadOnly = false;
            this.TBCon_Contacto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Ciudad.ReadOnly = false;
            this.TBCon_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Direccion.ReadOnly = false;
            this.TBCon_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Telefono.ReadOnly = false;
            this.TBCon_Telefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Movil.ReadOnly = false;
            this.TBCon_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Correo.ReadOnly = false;
            this.TBCon_Correo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Parentesco.ReadOnly = false;
            this.TBCon_Parentesco.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.CBTipo.SelectedIndex = 0;
            this.CBGrupo.SelectedIndex = 0;
            this.TBDat_Codigo.Clear();
            this.TBDat_Codigo.Text = Campo;
            this.TBDat_Codigo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Nombre.Clear();
            this.TBDat_Nombre.Text = Campo;
            this.TBDat_Nombre.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Documento.Clear();
            this.TBDat_Documento.Text = Campo;
            this.TBDat_Documento.ForeColor = Color.FromArgb(255, 255, 255);

            this.TBDat_Telefono.Clear();
            this.TBDat_Movil.Clear();
            this.TBDat_TelefonoAux.Clear();
            this.TBDat_MovilAux.Clear();
            this.TBDat_Correo.Clear();
            this.TBDat_Pais.Clear();
            this.TBDat_Ciudad.Clear();
            this.TBDat_Departamento.Clear();
            this.TBDat_PaginaWeb.Clear();
            this.TBDat_Direccion.Clear();
            this.TBDat_Observacion.Clear();

            this.CH_Contado.Checked = true;
            this.CH_Credito.Checked = true;
            this.CH_Efectivo.Checked = true;
            this.CH_Efectivo.Checked = true;

            //Datos de Envio
            this.TBDes_Sucurzal.Clear();
            this.TBDes_Pais.Clear();
            this.TBDes_Ciudad.Clear();
            this.TBDes_Departamento.Clear();
            this.TBDes_Receptor.Clear();
            this.TBDes_Barrio.Clear();
            this.TBDes_Apartamento.Clear();
            this.TBDes_Direccion.Clear();
            this.TBDes_Movil.Clear();
            this.TBDes_Observacion.Clear();

            //Datos Financieros
            this.TBFin_CodigoBanco.Clear();
            this.TBFin_Banco.Clear();
            this.TBFin_NumCuenta.Clear();
            this.CBFin_Cuenta.SelectedIndex = 0;

            //Datos de Creditos
            this.TBCre_Valor.Clear();
            this.TBCre_CuotaMeses.Clear();
            this.TBCre_DiasDeProrroga.Clear();
            this.TBCre_InteresMora.Clear();
            this.TBCre_TasaAnual.Clear();
            this.TBCre_TasaMensual.Clear();

            //Datos de Facturacion
            this.TBFac_Cliente.Clear();
            this.TBFac_Asesor.Clear();
            this.TBFac_DocumentoCliente.Clear();
            this.TBFac_CodigoAsesor.Clear();
            this.TBFac_Movil.Clear();
            this.TBFac_Correo.Clear();
            this.TBFac_Pais.Clear();
            this.TBFac_Ciudad.Clear();
            this.TBFac_Departamento.Clear();
            this.CH_Facturacion.Checked = false;

            //Datos de Contacto
            this.TBCon_Contacto.Clear();
            this.TBCon_Ciudad.Clear();
            this.TBCon_Direccion.Clear();
            this.TBCon_Telefono.Clear();
            this.TBCon_Movil.Clear();
            this.TBCon_Correo.Clear();
            this.TBCon_Parentesco.Clear();

            //Limpieza de Label que cuentan las columnas de los DataGriview
            this.lblTotal_Contacto.Text = "Datos Registrados: 0";
            this.lblTotal_Credito.Text = "Datos Registrados: 0";
            this.lblTotal_Despacho.Text = "Datos Registrados: 0";
            this.lblTotal_Facturacion.Text = "Datos Registrados: 0";
            this.lblTotal_Financiera.Text = "Datos Registrados: 0";

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TCPrincipal.SelectedIndex = 0;
            this.TBDat_Codigo.Select();

            //SE PROCEDE A LIMPIAR LAS TABLAS DE LOS MULTIPLEX PANELES
            this.Diseño_TablasGenerales();
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnModificar_Contacto.Enabled = false;
                this.btnModificar_Credito.Enabled = false;
                this.btnModificar_Despacho.Enabled = false;
                this.btnModificar_Facturacion.Enabled = false;
                this.btnModificar_Financiera.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";

                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnModificar_Contacto.Enabled = true;
                this.btnModificar_Credito.Enabled = true;
                this.btnModificar_Despacho.Enabled = true;
                this.btnModificar_Facturacion.Enabled = true;
                this.btnModificar_Financiera.Enabled = true;
            }
        }

        private void Auto_Combobox()
        {
            try
            {
                this.CBTipo.DataSource = fTipoDeCliente.Lista();
                this.CBTipo.ValueMember = "Codigo";
                this.CBTipo.DisplayMember = "Tipo";

                this.CBGrupo.DataSource = fGrupoDeProductoDeCliente.Lista();
                this.CBGrupo.ValueMember = "Codigo";
                this.CBGrupo.DisplayMember = "Grupo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void setEmpleado(string idempleado, string documento, string asesor)
        {
            this.TBIdempleado.Text = idempleado;
            this.TBFac_CodigoAsesor.Text = documento;
            this.TBFac_Asesor.Text = asesor;
        }

        private void Actualizar_DetFacturacion()
        {
            this.DGDetalle_Facturacion.DataSource = fCliente.Lista_Facturacion(1, Convert.ToInt32(TBIdcliente.Text));
            this.lblTotal_Facturacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Facturacion.Rows.Count);
        }

        private void Actualizar_DetCredito()
        {
            this.DGDetalle_Credito.DataSource = fCliente.Lista_Credito(1, Convert.ToInt32(TBIdcliente.Text));
            this.lblTotal_Credito.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Credito.Rows.Count);
        }
        private void Actualizar_DetDespacho()
        {
            this.DGDetalle_Despacho.DataSource = fCliente.Lista_Despacho(1, Convert.ToInt32(TBIdcliente.Text));
            this.lblTotal_Despacho.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Despacho.Rows.Count);
        }
        private void Actualizar_DetFinanciera()
        {
            this.DGDetalle_Financiera.DataSource = fCliente.Lista_Financiera(1, Convert.ToInt32(TBIdcliente.Text));
            this.lblTotal_Financiera.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Financiera.Rows.Count);
        }
        private void Actualizar_DetContacto()
        {
            this.DGDetalle_Contacto.DataSource = fCliente.Lista_Contacto(1, Convert.ToInt32(TBIdcliente.Text));
            this.lblTotal_Contacto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Contacto.Rows.Count);
        }
        private void Validaciones_SQL()
        {
            //Se valida el valor de los checbox que se encuentran en el panel de datos basicos
            //En el cual si este esta seleccionado su valor sera 1 y si no esta seleccionado este seria 0

            if (CH_Contado.Checked)
            {
                this.Checkbox_Contado = "1";
            }
            else
            {
                this.Checkbox_Contado = "0";
            }

            if (CH_Efectivo.Checked)
            {
                this.Checkbox_Efectivo = "1";
            }
            else
            {
                this.Checkbox_Efectivo = "0";
            }

            if (CH_Debito.Checked)
            {
                this.Checkbox_Debito = "1";
            }
            else
            {
                this.Checkbox_Debito = "0";
            }

            if (CH_Credito.Checked)
            {
                this.Checkbox_Credito = "1";
            }
            else
            {
                this.Checkbox_Credito = "0";
            }


            //********************************* TABLAS DE DETALLES ********************************* 

            if (DGDetalle_Facturacion.Rows.Count == 0)
            {
                this.Tran_Facturacion = "1";
            }
            else
            {
                this.Tran_Facturacion = "0";
            }

            if (DGDetalle_Credito.Rows.Count == 0)
            {
                this.Tran_Credito = "1";
            }
            else
            {
                this.Tran_Credito = "0";
            }

            if (DGDetalle_Despacho.Rows.Count == 0)
            {
                this.Tran_Despacho = "1";
            }
            else
            {
                this.Tran_Despacho = "0";
            }

            if (DGDetalle_Financiera.Rows.Count == 0)
            {
                this.Tran_Financiera = "1";
            }
            else
            {
                this.Tran_Financiera = "0";
            }

            if (DGDetalle_Contacto.Rows.Count == 0)
            {
                this.Tran_Contacto = "1";
            }
            else
            {
                this.Tran_Contacto = "0";
            }

            //********************************* CAMPOS NUMERICOS VACIOS ********************************* 
            if (TBDat_Telefono.Text == String.Empty)
            {
                this.TBDat_Telefono.Text = "0";
            }
            if (TBDat_TelefonoAux.Text == String.Empty)
            {
                this.TBDat_TelefonoAux.Text = "0";
            }
            if (TBDat_Movil.Text == String.Empty)
            {
                this.TBDat_Movil.Text = "0";
            }
            if (TBDat_MovilAux.Text == String.Empty)
            {
                this.TBDat_MovilAux.Text = "0";
            }

        }

        private void Diseño_TablasGenerales()
        {
            try
            {
                //Panel de Facturacion
                this.DtDetalle_Facturacion = new DataTable();
                this.DtDetalle_Facturacion.Columns.Add("Idcliente", System.Type.GetType("System.Int32"));
                this.DtDetalle_Facturacion.Columns.Add("Idempleado", System.Type.GetType("System.Int32"));
                this.DtDetalle_Facturacion.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Empleado", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Cliente", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Documento", System.Type.GetType("System.Int64"));
                this.DtDetalle_Facturacion.Columns.Add("Movil", System.Type.GetType("System.Int64"));
                this.DtDetalle_Facturacion.Columns.Add("País", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Departamento", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Correo", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Facturacion.DataSource = DtDetalle_Facturacion;

                //Panel de Credito
                this.DtDetalle_Credito = new DataTable();
                this.DtDetalle_Credito.Columns.Add("Idcliente", System.Type.GetType("System.Int32"));
                this.DtDetalle_Credito.Columns.Add("Valor", System.Type.GetType("System.String"));
                this.DtDetalle_Credito.Columns.Add("Cuota", System.Type.GetType("System.Int64"));
                this.DtDetalle_Credito.Columns.Add("T. Mensual", System.Type.GetType("System.Int64"));
                this.DtDetalle_Credito.Columns.Add("T. Anual", System.Type.GetType("System.Int64"));
                this.DtDetalle_Credito.Columns.Add("Solicitud", System.Type.GetType("System.DateTime"));
                this.DtDetalle_Credito.Columns.Add("Emisión", System.Type.GetType("System.DateTime"));
                this.DtDetalle_Credito.Columns.Add("Días", System.Type.GetType("System.Int64"));
                this.DtDetalle_Credito.Columns.Add("Mora", System.Type.GetType("System.Int64"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Credito.DataSource = this.DtDetalle_Credito;

                //Panel de Envio - Despacho
                this.DtDetalle_Despacho = new DataTable();
                this.DtDetalle_Despacho.Columns.Add("Idcliente", System.Type.GetType("System.Int32"));
                this.DtDetalle_Despacho.Columns.Add("Sucurzal", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("País", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Departamento", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Receptor", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Barrio", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Apartamento", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Móvil", System.Type.GetType("System.Int64"));
                this.DtDetalle_Despacho.Columns.Add("Dirección", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Observación", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Despacho.DataSource = this.DtDetalle_Despacho;

                //Panel Financiera
                this.DtDetalle_Financiera = new DataTable();
                this.DtDetalle_Financiera.Columns.Add("Idcliente", System.Type.GetType("System.Int32"));
                this.DtDetalle_Financiera.Columns.Add("Idbanco", System.Type.GetType("System.Int32"));
                this.DtDetalle_Financiera.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle_Financiera.Columns.Add("Banco", System.Type.GetType("System.String"));
                this.DtDetalle_Financiera.Columns.Add("Cuenta", System.Type.GetType("System.String"));
                this.DtDetalle_Financiera.Columns.Add("Nº. de Cuenta", System.Type.GetType("System.Int64"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Financiera.DataSource = this.DtDetalle_Financiera;

                //Panel Datos de Contacto
                this.DtDetalle_Contacto = new DataTable();
                this.DtDetalle_Contacto.Columns.Add("Idcliente", System.Type.GetType("System.Int32"));
                this.DtDetalle_Contacto.Columns.Add("Contacto", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Dirección", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Telefono", System.Type.GetType("System.Int64"));
                this.DtDetalle_Contacto.Columns.Add("Móvil", System.Type.GetType("System.Int64"));
                this.DtDetalle_Contacto.Columns.Add("Correo", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Parentesco", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Contacto.DataSource = this.DtDetalle_Contacto;

                //************************************* Ocultacion de Columnas *************************************
                this.DGDetalle_Facturacion.Columns[0].Visible = false;
                this.DGDetalle_Facturacion.Columns[1].Visible = false;

                this.DGDetalle_Credito.Columns[0].Visible = false;

                this.DGDetalle_Despacho.Columns[0].Visible = false;

                this.DGDetalle_Financiera.Columns[0].Visible = false;
                this.DGDetalle_Financiera.Columns[1].Visible = false;

                this.DGDetalle_Contacto.Columns[0].Visible = false;
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
                DataTable Datos = Negocio.fCliente.AutoComplementar_SQL(0);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se Encuentran Clientes Registrados en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.TBIdcliente_AutoSQL.Text = "1";
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    Idcliente = Datos.Rows[0][0].ToString();

                    //Se procede a completar los campos de texto segun las consulta realizada anteriormente en la base de datos
                    this.TBIdcliente_AutoSQL.Text = Idcliente;
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

                if (this.TBDat_Nombre.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Cliente a registrar");
                }
                else if (this.TBDat_Documento.Text == Campo)
                {
                    MensajeError("Ingrese el numero del Documento del Cliente");
                }
                else if (this.TBDat_Codigo.Text == Campo)
                {
                    MensajeError("Ingrese el Codigo del Cliente");
                }
                else if (this.CBTipo.SelectedIndex == 0)
                {
                    MensajeError("Seleccione el Tipo de Cliente");
                }

                else
                {
                    this.Validaciones_SQL();

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fCliente.Guardar_DatosBasicos
                            (

                                //Datos Auxiliares
                                Convert.ToInt32(1), Convert.ToInt32(this.CBTipo.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue),

                                //Panel Datos Basicos
                                this.TBDat_Codigo.Text, this.TBDat_Nombre.Text, Convert.ToInt64(this.TBDat_Documento.Text), Convert.ToInt64(this.TBDat_Telefono.Text), Convert.ToInt64(this.TBDat_Movil.Text), Convert.ToInt64(this.TBDat_TelefonoAux.Text), Convert.ToInt64(this.TBDat_MovilAux.Text), this.TBDat_Correo.Text, this.TBDat_Pais.Text, this.TBDat_Ciudad.Text, this.TBDat_Departamento.Text, this.TBDat_PaginaWeb.Text, this.TBDat_Direccion.Text, this.TBDat_Observacion.Text,

                                //Tabla de Detalles - Facturacion, Credito, Despacho, Datos Financieros, Contacto
                                this.DtDetalle_Facturacion, this.DtDetalle_Credito, this.DtDetalle_Despacho, this.DtDetalle_Financiera, this.DtDetalle_Contacto,

                                //Variables Para Confirmar el Insertar en la Transaccion en SQL
                                //Donde esten las Validaciones IF NOT
                                1, 1, 1, 1, 1,

                                //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                Convert.ToInt32(Tran_Facturacion), Convert.ToInt32(Tran_Credito), Convert.ToInt32(Tran_Despacho), Convert.ToInt32(Tran_Financiera), Convert.ToInt32(Tran_Contacto),

                                //
                                Convert.ToInt32(Checkbox_Efectivo), Convert.ToInt32(Checkbox_Debito), Convert.ToInt32(Checkbox_Credito), Convert.ToInt32(Checkbox_Contado)
                           );
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

                    this.TBDat_Telefono.Clear();
                    this.TBDat_Movil.Clear();
                    this.TBDat_TelefonoAux.Clear();
                    this.TBDat_MovilAux.Clear();

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("El Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Registrado(a) Exitosamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Actualizado(a) Exitosamente");
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
                this.TBIdcliente.Text = "0";

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

                    Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        if (DGResultados.SelectedRows.Count > 0)
                        {
                            Eliminacion = Convert.ToInt32(DGResultados.CurrentRow.Cells["Codigo"].Value.ToString());
                            Respuesta = Negocio.fCliente.Eliminar(Eliminacion, 0);
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
                        this.TBBuscar.Text = "";
                        this.Limpiar_Datos();
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

        private void btnExaminar_Asesor_Click(object sender, EventArgs e)
        {
            frmFiltro_Empleado frmFiltro_Empleado = new frmFiltro_Empleado();
            frmFiltro_Empleado.ShowDialog();
        }

        private void btnModificar_Facturacion_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                rptaDatosBasicos = fCliente.Editar_Facturacion

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.TBIdfacturacion.Text), Convert.ToInt32(this.TBIdcliente.Text), Convert.ToInt32(this.TBIdempleado.Text),

                                 //Panel Datos Basicos
                                 this.TBFac_Asesor.Text, this.TBFac_CodigoAsesor.Text, this.TBFac_Cliente.Text, Convert.ToInt64(this.TBFac_DocumentoCliente.Text), Convert.ToInt64(this.TBFac_Movil.Text), this.TBFac_Pais.Text, this.TBFac_Ciudad.Text, this.TBFac_Departamento.Text, this.TBFac_Correo.Text,

                                //SI ES IGUAL A 2 SE EDITARAN LOS REGISTROS EN LA BASE DE DATOS
                                2
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("El Registro de Facturación del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Actualizado Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    this.TBIdfacturacion.Clear();
                    this.TBFac_Cliente.Clear();
                    this.TBFac_Asesor.Clear();
                    this.TBFac_DocumentoCliente.Clear();
                    this.TBFac_CodigoAsesor.Clear();
                    this.TBFac_Movil.Clear();
                    this.TBFac_Correo.Clear();
                    this.TBFac_Pais.Clear();
                    this.TBFac_Ciudad.Clear();
                    this.TBFac_Departamento.Clear();
                    this.CH_Facturacion.Checked = false;

                    this.Actualizar_DetFacturacion();
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

        private void btnModificar_Credito_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                rptaDatosBasicos = fCliente.Editar_Credito

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.TBIdcredito.Text), Convert.ToInt32(this.TBIdcliente.Text),

                                 //Panel Datos Basicos
                                 Convert.ToDecimal(this.TBCre_Valor.Text), Convert.ToInt64(this.TBCre_CuotaMeses.Text), Convert.ToInt64(this.TBCre_TasaMensual.Text), Convert.ToInt64(this.TBCre_TasaAnual.Text), this.DTCre_Solicitud.Value, this.DTCre_Emision.Value, Convert.ToInt64(this.TBCre_DiasDeProrroga.Text), Convert.ToInt64(this.TBCre_InteresMora.Text),

                                //SI ES IGUAL A 2 SE EDITARAN LOS REGISTROS EN LA BASE DE DATOS
                                2
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("El Registro de Credito del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Actualizado Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    this.TBIdcredito.Clear();
                    this.TBCre_Valor.Clear();
                    this.TBCre_CuotaMeses.Clear();
                    this.TBCre_DiasDeProrroga.Clear();
                    this.TBCre_InteresMora.Clear();
                    this.TBCre_TasaMensual.Clear();

                    this.Actualizar_DetCredito();
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

        private void btnModificar_Despacho_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                rptaDatosBasicos = fCliente.Editar_Despacho

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.TBIddespacho.Text), Convert.ToInt32(this.TBIdcliente.Text),

                                 //Panel Datos Basicos
                                 this.TBDes_Sucurzal.Text, this.TBDes_Pais.Text, this.TBDes_Ciudad.Text, this.TBDes_Departamento.Text, this.TBDes_Receptor.Text, this.TBDes_Barrio.Text, this.TBDes_Apartamento.Text, Convert.ToInt64(this.TBDes_Movil.Text), this.TBDes_Direccion.Text, this.TBDes_Observacion.Text,

                                //SI ES IGUAL A 2 SE EDITARAN LOS REGISTROS EN LA BASE DE DATOS
                                2
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("El Registro de Despachos del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Actualizado Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    this.TBIddespacho.Clear();
                    this.TBDes_Sucurzal.Clear();
                    this.TBDes_Pais.Clear();
                    this.TBDes_Ciudad.Clear();
                    this.TBDes_Departamento.Clear();
                    this.TBDes_Receptor.Clear();
                    this.TBDes_Barrio.Clear();
                    this.TBDes_Apartamento.Clear();
                    this.TBDes_Direccion.Clear();
                    this.TBDes_Movil.Clear();
                    this.TBDes_Observacion.Clear();

                    this.Actualizar_DetDespacho();
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

        private void btnModificar_Financiera_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                rptaDatosBasicos = fCliente.Editar_Financiera

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.TBIdfinanciera.Text), Convert.ToInt32(this.TBIdcliente.Text), Convert.ToInt32(this.TBIdbanco.Text),

                                 //Panel Datos Basicos
                                 this.CBFin_Cuenta.Text, Convert.ToInt64(this.TBFin_NumCuenta.Text),

                                //SI ES IGUAL A 2 SE EDITARAN LOS REGISTROS EN LA BASE DE DATOS
                                2
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("El Registro Financiero del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Actualizado Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    this.TBIdfinanciera.Clear();
                    this.TBFin_CodigoBanco.Clear();
                    this.TBFin_Banco.Clear();
                    this.TBFin_NumCuenta.Clear();
                    this.CBFin_Cuenta.SelectedIndex = 0;

                    this.Actualizar_DetFinanciera();
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

        private void btnModificar_Contacto_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                rptaDatosBasicos = fCliente.Editar_Contacto

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.TBIdcontacto.Text), Convert.ToInt32(this.TBIdcliente.Text),

                                 //Panel Datos Basicos
                                 this.TBCon_Contacto.Text, this.TBCon_Ciudad.Text, this.TBCon_Direccion.Text, Convert.ToInt64(this.TBCon_Telefono.Text), Convert.ToInt64(this.TBCon_Movil.Text), this.TBCon_Correo.Text, this.TBCon_Parentesco.Text,

                                //SI ES IGUAL A 2 SE EDITARAN LOS REGISTROS EN LA BASE DE DATOS
                                2
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("El Registro de Contacto del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Actualizado Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    this.TBIdcontacto.Clear();
                    this.TBCon_Contacto.Clear();
                    this.TBCon_Ciudad.Clear();
                    this.TBCon_Direccion.Clear();
                    this.TBCon_Telefono.Clear();
                    this.TBCon_Movil.Clear();
                    this.TBCon_Correo.Clear();
                    this.TBCon_Parentesco.Clear();

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


        private void btnAgregar_Facturacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBFac_CodigoAsesor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor seleccione el Empleado a Cargo de la Facturación del Cliente. En caso de no tener alguno Cargar un Empleado de Tipo Contado");
                    }
                    else if (this.TBFac_DocumentoCliente.Text == String.Empty)
                    {
                        this.MensajeError("Por favor especifique la Identificación del Cliente");
                        this.TBFac_DocumentoCliente.Select();
                    }
                    else if (this.TBFac_Cliente.Text == String.Empty)
                    {
                        this.MensajeError("Por favor especifique el Nombre del Cliente");
                        this.TBFac_Cliente.Select();
                    }
                    else
                    {
                        DataRow fila = this.DtDetalle_Facturacion.NewRow();
                        fila["Idcliente"] = Convert.ToInt32(this.TBIdcliente_AutoSQL.Text);
                        fila["Idempleado"] = Convert.ToInt32(this.TBIdempleado.Text);
                        fila["Codigo"] = this.TBFac_CodigoAsesor.Text;
                        fila["Empleado"] = this.TBFac_Asesor.Text;
                        fila["Cliente"] = this.TBFac_Cliente.Text;
                        fila["Documento"] = Convert.ToInt64(this.TBFac_DocumentoCliente.Text);
                        fila["Movil"] = Convert.ToInt64(this.TBFac_Movil.Text);
                        fila["País"] = this.TBFac_Pais.Text;
                        fila["Ciudad"] = this.TBFac_Ciudad.Text;
                        fila["Departamento"] = this.TBFac_Departamento.Text;
                        fila["Correo"] = this.TBFac_Correo.Text;
                        this.DtDetalle_Facturacion.Rows.Add(fila);

                        //
                        this.TBIdfacturacion.Clear();
                        this.TBFac_Cliente.Clear();
                        this.TBFac_Asesor.Clear();
                        this.TBFac_DocumentoCliente.Clear();
                        this.TBFac_CodigoAsesor.Clear();
                        this.TBFac_Movil.Clear();
                        this.TBFac_Correo.Clear();
                        this.TBFac_Pais.Clear();
                        this.TBFac_Ciudad.Clear();
                        this.TBFac_Departamento.Clear();
                        this.CH_Facturacion.Checked = false;
                    }
                }
                else
                {
                    if (this.TBFac_CodigoAsesor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor seleccione el Empleado a Cargo de la Facturación del Cliente. En caso de no tener alguno Cargar un Empleado de Tipo Contado");
                    }
                    else if (this.TBFac_DocumentoCliente.Text == String.Empty)
                    {
                        this.MensajeError("Por favor especifique la Identificación del Cliente");
                        this.TBFac_DocumentoCliente.Select();
                    }
                    else if (this.TBFac_Cliente.Text == String.Empty)
                    {
                        this.MensajeError("Por favor especifique el Nombre del Cliente");
                        this.TBFac_Cliente.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Datos de Facturación del Cliente?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fCliente.Guardar_Facturacion

                                    (
                                         //Datos Basicos
                                         Convert.ToInt32(this.TBIdcliente.Text), Convert.ToInt32(this.TBIdempleado.Text), this.TBFac_Asesor.Text, this.TBFac_CodigoAsesor.Text, this.TBFac_Cliente.Text, Convert.ToInt64(this.TBFac_DocumentoCliente.Text), Convert.ToInt64(this.TBFac_Movil.Text), this.TBFac_Pais.Text, this.TBFac_Ciudad.Text, this.TBFac_Departamento.Text, this.TBFac_Correo.Text,

                                        //Datos Auxiliares
                                        1
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos de Facturacion del Cliente: " + TBDat_Nombre.Text + " han Sido Registrados Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdfacturacion.Clear();
                            this.TBFac_Cliente.Clear();
                            this.TBFac_Asesor.Clear();
                            this.TBFac_DocumentoCliente.Clear();
                            this.TBFac_CodigoAsesor.Clear();
                            this.TBFac_Movil.Clear();
                            this.TBFac_Correo.Clear();
                            this.TBFac_Pais.Clear();
                            this.TBFac_Ciudad.Clear();
                            this.TBFac_Departamento.Clear();
                            this.CH_Facturacion.Checked = false;

                            this.Actualizar_DetFacturacion();
                        }
                        else
                        {
                            this.TBFac_Cliente.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Credito_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBCre_Valor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Valor del Credito a Solicitar");
                        this.TBCre_Valor.Select();
                    }
                    else if (this.TBCre_CuotaMeses.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Numero de Cuotas en Meses");
                        this.TBCre_CuotaMeses.Select();
                    }
                    else if (this.TBCre_TasaMensual.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Porcentaje de Tasa Mensual a Manejar en el Credito a Solicitar");
                        this.TBCre_TasaMensual.Select();
                    }
                    else if (this.TBCre_TasaAnual.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Porcentaje de Tasa Anual a Manejar en el Credito a Solicitar");
                        this.TBCre_TasaAnual.Select();
                    }

                    else
                    {
                        if (TBCre_InteresMora.Text == String.Empty)
                        {
                            this.TBCre_InteresMora.Text = "0";
                        }
                        if (TBCre_DiasDeProrroga.Text == String.Empty)
                        {
                            this.TBCre_DiasDeProrroga.Text = "0";
                        }

                        DataRow fila = this.DtDetalle_Credito.NewRow();
                        fila["Idcliente"] = Convert.ToInt32(this.TBIdcliente_AutoSQL.Text);
                        fila["Valor"] = this.TBCre_Valor.Text;
                        fila["Cuota"] = Convert.ToInt64(this.TBCre_CuotaMeses.Text);
                        fila["T. Mensual"] = Convert.ToInt64(this.TBCre_TasaMensual.Text);
                        fila["T. Anual"] = Convert.ToInt64(this.TBCre_TasaMensual.Text);
                        fila["Solicitud"] = this.DTCre_Solicitud.Value.ToString("dd/MM/yyyy");
                        fila["Emisión"] = this.DTCre_Emision.Value.ToString("dd/MM/yyyy");
                        fila["Días"] = Convert.ToInt64(this.TBCre_DiasDeProrroga.Text);
                        fila["Mora"] = Convert.ToInt64(this.TBCre_InteresMora.Text);
                        this.DtDetalle_Credito.Rows.Add(fila);

                        //
                        this.TBIdcredito.Clear();
                        this.TBCre_Valor.Clear();
                        this.TBCre_CuotaMeses.Clear();
                        this.TBCre_DiasDeProrroga.Clear();
                        this.TBCre_InteresMora.Clear();
                        this.TBCre_TasaAnual.Clear();
                        this.TBCre_TasaMensual.Clear();
                    }
                }
                else
                {
                    if (this.TBCre_Valor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Valor del Credito a Solicitar");
                        this.TBCre_Valor.Select();
                    }
                    else if (this.TBCre_CuotaMeses.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Numero de Cuotas en Meses");
                        this.TBCre_CuotaMeses.Select();
                    }
                    else if (this.TBCre_TasaMensual.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Porcentaje de Tasa Mensual a Manejar en el Credito a Solicitar");
                        this.TBCre_TasaMensual.Select();
                    }
                    else if (this.TBCre_TasaAnual.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Porcentaje de Tasa Anual a Manejar en el Credito a Solicitar");
                        this.TBCre_TasaAnual.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Datos de Credito del Cliente?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fCliente.Guardar_Credito

                                    (
                                         //Datos Basicos
                                         Convert.ToInt32(this.TBIdcliente.Text), Convert.ToDecimal(this.TBCre_Valor.Text), Convert.ToInt64(this.TBCre_CuotaMeses.Text), Convert.ToInt64(this.TBCre_TasaMensual.Text), Convert.ToInt64(this.TBCre_TasaAnual.Text), this.DTCre_Solicitud.Value, this.DTCre_Emision.Value, Convert.ToInt64(this.TBCre_DiasDeProrroga.Text), Convert.ToInt64(this.TBCre_InteresMora.Text),

                                        //Datos Auxiliares
                                        1
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos de Credito del Cliente: " + TBDat_Nombre.Text + " han Sido Registrados Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdcredito.Clear();
                            this.TBCre_Valor.Clear();
                            this.TBCre_CuotaMeses.Clear();
                            this.TBCre_DiasDeProrroga.Clear();
                            this.TBCre_InteresMora.Clear();
                            this.TBCre_TasaMensual.Clear();

                            this.Actualizar_DetCredito();
                        }
                        else
                        {
                            this.TBCre_Valor.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Despacho_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBDes_Sucurzal.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre de la Sucurzal a Enviar");
                        this.TBDes_Sucurzal.Select();
                    }
                    else if (this.TBDes_Pais.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el País a Enviar");
                        this.TBDes_Pais.Select();
                    }
                    else if (this.TBDes_Ciudad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ciudad a Enviar");
                        this.TBDes_Ciudad.Select();
                    }
                    else if (this.TBDes_Receptor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre de la Persona que Recibe el Envio");
                        this.TBDes_Receptor.Select();
                    }
                    else if (this.TBDes_Barrio.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre del Barrio o Zona Urbana del Envio");
                        this.TBDes_Barrio.Select();
                    }
                    else if (this.TBDes_Ciudad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ciudad de Destino del Envio");
                        this.TBDes_Ciudad.Select();
                    }
                    else if (this.TBDes_Movil.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique un Número de Contacto");
                        this.TBDes_Movil.Select();
                    }
                    else
                    {

                        DataRow fila = this.DtDetalle_Despacho.NewRow();
                        fila["Idcliente"] = Convert.ToInt32(this.TBIdcliente_AutoSQL.Text);
                        fila["Sucurzal"] = this.TBDes_Sucurzal.Text;
                        fila["País"] = this.TBDes_Pais.Text;
                        fila["Ciudad"] = this.TBDes_Ciudad.Text;
                        fila["Departamento"] = this.TBDes_Departamento.Text;
                        fila["Receptor"] = this.TBDes_Receptor.Text;
                        fila["Barrio"] = this.TBDes_Barrio.Text;
                        fila["Apartamento"] = this.TBDes_Apartamento.Text;
                        fila["Móvil"] = Convert.ToInt64(this.TBDes_Movil.Text);
                        fila["Dirección"] = this.TBDes_Direccion.Text;
                        fila["Observación"] = this.TBDes_Observacion.Text;
                        this.DtDetalle_Despacho.Rows.Add(fila);

                        //
                        this.TBIddespacho.Clear();
                        this.TBDes_Sucurzal.Clear();
                        this.TBDes_Pais.Clear();
                        this.TBDes_Ciudad.Clear();
                        this.TBDes_Departamento.Clear();
                        this.TBDes_Receptor.Clear();
                        this.TBDes_Barrio.Clear();
                        this.TBDes_Apartamento.Clear();
                        this.TBDes_Direccion.Clear();
                        this.TBDes_Movil.Clear();
                        this.TBDes_Observacion.Clear();
                    }
                }
                else
                {
                    if (this.TBDes_Sucurzal.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre de la Sucurzal a Enviar");
                        this.TBDes_Sucurzal.Select();
                    }
                    else if (this.TBDes_Pais.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el País a Enviar");
                        this.TBDes_Pais.Select();
                    }
                    else if (this.TBDes_Ciudad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ciudad a Enviar");
                        this.TBDes_Ciudad.Select();
                    }
                    else if (this.TBDes_Receptor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre de la Persona que Recibe el Envio");
                        this.TBDes_Receptor.Select();
                    }
                    else if (this.TBDes_Barrio.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre del Barrio o Zona Urbana del Envio");
                        this.TBDes_Barrio.Select();
                    }
                    else if (this.TBDes_Ciudad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ciudad de Destino del Envio");
                        this.TBDes_Ciudad.Select();
                    }
                    else if (this.TBDes_Movil.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique un Número de Contacto");
                        this.TBDes_Movil.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Datos de Despacho del Cliente?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fCliente.Guardar_Despacho

                                    (
                                         //Datos Basicos
                                         Convert.ToInt32(this.TBIdcliente.Text), this.TBDes_Sucurzal.Text, this.TBDes_Pais.Text, this.TBDes_Ciudad.Text, this.TBDes_Departamento.Text, this.TBDes_Receptor.Text, this.TBDes_Barrio.Text, this.TBDes_Apartamento.Text, Convert.ToInt64(this.TBDes_Movil.Text), this.TBDes_Direccion.Text, this.TBDes_Observacion.Text,

                                        //Datos Auxiliares
                                        1
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos de Despacho del Cliente: " + TBDat_Nombre.Text + " han Sido Registrados Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIddespacho.Clear();
                            this.TBDes_Sucurzal.Clear();
                            this.TBDes_Pais.Clear();
                            this.TBDes_Ciudad.Clear();
                            this.TBDes_Departamento.Clear();
                            this.TBDes_Receptor.Clear();
                            this.TBDes_Barrio.Clear();
                            this.TBDes_Apartamento.Clear();
                            this.TBDes_Direccion.Clear();
                            this.TBDes_Movil.Clear();
                            this.TBDes_Observacion.Clear();

                            this.Actualizar_DetDespacho();
                        }
                        else
                        {
                            this.TBDes_Sucurzal.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Financiera_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBFin_CodigoBanco.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Banco o Entidad Financiera");
                        this.TBFin_CodigoBanco.Select();
                    }
                    else if (this.TBFin_Banco.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Banco o Entidad Financiera");
                        this.TBFin_Banco.Select();
                    }
                    else if (this.TBFin_NumCuenta.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Número de Cuenta Bancaria");
                        this.TBFin_NumCuenta.Select();
                    }

                    else
                    {

                        DataRow fila = this.DtDetalle_Financiera.NewRow();
                        fila["Idcliente"] = Convert.ToInt32(this.TBIdcliente.Text);
                        fila["Idbanco"] = this.TBFin_CodigoBanco.Text;
                        fila["Cuenta"] = this.CBFin_Cuenta.Text;
                        fila["Nº. de Cuenta"] = Convert.ToInt64(this.TBFin_NumCuenta.Text);
                        this.DtDetalle_Financiera.Rows.Add(fila);

                        //
                        this.TBIdfinanciera.Clear();
                        this.TBFin_CodigoBanco.Clear();
                        this.TBFin_Banco.Clear();
                        this.TBFin_NumCuenta.Clear();
                        this.CBFin_Cuenta.SelectedIndex = 0;
                    }
                }
                else
                {
                    if (this.TBFin_CodigoBanco.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Banco o Entidad Financiera");
                        this.TBFin_CodigoBanco.Select();
                    }
                    else if (this.TBFin_Banco.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Banco o Entidad Financiera");
                        this.TBFin_Banco.Select();
                    }
                    else if (this.TBFin_NumCuenta.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Número de Cuenta Bancaria");
                        this.TBFin_NumCuenta.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Datos Financieros del Cliente?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fCliente.Guardar_Financiera

                                    (
                                         //Datos Basicos
                                         Convert.ToInt32(this.TBIdcliente.Text), Convert.ToInt32(this.TBIdbanco.Text), this.CBFin_Cuenta.Text, Convert.ToInt64(this.TBFin_NumCuenta.Text),

                                        //Datos Auxiliares
                                        1
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos Financieros del Cliente: " + TBDat_Nombre.Text + " han Sido Registrados Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdfinanciera.Clear();
                            this.TBFin_CodigoBanco.Clear();
                            this.TBFin_Banco.Clear();
                            this.TBFin_NumCuenta.Clear();
                            this.CBFin_Cuenta.SelectedIndex = 0;

                            this.Actualizar_DetFinanciera();
                        }
                        else
                        {
                            this.TBFin_NumCuenta.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Contacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBCon_Contacto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre de la Persona de Contacto");
                        this.TBCon_Contacto.Select();
                    }
                    else if (this.TBCon_Ciudad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique una Ciudad de Contacto");
                        this.TBCon_Ciudad.Select();
                    }
                    else if (this.TBCon_Direccion.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique una Dirección de Contacto");
                        this.TBCon_Direccion.Select();
                    }
                    else if (this.TBCon_Movil.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique un Número Movil de Contacto");
                        this.TBCon_Movil.Select();
                    }

                    else
                    {

                        DataRow fila = this.DtDetalle_Contacto.NewRow();
                        fila["Idcliente"] = Convert.ToInt32(this.TBIdcliente_AutoSQL.Text);
                        fila["Contacto"] = this.TBCon_Contacto.Text;
                        fila["Ciudad"] = this.TBCon_Ciudad.Text;
                        fila["Dirección"] = this.TBCon_Direccion.Text;
                        fila["Telefono"] = Convert.ToInt64(this.TBCon_Telefono.Text);
                        fila["Móvil"] = Convert.ToInt64(this.TBCon_Movil.Text);
                        fila["Correo"] = this.TBCon_Correo.Text;
                        fila["Parentesco"] = this.TBCon_Parentesco.Text;
                        this.DtDetalle_Contacto.Rows.Add(fila);

                        //
                        this.TBIdcontacto.Clear();
                        this.TBCon_Contacto.Clear();
                        this.TBCon_Ciudad.Clear();
                        this.TBCon_Direccion.Clear();
                        this.TBCon_Telefono.Clear();
                        this.TBCon_Movil.Clear();
                        this.TBCon_Correo.Clear();
                        this.TBCon_Parentesco.Clear();
                    }
                }
                else
                {
                    if (this.TBCon_Contacto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre de la Persona de Contacto");
                        this.TBCon_Contacto.Select();
                    }
                    else if (this.TBCon_Ciudad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique una Ciudad de Contacto");
                        this.TBCon_Ciudad.Select();
                    }
                    else if (this.TBCon_Direccion.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique una Dirección de Contacto");
                        this.TBCon_Direccion.Select();
                    }
                    else if (this.TBCon_Telefono.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique un Número Telefónico de Contacto");
                        this.TBCon_Telefono.Select();
                    }

                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Datos de Despacho del Cliente?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fCliente.Guardar_Contacto

                                    (
                                         //Datos Basicos
                                         Convert.ToInt32(this.TBIdcliente.Text), this.TBCon_Contacto.Text, this.TBCon_Ciudad.Text, this.TBCon_Direccion.Text, Convert.ToInt64(this.TBCon_Telefono.Text), Convert.ToInt64(this.TBCon_Movil.Text), this.TBCon_Correo.Text, this.TBCon_Parentesco.Text,

                                        //Datos Auxiliares
                                        1
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos de Contacto del Cliente: " + TBDat_Nombre.Text + " han Sido Registrados Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdcontacto.Clear();
                            this.TBCon_Contacto.Clear();
                            this.TBCon_Ciudad.Clear();
                            this.TBCon_Direccion.Clear();
                            this.TBCon_Telefono.Clear();
                            this.TBCon_Movil.Clear();
                            this.TBCon_Correo.Clear();
                            this.TBCon_Parentesco.Clear();

                            this.Actualizar_DetContacto();
                        }
                        else
                        {
                            this.TBCon_Contacto.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Facturacion_Click(object sender, EventArgs e)
        {
            try
            {
                this.TBFac_Cliente.Clear();
                this.TBFac_Asesor.Clear();
                this.TBFac_DocumentoCliente.Clear();
                this.TBFac_CodigoAsesor.Clear();
                this.TBFac_Movil.Clear();
                this.TBFac_Correo.Clear();
                this.TBFac_Pais.Clear();
                this.TBFac_Ciudad.Clear();
                this.TBFac_Departamento.Clear();
                this.CH_Facturacion.Checked = false;

                this.TBFac_Cliente.Enabled = true;
                this.TBFac_Cliente.BackColor = Color.FromArgb(3, 155, 229);
                this.TBFac_DocumentoCliente.Enabled = true;
                this.TBFac_DocumentoCliente.BackColor = Color.FromArgb(3, 155, 229);
                this.TBFac_Movil.Enabled = true;
                this.TBFac_Movil.BackColor = Color.FromArgb(3, 155, 229);
                this.TBFac_Pais.Enabled = true;
                this.TBFac_Pais.BackColor = Color.FromArgb(3, 155, 229);
                this.TBFac_Ciudad.Enabled = true;
                this.TBFac_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
                this.TBFac_Departamento.Enabled = true;
                this.TBFac_Departamento.BackColor = Color.FromArgb(3, 155, 229);
                this.TBFac_Correo.Enabled = true;
                this.TBFac_Correo.BackColor = Color.FromArgb(3, 155, 229);

                //SE DEVUELVE EL FOCUS AL TEXBOXT PRINCIPAL
                this.TBFac_DocumentoCliente.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Credito_Click(object sender, EventArgs e)
        {
            try
            {
                this.TBCre_Valor.Clear();
                this.TBCre_CuotaMeses.Clear();
                this.TBCre_DiasDeProrroga.Clear();
                this.TBCre_InteresMora.Clear();
                this.TBCre_TasaAnual.Clear();
                this.TBCre_TasaMensual.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Despacho_Click(object sender, EventArgs e)
        {
            try
            {
                this.TBDes_Sucurzal.Clear();
                this.TBDes_Pais.Clear();
                this.TBDes_Ciudad.Clear();
                this.TBDes_Departamento.Clear();
                this.TBDes_Receptor.Clear();
                this.TBDes_Barrio.Clear();
                this.TBDes_Apartamento.Clear();
                this.TBDes_Direccion.Clear();
                this.TBDes_Movil.Clear();
                this.TBDes_Observacion.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Financiera_Click(object sender, EventArgs e)
        {
            try
            {
                this.TBFin_CodigoBanco.Clear();
                this.TBFin_Banco.Clear();
                this.TBFin_NumCuenta.Clear();
                this.CBFin_Cuenta.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Contacto_Click(object sender, EventArgs e)
        {
            try
            {
                this.TBCon_Contacto.Clear();
                this.TBCon_Ciudad.Clear();
                this.TBCon_Direccion.Clear();
                this.TBCon_Telefono.Clear();
                this.TBCon_Movil.Clear();
                this.TBCon_Correo.Clear();
                this.TBCon_Parentesco.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Facturacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Facturacion)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idcliente, Idfacturacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Facturacion.SelectedRows.Count > 0)
                            {
                                Idcliente = Convert.ToInt32(DGDetalle_Facturacion.CurrentRow.Cells["Idcliente"].Value.ToString());
                                Idfacturacion = Convert.ToInt32(DGDetalle_Facturacion.CurrentRow.Cells["Idfactura"].Value.ToString());
                                Respuesta = Negocio.fCliente.Eliminar_Facturacion(Idcliente, Idfacturacion, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("El Registro de Datos de Facturacion del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Eliminado");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetFacturacion();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Facturacion.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Facturacion.Rows[Fila];

                    //Se remueve la fila y se Selecciona el Texboxt Inicial
                    this.DtDetalle_Facturacion.Rows.Remove(row);
                    this.TBFac_DocumentoCliente.Select();
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione el Registro de Facturación que desea Remover");
            }
        }

        private void btnEliminar_Credito_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Credito)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idcliente, Idcredito;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Credito.SelectedRows.Count > 0)
                            {
                                Idcliente = Convert.ToInt32(DGDetalle_Credito.CurrentRow.Cells["Idcliente"].Value.ToString());
                                Idcredito = Convert.ToInt32(DGDetalle_Credito.CurrentRow.Cells["Idcredito"].Value.ToString());
                                Respuesta = Negocio.fCliente.Eliminar_Credito(Idcliente, Idcredito, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("El Registro de Credito del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Eliminado");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetCredito();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Credito.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Credito.Rows[Fila];

                    //Se remueve la fila y se Selecciona el Texboxt Inicial
                    this.DtDetalle_Credito.Rows.Remove(row);
                    this.TBCre_Valor.Select();
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la Solicitud de Credito que desea Remover");
            }
        }

        private void btnEliminar_Despacho_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Despacho)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idcliente, Iddespacho;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Despacho.SelectedRows.Count > 0)
                            {
                                Idcliente = Convert.ToInt32(DGDetalle_Despacho.CurrentRow.Cells["Idcliente"].Value.ToString());
                                Iddespacho = Convert.ToInt32(DGDetalle_Despacho.CurrentRow.Cells["Iddespacho"].Value.ToString());
                                Respuesta = Negocio.fCliente.Eliminar_Despacho(Idcliente, Iddespacho, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("El Registro de Despacho del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Eliminado");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetDespacho();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Despacho.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Despacho.Rows[Fila];

                    //Se remueve la fila y se Selecciona el Texboxt Inicial
                    this.DtDetalle_Despacho.Rows.Remove(row);
                    this.TBDes_Sucurzal.Select();
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione el Registro de Despacho que desea Remover");
            }
        }

        private void btnEliminar_Financiera_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Financiera)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idcliente, Idfinanciera;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Financiera.SelectedRows.Count > 0)
                            {
                                Idcliente = Convert.ToInt32(DGDetalle_Financiera.CurrentRow.Cells["Idcliente"].Value.ToString());
                                Idfinanciera = Convert.ToInt32(DGDetalle_Financiera.CurrentRow.Cells["Idfinanciera"].Value.ToString());
                                Respuesta = Negocio.fCliente.Eliminar_Financiera(Idcliente, Idfinanciera, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("El Registro de Datos de Financiera del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Eliminado");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetFinanciera();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Financiera.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Financiera.Rows[Fila];

                    //Se remueve la fila y se Selecciona el Texboxt Inicial
                    this.DtDetalle_Financiera.Rows.Remove(row);
                    this.TBFin_NumCuenta.Select();
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione el Registro de Financiera que desea Remover");
            }
        }

        private void btnEliminar_Contacto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Contacto)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idcliente, Idcontacto;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Contacto.SelectedRows.Count > 0)
                            {
                                Idcliente = Convert.ToInt32(DGDetalle_Contacto.CurrentRow.Cells["Idcliente"].Value.ToString());
                                Idcontacto = Convert.ToInt32(DGDetalle_Contacto.CurrentRow.Cells["Idcontacto"].Value.ToString());
                                Respuesta = Negocio.fCliente.Eliminar_Contacto(Idcliente, Idcontacto, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("El Registro de Datos de Contacto del Cliente: “" + this.TBDat_Nombre.Text + "” a Sido Eliminado");
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

                    //Se remueve la fila y se Selecciona el Texboxt Inicial
                    this.DtDetalle_Contacto.Rows.Remove(row);
                    this.TBCon_Contacto.Select();
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la Ubicacion que desea Remover del registo");
            }
        }

        private void TBIdcliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fCliente.Buscar(this.TBIdcliente.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos
                    //Idcliente = Datos.Rows[0][0].ToString();
                    Idtipo = Datos.Rows[0][1].ToString();
                    Idgrupo = Datos.Rows[0][2].ToString();
                    Codigo = Datos.Rows[0][3].ToString();
                    Documento = Datos.Rows[0][4].ToString();
                    Telefono = Datos.Rows[0][5].ToString();
                    Movil = Datos.Rows[0][6].ToString();
                    TelefonoAux = Datos.Rows[0][7].ToString();
                    MovilAux = Datos.Rows[0][8].ToString();
                    Correo = Datos.Rows[0][9].ToString();
                    Pais = Datos.Rows[0][10].ToString();
                    Ciudad = Datos.Rows[0][11].ToString();
                    Departamento = Datos.Rows[0][12].ToString();
                    Web = Datos.Rows[0][13].ToString();
                    Direccion = Datos.Rows[0][14].ToString();
                    Observacion = Datos.Rows[0][15].ToString();
                    Efectivo = Datos.Rows[0][16].ToString();
                    Credito = Datos.Rows[0][17].ToString();
                    Debito = Datos.Rows[0][18].ToString();
                    Contado = Datos.Rows[0][19].ToString();

                    //Se procede a completar los campos de texto segun las consulta Realizada anteriormente en la base de datos

                    //Panel Datos Basicos
                    //this.TBIdcliente.Text = Idcliente;
                    this.TBDat_Codigo.Text = Codigo;
                    this.TBDat_Nombre.Text = Cliente;
                    this.TBDat_Documento.Text = Documento;
                    this.TBDat_Telefono.Text = Telefono;
                    this.TBDat_Movil.Text = Movil;
                    this.TBDat_TelefonoAux.Text = TelefonoAux;
                    this.TBDat_MovilAux.Text = MovilAux;
                    this.TBDat_Correo.Text = Correo;
                    this.TBDat_Pais.Text = Pais;
                    this.TBDat_Ciudad.Text = Ciudad;
                    this.TBDat_Departamento.Text = Departamento;
                    this.TBDat_PaginaWeb.Text = Web;
                    this.TBDat_Direccion.Text = Direccion;
                    this.TBDat_Observacion.Text = Observacion;

                    //SE CARGAN LOS COMBOBOX SEGUN LOS REGISTROS EN LA BASE DE DATOS
                    this.Tipo_SQL = Idtipo;
                    this.CBTipo.SelectedValue = Tipo_SQL;

                    this.Grupo_SQL = Idgrupo;
                    this.CBGrupo.SelectedValue = Grupo_SQL;

                    //SE VALIDAN LOS CHEXBOX SEGUN LOS REGISTROS EN LA BASE DE DATOS SI ESTAN HABILITADOS O NO
                    if (Efectivo == "1")
                    {
                        this.CH_Efectivo.Checked = true;
                    }
                    else
                    {
                        this.CH_Efectivo.Checked = false;
                    }

                    if (Credito == "1")
                    {
                        this.CH_Credito.Checked = true;
                    }
                    else
                    {
                        this.CH_Credito.Checked = false;
                    }

                    if (Debito == "1")
                    {
                        this.CH_Debito.Checked = true;
                    }
                    else
                    {
                        this.CH_Debito.Checked = false;
                    }

                    if (Contado == "1")
                    {
                        this.CH_Contado.Checked = true;
                    }
                    else
                    {
                        this.CH_Contado.Checked = false;
                    }

                    //************************************************************************************************************************
                    //Se realizan las consultas para llenar los DataGriview donde se mostrarian los MultiPlex Registros.

                    this.DGDetalle_Contacto.DataSource = fCliente.Buscar_Contacto(1, Convert.ToInt32(this.TBIdcliente.Text));
                    this.DGDetalle_Contacto.Columns[0].Visible = false;
                    this.lblTotal_Contacto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Contacto.Rows.Count);

                    this.DGDetalle_Credito.DataSource = fCliente.Buscar_Credito(1, Convert.ToInt32(this.TBIdcliente.Text));
                    this.DGDetalle_Credito.Columns[0].Visible = false;
                    this.lblTotal_Credito.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Credito.Rows.Count);

                    this.DGDetalle_Despacho.DataSource = fCliente.Buscar_Despacho(1, Convert.ToInt32(this.TBIdcliente.Text));
                    this.DGDetalle_Despacho.Columns[0].Visible = false;
                    this.lblTotal_Despacho.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Despacho.Rows.Count);
                    //this.DGDetalle_Impuesto.Columns[1].Visible = false;
                    //this.DGDetalle_Impuesto.Columns["IdDet_impuesto"].Visible = false;

                    this.DGDetalle_Facturacion.DataSource = fCliente.Buscar_Facturacion(1, Convert.ToInt32(this.TBIdcliente.Text));
                    this.DGDetalle_Facturacion.Columns[0].Visible = false;
                    this.lblTotal_Facturacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Facturacion.Rows.Count);
                    //this.DGDetalle_Facturacion.Columns[1].Visible = false;
                    //this.DGDetalle_Facturacion.Columns[2].Visible = false;
                    //this.DGDetalle_Facturacion.Columns[3].Visible = false;

                    //this.DGDetalle_Financiera.DataSource = fCliente.Buscar_Financiera(1, Convert.ToInt32(this.TBIdcliente.Text));
                    //this.lblTotal_Financiera.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Financiera.Rows.Count);
                    //this.DGDetalle_Financiera.Columns[0].Visible = false;

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
                    this.TBIdcliente.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);
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

        private void CH_Facturacion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CH_Facturacion.Checked)
                {
                    this.TBFac_Cliente.Text = TBDat_Nombre.Text;
                    this.TBFac_Cliente.Text = TBDat_Nombre.Text;
                    this.TBFac_DocumentoCliente.Text = TBDat_Documento.Text;
                    this.TBFac_Movil.Text = TBDat_Movil.Text;
                    this.TBFac_Pais.Text = TBDat_Pais.Text;
                    this.TBFac_Ciudad.Text = TBDat_Ciudad.Text;
                    this.TBFac_Departamento.Text = TBDat_Departamento.Text;
                    this.TBFac_Correo.Text = TBDat_Correo.Text;

                    //
                    this.TBFac_Cliente.Enabled = false;
                    this.TBFac_Cliente.BackColor = Color.FromArgb(72, 209, 204);
                    this.TBFac_DocumentoCliente.Enabled = false;
                    this.TBFac_DocumentoCliente.BackColor = Color.FromArgb(72, 209, 204);
                    this.TBFac_Movil.Enabled = false;
                    this.TBFac_Movil.BackColor = Color.FromArgb(72, 209, 204);
                    this.TBFac_Pais.Enabled = false;
                    this.TBFac_Pais.BackColor = Color.FromArgb(72, 209, 204);
                    this.TBFac_Ciudad.Enabled = false;
                    this.TBFac_Ciudad.BackColor = Color.FromArgb(72, 209, 204);
                    this.TBFac_Departamento.Enabled = false;
                    this.TBFac_Departamento.BackColor = Color.FromArgb(72, 209, 204);
                    this.TBFac_Correo.Enabled = false;
                    this.TBFac_Correo.BackColor = Color.FromArgb(72, 209, 204);

                    //********************************* CAMPOS NUMERICOS VACIOS ********************************* 
                    if (TBDat_Telefono.Text == String.Empty)
                    {
                        this.TBFac_Movil.Text = "0";
                    }
                }
                else
                {
                    this.TBFac_Cliente.Clear();
                    this.TBFac_DocumentoCliente.Clear();
                    this.TBFac_Movil.Clear();
                    this.TBFac_Pais.Clear();
                    this.TBFac_Ciudad.Clear();
                    this.TBFac_Departamento.Clear();
                    this.TBFac_Correo.Clear();

                    //
                    this.TBFac_Cliente.Enabled = true;
                    this.TBFac_Cliente.BackColor = Color.FromArgb(3, 155, 229);
                    this.TBFac_DocumentoCliente.Enabled = true;
                    this.TBFac_DocumentoCliente.BackColor = Color.FromArgb(3, 155, 229);
                    this.TBFac_Movil.Enabled = true;
                    this.TBFac_Movil.BackColor = Color.FromArgb(3, 155, 229);
                    this.TBFac_Pais.Enabled = true;
                    this.TBFac_Pais.BackColor = Color.FromArgb(3, 155, 229);
                    this.TBFac_Ciudad.Enabled = true;
                    this.TBFac_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
                    this.TBFac_Departamento.Enabled = true;
                    this.TBFac_Departamento.BackColor = Color.FromArgb(3, 155, 229);
                    this.TBFac_Correo.Enabled = true;
                    this.TBFac_Correo.BackColor = Color.FromArgb(3, 155, 229);
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
                    try
                    {
                        if (Editar == "1")
                        {
                            //
                            this.Digitar = false;
                            this.Botones();

                            //Se procede a completar los campos de textos segun
                            //la consulta realizada en la base de datos
                            this.TBIdcliente.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBTipo.SelectedIndex != 0)
            {
                this.TBDat_Nombre.Select();
            }
        }

        //********************** PANEL DATOS BASICOS - ENTER *********************************************
        private void TBDat_Nombre_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDat_Nombre.Text == Campo)
            {
                this.TBDat_Nombre.BackColor = Color.Azure;
                this.TBDat_Nombre.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDat_Nombre.Clear();
            }
            else
            {
                this.TBDat_Nombre.BackColor = Color.Azure;
                this.TBDat_Nombre.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBDat_Codigo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDat_Codigo.Text == Campo)
            {
                this.TBDat_Codigo.BackColor = Color.Azure;
                this.TBDat_Codigo.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDat_Codigo.Clear();
            }
            else
            {
                this.TBDat_Codigo.BackColor = Color.Azure;
                this.TBDat_Codigo.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBDat_Documento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDat_Documento.Text == Campo)
            {
                this.TBDat_Documento.BackColor = Color.Azure;
                this.TBDat_Documento.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDat_Documento.Clear();
            }
            else
            {
                this.TBDat_Documento.BackColor = Color.Azure;
                this.TBDat_Documento.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBDat_Telefono_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Telefono.BackColor = Color.Azure;
        }

        private void TBDat_Movil_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Movil.BackColor = Color.Azure;
        }

        private void TBDat_TelefonoAux_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_TelefonoAux.BackColor = Color.Azure;
        }

        private void TBDat_MovilAux_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_MovilAux.BackColor = Color.Azure;
        }

        private void TBDat_Correo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Correo.BackColor = Color.Azure;
        }

        private void TBDat_Pais_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Pais.BackColor = Color.Azure;
        }

        private void TBDat_Ciudad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Ciudad.BackColor = Color.Azure;
        }

        private void TBDat_Departamento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Departamento.BackColor = Color.Azure;
        }

        private void TBDat_PaginaWeb_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_PaginaWeb.BackColor = Color.Azure;
        }

        private void TBDat_Direccion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Direccion.BackColor = Color.Azure;
        }

        private void TBDat_Observacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDat_Observacion.BackColor = Color.Azure;
        }

        //********************** PANEL DATOS DE FACTURACION - ENTER *********************************************

        private void TBFac_DocumentoCliente_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFac_DocumentoCliente.BackColor = Color.Azure;
        }

        private void TBFac_Cliente_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFac_Cliente.BackColor = Color.Azure;
        }

        private void TBFac_Movil_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFac_Movil.BackColor = Color.Azure;
        }

        private void TBFac_Pais_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFac_Pais.BackColor = Color.Azure;
        }

        private void TBFac_Ciudad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFac_Ciudad.BackColor = Color.Azure;
        }

        private void TBFac_Departamento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFac_Departamento.BackColor = Color.Azure;
        }

        private void TBFac_Correo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFac_Correo.BackColor = Color.Azure;
        }

        //********************** PANEL DATOS DE CREDITO - ENTER *********************************************

        private void TBCre_CreditoMinimo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_Valor.BackColor = Color.Azure;
        }

        private void TBCre_CuotaMinima_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_CuotaMeses.BackColor = Color.Azure;
        }

        private void TBCre_TasaAnual_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_TasaAnual.BackColor = Color.Azure;
        }

        private void TBCre_DiasDeProrroga_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_DiasDeProrroga.BackColor = Color.Azure;
        }

        private void TBCre_Intereses_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_TasaMensual.BackColor = Color.Azure;
        }

        private void TBCre_InteresMora_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_InteresMora.BackColor = Color.Azure;
        }

        //********************** PANEL DATOS DE DESPACHO - ENTER *********************************************

        private void TBDes_Sucurzal_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Sucurzal.BackColor = Color.Azure;
        }

        private void TBDes_Pais_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Pais.BackColor = Color.Azure;
        }

        private void TBDes_Ciudad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Ciudad.BackColor = Color.Azure;
        }

        private void TBDes_Departamento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Departamento.BackColor = Color.Azure;
        }

        private void TBDes_Receptor_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Receptor.BackColor = Color.Azure;
        }

        private void TBDes_Barrio_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Barrio.BackColor = Color.Azure;
        }

        private void TBDes_Apartamento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Apartamento.BackColor = Color.Azure;
        }

        private void TBDes_Movil_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Movil.BackColor = Color.Azure;
        }

        private void TBDes_Direccion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Direccion.BackColor = Color.Azure;
        }

        private void TBDes_Observacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBDes_Observacion.BackColor = Color.Azure;
        }

        //********************** PANEL DATOS FINANCIEROS - ENTER *********************************************

        private void TBFin_NumCuenta_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBFin_NumCuenta.BackColor = Color.Azure;
        }

        //********************** PANEL DATOS DE CONTACTO - ENTER *********************************************

        private void TBCon_Contacto_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCon_Contacto.BackColor = Color.Azure;
        }

        private void TBCon_Ciudad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCon_Ciudad.BackColor = Color.Azure;
        }

        private void TBCon_Direccion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCon_Direccion.BackColor = Color.Azure;
        }

        private void TBCon_Telefono_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCon_Telefono.BackColor = Color.Azure;
        }

        private void TBCon_Movil_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCon_Movil.BackColor = Color.Azure;
        }

        private void TBCon_Correo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCon_Correo.BackColor = Color.Azure;
        }

        private void TBCon_Parentesco_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCon_Parentesco.BackColor = Color.Azure;
        }

        //********************** PANEL DATOS BASICOS - LEAVE *********************************************

        private void TBDat_Codigo_Leave(object sender, EventArgs e)
        {
            if (TBDat_Codigo.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDat_Codigo.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDat_Codigo.Text = Campo;
                this.TBDat_Codigo.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                this.TBDat_Codigo.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDat_Nombre_Leave(object sender, EventArgs e)
        {
            if (TBDat_Nombre.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDat_Nombre.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDat_Nombre.Text = Campo;
                this.TBDat_Nombre.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                this.TBDat_Nombre.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDat_Documento_Leave(object sender, EventArgs e)
        {
            if (TBDat_Documento.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDat_Documento.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDat_Documento.Text = Campo;
                this.TBDat_Documento.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                this.TBDat_Documento.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDat_Telefono_Leave(object sender, EventArgs e)
        {
            this.TBDat_Telefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_Movil_Leave(object sender, EventArgs e)
        {
            this.TBDat_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_TelefonoAux_Leave(object sender, EventArgs e)
        {
            this.TBDat_TelefonoAux.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_MovilAux_Leave(object sender, EventArgs e)
        {
            this.TBDat_MovilAux.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_Correo_Leave(object sender, EventArgs e)
        {
            this.TBDat_Correo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_Pais_Leave(object sender, EventArgs e)
        {
            this.TBDat_Pais.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_Ciudad_Leave(object sender, EventArgs e)
        {
            this.TBDat_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_Departamento_Leave(object sender, EventArgs e)
        {
            this.TBDat_Departamento.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_PaginaWeb_Leave(object sender, EventArgs e)
        {
            this.TBDat_PaginaWeb.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_Direccion_Leave(object sender, EventArgs e)
        {
            this.TBDat_Direccion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDat_Observacion_Leave(object sender, EventArgs e)
        {
            this.TBDat_Observacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        //********************** PANEL DATOS DE FACTURACION - LEAVE *********************************************

        private void TBFac_DocumentoCliente_Leave(object sender, EventArgs e)
        {
            this.TBFac_DocumentoCliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFac_Cliente_Leave(object sender, EventArgs e)
        {
            this.TBFac_Cliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFac_Movil_Leave(object sender, EventArgs e)
        {
            this.TBFac_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFac_Pais_Leave(object sender, EventArgs e)
        {
            this.TBFac_Pais.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFac_Ciudad_Leave(object sender, EventArgs e)
        {
            this.TBFac_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFac_Departamento_Leave(object sender, EventArgs e)
        {
            this.TBFac_Departamento.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFac_Correo_Leave(object sender, EventArgs e)
        {
            this.TBFac_Correo.BackColor = Color.FromArgb(3, 155, 229);
        }

        //********************** PANEL DATOS DE CREDITO - LEAVE *********************************************

        private void TBCre_CreditoMinimo_Leave(object sender, EventArgs e)
        {
            this.TBCre_Valor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_CuotaMinima_Leave(object sender, EventArgs e)
        {
            this.TBCre_CuotaMeses.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_DiasDeProrroga_Leave(object sender, EventArgs e)
        {
            this.TBCre_DiasDeProrroga.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_Intereses_Leave(object sender, EventArgs e)
        {
            this.TBCre_TasaMensual.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_InteresMora_Leave(object sender, EventArgs e)
        {
            this.TBCre_InteresMora.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_TasaAnual_Leave(object sender, EventArgs e)
        {
            this.TBCre_TasaAnual.BackColor = Color.FromArgb(3, 155, 229);
        }
        //********************** PANEL DATOS DE ENVIO - LEAVE *********************************************

        private void TBDes_Sucurzal_Leave(object sender, EventArgs e)
        {
            this.TBDes_Sucurzal.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Pais_Leave(object sender, EventArgs e)
        {
            this.TBDes_Pais.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Ciudad_Leave(object sender, EventArgs e)
        {
            this.TBDes_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Departamento_Leave(object sender, EventArgs e)
        {
            this.TBDes_Departamento.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Receptor_Leave(object sender, EventArgs e)
        {
            this.TBDes_Receptor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Barrio_Leave(object sender, EventArgs e)
        {
            this.TBDes_Barrio.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Apartamento_Leave(object sender, EventArgs e)
        {
            this.TBDes_Apartamento.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Movil_Leave(object sender, EventArgs e)
        {
            this.TBDes_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Direccion_Leave(object sender, EventArgs e)
        {
            this.TBDes_Direccion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDes_Observacion_Leave(object sender, EventArgs e)
        {
            this.TBDes_Observacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        //********************** PANEL DATOS DE FINANCIERA - LEAVE *********************************************

        private void TBFin_NumCuenta_Leave(object sender, EventArgs e)
        {
            this.TBFin_NumCuenta.BackColor = Color.FromArgb(3, 155, 229);
        }

        //********************** PANEL DATOS DE CONTACTO - LEAVE *********************************************

        private void TBCon_Contacto_Leave(object sender, EventArgs e)
        {
            this.TBCon_Contacto.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCon_Ciudad_Leave(object sender, EventArgs e)
        {
            this.TBCon_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCon_Direccion_Leave(object sender, EventArgs e)
        {
            this.TBCon_Direccion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCon_Telefono_Leave(object sender, EventArgs e)
        {
            this.TBCon_Telefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCon_Movil_Leave(object sender, EventArgs e)
        {
            this.TBCon_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCon_Correo_Leave(object sender, EventArgs e)
        {
            this.TBCon_Correo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCon_Parentesco_Leave(object sender, EventArgs e)
        {
            this.TBCon_Parentesco.BackColor = Color.FromArgb(3, 155, 229);
        }

        //********************** PANEL DATOS BASICOS - SALTO DE LINEA *********************************************

        private void TBDat_Codigo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Nombre.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Codigo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Codigo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Nombre_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Documento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Nombre.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Nombre.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Documento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Telefono.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Documento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Documento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Telefono_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Telefono.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Telefono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Movil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_TelefonoAux.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Movil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_TelefonoAux_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_MovilAux.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_TelefonoAux.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_TelefonoAux.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_MovilAux_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Correo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_MovilAux.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_MovilAux.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Correo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Pais.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Correo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Correo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Pais_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Ciudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Pais.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Pais.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Ciudad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Departamento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Ciudad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_DocumentoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_Movil_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Movil_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_MovilAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_TelefonoAux_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_TasaMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_CuotaMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_TasaAnual_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_DiasDeProrroga_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_InteresMora_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Movil_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFin_NumCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Movil_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se Permite Digitar Numeros", "Advertencia - Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGDetalle_Facturacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.TBFac_CodigoAsesor.Text = DGDetalle_Facturacion.CurrentRow.Cells[2].Value.ToString();
                this.TBFac_Asesor.Text = DGDetalle_Facturacion.CurrentRow.Cells[3].Value.ToString();
                this.TBFac_Cliente.Text = DGDetalle_Facturacion.CurrentRow.Cells[4].Value.ToString();
                this.TBFac_DocumentoCliente.Text = DGDetalle_Facturacion.CurrentRow.Cells[5].Value.ToString();
                this.TBFac_Movil.Text = DGDetalle_Facturacion.CurrentRow.Cells[6].Value.ToString();
                this.TBFac_Pais.Text = DGDetalle_Facturacion.CurrentRow.Cells[7].Value.ToString();
                this.TBFac_Ciudad.Text = DGDetalle_Facturacion.CurrentRow.Cells[8].Value.ToString();
                this.TBFac_Departamento.Text = DGDetalle_Facturacion.CurrentRow.Cells[9].Value.ToString();
                this.TBFac_Correo.Text = DGDetalle_Facturacion.CurrentRow.Cells[10].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_Valor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCre_CuotaMeses.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_Valor.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCre_Valor.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_CuotaMeses_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCre_TasaMensual.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CuotaMeses.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCre_CuotaMeses.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_TasaAnual_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCre_DiasDeProrroga.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_TasaAnual.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCre_TasaAnual.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_DiasDeProrroga_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCre_InteresMora.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_DiasDeProrroga.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCre_DiasDeProrroga.Select();
                        }
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
                        this.DGResultados.DataSource = fCliente.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultados.Columns[0].Visible = false;
                        this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;

                        //************************************* Alineacion de las Celdas *************************************

                        //Panel Codigo de Barra
                        this.DGResultados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        this.DGResultados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        //Se Limpian las Filas y Columnas de la tabla
                        this.DGResultados.DataSource = null;
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

        private void TBDat_Departamento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_PaginaWeb.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Departamento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Departamento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_PaginaWeb_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Direccion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_PaginaWeb.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_PaginaWeb.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Direccion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Observacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Direccion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Direccion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDat_Observacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDat_Nombre.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Observacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDat_Observacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //********************** PANEL DATOS DE FACTURACION - SALTO DE LINEA *********************************************
        private void TBFac_DocumentoCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFac_Cliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFac_DocumentoCliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFac_DocumentoCliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFac_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFac_Cliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFac_Cliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_Movil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFac_Pais.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFac_Movil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFac_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_Pais_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBFac_Ciudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFac_Pais.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFac_Pais.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_Ciudad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFac_Departamento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFac_Ciudad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFac_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_Departamento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFac_Correo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFac_Departamento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFac_Departamento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFac_Correo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFac_DocumentoCliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFac_Correo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFac_Correo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //********************** PANEL DATOS DE CREDITO - SALTO DE LINEA *********************************************

        private void TBCre_TasaMensual_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCre_TasaAnual.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_TasaMensual.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCre_TasaMensual.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCre_InteresMora_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCre_Valor.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_InteresMora.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCre_InteresMora.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //********************** PANEL DATOS DE DESPACHO - SALTO DE LINEA *********************************************

        private void TBDes_Sucurzal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Pais.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Sucurzal.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Sucurzal.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Pais_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Ciudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Pais.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Pais.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Ciudad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Departamento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Ciudad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Departamento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Receptor.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Departamento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Departamento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Receptor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Barrio.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Receptor.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Receptor.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Barrio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Apartamento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Barrio.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Barrio.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Apartamento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Apartamento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Apartamento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Movil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Direccion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Movil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Direccion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Observacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Direccion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Direccion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDes_Observacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDes_Sucurzal.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Observacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDes_Observacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //********************** PANEL DATOS FINANCIERA - SALTO DE LINEA *********************************************

        private void TBFin_NumCuenta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFin_NumCuenta.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBFin_NumCuenta.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBFin_NumCuenta.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //********************** PANEL DATOS DE CONTACTO - SALTO DE LINEA *********************************************

        private void TBCon_Contacto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCon_Ciudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCon_Contacto.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCon_Contacto.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Ciudad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCon_Direccion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCon_Ciudad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCon_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Direccion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCon_Telefono.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCon_Direccion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCon_Direccion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Telefono_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCon_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCon_Telefono.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCon_Telefono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Movil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCon_Correo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCon_Movil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCon_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Correo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCon_Parentesco.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCon_Correo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCon_Correo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCon_Parentesco_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCon_Contacto.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCon_Parentesco.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCon_Parentesco.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
