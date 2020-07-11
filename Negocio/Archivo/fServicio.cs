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
    public class fServicio
    {
        public static DataTable Lista()
        {
            Conexion_Servicio Datos = new Conexion_Servicio();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Servicio Datos = new Conexion_Servicio();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idimpuesto,

                //Datos Basicos
                string codigo, string servicio, string descripcion, string clase, string retencion, string costo,
                string valor01, string valor02, string valor03, string comision, string venta,
                int estado
            )
        {
            Conexion_Servicio Datos = new Conexion_Servicio();
            Entidad_Servicio Obj = new Entidad_Servicio();

            Obj.IDImpuesto = idimpuesto;
            Obj.Codigo = codigo;
            Obj.Servicio = servicio;
            Obj.Descripcion = descripcion;
            Obj.Clase = clase;
            Obj.Retencion = retencion;
            Obj.Costo = costo;
            Obj.Valor01 = valor01;
            Obj.Valor02 = valor02;
            Obj.Valor03 = valor03;
            Obj.Comision = comision;
            Obj.Venta = venta;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idimpuesto,

                //Datos Basicos
                string codigo, string servicio, string descripcion, string clase, string retencion, string costo,
                string valor01, string valor02, string valor03, string comision, string venta,
                int estado
            )
        {
            Conexion_Servicio Datos = new Conexion_Servicio();
            Entidad_Servicio Obj = new Entidad_Servicio();

            Obj.IDImpuesto = idimpuesto;
            Obj.Codigo = codigo;
            Obj.Servicio = servicio;
            Obj.Descripcion = descripcion;
            Obj.Clase = clase;
            Obj.Retencion = retencion;
            Obj.Costo = costo;
            Obj.Valor01 = valor01;
            Obj.Valor02 = valor02;
            Obj.Valor03 = valor03;
            Obj.Comision = comision;
            Obj.Venta = venta;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Servicio Datos = new Conexion_Servicio();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
