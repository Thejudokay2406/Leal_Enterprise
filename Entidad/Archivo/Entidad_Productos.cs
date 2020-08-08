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
        private int _Impuesto_SQL;

        //Datos Auxiliares para Editar los Detalles
        private int _AutoDet_Ubicacion;
        private int _AutoDet_Proveedor;
        private int _AutoDet_Lote;
        private int _AutoDet_Codigodebarra;
        private int _AutoDet_Igualdad;
        private int _AutoDet_Impuesto;

        //Datos Basicos
        private string _Codigo;
        private string _Producto;
        private string _Referencia;
        private string _Descripcion;
        private string _Presentacion;
        private string _Unidad;
        private string _Comision;
        private int _Comision_Porcentaje;

        private int _ManejaVencimiento;
        private int _ManejaImpuesto;
        private int _Importado;
        private int _Exportado;
        private int _Ofertable;
        private int _ManejaComision;

        //Valores
        private string _Compra_Promedio;
        private string _Compra_Final;
        private string _Venta_Excento;
        private string _Venta_NoExcento;
        private string _Venta_Mayorista;
        private string _Fabricacion;
        private string _Materiales;
        private string _Exportacion;
        private string _Importacion;
        private string _Seguro;
        private string _Gastos;

        //Cantidades
        private string _Venta_MinimaCliente;
        private string _Venta_MaximaCliente;
        private string _Venta_MinimaMayorista;
        private string _Venta_MaximaMayorista;
        private string _Compra_MinimaCliente;
        private string _Compra_MaximaCliente;
        private string _Compra_MinimaMayorista;
        private string _Compra_MaximaMayorista;

        //Detalles de Productos
        private DataTable _Detalle_Lote;
        private DataTable _Detalle_Impuesto;
        private DataTable _Detalle_Igualdad;
        private DataTable _Detalle_Proveedor;
        private DataTable _Detalle_Ubicacion;
        private DataTable _Detalle_CodigoDeBarra;

        //Panel Ubicacion
        private int _Idbodega;
        private string _Ubicacion;
        private string _Estante;
        private string _Nivel;

        //Panel de Imagenes
        private byte[] _Imagen;

        //Datos para Ejecutar las Transacciones en SQL
        private int _Ubicacion_AutoSQL;
        private int _Igualdad_AutoSQL;
        private int _Impuesto_AutoSQL;
        private int _Proveedor_AutoSQL;
        private int _CodBarra_AutoSQL;
        private int _Lote_AutoSQL;

        //
        private int _Tran_Ubicacion;
        private int _Tran_Igualdad;
        private int _Tran_Impuesto;
        private int _Tran_Proveedor;
        private int _Tran_CodBarra;
        private int _Tran_Lote;

        //Datos Para Filtrar los Multiples registro del Producto Como Ubicacion, Lotes ETC
        private int _Auto_Ubicacion;
        private int _Auto_Igualdad;
        private int _Auto_Impuesto;
        private int _Auto_Proveedor;
        private int _Auto_CodBarra;
        private int _Auto_Lote;

        private int _Det_Ubicacion;
        private int _Det_Igualdad;
        private int _Det_Impuesto;
        private int _Det_Proveedor;
        private int _Det_CodBarra;
        private int _Det_Lote;

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
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public string Referencia { get => _Referencia; set => _Referencia = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Presentacion { get => _Presentacion; set => _Presentacion = value; }
        public string Unidad { get => _Unidad; set => _Unidad = value; }
        public string Comision { get => _Comision; set => _Comision = value; }
        public int Comision_Porcentaje { get => _Comision_Porcentaje; set => _Comision_Porcentaje = value; }
        public int ManejaVencimiento { get => _ManejaVencimiento; set => _ManejaVencimiento = value; }
        public int ManejaImpuesto { get => _ManejaImpuesto; set => _ManejaImpuesto = value; }
        public int Importado { get => _Importado; set => _Importado = value; }
        public int Exportado { get => _Exportado; set => _Exportado = value; }
        public int Ofertable { get => _Ofertable; set => _Ofertable = value; }
        public int ManejaComision { get => _ManejaComision; set => _ManejaComision = value; }
        public string Compra_Promedio { get => _Compra_Promedio; set => _Compra_Promedio = value; }
        public string Compra_Final { get => _Compra_Final; set => _Compra_Final = value; }
        public string Venta_Excento { get => _Venta_Excento; set => _Venta_Excento = value; }
        public string Venta_NoExcento { get => _Venta_NoExcento; set => _Venta_NoExcento = value; }
        public string Venta_Mayorista { get => _Venta_Mayorista; set => _Venta_Mayorista = value; }
        public string Fabricacion { get => _Fabricacion; set => _Fabricacion = value; }
        public string Materiales { get => _Materiales; set => _Materiales = value; }
        public string Exportacion { get => _Exportacion; set => _Exportacion = value; }
        public string Importacion { get => _Importacion; set => _Importacion = value; }
        public string Seguro { get => _Seguro; set => _Seguro = value; }
        public string Gastos { get => _Gastos; set => _Gastos = value; }
        public string Venta_MinimaCliente { get => _Venta_MinimaCliente; set => _Venta_MinimaCliente = value; }
        public string Venta_MaximaCliente { get => _Venta_MaximaCliente; set => _Venta_MaximaCliente = value; }
        public string Venta_MinimaMayorista { get => _Venta_MinimaMayorista; set => _Venta_MinimaMayorista = value; }
        public string Venta_MaximaMayorista { get => _Venta_MaximaMayorista; set => _Venta_MaximaMayorista = value; }
        public string Compra_MinimaCliente { get => _Compra_MinimaCliente; set => _Compra_MinimaCliente = value; }
        public string Compra_MaximaCliente { get => _Compra_MaximaCliente; set => _Compra_MaximaCliente = value; }
        public string Compra_MinimaMayorista { get => _Compra_MinimaMayorista; set => _Compra_MinimaMayorista = value; }
        public string Compra_MaximaMayorista { get => _Compra_MaximaMayorista; set => _Compra_MaximaMayorista = value; }
        public DataTable Detalle_Lote { get => _Detalle_Lote; set => _Detalle_Lote = value; }
        public DataTable Detalle_Impuesto { get => _Detalle_Impuesto; set => _Detalle_Impuesto = value; }
        public DataTable Detalle_Igualdad { get => _Detalle_Igualdad; set => _Detalle_Igualdad = value; }
        public DataTable Detalle_Proveedor { get => _Detalle_Proveedor; set => _Detalle_Proveedor = value; }
        public DataTable Detalle_Ubicacion { get => _Detalle_Ubicacion; set => _Detalle_Ubicacion = value; }
        public DataTable Detalle_CodigoDeBarra { get => _Detalle_CodigoDeBarra; set => _Detalle_CodigoDeBarra = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Producto_AutoSQL { get => _Producto_AutoSQL; set => _Producto_AutoSQL = value; }
        public int Ubicacion_AutoSQL { get => _Ubicacion_AutoSQL; set => _Ubicacion_AutoSQL = value; }
        public int Igualdad_AutoSQL { get => _Igualdad_AutoSQL; set => _Igualdad_AutoSQL = value; }
        public int Impuesto_AutoSQL { get => _Impuesto_AutoSQL; set => _Impuesto_AutoSQL = value; }
        public int Proveedor_AutoSQL { get => _Proveedor_AutoSQL; set => _Proveedor_AutoSQL = value; }
        public int CodBarra_AutoSQL { get => _CodBarra_AutoSQL; set => _CodBarra_AutoSQL = value; }
        public int Lote_AutoSQL { get => _Lote_AutoSQL; set => _Lote_AutoSQL = value; }
        public int Tran_Ubicacion { get => _Tran_Ubicacion; set => _Tran_Ubicacion = value; }
        public int Tran_Igualdad { get => _Tran_Igualdad; set => _Tran_Igualdad = value; }
        public int Tran_Impuesto { get => _Tran_Impuesto; set => _Tran_Impuesto = value; }
        public int Tran_Proveedor { get => _Tran_Proveedor; set => _Tran_Proveedor = value; }
        public int Tran_CodBarra { get => _Tran_CodBarra; set => _Tran_CodBarra = value; }
        public int Tran_Lote { get => _Tran_Lote; set => _Tran_Lote = value; }
        public int Det_Ubicacion { get => _Det_Ubicacion; set => _Det_Ubicacion = value; }
        public int Det_Igualdad { get => _Det_Igualdad; set => _Det_Igualdad = value; }
        public int Det_Impuesto { get => _Det_Impuesto; set => _Det_Impuesto = value; }
        public int Det_Proveedor { get => _Det_Proveedor; set => _Det_Proveedor = value; }
        public int Det_CodBarra { get => _Det_CodBarra; set => _Det_CodBarra = value; }
        public int Det_Lote { get => _Det_Lote; set => _Det_Lote = value; }
        public int Auto_Ubicacion { get => _Auto_Ubicacion; set => _Auto_Ubicacion = value; }
        public int Auto_Igualdad { get => _Auto_Igualdad; set => _Auto_Igualdad = value; }
        public int Auto_Impuesto { get => _Auto_Impuesto; set => _Auto_Impuesto = value; }
        public int Auto_Proveedor { get => _Auto_Proveedor; set => _Auto_Proveedor = value; }
        public int Auto_CodBarra { get => _Auto_CodBarra; set => _Auto_CodBarra = value; }
        public int Auto_Lote { get => _Auto_Lote; set => _Auto_Lote = value; }
        public int Ubicacion_SQL { get => _Ubicacion_SQL; set => _Ubicacion_SQL = value; }
        public int Proveedor_SQL { get => _Proveedor_SQL; set => _Proveedor_SQL = value; }
        public int Lote_SQL { get => _Lote_SQL; set => _Lote_SQL = value; }
        public int Codigodebarra_SQL { get => _Codigodebarra_SQL; set => _Codigodebarra_SQL = value; }
        public int Igualdad_SQL { get => _Igualdad_SQL; set => _Igualdad_SQL = value; }
        public int Impuesto_SQL { get => _Impuesto_SQL; set => _Impuesto_SQL = value; }
        public string Ubicacion { get => _Ubicacion; set => _Ubicacion = value; }
        public string Estante { get => _Estante; set => _Estante = value; }
        public string Nivel { get => _Nivel; set => _Nivel = value; }
        public int AutoDet_Ubicacion { get => _AutoDet_Ubicacion; set => _AutoDet_Ubicacion = value; }
        public int AutoDet_Proveedor { get => _AutoDet_Proveedor; set => _AutoDet_Proveedor = value; }
        public int AutoDet_Lote { get => _AutoDet_Lote; set => _AutoDet_Lote = value; }
        public int AutoDet_Codigodebarra { get => _AutoDet_Codigodebarra; set => _AutoDet_Codigodebarra = value; }
        public int AutoDet_Igualdad { get => _AutoDet_Igualdad; set => _AutoDet_Igualdad = value; }
        public int AutoDet_Impuesto { get => _AutoDet_Impuesto; set => _AutoDet_Impuesto = value; }
        public int Idbodega { get => _Idbodega; set => _Idbodega = value; }
    }
}
