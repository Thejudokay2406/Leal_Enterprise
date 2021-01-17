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
    public class fGrupoDeProducto
    {
        public static DataTable Lista(int auto)
        {
            Conexion_GrupoDeProducto Datos = new Conexion_GrupoDeProducto();
            return Datos.Lista(auto);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_GrupoDeProducto Datos = new Conexion_GrupoDeProducto();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string grupo, string descripcion, string observacion
            )
        {
            Conexion_GrupoDeProducto Datos = new Conexion_GrupoDeProducto();
            Entidad_GrupoDeProducto Obj = new Entidad_GrupoDeProducto();

            Obj.Grupo = grupo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idgrupo,

                //Datos Basicos
                string grupo, string descripcion, string observacion
            )
        {
            Conexion_GrupoDeProducto Datos = new Conexion_GrupoDeProducto();
            Entidad_GrupoDeProducto Obj = new Entidad_GrupoDeProducto();

            Obj.Idgrupo = idgrupo;
            Obj.Grupo = grupo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_GrupoDeProducto Datos = new Conexion_GrupoDeProducto();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
