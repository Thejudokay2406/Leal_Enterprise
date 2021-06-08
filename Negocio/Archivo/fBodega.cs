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
    public class fBodega
    {
        public static DataTable Lista(int auto)
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            return Datos.Lista(auto);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idsucurzal,

                //Datos Basicos
                string Bodega, string Documento, string Descripcion, string Director, string Ciudad, string Telefono01, string Extension01, string Telefono02, string Extension02, string Movil01, string Movil02, string Correo, string Dimensiones, string Direccion01, string Direccion02
            )
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            Entidad_Bodega Obj = new Entidad_Bodega();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Llaves Auxiliares
            Obj.Idsucurzal = idsucurzal;

            //Datos Basicos
            Obj.Bodega = Bodega;
            Obj.Documento = Documento;
            Obj.Descripcion = Descripcion;
            Obj.Director = Director;
            Obj.Ciudad = Ciudad;
            Obj.Telefono01 = Telefono01;
            Obj.Extension01 = Extension01;
            Obj.Telefono02 = Telefono02;
            Obj.Extension02 = Extension02;
            Obj.Movil01 = Movil01;
            Obj.Movil02 = Movil01;
            Obj.Correo = Correo;
            Obj.Medida = Dimensiones;
            Obj.Direccion01 = Direccion01;
            Obj.Direccion02 = Direccion02;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idbodega, int idsucurzal,

                //Datos Basicos
                string Bodega, string Documento, string Descripcion, string Director, string Ciudad, string Telefono01, string Extension01, string Telefono02, string Extension02, string Movil01, string Movil02, string Correo, string Dimensiones, string Direccion01, string Direccion02
            )
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            Entidad_Bodega Obj = new Entidad_Bodega();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Llaves Auxiliares y Llave Primaria
            Obj.Idbodega = idbodega;
            Obj.Idsucurzal = idsucurzal;

            //Datos Basicos
            Obj.Bodega = Bodega;
            Obj.Documento = Documento;
            Obj.Descripcion = Descripcion;
            Obj.Director = Director;
            Obj.Ciudad = Ciudad;
            Obj.Telefono01 = Telefono01;
            Obj.Extension01 = Extension01;
            Obj.Telefono02 = Telefono02;
            Obj.Extension02 = Extension02;
            Obj.Movil01 = Movil01;
            Obj.Movil02 = Movil01;
            Obj.Correo = Correo;
            Obj.Medida = Dimensiones;
            Obj.Direccion01 = Direccion01;
            Obj.Direccion02 = Direccion02;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
