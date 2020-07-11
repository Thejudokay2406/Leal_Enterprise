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
    public class fEmpaque
    {
        public static DataTable Lista()
        {
            Conexion_Empaque Datos = new Conexion_Empaque();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Empaque Datos = new Conexion_Empaque();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string empaque, string descripcion, string observacion, int estado
            )
        {
            Conexion_Empaque Datos = new Conexion_Empaque();
            Entidad_Empaque Obj = new Entidad_Empaque();

            Obj.Empaque = empaque;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idempaque,

                //Datos Basicos
                string empaque, string descripcion, string observacion, int estado
            )
        {
            Conexion_Empaque Datos = new Conexion_Empaque();
            Entidad_Empaque Obj = new Entidad_Empaque();

            Obj.Idempaque = idempaque;
            Obj.Empaque = empaque;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Empaque Datos = new Conexion_Empaque();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
