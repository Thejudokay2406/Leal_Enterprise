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
    public class fGrupoDeCliente
    {
        public static DataTable Lista()
        {
            Conexion_GrupoDeCliente Datos = new Conexion_GrupoDeCliente();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_GrupoDeCliente Datos = new Conexion_GrupoDeCliente();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                string grupo, string descripcion, string observacion
            )
        {
            Conexion_GrupoDeCliente Datos = new Conexion_GrupoDeCliente();
            Entidad_GrupoDeCliente Obj = new Entidad_GrupoDeCliente();

            //Datos Basicos
            Obj.Grupo = grupo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            
            //Datos Auxiliares
            Obj.Auto = auto;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idgrupo,

                string grupo, string descripcion, string observacion
            )
        {
            Conexion_GrupoDeCliente Datos = new Conexion_GrupoDeCliente();
            Entidad_GrupoDeCliente Obj = new Entidad_GrupoDeCliente();

            //Datos Basicos
            Obj.Idgrupo = idgrupo;
            Obj.Grupo = grupo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;

            //Datos Auxiliares
            Obj.Auto = auto;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_GrupoDeCliente Datos = new Conexion_GrupoDeCliente();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
