using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

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
        public bool Examinar_Exterior = false;
        public bool Examinar_Proveedor = false;

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
        private string Moneda = "Moneda Extranjera";

        //********** Variables para la Validacion de los checkbox en el Pane Datos Basicos**************************************

        private string Checkbox_Vencimiento, Checkbox_Ofertable, Checkbox_Impuesto = "";
        private string Checkbox_Comision, Checkbox_Exportado, Checkbox_Importado = "";
        private string Checkbox_Empaque, Checkbox_Fabricado, Checkbox_Balanza, Checkbox_Retencion = "";

        //********** Variables para la Validacion de las Transacciones en SQL **************************************************

        private string Tran_Ubicacion, Tran_Igualdad, Tran_Lote, Tran_CodBarra, Tran_Proveedor, Tran_Impuesto, Tran_Exterior, Tran_Compuesto, Tran_Stock, Tran_Retencion = "";

        //********** Variables para AutoComplementar Combobox segun la Consulta en SQL ******************************

        private string Empaque_SQL, Grupo_SQL, Marca_SQL, Tipo_SQL = "";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *********************************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Parametros para AutoCompletar los Texboxt *****************************************************************

        //Panel Datos Basicos - Llaves Primarias
        private string Idproducto, Idmarca, Idgrupo, Idtipo, Idempaque, Idbodega, Idproveedor, Idimpuesto = "";

        //Panel Datos Basicos
        private string Codigo, Nombre, Referencia, Descripcion, Presentacion, Por_Comision, Val_Comision = "";
        private string AplicaVencimiento, AplicaImpuesto, Importado, Exportado, Ofertable, AplicaComision = "";

        //Panel - Compuesto
        private string Compuesto, Compuesto_Descripcion, Compuesto_Medida = "";

        //Panel - Valores y Precio
        private string ValorCom_Promedio, ValorCom_Final, Valor_Venta01, Valor_Veenta02, Valor_Venta03, Valor_Mayorista = "";
        private string Porc_Venta01, Porc_Venta02, Porc_Valor03, Porc_Mayorista = "";
        private string ValorPorc_Valor01, ValorPorc_Valor02, ValorPorc_Valor03, ValorPorc_Mayorista = "";

        private string Unidad, Unidad_Detallada, Valor_Unidad01, Valor_Unidad02, Valor_Unidad03 = "";
        private string Porc_Unidad01, Porc_Unidad02, Porc_Unidad03 = "";
        private string ValorPorc_Unidad01, ValorPorc_Unidad02, ValorPorc_Unidad03 = "";

        //Panel - Valor de Fabricacion
        private string Fabrica_Material01, Fabrica_Material02, Fabrica_Material03, Fabrica_OtroMaterial, Fabrica_ManoDeObra, Fabrica_Materiales, Fabrica_Envio, Fabrica_Almacenamiento, Fabrica_Maquinaria, Fabrica_Herramientas, Fabrica_CostoGeneral = "";

        //Panel - Cantidades
        private string VenMin_Cliente, VenMax_Cliente, VenMin_Mayorista, VenMax_Mayorista, ComMin_Cliente, ComMax_Cliente, ComMin_Mayorista, ComMax_Mayorista = "";

        //Panel - Imagen
        private string Imagen = "";

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
            //this.TBIdproducto_AutoSQL.Visible = false;
            this.TBIdigualdad_Producto.Visible = false;
                        
            //Panel - Cantidades - Otros Datos
            this.CBUnidad.SelectedIndex = 0;

            //
            this.btnExaminar_Impuesto.Enabled = false;

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

            this.TBCodigo_Marca.ReadOnly = false;
            this.TBCodigo_Marca.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo_Grupo.ReadOnly = false;
            this.TBCodigo_Grupo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo_Tipo.ReadOnly = false;
            this.TBCodigo_Tipo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo_Empaque.ReadOnly = false;
            this.TBCodigo_Empaque.BackColor = Color.FromArgb(3, 155, 229);

            //Panel Compuesto
            this.TBCompuesto.ReadOnly = false;
            this.TBCompuesto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompuesto_Descrip.ReadOnly = false;
            this.TBCompuesto_Descrip.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Valores
            this.TBValor_CompraPromedio.ReadOnly = false;
            this.TBValor_CompraPromedio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_CompraFinal.ReadOnly = false;
            this.TBValor_CompraFinal.BackColor = Color.FromArgb(3, 155, 229);

            this.TBValor_Venta01.ReadOnly = false;
            this.TBValor_Venta01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_Venta02.ReadOnly = false;
            this.TBValor_Venta02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_Venta03.ReadOnly = false;
            this.TBValor_Venta03.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_Mayorista.ReadOnly = false;
            this.TBValor_Mayorista.BackColor = Color.FromArgb(3, 155, 229);

            this.TBValor_PorVenta01.Enabled = false;
            this.TBValor_PorVenta01.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_PorVenta02.Enabled = false;
            this.TBValor_PorVenta02.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_PorVenta03.Enabled = false;
            this.TBValor_PorVenta03.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_PorMayorista.Enabled = false;
            this.TBValor_PorMayorista.BackColor = Color.FromArgb(72, 209, 204);

            this.TBValor_ImpVenta01.Enabled = false;
            this.TBValor_ImpVenta01.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_ImpVenta02.Enabled = false;
            this.TBValor_ImpVenta02.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_ImpVenta03.Enabled = false;
            this.TBValor_ImpVenta03.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_ImpMayorista.Enabled = false;
            this.TBValor_ImpMayorista.BackColor = Color.FromArgb(72, 209, 204);

            this.TBValor_Unidad.ReadOnly = false;
            this.TBValor_Unidad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_Unidad01.ReadOnly = false;
            this.TBValor_Unidad01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_Unidad02.ReadOnly = false;
            this.TBValor_Unidad02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_Unidad03.ReadOnly = false;
            this.TBValor_Unidad03.BackColor = Color.FromArgb(3, 155, 229);

            this.TBValor_PorUnidad01.Enabled = false;
            this.TBValor_PorUnidad01.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_PorUnidad02.Enabled = false;
            this.TBValor_PorUnidad02.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_PorUnidad03.Enabled = false;
            this.TBValor_PorUnidad03.BackColor = Color.FromArgb(72, 209, 204);

            this.TBValor_ImpUnidad01.Enabled = false;
            this.TBValor_ImpUnidad01.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_ImpUnidad02.Enabled = false;
            this.TBValor_ImpUnidad02.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValor_ImpUnidad03.Enabled = false;
            this.TBValor_ImpUnidad03.BackColor = Color.FromArgb(72, 209, 204);

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
            this.TBCompraMaxima_Cliente.ReadOnly = false;
            this.TBCompraMaxima_Cliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompraMinima_Mayorista.ReadOnly = false;
            this.TBCompraMinima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompraMaxima_Mayorista.ReadOnly = false;
            this.TBCompraMaxima_Mayorista.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Exterior
            this.TBExterior_Proveedor.Enabled = false;
            this.TBExterior_Proveedor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBExterior_Aduana.ReadOnly = false;
            this.TBExterior_Aduana.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExterior_Comision.ReadOnly = false;
            this.TBExterior_Comision.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExterior_Documento.ReadOnly = false;
            this.TBExterior_Documento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExterior_Adicional.ReadOnly = false;
            this.TBExterior_Adicional.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExterior_Exportacion.ReadOnly = false;
            this.TBExterior_Exportacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExterior_Importacion.ReadOnly = false;
            this.TBExterior_Importacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExterior_Seguridad.ReadOnly = false;
            this.TBExterior_Seguridad.BackColor = Color.FromArgb(3, 155, 229);

            //
            this.TBExteriorMon_Aduana.ReadOnly = false;
            this.TBExteriorMon_Aduana.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExteriorMon_Comision.ReadOnly = false;
            this.TBExteriorMon_Comision.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExteriorMon_Documento.ReadOnly = false;
            this.TBExteriorMon_Documento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExteriorMon_Adicional.ReadOnly = false;
            this.TBExteriorMon_Adicional.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExteriorMon_Exportacion.ReadOnly = false;
            this.TBExteriorMon_Exportacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExteriorMon_Importacion.ReadOnly = false;
            this.TBExteriorMon_Importacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBExteriorMon_Seguridad.ReadOnly = false;
            this.TBExteriorMon_Seguridad.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Fabricacion
            this.TBFabri_Material01.ReadOnly = false;
            this.TBFabri_Material01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_Material02.ReadOnly = false;
            this.TBFabri_Material02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_Material03.ReadOnly = false;
            this.TBFabri_Material03.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_OtroMaterial.ReadOnly = false;
            this.TBFabri_OtroMaterial.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_ManoDeObra.ReadOnly = false;
            this.TBFabri_ManoDeObra.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_Materiales.ReadOnly = false;
            this.TBFabri_Materiales.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_Envio.ReadOnly = false;
            this.TBFabri_Envio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_Almacenamiento.ReadOnly = false;
            this.TBFabri_Almacenamiento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_Maquinaria.ReadOnly = false;
            this.TBFabri_Maquinaria.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_Manual.ReadOnly = false;
            this.TBFabri_Manual.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_TotalFabricacion.Enabled = false;
            this.TBFabri_TotalFabricacion.BackColor = Color.FromArgb(72, 209, 204);

            //Panel - Igualdad
            this.TBIgualdad_Codigo.Enabled = false;
            this.TBIgualdad_Codigo.BackColor = Color.FromArgb(72, 209, 204);
            this.TBIgualdad_Producto.ReadOnly = false;
            this.TBIgualdad_Producto.BackColor = Color.FromArgb(72, 209, 204);
            this.TBIgualdad_Marca.ReadOnly = false;
            this.TBIgualdad_Marca.BackColor = Color.FromArgb(72, 209, 204);

            //Panel - Codigo de Barra
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

            //Panel - Proveedor
            this.TBProveedor.Enabled = false;
            this.TBProveedor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBProveedor_Documento.Enabled = false;
            this.TBProveedor_Documento.BackColor = Color.FromArgb(72, 209, 204);

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

            this.CHVencimiento.Checked = false;
            this.CHImpuesto.Checked = false;
            this.CHOfertable.Checked = false;
            this.CHImportado.Checked = false;
            this.CHExportado.Checked = false;
            this.CHManejaComision.Checked = false;
            this.CHBalanza.Checked = false;
            this.CHEmpaque.Checked = false;
            this.CHRetencion.Checked = false;
            this.CHFabricado.Checked = false;

            //Panel Compuesto
            this.TBCompuesto.Clear();
            this.TBCompuesto_Descrip.Clear();

            //Panel Proveedor
            this.TBProveedor.Clear();
            this.TBProveedor_Documento.Clear();

            //Panel - Valores
            this.TBValor_CompraPromedio.Clear();
            this.TBValor_CompraFinal.Clear();

            this.TBValor_Venta01.Clear();
            this.TBValor_Venta02.Clear();
            this.TBValor_Venta03.Clear();
            this.TBValor_Mayorista.Clear();

            this.TBValor_PorVenta01.Clear();
            this.TBValor_PorVenta02.Clear();
            this.TBValor_PorVenta03.Clear();
            this.TBValor_PorMayorista.Clear();

            this.TBValor_ImpVenta01.Clear();
            this.TBValor_ImpVenta02.Clear();
            this.TBValor_ImpVenta03.Clear();
            this.TBValor_ImpMayorista.Clear();

            this.TBValor_Unidad.Clear();
            this.TBValor_Unidad01.Clear();
            this.TBValor_Unidad02.Clear();
            this.TBValor_Unidad03.Clear();

            this.TBValor_PorUnidad01.Clear();
            this.TBValor_PorUnidad02.Clear();
            this.TBValor_PorUnidad03.Clear();

            this.TBValor_ImpUnidad01.Clear();
            this.TBValor_ImpUnidad02.Clear();
            this.TBValor_ImpUnidad03.Clear();

            // Panel Cantidades
            this.TBVentaMaxima_Mayorista.Clear();
            this.TBVentaMinima_Mayorista.Clear();
            this.TBVentaMinina_Cliente.Clear();
            this.TBVentaMaxima_Cliente.Clear();

            this.TBCompraMinima_Cliente.Clear();
            this.TBCompraMaxima_Cliente.Clear();
            this.TBCompraMinima_Mayorista.Clear();
            this.TBCompraMaxima_Mayorista.Clear();

            //Panel Exterior
            this.TBExterior_Proveedor.Clear();
            this.TBExterior_Aduana.Clear();
            this.TBExterior_Comision.Clear();
            this.TBExterior_Documento.Clear();
            this.TBExterior_Adicional.Clear();
            this.TBExterior_Exportacion.Clear();
            this.TBExterior_Importacion.Clear();
            this.TBExterior_Seguridad.Clear();

            //
            this.TBExteriorMon_Aduana.Clear();
            this.TBExteriorMon_Comision.Clear();
            this.TBExteriorMon_Documento.Clear();
            this.TBExteriorMon_Adicional.Clear();
            this.TBExteriorMon_Exportacion.Clear();
            this.TBExteriorMon_Importacion.Clear();
            this.TBExteriorMon_Seguridad.Clear();

            //Panel Fabricacion
            this.TBFabri_Material01.Clear();
            this.TBFabri_Material02.Clear();
            this.TBFabri_Material03.Clear();
            this.TBFabri_OtroMaterial.Clear();
            this.TBFabri_ManoDeObra.Clear();
            this.TBFabri_Materiales.Clear();
            this.TBFabri_Envio.Clear();
            this.TBFabri_Almacenamiento.Clear();
            this.TBFabri_Maquinaria.Clear();
            this.TBFabri_Manual.Clear();
            this.TBFabri_TotalFabricacion.Clear();

            //Panel Igualdad
            this.TBIgualdad_Codigo.Clear();
            this.TBIgualdad_Producto.Clear();
            this.TBIgualdad_Marca.Clear();

            //Panel Codigo de Barra
            this.TBCodigodeBarra.Clear();

            //Panel - Ubicacion
            this.TBUbicacion.Clear();
            this.TBEstante.Clear();
            this.TBNivel.Clear();

            //Panel - Impuestos
            this.TBImpuesto.Clear();
            this.TBValor_Impuesto.Clear();
            this.TBDescripcion_Impuesto.Clear();

            //Panel - Lote
            this.TBLotedeingreso.Clear();
            this.TBValor_Lote.Clear();
            this.TBLote_Venta.Clear();
            this.TBLote_Cantidad.Clear();

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
                this.btnGuardar.Text = "Guardar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;

                this.btnModificar_CodigoDeBarra.Enabled = false;
                this.btnModificar_Lote.Enabled = false;
                this.btnModificar_Ubicacion.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;

                this.btnModificar_CodigoDeBarra.Enabled = true;
                this.btnModificar_Lote.Enabled = true;
                this.btnModificar_Ubicacion.Enabled = true;
            }
        }

        private void AutoCompletar_Combobox()
        {
            try
            {
                this.CBEmpaque.DataSource = fEmpaque.Lista();
                this.CBEmpaque.ValueMember = "Codigo";
                this.CBEmpaque.DisplayMember = "Empaque";

                //this.CBBodega.DataSource = fBodega.Lista();
                //this.CBBodega.ValueMember = "Codigo";
                //this.CBBodega.DisplayMember = "Bodega";

                this.CBGrupo.DataSource = fGrupoDeProducto.Lista();
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

        private void Actualizar_DetCodigoDeBarra()
        {
            this.DGDetalle_CodigoDeBarra.DataSource = fProducto_Inventario.Lista_CodigoDeBarra(1, Convert.ToInt32(TBIdproducto.Text));
            this.lblTotal_Codigodebarra.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_CodigoDeBarra.Rows.Count);
        }

        private void Actualizar_DetIgualdad()
        {
            this.DGDetalle_Igualdad.DataSource = fProducto_Inventario.Lista_Igualdad(2, Convert.ToInt32(TBIdproducto.Text));
            this.lblTotal_Igualdad.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Igualdad.Rows.Count);
        }

        private void Actualizar_DetImpuesto()
        {
            this.DGDetalle_Impuesto.DataSource = fProducto_Inventario.Lista_Impuesto(3, Convert.ToInt32(TBIdproducto.Text));
            this.lblTotal_Impuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Impuesto.Rows.Count);
        }

        private void Actualizar_DetLote()
        {
            this.DGDetalles_Lotes.DataSource = fProducto_Inventario.Lista_Lote(4, Convert.ToInt32(TBIdproducto.Text)); ;
            this.lblTotal_Lotes.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Lotes.Rows.Count);
        }

        private void Actualizar_DetProveedor()
        {
            this.DGDetalle_Proveedor.DataSource = fProducto_Inventario.Lista_Proveedor(5, Convert.ToInt32(TBIdproducto.Text));
            this.lblTotal_Proveedor.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Proveedor.Rows.Count);
        }

        private void Actualizar_DetUbicacion()
        {
            this.DGDetalles_Ubicacion.DataSource = fProducto_Inventario.Lista_Ubicacion(6, Convert.ToInt32(TBIdproducto.Text)); ;
            this.lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);
        }

        public void setProveedor(string idproveedor, string proveedor, string documento)
        {
            this.TBIdproveedor.Text = idproveedor;
            this.TBProveedor.Text = proveedor;
            this.TBProveedor_Documento.Text = documento;
        }
        
        public void setProveedor_Exterior(string idproveedor, string proveedor, string documento)
        {
            this.TBIdproveedor.Text = idproveedor;
            this.TBProveedor.Text = proveedor;
            this.TBProveedor_Documento.Text = documento;
        }

        private void Validaciones_SQL()
        {
            //Se valida el valor de los checbox que se encuentran en el panel de datos basicos
            //En el cual si este esta seleccionado su valor sera 1 y si no esta seleccionado este seria 0

            if (CHVencimiento.Checked)
            {
                this.Checkbox_Vencimiento = "1";
            }
            else
            {
                this.Checkbox_Vencimiento = "0";
            }

            if (CHImpuesto.Checked)
            {
                this.Checkbox_Impuesto = "1";
            }
            else
            {
                this.Checkbox_Impuesto = "0";
            }

            if (CHImportado.Checked)
            {
                this.Checkbox_Importado = "1";
            }
            else
            {
                this.Checkbox_Importado = "0";
            }

            if (CHExportado.Checked)
            {
                this.Checkbox_Exportado = "1";
            }
            else
            {
                this.Checkbox_Exportado = "0";
            }

            if (CHOfertable.Checked)
            {
                this.Checkbox_Ofertable = "1";
            }
            else
            {
                this.Checkbox_Ofertable = "0";
            }

            if (CHManejaComision.Checked)
            {
                this.Checkbox_Comision = "1";
            }
            else
            {
                this.Checkbox_Comision = "0";
            }

            //Validacion de Tablas o Detalles del Producto
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

            if (DGDetalle_Proveedor.Rows.Count == 0)
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
                this.DtDetalle_Impuesto.Columns.Add("Descripción", System.Type.GetType("System.String"));
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
                this.DGDetalle_CodigoDeBarra.Columns[0].Visible = false;

                this.DGDetalle_Impuesto.Columns[0].Visible = false;
                this.DGDetalle_Impuesto.Columns[1].Visible = false;

                this.DGDetalle_Proveedor.Columns[0].Visible = false;
                this.DGDetalle_Proveedor.Columns[1].Visible = false;

                this.DGDetalles_Ubicacion.Columns[0].Visible = false;
                this.DGDetalles_Ubicacion.Columns[1].Visible = false;
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
                DataTable Datos = Negocio.fProducto_Inventario.AutoComplementar_SQL(0);
                //Evaluamos si  existen los Datos

                if (Datos.Rows.Count == 0)
                {
                    TBIdproducto_AutoSQL.Text = "1";
                    //TBCodigoID.Text = "1";
                    //MessageBox.Show("No se Encontraron Registros en la Base de Datos", "Sistema Instituto Fundecar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Calculo_Impuesto()
        {
            try
            {
                int Impuesto_SQL = 0;
                double Valor01, Valor02, Valor03, Porcentaje01, Porcentaje02, Porcentaje03, Operacion, Divisor, Multiplicador, Impuesto01;
                double Base01, Base02, Base03;


                if (CHImpuesto.Checked)
                {
                    if (DGDetalle_Impuesto.Rows.Count == 0)
                    {
                        MensajeError("Por Favor Especifique el Impuesto del Producto");
                    }
                    else
                    {
                        foreach (DataGridViewRow row in DGDetalle_Impuesto.Rows)
                        {
                            if (row.Cells[3].Value != null)
                                Impuesto_SQL += (Int32)row.Cells[3].Value;

                            //Se procede a calcular el IVA o Impuestos

                            this.TBValor_PorVenta01.Text = Impuesto_SQL.ToString();
                            this.TBValor_PorVenta02.Text = Impuesto_SQL.ToString();
                            this.TBValor_PorVenta03.Text = Impuesto_SQL.ToString();

                            this.TBDivisor_Impuesto.Text = "1." + TBValor_PorVenta01.Text;
                            this.TBmultiplicador_Impuesto.Text = "0." + TBValor_PorVenta01.Text;

                            //Se procede a calcular el IVA o Impuestos
                            Valor01 = Convert.ToDouble(TBValor_Venta01.Text);
                            Divisor = Convert.ToDouble(TBDivisor_Impuesto.Text);
                            Multiplicador = Convert.ToDouble(TBmultiplicador_Impuesto.Text);
                            //Porcentaje01 = Convert.ToDouble(this.TBValor_PorVenta01.Text);

                            //Primero se Calcula el Valor Base
                            Base01 = Valor01 / Divisor;
                            this.textBox6.Text = Base01.ToString("C");

                            //Despues se Calcula el Valor del Impuesto
                            Impuesto01 = Base01 * Multiplicador;
                            this.TBValor_ImpVenta01.Text = Impuesto01.ToString("C");
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in DGDetalle_Impuesto.Rows)
                    {
                        if (row.Cells[3].Value != null)
                            Impuesto_SQL += (Int32)row.Cells[3].Value;

                        //Se procede a calcular el IVA o Impuestos

                        this.TBValor_PorVenta01.Text = Impuesto_SQL.ToString();
                        this.TBValor_PorVenta02.Text = Impuesto_SQL.ToString();
                        this.TBValor_PorVenta03.Text = Impuesto_SQL.ToString();

                        this.TBDivisor_Impuesto.Text = "1," + TBValor_PorVenta01.Text;

                        //Se procede a calcular el IVA o Impuestos
                        Valor01 = Convert.ToDouble(TBValor_Venta01.Text);
                        Divisor = Convert.ToDouble(TBDivisor_Impuesto.Text);
                        Porcentaje01 = Convert.ToDouble(this.TBValor_PorVenta01.Text);

                        //Primero se Calcula el Valor Base
                        Base01 = Valor01 / Divisor;
                        this.textBox6.Text = Base01.ToString("C");
                    }
                }

                

                //else
                //{
                //    this.TBValor_PorVenta01.Text = Impuesto_SQL.ToString();
                //    this.TBValor_PorVenta02.Text = Impuesto_SQL.ToString();
                //    this.TBValor_PorVenta03.Text = Impuesto_SQL.ToString();
                //}

                ////Se procede a calcular el IVA o Impuestos
                //Valor01 = Convert.ToDouble(TBValor_Venta01.Text);
                //Divisor = Convert.ToDouble(TBDivisor_Impuesto.Text);
                //Porcentaje01 = Convert.ToDouble(this.TBValor_PorVenta01.Text);

                ////Total01 = (Valor01 / Intervalo) / 100;
                //Total01 = (Valor01 / Divisor);

                //this.TBValor_ImpVenta01.Text = Total01.ToString("C");

                //////Se procede a calcular el IVA o Impuestos
                ////Intervalo = Convert.ToDouble(TBIntervalo.Text);


                ////Operacion = Valor01 / Intervalo;
                ////Total = Valor01 - Operacion;

                ////this.TBValor_ImpVenta01.Text = Total.ToString();
                //////this.textBox1.Text = string.Format("{0:C2}", Operacion);
                ////this.textBox1.Text = Total.ToString("C");
                //////this.textBox1.Text = string.Format("###,###,###,00", Operacion);


                //MessageBox.Show(suma.ToString());
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

                        rptaDatosBasicos = fProducto_Inventario.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.CBMarca.SelectedValue), Convert.ToInt32(this.CBEmpaque.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue), Convert.ToInt32(this.CBTipo.SelectedValue),

                                 //Panel Datos Basicos
                                 this.TBCodigo.Text, this.TBNombre.Text, this.TBReferencia.Text, this.TBDescripcion01.Text, this.TBPresentacion.Text,
                                 this.CBUnidad.Text, this.TBComision_Valor.Text, Convert.ToInt32(this.TBComision_Porcentaje.Text),

                                 Convert.ToInt32(Checkbox_Vencimiento), Convert.ToInt32(Checkbox_Impuesto), Convert.ToInt32(Checkbox_Importado),
                                 Convert.ToInt32(Checkbox_Exportado), Convert.ToInt32(Checkbox_Ofertable), Convert.ToInt32(Checkbox_Comision),

                                 //Panel de Valores
                                 this.TBValor_CompraPromedio.Text, this.TBValor_CompraFinal.Text, this.TBValor_Venta01.Text, this.TBValor_Venta02.Text, this.TBValor_Mayorista.Text,
                                 this.TBFabri_ManoDeObra.Text, this.TBFabri_Materiales.Text, this.TBExterior_Exportacion.Text, this.TBExterior_Importacion.Text,
                                 this.TBExterior_Seguridad.Text, this.TBExteriorMon_Comision.Text,

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
                        rptaDatosBasicos = fProducto_Inventario.Editar_DatosBasicos

                            (
                                //Llave Primaria
                                Convert.ToInt32(this.TBIdproducto.Text),

                                //Datos Auxiliares
                                Convert.ToInt32(this.CBMarca.SelectedValue), Convert.ToInt32(this.CBEmpaque.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue), Convert.ToInt32(this.CBTipo.SelectedValue),

                                //Panel Datos Basicos
                                this.TBCodigo.Text, this.TBNombre.Text, this.TBReferencia.Text, this.TBDescripcion01.Text, this.TBPresentacion.Text,
                                this.CBUnidad.Text, this.TBComision_Valor.Text, Convert.ToInt32(this.TBComision_Porcentaje.Text),

                                Convert.ToInt32(Checkbox_Vencimiento), Convert.ToInt32(Checkbox_Impuesto), Convert.ToInt32(Checkbox_Importado),
                                Convert.ToInt32(Checkbox_Exportado), Convert.ToInt32(Checkbox_Ofertable), Convert.ToInt32(Checkbox_Comision),

                                //Panel de Valores
                                this.TBValor_CompraPromedio.Text, this.TBValor_CompraFinal.Text, this.TBValor_Venta01.Text, this.TBValor_Venta02.Text, this.TBValor_Mayorista.Text,
                                this.TBFabri_ManoDeObra.Text, this.TBFabri_Materiales.Text, this.TBExterior_Exportacion.Text, this.TBExterior_Importacion.Text,
                                this.TBExterior_Seguridad.Text, this.TBExteriorMon_Comision.Text,

                                //Panel Cantidades
                                this.TBVentaMinina_Cliente.Text, this.TBVentaMaxima_Cliente.Text, this.TBVentaMinima_Mayorista.Text, this.TBVentaMaxima_Mayorista.Text, this.TBCompraMinima_Cliente.Text, this.TBCompraMaxima_Cliente.Text, this.TBCompraMinima_Mayorista.Text, this.TBCompraMaxima_Mayorista.Text,

                                //Panel de Imagen
                                Imagen_Producto,

                                //Si es igual a 2 se editaran los datos en la base de datos
                                2
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("El Producto: “" + this.TBNombre.Text + "” a Sido Registrado Exitosamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro del Producto: “" + this.TBNombre.Text + "” a Sido Actualizado Exitosamente");
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
                this.TBIdproducto.Text = "0";

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
                    int Idproducto;

                    Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        if (DGResultados.SelectedRows.Count > 0)
                        {
                            Idproducto = Convert.ToInt32(DGResultados.CurrentRow.Cells["ID"].Value.ToString());
                            Respuesta = Negocio.fProducto_Inventario.Eliminar(Idproducto, 1);
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

        private void btnAgregar_Ubicacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    //if (this.CBBodega.SelectedIndex == 0)
                    //{
                    //    this.MensajeError("Por favor seleccione la Bodega perteneciente a la Ubicación que desea generar");
                    //}
                    if (this.TBUbicacion.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ubicación dentro de la Bodega seleccionada");
                        this.TBUbicacion.Select();
                    }
                    else
                    {

                        DataRow fila = this.DtDetalle_Ubicacion.NewRow();
                        fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                        //fila["Idbodega"] = Convert.ToInt32(this.CBBodega.SelectedValue);
                        fila["Ubicacion"] = this.TBUbicacion.Text;
                        fila["Estante"] = this.TBEstante.Text;
                        fila["Nivel"] = this.TBNivel.Text;
                        this.DtDetalle_Ubicacion.Rows.Add(fila);

                        this.lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);

                        //
                        //this.CBBodega.SelectedIndex = 0;
                        this.TBUbicacion.Clear();
                        this.TBEstante.Clear();
                        this.TBNivel.Clear();
                    }
                }
                else
                {
                    //if (this.CBBodega.SelectedIndex == 0)
                    //{
                    //    this.MensajeError("Por favor seleccione la Bodega perteneciente a la Ubicación que desea generar");
                    //}
                    if (this.TBUbicacion.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Ubicación dentro de la Bodega seleccionada");
                        this.TBUbicacion.Select();
                    }
                    else
                    {
                        //DialogResult result = MessageBox.Show("¿Desea Registrar la Ubicacion del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        //if (result == DialogResult.Yes)
                        //{
                        //    string rptaDatosBasicos = "";
                        //    rptaDatosBasicos = fProducto_Inventario.Guardar_Ubicacion

                        //            (
                        //                 //Datos Basicos
                        //                 Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(this.CBBodega.SelectedValue), this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text,

                        //                //Datos Auxiliares
                        //                1
                        //            );

                        //    if (rptaDatosBasicos.Equals("OK"))
                        //    {
                        //        this.MensajeOk("La Ubicación del Producto: " + TBNombre.Text + " con Codigo: " + this.TBCodigo.Text + " a Sido Registrada Exitosamente");
                        //    }

                        //    else
                        //    {
                        //        this.MensajeError(rptaDatosBasicos);
                        //    }

                        //    //
                        //    //this.CBBodega.SelectedIndex = 0;
                        //    this.TBUbicacion.Clear();
                        //    this.TBEstante.Clear();
                        //    this.TBNivel.Clear();

                        //    this.Actualizar_DetUbicacion();
                        //}
                        //else
                        //{
                        //    this.TBUbicacion.Select();
                        //}
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
                        int Idproducto, Idubicacion;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalles_Ubicacion.SelectedRows.Count > 0)
                            {
                                Idproducto = Convert.ToInt32(DGDetalles_Ubicacion.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Idubicacion = Convert.ToInt32(DGDetalles_Ubicacion.CurrentRow.Cells["Idubicacion"].Value.ToString());
                                Respuesta = Negocio.fProducto_Inventario.Eliminar_Ubicacion(Idproducto, Idubicacion, 6);
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
                        this.Actualizar_DetUbicacion();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            rptaDatosBasicos = fProducto_Inventario.Guardar_CodigoDeBarra

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

                        //
                        this.Actualizar_DetCodigoDeBarra();
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
                        int Idproducto, Idcodbarra;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Proveedor.SelectedRows.Count > 0)
                            {
                                Idproducto = Convert.ToInt32(DGDetalle_Proveedor.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Idcodbarra = Convert.ToInt32(DGDetalle_Proveedor.CurrentRow.Cells["IdCodBarra"].Value.ToString());
                                Respuesta = Negocio.fProducto_Inventario.Eliminar_CodigoDeBara(Idproducto, Idcodbarra, 1);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Codigo de Barra Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetCodigoDeBarra();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void TBValor_Venta02_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Venta02.BackColor = Color.Azure;

            //
            this.TBValor_Venta02.Text = TBValor_Venta01.Text;
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

        private void TBValor_CompraPromedio_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_CompraPromedio.BackColor = Color.Azure;
        }

        private void TBValorParaComision_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBComision_Valor.BackColor = Color.Azure;
        }

        private void TBValordecompra_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBValor_CompraFinal.BackColor = Color.Azure;
        }

        private void TBVentaMayorista_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBValor_Mayorista.BackColor = Color.Azure;
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBNombre.Select();
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
                            this.TBCodigo.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBReferencia.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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

        private void TBReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDescripcion01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBDescripcion01.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBPresentacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBDescripcion01.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    if (CHManejaComision.Checked)
                    {
                        this.TBComision_Porcentaje.Select();
                    }
                    else
                    {
                        this.TBNombre.Select();
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBPresentacion.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBValor_CompraFinal.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_CompraPromedio.Select();
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
                            this.TBValor_CompraPromedio.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void TBValor_Venta01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBValor_Venta02.Select();

                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Venta01.Select();
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
                            this.TBValor_Venta01.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBValor_Venta01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_CompraFinal.Select();
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
                            this.TBValor_CompraFinal.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBValor_Venta03.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Venta02.Select();
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
                            this.TBValor_Venta02.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBVentaMaxima_Cliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMinina_Cliente.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBVentaMinima_Mayorista.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMaxima_Cliente.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBValor_CompraFinal.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            //this.TBOtrosGastos.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEstante.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBUbicacion.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBNivel.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBEstante.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBUbicacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBNivel.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBValor_Lote.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBLotedeingreso.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBLote_Venta.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Lote.Select();
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
            if (this.CHImpuesto.Checked)
            {
                this.btnExaminar_Impuesto.Enabled = true;
            }
            else
            {
                this.btnExaminar_Impuesto.Enabled = false;
            }
        }

        private void TBValorFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
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
                                rptaDatosBasicos = fProducto_Inventario.Guardar_Igualdad

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

                            //
                            this.Actualizar_DetIgualdad();
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
                            Fila_Imp["Descripción"] = this.TBDescripcion_Impuesto.Text;
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
                            rptaDatosBasicos = fProducto_Inventario.Guardar_Impuesto

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
                        //
                        this.Actualizar_DetImpuesto();
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
                            rptaDatosBasicos = fProducto_Inventario.Guardar_Proveedor

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

                        //
                        this.Actualizar_DetProveedor();
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
                            rptaDatosBasicos = fProducto_Inventario.Guardar_Lote

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

                        //
                        this.Actualizar_DetLote();
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
                        int Idproducto, Idlote;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalles_Lotes.SelectedRows.Count > 0)
                            {
                                Idproducto = Convert.ToInt32(DGDetalles_Lotes.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Idlote = Convert.ToInt32(DGDetalles_Lotes.CurrentRow.Cells["Idlote"].Value.ToString());
                                Respuesta = Negocio.fProducto_Inventario.Eliminar_Lote(Idproducto, Idlote, 4);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Lote Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetLote();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        int Idproducto, Idigualdad;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Igualdad.SelectedRows.Count > 0)
                            {
                                Idproducto = Convert.ToInt32(DGDetalle_Igualdad.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Idigualdad = Convert.ToInt32(DGDetalle_Igualdad.CurrentRow.Cells["Idigualdad"].Value.ToString());
                                Respuesta = Negocio.fProducto_Inventario.Eliminar_Igualdad(Idproducto, Idigualdad, 2);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Producto de Igualdad Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetIgualdad();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        int Idproducto, Idimpuesto;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Impuesto.SelectedRows.Count > 0)
                            {
                                Idproducto = Convert.ToInt32(DGDetalle_Impuesto.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Idimpuesto = Convert.ToInt32(DGDetalle_Impuesto.CurrentRow.Cells["IdDet_impuesto"].Value.ToString());
                                Respuesta = Negocio.fProducto_Inventario.Eliminar_Impuesto(Idproducto, Idimpuesto, 3);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Impuesto Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetImpuesto();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        int Idproducto, Idproveedor;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalle_Proveedor.SelectedRows.Count > 0)
                            {
                                Idproducto = Convert.ToInt32(DGDetalle_Proveedor.CurrentRow.Cells["Idproducto"].Value.ToString());
                                Idproveedor = Convert.ToInt32(DGDetalle_Proveedor.CurrentRow.Cells["IdDet_Proveedor"].Value.ToString());
                                Respuesta = Negocio.fProducto_Inventario.Eliminar_Proveedor(Idproducto, Idproveedor, 5);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Proveedor Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetProveedor();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            this.TBFabri_ManoDeObra.BackColor = Color.Azure;
        }

        private void TBCostos_Materiales_Enter(object sender, EventArgs e)
        {
            this.TBFabri_Materiales.BackColor = Color.Azure;
        }

        private void TBCostos_Exportacion_Enter(object sender, EventArgs e)
        {
            this.TBExterior_Exportacion.BackColor = Color.Azure;
        }

        private void TBCostos_Imprtacion_Enter(object sender, EventArgs e)
        {
            this.TBExterior_Importacion.BackColor = Color.Azure;
        }

        private void TBCostos_Seguridad_Enter(object sender, EventArgs e)
        {
            this.TBExterior_Seguridad.BackColor = Color.Azure;
        }

        private void TBCostos_Adicional_Enter(object sender, EventArgs e)
        {
            this.TBExteriorMon_Comision.BackColor = Color.Azure;
        }

        private void TBCosto_Fabricacion_Leave(object sender, EventArgs e)
        {
            this.TBFabri_ManoDeObra.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBFabri_Materiales.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBExterior_Exportacion.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBExterior_Importacion.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBExterior_Seguridad.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBExteriorMon_Comision.BackColor = Color.FromArgb(3, 155, 229);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBFabri_Materiales.Select();
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
                            this.TBFabri_ManoDeObra.Select();
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
                            this.TBFabri_ManoDeObra.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBExterior_Importacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Exportacion.Select();
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
                            this.TBExterior_Exportacion.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBExterior_Seguridad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Importacion.Select();
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
                            this.TBExterior_Importacion.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBExteriorMon_Comision.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Seguridad.Select();
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
                            this.TBExterior_Seguridad.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBExterior_Exportacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_Materiales.Select();
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
                            this.TBFabri_Materiales.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBValor_CompraPromedio.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Comision.Select();
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
                            this.TBExteriorMon_Comision.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBLote_Cantidad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBLote_Venta.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBLotedeingreso.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBLote_Cantidad.Select();
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
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
            {
                //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                this.TBNombre.Select();
            }
        }

        private void TBComision_Porcentaje_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
            {
                //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                if (CHManejaComision.Checked)
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBVentaMaxima_Cliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMinina_Cliente.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBVentaMinima_Mayorista.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMaxima_Cliente.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBVentaMaxima_Mayorista.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMinima_Mayorista.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBCompraMinima_Cliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMaxima_Mayorista.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBCompraMaxima_Cliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBCompraMinima_Cliente.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBCompraMinima_Mayorista.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBCompraMaxima_Cliente.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBCompraMaxima_Mayorista.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBCompraMinima_Mayorista.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBVentaMinina_Cliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBCompraMaxima_Mayorista.Select();
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

        //*********** PANEL COMPUESTO - EVENTO ENTER *********** 
        private void TBCompuesto_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBCompuesto.BackColor = Color.Azure;
        }

        private void TBCompuesto_Descrip_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBCompuesto_Descrip.BackColor = Color.Azure;
        }

        //*********** PANEL EXTERIOR - EVENTO ENTER *********** 
        private void TBExterior_Aduana_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Aduana.BackColor = Color.Azure;
        }

        private void TBExteriorMon_Aduana_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExteriorMon_Aduana.BackColor = Color.Azure;
        }

        private void TBExterior_Comision_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Comision.BackColor = Color.Azure;
        }

        private void TBExteriorMon_Comision_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExteriorMon_Comision.BackColor = Color.Azure;
        }

        private void TBExterior_Documento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Documento.BackColor = Color.Azure;
        }

        private void TBExteriorMon_Documento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExteriorMon_Documento.BackColor = Color.Azure;
        }

        private void TBExterior_Adicional_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Adicional.BackColor = Color.Azure;
        }

        private void TBExteriorMon_Adicional_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExteriorMon_Adicional.BackColor = Color.Azure;
        }

        private void TBExterior_Exportacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Exportacion.BackColor = Color.Azure;
        }

        private void TBExteriorMon_Exportacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExteriorMon_Exportacion.BackColor = Color.Azure;
        }

        private void TBExterior_Importacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Importacion.BackColor = Color.Azure;
        }

        private void TBExteriorMon_Importacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExteriorMon_Importacion.BackColor = Color.Azure;
        }

        private void TBExterior_Seguridad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Seguridad.BackColor = Color.Azure;
        }

        private void TBExteriorMon_Seguridad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExteriorMon_Seguridad.BackColor = Color.Azure;
        }

        //*********** PANEL VALOR DE FABRICACION
        private void TBFabri_Material01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Material01.BackColor = Color.Azure;
        }

        private void TBFabri_Material02_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Material02.BackColor = Color.Azure;
        }

        private void TBFabri_Material03_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Material03.BackColor = Color.Azure;
        }

        private void TBFabri_OtroMaterial_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_OtroMaterial.BackColor = Color.Azure;
        }

        private void TBFabri_ManoDeObra_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_ManoDeObra.BackColor = Color.Azure;
        }

        private void TBFabri_Materiales_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Materiales.BackColor = Color.Azure;
        }

        private void TBFabri_Envio_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Envio.BackColor = Color.Azure;
        }

        private void TBFabri_Almacenamiento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Almacenamiento.BackColor = Color.Azure;
        }

        private void TBFabri_Maquinaria_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Maquinaria.BackColor = Color.Azure;
        }

        private void TBFabri_Manual_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_Manual.BackColor = Color.Azure;
        }

        private void TBFabri_TotalFabricacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_TotalFabricacion.BackColor = Color.Azure;
        }

        private void TBValor_Venta03_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Venta03.BackColor = Color.Azure;

            //
            this.TBValor_Venta03.Text = TBValor_Venta02.Text;
        }

        private void TBValor_Unidad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Unidad.BackColor = Color.Azure;
        }

        private void TBValor_Unidad01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Unidad01.BackColor = Color.Azure;
        }

        private void TBValor_Unidad02_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Unidad02.BackColor = Color.Azure;
        }

        private void TBValor_Unidad03_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Unidad03.BackColor = Color.Azure;
        }

        private void TBCompuesto_Leave(object sender, EventArgs e)
        {
            this.TBCompuesto.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompuesto_Descrip_Leave(object sender, EventArgs e)
        {
            this.TBCompuesto_Descrip.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBExterior_Aduana_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExterior_Aduana.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExterior_Comision_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExterior_Comision.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExterior_Documento_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExterior_Documento.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExterior_Adicional_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExterior_Adicional.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExterior_Exportacion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExterior_Exportacion.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExterior_Importacion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExterior_Importacion.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExterior_Seguridad_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExterior_Seguridad.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExteriorMon_Aduana_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExteriorMon_Aduana.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExteriorMon_Comision_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExteriorMon_Comision.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExteriorMon_Documento_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExteriorMon_Documento.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExteriorMon_Adicional_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExteriorMon_Adicional.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExteriorMon_Exportacion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExteriorMon_Exportacion.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExteriorMon_Importacion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExteriorMon_Importacion.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExteriorMon_Seguridad_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBExteriorMon_Seguridad.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Material01_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Material01.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Material02_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Material02.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Material03_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Material03.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_OtroMaterial_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_OtroMaterial.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_ManoDeObra_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_ManoDeObra.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Materiales_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Materiales.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Envio_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Envio.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Almacenamiento_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Almacenamiento.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Maquinaria_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Maquinaria.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_Manual_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_Manual.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBFabri_TotalFabricacion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_TotalFabricacion.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBValor_Venta03_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValor_Venta03.BackColor = Color.FromArgb(3, 155, 229);

            if (TBValor_Venta03.Text != string.Empty)
            {
                this.Calculo_Impuesto();
            }

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

        private void TBValor_ImpMayorista_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValor_ImpMayorista.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBValor_Unidad01_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValor_Unidad01.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBValor_Unidad02_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValor_Unidad02.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBValor_Unidad03_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValor_Unidad03.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBExterior_Aduana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExterior_Comision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExterior_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExterior_Adicional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExterior_Exportacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExterior_Importacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExterior_Seguridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExteriorMon_Aduana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExteriorMon_Comision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExteriorMon_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExteriorMon_Adicional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExteriorMon_Exportacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExteriorMon_Importacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBExteriorMon_Seguridad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Material01_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Material02_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Material03_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_OtroMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_ManoDeObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Materiales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Envio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Almacenamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Maquinaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Manual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_TotalFabricacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor_Venta03_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor_PorVenta01_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor_Unidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor_Unidad01_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor_Unidad02_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor_Unidad03_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor_Unidad_Leave(object sender, EventArgs e)
        {
            this.TBValor_Unidad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompuesto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCompuesto_Descrip.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBCompuesto.Select();
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
                            this.TBCompuesto.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCompuesto_Descrip_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCompuesto.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBCompuesto_Descrip.Select();
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
                            this.TBCompuesto_Descrip.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExterior_Aduana_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExteriorMon_Aduana.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Aduana.Select();
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
                            this.TBExterior_Aduana.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExteriorMon_Aduana_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExterior_Comision.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Aduana.Select();
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
                            this.TBExteriorMon_Aduana.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExterior_Comision_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExteriorMon_Comision.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Comision.Select();
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
                            this.TBExterior_Comision.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExteriorMon_Comision_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExterior_Documento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Comision.Select();
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
                            this.TBExteriorMon_Comision.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExterior_Documento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExteriorMon_Documento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Documento.Select();
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
                            this.TBExterior_Documento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExteriorMon_Documento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExterior_Adicional.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Documento.Select();
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
                            this.TBExteriorMon_Documento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExterior_Adicional_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExteriorMon_Adicional.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Adicional.Select();
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
                            this.TBExterior_Adicional.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExteriorMon_Adicional_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExterior_Exportacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Adicional.Select();
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
                            this.TBExteriorMon_Adicional.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExterior_Exportacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExteriorMon_Exportacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Exportacion.Select();
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
                            this.TBExterior_Exportacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExteriorMon_Exportacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExterior_Importacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Exportacion.Select();
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
                            this.TBExteriorMon_Exportacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExterior_Importacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExteriorMon_Importacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Importacion.Select();
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
                            this.TBExterior_Importacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExteriorMon_Importacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExterior_Seguridad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Importacion.Select();
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
                            this.TBExteriorMon_Importacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExterior_Seguridad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExteriorMon_Seguridad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Seguridad.Select();
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
                            this.TBExterior_Seguridad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBExteriorMon_Seguridad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBExterior_Aduana.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExteriorMon_Seguridad.Select();
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
                            this.TBExteriorMon_Seguridad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnExaminar_Exterior_Click(object sender, EventArgs e)
        {
            this.Examinar_Exterior = true;
            frmFiltro_Proveedor frmFiltro_Proveedor = new frmFiltro_Proveedor();
            frmFiltro_Proveedor.ShowDialog();
        }

        private void TBValor_Venta03_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBValor_Mayorista.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Venta03.Select();
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
                            this.TBValor_Venta03.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor_Unidad01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBValor_Unidad02.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Unidad01.Select();
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
                            this.TBValor_Unidad01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor_Unidad02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBValor_Unidad03.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Unidad02.Select();
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
                            this.TBValor_Unidad02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor_Unidad03_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBValor_CompraPromedio.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Unidad03.Select();
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
                            this.TBValor_Unidad03.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_Material01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Material02.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Aduana.Select();
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
                            this.TBExterior_Aduana.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_Material02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Material03.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBExterior_Aduana.Select();
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
                            this.TBExterior_Aduana.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_Material03_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_OtroMaterial.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_Material03.Select();
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
                            this.TBFabri_Material03.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_OtroMaterial_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_ManoDeObra.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_OtroMaterial.Select();
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
                            this.TBFabri_OtroMaterial.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_ManoDeObra_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBFabri_Materiales_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Envio.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_Materiales.Select();
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
                            this.TBFabri_Materiales.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_Envio_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBFabri_Envio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Almacenamiento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_Envio.Select();
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
                            this.TBFabri_Envio.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_Almacenamiento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Maquinaria.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_Almacenamiento.Select();
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
                            this.TBFabri_Almacenamiento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_Maquinaria_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Manual.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_Maquinaria.Select();
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
                            this.TBFabri_Maquinaria.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_Manual_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Material01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_Manual.Select();
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
                            this.TBFabri_Manual.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_ManoDeObra_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_Materiales.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla F9 se Cancela la Edicion y se Limpian los Campos

                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBFabri_ManoDeObra.Select();
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
                            this.TBFabri_ManoDeObra.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMaxima_Mayorista_Enter(object sender, EventArgs e)
        {
            this.TBVentaMaxima_Mayorista.BackColor = Color.Azure;
        }

        private void TBValor_ImpVenta01_Leave(object sender, EventArgs e)
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
            tb.Text = string.Format("{0:N}", numero);
        }

        private void CBMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMarca.SelectedIndex == 0)
            {
                this.TBCodigo_Marca.Enabled = true;
                this.TBCodigo_Marca.BackColor = Color.FromArgb(3, 155, 229);
            }
            else
            {
                this.TBCodigo_Marca.Enabled = false;
                this.TBCodigo_Marca.BackColor = Color.FromArgb(72, 209, 204);
            }
        }

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBTipo.SelectedIndex == 0)
            {
                this.TBCodigo_Tipo.Enabled = true;
                this.TBCodigo_Tipo.BackColor = Color.FromArgb(3, 155, 229);
            }
            else
            {
                this.TBCodigo_Tipo.Enabled = false;
                this.TBCodigo_Tipo.BackColor = Color.FromArgb(72, 209, 204);
            }
        }

        private void CBEmpaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBEmpaque.SelectedIndex == 0)
            {
                this.TBCodigo_Empaque.Enabled = true;
                this.TBCodigo_Empaque.BackColor = Color.FromArgb(3, 155, 229);
            }
            else
            {
                this.TBCodigo_Empaque.Enabled = false;
                this.TBCodigo_Empaque.BackColor = Color.FromArgb(72, 209, 204);
            }
        }

        private void TBCodigo_Marca_Enter(object sender, EventArgs e)
        {
            this.TBCodigo_Marca.BackColor = Color.Azure;
        }

        private void TBCodigo_Grupo_Enter(object sender, EventArgs e)
        {
            this.TBCodigo_Grupo.BackColor = Color.Azure;
        }

        private void TBCodigo_Tipo_Enter(object sender, EventArgs e)
        {
            this.TBCodigo_Tipo.BackColor = Color.Azure;
        }

        private void TBCodigo_Empaque_Enter(object sender, EventArgs e)
        {
            this.TBCodigo_Empaque.BackColor = Color.Azure;
        }

        private void TBCodigo_Marca_Leave(object sender, EventArgs e)
        {
            this.TBCodigo_Marca.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigo_Grupo_Leave(object sender, EventArgs e)
        {
            this.TBCodigo_Grupo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigo_Tipo_Leave(object sender, EventArgs e)
        {
            this.TBCodigo_Tipo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigo_Empaque_Leave(object sender, EventArgs e)
        {
            this.TBCodigo_Empaque.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void CBGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBGrupo.SelectedIndex == 0)
            {
                this.TBCodigo_Grupo.Enabled = true;
                this.TBCodigo_Grupo.BackColor = Color.FromArgb(3, 155, 229);
            }
            else
            {
                this.TBCodigo_Grupo.Enabled = false;
                this.TBCodigo_Grupo.BackColor = Color.FromArgb(72, 209, 204);
            }
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
            this.Examinar_Proveedor = true;
            frmFiltro_Proveedor frmFiltro_Proveedor = new frmFiltro_Proveedor();
            frmFiltro_Proveedor.ShowDialog();
        }

        private void TBValorVenta_SinImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValorVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnExaminar_Impuesto_Click(object sender, EventArgs e)
        {
            frmFiltro_Impuesto frmFiltro_Impuesto = new frmFiltro_Impuesto();
            frmFiltro_Impuesto.ShowDialog();
        }

        private void DGDetalles_Ubicacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                DataGridViewRow fila = DGDetalles_Ubicacion.Rows[e.RowIndex];

                //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                //this.CBBodega.SelectedValue = Convert.ToString(fila.Cells["Idbodega"].Value);
                this.TBUbicacion.Text = Convert.ToString(fila.Cells["Ubicacion"].Value);
                this.TBEstante.Text = Convert.ToString(fila.Cells["Estante"].Value);
                this.TBNivel.Text = Convert.ToString(fila.Cells["Nivel"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnModificar_Ubicacion_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                rptaDatosBasicos = fProducto_Inventario.Editar_Ubicacion

                            (
                                 //Datos Auxiliares
                                 Convert.ToInt32(this.TBIdproducto.Text),

                                 //Panel Datos Basicos
                                 this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text,

                                //Si es igual a 1 se registraran los datos en la base de datos
                                2
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("La Ubicacion del Producto: “" + this.TBNombre.Text + "” a Sido Actualizada Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    //this.CBBodega.SelectedIndex = 0;
                    this.TBUbicacion.Clear();
                    this.TBEstante.Clear();
                    this.TBNivel.Clear();

                    this.Actualizar_DetUbicacion();
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

        private void btnModificar_CodigoDeBarra_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnModificar_Lote_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGDetalles_Ubicacion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                DataGridViewRow fila = DGDetalles_Ubicacion.Rows[e.RowIndex];

                //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                //this.CBBodega.SelectedValue = Convert.ToString(fila.Cells["Idbodega"].Value);
                this.TBUbicacion.Text = Convert.ToString(fila.Cells["Ubicacion"].Value);
                this.TBEstante.Text = Convert.ToString(fila.Cells["Estante"].Value);
                this.TBNivel.Text = Convert.ToString(fila.Cells["Nivel"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CBUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBUnidad.SelectedIndex == 1)
            {
                //SE PROCEDE HABILITAR LOS CAMPOS DE TEXTO CON LOS VALORES POR UNIDADES
            }
            else
            {
                //SE DESABILITAN Y SE LIMPIAN LOS CAMPOS DE TEXTO
            }
        }

        private void CBBodega_Stock_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
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
            if (CHManejaComision.Checked)
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
            if (TBValor_CompraPromedio.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor_CompraPromedio.BackColor = Color.FromArgb(3, 155, 229);
            }
            else
            {
                this.TBValor_CompraPromedio.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBValor_Mayorista.BackColor = Color.FromArgb(3, 155, 229);

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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    this.TBValor_Unidad01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBValor_Mayorista.Select();
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
                            this.TBValor_Mayorista.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    if (CHManejaComision.Checked)
                    {
                        //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                        this.TBComision_Valor.Select();
                    }
                    else
                    {
                        this.TBVentaMinina_Cliente.Select();
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBComision_Porcentaje.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBVentaMinina_Cliente.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBComision_Valor.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBVentaMaxima_Mayorista.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMinima_Mayorista.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBValor_CompraPromedio.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;
                    this.TBIdproducto.Text = "0";

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
                            this.TBVentaMaxima_Mayorista.Select();
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
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    if (TBCodigodeBarra.Text == string.Empty)
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
            this.TBValor_CompraFinal.BackColor = Color.FromArgb(3, 155, 229);

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
            this.TBValor_Venta02.BackColor = Color.FromArgb(3, 155, 229);

            if (TBValor_Venta02.Text != string.Empty)
            {
                this.Calculo_Impuesto();
            }


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

        private void TBValor_Venta01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Venta01.BackColor = Color.Azure;
        }

        private void TBValor_Venta01_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValor_Venta01.BackColor = Color.FromArgb(3, 155, 229);

            if (TBValor_Venta01.Text != string.Empty)
            {
                this.Calculo_Impuesto();
            }

            //********************* PROCESO PARA FORMATEAR EL TEXBOXT A TIPO MONEDA

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

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fProducto_Inventario.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultados.Columns[0].Visible = false;

                        this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

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
                DataTable Datos = Negocio.fProducto_Inventario.Buscar(this.TBIdproducto.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    //MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //Valor_Promedio = Datos.Rows[0][18].ToString();
                    //ValCom_Final = Datos.Rows[0][19].ToString();
                    //Valor_Excento = Datos.Rows[0][20].ToString();
                    //Valor_NoExcento = Datos.Rows[0][21].ToString();
                    //Valor_Mayorista = Datos.Rows[0][22].ToString();
                    //Valor_Fabricacion = Datos.Rows[0][23].ToString();
                    //Valor_Materiales = Datos.Rows[0][24].ToString();
                    //Valor_Exportacion = Datos.Rows[0][25].ToString();
                    //Valor_Importacion = Datos.Rows[0][26].ToString();
                    //Valor_Seguro = Datos.Rows[0][27].ToString();
                    //Valor_Otros = Datos.Rows[0][28].ToString();

                    //
                    VenMin_Cliente = Datos.Rows[0][29].ToString();
                    VenMax_Cliente = Datos.Rows[0][30].ToString();
                    VenMin_Mayorista = Datos.Rows[0][31].ToString();
                    VenMax_Mayorista = Datos.Rows[0][32].ToString();
                    ComMin_Cliente = Datos.Rows[0][33].ToString();
                    ComMax_Cliente = Datos.Rows[0][34].ToString();
                    ComMin_Mayorista = Datos.Rows[0][35].ToString();
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

                    ////Panel - Valores
                    //this.TBCompraPromedio.Text = Valor_Promedio;
                    //this.TBCompraFinal.Text = ValCom_Final;
                    //this.TBValorVenta_01.Text = Valor_Excento;
                    //this.TBValorVenta_02.Text = Valor_NoExcento;
                    //this.TBVentaMayorista.Text = Valor_Mayorista;
                    //this.TBCosto_Fabricacion.Text = Valor_Fabricacion;
                    //this.TBCostos_Materiales.Text = Valor_Materiales;
                    //this.TBCostos_Exportacion.Text = Valor_Exportacion;
                    //this.TBCostos_Imprtacion.Text = Valor_Importacion;
                    //this.TBCostos_Seguridad.Text = Valor_Seguro;
                    //this.TBCostos_Adicional.Text = Valor_Otros;

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
                        this.CHVencimiento.Checked = false;
                    }
                    else
                    {
                        this.CHVencimiento.Checked = true;
                    }

                    if (Importado == "0")
                    {
                        this.CHImportado.Checked = false;
                    }
                    else
                    {
                        this.CHImportado.Checked = true;
                    }

                    if (Exportado == "0")
                    {
                        this.CHExportado.Checked = false;
                    }
                    else
                    {
                        this.CHExportado.Checked = true;
                    }

                    if (AplicaImpuesto == "0")
                    {
                        this.CHImpuesto.Checked = false;
                    }
                    else
                    {
                        this.CHImpuesto.Checked = true;
                    }

                    if (Ofertable == "0")
                    {
                        this.CHOfertable.Checked = false;
                    }
                    else
                    {
                        this.CHOfertable.Checked = true;
                    }

                    if (AplicaComision == "0")
                    {
                        this.CHManejaComision.Checked = false;
                    }
                    else
                    {
                        this.CHManejaComision.Checked = true;
                    }

                    //************************************************************************************************************************
                    //Se realizan las consultas para llenar los DataGriview donde se mostrarian los MultiPlex Registros.

                    this.DGDetalles_Ubicacion.DataSource = fProducto_Inventario.Buscar_Ubicacion(1, Convert.ToInt32(this.TBIdproducto.Text));
                    this.lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);
                    this.DGDetalles_Ubicacion.Columns["Idubicacion"].Visible = false;

                    this.DGDetalle_Igualdad.DataSource = fProducto_Inventario.Buscar_Igualdad(1, Convert.ToInt32(this.TBIdproducto.Text));
                    this.lblTotal_Igualdad.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Igualdad.Rows.Count);
                    this.DGDetalle_Igualdad.Columns["Idigualdad"].Visible = false;

                    this.DGDetalle_Impuesto.DataSource = fProducto_Inventario.Buscar_Impuesto(1, Convert.ToInt32(this.TBIdproducto.Text));
                    this.lblTotal_Impuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Impuesto.Rows.Count);
                    this.DGDetalle_Impuesto.Columns[0].Visible = false;
                    this.DGDetalle_Impuesto.Columns[1].Visible = false;
                    this.DGDetalle_Impuesto.Columns["IdDet_impuesto"].Visible = false;

                    this.DGDetalle_Proveedor.DataSource = fProducto_Inventario.Buscar_Proveedor(1, Convert.ToInt32(this.TBIdproducto.Text));
                    this.lblTotal_Proveedor.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Proveedor.Rows.Count);
                    this.DGDetalle_Proveedor.Columns["IdDet_Proveedor"].Visible = false;

                    this.DGDetalle_CodigoDeBarra.DataSource = fProducto_Inventario.Buscar_CodigoDeBarra(1, Convert.ToInt32(this.TBIdproducto.Text));
                    this.lblTotal_Codigodebarra.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_CodigoDeBarra.Rows.Count);
                    this.DGDetalle_CodigoDeBarra.Columns["IdCodBarra"].Visible = false;

                    this.DGDetalles_Lotes.DataSource = fProducto_Inventario.Buscar_Lote(1, Convert.ToInt32(this.TBIdproducto.Text));
                    this.lblTotal_Lotes.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Lotes.Rows.Count);
                    this.DGDetalles_Lotes.Columns["Idlote"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGDetalle_Impuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGDetalle_Impuesto.Columns[0].Index)
            {
                DataGridViewComboBoxCell ChkEliminar = (DataGridViewComboBoxCell)DGDetalle_Impuesto.Rows[e.RowIndex].Cells[0];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Editar == "1")
                {
                    this.TBIdproducto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
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
