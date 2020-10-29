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

        // ******************************************* Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar ************************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        // ******************************************* Parametros para AutoCompletar los Texboxt *********************************************************

        //Panel Datos Basicos
        private string Codigo, Idtipo, Nombre, Documento, Telefono, Movil, Correo, Pais, Ciudad, Departamento = "";

        //Panel Datos de Envio
        private string PaisDeEnvio, CiudadDeEnvio, Receptor, DireccionPrincipal, TelefonoDeEnvio, MovilDeEnvio, Observacion = "";

        //Panel Datos Financieros
        private string Diasdecredito, Diasdeprorroga, Interesespormora, Creditominimo, Creditomaximo = "";

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

            //Focus a Texboxt y Combobox
            this.TBDat_Nombre.Select();

            //Ocultacion de Texboxt
            this.TBIdcliente.Visible = false;
            this.TBIdbanco.Visible = false;
            this.TBIdempleado.Visible = false;
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
            //this.TBDat_Ahorro.ReadOnly = false;
            //this.TBDat_Ahorro.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBDat_CreditoDisp.ReadOnly = false;
            //this.TBDat_CreditoDisp.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBDat_CreditoFact.ReadOnly = false;
            //this.TBDat_CreditoFact.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBCre_CreditoMinimo.ReadOnly = false;
            this.TBCre_CreditoMinimo.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBCre_CreditoMaximo.ReadOnly = false;
            //this.TBCre_CreditoMaximo.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBCre_DebitoMinimo.ReadOnly = false;
            //this.TBCre_DebitoMinimo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_CuotaMinima.ReadOnly = false;
            this.TBCre_CuotaMinima.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBCre_CuotaMaxima.ReadOnly = false;
            //this.TBCre_CuotaMaxima.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBCre_Diasdecredito.ReadOnly = false;
            //this.TBCre_Diasdecredito.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_DiasDeProrroga.ReadOnly = false;
            this.TBCre_DiasDeProrroga.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_InteresMora.ReadOnly = false;
            this.TBCre_InteresMora.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBCre_DebitoMaximo.ReadOnly = false;
            //this.TBCre_DebitoMaximo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_Intereses.ReadOnly = false;
            this.TBCre_Intereses.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBDat_Nombre.Clear();
            this.TBDat_Nombre.Text = Campo;
            this.TBDat_Documento.Clear();
            this.TBDat_Documento.Text = Campo;

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
            //this.TBDat_Ahorro.Clear();
            //this.TBDat_CreditoDisp.Clear();
            //this.TBDat_CreditoFact.Clear();

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
            this.TBFin_Banco.Enabled = false;
            this.TBFin_NumCuenta.Clear();
            this.CBFin_Cuenta.SelectedIndex = 0;

            //Datos de Creditos
            this.TBCre_CreditoMinimo.Clear();
            //this.TBCre_CreditoMaximo.Clear();
            //this.TBCre_DebitoMinimo.Clear();
            this.TBCre_CuotaMinima.Clear();
            //this.TBCre_CuotaMaxima.Clear();
            //this.TBCre_Diasdecredito.Clear();
            this.TBCre_DiasDeProrroga.Clear();
            this.TBCre_InteresMora.Clear();
            //this.TBCre_DebitoMaximo.Clear();
            this.TBCre_Intereses.Clear();

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

        private void Auto_Combobox()
        {
            try
            {
                this.CBTipo.DataSource = fTipoDeCliente.Lista();
                this.CBTipo.ValueMember = "Codigo";
                this.CBTipo.DisplayMember = "Tipo";

                this.CBGrupo.DataSource = fGrupoDeCliente.Lista();
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
        }

        private void Diseño_TablasGenerales()
        {
            try
            {
                //Panel de Facturacion
                this.DtDetalle_Facturacion = new DataTable();
                this.DtDetalle_Facturacion.Columns.Add("Idempleado", System.Type.GetType("System.Int32"));
                this.DtDetalle_Facturacion.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Empleado", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Cliente", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Documento", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Movil", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("País", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Departamento", System.Type.GetType("System.String"));
                this.DtDetalle_Facturacion.Columns.Add("Correo", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Facturacion.DataSource = DtDetalle_Facturacion;

                //Panel de Credito
                this.DtDetalle_Credito = new DataTable();
                this.DtDetalle_Credito.Columns.Add("Idcredito", System.Type.GetType("System.Int32"));
                this.DtDetalle_Credito.Columns.Add("Valor", System.Type.GetType("System.String"));
                this.DtDetalle_Credito.Columns.Add("Cuota", System.Type.GetType("System.String"));
                this.DtDetalle_Credito.Columns.Add("T. Mensual", System.Type.GetType("System.String"));
                this.DtDetalle_Credito.Columns.Add("T. Anual", System.Type.GetType("System.String"));
                this.DtDetalle_Credito.Columns.Add("Solicitud", System.Type.GetType("System.String"));
                this.DtDetalle_Credito.Columns.Add("Emisión", System.Type.GetType("System.DateTime"));
                this.DtDetalle_Credito.Columns.Add("Días", System.Type.GetType("System.DateTime"));
                this.DtDetalle_Credito.Columns.Add("Mora", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Credito.DataSource = this.DtDetalle_Credito;

                //Panel de Envio - Despacho
                this.DtDetalle_Despacho = new DataTable();
                //this.DtDetalle_Despacho.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Despacho.Columns.Add("Sucurzal", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("País", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Departamento", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Rceptor", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Barrio", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Departamento", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Móvil", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Dirección", System.Type.GetType("System.String"));
                this.DtDetalle_Despacho.Columns.Add("Observación", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Despacho.DataSource = this.DtDetalle_Despacho;

                //Panel Financiera
                this.DtDetalle_Financiera = new DataTable();
                this.DtDetalle_Financiera.Columns.Add("Idbanco", System.Type.GetType("System.Int32"));
                this.DtDetalle_Financiera.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle_Financiera.Columns.Add("Banco", System.Type.GetType("System.String"));
                this.DtDetalle_Financiera.Columns.Add("Cuenta", System.Type.GetType("System.String"));
                this.DtDetalle_Financiera.Columns.Add("Nº. de Cuenta", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Financiera.DataSource = this.DtDetalle_Financiera;

                //Panel Datos de Contacto
                this.DtDetalle_Contacto = new DataTable();
                this.DtDetalle_Contacto.Columns.Add("Contacto", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Ciudad", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Dirección", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Telefono", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Móvil", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Correo", System.Type.GetType("System.String"));
                this.DtDetalle_Contacto.Columns.Add("Parentesco", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Contacto.DataSource = this.DtDetalle_Contacto;
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
                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fCliente.Guardar_DatosBasicos
                            (

                                //Datos Auxiliares
                                Convert.ToInt32(1), Convert.ToInt32(this.CBTipo.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue),

                                //Panel Datos Basicos
                                this.TBDat_Codigo.Text, this.TBDat_Nombre.Text, this.TBDat_Documento.Text, this.TBDat_Telefono.Text, this.TBDat_Movil.Text, this.TBDat_TelefonoAux.Text, this.TBDat_MovilAux.Text, this.TBDat_Correo.Text, this.TBDat_Pais.Text, this.TBDat_Ciudad.Text, this.TBDat_Departamento.Text, this.TBDat_PaginaWeb.Text, this.TBDat_Direccion.Text, this.TBDat_Observacion.Text,

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
                this.Limpiar_Datos();

                //Se Limpian las Filas y Columnas de la tabla
                this.DGResultados.DataSource = null;
                this.DGResultados.Enabled = false;
                this.lblTotal.Text = "Datos Registrados: 0";
                this.TBBuscar.Text="";
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
                    MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        fila["Idempleado"] = Convert.ToInt32(this.TBIdempleado.Text);
                        fila["Codigo"] = this.TBFac_CodigoAsesor.Text;
                        fila["Empleado"] = this.TBFac_Asesor.Text;
                        fila["Cliente"] = this.TBFac_Cliente.Text;
                        fila["Documento"] = this.TBFac_DocumentoCliente.Text;
                        fila["Movil"] = this.TBFac_Movil.Text;
                        fila["País"] = this.TBFac_Pais.Text;
                        fila["Ciudad"] = this.TBFac_Ciudad.Text;
                        fila["Departamento"] = this.TBFac_Departamento.Text;
                        fila["Correo"] = this.TBFac_Correo.Text;
                        this.DtDetalle_Facturacion.Rows.Add(fila);

                        //
                        this.TBFac_Cliente.Clear();
                        this.TBFac_Asesor.Clear();
                        this.TBFac_DocumentoCliente.Clear();
                        this.TBFac_CodigoAsesor.Clear();
                        this.TBFac_Movil.Clear();
                        this.TBFac_Correo.Clear();
                        this.TBFac_Pais.Clear();
                        this.TBFac_Ciudad.Clear();
                        this.TBFac_Departamento.Clear();
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
                            //rptaDatosBasicos = fCliente.f

                            //        (
                            //             //Datos Basicos
                            //             Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(this.CBBodega.SelectedValue), this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text,

                            //            //Datos Auxiliares
                            //            1
                            //        );

                            //if (rptaDatosBasicos.Equals("OK"))
                            //{
                            //    this.MensajeOk("La Ubicación del Producto: " + TBNombre.Text + " con Codigo: " + this.TBCodigo.Text + " a Sido Registrada Exitosamente");
                            //}

                            //else
                            //{
                            //    this.MensajeError(rptaDatosBasicos);
                            //}

                            ////
                            //this.CBBodega.SelectedIndex = 0;
                            //this.TBUbicacion.Clear();
                            //this.TBEstante.Clear();
                            //this.TBNivel.Clear();

                            //this.Actualizar_DetUbicacion();
                        }
                        else
                        {
                            //this.TBUbicacion.Select();
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

        }

        private void btnAgregar_Despacho_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Financiera_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Contacto_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Facturacion_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Credito_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Despacho_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Financiera_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Contacto_Click(object sender, EventArgs e)
        {

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
                    Codigo = Datos.Rows[0][0].ToString();
                    Idtipo = Datos.Rows[0][1].ToString();
                    Nombre = Datos.Rows[0][2].ToString();
                    Documento = Datos.Rows[0][3].ToString();
                    Telefono = Datos.Rows[0][4].ToString();
                    Movil = Datos.Rows[0][5].ToString();
                    Correo = Datos.Rows[0][6].ToString();
                    Pais = Datos.Rows[0][7].ToString();
                    Ciudad = Datos.Rows[0][8].ToString();
                    Departamento = Datos.Rows[0][9].ToString();

                    //Panel Datos de Envio
                    PaisDeEnvio = Datos.Rows[0][10].ToString();
                    CiudadDeEnvio = Datos.Rows[0][11].ToString();
                    Receptor = Datos.Rows[0][12].ToString();
                    DireccionPrincipal = Datos.Rows[0][13].ToString();
                    TelefonoDeEnvio = Datos.Rows[0][16].ToString();
                    MovilDeEnvio = Datos.Rows[0][17].ToString();
                    Observacion = Datos.Rows[0][18].ToString();

                    //Panel Datos Financieros
                    Diasdecredito = Datos.Rows[0][21].ToString();
                    Diasdeprorroga = Datos.Rows[0][22].ToString();
                    Interesespormora = Datos.Rows[0][23].ToString();
                    Creditominimo = Datos.Rows[0][24].ToString();
                    Creditomaximo = Datos.Rows[0][25].ToString();

                    //Se procede a completar los campos de texto segun las consulta
                    //Realizada anteriormente en la base de datos


                    //Panel Datos Basicos
                    this.TBDat_Codigo.Text = Codigo;
                    this.CBTipo.SelectedValue = Idtipo;
                    this.TBDat_Nombre.Text = Nombre;
                    this.TBDat_Documento.Text = Documento;
                    this.TBDat_Telefono.Text = Telefono;
                    this.TBDat_Movil.Text = Movil;
                    this.TBDat_Correo.Text = Correo;
                    this.TBDat_Pais.Text = Pais;
                    this.TBDat_Ciudad.Text = Ciudad;
                    this.TBDat_Departamento.Text = Departamento;

                    //Panel Datos de Envio
                    this.TBDes_Pais.Text = PaisDeEnvio;
                    this.TBDes_Ciudad.Text = CiudadDeEnvio;
                    this.TBDes_Receptor.Text = Receptor;
                    this.TBDes_Direccion.Text = DireccionPrincipal;
                    this.TBDes_Movil.Text = TelefonoDeEnvio;
                    this.TBDes_Movil.Text = MovilDeEnvio;
                    this.TBDes_Observacion.Text = Observacion;

                    //Panel Datos Financieros
                    //this.TBCre_Diasdecredito.Text = Diasdecredito;
                    this.TBCre_DiasDeProrroga.Text = Diasdeprorroga;
                    this.TBCre_InteresMora.Text = Interesespormora;
                    this.TBCre_CreditoMinimo.Text = Creditominimo;
                    //this.TBCre_CreditoMaximo.Text = Creditomaximo;
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
            this.TBCre_CreditoMinimo.BackColor = Color.Azure;
        }

        private void TBCre_CuotaMinima_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_CuotaMinima.BackColor = Color.Azure;
        }

        private void TBCre_DiasDeProrroga_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_DiasDeProrroga.BackColor = Color.Azure;
        }
         
        private void TBCre_Intereses_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBCre_Intereses.BackColor = Color.Azure;
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
            this.TBCre_CreditoMinimo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_CuotaMinima_Leave(object sender, EventArgs e)
        {
            this.TBCre_CuotaMinima.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_DiasDeProrroga_Leave(object sender, EventArgs e)
        {
            this.TBCre_DiasDeProrroga.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_Intereses_Leave(object sender, EventArgs e)
        {
            this.TBCre_Intereses.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCre_InteresMora_Leave(object sender, EventArgs e)
        {
            this.TBCre_InteresMora.BackColor = Color.FromArgb(3, 155, 229);
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

        private void TBCre_Intereses_KeyUp(object sender, KeyEventArgs e)
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
                            this.TBCre_Intereses.Select();
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
                            this.TBCre_Intereses.Select();
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

                    this.TBCre_CreditoMinimo.Select();
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
