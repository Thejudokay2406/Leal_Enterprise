using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Cliente
    {
        //Llave primaria y Auxiliares
        private int _Idcliente;
        private int _Idtipo;
        private int _Idgrupo;
        private int _Idempleado;
        private int _Idbanco;

        private int _Idfacturacion;
        private int _Idcredito;
        private int _Iddespacho;
        private int _Idfinanciera;
        private int _Idcontacto;

        //Datos Basicos
        private string _Dat_Codigo;
        private string _Dat_Cliente;
        private string _Dat_Documento;
        private Int64 _Dat_Telefono;
        private Int64 _Dat_TelefonoAux;
        private Int64 _Dat_Movil;
        private Int64 _Dat_MovilAux;
        private string _Dat_Correo;
        private string _Dat_Pais;
        private string _Dat_Ciudad;
        private string _Dat_Departamento;
        private string _Dat_PaginaWeb;
        private string _Dat_Direccion;
        private string _Dat_Observacion;
        private int _Dat_Credito;
        private int _Dat_Contado;
        private int _Dat_Debito;
        private int _Dat_Efectivo;

        //Datos de Facturacion
        private string _Fac_Asesor;
        private string _Fac_AsesorCodigo;
        private string _Fac_Cliente;
        private string _Fac_ClienteDoc;
        private Int64 _Fac_Movil;
        private string _Fac_Pais;
        private string _Fac_Ciudad;
        private string _Fac_Departamento;
        private string _Fac_Correo;

        //Datos de Credito
        private string _Cre_Valor;
        private Int64 _Cre_Cuotas;
        private Int64 _Cre_TasaMensual;
        private Int64 _Cre_TasaAnual;
        private DateTime _Cre_Solicitud;
        private DateTime _Cre_Emision;
        private Int64 _Cre_Prorroga;
        private Int64 _Cre_TasaMora;

        //Datos de Envios
        private string _Des_Sucurzal;
        private string _Des_Pais;
        private string _Des_Ciudad;
        private string _Des_Departamento;
        private string _Des_Receptor;
        private string _Des_Barrio;
        private string _Des_Apartamento;
        private Int64 _Des_Movil;
        private string _Des_Direccion;
        private string _Des_Observacion;
        
        //Datos de Financiera
        private string _Fin_Banco;
        private string _Fin_BancoCodigo;
        private string _Fin_Cuenta;
        private Int64 _Fin_CuentaNumero;

        //Datos de Contacto
        private string _Cont_Contacto;
        private string _Cont_Ciudad;
        private string _Cont_Direccion;
        private Int64 _Cont_Telefono;
        private Int64 _Cont_Movil;
        private string _Cont_Correo;
        private string _Cont_Parentesco;
        
        //Datos Auxiliares para Editar los Detalles
        private int _AutoDet_Facturacion;
        private int _AutoDet_Despacho;
        private int _AutoDet_Credito;
        private int _AutoDet_Financiera;
        private int _AutoDet_Contacto;

        //Datos Para Filtrar los Multiples registro del Cliente Como Facturacion, Despachos ETC
        private int _Auto_Facturacion;
        private int _Auto_Despacho;
        private int _Auto_Credito;
        private int _Auto_Financiera;
        private int _Auto_Contacto;

        private DataTable _Det_Facturacion;
        private DataTable _Det_Despacho;
        private DataTable _Det_Credito;
        private DataTable _Det_Financiera;
        private DataTable _Det_Contacto;

        //Datos para Ejecutar las Transacciones en SQL
        private int _Facturacion_AutoSQL;
        private int _Despacho_AutoSQL;
        private int _Credito_AutoSQL;
        private int _Financiera_AutoSQL;
        private int _Contacto_AutoSQL;

        //
        private int _Tran_Facturacion;
        private int _Tran_Despacho;
        private int _Tran_Credito;
        private int _Tran_Financiera;
        private int _Tran_Contacto;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtipo { get => _Idtipo; set => _Idtipo = value; }
        public int Idgrupo { get => _Idgrupo; set => _Idgrupo = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Idbanco { get => _Idbanco; set => _Idbanco = value; }
        public int Idfacturacion { get => _Idfacturacion; set => _Idfacturacion = value; }
        public int Idcredito { get => _Idcredito; set => _Idcredito = value; }
        public int Iddespacho { get => _Iddespacho; set => _Iddespacho = value; }
        public int Idfinanciera { get => _Idfinanciera; set => _Idfinanciera = value; }
        public int Idcontacto { get => _Idcontacto; set => _Idcontacto = value; }
        public string Dat_Codigo { get => _Dat_Codigo; set => _Dat_Codigo = value; }
        public string Dat_Cliente { get => _Dat_Cliente; set => _Dat_Cliente = value; }
        public string Dat_Documento { get => _Dat_Documento; set => _Dat_Documento = value; }
        public long Dat_Telefono { get => _Dat_Telefono; set => _Dat_Telefono = value; }
        public long Dat_TelefonoAux { get => _Dat_TelefonoAux; set => _Dat_TelefonoAux = value; }
        public long Dat_Movil { get => _Dat_Movil; set => _Dat_Movil = value; }
        public long Dat_MovilAux { get => _Dat_MovilAux; set => _Dat_MovilAux = value; }
        public string Dat_Correo { get => _Dat_Correo; set => _Dat_Correo = value; }
        public string Dat_Pais { get => _Dat_Pais; set => _Dat_Pais = value; }
        public string Dat_Ciudad { get => _Dat_Ciudad; set => _Dat_Ciudad = value; }
        public string Dat_Departamento { get => _Dat_Departamento; set => _Dat_Departamento = value; }
        public string Dat_PaginaWeb { get => _Dat_PaginaWeb; set => _Dat_PaginaWeb = value; }
        public string Dat_Direccion { get => _Dat_Direccion; set => _Dat_Direccion = value; }
        public string Dat_Observacion { get => _Dat_Observacion; set => _Dat_Observacion = value; }
        public int Dat_Credito { get => _Dat_Credito; set => _Dat_Credito = value; }
        public int Dat_Contado { get => _Dat_Contado; set => _Dat_Contado = value; }
        public int Dat_Debito { get => _Dat_Debito; set => _Dat_Debito = value; }
        public int Dat_Efectivo { get => _Dat_Efectivo; set => _Dat_Efectivo = value; }
        public string Fac_Asesor { get => _Fac_Asesor; set => _Fac_Asesor = value; }
        public string Fac_AsesorCodigo { get => _Fac_AsesorCodigo; set => _Fac_AsesorCodigo = value; }
        public string Fac_Cliente { get => _Fac_Cliente; set => _Fac_Cliente = value; }
        public string Fac_ClienteDoc { get => _Fac_ClienteDoc; set => _Fac_ClienteDoc = value; }
        public long Fac_Movil { get => _Fac_Movil; set => _Fac_Movil = value; }
        public string Fac_Pais { get => _Fac_Pais; set => _Fac_Pais = value; }
        public string Fac_Ciudad { get => _Fac_Ciudad; set => _Fac_Ciudad = value; }
        public string Fac_Departamento { get => _Fac_Departamento; set => _Fac_Departamento = value; }
        public string Fac_Correo { get => _Fac_Correo; set => _Fac_Correo = value; }
        public string Cre_Valor { get => _Cre_Valor; set => _Cre_Valor = value; }
        public long Cre_Cuotas { get => _Cre_Cuotas; set => _Cre_Cuotas = value; }
        public long Cre_TasaMensual { get => _Cre_TasaMensual; set => _Cre_TasaMensual = value; }
        public long Cre_TasaAnual { get => _Cre_TasaAnual; set => _Cre_TasaAnual = value; }
        public DateTime Cre_Solicitud { get => _Cre_Solicitud; set => _Cre_Solicitud = value; }
        public DateTime Cre_Emision { get => _Cre_Emision; set => _Cre_Emision = value; }
        public long Cre_Prorroga { get => _Cre_Prorroga; set => _Cre_Prorroga = value; }
        public long Cre_TasaMora { get => _Cre_TasaMora; set => _Cre_TasaMora = value; }
        public string Des_Sucurzal { get => _Des_Sucurzal; set => _Des_Sucurzal = value; }
        public string Des_Pais { get => _Des_Pais; set => _Des_Pais = value; }
        public string Des_Ciudad { get => _Des_Ciudad; set => _Des_Ciudad = value; }
        public string Des_Departamento { get => _Des_Departamento; set => _Des_Departamento = value; }
        public string Des_Receptor { get => _Des_Receptor; set => _Des_Receptor = value; }
        public string Des_Barrio { get => _Des_Barrio; set => _Des_Barrio = value; }
        public string Des_Apartamento { get => _Des_Apartamento; set => _Des_Apartamento = value; }
        public long Des_Movil { get => _Des_Movil; set => _Des_Movil = value; }
        public string Des_Direccion { get => _Des_Direccion; set => _Des_Direccion = value; }
        public string Des_Observacion { get => _Des_Observacion; set => _Des_Observacion = value; }
        public string Fin_Banco { get => _Fin_Banco; set => _Fin_Banco = value; }
        public string Fin_BancoCodigo { get => _Fin_BancoCodigo; set => _Fin_BancoCodigo = value; }
        public string Fin_Cuenta { get => _Fin_Cuenta; set => _Fin_Cuenta = value; }
        public long Fin_CuentaNumero { get => _Fin_CuentaNumero; set => _Fin_CuentaNumero = value; }
        public string Cont_Contacto { get => _Cont_Contacto; set => _Cont_Contacto = value; }
        public string Cont_Ciudad { get => _Cont_Ciudad; set => _Cont_Ciudad = value; }
        public string Cont_Direccion { get => _Cont_Direccion; set => _Cont_Direccion = value; }
        public long Cont_Telefono { get => _Cont_Telefono; set => _Cont_Telefono = value; }
        public long Cont_Movil { get => _Cont_Movil; set => _Cont_Movil = value; }
        public string Cont_Correo { get => _Cont_Correo; set => _Cont_Correo = value; }
        public string Cont_Parentesco { get => _Cont_Parentesco; set => _Cont_Parentesco = value; }
        public int AutoDet_Facturacion { get => _AutoDet_Facturacion; set => _AutoDet_Facturacion = value; }
        public int AutoDet_Despacho { get => _AutoDet_Despacho; set => _AutoDet_Despacho = value; }
        public int AutoDet_Credito { get => _AutoDet_Credito; set => _AutoDet_Credito = value; }
        public int AutoDet_Financiera { get => _AutoDet_Financiera; set => _AutoDet_Financiera = value; }
        public int AutoDet_Contacto { get => _AutoDet_Contacto; set => _AutoDet_Contacto = value; }
        public int Auto_Facturacion { get => _Auto_Facturacion; set => _Auto_Facturacion = value; }
        public int Auto_Despacho { get => _Auto_Despacho; set => _Auto_Despacho = value; }
        public int Auto_Credito { get => _Auto_Credito; set => _Auto_Credito = value; }
        public int Auto_Financiera { get => _Auto_Financiera; set => _Auto_Financiera = value; }
        public int Auto_Contacto { get => _Auto_Contacto; set => _Auto_Contacto = value; }
        public DataTable Det_Facturacion { get => _Det_Facturacion; set => _Det_Facturacion = value; }
        public DataTable Det_Despacho { get => _Det_Despacho; set => _Det_Despacho = value; }
        public DataTable Det_Credito { get => _Det_Credito; set => _Det_Credito = value; }
        public DataTable Det_Financiera { get => _Det_Financiera; set => _Det_Financiera = value; }
        public DataTable Det_Contacto { get => _Det_Contacto; set => _Det_Contacto = value; }
        public int Facturacion_AutoSQL { get => _Facturacion_AutoSQL; set => _Facturacion_AutoSQL = value; }
        public int Despacho_AutoSQL { get => _Despacho_AutoSQL; set => _Despacho_AutoSQL = value; }
        public int Credito_AutoSQL { get => _Credito_AutoSQL; set => _Credito_AutoSQL = value; }
        public int Financiera_AutoSQL { get => _Financiera_AutoSQL; set => _Financiera_AutoSQL = value; }
        public int Contacto_AutoSQL { get => _Contacto_AutoSQL; set => _Contacto_AutoSQL = value; }
        public int Tran_Facturacion { get => _Tran_Facturacion; set => _Tran_Facturacion = value; }
        public int Tran_Despacho { get => _Tran_Despacho; set => _Tran_Despacho = value; }
        public int Tran_Credito { get => _Tran_Credito; set => _Tran_Credito = value; }
        public int Tran_Financiera { get => _Tran_Financiera; set => _Tran_Financiera = value; }
        public int Tran_Contacto { get => _Tran_Contacto; set => _Tran_Contacto = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}
