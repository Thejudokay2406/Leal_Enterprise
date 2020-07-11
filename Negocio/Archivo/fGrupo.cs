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
    public class fGrupo
    {
        public static DataTable Lista()
        {
            Conexion_Grupo Datos = new Conexion_Grupo();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Grupo Datos = new Conexion_Grupo();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string grupo, string descripcion, string observacion, int estado
            )
        {
            Conexion_Grupo Datos = new Conexion_Grupo();
            Entidad_Grupo Obj = new Entidad_Grupo();

            Obj.Grupo = grupo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idgrupo,

                //Datos Basicos
                string grupo, string descripcion, string observacion, int estado
            )
        {
            Conexion_Grupo Datos = new Conexion_Grupo();
            Entidad_Grupo Obj = new Entidad_Grupo();

            Obj.Idgrupo = idgrupo;
            Obj.Grupo = grupo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Grupo Datos = new Conexion_Grupo();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
