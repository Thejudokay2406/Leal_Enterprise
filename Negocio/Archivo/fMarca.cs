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
    public class fMarca
    {
        public static DataTable Lista()
        {
            Conexion_Marca Datos = new Conexion_Marca();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Marca Datos = new Conexion_Marca();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string marca, string descripcion, string referencia, string observacion,
                
                //
                int estado
            )
        {
            Conexion_Marca Datos = new Conexion_Marca();
            Entidad_Marca Obj = new Entidad_Marca();

            //Datos Basicos
            Obj.Marca = marca;
            Obj.Descripcion = descripcion;
            Obj.Referencia = referencia;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idmarca,

                //Datos Basicos
                string marca, string descripcion, string referencia, string observacion,

                //
                int estado
            )
        {
            Conexion_Marca Datos = new Conexion_Marca();
            Entidad_Marca Obj = new Entidad_Marca();

            //Llaves Auxiliares
            Obj.Idmarca = idmarca;

            //Datos Basicos
            Obj.Marca = marca;
            Obj.Descripcion = descripcion;
            Obj.Referencia = referencia;
            Obj.Observacion = observacion;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Marca Datos = new Conexion_Marca();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
