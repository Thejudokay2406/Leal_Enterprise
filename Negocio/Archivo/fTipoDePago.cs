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
        public static DataTable Lista()
        {
            Conexion_Pagos Datos = new Conexion_Pagos();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Pagos Datos = new Conexion_Pagos();
            return Datos.Buscar(Filtro, auto);
        }

        //public static string Guardar_DatosBasicos
        //    (
        //        //Datos Auxiliares y Llaves Primaria
        //        int auto,

        //        //Datos Basicos
        //        string marca, string descripcion, string referencia, string observacion,

        //        //
        //        int estado
        //    )
        //{
        //    Conexion_Pagos Datos = new Conexion_Pagos();
        //    Entidad_TipoDePago Obj = new Entidad_TipoDePago();

        //    //Datos Basicos
        //    Obj.Marca = marca;
        //    Obj.Descripcion = descripcion;
        //    Obj.Referencia = referencia;
        //    Obj.Observacion = observacion;
        //    Obj.Estado = estado;

        //    Obj.Auto = auto;
        //    return Datos.Guardar_DatosBasicos(Obj);
        //}

        //public static string Editar_DatosBasicos
        //    (
        //        //Datos Auxiliares y Llaves Primaria
        //        int auto, int idmarca,

        //        //Datos Basicos
        //        string marca, string descripcion, string referencia, string observacion,

        //        //
        //        int estado
        //    )
        //{
        //    Conexion_Pagos Datos = new Conexion_Pagos();
        //    Entidad_TipoDePago Obj = new Entidad_TipoDePago();

        //    //Llaves Auxiliares
        //    Obj.Idmarca = idmarca;

        //    //Datos Basicos
        //    Obj.Marca = marca;
        //    Obj.Descripcion = descripcion;
        //    Obj.Referencia = referencia;
        //    Obj.Observacion = observacion;
        //    Obj.Estado = estado;

        //    Obj.Auto = auto;
        //    return Datos.Editar_DatosBasicos(Obj);
        //}

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Pagos Datos = new Conexion_Pagos();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
