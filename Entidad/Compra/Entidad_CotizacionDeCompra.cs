using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_CotizacionDeCompra
    {
        //Llaves primarias
        private int _Idcotizacion;

        //Llaves Auxiliares
        private int _Iddetalle;
        private int _Idbodega;
        private int _Idproveedor;
        private int _Idordendecompra;
        private int _Idtipodepago;
        private int _Idempleado;

        //Datos Basicos
        private string _Codigo_CotizacionDeCompra;
        private string _Codigo_Almacen;
        private string _Almacen;
        private string _PrecioFinal;
        private string _Estado;

        //
        private string _SubTotal;
        private string _Descuento;
        private string _Descuento_Aplicado;
        private string _Impuesto;
        private string _Valor;
        private string _Mora;
        private string _Disponible;
        private string _Flete;
        private string _Pago;
        private string _Dias;
        private int _Vence;
        private DateTime _Fecha;


        //Datos Auxiliares
        private int _Auto;
        private DataTable _Cotizacion_Detalles;

        public int Idcotizacion { get => _Idcotizacion; set => _Idcotizacion = value; }
        public int Iddetalle { get => _Iddetalle; set => _Iddetalle = value; }
        public int Idbodega { get => _Idbodega; set => _Idbodega = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public int Idordendecompra { get => _Idordendecompra; set => _Idordendecompra = value; }
        public int Idtipodepago { get => _Idtipodepago; set => _Idtipodepago = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public string Codigo_Almacen { get => _Codigo_Almacen; set => _Codigo_Almacen = value; }
        public string Almacen { get => _Almacen; set => _Almacen = value; }
        public string PrecioFinal { get => _PrecioFinal; set => _PrecioFinal = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public string Descuento { get => _Descuento; set => _Descuento = value; }
        public string Descuento_Aplicado { get => _Descuento_Aplicado; set => _Descuento_Aplicado = value; }
        public string Impuesto { get => _Impuesto; set => _Impuesto = value; }
        public string Valor { get => _Valor; set => _Valor = value; }
        public string Mora { get => _Mora; set => _Mora = value; }
        public string Disponible { get => _Disponible; set => _Disponible = value; }
        public string Flete { get => _Flete; set => _Flete = value; }
        public string Pago { get => _Pago; set => _Pago = value; }
        public string Dias { get => _Dias; set => _Dias = value; }
        public int Vence { get => _Vence; set => _Vence = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public DataTable Cotizacion_Detalles { get => _Cotizacion_Detalles; set => _Cotizacion_Detalles = value; }
        public string Codigo_CotizacionDeCompra { get => _Codigo_CotizacionDeCompra; set => _Codigo_CotizacionDeCompra = value; }
    }
}
