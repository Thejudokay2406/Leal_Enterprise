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
    public class fIngreso_Bodega
    {
        public static DataTable Lista()
        {
            Conexion_IngresosDeBodega Datos = new Conexion_IngresosDeBodega();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_IngresosDeBodega Datos = new Conexion_IngresosDeBodega();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int idingreso, int idempleado, int idproveedor,
                int idbodega, int idcomprobante, string nº_comprobante,
                string lote, DataTable detalles
            )
        {
            Conexion_IngresosDeBodega Datos = new Conexion_IngresosDeBodega();
            Entidad_Ingreso Obj = new Entidad_Ingreso();

            Obj.Idingreso = idingreso;
            Obj.Idempleado = idempleado;
            Obj.Idproveedor = idproveedor;
            Obj.Idbodega = idbodega;
            Obj.Idcomprobante = idcomprobante;
            Obj.Nº_Comprobante = nº_comprobante;
            Obj.Lote = lote;
            Obj.Detalles = detalles;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_IngresosDeBodega Datos = new Conexion_IngresosDeBodega();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
