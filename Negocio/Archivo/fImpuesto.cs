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
    public class fImpuesto
    {
        public static DataTable Lista()
        {
            Conexion_Impuesto Datos = new Conexion_Impuesto();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Impuesto Datos = new Conexion_Impuesto();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string impuesto, string valor, string descripcion, string montodecompra, string montodeventa, string montodeservicio, int compra, int venta, int servicio, int impuestogravado, int impuestoretencion
            )
        {
            Conexion_Impuesto Datos = new Conexion_Impuesto();
            Entidad_Impuesto Obj = new Entidad_Impuesto();

            Obj.Auto = auto;

            Obj.Impuesto = impuesto;
            Obj.Valor = valor;
            Obj.Descripcion = descripcion;
            Obj.MontoDeCompra = montodecompra;
            Obj.MontoDeVenta = montodeventa;
            Obj.MontoDeServicio = montodeservicio;
            Obj.Compra = compra;
            Obj.Venta = venta;
            Obj.Servicio = servicio;
            Obj.ImpuestoGravado = impuestogravado;
            Obj.ImpuestoRetencion = impuestoretencion;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idimpuesto,

                //Datos Basicos
                string impuesto, string valor, string descripcion, string montodecompra, string montodeventa, string montodeservicio, int compra, int venta, int servicio, int impuestogravado, int impuestoretencion
            )
        {
            Conexion_Impuesto Datos = new Conexion_Impuesto();
            Entidad_Impuesto Obj = new Entidad_Impuesto();

            Obj.Auto = auto;

            Obj.Idimpuesto = idimpuesto;
            Obj.Impuesto = impuesto;
            Obj.Valor = valor;
            Obj.Descripcion = descripcion;
            Obj.MontoDeCompra = montodecompra;
            Obj.MontoDeVenta = montodeventa;
            Obj.MontoDeServicio = montodeservicio;
            Obj.Compra = compra;
            Obj.Venta = venta;
            Obj.Servicio = servicio;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Impuesto Datos = new Conexion_Impuesto();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
