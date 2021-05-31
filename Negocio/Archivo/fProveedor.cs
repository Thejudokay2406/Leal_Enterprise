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
    public class fProveedor
    {
        public static DataTable AutoComplementar_SQL(int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.AutoComplementar_SQL(auto);
        }

        public static DataTable Lista(int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Lista(auto);
        }

        public static DataTable Lista_Banco(int auto, int idproveedor)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Lista_Banco(auto, idproveedor);
        }

        public static DataTable Lista_Envio(int auto, int idproveedor)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Lista_Envio(auto, idproveedor);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Buscar(Filtro, auto);
        }

        public static DataTable Buscar_Envio(string Filtro, int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Buscar_Envio(Filtro, auto);
        }

        public static DataTable Buscar_Banco(string Filtro, int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Buscar_Banco(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                string tipo, string nombre, string documento, string representante, string pais, string ciudad, string nacionalidad, string telefono, string movil, string correo,
                DateTime fechadeinicio,

                //Panel Envio
                DataTable detalle_envio,

                //Panel Datos Bancarios
                DataTable detalle_banco,

                //Datos Auxiliares
                int envio_autosql, int banco_autosql,

                //SE VALIDA SI SE REALIZA O NO LA VALIDACION
                int tran_envio, int tran_banco
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Basicos
            Obj.Tipo = tipo;
            Obj.Nombre = nombre;
            Obj.Documento = documento;
            Obj.Representante = representante;
            Obj.Telefono = telefono;
            Obj.Movil = movil;
            Obj.Correo = correo;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Nacionalidad = nacionalidad;
            Obj.Fechadeinicio = fechadeinicio;

            //Datos de Envio
            Obj.Detalle_Envio = detalle_envio;
            
            //Datos Financieros
            Obj.Detalle_Banco = detalle_banco;

            //Datos Auxiliares
            Obj.Auto = auto;

            Obj.Tran_Envio = tran_envio;
            Obj.Tran_Banco = tran_banco;

            Obj.Envio_AutoSQL = envio_autosql;
            Obj.Banco_AutoSQL = banco_autosql;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Guardar_Envio
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                string receptor, string pais, string ciudad, string direccion, string telefono, string movil, string observacion
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Basicos
            Obj.Env_Receptor = receptor;
            Obj.Env_Pais = pais;
            Obj.Env_Ciudad = ciudad;
            Obj.Env_Direccion = direccion;
            Obj.Env_Telefono = telefono;
            Obj.Env_Movil = movil;
            Obj.Env_Observacion = observacion;

            //Datos Auxiliares
            Obj.Auto = auto;

            return Datos.Guardar_Envio(Obj);
        }

        public static string Guardar_Banco
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idproveedor,

                int idbanco, string banco, string banco_documento, string cuenta, Int64 numerodecuenta
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Idproveedor = idproveedor;
            Obj.Idbanco = idbanco;
            Obj.Banco = banco;
            Obj.Banco_Documento = banco_documento;
            Obj.Cuenta = cuenta;
            Obj.Numerodecuenta = numerodecuenta;

            

            return Datos.Guardar_Banco(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idproveedor,

                string tipo, string nombre, string documento, string representante, string pais,
                string ciudad, string nacionalidad, string telefono, string movil, string correo,
                DateTime fechadeinicio
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Idproveedor = idproveedor;
            Obj.Tipo = tipo;
            Obj.Nombre = nombre;
            Obj.Documento = documento;
            Obj.Representante = representante;
            Obj.Telefono = telefono;
            Obj.Movil = movil;
            Obj.Correo = correo;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Nacionalidad = nacionalidad;
            Obj.Fechadeinicio = fechadeinicio;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Editar_Envio
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idproveedor,

                string receptor, string pais, string ciudad, string direccion, string telefono, string movil, string observacion
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Basicos
            Obj.Idproveedor = idproveedor;
            Obj.Env_Receptor = receptor;
            Obj.Env_Pais = pais;
            Obj.Env_Ciudad = ciudad;
            Obj.Env_Direccion = direccion;
            Obj.Env_Telefono = telefono;
            Obj.Env_Movil = movil;
            Obj.Env_Observacion = observacion;

            //Datos Auxiliares
            Obj.Auto = auto;

            return Datos.Guardar_Envio(Obj);
        }

        public static string Editar_Banco
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idproveedor,

                int idbanco, string banco, string banco_documento, string cuenta, Int64 numerodecuenta
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Basicos
            Obj.Idproveedor = idproveedor;
            Obj.Idbanco = idbanco;
            Obj.Banco = banco;
            Obj.Banco_Documento = banco_documento;
            Obj.Cuenta = cuenta;
            Obj.Numerodecuenta = numerodecuenta;

            //Datos Auxiliares
            Obj.Auto = auto;

            return Datos.Guardar_Banco(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }

        public static string Eliminar_Banco(int Idbanco, int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Eliminar_Banco(Idbanco, auto);
        }

        public static string Eliminar_Envio(int Idbanco, int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Eliminar_Envio(Idbanco, auto);
        }
    }
}
