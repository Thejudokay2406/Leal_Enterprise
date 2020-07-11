using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class fCotizacion_Compra
    {
        public static DataTable Auto_ConsultaEnOrden(string Filtro)
        {
            Conexion_CotizacionDeCompra Datos = new Conexion_CotizacionDeCompra();
            return Datos.Auto_ConsultaEnOrden(Filtro);
        }

        public static DataTable Auto_ConsultaDetalle(string Filtro)
        {
            Conexion_CotizacionDeCompra Datos = new Conexion_CotizacionDeCompra();
            return Datos.Auto_ConsultaDetalle(Filtro);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_CotizacionDeCompra Datos = new Conexion_CotizacionDeCompra();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (

                //Datos Auxiliares y Llaves Primaria
                int idbodega, int idproveedor, int idtipodepago, int idempleado,

                //Datos Basicos
                string codigo, string codigo_almacen, string almacen,

                //Totalizacion de Compra
                string subtotal, string descuento, string descuento_aplicado,
                string impuesto, string valor, string mora, string disponible,
                string flete, string pago, string dias, int vence, DateTime fecha,
                
                //Datos Auxiliares
                DataTable Detalles, int auto
            )
        {
            Conexion_CotizacionDeCompra Datos = new Conexion_CotizacionDeCompra();
            Entidad_CotizacionDeCompra Obj = new Entidad_CotizacionDeCompra();

            //Datos Auxiliares y Llaves Primaria
            Obj.Idbodega = idbodega;
            Obj.Idproveedor = idproveedor;

            //Datos Auxiliares y Llaves Primaria
            Obj.Idbodega = idbodega;
            Obj.Idproveedor = idproveedor;
            Obj.Idtipodepago = idtipodepago;
            Obj.Idempleado = idempleado;

            //Datos Basicos
            Obj.Codigo_CotizacionDeCompra = codigo;
            Obj.Codigo_Almacen = codigo_almacen;
            Obj.Almacen = almacen;

            //Totalizacion de Compra
            Obj.SubTotal = subtotal;
            Obj.Descuento = descuento;
            Obj.Descuento_Aplicado = descuento_aplicado;
            Obj.Impuesto = impuesto;
            Obj.Valor = valor;
            Obj.Mora = mora;
            Obj.Disponible = disponible;
            Obj.Flete = flete;
            Obj.Pago = pago;
            Obj.Dias = dias;
            Obj.Vence = vence;
            Obj.Fecha = fecha;
                
            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Cotizacion_Detalles = Detalles;

            return Datos.Guardar_DatosBasicos(Obj);
        }
    }
}
