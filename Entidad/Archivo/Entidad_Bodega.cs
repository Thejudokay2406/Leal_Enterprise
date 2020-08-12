using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Bodega
    {
        //Llave primaria
        private int _Idbodega;

        //Llaves Auxiliares
        private int _Idsucurzal;

        //Datos Basicos
        private string _Bodega;
        private string _Documento;
        private string _Descripcion;
        private string _Director;
        private string _Ciudad;
        private string _Telefono;
        private string _Movil;
        private string _Correo;
        private string _Dimensiones;
        private string _Direccion01;
        private string _Direccion02;
        private string _Zona;

        //Datos de Pago
        private string _AutorizacionDePagos;
        private string _InicioHorarioPagos;
        private string _FinHorarioPagos;
        private int _Lunes_Pagos;
        private int _Martes_Pagos;
        private int _Miercoles_Pagos;
        private int _Jueves_Pagos;
        private int _Viernes_Pagos;
        private int _Sabado_Pagos;
        private int _Domingo_Pagos;
        private int _Bono;
        private int _Cheques;
        private int _Credito;
        private int _Debito;
        private int _Efectivo;
        private int _Sodexo;
        private int _Transferencia;
        private int _Otros;

        //Datos de Recepcion
        private string _Recepcion;
        private string _InicioHorarioRecepcion;
        private string _FinHorarioRecepcion;
        private int _Lunes_Recepcion;
        private int _Martes_Recepcion;
        private int _Miercoles_Recepcion;
        private int _Jueves_Recepcion;
        private int _Viernes_Recepcion;
        private int _Sabado_Recepcion;
        private int _Domingo_Recepcion;
        private string _Encargado_Recepcion;
        private string _Observacion_Recepcion;

        //Datos de Despacho
        private string _Despacho;
        private string _InicioHorarioDespacho;
        private string _FinHorarioDespacho;
        private int _Lunes_Despacho;
        private int _Martes_Despacho;
        private int _Miercoles_Despacho;
        private int _Jueves_Despacho;
        private int _Viernes_Despacho;
        private int _Sabado_Despacho;
        private int _Domingo_Despacho;
        private string _Encargado_Despacho;
        private string _Observacion_Despacho;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private int _Validacion_SQL;
        private string _Filtro;

        public int Idbodega { get => _Idbodega; set => _Idbodega = value; }
        public int Idsucurzal { get => _Idsucurzal; set => _Idsucurzal = value; }
        public string Bodega { get => _Bodega; set => _Bodega = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Director { get => _Director; set => _Director = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Dimensiones { get => _Dimensiones; set => _Dimensiones = value; }
        public string Direccion01 { get => _Direccion01; set => _Direccion01 = value; }
        public string Direccion02 { get => _Direccion02; set => _Direccion02 = value; }
        public string Zona { get => _Zona; set => _Zona = value; }
        public string AutorizacionDePagos { get => _AutorizacionDePagos; set => _AutorizacionDePagos = value; }
        public string InicioHorarioPagos { get => _InicioHorarioPagos; set => _InicioHorarioPagos = value; }
        public string FinHorarioPagos { get => _FinHorarioPagos; set => _FinHorarioPagos = value; }
        public int Lunes_Pagos { get => _Lunes_Pagos; set => _Lunes_Pagos = value; }
        public int Martes_Pagos { get => _Martes_Pagos; set => _Martes_Pagos = value; }
        public int Miercoles_Pagos { get => _Miercoles_Pagos; set => _Miercoles_Pagos = value; }
        public int Jueves_Pagos { get => _Jueves_Pagos; set => _Jueves_Pagos = value; }
        public int Viernes_Pagos { get => _Viernes_Pagos; set => _Viernes_Pagos = value; }
        public int Sabado_Pagos { get => _Sabado_Pagos; set => _Sabado_Pagos = value; }
        public int Domingo_Pagos { get => _Domingo_Pagos; set => _Domingo_Pagos = value; }
        public int Bono { get => _Bono; set => _Bono = value; }
        public int Cheques { get => _Cheques; set => _Cheques = value; }
        public int Debito { get => _Debito; set => _Debito = value; }
        public int Efectivo { get => _Efectivo; set => _Efectivo = value; }
        public int Sodexo { get => _Sodexo; set => _Sodexo = value; }
        public int Transferencia { get => _Transferencia; set => _Transferencia = value; }
        public int Otros { get => _Otros; set => _Otros = value; }
        public string Recepcion { get => _Recepcion; set => _Recepcion = value; }
        public string InicioHorarioRecepcion { get => _InicioHorarioRecepcion; set => _InicioHorarioRecepcion = value; }
        public string FinHorarioRecepcion { get => _FinHorarioRecepcion; set => _FinHorarioRecepcion = value; }
        public int Lunes_Recepcion { get => _Lunes_Recepcion; set => _Lunes_Recepcion = value; }
        public int Martes_Recepcion { get => _Martes_Recepcion; set => _Martes_Recepcion = value; }
        public int Miercoles_Recepcion { get => _Miercoles_Recepcion; set => _Miercoles_Recepcion = value; }
        public int Jueves_Recepcion { get => _Jueves_Recepcion; set => _Jueves_Recepcion = value; }
        public int Viernes_Recepcion { get => _Viernes_Recepcion; set => _Viernes_Recepcion = value; }
        public int Sabado_Recepcion { get => _Sabado_Recepcion; set => _Sabado_Recepcion = value; }
        public int Domingo_Recepcion { get => _Domingo_Recepcion; set => _Domingo_Recepcion = value; }
        public string Encargado_Recepcion { get => _Encargado_Recepcion; set => _Encargado_Recepcion = value; }
        public string Observacion_Recepcion { get => _Observacion_Recepcion; set => _Observacion_Recepcion = value; }
        public string Despacho { get => _Despacho; set => _Despacho = value; }
        public string InicioHorarioDespacho { get => _InicioHorarioDespacho; set => _InicioHorarioDespacho = value; }
        public string FinHorarioDespacho { get => _FinHorarioDespacho; set => _FinHorarioDespacho = value; }
        public int Lunes_Despacho { get => _Lunes_Despacho; set => _Lunes_Despacho = value; }
        public int Martes_Despacho { get => _Martes_Despacho; set => _Martes_Despacho = value; }
        public int Miercoles_Despacho { get => _Miercoles_Despacho; set => _Miercoles_Despacho = value; }
        public int Jueves_Despacho { get => _Jueves_Despacho; set => _Jueves_Despacho = value; }
        public int Viernes_Despacho { get => _Viernes_Despacho; set => _Viernes_Despacho = value; }
        public int Sabado_Despacho { get => _Sabado_Despacho; set => _Sabado_Despacho = value; }
        public int Domingo_Despacho { get => _Domingo_Despacho; set => _Domingo_Despacho = value; }
        public string Encargado_Despacho { get => _Encargado_Despacho; set => _Encargado_Despacho = value; }
        public string Observacion_Despacho { get => _Observacion_Despacho; set => _Observacion_Despacho = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public int Validacion_SQL { get => _Validacion_SQL; set => _Validacion_SQL = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Credito { get => _Credito; set => _Credito = value; }
    }
}
