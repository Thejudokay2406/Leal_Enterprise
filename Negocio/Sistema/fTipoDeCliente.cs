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
    public class fTipoDeCliente
    {
        public static DataTable Lista(int auto)
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            return Datos.Lista(auto);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string tipo, string descripcion, string observacion
            )
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            Entidad_TipoDeCliente Obj = new Entidad_TipoDeCliente();

            //
            Obj.Tipo = tipo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idtipodecliente,

                //Datos Basicos
                string tipo, string descripcion, string observacion
            )
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            Entidad_TipoDeCliente Obj = new Entidad_TipoDeCliente();

            //
            Obj.Idtipodecliente = idtipodecliente;
            Obj.Tipo = tipo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
