﻿using System;
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
    public partial class frmProducto : Form
    {
        //Instancia para el Filtro de los productos 
        private static frmProducto _Instancia;

        public static frmProducto GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmProducto();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;
        public bool Examinar_Proveedor = true;
        public bool Filtro_Igualdad = true;

        //Variables para Eliminar y ejecutar los procedimientos Internos en los paneles
        //Ubicacion, Lote, Proveedor ETC donde se realizan multiplex registros
        private bool Eliminar_Igualdad = false;
        private bool Eliminar_Impuesto = false;
        private bool Eliminar_Ubicacion = false;
        private bool Eliminar_Proveedor = false;
        private bool Eliminar_CodigoDeBarra = false;
        private bool Eliminar_Compuesto = false;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle_Compuesto;
        private DataTable DtDetalle_Exterior;
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

        private string Checkbox_Vencimiento, Checkbox_Ofertable, Checkbox_Impuesto, Checkbox_Comision, Checkbox_Exportado, Checkbox_Importado = "";
        private string Checkbox_Empaque, Checkbox_Fabricado, Checkbox_Balanza, Checkbox_Retencion, Checkbox_Compras, Checkbox_Ventas = "";

        //********** Variables para la Validacion de las Transacciones en SQL **************************************************

        private string Tran_Ubicacion, Tran_Igualdad, Tran_CodBarra, Tran_Proveedor, Tran_Impuesto, Tran_Exterior, Tran_Compuesto, Tran_Stock, Tran_Retencion = "";

        //********** Variables para AutoComplementar Combobox, Codigo_AutoIncrementable y Chexboxt segun la Consulta en SQL ****

        private string Empaque_SQL, Grupo_SQL, Marca_SQL, Tipo_SQL, Operacion, AutoIncrementable = "";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *********************************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Parametros para AutoCompletar los Texboxt *****************************************************************

        //Panel Datos Basicos - Llaves Primarias
        private string Idproducto, Idmarca, Idgrupo, Idtipo, Idempaque = "";

        //Panel Datos Basicos
        private string Codigo, Area, Nombre, Referencia, Descripcion, Descripcion02, Descripcion03, Presentacion, Comision, CompraMinima, CompraMaxima, VentaMinima, VentaMaxima = "";

        private string AplicaVentas, AplicaOfertable, AplicaCompras, Fabricado, Importado, Exportado, ManejaImpuesto, ManejaVencimiento, UtilizaEmpaque, ManejaComision, ManejaRetencion, UtilizaBalanza = "";

        //Panel - Fabricacion
        private string MaterialPrincipal, MaterialSecundario, MaterialTerciario, OtroMaterial, ManoDeObra, Materiales, Envio, Almacenamiento, Maquinaria, Herramientas, Fabricacion, DiasFormal, DiasProrroga = "";

        //Panel - Valores y Precio
        private string ValorCom_Promedio, ValorCom_Final, Valor_Base01, Valor_Base02, Valor_Base03, Valor_BaseMayorista = "";
        private string Porc_Venta01, Porc_Venta02, Porc_Valor03, Porc_Mayorista = "";
        private string Impuesto_Valor01, Impuesto_Valor02, Impuesto_Valor03, Impuesto_Mayorista = "";

        private string Unidad, Unidad_Detallada, Valor_Final01, Valor_Final02, Valor_Final03, ValorFinalMayorista = "";

        //Panel - Imagen
        private string Imagen = "";

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.AutoCompletar_Combobox();
            this.Diseño_TablasGenerales();
            this.AutoIncrementable_SQL();
            this.Auto_CodigoSQL();

            //Ocultacion de Texboxt
            this.TBIdproducto.Visible = false;
            this.TBIdimpuesto.Visible = false;
            this.TBIdproveedor.Visible = false;
            this.TBIdproducto_AutoSQL.Visible = false;
            this.TBIdigualdad_Producto.Visible = false;
            this.TBDivisor_Impuesto.Visible = false;
            this.TBmultiplicador_Impuesto.Visible = false;
            this.TBIdcompuesto.Visible = false;
            this.TBIdexterior.Visible = false;

            //Panel - Cantidades - Otros Datos
            this.CBArea.SelectedIndex = 0;
            this.CBUnidad.SelectedIndex = 0;
            this.CBComp_Medida.SelectedIndex = 0;

            //
            //this.btnExaminar_Impuesto.Enabled = false;

            //
            this.PB_Imagen.Image = Properties.Resources.Logo_Leal_Enterprise;

            //
            //SE OCULTAN LOS PANELES DEL TABCONTROL
            TCPrincipal.TabPages.Remove(TPImpuesto);
            TCPrincipal.TabPages.Remove(TPFabricacion);

            //SE SELECCIONA EL FORMULARIO DE CONSULTA PRINCIPAL Y COMBOBOX DEL MISMI
            TCFiltro.SelectedIndex =2;
            this.CBFiltro_Agrupado.SelectedIndex = 0;
            this.CBFiltro_General.SelectedIndex = 0;

            //Inicio de Texbox y Combobox por default
            this.TBNombre.Select();
            this.TBComision.Text = "0";
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
            this.TBDescripcion02.ReadOnly = false;
            this.TBDescripcion02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion03.ReadOnly = false;
            this.TBDescripcion03.BackColor = Color.FromArgb(3, 155, 229);
            this.TBReferencia.ReadOnly = false;
            this.TBReferencia.BackColor = Color.FromArgb(3, 155, 229);
            this.TBPresentacion.ReadOnly = false;
            this.TBPresentacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComision.Enabled = false;
            this.TBComision.BackColor = Color.FromArgb(245, 245, 245);

            this.TBCompraminima.ReadOnly = false;
            this.TBCompraminima.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompraMaxima.ReadOnly = false;
            this.TBCompraMaxima.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVentaMinima.ReadOnly = false;
            this.TBVentaMinima.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVentaMaxima.ReadOnly = false;
            this.TBVentaMaxima.BackColor = Color.FromArgb(3, 155, 229);

            //Panel Compuesto
            this.TBCompuesto.ReadOnly = false;
            this.TBCompuesto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComp_Descripcion.ReadOnly = false;
            this.TBComp_Descripcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComp_Medida.ReadOnly = false;
            this.TBComp_Medida.BackColor = Color.FromArgb(3, 155, 229);


            //Panel - Valores
            this.textBox1.Enabled = false;
            this.textBox1.BackColor = Color.FromArgb(255, 255, 255);
            this.textBox34.Enabled = false;
            this.textBox34.BackColor = Color.FromArgb(255, 255, 255);
            this.textBox3.Enabled = false;
            this.textBox3.BackColor = Color.FromArgb(255, 255, 255);
            this.textBox24.Enabled = false;
            this.textBox24.BackColor = Color.FromArgb(255, 255, 255);

            this.TBValor_CompraPromedio.ReadOnly = false;
            this.TBValor_CompraPromedio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor_CompraFinal.ReadOnly = false;
            this.TBValor_CompraFinal.BackColor = Color.FromArgb(3, 155, 229);

            this.TBValorBase_Inicial01.Enabled = true;
            this.TBValorBase_Inicial01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorBase_Inicial02.Enabled = true;
            this.TBValorBase_Inicial02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorBase_Inicial03.Enabled = true;
            this.TBValorBase_Inicial03.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorBase_InicialMayorista.Enabled = true;
            this.TBValorBase_InicialMayorista.BackColor = Color.FromArgb(3, 155, 229);

            //
            this.TBValor_Venta01.Enabled = false;
            this.TBValor_Venta01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Venta02.Enabled = false;
            this.TBValor_Venta02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Venta03.Enabled = false;
            this.TBValor_Venta03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Mayorista.Enabled = false;
            this.TBValor_Mayorista.BackColor = Color.FromArgb(245, 245, 245);

            this.TBValor_PorVenta01.Enabled = false;
            this.TBValor_PorVenta01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_PorVenta02.Enabled = false;
            this.TBValor_PorVenta02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_PorVenta03.Enabled = false;
            this.TBValor_PorVenta03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_PorMayorista.Enabled = false;
            this.TBValor_PorMayorista.BackColor = Color.FromArgb(245, 245, 245);

            this.TBValor_ImpVenta01.Enabled = false;
            this.TBValor_ImpVenta01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_ImpVenta02.Enabled = false;
            this.TBValor_ImpVenta02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_ImpVenta03.Enabled = false;
            this.TBValor_ImpVenta03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_ImpMayorista.Enabled = false;
            this.TBValor_ImpMayorista.BackColor = Color.FromArgb(245, 245, 245);

            this.TBValor_Unidad.ReadOnly = false;
            this.TBValor_Unidad.BackColor = Color.FromArgb(3, 155, 229);

            this.TBValorBase_Inicial01.Text = "0";
            this.TBValorBase_Inicial02.Text = "0";
            this.TBValorBase_Inicial03.Text = "0";
            this.TBValorBase_InicialMayorista.Text = "0";

            this.TBValor_Venta01.Text = "0";
            this.TBValor_Venta02.Text = "0";
            this.TBValor_Venta03.Text = "0";
            this.TBValor_Mayorista.Text = "0";

            this.TBValor_PorVenta01.Text = "0";
            this.TBValor_PorVenta02.Text = "0";
            this.TBValor_PorVenta03.Text = "0";
            this.TBValor_PorMayorista.Text = "0";

            this.TBValor_ImpVenta01.Text = "0";
            this.TBValor_ImpVenta02.Text = "0";
            this.TBValor_ImpVenta03.Text = "0";
            this.TBValor_ImpMayorista.Text = "0";

            this.TBValor_CompraPromedio.Text = "0";
            this.TBValor_CompraFinal.Text = "0";

            this.TBValor_Unidad.Text = "0";

            //Panel - Exterior
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

            //Panel - Fabricacion
            this.TBFabri_MaterialPrincipal.ReadOnly = false;
            this.TBFabri_MaterialPrincipal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_MaterialSecundario.ReadOnly = false;
            this.TBFabri_MaterialSecundario.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_MaterialTerciario.ReadOnly = false;
            this.TBFabri_MaterialTerciario.BackColor = Color.FromArgb(3, 155, 229);
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
            this.TBFabri_HerramientaManual.ReadOnly = false;
            this.TBFabri_HerramientaManual.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_TotalFabricacion.Enabled = false;
            this.TBFabri_TotalFabricacion.BackColor = Color.FromArgb(245, 245, 245);
            this.TBFabri_DiasFormal.ReadOnly = false;
            this.TBFabri_DiasFormal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFabri_DiasProrroga.ReadOnly = false;
            this.TBFabri_DiasProrroga.BackColor = Color.FromArgb(3, 155, 229);

            this.TBFabri_MaterialPrincipal.Text = "0";
            this.TBFabri_MaterialSecundario.Text = "0";
            this.TBFabri_MaterialTerciario.Text = "0";
            this.TBFabri_OtroMaterial.Text = "0";
            this.TBFabri_ManoDeObra.Text = "0";
            this.TBFabri_Materiales.Text = "0";
            this.TBFabri_Envio.Text = "0";
            this.TBFabri_Almacenamiento.Text = "0";
            this.TBFabri_Maquinaria.Text = "0";
            this.TBFabri_HerramientaManual.Text = "0";
            this.TBFabri_TotalFabricacion.Text = "0";
            this.TBFabri_DiasFormal.Text = "0";
            this.TBFabri_DiasProrroga.Text = "0";

            //Panel - Igualdad
            this.TBIgualdad_Codigo.Enabled = false;
            this.TBIgualdad_Codigo.BackColor = Color.FromArgb(245, 245, 245);
            this.TBIgualdad_Producto.Enabled = false;
            this.TBIgualdad_Producto.BackColor = Color.FromArgb(245, 245, 245);
            this.TBIgualdad_Marca.Enabled = false;
            this.TBIgualdad_Marca.BackColor = Color.FromArgb(245, 245, 245);

            //Panel - Codigo de Barra
            this.TBCodigodeBarra.ReadOnly = false;
            this.TBCodigodeBarra.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Ubicacion
            this.TBIdbodega_Ubicacion.Enabled = false;
            this.TBIdbodega_Ubicacion.BackColor = Color.FromArgb(245, 245, 245);
            this.TBBodega_Ubicacion.Enabled = false;
            this.TBBodega_Ubicacion.BackColor = Color.FromArgb(245, 245, 245);

            this.TBUbicacion.ReadOnly = false;
            this.TBUbicacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEstante.ReadOnly = false;
            this.TBEstante.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNivel.ReadOnly = false;
            this.TBNivel.BackColor = Color.FromArgb(3, 155, 229);

            //Panel - Impuestos
            this.TBImpuesto.Enabled = false;
            this.TBImpuesto.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Impuesto.Enabled = false;
            this.TBValor_Impuesto.BackColor = Color.FromArgb(245, 245, 245);
            this.TBDescripcion_Impuesto.Enabled = false;
            this.TBDescripcion_Impuesto.BackColor = Color.FromArgb(245, 245, 245);

            //Panel - Proveedor
            this.TBProveedor.Enabled = false;
            this.TBProveedor.BackColor = Color.FromArgb(245, 245, 245);
            this.TBProveedor_Documento.Enabled = false;
            this.TBProveedor_Documento.BackColor = Color.FromArgb(245, 245, 245);

            //Panel de Consulta General
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBCodigo.Clear();
            this.TBNombre.Clear();
            this.TBDescripcion01.Text = Campo;
            this.TBDescripcion02.Clear();
            this.TBDescripcion03.Clear();
            this.TBReferencia.Clear();
            this.TBPresentacion.Clear();
            this.TBVentaMinima.Clear();
            this.TBVentaMaxima.Clear();
            this.TBCompraminima.Clear();
            this.TBCompraMaxima.Clear();
            this.TBComision.Enabled = false;

            this.CBArea.SelectedIndex = 0;
            this.CBMarca.SelectedIndex = 0;
            this.CBGrupo.SelectedIndex = 0;
            this.CBEmpaque.SelectedIndex = 0;
            this.CBTipo.SelectedIndex = 0;
            this.CBUnidad.SelectedIndex = 0;

            this.CHCompras.Checked = false;
            this.CHVentas.Checked = false;
            this.CHImpuesto.Checked = false;
            this.CHOfertable.Checked = false;
            this.CHImportado.Checked = false;
            this.CHExportado.Checked = false;
            this.CHManejaComision.Checked = false;
            this.CHBalanza.Checked = false;
            this.CHEmpaque.Checked = false;
            this.CHRetencion.Checked = false;
            this.CHFabricado.Checked = false;

            this.TBIdproducto.Clear();
            this.TBBuscar.Clear();

            //Panel Compuesto
            this.TBCompuesto.Clear();
            this.TBComp_Descripcion.Clear();
            this.TBComp_Medida.Clear();

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


            this.TBValorBase_Inicial01.Text = "0";
            this.TBValorBase_Inicial02.Text = "0";
            this.TBValorBase_Inicial03.Text = "0";
            this.TBValorBase_InicialMayorista.Text = "0";

            this.TBValor_Venta01.Text = "0";
            this.TBValor_Venta02.Text = "0";
            this.TBValor_Venta03.Text = "0";
            this.TBValor_Mayorista.Text = "0";

            this.TBValor_PorVenta01.Text = "0";
            this.TBValor_PorVenta02.Text = "0";
            this.TBValor_PorVenta03.Text = "0";
            this.TBValor_PorMayorista.Text = "0";

            this.TBValor_ImpVenta01.Text = "0";
            this.TBValor_ImpVenta02.Text = "0";
            this.TBValor_ImpVenta03.Text = "0";
            this.TBValor_ImpMayorista.Text = "0";

            this.TBValor_CompraPromedio.Text = "0";
            this.TBValor_CompraFinal.Text = "0";

            this.TBValor_Unidad.Text = "0";

            //Panel Exterior
            this.CBProveedor_Exterior.SelectedIndex = 0;
            this.TBExterior_Aduana.Clear();
            this.TBExterior_Comision.Clear();
            this.TBExterior_Documento.Clear();
            this.TBExterior_Adicional.Clear();
            this.TBExterior_Exportacion.Clear();
            this.TBExterior_Importacion.Clear();
            this.TBExterior_Seguridad.Clear();

            //Panel Fabricacion
            this.TBFabri_MaterialPrincipal.Clear();
            this.TBFabri_MaterialSecundario.Clear();
            this.TBFabri_MaterialTerciario.Clear();
            this.TBFabri_OtroMaterial.Clear();
            this.TBFabri_ManoDeObra.Clear();
            this.TBFabri_Materiales.Clear();
            this.TBFabri_Envio.Clear();
            this.TBFabri_Almacenamiento.Clear();
            this.TBFabri_Maquinaria.Clear();
            this.TBFabri_HerramientaManual.Clear();
            this.TBFabri_TotalFabricacion.Clear();

            this.TBFabri_MaterialPrincipal.Text = "0";
            this.TBFabri_MaterialSecundario.Text = "0";
            this.TBFabri_MaterialTerciario.Text = "0";
            this.TBFabri_OtroMaterial.Text = "0";
            this.TBFabri_ManoDeObra.Text = "0";
            this.TBFabri_Materiales.Text = "0";
            this.TBFabri_Envio.Text = "0";
            this.TBFabri_Almacenamiento.Text = "0";
            this.TBFabri_Maquinaria.Text = "0";
            this.TBFabri_HerramientaManual.Text = "0";
            this.TBFabri_TotalFabricacion.Text = "0";

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

            //Limpieza de Label que cuentan las columnas de los DataGriview
            this.lblTotal_Codigodebarra.Text = "Datos Registrados: 0";
            this.lblTotal_Igualdad.Text = "Datos Registrados: 0";
            this.lblTotal_Impuesto.Text = "Datos Registrados: 0";
            this.lblTotal_Proveedor.Text = "Datos Registrados: 0";
            this.lblTotal_Ubicacion.Text = "Datos Registrados: 0";

            this.Auto_CodigoSQL();

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
                this.btnModificar_Ubicacion.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;

                this.btnModificar_CodigoDeBarra.Enabled = true;
                this.btnModificar_Ubicacion.Enabled = true;
            }
        }

        private void AutoCompletar_Combobox()
        {
            try
            {
                this.CBBodega.DataSource = fBodega.Lista(3);
                this.CBBodega.ValueMember = "Código";
                this.CBBodega.DisplayMember = "Bodega";

                this.CBEmpaque.DataSource = fEmpaque.Lista(3);
                this.CBEmpaque.ValueMember = "Código";
                this.CBEmpaque.DisplayMember = "Empaque";

                this.CBProveedor_Exterior.DataSource = fProveedor.Lista(3);
                this.CBProveedor_Exterior.ValueMember = "Código";
                this.CBProveedor_Exterior.DisplayMember = "Proveedor";

                this.CBGrupo.DataSource = fGrupoDeProducto.Lista(3);
                this.CBGrupo.ValueMember = "Código";
                this.CBGrupo.DisplayMember = "Grupo";

                this.CBMarca.DataSource = fMarca.Lista(3);
                this.CBMarca.ValueMember = "Codigo";
                this.CBMarca.DisplayMember = "Marca";

                this.CBTipo.DataSource = fTipoDeProducto.Lista(3);
                this.CBTipo.ValueMember = "Codigo";
                this.CBTipo.DisplayMember = "Tipo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Actualizar_DetCompuesto()
        {
            this.DGDetalle_Compuesto.DataSource = fProducto_Inventario.Lista_Compuesto(1, Convert.ToInt32(TBIdproducto.Text));
            this.lblTotal_Compuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Compuesto.Rows.Count);
        }

        private void Actualizar_DetExterior()
        {
            this.DGDetalle_Exterior.DataSource = fProducto_Inventario.Lista_Exterior(1, Convert.ToInt32(TBIdproducto.Text));
            this.lblTotal_Exterior.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Exterior.Rows.Count);
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

        private void Actualizar_DetProveedor()
        {
            this.DGDetalle_Proveedor.DataSource = fProducto_Inventario.Lista_Proveedor(1, Convert.ToInt32(TBIdproducto.Text));
            this.lblTotal_Proveedor.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Proveedor.Rows.Count);

            //
            //this.DGDetalle_Proveedor.Columns[0].Visible = false;
            //this.DGDetalle_Proveedor.Columns[1].Visible = false;
        }

        private void Actualizar_DetUbicacion()
        {
            this.DGDetalles_Ubicacion.DataSource = fProducto_Inventario.Lista_Ubicacion(1, Convert.ToInt32(TBIdproducto.Text)); ;
            this.lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);
        }

        public void setUbicacion(string idbodega, string bodega)
        {
            this.TBIdbodega_Ubicacion.Text = idbodega;
            this.TBBodega_Ubicacion.Text = bodega;
        }

        public void setProveedor(string idproveedor, string proveedor, string documento)
        {
            this.TBIdproveedor.Text = idproveedor;
            this.TBProveedor.Text = proveedor;
            this.TBProveedor_Documento.Text = documento;
        }

        public void setImpuesto(string idimpuesto, string impuesto, string valor, string descripcion)
        {
            this.TBIdimpuesto.Text = idimpuesto;
            this.TBImpuesto.Text = impuesto;
            this.TBValor_Impuesto.Text = valor;
            this.TBDescripcion_Impuesto.Text = descripcion;
        }

        private void Validaciones_SQL()
        {
            //Se valida el valor de los checbox que se encuentran en el panel de datos basicos
            //En el cual si este esta seleccionado su valor sera 1 y si no esta seleccionado este seria 0

            if (CHCompras.Checked)
            {
                this.Checkbox_Compras = "1";
            }
            else
            {
                this.Checkbox_Compras = "0";
            }

            if (CHVentas.Checked)
            {
                this.Checkbox_Ventas = "1";
            }
            else
            {
                this.Checkbox_Ventas = "0";
            }

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

            if (CHBalanza.Checked)
            {
                this.Checkbox_Balanza = "1";
            }
            else
            {
                this.Checkbox_Balanza = "0";
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

            if (CHEmpaque.Checked)
            {
                this.Checkbox_Empaque = "1";
            }
            else
            {
                this.Checkbox_Empaque = "0";
            }

            if (CHFabricado.Checked)
            {
                this.Checkbox_Fabricado = "1";
            }
            else
            {
                this.Checkbox_Fabricado = "0";
            }


            if (CHRetencion.Checked)
            {
                this.Checkbox_Retencion = "1";
            }
            else
            {
                this.Checkbox_Retencion = "0";
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

            if (DGDetalle_CodigoDeBarra.Rows.Count == 0)
            {
                this.Tran_CodBarra = "1";
            }
            else
            {
                this.Tran_CodBarra = "0";
            }

            if (DGDetalle_Compuesto.Rows.Count == 0)
            {
                this.Tran_Compuesto = "1";
            }
            else
            {
                this.Tran_Compuesto = "0";
            }

            if (DGDetalle_Exterior.Rows.Count == 0)
            {
                this.Tran_Exterior = "1";
            }
            else
            {
                this.Tran_Exterior = "0";
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
                //Panel Compuesto
                this.DtDetalle_Compuesto = new DataTable();
                this.DtDetalle_Compuesto.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Compuesto.Columns.Add("Compuesto", System.Type.GetType("System.String"));
                this.DtDetalle_Compuesto.Columns.Add("Descripción", System.Type.GetType("System.String"));
                this.DtDetalle_Compuesto.Columns.Add("Unidad", System.Type.GetType("System.String"));
                this.DtDetalle_Compuesto.Columns.Add("Medida", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Compuesto.DataSource = this.DtDetalle_Compuesto;
                this.DGDetalle_Compuesto.AutoGenerateColumns = false;

                //Panel Exterior
                this.DtDetalle_Exterior = new DataTable();
                this.DtDetalle_Exterior.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Exterior.Columns.Add("Idproveedor", System.Type.GetType("System.Int32"));
                this.DtDetalle_Exterior.Columns.Add("Aduana", System.Type.GetType("System.String"));
                this.DtDetalle_Exterior.Columns.Add("Comisión", System.Type.GetType("System.String"));
                this.DtDetalle_Exterior.Columns.Add("Documentación", System.Type.GetType("System.String"));
                this.DtDetalle_Exterior.Columns.Add("Adicional", System.Type.GetType("System.String"));
                this.DtDetalle_Exterior.Columns.Add("Exportación", System.Type.GetType("System.String"));
                this.DtDetalle_Exterior.Columns.Add("Importación", System.Type.GetType("System.String"));
                this.DtDetalle_Exterior.Columns.Add("Seguridad", System.Type.GetType("System.String"));

                //Captura de los Datos en las Tablas
                this.DGDetalle_Exterior.DataSource = this.DtDetalle_Exterior;

                //Panel Codigo de Barra
                this.DtDetalle_CodigoDeBarra = new DataTable();
                this.DtDetalle_CodigoDeBarra.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_CodigoDeBarra.Columns.Add("Código de Barra", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_CodigoDeBarra.DataSource = this.DtDetalle_CodigoDeBarra;

                //Panel Proveedores
                this.DtDetalle_Proveedor = new DataTable();
                this.DtDetalle_Proveedor.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Proveedor.Columns.Add("Código", System.Type.GetType("System.Int32"));
                this.DtDetalle_Proveedor.Columns.Add("Proveedor", System.Type.GetType("System.String"));
                this.DtDetalle_Proveedor.Columns.Add("Documento", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Proveedor.DataSource = this.DtDetalle_Proveedor;
                this.DGDetalle_Proveedor.AutoGenerateColumns = false;

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
                this.DtDetalle_Igualdad.Columns.Add("Código", System.Type.GetType("System.String"));
                this.DtDetalle_Igualdad.Columns.Add("Producto", System.Type.GetType("System.String"));
                this.DtDetalle_Igualdad.Columns.Add("Marca", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalle_Igualdad.DataSource = this.DtDetalle_Igualdad;

                //Panel Ubicacion
                this.DtDetalle_Ubicacion = new DataTable();
                this.DtDetalle_Ubicacion.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle_Ubicacion.Columns.Add("Idbodega", System.Type.GetType("System.Int32"));
                this.DtDetalle_Ubicacion.Columns.Add("Bodega", System.Type.GetType("System.String"));
                this.DtDetalle_Ubicacion.Columns.Add("Ubicación", System.Type.GetType("System.String"));
                this.DtDetalle_Ubicacion.Columns.Add("Estante", System.Type.GetType("System.String"));
                this.DtDetalle_Ubicacion.Columns.Add("Nivel", System.Type.GetType("System.String"));
                //Captura de los Datos en las Tablas
                this.DGDetalles_Ubicacion.DataSource = DtDetalle_Ubicacion;
                this.DGDetalles_Ubicacion.AutoGenerateColumns = false;


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

                //Formato de Celdas
                //this.DGDetalles_Lotes.Columns[2].DefaultCellStyle.Format = "##,##0.00";

                //************************************* Alineacion de las Celdas *************************************

                //Panel Codigo de Barra
                this.DGDetalle_CodigoDeBarra.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Panel Proveedores
                this.DGDetalle_Proveedor.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalle_Proveedor.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

                //************************************* Ocultacion de Columnas *************************************
                this.DGDetalle_Igualdad.Columns[0].Visible = false;
                this.DGDetalle_CodigoDeBarra.Columns[0].Visible = false;
                this.DGDetalle_Compuesto.Columns[0].Visible = false;

                this.DGDetalle_Impuesto.Columns[0].Visible = false;
                this.DGDetalle_Impuesto.Columns[1].Visible = false;

                this.DGDetalle_Proveedor.Columns[0].Visible = false;
                //this.DGDetalle_Proveedor.Columns[1].Visible = false;

                this.DGDetalles_Ubicacion.Columns[0].Visible = false;
                this.DGDetalles_Ubicacion.Columns[1].Visible = false;

                this.DGDetalle_Exterior.Columns[0].Visible = false;
                this.DGDetalle_Exterior.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Auto_CodigoSQL()
        {
            try
            {
                DataTable Datos = Negocio.fProducto_Inventario.AutoIncrementable(Convert.ToInt32(0));
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
                    //MessageBox.Show("No Se Encontraron Registros en la Base de Datos", "Sistema Instituto Fundecar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Total_Fabricacion()
        {
            try
            {
                double Total = 0;
                double materialprincipal, materialsecundario, materialterciario, otromaterial, manodeobra, materiales, envio, almacenamiento, maquinaria, herramientamanual = 0;

                materialprincipal = Convert.ToDouble(TBFabri_MaterialPrincipal.Text);
                materialsecundario = Convert.ToDouble(TBFabri_MaterialSecundario.Text);
                materialterciario = Convert.ToDouble(TBFabri_MaterialTerciario.Text);
                otromaterial = Convert.ToDouble(TBFabri_OtroMaterial.Text);
                manodeobra = Convert.ToDouble(TBFabri_ManoDeObra.Text);
                materiales = Convert.ToDouble(TBFabri_Materiales.Text);
                envio = Convert.ToDouble(TBFabri_Envio.Text);
                almacenamiento = Convert.ToDouble(TBFabri_Almacenamiento.Text);
                maquinaria = Convert.ToDouble(TBFabri_Maquinaria.Text);
                herramientamanual = Convert.ToDouble(TBFabri_HerramientaManual.Text);

                Total = (materialprincipal + materialsecundario + materialterciario + otromaterial + manodeobra + materiales + envio + almacenamiento + maquinaria + herramientamanual);

                //this.TBFabri_TotalFabricacion.Text = Convert.ToString(Total);

                this.TBFabri_TotalFabricacion.Text = string.Format("{0:N2}", Total);
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

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBNombre.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Producto a registrar");
                    this.TBNombre.Focus();
                }
                else if (this.TBDescripcion01.Text == Campo)
                {
                    MensajeError("Ingrese la Descripcion del Producto");
                    this.TBDescripcion01.Focus();
                }
                else if (this.TBCodigo.Text == Campo)
                {
                    MensajeError("Ingrese el Código del Producto");
                    this.TBCodigo.Focus();
                }
                else if (this.CBGrupo.SelectedIndex == 0)
                {
                    MensajeError("Seleccione el Grupo al cual pertenece el Producto"); ;
                }
                else if (this.CBMarca.SelectedIndex == 0)
                {
                    MensajeError("Seleccione la Marca del Producto");
                }
                else if (this.TBCompraminima.Text == String.Empty)
                {
                    MensajeError("Por Favor Ingrese la Cantidad de Compra Mínima");
                    this.TBCompraminima.Focus();
                }
                else if (this.TBCompraMaxima.Text == String.Empty)
                {
                    MensajeError("Por Favor Ingrese la Cantidad de Compra Maxima");
                    this.TBCompraMaxima.Focus();
                }
                else if (this.TBVentaMinima.Text == String.Empty)
                {
                    MensajeError("Por Favor Ingrese la Cantidad de Venta Mínima");
                    this.TBVentaMinima.Focus();
                }
                else if (this.TBVentaMaxima.Text == String.Empty)
                {
                    MensajeError("Por Favor Ingrese la Cantidad de Venta Maxima");
                    this.TBVentaMaxima.Focus();
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
                                 //Datos Auxiliares y Llaves Primarias
                                 1, Convert.ToInt32(this.CBMarca.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue), Convert.ToInt32(this.CBTipo.SelectedValue), Convert.ToInt32(this.CBEmpaque.SelectedValue),

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Ubicacion), Convert.ToInt32(Tran_Igualdad), Convert.ToInt32(Tran_Impuesto), Convert.ToInt32(Tran_Proveedor), Convert.ToInt32(Tran_CodBarra), Convert.ToInt32(Tran_Compuesto), Convert.ToInt32(Tran_Exterior),

                                 //Panel Datos Basicos
                                 this.CBArea.Text, this.TBCodigo.Text, this.TBNombre.Text, this.TBReferencia.Text, this.TBDescripcion01.Text, this.TBPresentacion.Text, Convert.ToInt64(this.TBComision.Text),

                                 Convert.ToInt32(Checkbox_Vencimiento), Convert.ToInt32(Checkbox_Impuesto), Convert.ToInt32(Checkbox_Importado), Convert.ToInt32(Checkbox_Exportado), Convert.ToInt32(Checkbox_Ofertable), Convert.ToInt32(Checkbox_Fabricado), Convert.ToInt32(Checkbox_Comision), Convert.ToInt32(Checkbox_Empaque), Convert.ToInt32(Checkbox_Balanza), Convert.ToInt32(Checkbox_Retencion), Convert.ToInt64(TBCompraminima.Text), Convert.ToInt32(Checkbox_Compras), Convert.ToInt32(Checkbox_Ventas), Convert.ToInt64(TBCompraMaxima.Text), Convert.ToInt64(TBVentaMinima.Text), Convert.ToInt64(TBVentaMaxima.Text),

                                 //Panel de Valores - Datos Basicos
                                 Convert.ToDouble(this.TBValor_CompraPromedio.Text), Convert.ToDouble(this.TBValor_CompraFinal.Text), Convert.ToDouble(this.TBValor_Venta01.Text), Convert.ToDouble(this.TBValor_Venta02.Text), Convert.ToDouble(this.TBValor_Venta03.Text), Convert.ToDouble(this.TBValor_Mayorista.Text),

                                 //Panel de Valores - Porcentajes
                                 Convert.ToDouble(this.TBValor_PorVenta01.Text), Convert.ToDouble(this.TBValor_PorVenta02.Text), Convert.ToDouble(this.TBValor_PorVenta03.Text), Convert.ToDouble(this.TBValor_PorMayorista.Text),

                                 ////Panel de Valores - Valor Base
                                 Convert.ToDouble(this.TBValorBase_Inicial01.Text), Convert.ToDouble(this.TBValorBase_Inicial02.Text), Convert.ToDouble(this.TBValorBase_Inicial03.Text), Convert.ToDouble(this.TBValorBase_InicialMayorista.Text),

                                 ////Panel de Valores - Impuesto
                                 Convert.ToDouble(this.TBValor_ImpVenta01.Text), Convert.ToDouble(this.TBValor_ImpVenta02.Text), Convert.ToDouble(this.TBValor_ImpVenta03.Text), Convert.ToDouble(this.TBValor_ImpMayorista.Text),

                                 ////Panel de Valores - Unidades
                                 this.CBUnidad.Text, this.TBValor_Unidad.Text,

                                 //Panel - Fabricacion
                                 Convert.ToDouble(this.TBFabri_MaterialPrincipal.Text), Convert.ToDouble(this.TBFabri_MaterialSecundario.Text), Convert.ToDouble(this.TBFabri_MaterialTerciario.Text), Convert.ToDouble(this.TBFabri_OtroMaterial.Text), Convert.ToDouble(this.TBFabri_ManoDeObra.Text), Convert.ToDouble(this.TBFabri_Materiales.Text), Convert.ToDouble(this.TBFabri_Envio.Text), Convert.ToDouble(this.TBFabri_Almacenamiento.Text), Convert.ToDouble(this.TBFabri_Maquinaria.Text), Convert.ToDouble(this.TBFabri_HerramientaManual.Text), Convert.ToDouble(this.TBFabri_TotalFabricacion.Text), Convert.ToInt64(this.TBFabri_DiasFormal.Text), Convert.ToInt64(this.TBFabri_DiasProrroga.Text),

                                 //Tabla de Detalles - Lote, Impuesto, Igualdad, Proveedor, Ubicacion, Codigo de Barra - Detalles de Productos
                                 this.DtDetalle_Impuesto, this.DtDetalle_Igualdad, this.DtDetalle_Proveedor, this.DtDetalle_Ubicacion, this.DtDetalle_CodigoDeBarra, this.DtDetalle_Exterior, this.DtDetalle_Compuesto,

                                 //Panel de Imagen
                                 Imagen_Producto
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fProducto_Inventario.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 2, Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(this.CBMarca.SelectedValue), Convert.ToInt32(this.CBGrupo.SelectedValue), Convert.ToInt32(this.CBTipo.SelectedValue), Convert.ToInt32(this.CBEmpaque.SelectedValue),

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Ubicacion), Convert.ToInt32(Tran_Igualdad), Convert.ToInt32(Tran_Impuesto), Convert.ToInt32(Tran_Proveedor), Convert.ToInt32(Tran_CodBarra), Convert.ToInt32(Tran_Compuesto), Convert.ToInt32(Tran_Exterior),

                                 //Panel Datos Basicos
                                 this.CBArea.Text, this.TBCodigo.Text, this.TBNombre.Text, this.TBReferencia.Text, this.TBDescripcion01.Text, this.TBPresentacion.Text, Convert.ToInt64(this.TBComision.Text),

                                 Convert.ToInt32(Checkbox_Vencimiento), Convert.ToInt32(Checkbox_Impuesto), Convert.ToInt32(Checkbox_Importado), Convert.ToInt32(Checkbox_Exportado), Convert.ToInt32(Checkbox_Ofertable), Convert.ToInt32(Checkbox_Fabricado), Convert.ToInt32(Checkbox_Comision), Convert.ToInt32(Checkbox_Empaque), Convert.ToInt32(Checkbox_Balanza), Convert.ToInt32(Checkbox_Retencion), Convert.ToInt32(Checkbox_Compras), Convert.ToInt32(Checkbox_Ventas), Convert.ToInt64(TBCompraminima.Text), Convert.ToInt64(TBCompraMaxima.Text), Convert.ToInt64(TBVentaMinima.Text), Convert.ToInt64(TBVentaMaxima.Text),

                                 //Panel de Valores - Datos Basicos
                                 Convert.ToDouble(this.TBValor_CompraPromedio.Text), Convert.ToDouble(this.TBValor_CompraFinal.Text), Convert.ToDouble(this.TBValor_Venta01.Text), Convert.ToDouble(this.TBValor_Venta02.Text), Convert.ToDouble(this.TBValor_Venta03.Text), Convert.ToDouble(this.TBValor_Mayorista.Text),

                                 //Panel de Valores - Porcentajes
                                 Convert.ToDouble(this.TBValor_PorVenta01.Text), Convert.ToDouble(this.TBValor_PorVenta02.Text), Convert.ToDouble(this.TBValor_PorVenta03.Text), Convert.ToDouble(this.TBValor_PorMayorista.Text),

                                 ////Panel de Valores - Valor Base
                                 Convert.ToDouble(this.TBValorBase_Inicial01.Text), Convert.ToDouble(this.TBValorBase_Inicial02.Text), Convert.ToDouble(this.TBValorBase_Inicial03.Text), Convert.ToDouble(this.TBValorBase_InicialMayorista.Text),

                                 ////Panel de Valores - Impuesto
                                 Convert.ToDouble(this.TBValor_ImpVenta01.Text), Convert.ToDouble(this.TBValor_ImpVenta02.Text), Convert.ToDouble(this.TBValor_ImpVenta03.Text), Convert.ToDouble(this.TBValor_ImpMayorista.Text),

                                 ////Panel de Valores - Unidades
                                 this.CBUnidad.Text, this.TBValor_Unidad.Text,

                                 //Panel - Fabricacion
                                 Convert.ToDouble(this.TBFabri_MaterialPrincipal.Text), Convert.ToDouble(this.TBFabri_MaterialSecundario.Text), Convert.ToDouble(this.TBFabri_MaterialTerciario.Text), Convert.ToDouble(this.TBFabri_OtroMaterial.Text), Convert.ToDouble(this.TBFabri_ManoDeObra.Text), Convert.ToDouble(this.TBFabri_Materiales.Text), Convert.ToDouble(this.TBFabri_Envio.Text), Convert.ToDouble(this.TBFabri_Almacenamiento.Text), Convert.ToDouble(this.TBFabri_Maquinaria.Text), Convert.ToDouble(this.TBFabri_HerramientaManual.Text), Convert.ToDouble(this.TBFabri_TotalFabricacion.Text), Convert.ToInt64(this.TBFabri_DiasFormal.Text), Convert.ToInt64(this.TBFabri_DiasProrroga.Text),

                                 //Tabla de Detalles - Lote, Impuesto, Igualdad, Proveedor, Ubicacion, Codigo de Barra - Detalles de Productos
                                 this.DtDetalle_Impuesto, this.DtDetalle_Igualdad, this.DtDetalle_Proveedor, this.DtDetalle_Ubicacion, this.DtDetalle_CodigoDeBarra, this.DtDetalle_Exterior, this.DtDetalle_Compuesto,

                                 //Panel de Imagen
                                 Imagen_Producto
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Procedimiento de Digitalización Exitoso - Leal Enterprise \n\n" + "El Producto: “" + this.TBNombre.Text + "” a Sido Registrado Exitosamente");
                        }

                        else
                        {
                            this.MensajeOk("Procedimiento de Modificación Exitoso - Leal Enterprise \n\n" + "El Registro del Producto: “" + this.TBNombre.Text + "” a Sido Actualizado Exitosamente");
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
                    this.Diseño_TablasGenerales();
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
                this.lblTotal_Codigodebarra.Text = "Datos Registrados: 0";
                this.lblTotal_Compuesto.Text = "Datos Registrados: 0";
                this.lblTotal_Exterior.Text = "Datos Registrados: 0";
                this.lblTotal_Igualdad.Text = "Datos Registrados: 0";
                this.lblTotal_Impuesto.Text = "Datos Registrados: 0";
                this.lblTotal_Proveedor.Text = "Datos Registrados: 0";
                this.lblTotal_Stock.Text = "Datos Registrados: 0";
                this.lblTotal_Ubicacion.Text = "Datos Registrados: 0";
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
                        fila["Idbodega"] = Convert.ToInt32(this.TBIdbodega_Ubicacion.Text);
                        fila["Bodega"] = this.TBBodega_Ubicacion.Text;
                        fila["Ubicación"] = this.TBUbicacion.Text;
                        fila["Estante"] = this.TBEstante.Text;
                        fila["Nivel"] = this.TBNivel.Text;
                        this.DtDetalle_Ubicacion.Rows.Add(fila);

                        this.lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);

                        //
                        //this.CBBodega.SelectedIndex = 0;
                        this.TBIdbodega_Ubicacion.Clear();
                        this.TBBodega_Ubicacion.Clear();
                        this.TBUbicacion.Clear();
                        this.TBEstante.Clear();
                        this.TBNivel.Clear();

                        this.TBUbicacion.Select();
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
                        DialogResult result = MessageBox.Show("¿Desea Registrar la Ubicacion del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fProducto_Inventario.Guardar_Ubicacion

                                    (
                                        //Datos Auxiliares
                                        Convert.ToInt32(1),

                                         //Datos Basicos
                                         Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(this.TBIdbodega_Ubicacion.Text), this.TBBodega_Ubicacion.Text, this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("La Ubicación del Producto: " + TBNombre.Text + " con Código: " + this.TBCodigo.Text + " a Sido Registrada Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            //this.CBBodega.SelectedIndex = 0;
                            this.TBIdbodega_Ubicacion.Clear();
                            this.TBBodega_Ubicacion.Clear();
                            this.TBUbicacion.Clear();
                            this.TBEstante.Clear();
                            this.TBNivel.Clear();

                            this.Actualizar_DetUbicacion();
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

                    this.lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);
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
                        this.MensajeError("Por favor Especifique el Código de Barra que desea agregar");
                        this.TBCodigodeBarra.Select();
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_CodigoDeBarra.Rows)
                        {
                            if (Convert.ToString(Fila["Código de Barra"]) == TBCodigodeBarra.Text)
                            {
                                this.MensajeError("El Código de Barra Que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_CodigoDeBarra.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            fila["Código de Barra"] = this.TBCodigodeBarra.Text;
                            this.DtDetalle_CodigoDeBarra.Rows.Add(fila);

                            //
                            this.lblTotal_Codigodebarra.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_CodigoDeBarra.Rows.Count);
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
                        this.MensajeError("Por favor Especifique el Código de Barra que desea agregar");
                        this.TBCodigodeBarra.Select();
                    }
                    else
                    {
                        foreach (DataRow Fila in DtDetalle_CodigoDeBarra.Rows)
                        {
                            if (Convert.ToString(Fila["Código de Barra"]) == TBCodigodeBarra.Text)
                            {
                                this.MensajeError("El Código de Barra Que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Código de Barra a la Lista?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProducto_Inventario.Guardar_CodigoDeBarra

                            (
                                //Datos Auxiliares
                                1,

                                //Datos Basicos
                                Convert.ToInt32(this.TBIdproducto.Text), this.TBCodigodeBarra.Text
                            );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Código de Barra: " + this.TBCodigodeBarra.Text + " del Producto: " + this.TBNombre.Text + " a Sido Agregado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }
                        }
                        else
                        {
                            this.TBCodigodeBarra.Clear();
                            this.TBCodigodeBarra.Select();

                            //
                            this.Actualizar_DetCodigoDeBarra();
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
                    this.lblTotal_Codigodebarra.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_CodigoDeBarra.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione el Código de Barra que desea Remover del registo");
            }
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
            //********************* PROCESO PARA FORMATEAR EL TEXBOXT Y PASAR DE FORMATO MONEDA A FORMATO NATURAL O LIMPIO (SIN NINGUN FORMATO)

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
            tb.Text = string.Format("{0:#}", numero);

            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor_Venta02.Text == "0")
            {
                this.TBValor_Venta02.BackColor = Color.Azure;
                this.TBValor_Venta02.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor_Venta02.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor_Venta02.BackColor = Color.Azure;
                this.TBValor_Venta02.ForeColor = Color.FromArgb(0, 0, 0);
            }
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

        private void TBValordecompra_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBValor_CompraFinal.BackColor = Color.Azure;
        }

        private void TBVentaMayorista_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor_Mayorista.Text == "0")
            {
                this.TBValor_Mayorista.BackColor = Color.Azure;
                this.TBValor_Mayorista.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor_Mayorista.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor_Mayorista.BackColor = Color.Azure;
                this.TBValor_Mayorista.ForeColor = Color.FromArgb(0, 0, 0);
            }

            //********************* PROCESO PARA FORMATEAR EL TEXBOXT Y PASAR DE FORMATO MONEDA A FORMATO NATURAL O LIMPIO (SIN NINGUN FORMATO)

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
            tb.Text = string.Format("{0:#}", numero);
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
            TBPresentacion.BackColor = Color.FromArgb(3, 155, 229);
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

                    this.TBDescripcion02.Select();
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
                        this.TBComision.Select();
                    }
                    else
                    {
                        this.TBCompraminima.Select();
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
                    if (CHImpuesto.Checked)
                    {
                        //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                        this.TBValor_Venta01.Select();
                    }
                    else
                    {
                        //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                        this.TBValorBase_Inicial01.Select();
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

        private void CBVencimiento_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CBImpuesto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CHImpuesto.Checked)
            {
                //this.btnExaminar_Impuesto.Enabled = true;
                this.TCPrincipal.TabPages.Add(TPImpuesto);


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


                //
                this.TBValorBase_Inicial01.Enabled = false;
                this.TBValorBase_Inicial01.BackColor = Color.FromArgb(245, 245, 245);
                this.TBValorBase_Inicial02.Enabled = false;
                this.TBValorBase_Inicial02.BackColor = Color.FromArgb(245, 245, 245);
                this.TBValorBase_Inicial03.Enabled = false;
                this.TBValorBase_Inicial03.BackColor = Color.FromArgb(245, 245, 245);
                this.TBValorBase_InicialMayorista.Enabled = false;
                this.TBValorBase_InicialMayorista.BackColor = Color.FromArgb(245, 245, 245);

                //
                this.TBValor_Venta01.Enabled = true;
                this.TBValor_Venta01.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor_Venta02.Enabled = true;
                this.TBValor_Venta02.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor_Venta03.Enabled = true;
                this.TBValor_Venta03.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor_Mayorista.Enabled = true;
                this.TBValor_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            }
            else
            {
                this.TCPrincipal.TabPages.Remove(TPImpuesto);

                this.TBValorBase_Inicial01.Enabled = true;
                this.TBValorBase_Inicial01.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValorBase_Inicial02.Enabled = true;
                this.TBValorBase_Inicial02.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValorBase_Inicial03.Enabled = true;
                this.TBValorBase_Inicial03.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValorBase_InicialMayorista.Enabled = true;
                this.TBValorBase_InicialMayorista.BackColor = Color.FromArgb(3, 155, 229);

                //
                this.TBValor_Venta01.Enabled = false;
                this.TBValor_Venta01.BackColor = Color.FromArgb(245, 245, 245);
                this.TBValor_Venta02.Enabled = false;
                this.TBValor_Venta02.BackColor = Color.FromArgb(245, 245, 245);
                this.TBValor_Venta03.Enabled = false;
                this.TBValor_Venta03.BackColor = Color.FromArgb(245, 245, 245);
                this.TBValor_Mayorista.Enabled = false;
                this.TBValor_Mayorista.BackColor = Color.FromArgb(245, 245, 245);

                this.TBValor_PorVenta01.Text = "0";
                this.TBValor_PorVenta02.Text = "0";
                this.TBValor_PorVenta03.Text = "0";
                this.TBValor_PorMayorista.Text = "0";

                this.TBValor_ImpVenta01.Text = "0";
                this.TBValor_ImpVenta02.Text = "0";
                this.TBValor_ImpVenta03.Text = "0";
                this.TBValor_ImpMayorista.Text = "0";

                this.TBValor_Venta01.Text = "0";
                this.TBValor_Venta02.Text = "0";
                this.TBValor_Venta03.Text = "0";
                this.TBValor_Mayorista.Text = "0";


                //Panel - Valores
                this.TBValor_CompraPromedio.Text = "0";
                this.TBValor_CompraFinal.Text = "0";

                this.TBValor_Unidad.Text = "0";

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
                    else if (this.TBIgualdad_Codigo.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Producto o Servicio de Igualdad que desea Agregar");
                        this.TBIgualdad_Codigo.Select();
                    }
                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Igualdad.Rows)
                        {
                            if (Convert.ToString(Fila[1]) == TBIdigualdad_Producto.Text)
                            {
                                this.MensajeError("El Producto o Servicio Que Desea Agregar ya se Encuentra en la Lista");
                                this.TBIdigualdad_Producto.Clear();
                            }
                            else if (Convert.ToString(Fila[2]) == TBIdigualdad_Producto.Text)
                            {
                                this.MensajeError("El Producto o Servicio Que Desea Agregar ya se Encuentra en la Lista");
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

                            //
                            this.lblTotal_Igualdad.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Igualdad.Rows.Count);
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
                                this.MensajeError("El producto o servicio Que Desea Agregar ya se Encuentra en la Lista");
                                this.TBIgualdad_Producto.Clear();
                            }
                            else if (Convert.ToString(Fila["Producto"]) == TBIgualdad_Producto.Text)
                            {
                                this.MensajeError("El producto o servicio Que Desea Agregar ya se Encuentra en la Lista");
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
                                    //Datos Auxiliares
                                    1,

                                    //Datos Basicos
                                    Convert.ToInt32(this.TBIdproducto.Text), this.TBCodigo.Text, this.TBIgualdad_Producto.Text, this.TBIgualdad_Marca.Text
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
                            if (Convert.ToString(Fila[1]) == TBIdimpuesto.Text)
                            {
                                this.MensajeError("El Impuesto Que Desea Agregar ya se Encuentra en la Lista");
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

                            this.lblTotal_Impuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Impuesto.Rows.Count);

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
                                this.MensajeError("El Impuesto Que Desea Agregar ya se Encuentra en la Lista");
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
                                //Datos Auxiliares
                                2,

                                //Datos Basicos
                                Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(TBIdimpuesto.Text), this.TBImpuesto.Text, this.TBValor_Impuesto.Text, this.TBDescripcion_Impuesto.Text
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
                        this.MensajeError("Por Favor Especifique el Proveedor Que Desea Agregar");
                        this.TBProveedor.Select();
                    }
                    else if (this.TBProveedor_Documento.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Numero de Documento del Proveedor que Desea Agregar");
                        this.TBProveedor_Documento.Select();
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Proveedor.Rows)
                        {
                            if (Convert.ToString(Fila[1]) == TBIdproveedor.Text)
                            {
                                this.MensajeError("El Proveedor Que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Proveedor.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            fila["Código"] = Convert.ToInt32(this.TBIdproveedor.Text);
                            fila["Proveedor"] = this.TBProveedor.Text;
                            fila["Documento"] = this.TBProveedor_Documento.Text;
                            this.DtDetalle_Proveedor.Rows.Add(fila);

                            this.lblTotal_Proveedor.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Proveedor.Rows.Count);
                        }

                        //
                        this.TBIdproveedor.Clear();
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
                        this.MensajeError("Por Favor Especifique el Proveedor Que Desea Agregar");
                        this.TBProveedor.Select();
                    }
                    else if (this.TBProveedor_Documento.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Numero de Documento del Proveedor que Desea Agregar");
                        this.TBProveedor_Documento.Select();
                    }

                    else
                    {
                        foreach (DataRow Fila in DtDetalle_Proveedor.Rows)
                        {
                            if (Convert.ToString(Fila[1]) == TBIdproveedor.Text)
                            {
                                this.MensajeError("El Proveedor Que Desea Agregar ya se Encuentra en la Lista");
                                this.TBIdproveedor.Clear();
                                this.TBProveedor.Clear();
                                this.TBProveedor_Documento.Clear();
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Proveedor a la Lista del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProducto_Inventario.Guardar_Proveedor

                                (
                                    //Datos Auxiliares
                                    1,

                                    //Datos Basicos
                                    Convert.ToInt32(TBIdproducto.Text), Convert.ToInt32(TBIdproveedor.Text), this.TBProveedor.Text, this.TBProveedor_Documento.Text
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Proveedor: " + this.TBProveedor.Text + " del Producto: " + TBNombre.Text + " con Código: " + this.TBCodigo.Text + " A Sido Registrado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdproveedor.Clear();
                            this.TBProveedor.Clear();
                            this.TBProveedor_Documento.Clear();

                            //
                            this.Actualizar_DetProveedor();
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

                    this.lblTotal_Impuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Impuesto.Rows.Count);
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

        private void btnExaminar_Igualdad_Click(object sender, EventArgs e)
        {
            frmFiltro_Producto frmFiltro_Producto = new frmFiltro_Producto();
            frmFiltro_Producto.ShowDialog();
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

                this.TBCompraminima.Select();
            }
        }

        private void TBComision_Porcentaje_Enter(object sender, EventArgs e)
        {
            this.TBComision.BackColor = Color.Azure;
        }

        private void TBComision_Porcentaje_Leave(object sender, EventArgs e)
        {
            this.TBComision.BackColor = Color.FromArgb(3, 155, 229);
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
            this.TBComp_Descripcion.BackColor = Color.Azure;
        }

        //*********** PANEL EXTERIOR - EVENTO ENTER *********** 
        private void TBExterior_Aduana_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Aduana.BackColor = Color.Azure;
        }

        private void TBExterior_Comision_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Comision.BackColor = Color.Azure;
        }

        private void TBExterior_Documento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Documento.BackColor = Color.Azure;
        }


        private void TBExterior_Adicional_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Adicional.BackColor = Color.Azure;
        }

        private void TBExterior_Exportacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Exportacion.BackColor = Color.Azure;
        }

        private void TBExterior_Importacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Importacion.BackColor = Color.Azure;
        }

        private void TBExterior_Seguridad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBExterior_Seguridad.BackColor = Color.Azure;
        }

        //*********** PANEL VALOR DE FABRICACION
        private void TBFabri_Material01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_MaterialPrincipal.BackColor = Color.Azure;
        }

        private void TBFabri_Material02_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_MaterialSecundario.BackColor = Color.Azure;
        }

        private void TBFabri_Material03_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_MaterialTerciario.BackColor = Color.Azure;
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
            this.TBFabri_HerramientaManual.BackColor = Color.Azure;
        }

        private void TBFabri_TotalFabricacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_TotalFabricacion.BackColor = Color.Azure;
        }

        private void TBValor_Venta03_Enter(object sender, EventArgs e)
        {
            //********************* PROCESO PARA FORMATEAR EL TEXBOXT Y PASAR DE FORMATO MONEDA A FORMATO NATURAL O LIMPIO (SIN NINGUN FORMATO)

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
            tb.Text = string.Format("{0:#}", numero);

            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor_Venta03.Text == "0")
            {
                this.TBValor_Venta03.BackColor = Color.Azure;
                this.TBValor_Venta03.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor_Venta03.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor_Venta03.BackColor = Color.Azure;
                this.TBValor_Venta03.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBValor_Unidad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValor_Unidad.BackColor = Color.Azure;
        }


        private void TBCompuesto_Leave(object sender, EventArgs e)
        {
            this.TBCompuesto.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompuesto_Descrip_Leave(object sender, EventArgs e)
        {
            this.TBComp_Descripcion.BackColor = Color.FromArgb(3, 155, 229);
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

        private void TBFabri_Material01_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_MaterialPrincipal.BackColor = Color.FromArgb(3, 155, 229);

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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
            this.TBFabri_MaterialSecundario.BackColor = Color.FromArgb(3, 155, 229);

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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
            this.TBFabri_MaterialTerciario.BackColor = Color.FromArgb(3, 155, 229);

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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
            this.TBFabri_HerramientaManual.BackColor = Color.FromArgb(3, 155, 229);

            //SE PROCEDE A CALCULAR EL TOTAL DEL VALOR DE FABRICACION
            this.Total_Fabricacion();

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
            if (TBValor_Venta03.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor_Venta03.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor_Venta03.Text = "0";
                this.TBValor_Venta03.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValor_Venta03.BackColor = Color.FromArgb(3, 155, 229);

                //
                int Impuesto_SQL = 0;
                double Valor01, Porcentaje01, Operacion, Mayorista, Divisor, Multiplicador, Impuesto01, Impuesto_Mayorista;
                double Base01, Base_Mayorista;


                foreach (DataGridViewRow row in DGDetalle_Impuesto.Rows)
                {
                    if (row.Cells[3].Value != null)
                        Impuesto_SQL += (Int32)row.Cells[3].Value;

                    //Se procede a calcular el IVA o Impuestos

                    this.TBValor_PorVenta03.Text = Impuesto_SQL.ToString();

                    this.TBDivisor_Impuesto.Text = "1." + TBValor_PorVenta03.Text;
                    this.TBmultiplicador_Impuesto.Text = "0." + TBValor_PorVenta03.Text;

                    //Se procede a calcular el IVA o Impuestos
                    Valor01 = Convert.ToDouble(TBValor_Venta03.Text);
                    Divisor = Convert.ToDouble(TBDivisor_Impuesto.Text);
                    Multiplicador = Convert.ToDouble(TBmultiplicador_Impuesto.Text);

                    //Primero se Calcula el Valor Base
                    Base01 = Valor01 / Divisor;
                    this.TBValorBase_Inicial03.Text = Base01.ToString("N");

                    //Despues se Calcula el Valor del Impuesto
                    Impuesto01 = Base01 * Multiplicador;
                    this.TBValor_ImpVenta03.Text = Impuesto01.ToString("N");

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

        private void TBFabri_Material01_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Material02_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Material03_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_OtroMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_ManoDeObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Materiales_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Envio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Almacenamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Maquinaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_Manual_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_TotalFabricacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
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

                    this.TBComp_Descripcion.Select();
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
                            this.TBComp_Descripcion.Select();
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
                            this.TBComp_Descripcion.Select();
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

        private void TBExterior_Comision_KeyUp(object sender, KeyEventArgs e)
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

        private void TBExterior_Documento_KeyUp(object sender, KeyEventArgs e)
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

        private void TBExterior_Adicional_KeyUp(object sender, KeyEventArgs e)
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

        private void TBExterior_Exportacion_KeyUp(object sender, KeyEventArgs e)
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

        private void TBExterior_Importacion_KeyUp(object sender, KeyEventArgs e)
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

        private void TBExterior_Seguridad_KeyUp(object sender, KeyEventArgs e)
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

        private void btnExaminar_Exterior_Click(object sender, EventArgs e)
        {
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

        private void TBFabri_Material01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_MaterialSecundario.Select();
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

                    this.TBFabri_MaterialTerciario.Select();
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
                            this.TBFabri_MaterialTerciario.Select();
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
                            this.TBFabri_MaterialTerciario.Select();
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

        private void TBValorBase_Inicial01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValorBase_Inicial01.BackColor = Color.Azure;

            //********************* PROCESO PARA FORMATEAR EL TEXBOXT Y PASAR DE FORMATO MONEDA A FORMATO NATURAL O LIMPIO (SIN NINGUN FORMATO)

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
            tb.Text = string.Format("{0:#}", numero);

            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValorBase_Inicial01.Text == "0")
            {
                this.TBValorBase_Inicial01.BackColor = Color.Azure;
                this.TBValorBase_Inicial01.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValorBase_Inicial01.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValorBase_Inicial01.BackColor = Color.Azure;
                this.TBValorBase_Inicial01.ForeColor = Color.FromArgb(0, 0, 0);
            }

        }

        private void TBValorBase_Inicial02_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValorBase_Inicial02.BackColor = Color.Azure;
        }

        private void TBValorBase_Inicial03_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValorBase_Inicial03.BackColor = Color.Azure;
        }

        private void TBValorBase_InicialMayorista_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBValorBase_InicialMayorista.BackColor = Color.Azure;
        }

        private void TBValorBase_Inicial01_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValorBase_Inicial01.BackColor = Color.FromArgb(3, 155, 229);

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
            //tb.Text = string.Format("{0:N2}", numero);

            tb.Text = string.Format("{0:#}", numero);
        }

        private void TBValorBase_Inicial02_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValorBase_Inicial02.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBValorBase_Inicial01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBValorBase_Inicial02.Select();

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
                            this.TBValorBase_Inicial01.Select();
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
                            this.TBValorBase_Inicial01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorBase_Inicial02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBValorBase_Inicial03.Select();

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
                            this.TBValorBase_Inicial02.Select();
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
                            this.TBValorBase_Inicial02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorBase_Inicial03_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBValorBase_InicialMayorista.Select();

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
                            this.TBValorBase_Inicial03.Select();
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
                            this.TBValorBase_Inicial03.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor_Venta02_KeyUp(object sender, KeyEventArgs e)
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

        private void TBComp_Medida_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBComp_Medida.BackColor = Color.Azure;
        }

        private void TBComp_Medida_Leave(object sender, EventArgs e)
        {
            this.TBComp_Medida.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void btnExaminar_Ubicacion_Click(object sender, EventArgs e)
        {
            frmFiltro_Bodega frmFiltro_Bodega = new frmFiltro_Bodega();
            frmFiltro_Bodega.ShowDialog();
        }

        private void TBImpuesto03_TextChanged(object sender, EventArgs e)
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
            tb.Text = string.Format("{0:#}", numero);
            //TBImpuesto01.Text = string.Format("{0:#}", numero);
            //tb.Text = string.Format("{0:N2}", numero);
        }

        private void TBCompraminima_Enter(object sender, EventArgs e)
        {
            this.TBCompraminima.BackColor = Color.Azure;
        }

        private void TBVentaMinima_Enter(object sender, EventArgs e)
        {
            this.TBVentaMinima.BackColor = Color.Azure;
        }

        private void TBCompraMaxima_Enter(object sender, EventArgs e)
        {
            this.TBCompraMaxima.BackColor = Color.Azure;
        }

        private void TBVentaMaxima_Enter(object sender, EventArgs e)
        {
            this.TBVentaMaxima.BackColor = Color.Azure;
        }

        private void TBDescripcion02_Enter(object sender, EventArgs e)
        {
            this.TBDescripcion02.BackColor = Color.Azure;
        }

        private void TBDescripcion03_Enter(object sender, EventArgs e)
        {
            this.TBDescripcion03.BackColor = Color.Azure;
        }

        private void TBDescripcion02_Leave(object sender, EventArgs e)
        {
            this.TBDescripcion02.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDescripcion03_Leave(object sender, EventArgs e)
        {
            this.TBDescripcion03.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompraminima_Leave(object sender, EventArgs e)
        {
            this.TBCompraminima.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMinima_Leave(object sender, EventArgs e)
        {
            this.TBVentaMinima.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompraMaxima_Leave(object sender, EventArgs e)
        {
            this.TBCompraMaxima.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMaxima_Leave(object sender, EventArgs e)
        {
            this.TBVentaMaxima.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCompraminima_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCompraMaxima.Select();
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
                            this.TBCompraminima.Select();
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
                            this.TBCompraminima.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMinima_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBVentaMaxima.Select();
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
                            this.TBVentaMinima.Select();
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
                            this.TBVentaMinima.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCompraMaxima_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBVentaMinima.Select();
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
                            this.TBCompraMaxima.Select();
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
                            this.TBCompraMaxima.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBVentaMaxima_KeyUp(object sender, KeyEventArgs e)
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
                            this.TBVentaMaxima.Select();
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
                            this.TBVentaMaxima.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDescripcion02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDescripcion03.Select();
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
                            this.TBDescripcion02.Select();
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
                            this.TBDescripcion02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDescripcion03_KeyUp(object sender, KeyEventArgs e)
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
                            this.TBDescripcion03.Select();
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
                            this.TBDescripcion03.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGDetalle_CodigoDeBarra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!Digitar)
                {
                    // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                    DataGridViewRow fila = DGDetalle_CodigoDeBarra.Rows[e.RowIndex];

                    //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                    this.TBCodigodeBarra.Text = Convert.ToString(fila.Cells["Código de Barra"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGDetalle_Compuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!Digitar)
                {
                    // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                    DataGridViewRow fila = DGDetalle_Compuesto.Rows[e.RowIndex];

                    //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                    this.TBCompuesto.Text = Convert.ToString(fila.Cells["Compuesto"].Value);
                    this.TBComp_Descripcion.Text = Convert.ToString(fila.Cells["Descripción"].Value);
                    this.CBComp_Medida.Text = Convert.ToString(fila.Cells["Unidad"].Value);
                    this.TBComp_Medida.Text = Convert.ToString(fila.Cells["Medida"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBFiltro_General_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CBFiltro_General.SelectedIndex == 0)
                {
                    //Se Limpian las Filas y Columnas de la tabla
                    this.CBFiltro_Agrupado.DataSource = null;
                    this.DGResultados_Filtro.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";

                    this.CBFiltro_Agrupado.Enabled = false;
                }
                else if (CBFiltro_General.SelectedIndex == 1)
                {
                    this.CBFiltro_Agrupado.DataSource = fEmpaque.Lista(3);
                    this.CBFiltro_Agrupado.ValueMember = "Código";
                    this.CBFiltro_Agrupado.DisplayMember = "Empaque";

                    //
                    this.CBFiltro_Agrupado.Enabled = true;
                }
                else if (CBFiltro_General.SelectedIndex == 2)
                {
                    this.CBFiltro_Agrupado.DataSource = fGrupoDeProducto.Lista(3);
                    this.CBFiltro_Agrupado.ValueMember = "Código";
                    this.CBFiltro_Agrupado.DisplayMember = "Grupo";

                    //
                    this.CBFiltro_Agrupado.Enabled = true;
                }
                else if (CBFiltro_General.SelectedIndex == 3)
                {
                    this.CBFiltro_Agrupado.DataSource = fMarca.Lista(3);
                    this.CBFiltro_Agrupado.ValueMember = "Código";
                    this.CBFiltro_Agrupado.DisplayMember = "Marca";

                    //
                    this.CBFiltro_Agrupado.Enabled = true;
                }
                else if (CBFiltro_General.SelectedIndex == 4)
                {
                    this.CBFiltro_Agrupado.DataSource = fProveedor.Lista(3);
                    this.CBFiltro_Agrupado.ValueMember = "Código";
                    this.CBFiltro_Agrupado.DisplayMember = "Proveedor";

                    //
                    this.CBFiltro_Agrupado.Enabled = true;
                }
                else if (CBFiltro_General.SelectedIndex == 5)
                {
                    this.CBFiltro_Agrupado.DataSource = fTipoDeProducto.Lista(3);
                    this.CBFiltro_Agrupado.ValueMember = "Código";
                    this.CBFiltro_Agrupado.DisplayMember = "Tipo";

                    //
                    this.CBFiltro_Agrupado.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBFiltro_Agrupado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //this.TBCBIdproducto.Text = CBFiltro_Agrupado.SelectedValue.ToString();

                if (CBFiltro_General.SelectedIndex == 1)
                {
                    this.DGResultados_Filtro.DataSource = fEmpaque.Buscar(this.CBFiltro_Agrupado.SelectedValue.ToString(), 4);
                    this.DGResultados_Filtro.Columns[0].Visible = false;
                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados_Filtro.Rows.Count);
                }
                else if (CBFiltro_General.SelectedIndex == 2)
                {
                    this.DGResultados_Filtro.DataSource = fGrupoDeProducto.Buscar(this.CBFiltro_Agrupado.SelectedValue.ToString(), 4);
                    this.DGResultados_Filtro.Columns[0].Visible = false;
                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados_Filtro.Rows.Count);
                }
                else if (CBFiltro_General.SelectedIndex == 3)
                {
                    this.DGResultados_Filtro.DataSource = fMarca.Buscar(this.CBFiltro_Agrupado.SelectedValue.ToString(), 4);
                    this.DGResultados_Filtro.Columns[0].Visible = false;
                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados_Filtro.Rows.Count);
                }
                else if (CBFiltro_General.SelectedIndex == 4)
                {
                    this.DGResultados_Filtro.DataSource = fProveedor.Buscar(this.CBFiltro_Agrupado.SelectedValue.ToString(), 5);
                    this.DGResultados_Filtro.Columns[0].Visible = false;
                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados_Filtro.Rows.Count);
                }
                else if (CBFiltro_General.SelectedIndex == 5)
                {
                    this.DGResultados_Filtro.DataSource = fTipoDeProducto.Buscar(this.CBFiltro_Agrupado.SelectedValue.ToString(), 4);
                    this.DGResultados_Filtro.Columns[0].Visible = false;
                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados_Filtro.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnDetalleProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Editar == "1")
                {
                    //
                    this.Digitar = false;
                    this.Botones();
                    this.TCPrincipal.SelectedIndex = 0;

                    this.TBIdproducto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                    this.TBNombre.Select();

                    //
                    //this.Digitar = false;
                    this.Eliminar_Igualdad = true;
                    this.Eliminar_Impuesto = true;
                    this.Eliminar_Ubicacion = true;
                    this.Eliminar_Proveedor = true;
                    this.Eliminar_CodigoDeBarra = true;
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

        private void TBFabri_DiasFormal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_DiasProrroga_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBFabri_DiasProrroga_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_MaterialPrincipal.Select();
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
                            this.TBFabri_DiasProrroga.Select();
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
                            this.TBFabri_DiasProrroga.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_DiasFormal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_DiasProrroga.Select();
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
                            this.TBFabri_DiasFormal.Select();
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
                            this.TBFabri_DiasFormal.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_TotalFabricacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBFabri_DiasFormal.Select();
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
                            this.TBFabri_TotalFabricacion.Select();
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
                            this.TBFabri_TotalFabricacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFabri_DiasFormal_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_DiasFormal.BackColor = Color.Azure;
        }

        private void TBFabri_DiasProrroga_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca si es obligatorio en la base de datos
            this.TBFabri_DiasProrroga.BackColor = Color.Azure;
        }

        private void TBFabri_DiasFormal_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_DiasFormal.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFabri_DiasProrroga_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBFabri_DiasProrroga.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void DGDetalle_Igualdad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!Digitar)
                {
                    // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                    DataGridViewRow fila = DGDetalle_Igualdad.Rows[e.RowIndex];

                    //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                    this.TBIgualdad_Codigo.Text = Convert.ToString(fila.Cells["Código"].Value);
                    this.TBIgualdad_Producto.Text = Convert.ToString(fila.Cells["Producto"].Value);
                    this.TBIgualdad_Marca.Text = Convert.ToString(fila.Cells["Marca"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGDetalle_Impuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!Digitar)
                {
                    // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                    DataGridViewRow fila = DGDetalle_Impuesto.Rows[e.RowIndex];

                    //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                    this.TBIdimpuesto.Text = Convert.ToString(fila.Cells["Idimpuesto"].Value);
                    this.TBImpuesto.Text = Convert.ToString(fila.Cells["Impuesto"].Value);
                    this.TBValor_Impuesto.Text = Convert.ToString(fila.Cells["Valor"].Value);
                    this.TBDescripcion_Impuesto.Text = Convert.ToString(fila.Cells["Descripción"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGDetalle_Proveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!Digitar)
                {
                    // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                    DataGridViewRow fila = DGDetalle_Proveedor.Rows[e.RowIndex];

                    //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                    this.TBIdproveedor.Text = Convert.ToString(fila.Cells["Código"].Value);
                    this.TBProveedor.Text = Convert.ToString(fila.Cells["Proveedor"].Value);
                    this.TBProveedor_Documento.Text = Convert.ToString(fila.Cells["Documento"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFiltro_Idproveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.DGDetalle_Proveedor.DataSource = fProducto_Inventario.Buscar_Proveedor(1, Convert.ToInt32(this.TBIdproducto.Text));
                this.lblTotal_Proveedor.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Proveedor.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorBase_InicialMayorista_KeyUp(object sender, KeyEventArgs e)
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
                            this.TBValorBase_InicialMayorista.Select();
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
                            this.TBValorBase_InicialMayorista.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorBase_Inicial01_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValorBase_Inicial02_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValorBase_Inicial03_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValorBase_InicialMayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValorBase_Inicial03_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValorBase_Inicial03.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBValorBase_InicialMayorista_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBValorBase_InicialMayorista.BackColor = Color.FromArgb(3, 155, 229);

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

        private void TBCodigodeBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
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

                    this.TBFabri_HerramientaManual.Select();
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

                    this.TBFabri_DiasFormal.Select();
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
                            this.TBFabri_HerramientaManual.Select();
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
                            this.TBFabri_HerramientaManual.Select();
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

        private void btnAgregar_Compuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBCompuesto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Compuesto del Producto");
                        this.TBCompuesto.Select();
                    }
                    else if (this.CBComp_Medida.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor Seleccione la Unidad de Medida del Componente que Desea Agregar");
                    }
                    else if (this.TBComp_Medida.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Medida de la Unidad");
                        this.TBComp_Medida.Select();
                    }
                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Compuesto.Rows)
                        {
                            if (Convert.ToString(Fila[1]) == TBCompuesto.Text)
                            {
                                this.MensajeError("El Compuesto Que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Compuesto.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            fila["Compuesto"] = this.TBCompuesto.Text;
                            fila["Descripción"] = this.TBComp_Descripcion.Text;
                            fila["Unidad"] = this.CBComp_Medida.Text;
                            fila["Medida"] = this.TBComp_Medida.Text;
                            this.DtDetalle_Compuesto.Rows.Add(fila);

                            this.lblTotal_Compuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Compuesto.Rows.Count);
                        }

                        //
                        this.TBCompuesto.Clear();
                        this.TBComp_Descripcion.Clear();
                        this.CBComp_Medida.SelectedIndex = 0;
                        this.TBComp_Medida.Clear();
                    }
                }
                else
                {
                    string rptaDatosBasicos = "";

                    // <<<<<<------ Panel Datos Basicos ------>>>>>

                    if (this.TBCompuesto.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique el Compuesto del Producto");
                        this.TBCompuesto.Select();
                    }
                    else if (this.CBComp_Medida.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor Seleccione la Unidad de Medida del Componente que Desea Agregar");
                    }
                    else if (this.TBComp_Medida.Text == String.Empty)
                    {
                        this.MensajeError("Por favor Especifique la Medida de la Unidad");
                        this.TBComp_Medida.Select();
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Compuesto.Rows)
                        {
                            if (Convert.ToString(Fila["Compuesto"]) == TBIgualdad_Producto.Text)
                            {
                                this.MensajeError("El Compuesto Que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir el Proveedor a la Lista del Producto?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProducto_Inventario.Guardar_Compuesto

                                (
                                    //Datos Auxiliares
                                    1,

                                    //Datos Basicos
                                    Convert.ToInt32(this.TBIdproducto.Text), this.TBCompuesto.Text, this.TBComp_Descripcion.Text, this.CBComp_Medida.Text, this.CBUnidad.Text
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("El Compuesto: " + this.TBCompuesto.Text + " del Producto: " + TBNombre.Text + " con Código: " + this.TBCodigo.Text + " A Sido Registrado Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.TBIdcompuesto.Clear();
                            this.TBCompuesto.Clear();
                            this.TBComp_Descripcion.Clear();
                            this.CBComp_Medida.SelectedIndex = 0;
                            this.TBComp_Medida.Clear();

                            //
                            this.Actualizar_DetCompuesto();
                        }
                        else
                        {
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

        private void btnModificar_Compuesto_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                //rptaDatosBasicos = fProducto_Compuesto.Editar_Ubicacion

                //            (
                //                 //Datos Auxiliares
                //                 Convert.ToInt32(this.TBIdproducto.Text),

                //                 //Panel Datos Basicos
                //                 this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text,

                //                //Si es igual a 1 se registraran los datos en la base de datos
                //                2
                //            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("Los Datos del Compuesto del Producto: “" + this.TBNombre.Text + "” han Sido Actualizado Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    //
                    this.TBCompuesto.Clear();
                    this.TBComp_Descripcion.Clear();
                    this.CBComp_Medida.SelectedItem = 0;
                    this.TBComp_Medida.Clear();

                    //this.Actualizar_DetCompuesto();
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

        private void btnEliminar_Compuesto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar_Compuesto)
                {
                    if (Eliminar == "1")
                    {
                        DialogResult Opcion;
                        string Respuesta = "";
                        int Idcompuesto;

                        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            if (DGDetalles_Ubicacion.SelectedRows.Count > 0)
                            {
                                Idcompuesto = Convert.ToInt32(DGDetalle_Compuesto.CurrentRow.Cells["Idcompuesto"].Value.ToString());
                                //Respuesta = Negocio.fProducto_Inventario.Eliminar_Compuesto(Idproducto, 6);
                            }

                            if (Respuesta.Equals("OK"))
                            {
                                this.MensajeOk("Compuesto Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Respuesta);
                            }
                        }

                        //
                        this.Actualizar_DetCompuesto();
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    int Fila = this.DGDetalle_Compuesto.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Compuesto.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Compuesto.Rows.Remove(row);

                    this.lblTotal_Compuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Compuesto.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por Favor Seleccione el Compuesto que Desea Remover del Registo");
            }
        }

        private void btnAgregar_Exterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.CBProveedor_Exterior.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor Especifique el Proveedor");
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Exterior.Rows)
                        {
                            if (Convert.ToString(Fila[1]) == CBProveedor_Exterior.SelectedValue)
                            {
                                this.MensajeError("El Proveedor que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }
                        if (agregar)
                        {
                            DataRow fila = this.DtDetalle_Exterior.NewRow();
                            fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                            fila["Idproveedor"] = Convert.ToInt32(this.CBProveedor_Exterior.SelectedValue);
                            fila["Aduana"] = this.TBExterior_Aduana.Text;
                            fila["Comisión"] = this.TBExterior_Comision.Text;
                            fila["Documentación"] = this.TBExterior_Documento.Text;
                            fila["Adicional"] = this.TBExterior_Adicional.Text;
                            fila["Exportación"] = this.TBExterior_Exportacion.Text;
                            fila["Importación"] = this.TBExterior_Importacion.Text;
                            fila["Seguridad"] = this.TBExterior_Seguridad.Text;
                            this.DtDetalle_Exterior.Rows.Add(fila);
                        }

                        //
                        this.CBProveedor_Exterior.SelectedIndex = 0;
                        this.TBExterior_Aduana.Clear();
                        this.TBExterior_Comision.Clear();
                        this.TBExterior_Documento.Clear();
                        this.TBExterior_Adicional.Clear();
                        this.TBExterior_Exportacion.Clear();
                        this.TBExterior_Importacion.Clear();
                        this.TBExterior_Seguridad.Clear();
                    }
                }
                else
                {
                    string rptaDatosBasicos = "";

                    // <<<<<<------ Panel Datos Basicos ------>>>>>

                    if (this.CBProveedor_Exterior.SelectedIndex == 0)
                    {
                        this.MensajeError("Por favor Especifique el Proveedor");
                    }

                    else
                    {
                        bool agregar = true;
                        foreach (DataRow Fila in DtDetalle_Exterior.Rows)
                        {
                            if (Convert.ToString(Fila[1]) == CBProveedor_Exterior.SelectedValue)
                            {
                                this.MensajeError("El Proveedor que Desea Agregar ya se Encuentra en la Lista");
                            }
                        }

                        DialogResult result = MessageBox.Show("¿Desea Añadir los Datos Digitados de Exportación/Importación?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            rptaDatosBasicos = fProducto_Inventario.Guardar_Exterior

                                (

                                    //Datos Auxiliares
                                    1,

                                    //Datos Basicos
                                    Convert.ToInt32(this.TBIdproducto.Text), Convert.ToInt32(CBProveedor_Exterior.SelectedValue), Convert.ToDouble(this.TBExterior_Aduana.Text), Convert.ToDouble(this.TBExterior_Comision.Text), Convert.ToDouble(this.TBExterior_Documento.Text), Convert.ToDouble(this.TBExterior_Adicional.Text), Convert.ToDouble(this.TBExterior_Exportacion.Text), Convert.ToDouble(this.TBExterior_Importacion.Text), Convert.ToDouble(this.TBExterior_Seguridad.Text)
                                );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("Los Datos de Exportación/Importación del Producto: " + TBNombre.Text + " con Código: " + this.TBCodigo.Text + " han Sido Agregados Exitosamente");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //
                            this.CBProveedor_Exterior.SelectedIndex = 0;
                            this.TBExterior_Aduana.Clear();
                            this.TBExterior_Comision.Clear();
                            this.TBExterior_Documento.Clear();
                            this.TBExterior_Adicional.Clear();
                            this.TBExterior_Exportacion.Clear();
                            this.TBExterior_Importacion.Clear();
                            this.TBExterior_Seguridad.Clear();

                            //
                            this.Actualizar_DetExterior();
                        }
                        else
                        {
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

        private void btnModificar_Exterior_Click(object sender, EventArgs e)
        {
            try
            {
                string rptaDatosBasicos = "";

                //rptaDatosBasicos = fProducto_Exterior.Editar_Exterior

                //            (
                //                 //Datos Auxiliares
                //                 Convert.ToInt32(this.TBIdproducto.Text),

                //                 //Panel Datos Basicos
                //                 this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text,

                //                //Si es igual a 1 se registraran los datos en la base de datos
                //                2
                //            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("Los Datos de Valores en el Exterior del Producto: “" + this.TBNombre.Text + "” han Sido Actualizado Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    //
                    this.TBCompuesto.Clear();
                    this.TBComp_Descripcion.Clear();
                    this.CBComp_Medida.SelectedItem = 0;
                    this.TBComp_Medida.Clear();

                    //this.Actualizar_DetExterior();
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

        private void btnEliminar_Exterior_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Eliminar_Exterior)
                //{
                //    if (Eliminar == "1")
                //    {
                //        DialogResult Opcion;
                //        string Respuesta = "";
                //        int Idexterior;

                //        Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                //        if (Opcion == DialogResult.OK)
                //        {
                //            if (DGDetalle_Exterior.SelectedRows.Count > 0)
                //            {
                //                Idexterior = Convert.ToInt32(DGDetalle_Exterior.CurrentRow.Cells["Idexterior"].Value.ToString());
                //                Respuesta = Negocio.fProducto_Exterior.Eliminar_Exterior(Idexterior, 6);
                //            }

                //            if (Respuesta.Equals("OK"))
                //            {
                //                this.MensajeOk("Compuesto Eliminado Correctamente");
                //            }
                //            else
                //            {
                //                this.MensajeError(Respuesta);
                //            }
                //        }

                //        //
                //        this.Actualizar_DetExterior();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //}
                //else
                //{
                //    int Fila = this.DGDetalle_Exterior.CurrentCell.RowIndex;
                //    DataRow row = this.DtDetalle_Exterior.Rows[Fila];

                //    //Se remueve la fila
                //    this.DtDetalle_Exterior.Rows.Remove(row);
                //}
            }
            catch (Exception ex)
            {
                MensajeError("Por Favor Seleccione el Registro que Desea Remover del Registo");
            }
        }

        private void btnExaminar_Stock_Click(object sender, EventArgs e)
        {
            try
            {
                frmFiltro_Bodega frmFiltro_Bodega = new frmFiltro_Bodega();
                frmFiltro_Bodega.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CHFabricado_CheckedChanged(object sender, EventArgs e)
        {
            if (Digitar)
            {
                if (CHFabricado.Checked)
                {
                    this.TCPrincipal.TabPages.Add(TPFabricacion);
                }
                else
                {
                    this.TCPrincipal.TabPages.Remove(TPFabricacion);

                    this.TBFabri_MaterialPrincipal.Text = "0";
                    this.TBFabri_MaterialSecundario.Text = "0";
                    this.TBFabri_MaterialTerciario.Text = "0";
                    this.TBFabri_OtroMaterial.Text = "0";
                    this.TBFabri_ManoDeObra.Text = "0";
                    this.TBFabri_Materiales.Text = "0";
                    this.TBFabri_Envio.Text = "0";
                    this.TBFabri_Almacenamiento.Text = "0";
                    this.TBFabri_Maquinaria.Text = "0";
                    this.TBFabri_HerramientaManual.Text = "0";
                    this.TBFabri_TotalFabricacion.Text = "0";
                    this.TBFabri_DiasFormal.Text = "0";
                    this.TBFabri_DiasProrroga.Text = "0";
                }
            }

            else if (!Digitar)
            {
                if (CHFabricado.Checked)
                {
                    this.TCPrincipal.TabPages.Add(TPFabricacion);
                }
                else
                {
                    this.TCPrincipal.TabPages.Remove(TPFabricacion);
                }
            }
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
                if (!Digitar)
                {
                    // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                    DataGridViewRow fila = DGDetalles_Ubicacion.Rows[e.RowIndex];

                    //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                    this.TBIdbodega_Ubicacion.Text = Convert.ToString(fila.Cells["Idbodega"].Value);
                    this.TBBodega_Ubicacion.Text = Convert.ToString(fila.Cells["Bodega"].Value);
                    this.TBUbicacion.Text = Convert.ToString(fila.Cells["Ubicación"].Value);
                    this.TBEstante.Text = Convert.ToString(fila.Cells["Estante"].Value);
                    this.TBNivel.Text = Convert.ToString(fila.Cells["Nivel"].Value);
                }
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
                                 //Datos Auxiliares y Llave Primaria
                                 2, Convert.ToInt32(this.TBIdproducto.Text),

                                 //Panel Datos Basicos
                                 Convert.ToInt32(TBIdbodega_Ubicacion.Text), Convert.ToInt32(this.TBIdbodega_Ubicacion.Text), this.TBBodega_Ubicacion.Text, this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text
                            );

                if (rptaDatosBasicos.Equals("OK"))
                {
                    if (this.Digitar)
                    {
                        this.MensajeOk("La Ubicación del Producto: “" + this.TBNombre.Text + "” a Sido Actualizada Exitosamente");
                    }

                    //SE LIMPIAN LOS CAMPOS DE TEXTO
                    //this.CBBodega.SelectedIndex = 0;
                    this.TBIdbodega_Ubicacion.Clear();
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
                //string rptaDatosBasicos = "";

                //rptaDatosBasicos = fProducto_Inventario.Editar_CodigoDeBarra

                //            (
                //                 //Datos Auxiliares
                //                 Convert.ToInt32(this.TBIdproducto.Text),

                //                 //Panel Datos Basicos
                //                 this.TBUbicacion.Text, this.TBEstante.Text, this.TBNivel.Text,

                //                //Si es igual a 1 se registraran los datos en la base de datos
                //                2
                //            );

                //if (rptaDatosBasicos.Equals("OK"))
                //{
                //    if (this.Digitar)
                //    {
                //        this.MensajeOk("La Ubicacion del Producto: “" + this.TBNombre.Text + "” a Sido Actualizada Exitosamente");
                //    }

                //    //SE LIMPIAN LOS CAMPOS DE TEXTO
                //    //this.CBBodega.SelectedIndex = 0;
                //    this.TBUbicacion.Clear();
                //    this.TBEstante.Clear();
                //    this.TBNivel.Clear();

                //    this.Actualizar_DetCodigoDeBarra();
                //}

                //else
                //{
                //    this.MensajeError(rptaDatosBasicos);
                //}
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
                if (!Digitar)
                {
                    // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                    DataGridViewRow fila = DGDetalles_Ubicacion.Rows[e.RowIndex];

                    //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                    //this.CBBodega.SelectedValue = Convert.ToString(fila.Cells["Idbodega"].Value);
                    this.TBBodega_Ubicacion.Text = Convert.ToString(fila.Cells["Bodega"].Value);
                    this.TBUbicacion.Text = Convert.ToString(fila.Cells["Ubicación"].Value);
                    this.TBEstante.Text = Convert.ToString(fila.Cells["Estante"].Value);
                    this.TBNivel.Text = Convert.ToString(fila.Cells["Nivel"].Value);
                }
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
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void CBManejaComision_CheckedChanged(object sender, EventArgs e)
        {
            if (Digitar)
            {
                if (CHFabricado.Checked)
                {
                    this.TBComision.Enabled = true;
                    this.TBComision.BackColor = Color.FromArgb(3, 155, 229);
                    this.TBComision.Text = "0";
                }
                else
                {
                    this.TBComision.Enabled = false;
                    this.TBComision.BackColor = Color.FromArgb(245, 245, 245);
                    this.TBComision.Text = "0";
                }
            }

            else if (!Digitar)
            {
                if (TBComision.Text !="0")
                {
                    this.CHFabricado.Checked = true;
                }
                else
                {
                    this.CHFabricado.Checked = false;
                }
            }
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
            if (TBValor_Mayorista.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor_Mayorista.Text = "0";
                this.TBValor_Mayorista.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValor_Mayorista.BackColor = Color.FromArgb(3, 155, 229);

                //
                int Impuesto_SQL = 0;
                double Operacion, Mayorista, Divisor, Multiplicador, Impuesto_Mayorista;
                double Base_Mayorista;


                foreach (DataGridViewRow row in DGDetalle_Impuesto.Rows)
                {
                    if (row.Cells[3].Value != null)
                        Impuesto_SQL += (Int32)row.Cells[3].Value;

                    //Se procede a calcular el IVA o Impuestos

                    this.TBValor_PorMayorista.Text = Impuesto_SQL.ToString();

                    this.TBDivisor_Impuesto.Text = "1." + TBValor_PorMayorista.Text;
                    this.TBmultiplicador_Impuesto.Text = "0." + TBValor_PorMayorista.Text;

                    //Se procede a calcular el IVA o Impuestos
                    Mayorista = Convert.ToDouble(TBValor_Mayorista.Text);
                    Divisor = Convert.ToDouble(TBDivisor_Impuesto.Text);
                    Multiplicador = Convert.ToDouble(TBmultiplicador_Impuesto.Text);

                    //Primero se Calcula el Valor Base
                    Base_Mayorista = Mayorista / Divisor;
                    this.TBValorBase_InicialMayorista.Text = Base_Mayorista.ToString("N0");

                    //Despues se Calcula el Valor del Impuesto
                    Impuesto_Mayorista = Base_Mayorista * Multiplicador;
                    this.TBValor_ImpMayorista.Text = Impuesto_Mayorista.ToString("N0");
                }
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

        private void TBComision_Enter(object sender, EventArgs e)
        {
            //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
            this.TBComision.BackColor = Color.Azure;
        }

        private void TBComision_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBComision.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVentaMayorista_KeyUp(object sender, KeyEventArgs e)
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
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente
                    this.TBNombre.Select();
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
                            this.TBComision.Select();
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
                            this.TBComision.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCodigodeBarra_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    bool agregar = true;
                    foreach (DataRow Fila in DtDetalle_CodigoDeBarra.Rows)
                    {
                        if (Convert.ToString(Fila["Código de Barra"]) == TBCodigodeBarra.Text)
                        {
                            this.MensajeError("El Código de Barra Que Desea Agregar ya se Encuentra en la Lista");
                        }
                    }
                    if (agregar)
                    {
                        DataRow fila = this.DtDetalle_CodigoDeBarra.NewRow();
                        fila["Idproducto"] = Convert.ToInt32(this.TBIdproducto_AutoSQL.Text);
                        fila["Código de Barra"] = this.TBCodigodeBarra.Text;
                        this.DtDetalle_CodigoDeBarra.Rows.Add(fila);

                        //
                        this.lblTotal_Codigodebarra.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_CodigoDeBarra.Rows.Count);
                    }

                    //
                    this.TBCodigodeBarra.Clear();
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
            tb.Text = string.Format("{0:N}", numero);
        }

        private void TBValor_Venta02_Leave(object sender, EventArgs e)
        {
            if (TBValor_Venta02.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor_Venta02.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor_Venta02.Text = "0";
                this.TBValor_Venta02.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValor_Venta02.BackColor = Color.FromArgb(3, 155, 229);

                //
                int Impuesto_SQL = 0;
                double Valor01, Valor02, Valor03, Porcentaje01, Porcentaje02, Porcentaje03, Operacion, Mayorista, Divisor, Multiplicador, Impuesto01, Impuesto02, Impuesto03, Impuesto_Mayorista;
                double Base01, Base02, Base03, Base_Mayorista;


                foreach (DataGridViewRow row in DGDetalle_Impuesto.Rows)
                {
                    if (row.Cells[3].Value != null)
                        Impuesto_SQL += (Int32)row.Cells[3].Value;

                    //Se procede a calcular el IVA o Impuestos

                    this.TBValor_PorVenta02.Text = Impuesto_SQL.ToString();

                    this.TBDivisor_Impuesto.Text = "1." + TBValor_PorVenta02.Text;
                    this.TBmultiplicador_Impuesto.Text = "0." + TBValor_PorVenta02.Text;

                    //Se procede a calcular el IVA o Impuestos
                    Valor02 = Convert.ToDouble(TBValor_Venta02.Text);
                    Divisor = Convert.ToDouble(TBDivisor_Impuesto.Text);
                    Multiplicador = Convert.ToDouble(TBmultiplicador_Impuesto.Text);

                    //Primero se Calcula el Valor Base
                    Base02 = Valor02 / Divisor;
                    this.TBValorBase_Inicial02.Text = Base02.ToString("N");

                    //Despues se Calcula el Valor del Impuesto
                    Impuesto01 = Base02 * Multiplicador;
                    this.TBValor_ImpVenta02.Text = Impuesto01.ToString("N");

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
                tb.Text = string.Format("{0:N}", numero);
            }
        }

        private void TBCodigodeBarra_Enter(object sender, EventArgs e)
        {
            this.TBCodigodeBarra.BackColor = Color.Azure;
        }

        private void TBCodigodeBarra_Leave(object sender, EventArgs e)
        {
            this.TBCodigodeBarra.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void frmProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void TBValor_Venta01_Enter(object sender, EventArgs e)
        {
            //********************* PROCESO PARA FORMATEAR EL TEXBOXT Y PASAR DE FORMATO MONEDA A FORMATO NATURAL O LIMPIO (SIN NINGUN FORMATO)

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
            tb.Text = string.Format("{0:#}", numero);

            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor_Venta01.Text == "0")
            {
                this.TBValor_Venta01.BackColor = Color.Azure;
                this.TBValor_Venta01.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor_Venta01.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor_Venta01.BackColor = Color.Azure;
                this.TBValor_Venta01.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBValor_Venta01_Leave(object sender, EventArgs e)
        {
            if (TBValor_Venta01.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor_Venta01.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor_Venta01.Text = "0";
                this.TBValor_Venta01.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValor_Venta01.BackColor = Color.FromArgb(3, 155, 229);

                //
                int Impuesto_SQL = 0;
                double Valor01, Porcentaje01, Operacion, Mayorista, Divisor, Multiplicador, Impuesto01, Impuesto_Mayorista;
                double Base01, Base_Mayorista;


                foreach (DataGridViewRow row in DGDetalle_Impuesto.Rows)
                {
                    if (row.Cells[3].Value != null)
                        Impuesto_SQL += (Int32)row.Cells[3].Value;

                    //Se procede a calcular el IVA o Impuestos

                    this.TBValor_PorVenta01.Text = Impuesto_SQL.ToString();

                    this.TBDivisor_Impuesto.Text = "1." + TBValor_PorVenta01.Text;
                    this.TBmultiplicador_Impuesto.Text = "0." + TBValor_PorVenta01.Text;

                    //Se procede a calcular el IVA o Impuestos
                    Valor01 = Convert.ToDouble(TBValor_Venta01.Text);
                    Divisor = Convert.ToDouble(TBDivisor_Impuesto.Text);
                    Multiplicador = Convert.ToDouble(TBmultiplicador_Impuesto.Text);

                    //Primero se Calcula el Valor Base
                    Base01 = Valor01 / Divisor;
                    this.TBValorBase_Inicial01.Text = Base01.ToString("N");

                    //Despues se Calcula el Valor del Impuesto
                    Impuesto01 = Base01 * Multiplicador;
                    this.TBValor_ImpVenta01.Text = Impuesto01.ToString("N");
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
                tb.Text = string.Format("{0:N}", numero);
            }
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
                        this.DGResultados.DataSource = fProducto_Inventario.Buscar(1, this.TBBuscar.Text);
                        this.DGResultados.Columns[0].Visible = false;

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
                if (!Digitar)
                {
                    DataTable Datos = Negocio.fProducto_Inventario.Buscar(2, this.TBIdproducto.Text);
                    //Evaluamos si  existen los Datos
                    if (Datos.Rows.Count != 0)
                    {
                        //Captura de Valores en la Base de Datos


                        //Panel Datos Basicos - Llaves Primarias
                        //Idproducto = Datos.Rows[0][0].ToString();
                        Idmarca = Datos.Rows[0][0].ToString();
                        Idgrupo = Datos.Rows[0][1].ToString();
                        Idtipo = Datos.Rows[0][2].ToString();
                        Idempaque = Datos.Rows[0][3].ToString();

                        //Panel Datos Basicos
                        Codigo = Datos.Rows[0][4].ToString();
                        Area = Datos.Rows[0][5].ToString();
                        Nombre = Datos.Rows[0][6].ToString();
                        Referencia = Datos.Rows[0][8].ToString();
                        Descripcion = Datos.Rows[0][9].ToString();
                        Descripcion02 = Datos.Rows[0][10].ToString();
                        Descripcion03 = Datos.Rows[0][11].ToString();
                        Presentacion = Datos.Rows[0][12].ToString();
                        Comision = Datos.Rows[0][13].ToString();
                        CompraMinima = Datos.Rows[0][14].ToString();
                        CompraMaxima = Datos.Rows[0][15].ToString();
                        VentaMinima = Datos.Rows[0][16].ToString();
                        VentaMaxima = Datos.Rows[0][17].ToString();

                        AplicaVentas = Datos.Rows[0][18].ToString();
                        AplicaOfertable = Datos.Rows[0][19].ToString();
                        AplicaCompras = Datos.Rows[0][20].ToString();
                        Fabricado = Datos.Rows[0][21].ToString();
                        Importado = Datos.Rows[0][22].ToString();
                        Exportado = Datos.Rows[0][23].ToString();
                        ManejaImpuesto = Datos.Rows[0][24].ToString();
                        ManejaVencimiento = Datos.Rows[0][25].ToString();
                        UtilizaEmpaque = Datos.Rows[0][26].ToString();
                        ManejaComision = Datos.Rows[0][27].ToString();
                        ManejaRetencion = Datos.Rows[0][28].ToString();
                        UtilizaBalanza = Datos.Rows[0][29].ToString();

                        //Panel - Fabricacion
                        MaterialPrincipal = Datos.Rows[0][30].ToString();
                        MaterialSecundario = Datos.Rows[0][31].ToString();
                        MaterialTerciario = Datos.Rows[0][32].ToString();
                        OtroMaterial = Datos.Rows[0][33].ToString();
                        ManoDeObra = Datos.Rows[0][34].ToString();
                        Materiales = Datos.Rows[0][35].ToString();
                        Envio = Datos.Rows[0][36].ToString();
                        Almacenamiento = Datos.Rows[0][37].ToString();
                        Maquinaria = Datos.Rows[0][38].ToString();
                        Herramientas = Datos.Rows[0][39].ToString();
                        Fabricacion = Datos.Rows[0][40].ToString();
                        DiasFormal = Datos.Rows[0][41].ToString();
                        DiasProrroga = Datos.Rows[0][42].ToString();

                        //Panel - Valores y Precio
                        ValorCom_Promedio = Datos.Rows[0][43].ToString();
                        ValorCom_Final = Datos.Rows[0][44].ToString();
                        Valor_Base01 = Datos.Rows[0][45].ToString();
                        Valor_Base02 = Datos.Rows[0][46].ToString();
                        Valor_Base03 = Datos.Rows[0][47].ToString();
                        Valor_BaseMayorista = Datos.Rows[0][48].ToString();
                        Porc_Venta01 = Datos.Rows[0][49].ToString();
                        Porc_Venta02 = Datos.Rows[0][50].ToString();
                        Porc_Valor03 = Datos.Rows[0][51].ToString();
                        Porc_Mayorista = Datos.Rows[0][52].ToString();
                        Impuesto_Valor01 = Datos.Rows[0][53].ToString();
                        Impuesto_Valor02 = Datos.Rows[0][54].ToString();
                        Impuesto_Valor03 = Datos.Rows[0][55].ToString();
                        Impuesto_Mayorista = Datos.Rows[0][56].ToString();
                        Valor_Final01 = Datos.Rows[0][57].ToString();
                        Valor_Final02 = Datos.Rows[0][58].ToString();
                        Valor_Final03 = Datos.Rows[0][59].ToString();
                        ValorFinalMayorista = Datos.Rows[0][60].ToString();
                        Unidad = Datos.Rows[0][61].ToString();
                        Unidad_Detallada = Datos.Rows[0][62].ToString();

                        //
                        Imagen = Datos.Rows[0][63].ToString();

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
                        this.CBArea.Text = Area;
                        this.TBNombre.Text = Nombre;
                        this.TBReferencia.Text = Referencia;
                        this.TBDescripcion01.Text = Descripcion;
                        this.TBDescripcion02.Text = Descripcion02;
                        this.TBDescripcion03.Text = Descripcion03;
                        this.TBPresentacion.Text = Presentacion;
                        this.TBComision.Text = Comision;
                        this.TBCompraminima.Text = CompraMinima;
                        this.TBCompraMaxima.Text = CompraMaxima;
                        this.TBVentaMinima.Text = VentaMinima;
                        this.TBVentaMaxima.Text = VentaMaxima;

                        //this.tb.Text=AplicaVentas;
                        //this.tb.Text=AplicaOfertable;
                        //this.tb.Text=AplicaCompras;
                        //this.tb.Text = Fabricado;
                        //this.tb.Text = Importado;
                        //this.tb.Text = Exportado;
                        //this.tb.Text = ManejaImpuesto;
                        //this.tb.Text = ManejaVencimiento;
                        //this.tb.Text = UtilizaEmpaque;
                        //this.tb.Text = ManejaComision;
                        //this.tb.Text = ManejaRetencion;
                        //this.tb.Text = UtilizaBalanza;

                        //Panel - Fabricacion
                        this.TBFabri_MaterialPrincipal.Text = MaterialPrincipal;
                        this.TBFabri_MaterialSecundario.Text = MaterialSecundario;
                        this.TBFabri_MaterialTerciario.Text = MaterialTerciario;
                        this.TBFabri_OtroMaterial.Text = OtroMaterial;
                        this.TBFabri_ManoDeObra.Text = ManoDeObra;
                        this.TBFabri_Materiales.Text = Materiales;
                        this.TBFabri_Envio.Text = Envio;
                        this.TBFabri_Almacenamiento.Text = Almacenamiento;
                        this.TBFabri_Maquinaria.Text = Maquinaria;
                        this.TBFabri_HerramientaManual.Text = Herramientas;
                        this.TBFabri_TotalFabricacion.Text = Fabricacion;
                        this.TBFabri_DiasFormal.Text = DiasFormal;
                        this.TBFabri_DiasProrroga.Text = DiasProrroga;

                        //Panel - Valores y Precio
                        this.TBValor_CompraPromedio.Text = ValorCom_Promedio;
                        this.TBValor_CompraFinal.Text = ValorCom_Final;
                        this.TBValorBase_Inicial01.Text = Valor_Base01;
                        this.TBValorBase_Inicial02.Text = Valor_Base02;
                        this.TBValorBase_Inicial03.Text = Valor_Base03;
                        this.TBValorBase_InicialMayorista.Text = Valor_BaseMayorista;
                        this.TBValor_PorVenta01.Text = Porc_Venta01;
                        this.TBValor_PorVenta02.Text = Porc_Venta02;
                        this.TBValor_PorVenta03.Text = Porc_Valor03;
                        this.TBValor_PorMayorista.Text = Porc_Mayorista;
                        this.TBValor_ImpVenta01.Text = Impuesto_Valor01;
                        this.TBValor_ImpVenta02.Text = Impuesto_Valor02;
                        this.TBValor_ImpVenta03.Text = Impuesto_Valor03;
                        this.TBValor_ImpMayorista.Text = Impuesto_Mayorista;
                        this.TBValor_Venta01.Text = Valor_Final01;
                        this.TBValor_Venta02.Text = Valor_Final02;
                        this.TBValor_Venta03.Text = Valor_Final03;
                        this.TBValor_Mayorista.Text = ValorFinalMayorista;
                        this.CBUnidad.Text = Unidad;
                        this.TBValor_Unidad.Text = Unidad_Detallada;

                        
                        //Se proceden a Validar los Chexboxt si estan activos o no

                        if (AplicaVentas == "0")
                        {
                            this.CHVentas.Checked = false;
                        }
                        else
                        {
                            this.CHVentas.Checked = true;
                        }

                        if (AplicaOfertable == "0")
                        {
                            this.CHOfertable.Checked = false;
                        }
                        else
                        {
                            this.CHOfertable.Checked = true;
                        }

                        if (AplicaCompras == "0")
                        {
                            this.CHCompras.Checked = false;
                        }
                        else
                        {
                            this.CHCompras.Checked = true;
                        }

                        if (Fabricado == "0")
                        {
                            this.CHFabricado.Checked = false;
                        }
                        else
                        {
                            this.CHFabricado.Checked = true;
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

                        if (ManejaImpuesto == "0")
                        {
                            this.CHImpuesto.Checked = false;
                        }
                        else
                        {
                            this.CHImpuesto.Checked = true;
                        }

                        if (ManejaVencimiento == "0")
                        {
                            this.CHVencimiento.Checked = false;
                        }
                        else
                        {
                            this.CHVencimiento.Checked = true;
                        }

                        if (UtilizaEmpaque == "0")
                        {
                            this.CHEmpaque.Checked = false;
                        }
                        else
                        {
                            this.CHEmpaque.Checked = true;
                        }

                        if (ManejaComision == "0")
                        {
                            this.CHManejaComision.Checked = false;
                        }
                        else
                        {
                            this.CHManejaComision.Checked = true;
                        }

                        if (ManejaRetencion == "0")
                        {
                            this.CHRetencion.Checked = false;
                        }
                        else
                        {
                            this.CHRetencion.Checked = true;
                        }

                        if (UtilizaBalanza == "0")
                        {
                            this.CHBalanza.Checked = false;
                        }
                        else
                        {
                            this.CHBalanza.Checked = true;
                        }

                        //************************************************************************************************************************
                        //Se realizan las consultas para llenar los DataGriview donde se mostrarian los MultiPlex Registros.

                        this.DGDetalle_Compuesto.DataSource = fProducto_Inventario.Buscar_Compuesto(1, Convert.ToInt32(this.TBIdproducto.Text));
                        this.lblTotal_Compuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Compuesto.Rows.Count);
                        //this.DGDetalle_Compuesto.Columns["Idcompuesto"].Visible = false;

                        this.DGDetalles_Ubicacion.DataSource = fProducto_Inventario.Buscar_Ubicacion(1, Convert.ToInt32(this.TBIdproducto.Text));
                        this.lblTotal_Ubicacion.Text = "Datos Registrados: " + Convert.ToString(DGDetalles_Ubicacion.Rows.Count);
                        //this.DGDetalles_Ubicacion.Columns["Idubicacion"].Visible = false;

                        this.DGDetalle_Igualdad.DataSource = fProducto_Inventario.Buscar_Igualdad(1, Convert.ToInt32(this.TBIdproducto.Text));
                        this.lblTotal_Igualdad.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Igualdad.Rows.Count);
                        this.DGDetalle_Igualdad.Columns["Idigualdad"].Visible = false;

                        this.DGDetalle_Impuesto.DataSource = fProducto_Inventario.Buscar_Impuesto(1, Convert.ToInt32(this.TBIdproducto.Text));
                        this.lblTotal_Impuesto.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Impuesto.Rows.Count);

                        this.DGDetalle_Proveedor.DataSource = fProducto_Inventario.Buscar_Proveedor(1, Convert.ToInt32(this.TBIdproducto.Text));
                        this.lblTotal_Proveedor.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_Proveedor.Rows.Count);


                        this.DGDetalle_CodigoDeBarra.DataSource = fProducto_Inventario.Buscar_CodigoDeBarra(1, Convert.ToInt32(this.TBIdproducto.Text));
                        this.lblTotal_Codigodebarra.Text = "Datos Registrados: " + Convert.ToString(DGDetalle_CodigoDeBarra.Rows.Count);
                        this.DGDetalle_CodigoDeBarra.Columns["IdCodBarra"].Visible = false;
                    }
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
                    //
                    this.Digitar = false;
                    this.Botones();
                    this.TCPrincipal.SelectedIndex = 0;

                    this.TBIdproducto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                    this.TBNombre.Select();

                    //
                    //this.Digitar = false;
                    this.Eliminar_Igualdad = true;
                    this.Eliminar_Impuesto = true;
                    this.Eliminar_Ubicacion = true;
                    this.Eliminar_Proveedor = true;
                    this.Eliminar_CodigoDeBarra = true;
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
