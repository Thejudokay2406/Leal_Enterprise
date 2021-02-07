using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Productos
    {
        //Llave primaria
        private int _Idproducto;
        private int _Idexterior;
        private int _Idcompuesto;
        private int _Idigualdad;
        private int _Idubicacion;
        private int _;

        //Llaves Auxiliares Datos Basicos
        private int _Idmarca;
        private int _Idgrupo;
        private int _Idtipo;
        private int _Idempaque;
        

        //Llaves Auxiliares de los Detalles
        private int _Ubicacion_SQL;
        private int _Proveedor_SQL;
        private int _Lote_SQL;
        private int _Codigodebarra_SQL;
        private int _Igualdad_SQL;
        private int _Compuesto_SQL;
        private int _Exterior_SQL;
        private int _Impuesto_SQL;

        //Datos Auxiliares para Editar los Detalles
        private int _AutoDet_Ubicacion;
        private int _AutoDet_Proveedor;
        private int _AutoDet_Lote;
        private int _AutoDet_Codigodebarra;
        private int _AutoDet_Igualdad;
        private int _AutoDet_Compuesto;
        private int _AutoDet_Exterior;
        private int _AutoDet_Impuesto;

        //Datos Basicos
        private string _Codigo;
        private string _Producto;
        private string _Referencia;
        private string _Descripcion;
        private string _Presentacion;
        private Int64 _Comision;

        private int _ManejaVencimiento;
        private int _ManejaImpuesto;
        private int _Importado;
        private int _Exportado;
        private int _Ofertable;
        private int _ManejaComision;
        private int _ManejaEmpaque;
        private int _ManejaBalanza;
        private int _ManejaRetencion;

        //Panel - Codigo de Barra
        private int _Idcodigodebarra;
        private string _Codigodebarra;

        //Valores
        private double _Compra_Promedio;
        private double _Compra_Final;
        private double _Venta01;
        private double _Venta02;
        private double _Venta03;
        private double _Mayorista;
        private double _Venta01_Porcentaje;
        private double _Venta02_Porcentaje;
        private double _Venta03_Porcentaje;
        private double _Mayorista_Porcentaje;
        private double _Venta01_BaseInicial;
        private double _Venta02_BaseInicial;
        private double _Venta03_BaseInicial;
        private double _Mayorista_BaseInicial;
        private double _Venta01_Impuesto;
        private double _Venta02_Impuesto;
        private double _Venta03_Impuesto;
        private double _Mayorista_Impuesto;

        private string _Unidad;
        private string _Unidad_Detalle;
        private double _Unidad01;
        private double _Unidad02;
        private double _Unidad03;
        private double _Unidad01_Porcentaje;
        private double _Unidad02_Porcentaje;
        private double _Unidad03_Porcentaje;
        private double _Unidad01_BaseInicial;
        private double _Unidad02_BaseInicial;
        private double _Unidad03_BaseInicial;
        private double _Unidad01_Impuesto;
        private double _Unidad02_Impuesto;
        private double _Unidad03_Impuesto;

        //Panel - Fabricacion
        private double _Material_Principal;
        private double _Material_Secundario;
        private double _Material_Terciario;
        private double _Material_OtroMaterial;
        private double _ManoDeObra;
        private double _Materiales;
        private double _Envio;
        private double _Almacenamiento;
        private double _Maquinaria;
        private double _Herramientas;
        private double _Herramientas_Manuales;
        private double _CostoFabricacion;

        //Panel - Exterior
        private double _Ext_Aduana;
        private double _Ext_Comision;
        private double _Ext_Documento;
        private double _Ext_Adicional;
        private double _Ext_Exportacion;
        private double _Ext_Importacion;
        private double _Ext_Seguridad;
        private double _Ext_Aduana_Moneda;
        private double _Ext_Comision_Moneda;
        private double _Ext_Documento_Moneda;
        private double _Ext_Adicional_Moneda;
        private double _Ext_Exportacion_Moneda;
        private double _Ext_Importacion_Moneda;
        private double _Ext_Seguridad_Moneda;

        //Panel Compuesto
        private string _Compuesto;
        private string _Compuesto_Descripcion;
        private string _Compuesto_Medida;
        private string _Compuesto_MedodaDescripcion;

        //Detalles de Productos
        private DataTable _Detalle_Lote;
        private DataTable _Detalle_Impuesto;
        private DataTable _Detalle_Igualdad;
        private DataTable _Detalle_Proveedor;
        private DataTable _Detalle_Ubicacion;
        private DataTable _Detalle_CodigoDeBarra;
        private DataTable _Detalle_Exterior;
        private DataTable _Detalle_Compuesto;

        //Panel Ubicacion
        private int _Idbodega;
        private string _Ubicacion;
        private string _Estante;
        private string _Nivel;

        //Panel Impuesto
        private int _Idimpuesto;
        private string _Impuesto;
        private string _Impuesto_Descripcion;
        private string _Impuesto_Valor;

        //Panel Igualdad
        private string _Igualdad_Codigo;
        private string _Igualdad_Producto;
        private string _Igualdad_Marca;

        //Panel Lotes
        private int _Idlote;
        private string _Lote;
        private string _Lote_Compra;
        private string _Lote_Venta;
        private string _Lote_Cantidad;
        private DateTime _Lote_Fecha;

        //Panel Proveedor
        private int _Idproveedor;
        private string _Proveedor;
        private string _Proveedor_Documento;

        //Panel Codigo de Barra
        private string _CodigoDeBarra;
        private string _CodigoDeBarra_Codigo;

        //Panel de Imagenes
        private byte[] _Imagen;

        //Datos para Ejecutar las Transacciones en SQL
        private int _Ubicacion_AutoSQL;
        private int _Igualdad_AutoSQL;
        private int _Impuesto_AutoSQL;
        private int _Proveedor_AutoSQL;
        private int _CodBarra_AutoSQL;
        private int _Lote_AutoSQL;
        private int _Exterior_AutoSQL;
        private int _Compuesto_AutoSQL;

        //
        private int _Tran_Ubicacion;
        private int _Tran_Igualdad;
        private int _Tran_Impuesto;
        private int _Tran_Proveedor;
        private int _Tran_CodBarra;
        private int _Tran_Lote;
        private int _Tran_Compuesto;
        private int _Tran_Exterior;

        //Datos Para Filtrar los Multiples registro del Producto Como Ubicacion, Lotes ETC
        private int _Auto_Ubicacion;
        private int _Auto_Igualdad;
        private int _Auto_Impuesto;
        private int _Auto_Proveedor;
        private int _Auto_CodBarra;
        private int _Auto_Lote;
        private int _Auto_Compuesto;
        private int _Auto_Exterior;

        private int _Det_Ubicacion;
        private int _Det_Igualdad;
        private int _Det_Impuesto;
        private int _Det_Proveedor;
        private int _Det_CodBarra;
        private int _Det_Lote;
        private int _Det_Compuesto;
        private int _Det_Exterior;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private int _Producto_AutoSQL;
        private string _Filtro;

        public int Idproducto { get => _Idproducto; set => _Idproducto = value; }
        public int Idmarca { get => _Idmarca; set => _Idmarca = value; }
        public int Idgrupo { get => _Idgrupo; set => _Idgrupo = value; }
        public int Idtipo { get => _Idtipo; set => _Idtipo = value; }
        public int Idempaque { get => _Idempaque; set => _Idempaque = value; }
        public int Ubicacion_SQL { get => _Ubicacion_SQL; set => _Ubicacion_SQL = value; }
        public int Proveedor_SQL { get => _Proveedor_SQL; set => _Proveedor_SQL = value; }
        public int Lote_SQL { get => _Lote_SQL; set => _Lote_SQL = value; }
        public int Codigodebarra_SQL { get => _Codigodebarra_SQL; set => _Codigodebarra_SQL = value; }
        public int Igualdad_SQL { get => _Igualdad_SQL; set => _Igualdad_SQL = value; }
        public int Compuesto_SQL { get => _Compuesto_SQL; set => _Compuesto_SQL = value; }
        public int Exterior_SQL { get => _Exterior_SQL; set => _Exterior_SQL = value; }
        public int Impuesto_SQL { get => _Impuesto_SQL; set => _Impuesto_SQL = value; }
        public int AutoDet_Ubicacion { get => _AutoDet_Ubicacion; set => _AutoDet_Ubicacion = value; }
        public int AutoDet_Proveedor { get => _AutoDet_Proveedor; set => _AutoDet_Proveedor = value; }
        public int AutoDet_Lote { get => _AutoDet_Lote; set => _AutoDet_Lote = value; }
        public int AutoDet_Codigodebarra { get => _AutoDet_Codigodebarra; set => _AutoDet_Codigodebarra = value; }
        public int AutoDet_Igualdad { get => _AutoDet_Igualdad; set => _AutoDet_Igualdad = value; }
        public int AutoDet_Compuesto { get => _AutoDet_Compuesto; set => _AutoDet_Compuesto = value; }
        public int AutoDet_Exterior { get => _AutoDet_Exterior; set => _AutoDet_Exterior = value; }
        public int AutoDet_Impuesto { get => _AutoDet_Impuesto; set => _AutoDet_Impuesto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public string Referencia { get => _Referencia; set => _Referencia = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Presentacion { get => _Presentacion; set => _Presentacion = value; }
        public long Comision { get => _Comision; set => _Comision = value; }
        public int ManejaVencimiento { get => _ManejaVencimiento; set => _ManejaVencimiento = value; }
        public int ManejaImpuesto { get => _ManejaImpuesto; set => _ManejaImpuesto = value; }
        public int Importado { get => _Importado; set => _Importado = value; }
        public int Exportado { get => _Exportado; set => _Exportado = value; }
        public int Ofertable { get => _Ofertable; set => _Ofertable = value; }
        public int ManejaComision { get => _ManejaComision; set => _ManejaComision = value; }
        public int ManejaEmpaque { get => _ManejaEmpaque; set => _ManejaEmpaque = value; }
        public int ManejaBalanza { get => _ManejaBalanza; set => _ManejaBalanza = value; }
        public int ManejaRetencion { get => _ManejaRetencion; set => _ManejaRetencion = value; }
        public int Idcodigodebarra { get => _Idcodigodebarra; set => _Idcodigodebarra = value; }
        public string Codigodebarra { get => _Codigodebarra; set => _Codigodebarra = value; }
        public string CodigoDeBarra { get => _CodigoDeBarra; set => _CodigoDeBarra = value; }
        public double Compra_Promedio { get => _Compra_Promedio; set => _Compra_Promedio = value; }
        public double Compra_Final { get => _Compra_Final; set => _Compra_Final = value; }
        public double Venta01 { get => _Venta01; set => _Venta01 = value; }
        public double Venta02 { get => _Venta02; set => _Venta02 = value; }
        public double Venta03 { get => _Venta03; set => _Venta03 = value; }
        public double Mayorista { get => _Mayorista; set => _Mayorista = value; }
        public double Venta01_Porcentaje { get => _Venta01_Porcentaje; set => _Venta01_Porcentaje = value; }
        public double Venta02_Porcentaje { get => _Venta02_Porcentaje; set => _Venta02_Porcentaje = value; }
        public double Venta03_Porcentaje { get => _Venta03_Porcentaje; set => _Venta03_Porcentaje = value; }
        public double Mayorista_Porcentaje { get => _Mayorista_Porcentaje; set => _Mayorista_Porcentaje = value; }
        public double Venta01_BaseInicial { get => _Venta01_BaseInicial; set => _Venta01_BaseInicial = value; }
        public double Venta02_BaseInicial { get => _Venta02_BaseInicial; set => _Venta02_BaseInicial = value; }
        public double Venta03_BaseInicial { get => _Venta03_BaseInicial; set => _Venta03_BaseInicial = value; }
        public double Mayorista_BaseInicial { get => _Mayorista_BaseInicial; set => _Mayorista_BaseInicial = value; }
        public double Venta01_Impuesto { get => _Venta01_Impuesto; set => _Venta01_Impuesto = value; }
        public double Venta02_Impuesto { get => _Venta02_Impuesto; set => _Venta02_Impuesto = value; }
        public double Venta03_Impuesto { get => _Venta03_Impuesto; set => _Venta03_Impuesto = value; }
        public double Mayorista_Impuesto { get => _Mayorista_Impuesto; set => _Mayorista_Impuesto = value; }
        public string Unidad { get => _Unidad; set => _Unidad = value; }
        public string Unidad_Detalle { get => _Unidad_Detalle; set => _Unidad_Detalle = value; }
        public double Unidad01 { get => _Unidad01; set => _Unidad01 = value; }
        public double Unidad02 { get => _Unidad02; set => _Unidad02 = value; }
        public double Unidad03 { get => _Unidad03; set => _Unidad03 = value; }
        public double Unidad01_Porcentaje { get => _Unidad01_Porcentaje; set => _Unidad01_Porcentaje = value; }
        public double Unidad02_Porcentaje { get => _Unidad02_Porcentaje; set => _Unidad02_Porcentaje = value; }
        public double Unidad03_Porcentaje { get => _Unidad03_Porcentaje; set => _Unidad03_Porcentaje = value; }
        public double Unidad01_BaseInicial { get => _Unidad01_BaseInicial; set => _Unidad01_BaseInicial = value; }
        public double Unidad02_BaseInicial { get => _Unidad02_BaseInicial; set => _Unidad02_BaseInicial = value; }
        public double Unidad03_BaseInicial { get => _Unidad03_BaseInicial; set => _Unidad03_BaseInicial = value; }
        public double Unidad01_Impuesto { get => _Unidad01_Impuesto; set => _Unidad01_Impuesto = value; }
        public double Unidad02_Impuesto { get => _Unidad02_Impuesto; set => _Unidad02_Impuesto = value; }
        public double Unidad03_Impuesto { get => _Unidad03_Impuesto; set => _Unidad03_Impuesto = value; }
        public double Material_Principal { get => _Material_Principal; set => _Material_Principal = value; }
        public double Material_Secundario { get => _Material_Secundario; set => _Material_Secundario = value; }
        public double Material_Terciario { get => _Material_Terciario; set => _Material_Terciario = value; }
        public double Material_OtroMaterial { get => _Material_OtroMaterial; set => _Material_OtroMaterial = value; }
        public double ManoDeObra { get => _ManoDeObra; set => _ManoDeObra = value; }
        public double Materiales { get => _Materiales; set => _Materiales = value; }
        public double Envio { get => _Envio; set => _Envio = value; }
        public double Almacenamiento { get => _Almacenamiento; set => _Almacenamiento = value; }
        public double Maquinaria { get => _Maquinaria; set => _Maquinaria = value; }
        public double Herramientas { get => _Herramientas; set => _Herramientas = value; }
        public double Herramientas_Manuales { get => _Herramientas_Manuales; set => _Herramientas_Manuales = value; }
        public double CostoFabricacion { get => _CostoFabricacion; set => _CostoFabricacion = value; }
        public double Ext_Aduana { get => _Ext_Aduana; set => _Ext_Aduana = value; }
        public double Ext_Comision { get => _Ext_Comision; set => _Ext_Comision = value; }
        public double Ext_Documento { get => _Ext_Documento; set => _Ext_Documento = value; }
        public double Ext_Adicional { get => _Ext_Adicional; set => _Ext_Adicional = value; }
        public double Ext_Exportacion { get => _Ext_Exportacion; set => _Ext_Exportacion = value; }
        public double Ext_Importacion { get => _Ext_Importacion; set => _Ext_Importacion = value; }
        public double Ext_Seguridad { get => _Ext_Seguridad; set => _Ext_Seguridad = value; }
        public double Ext_Aduana_Moneda { get => _Ext_Aduana_Moneda; set => _Ext_Aduana_Moneda = value; }
        public double Ext_Comision_Moneda { get => _Ext_Comision_Moneda; set => _Ext_Comision_Moneda = value; }
        public double Ext_Documento_Moneda { get => _Ext_Documento_Moneda; set => _Ext_Documento_Moneda = value; }
        public double Ext_Adicional_Moneda { get => _Ext_Adicional_Moneda; set => _Ext_Adicional_Moneda = value; }
        public double Ext_Exportacion_Moneda { get => _Ext_Exportacion_Moneda; set => _Ext_Exportacion_Moneda = value; }
        public double Ext_Importacion_Moneda { get => _Ext_Importacion_Moneda; set => _Ext_Importacion_Moneda = value; }
        public double Ext_Seguridad_Moneda { get => _Ext_Seguridad_Moneda; set => _Ext_Seguridad_Moneda = value; }
        public string Compuesto { get => _Compuesto; set => _Compuesto = value; }
        public string Compuesto_Descripcion { get => _Compuesto_Descripcion; set => _Compuesto_Descripcion = value; }
        public string Compuesto_Medida { get => _Compuesto_Medida; set => _Compuesto_Medida = value; }
        public string Compuesto_MedodaDescripcion { get => _Compuesto_MedodaDescripcion; set => _Compuesto_MedodaDescripcion = value; }
        public DataTable Detalle_Lote { get => _Detalle_Lote; set => _Detalle_Lote = value; }
        public DataTable Detalle_Impuesto { get => _Detalle_Impuesto; set => _Detalle_Impuesto = value; }
        public DataTable Detalle_Igualdad { get => _Detalle_Igualdad; set => _Detalle_Igualdad = value; }
        public DataTable Detalle_Proveedor { get => _Detalle_Proveedor; set => _Detalle_Proveedor = value; }
        public DataTable Detalle_Ubicacion { get => _Detalle_Ubicacion; set => _Detalle_Ubicacion = value; }
        public DataTable Detalle_CodigoDeBarra { get => _Detalle_CodigoDeBarra; set => _Detalle_CodigoDeBarra = value; }
        public DataTable Detalle_Exterior { get => _Detalle_Exterior; set => _Detalle_Exterior = value; }
        public DataTable Detalle_Compuesto { get => _Detalle_Compuesto; set => _Detalle_Compuesto = value; }
        public int Idbodega { get => _Idbodega; set => _Idbodega = value; }
        public string Ubicacion { get => _Ubicacion; set => _Ubicacion = value; }
        public string Estante { get => _Estante; set => _Estante = value; }
        public string Nivel { get => _Nivel; set => _Nivel = value; }
        public int Idimpuesto { get => _Idimpuesto; set => _Idimpuesto = value; }
        public string Impuesto { get => _Impuesto; set => _Impuesto = value; }
        public string Impuesto_Descripcion { get => _Impuesto_Descripcion; set => _Impuesto_Descripcion = value; }
        public string Impuesto_Valor { get => _Impuesto_Valor; set => _Impuesto_Valor = value; }
        public string Igualdad_Codigo { get => _Igualdad_Codigo; set => _Igualdad_Codigo = value; }
        public string Igualdad_Producto { get => _Igualdad_Producto; set => _Igualdad_Producto = value; }
        public string Igualdad_Marca { get => _Igualdad_Marca; set => _Igualdad_Marca = value; }
        public int Idlote { get => _Idlote; set => _Idlote = value; }
        public string Lote { get => _Lote; set => _Lote = value; }
        public string Lote_Compra { get => _Lote_Compra; set => _Lote_Compra = value; }
        public string Lote_Venta { get => _Lote_Venta; set => _Lote_Venta = value; }
        public string Lote_Cantidad { get => _Lote_Cantidad; set => _Lote_Cantidad = value; }
        public DateTime Lote_Fecha { get => _Lote_Fecha; set => _Lote_Fecha = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public string Proveedor_Documento { get => _Proveedor_Documento; set => _Proveedor_Documento = value; }
        public string CodigoDeBarra_Codigo { get => _CodigoDeBarra_Codigo; set => _CodigoDeBarra_Codigo = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Ubicacion_AutoSQL { get => _Ubicacion_AutoSQL; set => _Ubicacion_AutoSQL = value; }
        public int Igualdad_AutoSQL { get => _Igualdad_AutoSQL; set => _Igualdad_AutoSQL = value; }
        public int Impuesto_AutoSQL { get => _Impuesto_AutoSQL; set => _Impuesto_AutoSQL = value; }
        public int Proveedor_AutoSQL { get => _Proveedor_AutoSQL; set => _Proveedor_AutoSQL = value; }
        public int CodBarra_AutoSQL { get => _CodBarra_AutoSQL; set => _CodBarra_AutoSQL = value; }
        public int Lote_AutoSQL { get => _Lote_AutoSQL; set => _Lote_AutoSQL = value; }
        public int Exterior_AutoSQL { get => _Exterior_AutoSQL; set => _Exterior_AutoSQL = value; }
        public int Compuesto_AutoSQL { get => _Compuesto_AutoSQL; set => _Compuesto_AutoSQL = value; }
        public int Tran_Ubicacion { get => _Tran_Ubicacion; set => _Tran_Ubicacion = value; }
        public int Tran_Igualdad { get => _Tran_Igualdad; set => _Tran_Igualdad = value; }
        public int Tran_Impuesto { get => _Tran_Impuesto; set => _Tran_Impuesto = value; }
        public int Tran_Proveedor { get => _Tran_Proveedor; set => _Tran_Proveedor = value; }
        public int Tran_CodBarra { get => _Tran_CodBarra; set => _Tran_CodBarra = value; }
        public int Tran_Lote { get => _Tran_Lote; set => _Tran_Lote = value; }
        public int Tran_Compuesto { get => _Tran_Compuesto; set => _Tran_Compuesto = value; }
        public int Tran_Exterior { get => _Tran_Exterior; set => _Tran_Exterior = value; }
        public int Auto_Ubicacion { get => _Auto_Ubicacion; set => _Auto_Ubicacion = value; }
        public int Auto_Igualdad { get => _Auto_Igualdad; set => _Auto_Igualdad = value; }
        public int Auto_Impuesto { get => _Auto_Impuesto; set => _Auto_Impuesto = value; }
        public int Auto_Proveedor { get => _Auto_Proveedor; set => _Auto_Proveedor = value; }
        public int Auto_CodBarra { get => _Auto_CodBarra; set => _Auto_CodBarra = value; }
        public int Auto_Lote { get => _Auto_Lote; set => _Auto_Lote = value; }
        public int Auto_Compuesto { get => _Auto_Compuesto; set => _Auto_Compuesto = value; }
        public int Auto_Exterior { get => _Auto_Exterior; set => _Auto_Exterior = value; }
        public int Det_Ubicacion { get => _Det_Ubicacion; set => _Det_Ubicacion = value; }
        public int Det_Igualdad { get => _Det_Igualdad; set => _Det_Igualdad = value; }
        public int Det_Impuesto { get => _Det_Impuesto; set => _Det_Impuesto = value; }
        public int Det_Proveedor { get => _Det_Proveedor; set => _Det_Proveedor = value; }
        public int Det_CodBarra { get => _Det_CodBarra; set => _Det_CodBarra = value; }
        public int Det_Lote { get => _Det_Lote; set => _Det_Lote = value; }
        public int Det_Compuesto { get => _Det_Compuesto; set => _Det_Compuesto = value; }
        public int Det_Exterior { get => _Det_Exterior; set => _Det_Exterior = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public int Producto_AutoSQL { get => _Producto_AutoSQL; set => _Producto_AutoSQL = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Idexterior { get => _Idexterior; set => _Idexterior = value; }
        public int Idcompuesto { get => _Idcompuesto; set => _Idcompuesto = value; }
        public int Idigualdad { get => _Idigualdad; set => _Idigualdad = value; }
        public int Idubicacion { get => _Idubicacion; set => _Idubicacion = value; }
    }
}
