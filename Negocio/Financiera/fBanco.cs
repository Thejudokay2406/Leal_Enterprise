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
    public class fBanco
    {
        public static DataTable Lista()
        {
            Conexion_Banco Datos = new Conexion_Banco();
            return Datos.Lista();
        }

        public static DataTable Lista_Contacto(int auto, int idbanco)
        {
            Conexion_Banco Datos = new Conexion_Banco();
            return Datos.Lista_Contacto(auto, idbanco);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Banco Datos = new Conexion_Banco();
            return Datos.Buscar(Filtro, auto);
        }

        public static DataTable AutoComplementar_SQL(int auto)
        {
            Conexion_Banco Datos = new Conexion_Banco();
            return Datos.AutoComplementar_SQL(auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string Nombre, Int64 Identificacion, string Pais, string Ciudad, string Area, string Direccion01, string Direccion02, Int64 Telefono01, Int64 Extension01, Int64 Telefono02, Int64 Extension02, Int64 Movil01, Int64 Movil02, string Pagina,

                //Panel Contacto
                DataTable detalle_contacto,

                //Datos Auxiliares
                int contacto_autosql,

                //SE VALIDA SI SE REALIZA O NO LA VALIDACION
                int tran_contacto

            )
        {
            Conexion_Banco Datos = new Conexion_Banco();
            Entidad_Banco Obj = new Entidad_Banco();

            Obj.Nombre = Nombre;
            Obj.Identificacion = Identificacion;
            Obj.Pais = Pais;
            Obj.Ciudad = Ciudad;
            Obj.Area = Area;
            Obj.Direccion01 = Direccion01;
            Obj.Direccion02 = Direccion02;
            Obj.Telefono01 = Telefono01;
            Obj.Extension01 = Extension01;
            Obj.Telefono02 = Telefono02;
            Obj.Extension02 = Extension02;
            Obj.Movil01 = Movil01;
            Obj.Movil02 = Movil02;
            Obj.Pagina = Pagina;

            //Panel Contacto
            Obj.Detalle_Contacto = detalle_contacto;

            //Datos Auxiliares
            Obj.Contacto_AutoSQL = contacto_autosql;

            //SE VALIDA SI SE REALIZA O NO LA VALIDACION
            Obj.Tran_Contacto = tran_contacto;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Guardar_Contacto
           (
               //Datos Auxiliares y Llaves Primaria
               int auto, int idbanco,

               //Datos Basicos
               string asesor, string cargo, string ciudad, Int64 telefono, Int64 extension, Int64 movil, string area,  string observacion
            )
        {
            Conexion_Banco Datos = new Conexion_Banco();
            Entidad_Banco Obj = new Entidad_Banco();

            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Idbanco = idbanco;

            Obj.Cont_Asesor = asesor;
            Obj.Cont_Cargo = cargo;
            Obj.Cont_Ciudad = ciudad;
            Obj.Cont_Telefono = telefono;
            Obj.Cont_Extension = extension;
            Obj.Cont_Movil = movil;
            Obj.Cont_Area = area;
            Obj.Cont_Observacion1 = observacion;

            return Datos.Guardar_Contacto(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idbanco,

                //Datos Basicos
                string Nombre, Int64 Identificacion, string Pais, string Ciudad, string Area, string Direccion01, string Direccion02, Int64 Telefono01, Int64 Extension01, Int64 Telefono02, Int64 Extension02, Int64 Movil01, Int64 Movil02, string Pagina,

                //Panel Contacto
                DataTable detalle_contacto,

                //Datos Auxiliares
                int contacto_autosql,

                //SE VALIDA SI SE REALIZA O NO LA VALIDACION
                int tran_contacto
            )
        {
            Conexion_Banco Datos = new Conexion_Banco();
            Entidad_Banco Obj = new Entidad_Banco();

            Obj.Idbanco = idbanco;
            Obj.Nombre = Nombre;
            Obj.Identificacion = Identificacion;
            Obj.Pais = Pais;
            Obj.Ciudad = Ciudad;
            Obj.Area = Area;
            Obj.Direccion01 = Direccion01;
            Obj.Direccion02 = Direccion02;
            Obj.Telefono01 = Telefono01;
            Obj.Extension01 = Extension01;
            Obj.Telefono02 = Telefono02;
            Obj.Extension02 = Extension02;
            Obj.Movil01 = Movil01;
            Obj.Movil02 = Movil02;
            Obj.Pagina = Pagina;

            //Panel Contacto
            Obj.Detalle_Contacto = detalle_contacto;

            //Datos Auxiliares
            Obj.Contacto_AutoSQL = contacto_autosql;

            //SE VALIDA SI SE REALIZA O NO LA VALIDACION
            Obj.Tran_Contacto = tran_contacto;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Editar_Contacto
           (
               //Datos Auxiliares y Llaves Primaria
               int auto, int idbanco,

               //Datos Basicos
               string asesor, string cargo, string ciudad, Int64 telefono, Int64 extension, Int64 movil, string area, string observacion
            )
        {
            Conexion_Banco Datos = new Conexion_Banco();
            Entidad_Banco Obj = new Entidad_Banco();

            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Idbanco = idbanco;

            Obj.Cont_Asesor = asesor;
            Obj.Cont_Cargo = cargo;
            Obj.Cont_Ciudad = ciudad;
            Obj.Cont_Telefono = telefono;
            Obj.Cont_Extension = extension;
            Obj.Cont_Movil = movil;
            Obj.Cont_Area = area;
            Obj.Cont_Observacion1 = observacion;

            return Datos.Editar_Contacto(Obj);
        }

        //METODO ELIMINAR

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Banco Datos = new Conexion_Banco();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }

        public static string Eliminar_Contacto(int Idcontacto, int auto)
        {
            Conexion_Banco Datos = new Conexion_Banco();
            return Datos.Eliminar_Contacto(Idcontacto, auto);
        }
    }
}
