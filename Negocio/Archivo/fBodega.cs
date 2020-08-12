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
        public static DataTable Lista()
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            return Datos.Lista();
        }

        public static DataTable AutoComplementar_SQL(string Filtro)
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            return Datos.AutoComplementar_SQL(Filtro);
        }

        public static DataTable AutoDetalle_SQL(string Filtro, int auto)
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            return Datos.AutoDetalle_SQL(Filtro, auto);
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
                string Bodega, string Documento, string Descripcion, string Director, string Ciudad, string Telefono,
                string Movil, string Correo, string Dimensiones, string Direccion01, string Direccion02, string Zona,

                //Datos de Pago
                string AutorizacionDePagos, string InicioHorarioPagos, string FinHorarioPagos, int Lunes_Pagos, int Martes_Pagos, int Miercoles_Pagos,
                int Jueves_Pagos, int Viernes_Pagos, int Sabado_Pagos, int Domingo_Pagos, int Bono, int Cheques, int credito, int Debito, int Efectivo,
                int Sodexo, int Transferencia, int Otros,

                //Datos de Recepcion
                string Recepcion, string InicioHorarioRecepcion, string FinHorarioRecepcion, int Lunes_Recepcion, int Martes_Recepcion, int Miercoles_Recepcion,
                int Jueves_Recepcion, int Viernes_Recepcion, int Sabado_Recepcion, int Domingo_Recepcion, string Encargado_Recepcion, string Observacion_Recepcion,

                //Datos de Despacho
                string Despacho, string InicioHorarioDespacho, string FinHorarioDespacho, int Lunes_Despacho, int Martes_Despacho, int Miercoles_Despacho,
                int Jueves_Despacho, int Viernes_Despacho, int Sabado_Despacho, int Domingo_Despacho, string Encargado_Despacho, string Observacion_Despacho
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
            Obj.Telefono = Telefono;
            Obj.Movil = Movil;
            Obj.Correo = Correo;
            Obj.Dimensiones = Dimensiones;
            Obj.Direccion01 = Direccion01;
            Obj.Direccion02 = Direccion02;
            Obj.Zona = Zona;

            //Datos de Pago
            Obj.AutorizacionDePagos = AutorizacionDePagos;
            Obj.InicioHorarioPagos = InicioHorarioPagos;
            Obj.FinHorarioPagos = FinHorarioPagos;
            Obj.Lunes_Pagos = Lunes_Pagos;
            Obj.Martes_Pagos = Martes_Pagos;
            Obj.Miercoles_Pagos = Miercoles_Pagos;
            Obj.Jueves_Pagos = Jueves_Pagos;
            Obj.Viernes_Pagos = Viernes_Pagos;
            Obj.Sabado_Pagos = Sabado_Pagos;
            Obj.Domingo_Pagos = Domingo_Pagos;
            Obj.Bono = Bono;
            Obj.Cheques = Cheques;
            Obj.Credito = credito;
            Obj.Debito = Debito;
            Obj.Efectivo = Efectivo;
            Obj.Sodexo = Sodexo;
            Obj.Transferencia = Transferencia;
            Obj.Otros = Otros;

            //Datos de Recepcion
            Obj.Recepcion = Recepcion;
            Obj.InicioHorarioRecepcion = InicioHorarioRecepcion;
            Obj.FinHorarioRecepcion = FinHorarioRecepcion;
            Obj.Lunes_Recepcion = Lunes_Recepcion;
            Obj.Martes_Recepcion = Martes_Recepcion;
            Obj.Miercoles_Recepcion = Miercoles_Recepcion;
            Obj.Jueves_Recepcion = Jueves_Recepcion;
            Obj.Viernes_Recepcion = Viernes_Recepcion;
            Obj.Sabado_Recepcion = Sabado_Recepcion;
            Obj.Domingo_Recepcion = Domingo_Recepcion;
            Obj.Encargado_Recepcion = Encargado_Recepcion;
            Obj.Observacion_Recepcion = Observacion_Recepcion;

            //Datos de Despacho
            Obj.Despacho = Despacho;
            Obj.InicioHorarioDespacho = InicioHorarioDespacho;
            Obj.FinHorarioDespacho = FinHorarioDespacho;
            Obj.Lunes_Despacho = Lunes_Despacho;
            Obj.Martes_Despacho = Martes_Despacho;
            Obj.Miercoles_Despacho = Miercoles_Despacho;
            Obj.Jueves_Despacho = Jueves_Despacho;
            Obj.Viernes_Despacho = Viernes_Despacho;
            Obj.Sabado_Despacho = Sabado_Despacho;
            Obj.Domingo_Despacho = Domingo_Despacho;
            Obj.Encargado_Despacho = Encargado_Despacho;
            Obj.Observacion_Despacho = Observacion_Despacho;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idbodega, int idsucurzal,

                //Datos Basicos
                string Bodega, string Documento, string Descripcion, string Director, string Ciudad, string Telefono,
                string Movil, string Correo, string Dimensiones, string Direccion01, string Direccion02, string Zona,

                //Datos de Pago
                string AutorizacionDePagos, string InicioHorarioPagos, string FinHorarioPagos, int Lunes_Pagos, int Martes_Pagos, int Miercoles_Pagos,
                int Jueves_Pagos, int Viernes_Pagos, int Sabado_Pagos, int Domingo_Pagos, int Bono, int Cheques, int credito, int Debito, int Efectivo,
                int Sodexo, int Transferencia, int Otros,

                //Datos de Recepcion
                string Recepcion, string InicioHorarioRecepcion, string FinHorarioRecepcion, int Lunes_Recepcion, int Martes_Recepcion, int Miercoles_Recepcion,
                int Jueves_Recepcion, int Viernes_Recepcion, int Sabado_Recepcion, int Domingo_Recepcion, string Encargado_Recepcion, string Observacion_Recepcion,

                //Datos de Despacho
                string Despacho, string InicioHorarioDespacho, string FinHorarioDespacho, int Lunes_Despacho, int Martes_Despacho, int Miercoles_Despacho,
                int Jueves_Despacho, int Viernes_Despacho, int Sabado_Despacho, int Domingo_Despacho, string Encargado_Despacho, string Observacion_Despacho
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
            Obj.Telefono = Telefono;
            Obj.Movil = Movil;
            Obj.Correo = Correo;
            Obj.Dimensiones = Dimensiones;
            Obj.Direccion01 = Direccion01;
            Obj.Direccion02 = Direccion02;
            Obj.Zona = Zona;

            //Datos de Pago
            Obj.AutorizacionDePagos = AutorizacionDePagos;
            Obj.InicioHorarioPagos = InicioHorarioPagos;
            Obj.FinHorarioPagos = FinHorarioPagos;
            Obj.Lunes_Pagos = Lunes_Pagos;
            Obj.Martes_Pagos = Martes_Pagos;
            Obj.Miercoles_Pagos = Miercoles_Pagos;
            Obj.Jueves_Pagos = Jueves_Pagos;
            Obj.Viernes_Pagos = Viernes_Pagos;
            Obj.Sabado_Pagos = Sabado_Pagos;
            Obj.Domingo_Pagos = Domingo_Pagos;
            Obj.Bono = Bono;
            Obj.Cheques = Cheques;
            Obj.Credito = credito;
            Obj.Debito = Debito;
            Obj.Efectivo = Efectivo;
            Obj.Sodexo = Sodexo;
            Obj.Transferencia = Transferencia;
            Obj.Otros = Otros;

            //Datos de Recepcion
            Obj.Recepcion = Recepcion;
            Obj.InicioHorarioRecepcion = InicioHorarioRecepcion;
            Obj.FinHorarioRecepcion = FinHorarioRecepcion;
            Obj.Lunes_Recepcion = Lunes_Recepcion;
            Obj.Martes_Recepcion = Martes_Recepcion;
            Obj.Miercoles_Recepcion = Miercoles_Recepcion;
            Obj.Jueves_Recepcion = Jueves_Recepcion;
            Obj.Viernes_Recepcion = Viernes_Recepcion;
            Obj.Sabado_Recepcion = Sabado_Recepcion;
            Obj.Domingo_Recepcion = Domingo_Recepcion;
            Obj.Encargado_Recepcion = Encargado_Recepcion;
            Obj.Observacion_Recepcion = Observacion_Recepcion;

            //Datos de Despacho
            Obj.Despacho = Despacho;
            Obj.InicioHorarioDespacho = InicioHorarioDespacho;
            Obj.FinHorarioDespacho = FinHorarioDespacho;
            Obj.Lunes_Despacho = Lunes_Despacho;
            Obj.Martes_Despacho = Martes_Despacho;
            Obj.Miercoles_Despacho = Miercoles_Despacho;
            Obj.Jueves_Despacho = Jueves_Despacho;
            Obj.Viernes_Despacho = Viernes_Despacho;
            Obj.Sabado_Despacho = Sabado_Despacho;
            Obj.Domingo_Despacho = Domingo_Despacho;
            Obj.Encargado_Despacho = Encargado_Despacho;
            Obj.Observacion_Despacho = Observacion_Despacho;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Bodega Datos = new Conexion_Bodega();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}
