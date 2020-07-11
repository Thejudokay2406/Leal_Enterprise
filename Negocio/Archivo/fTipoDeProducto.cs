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
    public class fTipoDeProducto
    {
        public static DataTable Lista()
        {
            Conexion_TipoDeProducto Datos = new Conexion_TipoDeProducto();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_TipoDeProducto Datos = new Conexion_TipoDeProducto();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string tipo, string descripcion, string observacion, int estado
            )
        {
            Conexion_TipoDeProducto Datos = new Conexion_TipoDeProducto();
            Entidad_TipoDeProducto Obj = new Entidad_TipoDeProducto();

            Obj.Tipo = tipo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idtipo,

                //Datos Basicos
                string tipo, string descripcion, string observacion, int estado
            )
        {
            Conexion_TipoDeProducto Datos = new Conexion_TipoDeProducto();
            Entidad_TipoDeProducto Obj = new Entidad_TipoDeProducto();

            Obj.Idtipo =idtipo ;
            Obj.Tipo = tipo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_TipoDeProducto Datos = new Conexion_TipoDeProducto();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
