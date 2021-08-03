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
    public class fTipoDePago
    {
        public static DataTable Lista(int auto)
        {
            Conexion_TipoDePagos Datos = new Conexion_TipoDePagos();
            return Datos.Lista(auto);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_TipoDePagos Datos = new Conexion_TipoDePagos();
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
            Conexion_TipoDePagos Datos = new Conexion_TipoDePagos();
            Entidad_TipoDePago Obj = new Entidad_TipoDePago();

            //
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Tipo = tipo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idtipo,

                //Datos Basicos
                string tipo, string descripcion, string observacion
            )
        {
            Conexion_TipoDePagos Datos = new Conexion_TipoDePagos();
            Entidad_TipoDePago Obj = new Entidad_TipoDePago();

            //Llaves Auxiliares
            Obj.Idtipo = idtipo;

            //
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Tipo = tipo;
            Obj.Descripcion = descripcion;
            Obj.Observacion = observacion;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_TipoDePagos Datos = new Conexion_TipoDePagos();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
