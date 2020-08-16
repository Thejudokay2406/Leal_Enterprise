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
    public partial class frmProductos : Form
    {
        //Instancia para el Filtro de los productos 
        private static frmProductos _Instancia;

        public static frmProductos GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmProductos();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //Variables para Eliminar y ejecutar los procedimientos Internos en los paneles
        //Ubicacion, Lote, Proveedor ETC donde se realizan multiplex registros
        private bool Eliminar_Lote = false;
        private bool Eliminar_Igualdad = false;
        private bool Eliminar_Impuesto = false;
        private bool Eliminar_Ubicacion = false;
        private bool Eliminar_Proveedor = false;
        private bool Eliminar_CodigoDeBarra = false;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle_Lote;
        private DataTable DtDetalle_Impuesto;
        private DataTable DtDetalle_Igualdad;
        private DataTable DtDetalle_Ubicacion;
        private DataTable DtDetalle_Proveedor;
        private DataTable DtDetalle_CodigoDeBarra;

        //Variables de Validaciones
        public int Idempleado; //Variable para Captura el Empleado Logueado
        private string Campo = "Campo Obligatorio";

        //********** Variables para la Validacion de los checkbox en el Pane Datos Basicos**************************************

        private string Checkbox_Vencimiento, Checkbox_Ofertable, Checkbox_Impuesto = "";
        private string Checkbox_Comision, Checkbox_Exportado, Checkbox_Importado = "";

        //********** Variables para la Validacion de las Transacciones en SQL **************************************************

        private string Tran_Ubicacion, Tran_Igualdad, Tran_Lote, Tran_CodBarra, Tran_Proveedor, Tran_Impuesto = "";

        //********** Variables para AutoComplementar Combobox y Chexboxt segun la Consulta en SQL ******************************

        //Panel Datos Basicos
        private string Bodega_SQL, Empaque_SQL, Grupo_SQL, Marca_SQL, Tipo_SQL = "";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *********************************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Parametros para AutoCompletar los Texboxt *****************************************************************

        //Panel Datos Basicos - Llaves Primarias
        private string Idproducto, Idmarca, Idgrupo, Idtipo, Idempaque, Idbodega, Idproveedor, Idimpuesto = "";

        //Panel Datos Basicos
        private string Codigo, Nombre, Referencia, Descripcion, Presentacion, Por_Comision, Val_Comision, Unidad = "";
        private string AplicaVencimiento, AplicaImpuesto, Importado, Exportado, Ofertable, AplicaComision = "";

        //Panel - Valores
        private string Valor_Promedio, ValCom_Final, Valor_Excento, Valor_NoExcento, Valor_Mayorista, Valor_Fabricacion, Valor_Materiales, Valor_Exportacion, Valor_Importacion, Valor_Seguro, Valor_Otros = "";

        //Panel - Cantidades
        private string VenMin_Cliente, VenMax_Cliente, VenMin_Mayorista, VenMax_Mayorista, ComMin_Cliente, ComMax_Cliente, ComMin_Mayorista, ComMax_Mayorista = "";

        //Panel - Imagen
        private string Imagen = "";

        //********** Variable para Agregar registros a los multiplex detalles como Ubicacio, Proveedores, Impuestos ETC *********************************************

        private string Imp_Nombre, Imp_Descripcion, Imp_Valor = "";

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.AutoCompletar_Combobox();
            this.Diseño_TablasGenerales();
            this.AutoIncrementable_SQL();

            //Inicio de Texbox y Combobox por default
            this.TBNombre.Select();

            this.TBComision_Valor.Text = "0";
            this.TBComision_Porcentaje.Text = "0";

            //Ocultacion de Texboxt
            this.TBIdproducto.Visible = false;
            this.TBIdimpuesto.Visible = false;
            this.TBIdproveedor.Visible = false;
            this.TBIdproducto_AutoSQL.Visible = false;
            this.TBIdigualdad_Producto.Visible = false;

            //Panel - Cantidades - Otros Datos
            this.CBUnidad.SelectedIndex = 0;
            
            //
            this.PB_Imagen.Image = Properties.Resources.Logo_Leal_Enterprise;
        }

        private void Habilitar()
        {
                        
            //Panel - Datos Basicos
            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCodigo.Text = Campo;
            this.TBNombre.ReadOnly = false;
            this.TBNombre.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNombre.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBNombre.Text = Campo;
            this.TBDescripcion01.ReadOnly = false;
            this.TBDescripcion01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion01.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDescripcion01.Text = Campo;
            this.TBReferencia.ReadOnly = false;
            this.TBReferencia.BackColor = Color.FromArgb(3, 155, 229);
            this.TBPresentacion.ReadOnly = false;
            this.TBPresentacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComision_Porcentaje.Enabled = false;
            this.TBComision_Porcentaje.BackColor = Color.FromArgb(72, 209, 204);
            this.TBComision_Valor.Enabled = false;
            this.TBComision_Valor.BackColor = Color.FromArgb(72, 209, 204);

            //Panel Proveedor
            this.TBProveedor.ReadOnly = false;
            this.TBProveedor.BackColor = Color.FromArgb(72, 209, 204);

            //Panel - Valores
            this.TBCompraPromedio.ReadOnly = false;
            this.TBCompraPromedio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompraFinal.ReadOnly = false;
            this.TBCompraFinal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorVenta_NoExcento.ReadOnly = false;
            this.TBValorVenta_NoExcento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorVenta_Excento.ReadOnly = false;
            this.TBValorVenta_Excento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVentaMayorista.ReadOnly = false;
            this.TBVentaMayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCosto_Fabricacion.ReadOnly = false;
            this.TBCosto_Fabricacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCostos_Materiales.ReadOnly = false;
            this.TBCostos_Materiales.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCostos_Exportacion.ReadOnly = false;
            this.TBCostos_Exportacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCostos_Imprtacion.ReadOnly = false;
            this.TBCostos_Imprtacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCostos_Seguridad.ReadOnly = false;
            this.TBCostos_Seguridad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCostos_Adicional.ReadOnly = false;
            this.TBCostos_Adicional.BackColor = Color.FromArgb(3, 155, 229);

            // Panel Cantidades
            this.TBVentaMaxima_Mayorista.ReadOnly = false;
            this.TBVentaMaxima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVentaMinima_Mayorista.ReadOnly = false;
            this.TBVentaMinima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVentaMinina_Cliente.ReadOnly = false;
            this.TBVentaMinina_Cliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVentaMaxima_Cliente.ReadOnly = false;
            this.TBVentaMaxima_Cliente.BackColor = Color.FromArgb(3, 155, 229);

            this.TBCompraMinima_Cliente.ReadOnly = false;
            this.TBCompraMinima_Cliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompraMinima_Mayorista.ReadOnly = false;
            this.TBCompraMinima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompraMaxima_Mayorista.ReadOnly = false;
            this.TBCompraMaxima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);

            //Panel Igualdad
            this.TBIgualdad_Codigo.ReadOnly = false;
            this.TBIgualdad_Codigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBIgualdad_Producto.ReadOnly = false;
            this.TBIgualdad_Producto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBIgualdad_Marca.ReadOnly = false;
            this.TBIgualdad_Marca.BackColor = Color.FromArgb(3, 155, 229);

            //Panel Proveedor
            this.TBProveedor.ReadOnly = false;
            this.TBProveedor.BackColor = Color.FromArgb(3, 155, 229);

            //Panel Codigo de Barra
            this.TBCodigodeBarra.ReadOnly = false;
            this.TBCodigodeBarra.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Ubicacion
            this.TBUbicacion.ReadOnly = false;
            this.TBUbicacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEstante.ReadOnly = false;
            this.TBEstante.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNivel.ReadOnly = false;
            this.TBNivel.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Impuestos
            this.TBImpuesto.Enabled = false;
            this.TBImpuesto.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_Impuesto.Enabled = false;
            this.TBValor_Impuesto.BackColor = Color.FromArgb(72, 209, 204);
            this.TBDescripcion_Impuesto.Enabled = false;
            this.TBDescripcion_Impuesto.BackColor = Color.FromArgb(72, 209, 204);

            //Panel - Lote
            this.TBLotedeingreso.ReadOnly = false;
            this.TBLotedeingreso.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_Lote.ReadOnly = false;
            this.TBValor_Lote.BackColor = Color.FromArgb(3, 155, 229);
            this.TBLote_Venta.ReadOnly = false;
            this.TBLote_Venta.BackColor = Color.FromArgb(3, 155, 229);
            this.TBLote_Cantidad.ReadOnly = false;
            this.TBLote_Cantidad.BackColor = Color.FromArgb(3, 155, 229);
            this.DTLote_Vencimiento.Enabled = true;
            this.DTLote_Vencimiento.BackColor = Color.FromArgb(3, 155, 229);

            //Panel de Consulta General
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
                        
            this.TBCodigo.Clear();
            this.TBNombre.Clear();
            this.TBDescripcion01.Clear();
            this.TBReferencia.Clear();
            this.TBPresentacion.Clear();
            this.TBComision_Porcentaje.Enabled = false;
            this.TBComision_Valor.Enabled = false;

            this.CBMarca.SelectedIndex = 0;
            this.CBGrupo.SelectedIndex = 0;
            this.CBEmpaque.SelectedIndex = 0;
            this.CBTipo.SelectedIndex = 0;
            this.CBUnidad.SelectedIndex = 0;

            this.CBVencimiento.Checked = false;
            this.CBImpuesto.Checked = false;
            this.CBOfertable.Checked = false;
            this.CBImportado.Checked = false;
            this.CBExportado.Checked = false;
            this.CBManejaComision.Checked = false;

            //Panel Proveedor
            this.TBProveedor.Clear();

            //Panel - Valores
            this.TBCompraPromedio.Clear();
            this.TBCompraFinal.Clear();
            this.TBValorVenta_NoExcento.Enabled = false;
            this.TBValorVenta_Excento.Clear();
            this.TBVentaMayorista.Clear();
            this.TBCosto_Fabricacion.Clear();
            this.TBCostos_Materiales.Clear();
            this.TBCostos_Exportacion.Clear();
            this.TBCostos_Imprtacion.Clear();
            this.TBCostos_Seguridad.Clear();
            this.TBCostos_Adicional.Clear();

            // Panel Cantidades
            this.TBVentaMaxima_Mayorista.Clear();
            this.TBVentaMinima_Mayorista.Clear();
            this.TBVentaMinina_Cliente.Clear();
            this.TBVentaMaxima_Cliente.Clear();

            this.TBCompraMinima_Cliente.Clear();
            this.TBCompraMinima_Mayorista.Clear();
            this.TBCompraMaxima_Cliente.Clear();
            this.TBCompraMaxima_Mayorista.Clear();

            //Panel Igualdad
            this.TBIgualdad_Codigo.Clear();
            this.TBIgualdad_Producto.Clear();
            this.TBIgualdad_Marca.Clear();
            this.TBIdigualdad_Producto.Clear();
            this.DGDetalle_Igualdad.DataSource = null;

            //Panel Impuesto
            this.TBIdimpuesto.Clear();
            this.TBImpuesto.Clear();
            this.TBValor_Impuesto.Clear();
            this.TBDescripcion_Impuesto.Clear();
            this.DGDetalle_Impuesto.DataSource = null;

            //Panel Proveedor
            this.TBProveedor.Clear();
            this.DGDetalle_Proveedor.DataSource = null;

            //Panel Codigo de Barra
            this.TBCodigodeBarra.Clear();
            this.DGDetalle_CodigoDeBarra.DataSource = null;

            //Panel - Ubicacion
            this.CBBodega.SelectedIndex = 0;
            this.TBUbicacion.Clear();
            this.TBEstante.Clear();
            this.TBNivel.Clear();
            this.DGDetalles_Ubicacion.DataSource = null;

            //Panel - Lote
            this.TBLotedeingreso.Clear();
            this.TBValor_Lote.Clear();
            this.TBLote_Cantidad.Clear();
            this.DTLote_Vencimiento.Enabled = true;
            this.DGDetalles_Lotes.DataSource = null;

            //Limpieza de Label que cuentan las columnas de los DataGriview
            this.lblTotal_Codigodebarra.Text = "Datos Registrados: 0";
            this.lblTotal_Igualdad.Text = "Datos Registrados: 0";
            this.lblTotal_Impuesto.Text = "Datos Registrados: 0";
            this.lblTotal_Lotes.Text = "Datos Registrados: 0";
            this.lblTotal_Proveedor.Text = "Datos Registrados: 0";
            this.lblTotal_Ubicacion.Text = "Datos Registrados: 0";

            this.PB_Imagen.Image = Properties.Resources.Logo_Leal_Enterprise;

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBNombre.Select();
            this.TCPrincipal.SelectedIndex = 0;
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

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
        }

        private void AutoCompletar_Combobox()
        {
            try
            {
                this.CBEmpaque.DataSource = fEmpaque.Lista();
                this.CBEmpaque.ValueMember = "Codigo";
                this.CBEmpaque.DisplayMember = "Empaque";

                this.CBBodega.DataSource = fBodega.Lista();
                this.CBBodega.ValueMember = "Codigo";
                this.CBBodega.DisplayMember = "Bodega";

                this.CBGrupo.DataSource = fGrupo.Lista();
                this.CBGrupo.ValueMember = "Codigo";
                this.CBGrupo.DisplayMember = "Grupo";

                this.CBMarca.DataSource = fMarca.Lista();
                this.CBMarca.ValueMember = "Codigo";
                this.CBMarca.DisplayMember = "Marca";

                this.CBTipo.DataSource = fTipoDeProducto.Lista();
                this.CBTipo.ValueMember = "Codigo";
                this.CBTipo.DisplayMember = "Tipo";
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void setProveedor(string idproveedor, string proveedor, string documento)
        {
            this.TBIdproveedor.Text = idproveedor;
            this.TBProveedor.Text = proveedor;
            this.TBProveedor_Documento.Text = documento;
        }
                
        private void Validaciones_SQL()
        {
            //Se valida el valor de los checbox que se encuentran en el panel de datos basicos
            //En el cual si este esta seleccionado su valor sera 1 y si no esta seleccionado este seria 0

            if (CBVencimiento.Checked)
            {
                this.Checkbox_Vencimiento = "1";
            }
            else
            {
                this.Checkbox_Vencimiento = "0";
            }

            if (CBImpuesto.Checked)
            {
                this.Checkbox_Impuesto = "1";
            }
            else
            {
                this.Checkbox_Impuesto = "0";
            }

            if (CBImportado.Checked)
            {
                this.Checkbox_Importado = "1";
            }
            else
            {
                this.Checkbox_Importado = "0";
            }

            if (CBExportado.Checked)
            {
                this.Checkbox_Exportado = "1";
            }
            else
            {
                this.Checkbox_Exportado = "0";
            }

            if (CBOfertable.Checked)
            {
                this.Checkbox_Ofertable = "1";
            }
            else
            {
                this.Checkbox_Ofertable = "0";
            }
            
            if (CBManejaComision.Checked)
            {
                this.Checkbox_Comision = "1";
            }
            else
            {
                this.Checkbox_Comision = "0";
            }

            //
            if (DGDetalles_Ubicacion.Rows.Count == 0)
            {
                this.Tran_Ubicacion = "1";
            }
            else
            {
                this.Tran_Ubicacion = "0";
            }

            if (DGDetalles_Lotes.Rows.Count == 0)
            {
                this.Tran_Lote = "1";
            }
            else
            {
                this.Tran_Lote = "0";
            }

            if (DGDetalle_CodigoDeBarra.Rows.Count == 0)
            {
                this.Tran_CodBarra = "1";
            }
            else
            {
                this.Tran_CodBarra = "0";
            }

            if (DGDetalle_Igualdad.Rows.Count == 0)
            {
                this.Tran_Igualdad = "1";
            }
            else
            {
                this.Tran_Igualdad = "0";
            }

            if (DGDetalle_Impuesto.Rows.Count == 0)
            {
                this.Tran_Impuesto = "1";
            }
            else
            {
                this.Tran_Impuesto = "0";
            }

            if (DGDetalle_Proveedor.Rows.Count==0)
            {
                this.Tran_Proveedor = "1";
            }
            else
            {
                this.Tran_Proveedor = "0";
            }
        }

        private void Diseño_TablasGenerales()
        {
            try
            {
                //Panel Ubicacion
                this.DtDetalle_Ubicacion = new DataTable();
                this.DtDetalle_Ubicacion.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Ubicacion.Columns.Add("Idbodega", System.Type.GetType("System.Int32"));
                this.DtDetalle_Ubicacion.Columns.Add("Ubicacion", System.Type.GetType("System.String"));
                this.DtDetalle_Ubicacion.Columns.Add("Estante", System.Type.GetType("System.String"));
                this.DtDetalle_Ubicacion.Columns.Add("Nivel", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalles_Ubicacion.DataSource = DtDetalle_Ubicacion;

                //Panel Lote
                this.DtDetalle_Lote = new DataTable();
                this.DtDetalle_Lote.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Lote.Columns.Add("Lote", System.Type.GetType("System.String"));
                this.DtDetalle_Lote.Columns.Add("Stock", System.Type.GetType("System.String"));
                this.DtDetalle_Lote.Columns.Add("Valor de Compra", System.Type.GetType("System.String"));
                this.DtDetalle_Lote.Columns.Add("Valor de Venta", System.Type.GetType("System.String"));
                this.DtDetalle_Lote.Columns.Add("Vencimiento", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalles_Lotes.DataSource = this.DtDetalle_Lote;

                //Panel Codigo de Barra
                this.DtDetalle_CodigoDeBarra = new DataTable();
                this.DtDetalle_CodigoDeBarra.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_CodigoDeBarra.Columns.Add("Codigo de Barra", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_CodigoDeBarra.DataSource = this.DtDetalle_CodigoDeBarra;

                //Panel Proveedores
                this.DtDetalle_Proveedor = new DataTable();
                this.DtDetalle_Proveedor.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Proveedor.Columns.Add("Idproveedor", System.Type.GetType("System.Int32"));
                this.DtDetalle_Proveedor.Columns.Add("Proveedor", System.Type.GetType("System.String"));
                this.DtDetalle_Proveedor.Columns.Add("Documento", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Proveedor.DataSource = this.DtDetalle_Proveedor;

                //Panel Impuesto
                this.DtDetalle_Impuesto = new DataTable();
                this.DtDetalle_Impuesto.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Impuesto.Columns.Add("Idimpuesto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Impuesto.Columns.Add("Impuesto", System.Type.GetType("System.String"));
                this.DtDetalle_Impuesto.Columns.Add("Valor", System.Type.GetType("System.Int32"));
                this.DtDetalle_Impuesto.Columns.Add("Descripcion", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Impuesto.DataSource = this.DtDetalle_Impuesto;

                //Panel Igualdad
                this.DtDetalle_Igualdad = new DataTable();
                this.DtDetalle_Igualdad.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Igualdad.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle_Igualdad.Columns.Add("Producto", System.Type.GetType("System.String"));
                this.DtDetalle_Igualdad.Columns.Add("Marca", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Igualdad.DataSource = this.DtDetalle_Igualdad;
                

                //Medidas de las Columnas - Codigo de Barra
                //this.DGDetalle_CodigoDeBarra.Columns[1].Width = 370;

                this.DGDetalle_Proveedor.Columns[1].Width = 270;
                this.DGDetalle_Proveedor.Columns[2].Width = 100;

                this.DGDetalles_Ubicacion.Columns[1].Width = 220;
                this.DGDetalles_Ubicacion.Columns[2].Width = 75;
                this.DGDetalles_Ubicacion.Columns[3].Width = 75;

                this.DGDetalle_Impuesto.Columns[1].Width = 270;
                this.DGDetalle_Impuesto.Columns[2].Width = 100;

                this.DGDetalle_Igualdad.Columns[1].Width = 115;
                this.DGDetalle_Igualdad.Columns[2].Width = 255;
                this.DGDetalle_Igualdad.Columns[3].Width = 100;

                this.DGDetalles_Lotes.Columns[0].Width = 80;
                this.DGDetalles_Lotes.Columns[1].Width = 80;
                this.DGDetalles_Lotes.Columns[2].Width = 130;
                this.DGDetalles_Lotes.Columns[3].Width = 130;
                this.DGDetalles_Lotes.Columns[4].Width = 130;

                //Formato de Celdas
                //this.DGDetalles_Lotes.Columns[2].DefaultCellStyle.Format = "##,##0.00";

                //************************************* Alineacion de las Celdas *************************************

                //Panel Codigo de Barra
                this.DGDetalle_CodigoDeBarra.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Proveedores
                this.DGDetalle_Proveedor.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Proveedor.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Ubicaciones
                this.DGDetalles_Ubicacion.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Ubicacion.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Ubicacion.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Impuestos
                this.DGDetalle_Impuesto.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Impuesto.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Igualdad
                this.DGDetalle_Igualdad.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Igualdad.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Igualdad.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Lotes
                this.DGDetalles_Lotes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //************************************* Aliniacion de Emcabezados *************************************

                //Panel Codigo de Barra
                this.DGDetalle_CodigoDeBarra.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Proveedores
                this.DGDetalle_Proveedor.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Proveedor.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Ubicaciones
                this.DGDetalles_Ubicacion.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Ubicacion.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Ubicacion.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Impuestos
                this.DGDetalle_Impuesto.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Impuesto.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Igualdad
                this.DGDetalle_Igualdad.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Igualdad.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Igualdad.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Lotes
                this.DGDetalles_Lotes.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles_Lotes.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //************************************* Ocultacion de Columnas *************************************
                this.DGDetalles_Lotes.Columns[0].Visible = false;
                this.DGDetalle_Igualdad.Columns[0].Visible = false;
                this.DGDetalle_Impuesto.Columns[0].Visible = false;
                this.DGDetalle_Impuesto.Columns[1].Visible = false;
                this.DGDetalle_Proveedor.Columns[0].Visible = false;
                this.DGDetalle_Proveedor.Columns[1].Visible = false;
                this.DGDetalles_Ubicacion.Columns[0].Visible = false;
                this.DGDetalles_Ubicacion.Columns[1].Visible = false;
                this.DGDetalle_CodigoDeBarra.Columns[0].Visible = false;
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
                DataTable Datos = Negocio.fProductos.AutoComplementar_SQL(0);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.TBIdproducto_AutoSQL.Text = "1";
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    Idproducto = Datos.Rows[0][0].ToString();

                    //Se procede a completar los campos de texto segun las consulta realizada anteriormente en la base de datos
                    this.TBIdproducto_AutoSQL.Text = Idproducto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        public void setImpuesto(string idimpuesto, string impuesto, string valor, string descripcion)
        {
            this.TBIdimpuesto.Text = idimpuesto;
            this.TBImpuesto.Text = impuesto;
            this.TBValor_Impuesto.Text = valor;
            this.TBDescripcion_Impuesto.Text = descripcion;
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

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBNombre.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Producto a registrar");
                }
                else if (this.TBDescripcion01.Text == Campo)
                {
                    MensajeError("Ingrese la Descripcion del Producto");
                }
                else if (this.TBCodigo.Text == Campo)
                {
                    MensajeError("Ingrese el Codigo del Producto");
                }
                else if (this.CBGrupo.SelectedIndex == 0)
                {
                    MensajeError("Seleccione el Grupo al cual pertenece el Producto");
                }
                else if (this.CBMarca.SelectedIndex == 0)
                {
                    MensajeError("Seleccione la Marca del Producto");
                }

                else
                {
                    //Parametros para poder guardar la imagen del producto

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.PB_Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] Imagen_Producto = ms.GetBuffer();

                    this.Validaciones_SQL();

                    if (this.Digitar)
                    {

                        rptaDatosBasicos = fProductos.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.CBMarca.SelectedValue), Convert.ToInt32(this.CBEmpaque.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue), Convert.ToInt32(this.CBTipo.SelectedValue),

                                 //Panel Datos Basicos
                                 this.TBCodigo.Text, this.TBNombre.Text, this.TBReferencia.Text, this.TBDescripcion01.Text, this.TBPresentacion.Text,
                                 this.CBUnidad.Text, this.TBComision_Valor.Text, Convert.ToInt32(this.TBComision_Porcentaje.Text),

                                 Convert.ToInt32(Checkbox_Vencimiento), Convert.ToInt32(Checkbox_Impuesto), Convert.ToInt32(Checkbox_Importado),
                                 Convert.ToInt32(Checkbox_Exportado), Convert.ToInt32(Checkbox_Ofertable), Convert.ToInt32(Checkbox_Comision),

                                 //Panel de Valores
                                 this.TBCompraPromedio.Text, this.TBCompraFinal.Text, this.TBValorVenta_Excento.Text, this.TBValorVenta_NoExcento.Text, this.TBVentaMayorista.Text,
                                 this.TBCosto_Fabricacion.Text, this.TBCostos_Materiales.Text, this.TBCostos_Exportacion.Text, this.TBCostos_Imprtacion.Text,
                                 this.TBCostos_Seguridad.Text, this.TBCostos_Adicional.Text,

                                 //Panel Cantidades
                                 this.TBVentaMinina_Cliente.Text, this.TBVentaMaxima_Cliente.Text, this.TBVentaMinima_Mayorista.Text, this.TBVentaMaxima_Mayorista.Text, this.TBCompraMinima_Cliente.Text, this.TBCompraMaxima_Cliente.Text, this.TBCompraMinima_Mayorista.Text, this.TBCompraMaxima_Mayorista.Text,

                                 //Tabla de Detalles - Lote, Impuesto, Igualdad, Proveedor, Ubicacion, Codigo de Barra
                                 this.DtDetalle_Lote, this.DtDetalle_Impuesto, this.DtDetalle_Igualdad, this.DtDetalle_Proveedor, this.DtDetalle_Ubicacion, this.DtDetalle_CodigoDeBarra,

                                 //Panel de Imagen
                                 Imagen_Producto,

                                 //Variables Para Confirmar el Insertar en la Transaccion en SQL
                                 //Donde esten las Validaciones IF NOT
                                 1, 1, 1, 1, 1, 1,

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Ubicacion), Convert.ToInt32(Tran_Igualdad), Convert.ToInt32(Tran_Lote), Convert.ToInt32(Tran_CodBarra),
                                 Convert.ToInt32(Tran_Proveedor), Convert.ToInt32(Tran_Impuesto),

                                //Si es igual a 1 se registraran los datos en la base de datos
                                1
                            );
                    }

                    else
                    {
                        //rptaDatosBasicos = fProductos.Editar_DatosBasicos

                        //    (
                        //         ////Llave Primaria
                        //         //Convert.ToInt32(this.TBIdproducto.Text),

                        //         ////Datos Auxiliares
                        //         //Convert.ToInt32(this.CBMarca.SelectedValue), Convert.ToInt32(this.CBEmpaque.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue), Convert.ToInt32(this.CBTipo.SelectedValue),

                        //         ////Panel Datos Basicos
                        //         //this.TBCodigo.Text, this.TBNombre.Text, this.TBReferencia.Text, this.TBDescripcion01.Text, this.TBPresentacion.Text,
                        //         //this.CBUnidad.Text, this.TBComision_Valor.Text, Convert.ToInt32(this.TBComision_Porcentaje.Text),

                        //         //Convert.ToInt32(Checkbox_Vencimiento), Convert.ToInt32(Checkbox_Impuesto), Convert.ToInt32(Checkbox_Importado),
                        //         //Convert.ToInt32(Checkbox_Exportado), Convert.ToInt32(Checkbox_Ofertable), Convert.ToInt32(Checkbox_Comision),

                        //         ////Panel de Valores
                        //         //this.TBCompraPromedio.Text, this.TBCompraFinal.Text, this.TBValorVenta_Excento.Text, this.TBValorVenta_NoExcento.Text, this.TBVentaMayorista.Text,
                        //         //this.TBCosto_Fabricacion.Text, this.TBCostos_Materiales.Text, this.TBCostos_Exportacion.Text, this.TBCostos_Imprtacion.Text,
                        //         //this.TBCostos_Seguridad.Text, this.TBCostos_Adicional.Text,

                        //         ////Panel Cantidades
                        //         //this.TBVentaMinina_Cliente.Text, this.TBVentaMaxima_Cliente.Text, this.TBVentaMinima_Mayorista.Text, this.TBVentaMaxima_Mayorista.Text, this.TBCompraMinima_Cliente.Text, this.TBCompraMaxima_Cliente.Text, this.TBCompraMinima_Mayorista.Text, this.TBCompraMaxima_Mayorista.Text,

                        //         ////Tabla de Detalles - Lote, Impuesto, Igualdad, Proveedor, Ubicacion, Codigo de Barra
                        //         //this.DtDetalle_Lote, this.DtDetalle_Impuesto, this.DtDetalle_Igualdad, this.DtDetalle_Proveedor, this.DtDetalle_Ubicacion, this.DtDetalle_CodigoDeBarra,

                        //         ////Panel de Imagen
                        //         //Imagen_Producto,


                        //         ////Si es igual a 2 se Editaran los datos en la base de datos
                        //         //2
                        //    );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Registro Exitoso");
                        }

                        else
                        {
                            this.MensajeOk("Registro Actualizado");
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
                            Eliminacion = Convert.ToInt32(DGResultados.CurrentRow.Cells["ID"].Value.ToString());
                            Respuesta = Negocio.fProductos.Eliminar(Eliminacion, 1);
                        }

                        if (Respuesta.Equals("OK"))
                        {
                            this.MensajeOk("Registro Eliminado Correctamente");
                        }
                        else
                        {
                            this.MensajeError(Respuesta);
                        }
                    }

                    //
                    this.TBBuscar.Clear();

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

        private void btnAgregar_Ubicacion_Click(object sender, EventArgs e)
        
        {
            try
            {
                if (Digitar)
                {
                    if (this.CBBodega.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor seleccione la Bodega perteneciente a la Ubicación que desea generar");
                    }
                    else if (this.TBUbicacion.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ubicación dentro de la Bodega seleccionada");
                        this.TBUbicacion.Select();
                    }
                    else
                    {

                        DataRow fila = this.DtDetalle_Ubicacion.NewRow();
                        fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                        fila["Idbodega"] = Convert.ToInt32(this.CBBodega.SelectedValue);
                        fila["Ubicacion"] = this.TBUbicacion.Text;
                        fila["Estante"] = this.TBEstante.Text;
                        fila["Nivel"] = this.TBNivel.Text;
                        this.DtDetalle_Ubicacion.Rows.Add(fila);

                        //
                        this.CBBodega.SelectedIndex = 0;
                        this.TBUbicacion.Clear();
                        this.TBEstante.Clear();
                        this.TBNivel.Clear();
                    }
                }
                else
                {
                    if (this.CBBodega.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor seleccione la Bodega perteneciente a la Ubicación que desea generar");
                    }
                    else if (this.TBUbicacion.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ubicación dentro de la Bodega seleccionada");
                        this.TBUbicacion.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar la Ubicacion del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fProductos.Guardar_Ubicacion

                                    (
                                         //Datos Basicos
                                         Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(this.CBBodega.SelectedValue), this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text,

                                        //Datos Auxiliares
                                        1
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("La Ubicación del Producto: " + TBNombre.Text + " con Codigo: " + this.TBCodigo.Text + " a Sido Registrada Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.CBBodega.SelectedIndex = 0;
                            this.TBUbicacion.Clear();
                            this.TBEstante.Clear();
                            this.TBNivel.Clear();
                        }
                        else
                        {
                            this.TBUbicacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Ubicacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Ubicacion)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Eliminacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalles_Ubicacion.SelectedRows.Count > 0)
                            {
                                Eliminacion = Convert.ToInt32(DGDetalles_Ubicacion.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Respuesta = Negocio.fProductos.Eliminar_Ubicacion(Eliminacion, 2);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalles_Ubicacion.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Ubicacion.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Ubicacion.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la Ubicacion que desea Remover del registo");
            }
        }

        private void btnAgregar_CodigoDeBarra_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBCodigodeBarra.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Codigo de Barra que desea agregar");
                        this.TBCodigodeBarra.Select();
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_CodigoDeBarra.Rows)
                        {
                            if (Convert.ToString(Fila["Codigo de Barra"]) == TBCodigodeBarra.Text)
                            {
                                this.MensajeError("El Codigo de Barra que desea agregar ya se encuentra en la lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_CodigoDeBarra.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            fila["Codigo de Barra"] = this.TBCodigodeBarra.Text;
                            this.DtDetalle_CodigoDeBarra.Rows.Add(fila);
                        }

                        //
                        this.TBCodigodeBarra.Clear();
                    }
                }
                else
                {
                    string rptaDatosBasicos = "";

                    if (this.TBCodigodeBarra.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Codigo de Barra que desea agregar");
                        this.TBCodigodeBarra.Select();
                    }
                    else
                    {
                        foreach (DataRow Fila in DtDetalle_CodigoDeBarra.Rows)
                        {
                            if (Convert.ToString(Fila["Codigo de Barra"]) == TBCodigodeBarra.Text)
                            {
                                this.MensajeError("El Codigo de Barra que desea agregar ya se encuentra en la lista");
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Codigo de Barra a la Lista?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProductos.Guardar_CodigoDeBarra

                            (
                                 //Datos Basicos
                                 Convert.ToInt32(this.TBIdproducto.Text), this.TBCodigodeBarra.Text,

                                //Datos Auxiliares
                                3
                            );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Codigo de Barra: " + TBCodigodeBarra.Text + " del Producto: " + this.TBNombre.Text + " a Sido Agregado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }
                        }
                        else
                        {
                            this.TBCodigodeBarra.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_CodigosDeBarra_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Proveedor)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Eliminacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Proveedor.SelectedRows.Count > 0)
                            {
                                Eliminacion = Convert.ToInt32(DGDetalle_Proveedor.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Respuesta = Negocio.fProductos.Eliminar_CodigoDeBara(Eliminacion, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_CodigoDeBarra.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_CodigoDeBarra.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_CodigoDeBarra.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione el Codigo de Barra que desea Remover del registo");
            }
        }
        
        private void btnAgregar_Lotes_Click(object sender, EventArgs e)
        {

        }

        //******************** FOCUS ENTER  DATOS BASICOS ********************

        private void TBCodigo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCodigo.Text == Campo)
            {
                this.TBCodigo.BackColor = Color.Azure;
                this.TBCodigo.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCodigo.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCodigo.BackColor = Color.Azure;
                this.TBCodigo.ForeColor = Color.FromArgb(0, 0, 0);
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

        private void TBReferencia_Enter(object sender, EventArgs e)
        {
            this.TBReferencia.BackColor = Color.Azure;
        }

        private void TBDescripcion01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDescripcion01.Text == Campo)
            {
                this.TBDescripcion01.BackColor = Color.Azure;
                this.TBDescripcion01.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDescripcion01.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDescripcion01.BackColor = Color.Azure;
                this.TBDescripcion01.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBPresentacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBPresentacion.Text == Campo)
            {
                this.TBPresentacion.BackColor = Color.Azure;
                this.TBPresentacion.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBPresentacion.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBPresentacion.BackColor = Color.Azure;
                this.TBPresentacion.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        //******************** FOCUS ENTER Valores ********************
        
        private void TBValor01_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBValorVenta_NoExcento.BackColor = Color.Azure;
        }

        private void TBCantidadMininaCliente_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBVentaMinina_Cliente.BackColor = Color.Azure;
        }

        private void TBCantidadMaximaCliente_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBVentaMaxima_Cliente.BackColor = Color.Azure;
        }
        
        //******************** FOCUS ENTER UBICACION ********************
        private void TBUbicacion_Enter(object sender, EventArgs e)
        {
            this.TBUbicacion.BackColor = Color.Azure;
        }

        private void TBEstante_Enter(object sender, EventArgs e)
        {
            this.TBEstante.BackColor = Color.Azure;
        }

        private void TBNivel_Enter(object sender, EventArgs e)
        {
            this.TBNivel.BackColor = Color.Azure;
        }

        //******************** FOCUS ENTER PRECIOS ********************

        private void TBCompraPromedio_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCompraPromedio.Text == string.Empty)
            {
                this.TBCompraPromedio.BackColor = Color.Azure;
                this.TBCompraPromedio.ForeColor = Color.FromArgb(0, 0, 0);
            }
            else 
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCompraPromedio.BackColor = Color.Azure;
                this.TBCompraPromedio.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBValorParaComision_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBComision_Valor.BackColor = Color.Azure;
        }

        private void TBValordecompra_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBCompraFinal.BackColor = Color.Azure;
        }
        
        private void TBVentaMayorista_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBVentaMayorista.BackColor = Color.Azure;
        }

        private void TBMinimoMayorista_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBVentaMinima_Mayorista.BackColor = Color.Azure;
        }

        private void TBMaximoMayorista_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBVentaMaxima_Mayorista.BackColor = Color.Azure;
        }

        //******************** FOCUS LEAVE DATOS BASICOS ********************
        private void TBCodigo_Leave(object sender, EventArgs e)
        {
            if (TBCodigo.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCodigo.Text = Campo;
                this.TBCodigo.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

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

        private void TBReferencia_Leave(object sender, EventArgs e)
        {
            this.TBReferencia.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDescripcion01_Leave(object sender, EventArgs e)
        {
            if (TBDescripcion01.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDescripcion01.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDescripcion01.Text = Campo;
                this.TBDescripcion01.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                TBDescripcion01.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBPresentacion_Leave(object sender, EventArgs e)
        {
            if (TBPresentacion.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBPresentacion.BackColor = Color.FromArgb(3, 155, 229);
                this.TBPresentacion.Text = Campo;
                this.TBPresentacion.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                TBPresentacion.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        //************************ SALTO DE LINEAS - PANEL DATOS BASICOS ************************

        private void TBCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBNombre.Select();
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
                                //Llamada de Clase
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
                            this.TBCodigo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCodigo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBReferencia.Select();
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
                                //Llamada de Clase
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
                            this.TBNombre.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void TBReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDescripcion01.Select();
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
                                //Llamada de Clase
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
                            this.TBDescripcion01.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDescripcion01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDescripcion01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBPresentacion.Select();
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
                                //Llamada de Clase
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
                            this.TBDescripcion01.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBDescripcion01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBPresentacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    if (CBManejaComision.Checked)
                    {
                        this.TBComision_Porcentaje.Select();
                    }
                    else
                    {
                        this.TBNombre.Select();
                    }                    
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
                                //Llamada de Clase
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
                            this.TBPresentacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBPresentacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //************************ SALTO DE LINEAS - PANEL VALORES ************************

        private void TBCompraPromedio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente
                    this.TBCompraFinal.Select();
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
                                //Llamada de Clase
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
                            this.TBCompraPromedio.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCompraPromedio.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void TBValorVenta_SinImpuesto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    if (CBImpuesto.Checked)
                    {
                        this.TBValorVenta_NoExcento.Select();
                    }
                    else
                    {
                        this.TBVentaMayorista.Select();
                    }
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
                                //Llamada de Clase
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
                            this.TBValorVenta_Excento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBValorVenta_Excento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorFinal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBValorVenta_Excento.Select();
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
                                //Llamada de Clase
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
                            this.TBCompraFinal.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCompraFinal.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        
        private void TBValorVenta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBVentaMayorista.Select();
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
                                //Llamada de Clase
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
                            this.TBValorVenta_NoExcento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBValorVenta_NoExcento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCantidadMininaCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBVentaMaxima_Cliente.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMinina_Cliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMinina_Cliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCantidadMaximaCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBVentaMinima_Mayorista.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMaxima_Cliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMaxima_Cliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBOtrosGastos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCompraFinal.Select();
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
                                //Llamada de Clase
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
                            //this.TBOtrosGastos.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            //this.TBOtrosGastos.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //************************ SALTO DE LINEAS - PANEL UBICACIONES ************************

        private void TBUbicacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBEstante.Select();
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
                                //Llamada de Clase
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
                            this.TBUbicacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBUbicacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBEstante_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBNivel.Select();
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
                                //Llamada de Clase
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
                            this.TBEstante.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBEstante.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBNivel_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBUbicacion.Select();
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
                                //Llamada de Clase
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
                            this.TBNivel.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBNivel.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //************************ SALTO DE LINEAS - PANEL LOTES ************************

        private void TBLotedeingreso_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBValor_Lote.Select();
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
                                //Llamada de Clase
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
                            this.TBLotedeingreso.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBLotedeingreso.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor_Lote_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBLote_Venta.Select();
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
                                //Llamada de Clase
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
                            this.TBValor_Lote.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBValor_Lote.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBVencimiento_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBImpuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CBImpuesto.Checked)
            {
                this.TBValorVenta_NoExcento.Enabled = true;
            }
            else
            {
                this.TBValorVenta_NoExcento.Enabled = false;
            }
        }

        private void TBValorFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBLote_Venta_Enter(object sender, EventArgs e)
        {
            this.TBLote_Venta.BackColor = Color.Azure;
        }

        private void TBLote_Stock_Enter(object sender, EventArgs e)
        {
            this.TBLote_Cantidad.BackColor = Color.Azure;
        }

        private void TBLote_Venta_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBLote_Venta.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBLote_Stock_Leave(object sender, EventArgs e)
        {
            this.TBLote_Cantidad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBuscar_Proveedor_Enter(object sender, EventArgs e)
        {
            this.TBProveedor.BackColor = Color.Azure;
        }

        private void TBBuscar_Proveedor_Leave(object sender, EventArgs e)
        {
            this.TBProveedor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void btnAgregar_Igualdad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBIgualdad_Producto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Producto o Servicio de Igualdad que desea Agregar");
                        this.TBIgualdad_Producto.Select();
                    }
                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Igualdad.Rows)
                        {
                            if (Convert.ToString(Fila["Codigo"]) == TBIdigualdad_Producto.Text)
                            {
                                this.MensajeError("El producto o servicio que desea agregar ya se encuentra en la lista");
                                this.TBIdigualdad_Producto.Clear();
                            }
                            else if (Convert.ToString(Fila["Producto"]) == TBIdigualdad_Producto.Text)
                            {
                                this.MensajeError("El producto o servicio que desea agregar ya se encuentra en la lista");
                                this.TBIdigualdad_Producto.Clear();
                            }
                        }

                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Igualdad.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto.Text);
                            fila["Codigo"] = this.TBUbicacion.Text;
                            fila["Producto"] = this.TBEstante.Text;
                            fila["Marca"] = this.TBNivel.Text;
                            this.DtDetalle_Igualdad.Rows.Add(fila);
                        }

                        //
                        this.TBIgualdad_Producto.Clear();
                    }
                }
                else
                {
                    if (this.TBIgualdad_Producto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Producto o Servicio de Igualdad que desea Agregar");
                        this.TBIgualdad_Producto.Select();
                    }
                    else
                    {
                        foreach (DataRow Fila in DtDetalle_Igualdad.Rows)
                        {
                            if (Convert.ToString(Fila["Codigo"]) == TBIgualdad_Producto.Text)
                            {
                                this.MensajeError("El producto o servicio que desea agregar ya se encuentra en la lista");
                                this.TBIgualdad_Producto.Clear();
                            }
                            else if (Convert.ToString(Fila["Producto"]) == TBIgualdad_Producto.Text)
                            {
                                this.MensajeError("El producto o servicio que desea agregar ya se encuentra en la lista");
                                this.TBIgualdad_Producto.Clear();
                            }
                        }

                        if (this.TBIgualdad_Producto.Text == String.Empty)
                        {
                            this.MensajeError("Por favor Especifique el Producto o Servicio de Igualdad que desea Agregar");
                            this.TBIgualdad_Producto.Select();
                        }
                        else
                        {
                            string rptaDatosBasicos = "";

                            DialogResult result = MessageBox.Show("¿Desea Añadir el Producto de Igualdad la Lista del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (result == DialogResult.Yes)
                            {
                                rptaDatosBasicos = fProductos.Guardar_Igualdad

                                (
                                     //Datos Basicos
                                     Convert.ToInt32(this.TBIdproducto.Text), this.TBCodigo.Text, this.TBIgualdad_Producto.Text, this.TBIgualdad_Marca.Text,
                                    //Datos Auxiliares
                                    5
                                );

                                if (rptaDatosBasicos.Equals("OK"))
                                {
                                    this.MensajeOk("El Producto de Igualdad: " + TBIgualdad_Producto.Text + " a Sido Agregado Exitosamente");
                                }

                                else
                                {
                                    this.MensajeError(rptaDatosBasicos);
                                }

                                //
                                this.TBIdigualdad_Producto.Clear();
                                this.TBIgualdad_Producto.Clear();
                                this.TBIgualdad_Codigo.Clear();
                                this.TBIgualdad_Marca.Clear();
                            }
                            else
                            {
                                this.TBIgualdad_Producto.Select();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Impuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBImpuesto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Impuesto que Desea Agregar");
                        this.TBImpuesto.Select();
                    }
                    else if (this.TBValor_Impuesto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Valor del Impuesto que Desea Agregar");
                        this.TBValor_Impuesto.Select();
                    }
                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Impuesto.Rows)
                        {
                            if (Convert.ToString(Fila["idimpuesto"]) == TBIdimpuesto.Text)
                            {
                                this.MensajeError("El Impuesto que desea agregar ya se encuentra en la lista");
                                this.TBIdimpuesto.Clear();
                                this.TBImpuesto.Clear();
                                this.TBValor_Impuesto.Clear();
                                this.TBDescripcion_Impuesto.Clear();
                            }
                        }

                        if (agregar)
                        {
                            DataRow Fila_Imp = this.DtDetalle_Impuesto.NewRow();
                            Fila_Imp["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            Fila_Imp["Idimpuesto"] = Convert.ToInt32(this.TBIdimpuesto.Text);
                            Fila_Imp["Impuesto"] = this.TBImpuesto.Text;
                            Fila_Imp["Valor"] = Convert.ToInt32(this.TBValor_Impuesto.Text);
                            Fila_Imp["Descripcion"] = this.TBDescripcion_Impuesto.Text;
                            this.DtDetalle_Impuesto.Rows.Add(Fila_Imp);

                            //
                            this.TBIdimpuesto.Clear();
                            this.TBImpuesto.Clear();
                            this.TBValor_Impuesto.Clear();
                            this.TBDescripcion_Impuesto.Clear();
                        }
                    }
                }
                else
                {
                    string rptaDatosBasicos = "";

                    if (this.TBImpuesto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Impuesto que Desea Agregar");
                        this.TBImpuesto.Select();
                    }
                    else if (this.TBValor_Impuesto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Valor del Impuesto que Desea Agregar");
                        this.TBValor_Impuesto.Select();
                    }
                    else
                    {
                        foreach (DataRow Fila in DtDetalle_Impuesto.Rows)
                        {
                            if (Convert.ToString(Fila["idimpuesto"]) == TBIdimpuesto.Text)
                            {
                                this.MensajeError("El Impuesto que desea agregar ya se encuentra en la lista");
                                this.TBIdimpuesto.Clear();
                                this.TBImpuesto.Clear();
                                this.TBValor_Impuesto.Clear();
                                this.TBDescripcion_Impuesto.Clear();
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Impuesto la Lista del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProductos.Guardar_Impuesto

                            (
                                 //Datos Basicos
                                 Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(TBIdimpuesto.Text), this.TBImpuesto.Text, this.TBValor_Impuesto.Text, this.TBDescripcion_Impuesto.Text,
                                //Datos Auxiliares
                                2
                            );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Impueto: " + TBImpuesto.Text + " con Codigo: " + this.TBCodigo.Text + " a Sido Agregado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdimpuesto.Clear();
                            this.TBImpuesto.Clear();
                            this.TBValor_Impuesto.Clear();
                            this.TBDescripcion_Impuesto.Clear();
                        }
                        else
                        {
                            this.TBImpuesto.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Proveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBProveedor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Proveedor que desea Agregar");
                        this.TBProveedor.Select();
                    }
                    else if (this.TBProveedor_Documento.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Documento del Proveedor que Desea Agregar");
                        this.TBProveedor_Documento.Select();
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Proveedor.Rows)
                        {
                            if (Convert.ToString(Fila["Codigo"]) == TBIgualdad_Producto.Text)
                            {
                                this.MensajeError("El producto o servicio que desea agregar ya se encuentra en la lista");
                            }
                            else if (Convert.ToString(Fila["Producto"]) == TBIgualdad_Producto.Text)
                            {
                                this.MensajeError("El producto o servicio que desea agregar ya se encuentra en la lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Proveedor.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            fila["Idproveedor"] = Convert.ToInt32(this.TBIdproveedor.Text);
                            fila["Proveedor"] = this.TBProveedor.Text;
                            fila["Documento"] = this.TBProveedor_Documento.Text;
                            this.DtDetalle_Proveedor.Rows.Add(fila);
                        }

                        //
                        this.TBProveedor.Clear();
                        this.TBProveedor_Documento.Clear();
                    }
                }
                else
                {
                    string rptaDatosBasicos = "";

                    // <<<<<<------ Panel Datos Basicos ------>>>>>

                    if (this.TBProveedor.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Nombre del Proveedor que Desea Agregar");
                        this.TBProveedor.Select();
                    }
                    else if (this.TBProveedor_Documento.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Documento del Proveedor que Desea Agregar");
                        this.TBProveedor_Documento.Select();
                    }

                    else
                    {
                        foreach (DataRow Fila in DtDetalle_Proveedor.Rows)
                        {
                            if (Convert.ToString(Fila["Idproveedor"]) == TBIdproveedor.Text)
                            {
                                this.MensajeError("El Proveedor que desea agregar ya se encuentra en la lista");
                                this.TBProveedor.Clear();
                                this.TBProveedor_Documento.Clear();
                            }
                            else if (Convert.ToString(Fila["Idproveedor"]) == TBIdproveedor.Text)
                            {
                                this.MensajeError("El Proveedor que desea agregar ya se encuentra en la lista");
                                this.TBProveedor.Clear();
                                this.TBProveedor_Documento.Clear();
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Proveedor a la Lista del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProductos.Guardar_Proveedor

                                (
                                     //Datos Basicos
                                     Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(this.TBIdproveedor.Text), this.TBProveedor.Text, this.TBProveedor_Documento.Text,

                                    //Datos Auxiliares
                                    4
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Proveedor: " + this.TBProveedor.Text + " del Producto: " + TBNombre.Text + " con Codigo: " + this.TBCodigo.Text + " A Sido Registrado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdproveedor.Clear();
                            this.TBProveedor.Clear();
                            this.TBProveedor_Documento.Clear();
                        }
                        else
                        {
                            this.TBProveedor.Select();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Lote_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBLotedeingreso.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el numero de Lote que desea agregar");
                        this.TBLotedeingreso.Select();
                    }
                    else if (this.TBValor_Lote.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el valor de compra del Lote que desea agregar");
                        this.TBValor_Lote.Select();
                    }
                    else if (this.TBLote_Venta.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el valor de venta del Lote que desea agregar");
                        this.TBLote_Venta.Select();
                    }
                    else if (this.TBLote_Cantidad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Cantidad de Productos que ingresaran con el Lote que desea agregar");
                        this.TBLote_Cantidad.Select();
                    }
                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Lote.Rows)
                        {
                            if (Convert.ToString(Fila["Lote"]) == TBLotedeingreso.Text)
                            {
                                this.MensajeError("El Nº de Lote que desea agregar ya se encuentra en la lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Lote.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            fila["Lote"] = this.TBLotedeingreso.Text;
                            fila["Valor de Compra"] = this.TBValor_Lote.Text;
                            fila["Valor de Venta"] = this.TBLote_Venta.Text;
                            fila["Stock"] = this.TBLote_Cantidad.Text;
                            fila["Vencimiento"] = this.DTLote_Vencimiento.Value.ToString("dd/MM/yyyy");
                            this.DtDetalle_Lote.Rows.Add(fila);
                        }

                        //
                        this.TBLotedeingreso.Clear();
                        this.TBValor_Lote.Clear();
                        this.TBLote_Venta.Clear();
                        this.TBLote_Cantidad.Clear();
                    }
                }
                else
                {
                    if (this.TBLotedeingreso.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el numero de Lote que desea agregar");
                        this.TBLotedeingreso.Select();
                    }
                    else if (this.TBValor_Lote.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el valor de compra del Lote que desea agregar");
                        this.TBValor_Lote.Select();
                    }
                    else if (this.TBLote_Venta.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el valor de venta del Lote que desea agregar");
                        this.TBLote_Venta.Select();
                    }
                    else if (this.TBLote_Cantidad.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Cantidad de Productos que ingresaran con el Lote que desea agregar");
                        this.TBLote_Cantidad.Select();
                    }
                    else
                    {
                        foreach (DataRow Fila in DtDetalle_Lote.Rows)
                        {
                            if (Convert.ToString(Fila["Lote"]) == TBLotedeingreso.Text)
                            {
                                this.MensajeError("El Nº de Lote que desea agregar ya se encuentra en la lista");
                                this.TBLotedeingreso.Select();
                            }
                        }

                        string rptaDatosBasicos = "";

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Lote a la Lista del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProductos.Guardar_Lote

                                (
                                     //Datos Basicos
                                     Convert.ToInt32(this.TBIdproducto.Text), this.TBLotedeingreso.Text, this.TBValor_Lote.Text, this.TBLote_Venta.Text, this.TBLote_Cantidad.Text, this.DTLote_Vencimiento.Value,

                                    //Datos Auxiliares
                                    6
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Lote: " + this.TBLotedeingreso.Text + " del Producto: " + TBNombre.Text + " con Codigo: " + this.TBCodigo.Text + " A Sido Registrado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBLotedeingreso.Clear();
                            this.TBValor_Lote.Clear();
                            this.TBLote_Venta.Clear();
                            this.TBLote_Cantidad.Clear();
                        }
                        else
                        {
                            this.TBLotedeingreso.Select();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Lote_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Lote)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Eliminacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalles_Lotes.SelectedRows.Count > 0)
                            {
                                Eliminacion = Convert.ToInt32(DGDetalles_Lotes.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Respuesta = Negocio.fProductos.Eliminar_Lote(Eliminacion, 7);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalles_Lotes.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Lote.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Lote.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione 'El Lote' que desea Remover del Registro");
            }
        }

        private void btnImprimir_Igualdad_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Igualdad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Igualdad)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Eliminacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Igualdad.SelectedRows.Count > 0)
                            {
                                Eliminacion = Convert.ToInt32(DGDetalle_Igualdad.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Respuesta = Negocio.fProductos.Eliminar_Igualdad(Eliminacion, 3);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Igualdad.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Igualdad.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Igualdad.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la 'Ubicacion' que desea Remover del Registro");
            }
        }

        private void TBIgualdad_Producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (e.KeyChar == Convert.ToChar(Keys.Enter))
                //{
                //    DataTable Tabla = new DataTable();
                //    Tabla = fProductos.Buscar_Igualdad(this.TBIgualdad_Producto.Text.Trim());
                //    if (Tabla.Rows.Count <= 0)
                //    {
                //        this.MensajeError("El producto el cual desea agregar no se encuentra registrado en su Base de Datos");
                //    }
                //    else
                //    {
                //        this.DetalleIgualdad_SQL
                //            (
                //                Convert.ToInt32(Tabla.Rows[0][0]),
                //                Convert.ToString(Tabla.Rows[0][1]),
                //                Convert.ToString(Tabla.Rows[0][2]),
                //                Convert.ToString(Tabla.Rows[0][3])
                //            );

                //        lblTotalIgualdad.Text = "Productos Agregados: " + Convert.ToString(DGDetalle_Igualdad.Rows.Count);

                //        //Se procede a limpiar los campos de texto utilizados para el Filtro

                //        this.TBIgualdad_Producto.Clear();
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Impuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Impuesto)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Eliminacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Impuesto.SelectedRows.Count > 0)
                            {
                                Eliminacion = Convert.ToInt32(DGDetalle_Impuesto.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Respuesta = Negocio.fProductos.Eliminar_Impuesto(Eliminacion, 4);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Impuesto.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Impuesto.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Impuesto.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione 'El Impuesto' que desea Remover del Registro");
            }
        }

        private void btnEliminar_Proveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Proveedor)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Eliminacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Proveedor.SelectedRows.Count > 0)
                            {
                                Eliminacion = Convert.ToInt32(DGDetalle_Proveedor.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Respuesta = Negocio.fProductos.Eliminar_Proveedor(Eliminacion, 5);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Registro Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Proveedor.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Proveedor.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Proveedor.Rows.Remove(row);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione 'El Proveedor' que desea Remover del Registro");
            }
        }

        private void TBCosto_Fabricacion_Enter(object sender, EventArgs e)
        {
            this.TBCosto_Fabricacion.BackColor = Color.Azure;
        }

        private void TBCostos_Materiales_Enter(object sender, EventArgs e)
        {
            this.TBCostos_Materiales.BackColor = Color.Azure;
        }

        private void TBCostos_Exportacion_Enter(object sender, EventArgs e)
        {
            this.TBCostos_Exportacion.BackColor = Color.Azure;
        }

        private void TBCostos_Imprtacion_Enter(object sender, EventArgs e)
        {
            this.TBCostos_Imprtacion.BackColor = Color.Azure;
        }

        private void TBCostos_Seguridad_Enter(object sender, EventArgs e)
        {
            this.TBCostos_Seguridad.BackColor = Color.Azure;
        }

        private void TBCostos_Adicional_Enter(object sender, EventArgs e)
        {
            this.TBCostos_Adicional.BackColor = Color.Azure;
        }

        private void TBCosto_Fabricacion_Leave(object sender, EventArgs e)
        {
            this.TBCosto_Fabricacion.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCostos_Materiales_Leave(object sender, EventArgs e)
        {
            this.TBCostos_Materiales.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCostos_Exportacion_Leave(object sender, EventArgs e)
        {
            this.TBCostos_Exportacion.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCostos_Imprtacion_Leave(object sender, EventArgs e)
        {
            this.TBCostos_Imprtacion.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCostos_Seguridad_Leave(object sender, EventArgs e)
        {
            this.TBCostos_Seguridad.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCostos_Adicional_Leave(object sender, EventArgs e)
        {
            this.TBCostos_Adicional.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCosto_Fabricacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCostos_Materiales_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCostos_Exportacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCostos_Imprtacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCostos_Seguridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCostos_Adicional_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCosto_Fabricacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCostos_Materiales.Select();
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
                                //Llamada de Clase
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
                            this.TBCosto_Fabricacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCosto_Fabricacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCostos_Exportacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCostos_Imprtacion.Select();
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
                                //Llamada de Clase
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
                            this.TBCostos_Exportacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCostos_Exportacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCostos_Imprtacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCostos_Seguridad.Select();
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
                                //Llamada de Clase
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
                            this.TBCostos_Imprtacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCostos_Imprtacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCostos_Seguridad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCostos_Adicional.Select();
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
                                //Llamada de Clase
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
                            this.TBCostos_Seguridad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCostos_Seguridad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCostos_Materiales_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCostos_Exportacion.Select();
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
                                //Llamada de Clase
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
                            this.TBCostos_Materiales.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCostos_Materiales.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCostos_Adicional_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCompraPromedio.Select();
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
                                //Llamada de Clase
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
                            this.TBCostos_Adicional.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCostos_Adicional.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnExaminar_Igualdad_Click(object sender, EventArgs e)
        {
            frmFiltro_Producto frmFiltro_Producto = new frmFiltro_Producto();
            frmFiltro_Producto.ShowDialog();
        }

        private void TBValor_Lote_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBLote_Venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBLote_Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBLote_Venta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBLote_Cantidad.Select();
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
                                //Llamada de Clase
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
                            this.TBLote_Venta.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBLote_Venta.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBLote_Stock_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBLotedeingreso.Select();
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
                                //Llamada de Clase
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
                            this.TBLote_Cantidad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBLote_Cantidad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBComision_Valor_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                this.TBNombre.Select();
            }
        }

        private void TBComision_Porcentaje_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                if (CBManejaComision.Checked)
                {
                    this.TBComision_Valor.Select();
                }
                else
                {
                    this.TBNombre.Select();
                }
            }
        }

        private void TBComision_Porcentaje_Enter(object sender, EventArgs e)
        {
            this.TBComision_Porcentaje.BackColor = Color.Azure;
        }

        private void TBComision_Valor_Enter(object sender, EventArgs e)
        {
            this.TBComision_Valor.BackColor = Color.Azure;
        }

        private void TBComision_Porcentaje_Leave(object sender, EventArgs e)
        {
            this.TBComision_Porcentaje.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBComision_Valor_Leave(object sender, EventArgs e)
        {
            this.TBComision_Valor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMinina_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBVentaMaxima_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBVentaMinima_Mayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBVentaMaxima_Mayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCompraMinima_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCompraMaxima_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCompraMinima_Mayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCompraMaxima_Mayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBVentaMinina_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBVentaMaxima_Cliente.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMinina_Cliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMinina_Cliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMaxima_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBVentaMinima_Mayorista.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMaxima_Cliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMaxima_Cliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMinima_Mayorista_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBVentaMaxima_Mayorista.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMinima_Mayorista.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMinima_Mayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMaxima_Mayorista_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCompraMinima_Cliente.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMaxima_Mayorista.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMaxima_Mayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCompraMinima_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCompraMaxima_Cliente.Select();
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
                                //Llamada de Clase
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
                            this.TBCompraMinima_Cliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCompraMinima_Cliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCompraMaxima_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCompraMinima_Mayorista.Select();
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
                                //Llamada de Clase
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
                            this.TBCompraMaxima_Cliente.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCompraMaxima_Cliente.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCompraMinima_Mayorista_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCompraMaxima_Mayorista.Select();
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
                                //Llamada de Clase
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
                            this.TBCompraMinima_Mayorista.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCompraMinima_Mayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCompraMaxima_Mayorista_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBVentaMinina_Cliente.Select();
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
                                //Llamada de Clase
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
                            this.TBCompraMaxima_Mayorista.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCompraMaxima_Mayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMinina_Cliente_Enter(object sender, EventArgs e)
        {
            this.TBVentaMinina_Cliente.BackColor = Color.Azure;
        }

        private void TBVentaMaxima_Cliente_Enter(object sender, EventArgs e)
        {
            this.TBVentaMaxima_Cliente.BackColor = Color.Azure;
        }

        private void TBVentaMinima_Mayorista_Enter(object sender, EventArgs e)
        {
            this.TBVentaMinima_Mayorista.BackColor = Color.Azure;
        }

        private void TBVentaMaxima_Mayorista_Enter(object sender, EventArgs e)
        {
            this.TBVentaMaxima_Mayorista.BackColor = Color.Azure;
        }

        private void TBCompraMinima_Cliente_Enter(object sender, EventArgs e)
        {
            this.TBCompraMinima_Cliente.BackColor = Color.Azure;
        }

        private void TBCompraMaxima_Cliente_Enter(object sender, EventArgs e)
        {
            this.TBCompraMaxima_Cliente.BackColor = Color.Azure;
        }

        private void TBCompraMinima_Mayorista_Enter(object sender, EventArgs e)
        {
            this.TBCompraMinima_Mayorista.BackColor = Color.Azure;
        }

        private void TBCompraMaxima_Mayorista_Enter(object sender, EventArgs e)
        {
            this.TBCompraMaxima_Mayorista.BackColor = Color.Azure;
        }

        private void TBVentaMinina_Cliente_Leave(object sender, EventArgs e)
        {
            this.TBVentaMinina_Cliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMaxima_Cliente_Leave(object sender, EventArgs e)
        {
            this.TBVentaMaxima_Cliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMinima_Mayorista_Leave(object sender, EventArgs e)
        {
            this.TBVentaMinima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMaxima_Mayorista_Leave(object sender, EventArgs e)
        {
            this.TBVentaMaxima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompraMinima_Cliente_Leave(object sender, EventArgs e)
        {
            this.TBCompraMinima_Cliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompraMaxima_Cliente_Leave(object sender, EventArgs e)
        {
            this.TBCompraMaxima_Cliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompraMinima_Mayorista_Leave(object sender, EventArgs e)
        {
            this.TBCompraMinima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompraMaxima_Mayorista_Leave(object sender, EventArgs e)
        {
            this.TBCompraMaxima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBIdproveedor_TextChanged(object sender, EventArgs e)
        {

        }
                
        private void btnExaminar_Proveedor_Click(object sender, EventArgs e)
        {
            frmFiltro_Proveedor frmFiltro_Proveedor = new frmFiltro_Proveedor();
            frmFiltro_Proveedor.ShowDialog();
        }

        private void TBValorVenta_SinImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBValorVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void btnEditar_Ubicacion_Click(object sender, EventArgs e)
        {
            try
            {
                //this.DtDetalle_Ubicacion.Rows.Clear();
                this.DtDetalle_Ubicacion.Clear();

                this.CBBodega.SelectedIndex = 0;
                this.TBUbicacion.Clear();
                this.TBEstante.Clear();
                this.TBNivel.Clear();

                //if (!Digitar)
                //{
                //    if (Editar == "1")
                //    {
                //        this.DtDetalle_Ubicacion.Rows.Clear();
                //        this.DtDetalle_Ubicacion.AcceptChanges();

                //        ////'Primero se limpia el dataTable
                //        //DtDetalle_Ubicacion.Clear();
                //        ////'Luego se quita la relación del dataTable con el bindingSource y se limpia
                //        //bindingSource1.DataSource = Nothing;
                //        //bindingSource1.DataSource = "";
                //        //bindingSource1.Clear();
                //        //DataGridView1.DataSource = bindingSource1; //'Se vuelve a relacionar el bindingSource vacio con el grid
                //        //DataGridView1.Columns.Clear(); //'Al final se limpian las columnas que pudieran haber

                //        //SE VALIDA SI EL DATATABLE ESTA LLENO DE L 
                //        //if (DtDetalle_Ubicacion != null)
                //        //{
                //        //    this.MensajeError("Agregue la Ubicacion o Ubicaciones que desea Establecer del Producto: " + Convert.ToString(TBNombre.Text) + " Con Codigo: " + Convert.ToString(TBCodigo.Text));
                //        //}
                //        //else
                //        //{
                //        //    rptaEditarUbicacion = fProductos.Editar_Ubicacion(Convert.ToInt32(TBIdproducto.Text), this.DtDetalle_Ubicacion, 2);
                //        //}
                //    }

                //    else
                //    {
                //        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Modificar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }

                //    //if (rptaEditarUbicacion.Equals("OK"))
                //    //{
                //    //    if (!Digitar)
                //    //    {
                //    //        this.MensajeOk("Ubicacion Actualizada");
                //    //    }
                //    //}

                //    //
                //    this.CBBodega.SelectedIndex = 0;
                //    this.TBUbicacion.Clear();
                //    this.TBEstante.Clear();
                //    this.TBNivel.Clear();
                //}
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnExaminar_Impuesto_Click(object sender, EventArgs e)
        {
            frmFiltro_Impuesto frmFiltro_Impuesto = new frmFiltro_Impuesto();
            frmFiltro_Impuesto.ShowDialog();
        }

        private void TBIdubicacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBIdimpuesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataTable Datos = Negocio.fImpuesto.BuscarExistencia_SQL(this.TBIdimpuesto.Text);
                ////Evaluamos si  existen los Datos
                //if (Datos.Rows.Count == 0)
                //{
                //    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                //    //Captura de Valores en la Base de Datos

                //    //Panel Datos Basicos - Llaves Primarias
                //    //Imp_Nombre = Datos.Rows[0][0].ToString();
                //    Imp_Valor = Datos.Rows[0][0].ToString();
                //    Imp_Descripcion = Datos.Rows[0][1].ToString();

                //    //Panel Datos Basicos
                //    this.TBValor_Impuesto.Text = Imp_Valor;
                //    this.TBDescripcion_Impuesto.Text = Imp_Descripcion;
                //    //this.TBIdimpuesto.Text = Idimpuesto;+++
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBGastodeEnvio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBValorParaComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCantidadMininaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBCantidadMaximaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBMinimoMayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBMaximoMayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void TBValorComisionar_Leave(object sender, EventArgs e)
        {
            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCompraPromedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permitir teclas de control como retroceso
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void CBProductosOfertable_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void CBImportado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBExportado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBManejaComision_CheckedChanged(object sender, EventArgs e)
        {
            if (CBManejaComision.Checked)
            {
                this.TBComision_Porcentaje.Enabled = true;
                this.TBComision_Porcentaje.BackColor = Color.FromArgb(3, 155, 229);
                
                this.TBComision_Valor.Enabled = true;
                this.TBComision_Valor.BackColor = Color.FromArgb(3, 155, 229);

                this.TBComision_Valor.Text = "0";
                this.TBComision_Porcentaje.Text = "0";
            }
            else
            {
                this.TBComision_Porcentaje.Enabled = false;
                this.TBComision_Porcentaje.BackColor = Color.FromArgb(72, 209, 204);

                this.TBComision_Valor.Enabled = false;
                this.TBComision_Valor.BackColor = Color.FromArgb(72, 209, 204);

                this.TBComision_Valor.Text = "0";
                this.TBComision_Porcentaje.Text = "0";
            }
        }

        private void TBValorGeneral_Lote_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TBMinimoMayorista_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBCompraPromedio_Leave(object sender, EventArgs e)
        {
            if (TBCompraPromedio.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCompraPromedio.BackColor = Color.FromArgb(3, 155, 229);
            }
            else
            {
                this.TBCompraPromedio.BackColor = Color.FromArgb(3, 155, 229);
                               
                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
           
        }

        private void TBVentaMayorista_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBVentaMayorista.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBComision_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBComision_Porcentaje.BackColor = Color.Azure;
        }

        private void TBComision_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBComision_Porcentaje.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMayorista_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    this.TBCosto_Fabricacion.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMayorista.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBComision_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    if (CBManejaComision.Checked)
                    {
                        //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente
                        this.TBComision_Valor.Select();
                    }
                    else
                    {
                        this.TBVentaMinina_Cliente.Select();
                    }
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
                                //Llamada de Clase
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
                            this.TBComision_Porcentaje.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBComision_Porcentaje.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorParaComision_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBVentaMinina_Cliente.Select();
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
                                //Llamada de Clase
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
                            this.TBComision_Valor.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBComision_Valor.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMinimoMayorista_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBVentaMaxima_Mayorista.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMinima_Mayorista.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMinima_Mayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMaximoMayorista_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCompraPromedio.Select();
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
                                //Llamada de Clase
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
                            this.TBVentaMaxima_Mayorista.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBVentaMaxima_Mayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorParaComision_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBComision_Valor.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCantidadMininaCliente_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBVentaMinina_Cliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCantidadMaximaCliente_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBVentaMaxima_Cliente.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMinimoMayorista_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBVentaMinima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMaximoMayorista_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBVentaMaxima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigodeBarra_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    if (TBCodigodeBarra.Text==string.Empty)
                    {
                        MensajeError("Por favor digite el Codigo de Barra que desea registrar");
                        this.TBCodigodeBarra.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //******************** FOCUS LEAVE VALORES ********************

        private void TBValordecompra_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBCompraFinal.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBValorVenta_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValorVenta_NoExcento.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBLotedeingreso_Enter(object sender, EventArgs e)
        {
            this.TBLotedeingreso.BackColor = Color.Azure;
        }

        private void TBValor_Lote_Enter(object sender, EventArgs e)
        {
            this.TBValor_Lote.BackColor = Color.Azure;
        }

        private void TBLotedeingreso_Leave(object sender, EventArgs e)
        {
            this.TBLotedeingreso.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBValor_Lote_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValor_Lote.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCodigodeBarra_Enter(object sender, EventArgs e)
        {
            this.TBCodigodeBarra.BackColor = Color.Azure;
        }

        private void TBCodigodeBarra_Leave(object sender, EventArgs e)
        {
            this.TBCodigodeBarra.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void TBValorVenta_SinImpuesto_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBValorVenta_Excento.BackColor = Color.Azure;
        }

        private void TBValorVenta_SinImpuesto_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValorVenta_Excento.BackColor = Color.FromArgb(3, 155, 229);

            // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
            TextBox tb = (TextBox)sender;

            // Primero verificamos si el valor se puede convertir a Decimal.
            double numero = default(double);
            bool bln = double.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                // No es un valor decimal válido; limpiamos el control.
                //tb.Clear();
                return;
            }

            // En la propiedad Tag guardamos el valor con todos los decimales.
            //
            tb.Tag = numero;

            // Y acto seguido formateamos el valor
            // a monetario con dos decimales.
            //
            tb.Text = string.Format("{0:N2}", numero);
        }
     
        //******************** FOCUS LEAVE UBICACION ********************
        private void TBUbicacion_Leave(object sender, EventArgs e)
        {
            this.TBUbicacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBEstante_Leave(object sender, EventArgs e)
        {
            this.TBEstante.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBNivel_Leave(object sender, EventArgs e)
        {
            this.TBNivel.BackColor = Color.FromArgb(3, 155, 229);
        }

        //******************** FOCUS LEAVE CANTIDADES ********************

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.Azure;
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void CBBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBBodega.SelectedIndex != 0)
            {
                this.TBUbicacion.Select();
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
                        this.DGResultados.DataSource = fProductos.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultados.Columns[0].Visible = false;

                        lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
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
        
        private void TBIdproducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fProductos.Buscar(this.TBIdproducto.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos - Llaves Primarias
                    Idmarca = Datos.Rows[0][0].ToString();
                    Idgrupo = Datos.Rows[0][1].ToString();
                    Idtipo = Datos.Rows[0][2].ToString();
                    Idempaque = Datos.Rows[0][3].ToString();

                    //Panel Datos Basicos
                    Codigo = Datos.Rows[0][4].ToString();
                    Nombre = Datos.Rows[0][5].ToString();
                    Referencia = Datos.Rows[0][6].ToString();
                    Descripcion = Datos.Rows[0][7].ToString();
                    Presentacion = Datos.Rows[0][8].ToString();
                    Por_Comision = Datos.Rows[0][9].ToString();
                    Val_Comision = Datos.Rows[0][10].ToString();
                    Unidad = Datos.Rows[0][11].ToString();
                    AplicaVencimiento = Datos.Rows[0][12].ToString();
                    AplicaImpuesto = Datos.Rows[0][13].ToString();
                    Importado = Datos.Rows[0][14].ToString();
                    Exportado = Datos.Rows[0][15].ToString();
                    Ofertable = Datos.Rows[0][16].ToString();
                    AplicaComision = Datos.Rows[0][17].ToString();

                    //Panel - Valores
                    Valor_Promedio = Datos.Rows[0][18].ToString();
                    ValCom_Final = Datos.Rows[0][19].ToString();
                    Valor_Excento = Datos.Rows[0][20].ToString();
                    Valor_NoExcento = Datos.Rows[0][21].ToString();
                    Valor_Mayorista = Datos.Rows[0][22].ToString();
                    Valor_Fabricacion = Datos.Rows[0][23].ToString();
                    Valor_Materiales = Datos.Rows[0][24].ToString();
                    Valor_Exportacion = Datos.Rows[0][25].ToString();
                    Valor_Importacion = Datos.Rows[0][26].ToString();
                    Valor_Seguro = Datos.Rows[0][27].ToString();
                    Valor_Otros = Datos.Rows[0][28].ToString();

                    //
                    VenMin_Cliente = Datos.Rows[0][29].ToString();
                    VenMax_Cliente = Datos.Rows[0][30].ToString();
                    VenMin_Mayorista = Datos.Rows[0][31].ToString();
                    VenMax_Mayorista = Datos.Rows[0][32].ToString();
                    ComMin_Cliente = Datos.Rows[0][33].ToString();
                    ComMax_Cliente = Datos.Rows[0][34].ToString();
                    ComMin_Mayorista= Datos.Rows[0][35].ToString();
                    ComMax_Mayorista = Datos.Rows[0][36].ToString();

                    //
                    //Imagen = Datos.Rows[0][38].ToString();

                    //Se procede a completar los campos de texto segun las consulta
                    //Realizada anteriormente en la base de datos

                    this.Marca_SQL = Idmarca;
                    this.CBMarca.SelectedValue = Marca_SQL;
                    
                    this.Grupo_SQL = Idgrupo;
                    this.CBGrupo.SelectedValue = Grupo_SQL;

                    this.Tipo_SQL = Idtipo;
                    this.CBTipo.SelectedValue = Tipo_SQL;

                    this.Empaque_SQL = Idempaque;
                    this.CBEmpaque.SelectedValue = Empaque_SQL;

                    //this.Bodega_SQL = Idbodega;
                    //this.CBBodega.SelectedValue = Bodega_SQL;

                    //Panel Datos Basicos
                    this.TBCodigo.Text = Codigo;
                    this.TBIdproveedor.Text = Idproveedor;
                    this.TBIdimpuesto.Text = Idimpuesto;

                    //Panel Datos Basicos
                    this.TBCodigo.Text = Codigo;
                    this.TBNombre.Text = Nombre;
                    this.TBReferencia.Text = Referencia;
                    this.TBDescripcion01.Text = Descripcion;
                    this.TBPresentacion.Text = Presentacion;
                    this.CBUnidad.Text = Unidad;
                    
                    //Panel - Valores
                    this.TBCompraPromedio.Text = Valor_Promedio;
                    this.TBCompraFinal.Text = ValCom_Final;
                    this.TBValorVenta_Excento.Text = Valor_Excento;
                    this.TBValorVenta_NoExcento.Text = Valor_NoExcento;
                    this.TBVentaMayorista.Text = Valor_Mayorista;
                    this.TBCosto_Fabricacion.Text = Valor_Fabricacion;
                    this.TBCostos_Materiales.Text = Valor_Materiales;
                    this.TBCostos_Exportacion.Text = Valor_Exportacion;
                    this.TBCostos_Imprtacion.Text = Valor_Importacion;
                    this.TBCostos_Seguridad.Text = Valor_Seguro;
                    this.TBCostos_Adicional.Text = Valor_Otros;

                    //
                    this.TBVentaMinina_Cliente.Text = VenMin_Cliente;
                    this.TBVentaMinima_Mayorista.Text = VenMin_Mayorista;
                    this.TBVentaMaxima_Cliente.Text = VenMax_Cliente;
                    this.TBVentaMaxima_Mayorista.Text = VenMax_Mayorista;
                    this.TBCompraMinima_Mayorista.Text = ComMin_Mayorista;
                    this.TBCompraMaxima_Mayorista.Text = ComMax_Mayorista;
                    this.TBCompraMinima_Cliente.Text = ComMin_Cliente;
                    this.TBCompraMaxima_Cliente.Text = ComMax_Cliente;

                    //Panel - Imagen
                    //this.PB_Imagen.Image = Imagen;

                    //Se proceden a Validar los Chexboxt si estan activos o no

                    if (AplicaVencimiento == "0")
                    {
                        this.CBVencimiento.Checked = false;
                    }
                    else
                    {
                        this.CBVencimiento.Checked = true;
                    }

                    if (Importado == "0")
                    {
                        this.CBImportado.Checked = false;
                    }
                    else
                    {
                        this.CBImportado.Checked = true;
                    }

                    if (Exportado == "0")
                    {
                        this.CBExportado.Checked = false;
                    }
                    else
                    {
                        this.CBExportado.Checked = true;
                    }

                    if (AplicaImpuesto == "0")
                    {
                        this.CBImpuesto.Checked = false;
                    }
                    else
                    {
                        this.CBImpuesto.Checked = true;
                    }

                    if (Ofertable == "0")
                    {
                        this.CBOfertable.Checked = false;
                    }
                    else
                    {
                        this.CBOfertable.Checked = true;
                    }

                    if (AplicaComision == "0")
                    {
                        this.CBManejaComision.Checked = false;
                    }
                    else
                    {
                        this.CBManejaComision.Checked = true;
                    }

                    //************************************************************************************************************************
                    //Se realizan las consultas para llenar los DataGriview donde se mostrarian los MultiPlex Registros.

                    this.DGDetalles_Ubicacion.DataSource = fProductos.Buscar_Ubicacion(1, Convert.ToInt32(this.TBIdproducto.Text));
                    lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);

                    this.DGDetalle_Igualdad.DataSource = fProductos.Buscar_Igualdad(1, Convert.ToInt32(this.TBIdproducto.Text));
                    lblTotal_Igualdad.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Igualdad.Rows.Count);

                    this.DGDetalle_Impuesto.DataSource = fProductos.Buscar_Impuesto(1, Convert.ToInt32(this.TBIdproducto.Text));
                    lblTotal_Impuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Impuesto.Rows.Count);
                    this.DGDetalle_Impuesto.Columns[0].Visible = false;
                    this.DGDetalle_Impuesto.Columns[1].Visible = false;

                    this.DGDetalle_Proveedor.DataSource = fProductos.Buscar_Proveedor(1, Convert.ToInt32(this.TBIdproducto.Text));
                    lblTotal_Proveedor.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Proveedor.Rows.Count);

                    this.DGDetalle_CodigoDeBarra.DataSource = fProductos.Buscar_CodigoDeBarra(1, Convert.ToInt32(this.TBIdproducto.Text));
                    lblTotal_Codigodebarra.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_CodigoDeBarra.Rows.Count);

                    this.DGDetalles_Lotes.DataSource = fProductos.Buscar_Lote(1, Convert.ToInt32(this.TBIdproducto.Text));
                    lblTotal_Lotes.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Lotes.Rows.Count);
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
                    this.Digitar = false;
                    this.TBIdproducto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["ID"].Value);
                    this.TBNombre.Select();

                    //
                    //this.Digitar = false;
                    this.Eliminar_Lote = true;
                    this.Eliminar_Igualdad = true;
                    this.Eliminar_Impuesto = true;
                    this.Eliminar_Ubicacion = true;
                    this.Eliminar_Proveedor = true;
                    this.Eliminar_CodigoDeBarra = true;

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

        private void DGResultados_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    this.Digitar = false;

                    if (Editar == "1")
                    {
                        this.TBIdproducto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["ID"].Value);
                        this.TBNombre.Select();

                        //
                        this.Digitar = false;
                        this.Eliminar_Lote = true;
                        this.Eliminar_Igualdad = true;
                        this.Eliminar_Impuesto = true;
                        this.Eliminar_Ubicacion = true;
                        this.Eliminar_Proveedor = true;
                        this.Eliminar_CodigoDeBarra = true;

                        //
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

        private void PB_Imagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.PB_Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.PB_Imagen.Image = Image.FromFile(dialog.FileName);
            }
        }
    }
}
