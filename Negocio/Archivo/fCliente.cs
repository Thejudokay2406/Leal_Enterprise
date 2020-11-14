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
    public class fCliente
    {
        public static DataTable Lista()
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista();
        }

        public static DataTable Lista_Contacto(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Contacto(auto, idcliente);
        }

        public static DataTable Lista_Credito(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Credito(auto, idcliente);
        }

        public static DataTable Lista_Despacho(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Despacho(auto, idcliente);
        }

        public static DataTable Lista_Facturacion(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Facturacion(auto, idcliente);
        }

        public static DataTable Lista_Financiera(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Financiera(auto, idcliente);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar(Filtro, auto);
        }

        public static DataTable AutoComplementar_SQL(int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.AutoComplementar_SQL(auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idtipo, int idgrupo,

                //Datos Basicos
                string codigo, string cliente, string documento, string telefonoprin, string movilprin, string telefonoaux, string movilaux,
                string correo, string pais, string ciudad, string departamento, string paginaweb, string direccion, string observacion,

                //Panel Facturacion
                DataTable detalle_facturacion,

                //Panel Credito
                DataTable detalle_credito,

                //Panel Despacho
                DataTable detalle_despacho,

                //Panel Financiera
                DataTable detalle_financiera,

                //Panel Datos de Contacto
                DataTable detalle_contacto,

                //Datos Auxiliares
                int facturacion_autosql, int credito_autosql, int despacho_autosql, int financiera_autosql, int contacto_autosql,

                //SI VALIDA SI SE REALIZA O NO LA VALIDACION
                int tran_faturacion, int tran_credito, int tran_despacho, int tran_financiera, int tran_contacto,

                //VARIABLES PARA LA VALIDACION DE LOS CHEBOXT DEL PANEL DATOS BASICOS
                int efectivo, int debito, int credito, int contado
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Datos Auxiliares y Llaves Primaria
            Obj.Idtipo = idtipo;
            Obj.Idgrupo = idgrupo;

            //Datos Basicos
            Obj.Dat_Codigo = codigo;
            Obj.Dat_Cliente = cliente;
            Obj.Dat_Documento = documento;
            Obj.Dat_Telefono = telefonoprin;
            Obj.Dat_Movil = movilprin;
            Obj.Dat_TelefonoAux = telefonoaux;
            Obj.Dat_MovilAux = movilaux;
            Obj.Dat_Correo = correo;
            Obj.Dat_Pais = pais;
            Obj.Dat_Ciudad = ciudad;
            Obj.Dat_Departamento = departamento;
            Obj.Dat_PaginaWeb = paginaweb;
            Obj.Dat_Direccion = direccion;
            Obj.Dat_Observacion = observacion;

            //Panel Facturacion
            Obj.Det_Facturacion = detalle_facturacion;

            //Panel Credito
            Obj.Det_Credito = detalle_credito;

            //Panel Despacho
            Obj.Det_Despacho = detalle_despacho;

            //Panel Financiera
            Obj.Det_Financiera = detalle_financiera;

            //Panel Datos de Contacto
            Obj.Det_Contacto = detalle_contacto;

            //Datos Auxiliares
            Obj.Facturacion_AutoSQL = facturacion_autosql;
            Obj.Credito_AutoSQL = credito_autosql;
            Obj.Despacho_AutoSQL = despacho_autosql;
            Obj.Financiera_AutoSQL = financiera_autosql;
            Obj.Contacto_AutoSQL = contacto_autosql;

            //SI VALIDA SI SE REALIZA O NO LA VALIDACION
            Obj.Tran_Facturacion = tran_faturacion;
            Obj.Tran_Credito = tran_credito;
            Obj.Tran_Despacho = tran_despacho;
            Obj.Tran_Financiera = tran_financiera;
            Obj.Tran_Contacto = tran_contacto;

            //VARIABLES PARA LA VALIDACION DE LOS CHEBOXT DEL PANEL DATOS BASICOS
            Obj.Dat_Efectivo = efectivo;
            Obj.Dat_Debito = debito;
            Obj.Dat_Credito = credito;
            Obj.Dat_Contado = contado;

            //Variables
            Obj.Auto = auto;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idcliente, int idtipo, int idgrupo,

                //Datos Basicos
                string codigo, string cliente, string documento, string telefonoprin, string movilprin, string telefonoaux, string movilaux,
                string correo, string pais, string ciudad, string departamento, string paginaweb, string direccion, string observacion
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Datos Auxiliares y Llaves Primaria
            Obj.Idcliente = idcliente;
            Obj.Idcliente = idcliente;
            Obj.Idtipo = idtipo;
            Obj.Idgrupo = idgrupo;

            //Datos Basicos
            Obj.Dat_Codigo = codigo;
            Obj.Dat_Cliente = cliente;
            Obj.Dat_Documento = documento;
            Obj.Dat_Telefono = telefonoprin;
            Obj.Dat_Movil = movilprin;
            Obj.Dat_TelefonoAux = telefonoaux;
            Obj.Dat_MovilAux = movilaux;
            Obj.Dat_Correo = correo;
            Obj.Dat_Pais = pais;
            Obj.Dat_Ciudad = ciudad;
            Obj.Dat_Departamento = departamento;
            Obj.Dat_PaginaWeb = paginaweb;
            Obj.Dat_Direccion = direccion;
            Obj.Dat_Observacion = observacion;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Editar_Ubicacion
            (
                //
                int idcliente,

                //Panel Codigo de Barra
                string ubicacion, string estante, string nivel,

                //Datos Auxiliares
                int auto
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            ////Panel Ubicacion
            //Obj.idcliente = idcliente;
            //Obj.Ubicacion = ubicacion;
            //Obj.Estante = estante;
            //Obj.Nivel = nivel;

            ////Datos Auxiliares
            //Obj.AutoDet_Ubicacion = auto;

            return Datos.Editar_Ubicacion(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }

        public static string Eliminar_Contacto(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Contacto(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Credito(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Credito(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Despacho(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Despacho(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Facturacion(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Facturacion(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Financiera(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Financiera(Idcliente, Iddetalle, Auto);
        }


    }
}
