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
        public static DataTable Lista()
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            return Datos.Lista();
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
                string codigo, string tipo, string descripcion, string observacion,
                int estado
            )
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            Entidad_TipoDeCliente Obj = new Entidad_TipoDeCliente();

            //
            Obj.Codigo = codigo;
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
                int auto, int idtipodecliente,

                //Datos Basicos
                string codigo, string tipo, string descripcion, string observacion,
                int estado
            )
        {
            Conexion_TipoDeCliente Datos = new Conexion_TipoDeCliente();
            Entidad_TipoDeCliente Obj = new Entidad_TipoDeCliente();

            //
            Obj.Idtipodecliente = idtipodecliente;
            Obj.Codigo = codigo;
            Obj.Tipo = tipo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

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
